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



public partial class frmConnect36 : System.Web.UI.Page
{
    private void Init_Form()
    {

        //Response.Write("SessionCount -" + Session.Count.ToString());
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
        Session.Add("SystemId", "1");
        Session.Add("ModuleId", "");
        Application.Add("AppCurrentDate", "");
        Session.Add("Program", "");
        Session.Add("AppCurrency", "");
        Session.Add("AppUserEmployeeId", "");
        Session.Add("CustomfrmDrug", "");
        Session.Add("CustomfrmLab", "");
        Session.Add("AppUserCustomList", "");
        Session.Add("SCMModule", null);
        ////////////////////////////////////////

        GetApplicationParameters();
        #region Login
        //IUser LoginManager;
        //try
        //{
        //    LoginManager = (IUser)ObjectFactory.CreateInstance("BusinessProcess.Security.BUser, BusinessProcess.Security");
        //    Session["SystemId"] = "1";
        //    DataSet theDS = LoginManager.GetUserCredentials(un.Trim(), Convert.ToInt32(fID), 1);
        //    if (theDS.Tables.Count > 0)
        //    {
        //        int FacilityExist = 1;
        //        if (theDS.Tables[5].Rows.Count > 0)
        //        {
        //            DataView theDV = new DataView();
        //            FacilityExist = 0;
        //            foreach (DataRow theDR in theDS.Tables[5].Rows)
        //            {
        //                if (Convert.ToInt32(theDR["GroupId"]) > 1)
        //                {
        //                    theDV = new DataView(theDS.Tables[1]);
        //                    theDV.RowFilter = "FacilityID= " + fID + "";
        //                    if (theDV.ToTable().Rows.Count > 0)
        //                    {
        //                        FacilityExist = 1;
        //                    }
        //                }
        //                else if (Convert.ToInt32(theDR["GroupId"]) == 1)
        //                {
        //                    FacilityExist = 1;
        //                }
        //            }
        //        }
        //        if (FacilityExist == 0)
        //        {
        //            IQCareMsgBox.Show("AccessDenied", this);
        //            return;
        //        }

        //        Utility theUtil = new Utility();
        //         if (theDS.Tables[0].Rows.Count > 0)
        //         {                    
        //            if (Convert.ToString(theDS.Tables[0].Rows[0]["Password"]) != theUtil.Encrypt(pass.Trim()))
        //            {
        //                if ((Request.Browser.Cookies))
        //                {
        //                    HttpCookie theCookie = Request.Cookies[un];
        //                    if (theCookie == null)
        //                    {
        //                        HttpCookie theNCookie = new HttpCookie(un);
        //                        theNCookie.Value = un + ",1";
        //                        DateTime theNewDTTime = Convert.ToDateTime(ViewState["theCurrentDate"]).AddMinutes(5);
        //                        theNCookie.Expires = theNewDTTime;
        //                        Response.Cookies.Add(theNCookie);
        //                    }

        //                    else
        //                    {
        //                        string[] theVal = (theCookie.Value.ToString()).Split(',');
        //                        if (Convert.ToInt32(theVal[1]) >= 3 && theCookie.Name == un)
        //                        {
        //                            MsgBuilder theBuilder = new MsgBuilder();
        //                            theBuilder.DataElements["MessageText"] = "User Account Locked. Try again after 5 Mins.";
        //                            IQCareMsgBox.Show("#C1", theBuilder, this);
        //                            return;
        //                        }
        //                        else
        //                        {
        //                            theVal[1] = (Convert.ToInt32(theVal[1]) + 1).ToString();
        //                            theCookie.Value = un + "," + theVal[1];
        //                            DateTime theAddNewDTTime = Convert.ToDateTime(ViewState["theCurrentDate"]).AddMinutes(5);
        //                            theCookie.Expires = theAddNewDTTime;
        //                            Response.Cookies.Add(theCookie);
        //                        }
        //                    }
        //                }
        //                IQCareMsgBox.Show("PasswordNotMatch", this);
        //                Response.Redirect("frmLogin.aspx");
        //                //Init_Form();
        //                return;
        //            }
        //            else
        //            {
        //                HttpCookie theCookie = Request.Cookies[un];
        //                if (theCookie != null)
        //                {
        //                    string[] theVal = (theCookie.Value.ToString()).Split(',');
        //                    if (Convert.ToInt32(theVal[1]) >= 3)
        //                    {
        //                        MsgBuilder theBuilder = new MsgBuilder();
        //                        theBuilder.DataElements["MessageText"] = "User Account Locked. Try again after 5 Mins.";
        //                        IQCareMsgBox.Show("#C1", theBuilder, this);
        //                        return;
        //                    }
        //                }
        //            }
        //        }

        //        else
        //        {
        //            IQCareMsgBox.Show("InvalidLogin", this);
        //            Response.Redirect("frmLogin.aspx");
        //            //Init_Form();
        //            return;
        //        }
        //            if (Convert.ToString(theDS.Tables[0].Rows[0]["Password"]) != theUtil.Encrypt(pass.Trim()))
        //            {

        //                Session["AppUserId"] = Convert.ToString(theDS.Tables[0].Rows[0]["UserId"]);
        //                Session["AppUserName"] = Convert.ToString(theDS.Tables[0].Rows[0]["UserFirstName"]) + " " + Convert.ToString(theDS.Tables[0].Rows[0]["UserLastName"]);
        //                Session["EnrollFlag"] = theDS.Tables[1].Rows[0]["EnrollmentFlag"].ToString();
        //                Session["CareEndFlag"] = theDS.Tables[1].Rows[0]["CareEndFlag"].ToString();
        //                Session["IdentifierFlag"] = theDS.Tables[1].Rows[0]["IdentifierFlag"].ToString();
        //                Session["UserRight"] = theDS.Tables[1];
        //                Session["UserFeatures"] = theDS.Tables[6];
        //                Session["AppUserCustomList"] = theDS.Tables[7];
        //                DataTable theDT = theDS.Tables[2];
        //                Session["AppLocationId"] = theDT.Rows[0]["FacilityID"].ToString();
        //                Session["AppLocation"] = theDT.Rows[0]["FacilityName"].ToString();
        //                Session["AppCountryId"] = theDT.Rows[0]["CountryID"].ToString();
        //                Session["AppPosID"] = theDT.Rows[0]["PosID"].ToString();
        //                Session["AppSatelliteId"] = theDT.Rows[0]["SatelliteID"].ToString();
        //                Session["GracePeriod"] = theDT.Rows[0]["AppGracePeriod"].ToString();
        //                Session["AppDateFormat"] = theDT.Rows[0]["DateFormat"].ToString();
        //                Session["BackupDrive"] = theDT.Rows[0]["BackupDrive"].ToString();
        //                Session["SystemId"] = theDT.Rows[0]["SystemId"].ToString();
        //                Session["AppCurrency"] = theDT.Rows[0]["Currency"].ToString();
        //                Session["AppUserEmployeeId"] = theDS.Tables[0].Rows[0]["EmployeeId"].ToString();

        //                //Session["AppSystemId"] = theDT.Rows[0]["SystemId"].ToString();

        //                #region "ModuleId"
        //                Session["AppModule"] = theDS.Tables[3];
        //                DataView theSCMDV = new DataView(theDS.Tables[3]);
        //                theSCMDV.RowFilter = "ModuleId=201";
        //                if (theSCMDV.Count > 0)
        //                Session["SCMModule"] = theSCMDV[0]["ModuleName"];
        //                #endregion


        //                //Session["AppModule"] = theDS.Tables[3];
        //                //DataView theSCMDV = new DataView(theDS.Tables[3]);
        //                //theSCMDV.RowFilter = "ModuleId=201";
        //                //if (theSCMDV.Count > 0)
        //                //Session["SCMModule"] = theSCMDV[0]["ModuleName"];


        //                IQWebUtils theIQUtils = new IQWebUtils();
        //                //theIQUtils.CreateSessionObject(Session.SessionID); 
        //                Session["Paperless"] = theDT.Rows[0]["Paperless"].ToString();
        //                Session["Program"] = "";
        //                LoginManager = null;
        //            }


        //    }
        //    else
        //    {
        //        IQCareMsgBox.Show("PasswordNotMatch", this);
        //        Response.Redirect("frmLogin.aspx");
        //    }

        //}
        //catch (Exception err)
        //{
        //    MsgBuilder theBuilder = new MsgBuilder();
        //    theBuilder.DataElements["MessageText"] = err.Message.ToString();
        //    IQCareMsgBox.Show("#C1", theBuilder, this);
        //}
        //finally
        //{
        //    LoginManager = null;
        //}
        #endregion

    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]

    protected void Page_Load(object sender, EventArgs e)
    {

        string encryptUrl = Request.QueryString["enc"];
        encryptUrl = encryptUrl.Replace(" ", "+");
        Utility theUtil = new Utility();
        string decryptUrl = theUtil.Decrypt(encryptUrl);
        string ptnpk = decryptUrl.Substring(decryptUrl.IndexOf("ptn_pk=") + 8, decryptUrl.IndexOf("&UserName") - (decryptUrl.IndexOf("ptn_pk=") + 8));
        string uName = decryptUrl.Substring(decryptUrl.IndexOf("UserName=") + 9, decryptUrl.IndexOf("&Pass") - (decryptUrl.IndexOf("UserName=") + 9));
        string password = decryptUrl.Substring(decryptUrl.IndexOf("Password=") + 9, decryptUrl.IndexOf("&tech") - (decryptUrl.IndexOf("Password=") + 9));
        string technicalArea = decryptUrl.Substring(decryptUrl.IndexOf("technicalArea=") + 14, decryptUrl.IndexOf("&UserID") - (decryptUrl.IndexOf("technicalArea=") + 14));
        string userID = decryptUrl.Substring(decryptUrl.IndexOf("UserID=") + 7, decryptUrl.IndexOf("&FacilityID") - (decryptUrl.IndexOf("UserID=") + 7));
        string FacilityID = decryptUrl.Substring(decryptUrl.IndexOf("FacilityID=") + 11);

        try
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(frmLogin));
            if (Page.IsPostBack != true)
            {
                Thread theThread = new Thread(new ParameterizedThreadStart(IQCareUtils.GenerateCache));
                theThread.Start(false);
                Init_Form();
                AutoLogin(uName, FacilityID, password);
            }
            //Response.Redirect("frmFacilityHome.aspx");            
            //Search_Patient(ptnpk, technicalArea);
            if(ptnpk == "-1")
            {
            //    //Response.Redirect("frmFindAddPatient.aspx",false); 
               Session["PatientID"] = ptnpk.Trim();
               //Session["TechnicalAreaId"]
                  //Response.Redirect("frmAddTechnicalArea.aspx");
               Response.Redirect("frmFacilityHome.aspx", false);
            //    //Response.Redirect("www.google.com", true);
            }
            else
            {
                Session["PatientID"] = ptnpk;
                Response.Redirect("frmAddTechnicalArea.aspx");
            //    Response.Redirect("frmFacilityHome.aspx", false);
            //    //Response.Redirect("www.google.com", true);

            }
        }
        catch (Exception ex)
        {
            MsgBuilder theBuilder = new MsgBuilder();
            theBuilder.DataElements["MessageText"] = ex.Message.ToString();
            IQCareMsgBox.Show("#C1", theBuilder, this);
        }
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

    private void GetApplicationParameters()
    {
        IUser ApplicationManager;
        ApplicationManager = (IUser)ObjectFactory.CreateInstance("BusinessProcess.Security.BUser, BusinessProcess.Security");
        DataSet theDS = ApplicationManager.GetFacilitySettings(1);
        DataTable theDT = theDS.Tables[0];

        if (theDT.Rows.Count < 1)
        {
            string theUrl = string.Format("{0}", "./AdminForms/frmAdmin_FacilityList.aspx?BS=true");
            Response.Redirect(theUrl);
        }
        //if (!string.IsNullOrEmpty(theDT.Rows[0]["Image"].ToString()))
        //{
        //    imgLogin.ImageUrl = string.Format("images/{0}", theDT.Rows[0]["Image"].ToString());
        //}
        //else
        //{
        //    imgLogin.ImageUrl = "~/Images/Login.jpg";
        //}
        Session["SystemId"] = Convert.ToInt32(theDT.Rows[0]["SystemId"]);


        if (theDS.Tables[1].Rows[0]["AppVer"].ToString() != AuthenticationManager.AppVersion || ((DateTime)theDS.Tables[1].Rows[0]["RelDate"]).ToString("dd-MMM-yyyy") != AuthenticationManager.ReleaseDate)
        {
            string script = "<script language = 'javascript' defer ='defer' id = 'confirm'>\n";
            script += "var ans=true;\n";
            script += "alert('You are using a Wrong Version of Application. Please contact Support staff.');\n";
            script += "if (ans==true)\n";
            script += "{\n";
            script += "window.close() - y;\n";
            script += "}\n";
            script += "</script>\n";
            RegisterStartupScript("confirm", script);
            //btnLogin.Enabled = false;
        }


        ApplicationManager = null;
        IIQCareSystem DateManager;
        DateManager = (IIQCareSystem)ObjectFactory.CreateInstance("BusinessProcess.Security.BIQCareSystem, BusinessProcess.Security");
        DateTime theDTime = DateManager.SystemDate();

        ViewState["theCurrentDate"] = theDTime;
        //lblDate.Text = theDTime.ToString("dd-MMM-yyyy");
        Application["AppCurrentDate"] = theDTime.ToString("dd-MMM-yyyy");
        Session["AppCurrentDateClass"] = theDTime.ToString("dd-MMM-yyyy");
    }

    private void AutoLogin(string userName, string facilityID, string password)
    {
        IUser LoginManager;
        try
        {
            LoginManager = (IUser)ObjectFactory.CreateInstance("BusinessProcess.Security.BUser, BusinessProcess.Security");
            if (object.Equals(Session["SystemId"], null))
                Session["SystemId"] = "1";

            DataSet theDS = LoginManager.GetUserCredentials
                (userName.Trim(), Convert.ToInt32(facilityID), Convert.ToInt32(Session["SystemId"]));
            if (theDS.Tables.Count > 0)
            {
                int FacilityExist = 1;
                if (theDS.Tables[5].Rows.Count > 0)
                {
                    DataView theDV = new DataView();
                    FacilityExist = 0;
                    foreach (DataRow theDR in theDS.Tables[5].Rows)
                    {
                        if (Convert.ToInt32(theDR["GroupId"]) > 1)
                        {
                            theDV = new DataView(theDS.Tables[1]);
                            theDV.RowFilter = "FacilityID= " + facilityID + "";
                            if (theDV.ToTable().Rows.Count > 0)
                            {
                                FacilityExist = 1;
                            }
                        }
                        else if (Convert.ToInt32(theDR["GroupId"]) == 1)
                        {
                            FacilityExist = 1;
                        }
                    }
                }
                if (FacilityExist == 0)
                {
                    IQCareMsgBox.Show("AccessDenied", this);
                    return;
                }
                Utility theUtil = new Utility();
                if (theDS.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(theDS.Tables[0].Rows[0]["Password"]) != theUtil.Encrypt(password.Trim()))
                    {
                        if ((Request.Browser.Cookies))
                        {
                            HttpCookie theCookie = Request.Cookies[userName];
                            if (theCookie == null)
                            {
                                HttpCookie theNCookie = new HttpCookie(userName);
                                theNCookie.Value = userName + ",1";
                                DateTime theNewDTTime = Convert.ToDateTime(ViewState["theCurrentDate"]).AddMinutes(5);
                                theNCookie.Expires = theNewDTTime;
                                Response.Cookies.Add(theNCookie);
                            }
                            else
                            {
                                string[] theVal = (theCookie.Value.ToString()).Split(',');
                                if (Convert.ToInt32(theVal[1]) >= 3 && theCookie.Name == userName)
                                {
                                    MsgBuilder theBuilder = new MsgBuilder();
                                    theBuilder.DataElements["MessageText"] = "User Account Locked. Try again after 5 Mins.";
                                    IQCareMsgBox.Show("#C1", theBuilder, this);
                                    return;
                                }
                                else
                                {
                                    theVal[1] = (Convert.ToInt32(theVal[1]) + 1).ToString();
                                    theCookie.Value = userName + "," + theVal[1];
                                    DateTime theAddNewDTTime = Convert.ToDateTime(ViewState["theCurrentDate"]).AddMinutes(5);
                                    theCookie.Expires = theAddNewDTTime;
                                    Response.Cookies.Add(theCookie);
                                }
                            }
                        }
                        IQCareMsgBox.Show("PasswordNotMatch", this);
                        Init_Form();
                        return;
                    }
                    else
                    {
                        HttpCookie theCookie = Request.Cookies[userName];
                        if (theCookie != null)
                        {
                            string[] theVal = (theCookie.Value.ToString()).Split(',');
                            if (Convert.ToInt32(theVal[1]) >= 3)
                            {
                                MsgBuilder theBuilder = new MsgBuilder();
                                theBuilder.DataElements["MessageText"] = "User Account Locked. Try again after 5 Mins.";
                                IQCareMsgBox.Show("#C1", theBuilder, this);
                                return;
                            }
                        }
                    }
                }

                else
                {
                    IQCareMsgBox.Show("InvalidLogin", this);
                    Init_Form();
                    return;
                }

                Session["AppUserId"] = Convert.ToString(theDS.Tables[0].Rows[0]["UserId"]);
                Session["AppUserName"] = Convert.ToString(theDS.Tables[0].Rows[0]["UserFirstName"])
                    + " " + Convert.ToString(theDS.Tables[0].Rows[0]["UserLastName"]);
                Session["EnrollFlag"] = theDS.Tables[1].Rows[0]["EnrollmentFlag"].ToString();
                Session["CareEndFlag"] = theDS.Tables[1].Rows[0]["CareEndFlag"].ToString();
                Session["IdentifierFlag"] = theDS.Tables[1].Rows[0]["IdentifierFlag"].ToString();
                Session["UserRight"] = theDS.Tables[1];
                Session["UserFeatures"] = theDS.Tables[6];
                Session["AppUserCustomList"] = theDS.Tables[7];
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

                /*
                 * Commented by Gaurav & Suggested by Joseph 
                 * Purpose: Everytime not to update appoinments
                 * Date: 23 Sept 2014
                 */
                /////////////// Appointment Updates//////////////////
                //UpdateAppointment();
                /////////////////////////////////////////////////////

                if (Convert.ToString(theDS.Tables[0].Rows[0]["forcelogin"]) == "0")
                {
                    string theUrl = string.Format("{0}", "./AdminForms/frmAdmin_ChangePassword.aspx");
                    String msgString = "First time login: please change your password.\\n";
                    string script = "<script language = 'javascript' defer ='defer' id = 'changePwd'>\n";
                    script += "alert('" + msgString + "');\n";
                    string url = Request.RawUrl.ToString();
                    Application["PrvFrm"] = url;
                    Session["MandatoryChange"] = "1";
                    script += "window.location.href='" + theUrl + "'\n";
                    script += "</script>\n";
                    RegisterStartupScript("changePwd", script);
                }
                else if (theDS.Tables[3].Rows[0]["ExpPwdFlag"] != null && Convert.ToString(theDS.Tables[3].Rows[0]["ExpPwdFlag"]) != "")
                {
                    if (Convert.ToInt32(theDS.Tables[0].Rows[0]["UserId"]) != 1)
                    {
                        if (Convert.ToInt32(theDS.Tables[3].Rows[0]["ExpPwdFlag"]) == 1)
                        {

                            DateTime lastcontDate = Convert.ToDateTime(theDS.Tables[0].Rows[0]["PwdDate"]);
                            TimeSpan t = Convert.ToDateTime(theDS.Tables[4].Rows[0]["CurrentDate"]) - lastcontDate;
                            double NrOfDaysdiffernce = t.TotalDays;

                            string msgString;
                            string theUrl = string.Format("{0}", "./AdminForms/frmAdmin_ChangePassword.aspx");
                            if (NrOfDaysdiffernce > Convert.ToInt32(theDS.Tables[3].Rows[0]["ExpPwdDays"]))
                            {
                                msgString = "Your Password has expired. Please Change it now.\\n";
                                string script = "<script language = 'javascript' defer ='defer' id = 'changePwdfunction2'>\n";
                                script += "alert('" + msgString + "');\n";
                                string url = Request.RawUrl.ToString();
                                Application["PrvFrm"] = url;
                                Session["MandatoryChange"] = "1";
                                script += "window.location.href='" + theUrl + "'\n";
                                script += "</script>\n";
                                RegisterStartupScript("changePwdfunction2", script);
                            }

                            else
                            {
                                // adding the false parameter value to continue the execution of current page....
                                //Response.Redirect("frmFacilityHome.aspx", false);
                                // Response.Redirect("frmFindAddPatient.aspx");
                            }
                        }
                        else
                        {
                            // adding the false parameter value to continue the execution of current page....
                            //Response.Redirect("frmFacilityHome.aspx", false);
                            // Response.Redirect("frmFindAddPatient.aspx");
                        }
                    }
                    else
                    {
                        // adding the false parameter value to continue the execution of current page....
                        //Response.Redirect("frmFacilityHome.aspx", false);
                        // Response.Redirect("frmFindAddPatient.aspx");
                    }

                }
                else
                {
                    // adding the false parameter value to continue the execution of current page....
                    //Response.Redirect("frmFacilityHome.aspx", false);
                    //Response.Redirect("frmFindAddPatient.aspx");
                }

                //Response.Redirect("frmFacilityHomenew.aspx");
            }
            else
            {
                IQCareMsgBox.Show("InvalidLogin", this);
                return;
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


}