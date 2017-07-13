//using System;
//using System.Collections;
//using System.Configuration;
//using System.Data;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Collections.Specialized;
//using Application.Common;
//using Application.Presentation;
//using Interface.Security;
//using System.Threading;
//using Interface.Administration;
//using Interface.Clinical;

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;

using Application.Common;
using Application.Presentation;
using Interface.Security;
using System.Threading;



public partial class frmConnect : System.Web.UI.Page
{
    private void Init_Form(String un, String pass, String uID, String fID)
    {

        //// Setting Application/Session Parameters /////

        Session.Timeout = Convert.ToInt32(((NameValueCollection)ConfigurationSettings.GetConfig("appSettings"))["SessionTimeOut"]);
        Session.Add("AppUserId", "");
        Session.Add("AppUserName", "");
        Session.Add("EnrollFlag", "");
        Session.Add("IdentifierFlag", "");
        Session.Add("AppLocationId", "");
        Session.Add("AppLocation", "");
        Session.Add("AppCountryId", "");
        Session.Add("AppPosID", "");
        Session.Add("AppSatelliteId", "");
        Session.Add("GracePeriod", "");
        Session.Add("AppDateFormat", "");
        Session.Add("UserRight", "");
        Session.Add("BackupDrive", "");
        Session.Add("SystemId", "");
        Session.Add("ModuleId", "");
        Application.Add("AppCurrentDate", "");
        Session.Add("Program", "");
        Session.Add("AppCurrency", "");
        Session.Add("AppUserEmployeeId", "");
        Session.Add("CustomfrmDrug", "");
        Session.Add("CustomfrmLab", "");
        ////////////////////////////////////////

        IUser LoginManager;
        try
        {
            LoginManager = (IUser)ObjectFactory.CreateInstance("BusinessProcess.Security.BUser, BusinessProcess.Security");
            DataSet theDS = LoginManager.GetUserCredentials(un.Trim(), Convert.ToInt32(fID), 1);
            if (theDS.Tables.Count > 0)
            {
                Utility theUtil = new Utility();
                
                if (theUtil.Decrypt(Convert.ToString(theDS.Tables[0].Rows[0]["Password"])) == pass.Trim())
                {


                    Session["AppUserId"] = Convert.ToString(theDS.Tables[0].Rows[0]["UserId"]);
                    Session["AppUserName"] = Convert.ToString(theDS.Tables[0].Rows[0]["UserFirstName"]) + " " + Convert.ToString(theDS.Tables[0].Rows[0]["UserLastName"]);
                    Session["EnrollFlag"] = theDS.Tables[1].Rows[0]["EnrollmentFlag"].ToString();
                    Session["CareEndFlag"] = theDS.Tables[1].Rows[0]["CareEndFlag"].ToString();
                    Session["IdentifierFlag"] = theDS.Tables[1].Rows[0]["IdentifierFlag"].ToString();
                    Session["UserRight"] = theDS.Tables[1];
                    DataTable theDT = theDS.Tables[2];
                    Session["AppLocationId"] = theDT.Rows[0]["FacilityID"].ToString();
                    Session["AppLocation"] = theDT.Rows[0]["FacilityName"].ToString();
                    Session["AppCountryId"] = theDT.Rows[0]["CountryID"].ToString();
                    Session["AppPosID"] = theDT.Rows[0]["PosID"].ToString();
                    Session["AppSatelliteId"] = theDT.Rows[0]["SatelliteID"].ToString();
                    Session["GracePeriod"] = theDT.Rows[0]["AppGracePeriod"].ToString();
                    Session["AppDateFormat"] = theDT.Rows[0]["DateFormat"].ToString();
                    Session["BackupDrive"] = theDT.Rows[0]["BackupDrive"].ToString();
                    Session["SystemId"] = theDT.Rows[0]["SystemId"].ToString();
                    Session["AppCurrency"] = theDT.Rows[0]["Currency"].ToString();
                    Session["AppUserEmployeeId"] = theDS.Tables[0].Rows[0]["EmployeeId"].ToString();

                    //Session["AppSystemId"] = theDT.Rows[0]["SystemId"].ToString();

                    
                    Session["AppModule"] = theDS.Tables[3];
                    DataView theSCMDV = new DataView(theDS.Tables[3]);
					theSCMDV.RowFilter = "ModuleId=201";
					if (theSCMDV.Count > 0)
                    Session["SCMModule"] = theSCMDV[0]["ModuleName"];


                    IQWebUtils theIQUtils = new IQWebUtils();
                    //theIQUtils.CreateSessionObject(Session.SessionID); 
                    Session["Paperless"] = theDT.Rows[0]["Paperless"].ToString();
                    Session["Program"] = "";
                    LoginManager = null;
                   
                }
                else
                {
                    IQCareMsgBox.Show("PasswordNotMatch", this);
                    
                    Response.Redirect("frmLogin.aspx");
                    //return;
                }
            }
            
        }
        catch (Exception err)
        {
            MsgBuilder theBuilder = new MsgBuilder();
            theBuilder.DataElements["MessageText"] = err.Message.ToString();
            IQCareMsgBox.Show("#C1", theBuilder, this);
        }
        finally
        {
            LoginManager = null;
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        String encryptUrl = Request.QueryString["enc"];
        encryptUrl = encryptUrl.Replace(" ", "+");
        Utility theUtil = new Utility();
        String decryptUrl = theUtil.Decrypt(encryptUrl);
        String ptnpk = decryptUrl.Substring(decryptUrl.IndexOf("ptn_pk=") + 8, decryptUrl.IndexOf("&UserName") - (decryptUrl.IndexOf("ptn_pk=") + 8));
        String uName = decryptUrl.Substring(decryptUrl.IndexOf("UserName=") + 9, decryptUrl.IndexOf("&Pass") - (decryptUrl.IndexOf("UserName=") + 9));
        String password = decryptUrl.Substring(decryptUrl.IndexOf("Password=") + 9, decryptUrl.IndexOf("&tech") - (decryptUrl.IndexOf("Password=") + 9));
        String technicalArea = decryptUrl.Substring(decryptUrl.IndexOf("technicalArea=") + 14, decryptUrl.IndexOf("&UserID") - (decryptUrl.IndexOf("technicalArea=") + 14));
        String userID = decryptUrl.Substring(decryptUrl.IndexOf("UserID=") + 7, decryptUrl.IndexOf("&FacilityID") - (decryptUrl.IndexOf("UserID=") + 7));
        String FacilityID = decryptUrl.Substring(decryptUrl.IndexOf("FacilityID=") + 11);

        try
        {
			Ajax.Utility.RegisterTypeForAjax(typeof(frmLogin));
			if (Page.IsPostBack != true){
            Init_Form(uName, password, userID, FacilityID);
			}
			//Response.Redirect("frmFacilityHome.aspx");            
			//Search_Patient(ptnpk, technicalArea);
			if(ptnpk == "-1")
			{
			Response.Redirect("frmFindAddPatient.aspx"); 
			//Session["PatientID"] = ptnpk.Trim();
			//Session["TechnicalAreaId"]
			//Response.Redirect("frmAddTechnicalArea.aspx");
			}
			else
			{
				Session["PatientID"] = ptnpk;
				Response.Redirect("frmAddTechnicalArea.aspx"); 
			}
        }
        catch (Exception ex) {
            MsgBuilder theBuilder = new MsgBuilder();
            theBuilder.DataElements["MessageText"] = ex.Message.ToString();
            IQCareMsgBox.Show("#C1", theBuilder, this); }
    }

    private void Search_Patient(String s, String t)
    {
		string ObjFactoryParameter = "BusinessProcess.Clinical.BPatientRegistration, BusinessProcess.Clinical";
		Hashtable GetValuefromHT;
        
        try
        {           
            Session["PatientID"] = s.Trim();
            Session["TechnicalAreaId"] = t.Trim();           
        }
        catch (Exception err)
        {
            MsgBuilder theBuilder = new MsgBuilder();
            theBuilder.DataElements["MessageText"] = err.Message.ToString();
            IQCareMsgBox.Show("#C1", theBuilder, this);
            return;
        }
        finally
        {
            //PatientManager = null;
            Response.Redirect("ClinicalForms/frmPatient_Home.aspx");
        }
    }

}
