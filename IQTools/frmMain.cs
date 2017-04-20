using System;
using System.Management;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using BusinessLayer;
using DataLayer;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Windows.Forms;
using System.IO;
using Ionic.Zip;
using Microsoft.Win32;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using ActiveDatabaseSoftware.ActiveQueryBuilder;
using System.Globalization;
using System.Data.OleDb;
using System.Net;
using System.Windows;
using IQTools.RemoteWebService;
using Npgsql;


namespace IQTools
{
    public delegate void SettingsEventHandler(object sender, EventArgs e);

    public delegate void formUpdateFunctionType(object message);

    public partial class frmMain : Form
    {
        string serverType = Entity.getServerType(clsGbl.xmlPath);
        int x = 0;
        Hashtable htCategories; 
        Entity theObject = new Entity();
        DataTable theDt = new DataTable(); 
        DataTable theQryDT = new DataTable();
        Microsoft.SqlServer.Management.Common.ServerConnection conn = new Microsoft.SqlServer.Management.Common.ServerConnection();
        string cmdARTText = string.Empty;
        public string exportPath = @"C:\Cohort\ExcelExtracts";
        ExcelReports ER;
        ErrorLogHelper EH = new ErrorLogHelper();       
        private const string STR_MicrosoftAccess = "Microsoft Access";
        string EMRUser = string.Empty;
        string EMRPass = string.Empty;
        string EMRDB = string.Empty;
        string EMRIPAddress = string.Empty;
        string cboPMMSText = string.Empty;
        string cboDatabaseText = string.Empty;
        string cboServerTypeText = string.Empty;
       
        private string MS_ACCESS_PMMS = "CTC2";
        private string MS_ACCESS_PMMS_TYPE = "microsoft access";
        private string[] TABLE_NAMES = 
        {
         "tblExposedInfants"
        };

        string iqtoolsConnString = Entity.getconnString(clsGbl.xmlPath);
        
        private readonly frmLogin _frmLogin;

        public frmMain ( frmLogin FrmLogin )
        {
          InitializeComponent ( );
          _frmLogin = FrmLogin;
        }

        public frmMain()
        {
            InitializeComponent();
            
            //Hook option buttons on home page

            optART.CheckedChanged += new EventHandler(homeScreenOption_Changed);
            optMAP.CheckedChanged += new EventHandler(homeScreenOption_Changed);
            OptMA.CheckedChanged += new EventHandler(homeScreenOption_Changed);
            optAllApp.CheckedChanged += new EventHandler(homeScreenOption_Changed);
            optNoARTNoCD4.CheckedChanged += new EventHandler(homeScreenOption_Changed);
            optNoARTCD4XY.CheckedChanged += new EventHandler(homeScreenOption_Changed);
            cboServerType.Text = "Microsoft Access";
            this.tcAdmin.Controls.Remove ( tpDataConnection); 
            if (clsGbl.PMMS.ToLower ( ) != "iqcare")  //  this tab page should only appear when the connected EMR is IQCare
            {
              this.tcMain.Controls.Remove ( tpEMRAccess );
              this.tcReports.Controls.Remove ( tpComparisons );

            }
            if (clsGbl.PMMS.ToLower ( ) == "ctc2")
            {
              this.tcCountries.Controls.Remove ( tpKe );
              this.tcCountries.Controls.Remove ( tpNg );
              this.tcCountries.Controls.Remove ( tpHt );
              this.tcCountries.Controls.Remove ( tpUg );
              this.tcDonors.Controls.Remove ( tpDonorCustomReport );
              this.tcAdmin.Controls.Remove ( tpUsers );
              this.tcAdmin.Controls.Remove ( tpCReports );
              this.tcAdmin.Controls.Add ( tpDataConnection ); 
            }
            if (clsGbl.PMMS.ToLower() == "cpad")
            {
                this.tcCountries.Controls.Remove(TpTz);
                this.tcCountries.Controls.Remove(tpNg);
                this.tcCountries.Controls.Remove(tpHt);
                this.tcCountries.Controls.Remove(tpUg);
                this.tcDonors.Controls.Remove(tpDonorCustomReport);
                this.tcAdmin.Controls.Remove(tpUsers);
                this.tcAdmin.Controls.Remove(tpCReports);
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                loadQueries();
                cboMainLanguage.Enabled = false;
                LanguageCollector lc = new LanguageCollector();
                int currentLanguage;
                CultureInfoDisplayItem[] lis = lc.GetLanguages(System.Globalization.LanguageCollector.LanguageNameDisplay.EnglishName, out currentLanguage);
                cboMainLanguage.Items.AddRange(lis);
                this.cboMainLanguage.Text = clsGbl.cidi.DisplayName;
                clsGbl.IQToolsVersion = Application.ProductVersion;
                txtVersion.Text = Application.ProductVersion;
               
                    DataRow DBVersion = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                        , "Select DBVersion FROM aa_Version", ClsUtility.ObjectEnum.DataRow, serverType);
                    txtDate.Text = DBVersion[0].ToString();
                
                tpEMRAccess.Text = clsGbl.PMMS.ToUpper();

                lstClinical.Items.Clear();
                theDt.Clear();
                if (serverType != "pgsql")
                {
                    clsGbl.RemoteWebServiceURL = Entity.getRemoteServiceURL(clsGbl.xmlPath);
                    Thread remoteThread = new Thread(() => runRemoteServices());
                    remoteThread.SetApartmentState(ApartmentState.STA);
                    remoteThread.Start();


                    DataTableReader theDr;
                    if (clsGbl.currUser.ToLower() == "temp" || clsGbl.currUser.ToLower() == "admin")
                    {
                        clsGbl.IQDirection = "setUsers";
                        tcMain.SelectedTab = tpAdmin;
                        tpAdmin.Focus();
                        tcAdmin.SelectedTab = tpUsers;
                        theDt.Clear();
                        ClsUtility.Init_Hashtable();

                        theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                            , "SELECT DISTINCT GroupName From aa_UserGroups"
                            , ClsUtility.ObjectEnum.DataTable, serverType);
                        theDr = theDt.CreateDataReader();
                        cboUserGroup.Items.Clear();
                        while (theDr.Read())
                        { cboUserGroup.Items.Add(theDr["GroupName"].ToString()); }

                        theDt.Clear();
                        ClsUtility.Init_Hashtable();
                        theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                            , "SELECT FirstName, LastName, UserName, GroupName, aa_Users.DeleteFlag Deleted FROM aa_Users LEFT JOIN aa_userGroups ON aa_Users.GID = aa_UserGroups.GID"
                            , ClsUtility.ObjectEnum.DataTable, serverType);

                        dgvUsers.DataSource = theDt;
                        dgvUsers.Columns["GroupName"].Width = 200;
                        dgvUsers.Columns["UserName"].Width = 200;
                        dgvUsers.Columns["FirstName"].Width = 200;
                        dgvUsers.Columns["LastName"].Width = 200;
                        dgvUsers.Refresh();
                        tpUsers.Focus();
                    }

                    if (clsGbl.DBState == "Ready" || clsGbl.DBState == "Loading" || clsGbl.DBState == "Connected")
                    {
                        try
                        {
                            int i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                , "UPDATE aa_Database SET IQStatus='Connected', UpdateDate= '" + DateTime.Now.ToString() + "'"
                                , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                            clsGbl.DBState = "Connected";
                        }
                        catch { }
                    }
                }
                try
                {
                    if (clsGbl.PMMS.ToLower() == "iqcare" || clsGbl.PMMS.ToLower() == "cpad")
                    {
                        this.Text = "IQTools | " + clsGbl.loggedInUser.FacilityName;
                    }
                    else
                    {
                        string myComText = "";
                        if (clsGbl.PMMSType == "mysql")
                            myComText = "SELECT FacilityName From IQC_SiteDetails LIMIT 1";
                        else if (clsGbl.PMMS.ToLower() == "smartcare" || clsGbl.PMMS.ToLower() == "ctc2")
                            myComText = "SELECT TOP 1 FacilityName From IQC_SiteDetails ORDER BY FacilityID";
                        DataRow dr;
                        ClsUtility.Init_Hashtable();
                        dr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                            , myComText, ClsUtility.ObjectEnum.DataRow, serverType);
                        this.Text = "IQTools | " + dr["FacilityName"].ToString().Trim();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "IQTools");
                }                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool CheckForInternetConnection ( )
        {
          try
          {
            SetControlPropertyThreadSafe ( picProgress, "Image", Properties.Resources.progressWheel5 );
            SetControlPropertyThreadSafe ( lblNotify, "Text", "Checking Internet Connectivity" );
            using (var webclient = new WebClient ( ))
            using (var streamNet = webclient.OpenRead ( "http://www.google.com" ))
            {
              return true;
            }
          }
          catch (Exception ex)
          {
            SetControlPropertyThreadSafe ( lblNotify, "Text", ex.Message );
            return false;
          }
          finally { SetControlPropertyThreadSafe ( picProgress, "Image", null ); }
        }

        private void runRemoteServices()
        {
          if (CheckForInternetConnection ( ))
          {
            Service1 rws = new Service1 ( );
            rws.Url = clsGbl.RemoteWebServiceURL;
            try
            {
              SetControlPropertyThreadSafe ( picProgress, "Image", Properties.Resources.progressWheel5 );
              SetControlPropertyThreadSafe ( lblNotify, "Text", rws.SiteHandshake ( clsGbl.loggedInUser.MFLCode, clsGbl.loggedInUser.FacilityName ) );
              updateDatabase ( rws );
              loadQueries ( );
            }
            catch (Exception ex) { SetControlPropertyThreadSafe ( lblNotify, "Text", ex.Message ); }
            finally { SetControlPropertyThreadSafe ( picProgress, "Image", null ); }
          }
          else { SetControlPropertyThreadSafe ( lblNotify, "Text", Assets.Messages.InternetConnectivity ); }
        }

        private void updateDatabase(Service1 rws)
        {            
            Entity en = new Entity();
            ClsUtility.Init_Hashtable();

            DataTable DBChanges = new DataTable();
            DBChanges.TableName = "Output";
            ClsUtility.AddParameters("@WithSyntax", SqlDbType.Text, "0");
            string sp = "pr_GetQueriesForUpdate_IQTools";

            int updates = 0;            
            DataSet theObjects = new DataSet();            
            
            theObjects = (DataSet)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
                , ClsUtility.ObjectEnum.DataSet, serverType);
            SetControlPropertyThreadSafe(lblNotify, "Text", "Checking For Updates");
            
            if (rws.DBCompare(theObjects.Tables[0]) != null)
            {
                string sql = string.Empty;
                NewQuery nq = new NewQuery();
                int i = 0;
                ClsUtility.Init_Hashtable();

                DBChanges = rws.DBCompare(theObjects.Tables[0]);
                //updates = DBChanges.Rows.Count;
                DataTableReader DBChangesR = DBChanges.CreateDataReader();
                while (DBChangesR.Read())
                {
                    if (DBChangesR["ROUTINE_TYPE"].ToString().ToLower() == "procedure")
                    {                       
                       try
                       {
                           sp = "pr_UpdateObjects_IQTools";
                           ClsUtility.Init_Hashtable();
                           ClsUtility.AddParameters("@ObjectName", SqlDbType.VarChar, DBChangesR["ROUTINE_NAME"].ToString());
                           ClsUtility.AddParameters("@ObjectType", SqlDbType.VarChar, "PROCEDURE");
                           ClsUtility.AddParameters("@ObjectDef", SqlDbType.Text,DBChangesR["ROUTINE_DEFINITION"].ToString()); 
                          
                           i = (int)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
                                       , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                           updates += 1;
                       }
                       catch (Exception ex)
                       {
                           //MessageBox.Show(ex.Message);
                           EH.LogError(ex.Message, "IQTools Remote Update", serverType);
                       }
                       finally
                       {
                           if (i > 0) { }
                           else { }
                       }                        
                    }
                    else if (DBChangesR["ROUTINE_TYPE"].ToString().ToLower() == "function")
                    {                        
                        try
                        {
                            sp = "pr_UpdateObjects_IQTools";
                            ClsUtility.Init_Hashtable();
                            ClsUtility.AddParameters("@ObjectName", SqlDbType.VarChar, DBChangesR["ROUTINE_NAME"].ToString());
                            ClsUtility.AddParameters("@ObjectType", SqlDbType.VarChar, "FUNCTION");
                            ClsUtility.AddParameters("@ObjectDef", SqlDbType.Text, DBChangesR["ROUTINE_DEFINITION"].ToString());
                          
                            i = (int)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
                                        , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                            updates += 1;
                          
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message);
                            EH.LogError(ex.Message, "IQTools Remote Update", serverType);
                        }
                        finally
                        {
                            if (i > 0) { }
                            else { }
                        }    
                    }
                    else if (DBChangesR["ROUTINE_TYPE"].ToString().ToLower() == "query")
                    {
                        sp = "pr_SaveQuery_IQTools";

                        nq.qryID = Convert.ToInt32(DBChangesR["object_id"].ToString());
                        nq.qryName = DBChangesR["ROUTINE_NAME"].ToString();
                        nq.qryCategory = DBChangesR["QRY_CATEGORY"].ToString();
                        nq.qrySubCategory = DBChangesR["QRY_SBCATEGORY"].ToString();
                        nq.qrySQL = DBChangesR["ROUTINE_DEFINITION"].ToString();
                        nq.qryDescription = DBChangesR["QRY_DSC"].ToString();
                        nq.qryGroup = DBChangesR["QRY_GRP"].ToString();                        

                        ClsUtility.Init_Hashtable();
                        ClsUtility.AddParameters("@qryName", SqlDbType.VarChar, nq.qryName);
                        ClsUtility.AddParameters("@qryDescription", SqlDbType.VarChar, nq.qryDescription);
                        ClsUtility.AddParameters("@qryCategory", SqlDbType.VarChar, nq.qryCategory);
                        ClsUtility.AddParameters("@qrySubCategory", SqlDbType.VarChar, nq.qrySubCategory);
                        ClsUtility.AddParameters("@qrySQL", SqlDbType.VarChar, nq.qrySQL);
                        ClsUtility.AddParameters("@qryGroup", SqlDbType.VarChar, nq.qryGroup);
                        ClsUtility.AddParameters("@devFlag", SqlDbType.Int, 1);
                        
                        try
                        {
                            i = (int)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
                                        , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                            updates += 1;
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message);
                            EH.LogError(ex.Message, "IQTools Remote Update", serverType);
                        }
                        finally
                        {
                            if (i > 0) {}
                            else {}                            
                        }
                    }
                }
                try
                {
                    string DBVersion = rws.GetDBVersion();
                    ClsUtility.Init_Hashtable();
                    sql = "UPDATE aa_Version SET DBVersion = '" + DBVersion + "',UpdateDate = dbo.fn_GetCurrentDate()";
                    i = (int)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sql
                        , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                    txtDate.Text = DBVersion;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); EH.LogError(ex.Message, "IQTools Remote Update", serverType); }
            }
            SetControlPropertyThreadSafe(lblNotify, "Text", updates.ToString() + " Update(s) Applied");
            SetControlPropertyThreadSafe(picProgress, "Image", Properties.Resources.progress2);
        }

        private class NewQuery
        {
            public int qryID;
            public string qryName = string.Empty;
            public string qryDescription;
            public string qryCategory;
            public string qrySubCategory;
            public string qrySQL;
            public string qryGroup;
        }
        
        private void loadQueries()
        {
            if(serverType == "pgsql")
            {
                string sp = "iqtools.pr_getqueries_iqtools";
                ClsUtility.Init_Hashtable();                
                //ClsUtility.AddParameters("refcursor", SqlDbType.VarChar, 'a');
                ClsUtility.AddParameters("emr", SqlDbType.VarChar, clsGbl.PMMS);
                Entity en = new Entity();
                try
                {
                    clsGbl.Queries = (DataTable)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
                                            , ClsUtility.ObjectEnum.DataTable, serverType);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else {
            string sp = "pr_GetQueries_IQTools";
            ClsUtility.Init_Hashtable();
            ClsUtility.AddParameters("@EMR", SqlDbType.VarChar, clsGbl.PMMS);
            Entity en = new Entity();
            try
            {
                clsGbl.Queries = (DataTable)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
                                        , ClsUtility.ObjectEnum.DataTable, serverType);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
        }
        
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ClsUtility.Init_Hashtable();
                //Assets.UtFunctions theDB = new Assets.UtFunctions();
                if (clsGbl.DBState != "No data" || clsGbl.DBState != "" || clsGbl.DBState != "Loading")
                {
                    clsGbl.DBState = "Ready";
                    int i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                        , "UPDATE aa_Database SET IQStatus='Ready', UpdateDate=dbo.fn_GetCurrentDate()"
                        , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                }
                else if (clsGbl.DBState == "Loading")
                {
                    clsGbl.DBState = "Loading";
                    int i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                        , "UPDATE aa_Database SET IQStatus='Loading'", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                }
            }
            catch (Exception ex)
            {
                EH.LogError(ex.Message, "<<frmMain_FormClosed>>", serverType);
            }
            Application.Exit();
        }

        private void tcMain_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tpAdmin)
            {
                lstCats.Items.Clear();
                cboCReportCategory.Items.Clear();
                theDt.Clear();
                DataTableReader theDr;

                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , "SELECT DISTINCT Category FROM aa_Category", ClsUtility.ObjectEnum.DataTable, serverType);
                theDr = theDt.CreateDataReader();
                while (theDr.Read())
                {
                    lstCats.Items.Add(theDr["Category"].ToString());
                    cboCReportCategory.Items.Add(theDr["Category"].ToString());
                }
            } 
            else if (e.TabPage == tpReports)
            {
                ////lstClinical.Items.Clear();
                //theDt.Clear();
                //DataTableReader theDr;

                //theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                //    , "SELECT DISTINCT sbCategory FROM aa_Category LEFT JOIN aa_SBCategory ON aa_Category.CatID = aa_SBCategory.CatID " + 
                //    "WHERE aa_SBCategory.DeleteFlag=0 Or aa_SBCategory.DeleteFlag Is Null And Category='Clinical'"
                //    , ClsUtility.ObjectEnum.DataTable, serverType);
                //theDr = theDt.CreateDataReader();
                //while (theDr.Read())
                //{ lstClinical.Items.Add(theDr["sbCategory"].ToString()); }
            }

            else if (e.TabPage == tpQueries)
            {
                Pages.ucQueries queryPage = new Pages.ucQueries(this);
                queryPage.Parent = tcMain.SelectedTab;
                queryPage.Dock = DockStyle.Fill;
                queryPage.Show();
            }           

            else if (e.TabPage == tpEMRAccess)
            {
                Pages.ucEMRAccess emrPage = new Pages.ucEMRAccess(this);
                emrPage.Parent = tcMain.SelectedTab;
                emrPage.Dock = DockStyle.Fill;
                emrPage.Show();
                //Pages.ucEMRAccessChrome emrPage = new Pages.ucEMRAccessChrome(this);
                //emrPage.Parent = tcMain.SelectedTab;
                //emrPage.Dock = DockStyle.Fill;
                //emrPage.Show();
            }

            else if (e.TabPage == tpSMS)
            {
                Pages.ucMessaging messagingPage = new Pages.ucMessaging();
                messagingPage.Parent = tcMain.SelectedTab;
                messagingPage.Dock = DockStyle.Fill;
                messagingPage.Show();
            }

            else if (e.TabPage == tpForum)
            {
                Pages.ucIQToolsForum forumPage = new Pages.ucIQToolsForum(this);
                forumPage.Parent = tcMain.SelectedTab;
                forumPage.Dock = DockStyle.Fill;
                forumPage.Show();
            }
          
          else if (e.TabPage == tpNewReports)
          {
            
              Pages.ucReports reportsPage = new Pages.ucReports(this);
              reportsPage.Parent = tcMain.SelectedTab;
              reportsPage.Dock = DockStyle.Fill;
              reportsPage.Show();
              
          }
          
        }

        private void dgvAdherence_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvAdherence.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                string link = this.dgvAdherence[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (link != String.Empty)
                {
                    clsGbl.EMRPatientPK = link;
                    tcMain.SelectedTab = tpEMRAccess;
                }
            }
        }

        private string GetIQCareURL(String FacilityID, String ptnpk)
        {
            String url = "";
            String encryptURL = "";
            String cryptURL = "";

            // Prompt for Connect config if missing
            try
            {
                DataRow theDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT top 1 [IQServer],[IQPort],[IQUserName], u.UserID, [IQPassword],[IQTechnicalArea], [IQProtocol] FROM aa_IQCareConnect i inner join mst_user u on i.IQUserName = u.UserName WHERE i.DeleteFlag is Null And i.Active = 1", ClsUtility.ObjectEnum.DataRow, serverType);


                String IQCareUserName = theDr["IQUserName"].ToString().Trim();
                String UserID = theDr["UserID"].ToString().Trim();
                String IQCarePassword = ClsUtility.Decrypt(theDr["IQPassword"].ToString().Trim());
                String TechnicalArea = theDr["IQTechnicalArea"].ToString().Trim();
                String server = theDr["IQServer"].ToString().Trim();
                String protocol = theDr["IQProtocol"].ToString().Trim();
                String port = theDr["IQPort"].ToString().Trim();


                cryptURL = "Ptn_pk=" + ptnpk + "&UserName=" + IQCareUserName + "&Password=" + IQCarePassword + "&technicalArea=" + TechnicalArea + "&UserID=" + UserID + "&FacilityID=" + FacilityID + "";
                encryptURL = ClsUtility.Encrypt(cryptURL);

                //Format the URL
                url = protocol + "://" + server + ":" + port + "/iqcare/frmConnect.aspx?enc=" + encryptURL;
                return url;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower() == "there is no row at position 0.")
                {
                    //MessageBox.Show ( "Connection to IQCare Has Not Been Configured. Please Enter Your Connection Details Under The Administration Page", "IQTools", MessageBoxButtons.OK, MessageBoxIcon.Question );
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            }
        }

        private void tcAdmin_Selected(object sender, TabControlEventArgs e)
        {
            if (clsGbl.IQDirection == "setUsers")
            {
                tcAdmin.SelectedTab = tpUsers;
                tpUsers.Focus();
                clsGbl.IQDirection = "setUsers";
                return;
            }
            if (e.TabPage == tpEMaps)
            {
                // get all the excel kind reports in the combo;
                theDt.Clear();
                DataTableReader theDr;
                ClsUtility.Init_Hashtable();

                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT catId, Category FROM aa_Category WHERE Excel='True' Or Excel='1'", ClsUtility.ObjectEnum.DataTable, serverType);
                theDr = theDt.CreateDataReader();
                cboReports.Items.Clear();
                htCategories = new Hashtable();
                htCategories.Clear();
                while (theDr.Read())
                {
                    cboReports.Items.Add(theDr["Category"].ToString());
                    htCategories.Add(theDr["CatID"].ToString(), theDr["Category"].ToString());
                }
            }
           
            else if (e.TabPage == tpUsers)
            {

                theDt.Clear();
                DataTableReader theDr;
                ClsUtility.Init_Hashtable();

                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT DISTINCT GroupName From aa_UserGroups", ClsUtility.ObjectEnum.DataTable, serverType);
                theDr = theDt.CreateDataReader();
                cboUserGroup.Items.Clear();
                while (theDr.Read())
                { cboUserGroup.Items.Add(theDr["GroupName"].ToString()); }

                theDt.Clear();
                ClsUtility.Init_Hashtable();
                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT FirstName, LastName, UserName, GroupName[Group Name], aa_Users.DeleteFlag[Deleted] FROM aa_Users LEFT JOIN aa_userGroups ON aa_Users.GID = aa_UserGroups.GID", ClsUtility.ObjectEnum.DataTable, serverType);
                dgvUsers.DataSource = theDt;
                dgvUsers.Columns["Group Name"].Width = 200;
                dgvUsers.Columns["UserName"].Width = 200;
                dgvUsers.Columns["FirstName"].Width = 200;
                dgvUsers.Columns["LastName"].Width = 200;
                dgvUsers.Refresh();
            }           
            
           
            else if (e.TabPage == tpCReports)
            {
                refreshCustomReportsGrid();
            }
        }

        private void lstCats_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCats.Text = lstCats.Text;
            if (txtCats.Text != "")
            {
                txtCats.ReadOnly = true;
                lstSubCats.Items.Clear();
                theDt.Clear();

                DataRow cDr;
                DataTableReader theDr; txtCats.Text = lstCats.Text;

                cDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , "SELECT * FROM aa_Category WHERE Category='" + txtCats.Text + "'", ClsUtility.ObjectEnum.DataRow, serverType);
                if (cDr["Excel"].ToString() == "True")
                    chkExcel.Checked = true;
                else
                    chkExcel.Checked = false;

                if (cDr["DeleteFlag"].ToString() == "True")
                    chkCatActive.Checked = false;
                else
                    chkCatActive.Checked = true;

                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , "SELECT DISTINCT sbCategory FROM aa_Category LEFT JOIN aa_SBCategory ON aa_Category.CatID = aa_SBCategory.CatID WHERE Category='"
                    + lstCats.Text + "' AND (aa_SBCategory.DeleteFlag=0 Or aa_SBCategory.DeleteFlag Is Null)", ClsUtility.ObjectEnum.DataTable, serverType);
                theDr = theDt.CreateDataReader();
                while (theDr.Read())
                {
                    lstSubCats.Items.Add(theDr["sbCategory"].ToString());
                }

                txtSbCats.Text = "";
                cmdASC.Text = "+";
            }
        }

        private void lstSubCats_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSbCats.Text = lstSubCats.Text;
            cmdASC.Text = "-";

        }

        private void cmdASC_Click(object sender, EventArgs e)
        {
            if (txtSbCats.Text != "")
            {
                if (cmdASC.Text == "-")
                {
                    int i = 0;
                    i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                        , "UPDATE aa_SBCategory SET DeleteFlag=1, UpdateDate=dbo.fn_GetCurrentDate() WHERE sbCategory='" + txtSbCats.Text + "'"
                        , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                    lstCats_SelectedIndexChanged(sender, e);
                }
                else
                {
                    DataRow cDr;
                    cDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                        , "SELECT CatID FROM aa_Category WHERE Category='" + txtCats.Text + "'", ClsUtility.ObjectEnum.DataRow, serverType);
                    if (cDr["CatID"].ToString() != "")
                    {
                        int i = 0;
                        i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                            , "UPDATE aa_SBCategory SET DeleteFlag = Null, UpdateDate=dbo.fn_GetCurrentDate() WHERE sbCategory='" + txtSbCats.Text + "'"
                            , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                        if (i <= 0)
                        {
                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                              , "INSERT INTO aa_SBCategory (sbCategory, CatID, CreateDate) Values('" + txtSbCats.Text + "', " + cDr["CatID"].ToString() + ",dbo.fn_GetCurrentDate())"
                              , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                        }
                        lstCats_SelectedIndexChanged(sender, e);
                    }
                }
            }
        }

        private void cmdSQC_Click(object sender, EventArgs e)
        {

            if (txtCats.Text != "")
            {
                int i = 0;
                ClsUtility.Init_Hashtable();
                i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , "UPDATE aa_Category SET DeleteFlag='" + !chkCatActive.Checked + "', Excel='" + chkExcel.Checked + "', UpdateDate=dbo.fn_GetCurrentDate() WHERE Category='" + txtCats.Text + "'"
                    , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                if (i == 0)
                {
                    i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                        , "INSERT INTO aa_Category(Category, DeleteFlag, Excel, CreateDate) " +
                        "VALUES('" + txtCats.Text + "','" + !chkCatActive.Checked + "','" + !chkExcel.Checked + "', dbo.fn_GetCurrentDate())"
                        , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                }
                if (i > 0)
                {
                    lstCats.Items.Clear();
                    theDt.Clear();
                    DataTableReader theDr;

                    theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                        , "SELECT DISTINCT Category FROM aa_Category WHERE DeleteFlag=0 Or DeleteFlag Is Null", ClsUtility.ObjectEnum.DataTable, serverType);
                    theDr = theDt.CreateDataReader();
                    while (theDr.Read())
                    {
                        lstCats.Items.Add(theDr["Category"].ToString());
                    }
                }
            }
            txtCats.Text = "";
            txtCats.ReadOnly = true;
            lstSubCats.Items.Clear();
            txtSbCats.Text = "";
            cmdASC.Text = "+";
            chkExcel.Checked = false;
            chkCatActive.Checked = false;
        }

        private void lblNewCat_Click(object sender, EventArgs e)
        {
            txtCats.Text = "";
            txtCats.ReadOnly = false;
            lstSubCats.Items.Clear();
            txtSbCats.Text = "";
            cmdASC.Text = "+";
            chkExcel.Checked = false;
            chkCatActive.Checked = false;
        }

        private void lstQueries_SelectedIndexChanged(object sender, EventArgs e)
        {

            dgXls.DataSource = null;
            //txtDesc.Text = "";
            if (theDt != null)
            {
                DataTableReader theDr;
                theDr = theDt.CreateDataReader();

                try
                {
                    while (theDr.Read())
                    {
                        if (theDr["qryName"].ToString().Trim().ToLower() == lstQueries.Items[lstQueries.SelectedIndex].ToString().Trim().ToLower())
                        {
                            txtEDesc.Text = theDr["qryDescription"].ToString();

                            DataTable eDT = new DataTable();
                            // get the parameters
                            eDT = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                , "SELECT DISTINCT xlsCell, xlsTitle, DHISElementID, CategoryOptionID FROM " +
                                    "(aa_XLMaps LEFT JOIN aa_Queries ON aa_XLMaps.QryID = aa_Queries.QryID) LEFT JOIN  aa_SBCategory ON aa_XLMaps.xlCatID = aa_SBCategory.sbCatID " +
                                        "WHERE qryName = '" + lstQueries.Items[lstQueries.SelectedIndex].ToString() + "' And sbCategory = '" +
                                        lstCategories.Items[lstCategories.SelectedIndex].ToString() +
                                        "' And (aa_SBCategory.DeleteFlag=0 Or aa_SBCategory.DeleteFlag Is Null) And (aa_Queries.DeleteFlag=0 Or aa_Queries.DeleteFlag Is Null) And (aa_XLMaps.DeleteFlag=0 Or aa_XLMaps.DeleteFlag Is Null)"
                                        , ClsUtility.ObjectEnum.DataTable, serverType);
                            dgXls.DataSource = eDT;
                            dgXls.Refresh();
                            break;
                        }
                    }
                }
                catch { }
            }
        }

        private void cmdEMap_Click(object sender, EventArgs e)
        {
            //TODO Replace with pr_SaveUpdateExcelMapping_IQTools
            Cursor.Current = Cursors.WaitCursor;
            DataRow qryDR; DataRow catDR;
            ClsUtility.Init_Hashtable(); int i = 0;

            qryDR = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                , "SELECT qryID FROM aa_Queries WHERE qryName = '" + lstQueries.Items[lstQueries.SelectedIndex].ToString() + "'"
                , ClsUtility.ObjectEnum.DataRow, serverType);
            catDR = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                , "SELECT sbCatID FROM aa_SBCategory WHERE sbCategory = '" + lstCategories.Items[lstCategories.SelectedIndex].ToString()
                + "' And QryId=" + qryDR["QryID"], ClsUtility.ObjectEnum.DataRow, serverType);

            i = 0;
            try
            {
                string sql = "DELETE FROM aa_XLMaps WHERE QryID=" + qryDR["qryID"].ToString() + " AND xlCatID=" + catDR["sbCatID"].ToString();
                i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, sql
                , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                foreach (DataGridViewRow dr in dgXls.Rows)
                {
                    if (dr.Cells["xlsCell"].Value.ToString().Length > 1)
                    {
                        i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                            , "INSERT INTO aa_XLMaps (xlsCell, QryID, xlsTitle, xlCatID, CreateDate, DhisElementID, CategoryOptionID) VALUES('" +
                            dr.Cells["xlsCell"].Value.ToString() + "', " + qryDR["qryID"].ToString() + ", '"
                            + dr.Cells["xlsTitle"].Value.ToString() + "', " + catDR["sbCatID"].ToString() + ", dbo.fn_GetCurrentDate(), '"
                            + dr.Cells["DHISElementID"].Value.ToString() + "','" + dr.Cells["categoryOptionID"].Value.ToString() + "' )"
                            , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);

                    }
                }
                MessageBox.Show("Query Mapping Was Saved Successfully", Assets.Messages.InfoHeader);
            }
            catch (Exception ex)
            {
                EH.LogError(ex.Message, "Excel Mapping", serverType);
            }
            Cursor.Current = Cursors.Default;
        }

        private void cboReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update the list for queries associated with that report
            lstCategories.Items.Clear();
            lstQueries.Items.Clear();
            //txtDesc.Text = "";
            dgXls.DataSource = null;

            if (cboReports.Text != "")
            {
                // get the queries associated with the category
                theDt.Clear();
                DataTableReader theDr;
                ClsUtility.Init_Hashtable();

                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT DISTINCT sbCategory " +
                            "FROM aa_SBCategory LEFT JOIN aa_Category ON aa_SBCategory.CatID = aa_Category.CatID WHERE Category='" + cboReports.Text + "'"
                            , ClsUtility.ObjectEnum.DataTable, serverType);
                theDr = theDt.CreateDataReader();
                while (theDr.Read())
                {
                    lstCategories.Items.Add(theDr["sbCategory"].ToString());
                }
            }

        }

        private void cmdSyns_Click(object sender, EventArgs e)
        {
            Assets.UtFunctions theDB = new Assets.UtFunctions();

            if (theDB.clrIQTables(theDB.chkAccessDB(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), serverType), "iqtools")), ""))
            {
                if (theDB.crtIQTables(theDB.chkAccessDB(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), serverType), "IQTools")), "", null))
                {
                    MessageBox.Show("Update is completed");
                }
            }
        }

        private void lstClinical_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;            
            cmdClinical.Text = "Run";
            //populate the drop down of queries with queries associated with the seleted subcategory
            dgvClinical.DataSource = null;
            theDt.Clear(); DataTableReader theDr;
            cboClinical.Items.Clear(); cboClinical.Text = "";

            
            if (lstClinical.Text != "")
            {
              string sp = "pr_GetQueriesFromSbCategory_IQTools";
              ClsUtility.Init_Hashtable ( );
              ClsUtility.AddParameters ( "@EMR", SqlDbType.VarChar, clsGbl.PMMS );
              ClsUtility.AddParameters ( "@SBC", SqlDbType.VarChar, lstClinical.Text);
              ClsUtility.AddParameters ( "@CATEGORY", SqlDbType.VarChar, "Clinical" );
              Entity en = new Entity ( );
              try
              {
                theDt = (DataTable)en.ReturnObject ( iqtoolsConnString, ClsUtility.theParams, sp
                                        , ClsUtility.ObjectEnum.DataTable, serverType );
              }
              catch (Exception ex)
              {
                MessageBox.Show ( ex.Message );
              }

              //  theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
              //      , "SELECT  QryDescription Description From (aa_Queries LEFT JOIN aa_SBCategory ON aa_Queries.QryID = aa_SBCategory.QryID) LEFT JOIN aa_Category on aa_SBCategory.catID = aa_Category.catID WHERE category = 'Clinical' And (aa_Queries.Deleteflag=0 Or aa_Queries.DeleteFlag Is Null) And (aa_SBCategory.Deleteflag=0 Or aa_SBCategory.DeleteFlag Is Null) And aa_SBCategory.sbCategory='" + lstClinical.Text + "' ORDER By Psn", ClsUtility.ObjectEnum.DataTable, serverType);
                theDr = theDt.CreateDataReader();

                while (theDr.Read())
                { cboClinical.Items.Add(theDr["Description"].ToString()); }
            }
            Cursor.Current = Cursors.Default;
        }

        private void cmdClinical_Click(object sender, EventArgs e)
        {
            
           // Cursor.Current = Cursors.WaitCursor;
            if (cmdClinical.Text.ToLower() == "excel" && dgvClinical.DataSource != null)
            {
               // ExcelReports ER = new ExcelReports();
                try
                {
                  Thread epdThread = new Thread ( ( ) => exportDataToExcel ( (DataTable)dgvClinical.DataSource) );
                  epdThread.SetApartmentState ( ApartmentState.STA );
                  epdThread.Start ( );

                   // ER.ExportExcel((DataTable)dgvClinical.DataSource, "C:\\Cohort\\ExcelExtracts\\Clinical.xls");
                  //  System.Diagnostics.Process.Start("C:\\Cohort\\ExcelExtracts\\Clinical.xls");
                }
                catch
                { }
               // Cursor.Current = Cursors.Default;
                //return;
            }

            if (cboClinical.Text == "3: Excel Report: Duration in days before ART start")
            {
                ExcelReports Er = new ExcelReports();
                if (Params("ART")) Er.ARTStart_IQCare(htCategories);
            }
            else if (cboClinical.Text == "3: Excel Report: Duration in days before ART start - IQChart")
            {
                ExcelReports Er = new ExcelReports();
                if (Params("ART")) Er.ARTStart_IQChart(htCategories, "ART Start");
            }
            else if (cboClinical.Text == "3: Excel Report: Duration in days before ART start - IQChart (by LPTF)")
            {
                ExcelReports Er = new ExcelReports();
                if (Params("ART")) Er.ARTStart_IQChart(htCategories, "LPTF");
            }

            else
            {
                dgvClinical.DataSource = null;
                if (cboClinical.Text != "")
                {
                    DataRow theDr;
                    clsGbl.IQDirection = "clinical";
                    Entity theObject = new Entity(); ClsUtility.Init_Hashtable();

                    theDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                        , "SELECT qryDefinition, qryName FROM aa_Queries WHERE qryDescription='" + cboClinical.Text + "'", ClsUtility.ObjectEnum.DataRow, serverType);
                    clsGbl.currQuery = theDr["qryName"].ToString();
                    try
                    {
                        getQueryParameters(theDr["qryDefinition"].ToString());
                        DataTable dt = (DataTable)theObject.ReturnObject(iqtoolsConnString, ClsUtility.theParams
                            , theDr["qryDefinition"].ToString(), ClsUtility.ObjectEnum.DataTable, serverType);
                        dgvClinical.DataSource = dt;

                        cmdClinical.Text = "Excel";
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void cmdCmp_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (cmdCmp.Text.ToLower() == "excel" && dgvComparisons.DataSource != null)
            {
                ExcelReports ER = new ExcelReports();
                try
                {
                    ER.ExportExcel((DataTable)dgvComparisons.DataSource, "C:\\Cohort\\ExcelExtracts\\Comparisons.xls");
                    System.Diagnostics.Process.Start("C:\\Cohort\\ExcelExtracts\\Comparisons.xls");
                }
                catch
                { }
                Cursor.Current = Cursors.Default;
                return;
            }


            dgvComparisons.DataSource = null;
            if (cboComparisons.Text != "")
            {
                DataRow theDr;
                clsGbl.IQDirection = "comparisons";
                Entity theObject = new Entity(); ClsUtility.Init_Hashtable();

                theDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , "SELECT qryDefinition, qryName FROM aa_Queries WHERE qryDescription='" + cboComparisons.Text + "'"
                    , ClsUtility.ObjectEnum.DataRow, serverType);
                clsGbl.currQuery = theDr["qryName"].ToString();
                try
                {
                    getQueryParameters(theDr["qryDefinition"].ToString());
                    DataTable dt = (DataTable)theObject.ReturnObject(iqtoolsConnString, ClsUtility.theParams
                        , theDr["qryDefinition"].ToString(), ClsUtility.ObjectEnum.DataTable, serverType);
                    dgvComparisons.DataSource = dt;
                }
                catch { }
            }
            Cursor.Current = Cursors.Default;
        }

        private void cmdVals_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            if (cmdCmp.Text.ToLower() == "excel" && dgvValidations.DataSource != null)
            {
                  ExcelReports ER = new ExcelReports();
                try
                {
                  Thread compThread = new Thread ( ( ) => exportDataToExcel ( (DataTable)dgvComparisons.DataSource) );
                  compThread.SetApartmentState ( ApartmentState.STA );
                  compThread.Start ( );

                    //ER.ExportExcel((DataTable)dgvComparisons.DataSource, "C:\\Cohort\\ExcelExtracts\\Comparisons.xls");
                   // System.Diagnostics.Process.Start("C:\\Cohort\\ExcelExtracts\\Comparisons.xls");
                }
                catch
                { }
               // Cursor.Current = Cursors.Default;
               // return;
            }
            if (cmdVals.Text.ToLower() == "excel" && dgvValidations.DataSource != null)
            {
                 ExcelReports ER = new ExcelReports();
                try
                {
                  Thread ValidThread = new Thread ( ( ) => exportDataToExcel ( (DataTable)dgvValidations.DataSource ) );
                  ValidThread.SetApartmentState ( ApartmentState.STA );
                  ValidThread.Start ( );

                    //ER.ExportExcel((DataTable)dgvValidations.DataSource, "C:\\Cohort\\ExcelExtracts\\Validations.xls");
                    //System.Diagnostics.Process.Start("C:\\Cohort\\ExcelExtracts\\Validations.xls");
                }
                catch
                { }
              //  Cursor.Current = Cursors.Default;[
               // return;
            }

          //  dgvValidations.DataSource = null;
            if (cboValidations.Text != "")
            {
                DataRow theDr;
                clsGbl.IQDirection = "validations";
                Entity theObject = new Entity(); ClsUtility.Init_Hashtable();

                theDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , "SELECT qryDefinition, qryName FROM aa_Queries WHERE qryDescription='" + cboValidations.Text + "'", ClsUtility.ObjectEnum.DataRow, serverType);
                clsGbl.currQuery = theDr["qryName"].ToString();
                try
                {
                    getQueryParameters(theDr["qryDefinition"].ToString());
                    DataTable dt = (DataTable)theObject.ReturnObject(iqtoolsConnString, ClsUtility.theParams
                        , theDr["qryDefinition"].ToString(), ClsUtility.ObjectEnum.DataTable, serverType);
                    dgvValidations.DataSource = dt;
                    cmdVals.Text = "Excel";
                }
                catch { }
            }
           // Cursor.Current = Cursors.Default;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // update the text placeholders with the selected gridrow
            txtIQName.ReadOnly = true; txtIQName.BackColor = Color.White;
            txtPWord.Visible = false; lblPWord.Visible = false; txtCPWord.Visible = false; lblCPWord.Visible = false;

            cboUserGroup.Text = dgvUsers.CurrentRow.Cells["Group Name"].Value.ToString();
            txtIQName.Text = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();
            txtFName.Text = dgvUsers.CurrentRow.Cells["FirstName"].Value.ToString();
            txtLName.Text = dgvUsers.CurrentRow.Cells["LastName"].Value.ToString();
            chkUserActive.Checked = !((bool)dgvUsers.CurrentRow.Cells["Deleted"].Value);
        }

        private void lblAddUser_Click(object sender, EventArgs e)
        {
            if (clsGbl.IQDirection != "setUsers") clsGbl.IQDirection = "New User"; txtIQName.ReadOnly = false;
            txtPWord.Visible = true; lblPWord.Visible = true; txtCPWord.Visible = true; lblCPWord.Visible = true;
            txtPWord.Text = ""; txtCPWord.Text = ""; cboUserGroup.Text = "";
            txtFName.Text = ""; txtLName.Text = ""; txtIQName.Text = ""; chkUserActive.Checked = false;
        }

        private void cmdUpdateUser_Click(object sender, EventArgs e)
        {
            int i = 0;
            // edit username

            if (cboUserGroup.Text != "")
            {
                try
                {
                    DataRow gDr; ClsUtility.Init_Hashtable();
                    gDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT GID, GroupName From aa_UserGroups WHERE GroupName='" + cboUserGroup.Text + "' And (DeleteFlag Is Null Or DeleteFlag=0)", ClsUtility.ObjectEnum.DataRow, serverType);
                    if (gDr["GroupName"].ToString() != "")
                    {
                        if (ValidateGroup(gDr["GroupName"].ToString()))
                        {
                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "UPDATE aa_Users SET FirstName='" + txtFName.Text + "', LastName='" + txtLName.Text + "', GID='" + gDr["GID"].ToString() + "', UpdateDate=GetDate(), DeleteFlag='" + !chkUserActive.Checked + "' WHERE UserName='" + txtIQName.Text + "'", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);

                            if (i == 0 && (clsGbl.IQDirection == "New User" || clsGbl.IQDirection == "setUsers"))
                            {
                                if (txtPWord.Text == txtCPWord.Text)
                                {
                                    i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "INSERT INTO aa_Users(FirstName, LastName, UserName, Password, CreateDate, DeleteFlag, GID) VALUES('" + txtFName.Text + "','" + txtLName.Text + "','" + txtIQName.Text + "','" + ClsUtility.Encrypt(txtPWord.Text) + "',GetDate(),'" + !chkUserActive.Checked + "'," + gDr["GID"].ToString() + ")", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                                    txtPWord.Visible = false; lblPWord.Visible = false; txtCPWord.Visible = false; lblCPWord.Visible = false;
                                    txtIQName.ReadOnly = true; txtIQName.BackColor = Color.White;
                                }
                                else
                                { MessageBox.Show("Please enter matching passwords and try again"); return; }
                            }
                            theDt.Clear();
                            dgvUsers.DataSource = null;
                            ClsUtility.Init_Hashtable();
                            theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT FirstName, LastName, UserName, GroupName, aa_Users.DeleteFlag Deleted FROM aa_Users LEFT JOIN aa_userGroups ON aa_Users.GID = aa_UserGroups.GID", ClsUtility.ObjectEnum.DataTable, serverType);
                            dgvUsers.DataSource = theDt;
                            dgvUsers.Columns["GroupName"].Width = 200;
                            dgvUsers.Columns["UserName"].Width = 200;
                            dgvUsers.Columns["FirstName"].Width = 200;
                            dgvUsers.Columns["LastName"].Width = 200;
                            dgvUsers.Refresh();
                            if (clsGbl.IQDirection != "setUsers")
                                clsGbl.IQDirection = "main";
                            else
                                MessageBox.Show("Please start IQTools and log in with your new Account", "IQTools");
                        }
                        else
                        { MessageBox.Show("You do not have permission to create user of this user group!"); return; }
                    }
                    else
                    { MessageBox.Show("Invalid group name was used in creating/updating this user! Operation failed"); return; }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool ValidateGroup(string newgp)
        {
            return true;
        }    

        private void lstPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeriod.Text == "Monthly") popMonths();
            if (cboPeriod.Text == "Quarterly") popQuarters();
        }

        private void popMonths()
        {
            if (lstPeriods.Text != "")
            {
                txtSDate.Text = Convert.ToDateTime(lstPeriods.Text.ToString().Substring(0, lstPeriods.Text.Length - 4) + " 1, " 
                    + lstPeriods.Text.Substring(lstPeriods.Text.Length - 4)).ToShortDateString();
                txtEDate.Text = Convert.ToDateTime(lstPeriods.Text.ToString().Substring(0, lstPeriods.Text.Length - 4) + " " 
                    + DateTime.DaysInMonth(Convert.ToInt16(txtYear.Text), getMonth(lstPeriods.Text.ToString().Substring(0, lstPeriods.Text.Length - 4)) + 1) + ", " 
                    + lstPeriods.Text.Substring(lstPeriods.Text.Length - 4)).ToShortDateString();
                txtQStart.Text = Convert.ToDateTime(txtSDate.Text).Date.AddMonths(-2).ToShortDateString();
            }
        }

        private void popQuarters()
        {
            txtSDate.Text = Convert.ToDateTime(lstPeriods.Text.Substring(0, 3) + " 1, " + lstPeriods.Text.Substring(lstPeriods.Text.Length - 4)).ToShortDateString();
            txtEDate.Text = Convert.ToDateTime(txtSDate.Text).Date.AddMonths(3).AddDays(-1).ToShortDateString();
            txtQStart.Text = Convert.ToDateTime(txtSDate.Text).ToShortDateString();
        }

        private int getMonth(string mth)
        { for (int i = 0; i < 12; i++) if (cboMonths.Items[i].ToString().ToLower().Trim() == mth.ToString().ToLower().Trim()) return i; return 99; }

        private string pmmsType(string description)
        {
            switch (description.Trim().ToLower())
            {
                case "microsoft sql server":
                    return serverType;
                case "mysql server":
                    return "mysql";
                case "microsoft access":
                    return "msaccess";
                default:
                    return "";
            }
        }
        
        private bool getLPMMS()
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                DataRow theDr;
                Entity theObject = new Entity(); ClsUtility.Init_Hashtable();
                BusinessLayer.clsGbl.connTest = false;
                theDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , "SELECT connString From aa_Database", ClsUtility.ObjectEnum.DataRow, serverType);
                conn = (SqlConnection)Entity.GetConnection(ClsUtility.Decrypt(theDr["ConnString"].ToString()), serverType);
                conn.Close();
                conn.Dispose();
                return true;                 
            }
            catch
            {
                return false;
            }
        }

        private bool IQAccess(String Ftrs)
        {
            return true;
        }

        private void lstDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Uri address = new Uri(Application.StartupPath + "\\Help\\QueryGuide\\index.html");
            webHelp.Navigate(address);
        }

        private void lstValidations_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            cmdVals.Text = "Run";
            //populate the drop down of queries with queries associated with the seleted subcategory
            dgvValidations.DataSource = null;
            theDt.Clear(); DataTableReader theDr;
            cboValidations.Items.Clear(); cboValidations.Text = "";
            if (lstValidations.Text != "")
            {

              string sp = "pr_GetQueriesFromSbCategory_IQTools";
              ClsUtility.Init_Hashtable ( );
              ClsUtility.AddParameters ( "@EMR", SqlDbType.VarChar, clsGbl.PMMS );
              ClsUtility.AddParameters ( "@SBC", SqlDbType.VarChar, lstValidations.Text);
              ClsUtility.AddParameters ( "@CATEGORY", SqlDbType.VarChar, "Validations" );
              Entity en = new Entity ( );
              try
              {
                theDt = (DataTable)en.ReturnObject ( iqtoolsConnString, ClsUtility.theParams, sp
                                        , ClsUtility.ObjectEnum.DataTable, serverType );
              }
              catch (Exception ex)
              {
                MessageBox.Show ( ex.Message );
              }
                theDr = theDt.CreateDataReader();
                while (theDr.Read())
                { cboValidations.Items.Add(theDr["Description"].ToString()); }
            }
            Cursor.Current = Cursors.Default;
        }

        private void lstComparisons_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdCmp.Text = "Run";
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (lstComparisons.Text != "")
                {
                    ofdUtility.Filter = "Access Database|*.mdb|All Files|*.*";
                    ofdUtility.FileName = lstComparisons.Text;
                    ofdUtility.ShowDialog();

                    if (ofdUtility.FileName != "")
                    {
                        //populate the drop down of queries with queries associated with the seleted subcategory
                        dgvComparisons.DataSource = null;
                        theDt.Clear(); DataTableReader theDr;
                        cboComparisons.Items.Clear(); cboComparisons.Text = "";

                        string connString = "";


                        try // Mdb files
                        {
                            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + ofdUtility.FileName + ";Persist Security Info=False;";
                            System.Data.OleDb.OleDbConnection cnn = new System.Data.OleDb.OleDbConnection(connString);
                            cnn.Open();
                            cnn.Close(); clsGbl.StrComparisons = connString;
                        }
                        catch
                        {

                            try // Access 12.0
                            {
                                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + ofdUtility.FileName + ";Persist Security Info=False;";
                                System.Data.OleDb.OleDbConnection cnn = new System.Data.OleDb.OleDbConnection(connString);
                                cnn.Open();
                                cnn.Close(); clsGbl.StrComparisons = connString;
                            }
                            catch
                            {

                                try // Access 14.0
                                {
                                    connString = "Provider=Microsoft.ACE.OLEDB.14.0;Data Source= " + ofdUtility.FileName + ";Persist Security Info=False;";
                                    System.Data.OleDb.OleDbConnection cnn = new System.Data.OleDb.OleDbConnection(connString);
                                    cnn.Open();
                                    cnn.Close(); clsGbl.StrComparisons = connString;
                                }
                                catch
                                {

                                    clsGbl.StrComparisons = connString;
                                    connString = "";
                                }
                            }
                        }

                        Assets.UtFunctions theDB = new Assets.UtFunctions();
                        if (theDB.clrIQTables(true, lstComparisons.Text) && theDB.crtIQTables(true, lstComparisons.Text, null))
                        {
                            if (lstComparisons.Text != "")
                            {
                                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                    , "SELECT  QryDescription Description From (aa_Queries LEFT JOIN aa_SBCategory ON aa_Queries.QryID = aa_SBCategory.QryID) " + 
                                    "LEFT JOIN aa_Category on aa_SBCategory.catID = aa_Category.catID WHERE category = 'Comparisons' And (aa_Queries.Deleteflag=0 " + 
                                    "Or aa_Queries.DeleteFlag Is Null) And (aa_SBCategory.Deleteflag=0 Or aa_SBCategory.DeleteFlag Is Null) And aa_SBCategory.sbCategory='" 
                                    + lstComparisons.Text + "' ORDER By Psn"
                                    , ClsUtility.ObjectEnum.DataTable, serverType);
                                theDr = theDt.CreateDataReader();
                                while (theDr.Read())
                                { cboComparisons.Items.Add(theDr["Description"].ToString()); }
                            }
                        }
                        int i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                            , "UPDATE aa_Database SET IQStatus='Connected'", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                        clsGbl.DBState = "Connected";
                    }
                }
            }
            catch { }
            Cursor.Current = Cursors.Default;
        }        

        private void cmdTblClear_Click(object sender, EventArgs e)
        {
            string currDir = clsGbl.IQDirection;
            clsGbl.IQDirection = "ClearAll";
            Cursor.Current = Cursors.WaitCursor;
            Assets.UtFunctions theDB = new Assets.UtFunctions();
            if (theDB.clrIQTables(theDB.chkAccessDB(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "msssql"), "IQTools")), ""))
                MessageBox.Show("Finished clearing all non IQTools tables");
            clsGbl.IQDirection = currDir;
            Cursor.Current = Cursors.Default;
        }

        private void cmdART_Click(object sender, EventArgs e)
        {
            ClsUtility.Init_Hashtable();  
            ClsUtility.AddParameters ("@todate", SqlDbType.VarChar, dtpMAP.Value.ToString ( "s" ) );
            ClsUtility.AddParameters("@numdays", SqlDbType.VarChar, TxtMA.Text.Trim());
            ClsUtility.AddParameters("@appdate", SqlDbType.VarChar, dtpAllApp.Value.ToString("s"));
            ClsUtility.AddParameters("@lowCD4",SqlDbType.VarChar, txtLCD4.Text.Trim());
            ClsUtility.AddParameters("@highCD4", SqlDbType.VarChar, txtHCD4.Text.Trim());
            ClsUtility.AddParameters("@lowVL", SqlDbType.VarChar, txtLowVL.Text.Trim());

         //   dgvAdherence.DataSource = null;

            if (dgvAdherence.DataSource != null && cmdART.Text == Assets.Messages.ExportToExcel)
            {
               
                try
                {
                  Thread  exportDataThread = new Thread ( ( ) => exportDataToExcel ( (DataTable)dgvAdherence.DataSource ) );
                  exportDataThread.SetApartmentState ( ApartmentState.STA );
                  exportDataThread.Start ( );
          
                }
                catch
                { }
            
            }

            string strQuery = "";

            foreach (Control x in gbART.Controls)
            {
                if (x.GetType().ToString().ToLower() == "system.windows.forms.radiobutton")
                {
                    RadioButton rb = new RadioButton();
                    rb = (RadioButton)x;
                    if (rb.Checked)
                    {
                        strQuery = rb.Name;
                        break;
                    }
                }
            }
            string strName = "";
            switch (strQuery.ToLower())
            {
                case "optmap":
                    if (clsGbl.PMMS.ToLower() == "iqcare" || clsGbl.PMMS.ToLower() == "smartcare" || clsGbl.PMMS.ToLower() == "isante" || clsGbl.PMMS.ToLower() == "cpad")
                        strName = "IQC_missedARVPickup";
                    else if (clsGbl.PMMS.ToLower() == "ctc2" || clsGbl.PMMS.ToLower() == "ctc2mysql")
                        strName = "IQC_MissedARVTzPickup";
                    else
                        strName = "PMT_0001c";
                    break;

                case "optart":
                    if (clsGbl.PMMS.ToLower() == "iqcare" || clsGbl.PMMS.ToLower() == "smartcare" || clsGbl.PMMS.ToLower() == "isante"
                        || clsGbl.PMMS.ToLower() == "ctc2" || clsGbl.PMMS.ToLower() == "ctc2mysql" || clsGbl.PMMS.ToLower() == "cpad")
                        strName = "IQC_corePatientLineList";
                    else
                        strName = "PMT_0001i";
                    break;

                case "optapa":
                    if (clsGbl.PMMS.ToLower() == "iqcare" || clsGbl.PMMS.ToLower() == "smartcare" || clsGbl.PMMS.ToLower() == "isante"
                        || clsGbl.PMMS.ToLower() == "ctc2" || clsGbl.PMMS.ToLower() == "ctc2mysql" || clsGbl.PMMS.ToLower() == "cpad")
                        strName = "IQC_ARTMissedAppointments";
                    else
                        strName = "PMT_0001d";
                    break;

                case "optallapp":
                    if (clsGbl.PMMS.ToLower() == "iqcare" || clsGbl.PMMS.ToLower() == "smartcare" || clsGbl.PMMS.ToLower() == "isante"
                        || clsGbl.PMMS.ToLower() == "ctc2" || clsGbl.PMMS.ToLower() == "ctc2mysql" || clsGbl.PMMS.ToLower() == "cpad")
                        strName = "IQC_patientAppointments";
                    else
                        strName = "PMT_0001e";
                    break;

                case "optadherence":
                    if (clsGbl.PMMS.ToLower() == "iqcare" || clsGbl.PMMS.ToLower() == "smartcare" || clsGbl.PMMS.ToLower() == "isante"
                        || clsGbl.PMMS.ToLower() == "ctc2" || clsGbl.PMMS.ToLower() == "ctc2mysql" || clsGbl.PMMS.ToLower() == "cpad")
                        strName = "IQC_ARVAdherence";
                    else
                        strName = "PMT_0001f";
                    break;

                case "optnoartcd4xy":
                    if (clsGbl.PMMS.ToLower() == "iqcare" || clsGbl.PMMS.ToLower() == "smartcare" || clsGbl.PMMS.ToLower() == "isante"
                        || clsGbl.PMMS.ToLower() == "ctc2" || clsGbl.PMMS.ToLower() == "ctc2mysql" || clsGbl.PMMS.ToLower() == "cpad")
                        strName = "IQC_nonARTCD4";
                    else
                        strName = "PMT_0001g";
                    break;

                case "optnoartnocd4":
                    if (clsGbl.PMMS.ToLower() == "iqcare" || clsGbl.PMMS.ToLower() == "smartcare" || clsGbl.PMMS.ToLower() == "isante"
                        || clsGbl.PMMS.ToLower() == "ctc2" || clsGbl.PMMS.ToLower() == "ctc2mysql" || clsGbl.PMMS.ToLower() == "cpad")
                        strName = "IQC_nonARTNoCD4";
                    else
                        strName = "PMT_0001h";
                    break;

                case "optma":
                    if (clsGbl.PMMS.ToLower() == "iqcare" || clsGbl.PMMS.ToLower() == "smartcare" || clsGbl.PMMS.ToLower() == "isante" || clsGbl.PMMS.ToLower() == "cpad")
                        strName = "IQC_MissedAppointments";
                    else if (clsGbl.PMMS.ToLower() == "ctc2" || clsGbl.PMMS.ToLower() == "ctc2mysql")
                        strName = "IQC_MissedTzAppointments";
                    else
                        strName = "PMT_0001j";
                    break;
                case "optvldetect":
                    strName = "IQC_DetectableViralLoads";
                    break;
                case "optvl":
                    strName = "IQC_DueForViralLoad";
                    break;
            }
         
            Thread runQueryThread = new Thread(() => runQuery(strName, ClsUtility.theParams, dgvAdherence));
            runQueryThread.SetApartmentState(ApartmentState.STA);
            runQueryThread.Start();
          
        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        private static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe)
                    , new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control
                    , new object[] { propertyValue });
            }
        }        

        private void runQuery(string qryName, Hashtable queryParams, DataGridView dgv)
        {
            Hashtable queryParameters = new Hashtable(queryParams);
            Entity en = new Entity();
            string sp = "pr_GetQuerySQL_IQTools";
            ClsUtility.Init_Hashtable();
            ClsUtility.AddParameters("@qryName", SqlDbType.VarChar, qryName);
            try
            {
                SetControlPropertyThreadSafe(picProgress, "Image", Properties.Resources.progressWheel5);
                SetControlPropertyThreadSafe(lblNotify, "Text", "Running Query....");
                SetControlPropertyThreadSafe(cmdART, "Enabled", false);
                SetControlPropertyThreadSafe(dgv, "DataSource", null);

                DataRow sqlDR = (DataRow)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp, ClsUtility.ObjectEnum.DataRow, serverType);
                string querySQL = sqlDR["querySQL"].ToString();
                
                DataTable queryDT = (DataTable)en.ReturnObject(iqtoolsConnString, queryParameters, querySQL, ClsUtility.ObjectEnum.DataTable, serverType);              
                SetControlPropertyThreadSafe(dgv, "DataSource", queryDT);
                SetControlPropertyThreadSafe ( cmdART, "Text", Assets.Messages.ExportToExcel );
                setEMRLinkColumn(dgv, clsGbl.PMMS);
            }
            catch (Exception ex)
            {
                 SetControlPropertyThreadSafe ( cmdART, "Text", Assets.Messages.ViewReport );
                MessageBox.Show(ex.Message);
               
            }
            finally
            {
                SetControlPropertyThreadSafe(picProgress, "Image", null);
                SetControlPropertyThreadSafe(lblNotify, "Text", dgv.Rows.Count.ToString() + " Records");
                SetControlPropertyThreadSafe(cmdART, "Enabled", true);
     
           
            }

        }

        private void exportDataToExcel (DataTable dT)
        {
          ExcelReports ER = new ExcelReports ( );
          try
          {
            SetControlPropertyThreadSafe ( picProgress, "Image", Properties.Resources.progressWheel5 );
            SetControlPropertyThreadSafe ( lblNotify, "Text", "Exporting To Excel...." );
            SetControlPropertyThreadSafe ( cmdART, "Enabled", false );
            ER.ExportToExcel (dT, exportPath );
          }
          catch (Exception ex)
          {
            SetControlPropertyThreadSafe ( cmdART, "Text", Assets.Messages.ExportToExcel );
            MessageBox.Show ( ex.Message );
          }
           finally {

             SetControlPropertyThreadSafe ( picProgress, "Image", null );
             SetControlPropertyThreadSafe ( lblNotify, "Text", "Successfully Exported" );
             SetControlPropertyThreadSafe ( cmdART, "Enabled", true );
             SetControlPropertyThreadSafe ( cmdART, "Text", Assets.Messages.ViewReport );
          
          }


        
        
        }
        
        private void setEMRLinkColumn(DataGridView dgv, string EMR)
        {
            if (EMR.ToLower() == "iqcare" && dgv.Columns.Contains("PatientPK"))
            {
                try
                {
                    DataGridViewLinkColumn dgvlc = new DataGridViewLinkColumn();
                    dgvlc.DataPropertyName = "PatientPK";
                    dgvlc.HeaderText = "IQCare Link";
                    dgvlc.Name = "PtnPk"; //Rename the Column since we need to hide PatientPK 
                    if (dgv.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            dgv.Columns.Add(dgvlc);
                            dgv.Columns["PtnPk"].DisplayIndex = 0;
                            dgv.Columns["PatientPK"].Visible = false;
                        }));
                    }
                    else
                    {
                        dgv.Columns.Add(dgvlc);
                        dgv.Columns["PtnPk"].DisplayIndex = 0;
                        dgv.Columns["PatientPK"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Assets.Messages.ErrorHeader);
                }
            }
        }

        private void dgvAdherence_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "Error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Error";
                e.ThrowException = false;
            }
        }        
        
        private void tcReports_Selected(Object sender, TabControlEventArgs e)
        {
            //DataTableReader theDr;
            if (e.TabPage == tpClinical)
            {
                clsGbl.Queries.DefaultView.RowFilter = "Category = 'Clinical'";
                clsGbl.Queries.DefaultView.Sort = "SubCategory";
                lstClinical.DataSource = new BindingSource(clsGbl.Queries.DefaultView.ToTable(true, "SubCategory"), null);
                lstClinical.DisplayMember = "SubCategory";
            }
            else if (e.TabPage == tpDonor)
            {
                txtYear.Text = Convert.ToString(DateTime.Today.Year);
                lstPeriods.Items.Clear();
                lstPeriods.Visible = true;
                cboPeriod_SelectedIndexChanged(sender, e);
            }
            else if (e.TabPage == tpVals)
            {               
                clsGbl.Queries.DefaultView.RowFilter = "Category = 'Validations'";
                clsGbl.Queries.DefaultView.Sort = "SubCategory";
                lstValidations.DataSource = new BindingSource(clsGbl.Queries.DefaultView.ToTable(true, "SubCategory"), null);
                lstValidations.DisplayMember = "SubCategory";
            }
            else if (e.TabPage == tpComparisons)
            {
                clsGbl.Queries.DefaultView.RowFilter = "Category = 'Comparisons'";
                clsGbl.Queries.DefaultView.Sort = "SubCategory";
                lstComparisons.DataSource = new BindingSource(clsGbl.Queries.DefaultView.ToTable(true, "SubCategory"), null);
                lstComparisons.DisplayMember = "SubCategory";                
            }
        }

        private bool Params(string Report)
        {
            htCategories = new Hashtable();
            if (Report.ToLower() == "cdc" || Report.ToLower() == "aidsrelief")
            {
                if (clsGbl.PMMSType.ToLower() == "mysql")
                {
                    htCategories.Add("@FromDate", txtSDate.Value.ToString("yyyy-MM-dd"));
                    htCategories.Add("@ToDate", txtEDate.Value.ToString("yyyy-MM-dd"));
                }
                else
                {
                    htCategories.Add("@FromDate", txtSDate.Value);
                    htCategories.Add("@ToDate", txtEDate.Value);
                }
                htCategories.Add("@CD4Cutoff", txtCD4.Text);
            }
            else if (Report.ToLower() == "cohortreport")
            {
                if (clsGbl.PMMSType.ToLower() == "mysql")
                {
                    htCategories.Add("@FromDate", txtSDate.Text);
                    htCategories.Add("@ToDate", txtEDate.Text);
                }
                else
                {
                    htCategories.Add("@FromDate", txtSDate.Value);
                    htCategories.Add("@ToDate", txtEDate.Value);
                }
                int numYears = Convert.ToInt32(cboCohortFollowUp.Text.Substring(0, 2)) / 12;
                htCategories.Add("@xYears", numYears);
            }
            else if (Report.ToLower() == "optmap" || Report.ToLower() == "optma")
            {
                htCategories.Add("@NumDays", TxtMA.Text);
                if (dtpMAP.Checked)
                {
                    if (clsGbl.PMMSType.ToLower() == "mysql")   //opt check for mysql : isante
                    { htCategories.Add("@ToDate", dtpMAP.Text); }
                    else
                    { htCategories.Add("@ToDate", dtpMAP.Value); }
                }
                else
                {
                    htCategories.Add("@ToDate", DateTime.Now.Date);
                }
            }
            else if (Report.ToLower() == "scm")
            {
                htCategories.Add("@FromDate", txtSDate.Text);
                htCategories.Add("@ToDate", txtEDate.Text);
            }
            else if (Report.ToLower() == "patientsummary")
            {
                htCategories.Add("@PatientPK", 5512);
                htCategories.Add("@AgeLastVisit", 50);
            }
            else
            {

                if (dtpAllApp.Checked)
                    if (clsGbl.PMMSType.ToLower() == "mysql")
                    { htCategories.Add("@AppDate", dtpAllApp.Value.ToString("yyyy-MM-dd")); }
                    else
                    { htCategories.Add("@AppDate", dtpAllApp.Value.ToString("yyyy-MM-dd")); }

                else
                    htCategories.Add("@AppDate", DateTime.Now.Date);
                //htCategories.Add("@PatientID", txtPatient.Text);
                htCategories.Add("@LowCD4", txtLCD4.Text);
                htCategories.Add("@HighCD4", txtHCD4.Text);
                htCategories.Add("@NumDays", TxtMA.Text);
            }
            return true;
        }

        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPeriods.Items.Clear();
            lstPeriods.Visible = true;
            switch (cboPeriod.SelectedIndex)
            {
                case 0:
                    clsGbl.periodType = "Monthly";
                    pnlCustomDates.Enabled = false;
                    for (int i = -7; i < 12; i++)
                    {
                        lstPeriods.Items.Add(string.Format("{0:MMMM yyyy}", Convert.ToDateTime(cboMonths.Items[0].ToString() + "1, " + txtYear.Text).AddMonths(i)));
                    }
                    break;

                case 1:
                    clsGbl.periodType = "Quarterly";
                    pnlCustomDates.Enabled = false;
                    for (int i = 0; i <= 18; i++)
                    {
                        switch ((Math.Abs(i) % 4) + 1)
                        {
                            case 1:
                                lstPeriods.Items.Add("Jan - Mar " + (Convert.ToInt32(txtYear.Text) + ((i / 4) - 3)));
                                break;
                            case 2:
                                lstPeriods.Items.Add("Apr - Jun " + (Convert.ToInt32(txtYear.Text) + ((i / 4) - 3)));
                                break;
                            case 3:
                                lstPeriods.Items.Add("Jul - Sep " + (Convert.ToInt32(txtYear.Text) + ((i / 4) - 3)));
                                break;
                            case 4:
                                lstPeriods.Items.Add("Oct - Dec " + (Convert.ToInt32(txtYear.Text) + ((i / 4) - 3)));
                                break;
                        }
                    }
                    break;
                case 2:
                    clsGbl.periodType = "Custom";
                    pnlCustomDates.Enabled = true;
                    lstPeriods.Visible = false;
                    break;
            }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            txtSDate.Value = DateTime.Today; txtEDate.Value = DateTime.Today;
            cboPeriod_SelectedIndexChanged(sender, e);
        }

        private void cmdCReport_Click(object sender, EventArgs e)
        {
            if ((chkDonorCCC.Checked && cboDonorCCC.Text == "") || (OptDonorLPTF.Checked && cboDonorLPTF.Text == ""))
            { MessageBox.Show("Please select an LPTF/CCC to proceed"); return; }

            setLocale();
            Cursor.Current = Cursors.WaitCursor;
            if (txtSDate.Text != txtEDate.Text || clsGbl.IQDirection == "IQCare: mortality report")
            {
                ExcelReports ER = new ExcelReports();
                string currReport = getRadio(tlpCommon).ToLower();
                if (currReport != "")
                {
                    try
                    {
                        clsGbl.IQDirection = currReport;
                        switch (currReport)
                        {
                            case "optar":
                                if (Params("AIDSRelief"))
                                { ER.AIDSRelief(htCategories, clsGbl.locType, cboDonorLPTF.Text, cboDonorCCC.Text, setCCCs(cboDonorLPTF, chkDonorLPTF), this.pgBCommon); }
                                break;
                            case "optcdc":
                                if (Params("CDC")) ER.CDCReport(htCategories, clsGbl.locType, cboDonorLPTF.Text, cboDonorCCC.Text, setCCCs(cboDonorLPTF, chkDonorLPTF), chkDonorLPTF.Checked, this.pgBCommon);
                                break;
                            case "optmortality":
                                if (Params("Mortality")) ER.Mortality(htCategories);
                                break;
                            case "optartcohort":
                                if (Params("cohortreport"))
                                { ER.ARTCohort(htCategories, clsGbl.locType, cboDonorLPTF.Text, cboDonorCCC.Text, setCCCs(cboDonorLPTF, chkDonorLPTF), chkDonorLPTF.Checked, this.pgBCommon); }
                                break;
                            case "opthivqual":
                                if (Params("AIDSRelief"))
                                { ER.HIVQUAL(htCategories, clsGbl.locType, cboDonorLPTF.Text, cboDonorCCC.Text, setCCCs(cboDonorLPTF, chkDonorLPTF), chkDonorLPTF.Checked, this.pgBCommon); }
                                break;
                        }
                    }
                    catch { }
                }
                else MessageBox.Show(Assets.Messages.Report1, Assets.Messages.ErrorHeader);
            }

            else MessageBox.Show(Assets.Messages.Report2, Assets.Messages.ErrorHeader);
            Cursor.Current = Cursors.Default;
        }

        private void setLocale()
        {
            if (tcDonors.SelectedTab == tpCommon)
            {

                if (OptDonorAll.Checked && !chkCohortReportLL.Checked)
                { clsGbl.locType = "All"; }
                else if (OptDonorLPTF.Checked && !chkDonorCCC.Checked)
                { clsGbl.locType = "LPTF"; }
                else if (OptDonorLPTF.Checked && chkDonorCCC.Checked)
                { clsGbl.locType = "CCC"; }
                else if (OptDonorAll.Checked && chkCohortReportLL.Checked)
                {
                    clsGbl.locType = "AllCR";
                }
            }
            else
            {
                if (tcCountries.SelectedTab == tpKe)
                {
                    if (OptKEAll.Checked && !chk_RCLineLists.Checked)
                    { clsGbl.locType = "All"; }
                    else if (OptKELPTF.Checked && !ChkKECCC.Checked)
                    { clsGbl.locType = "LPTF"; }
                    else if (OptKELPTF.Checked && ChkKECCC.Checked)
                    { clsGbl.locType = "CCC"; }
                    else if (OptKEAll.Checked && chk_RCLineLists.Checked)
                    { clsGbl.locType = "AllRC"; }
                }
                else if (tcCountries.SelectedTab == tpUg)
                {
                    if (optUgAll.Checked)
                    { clsGbl.locType = "All"; }
                    else if (optUgLPTF.Checked && !chkUgCCC.Checked)
                    { clsGbl.locType = "LPTF"; }
                    else if (optUgLPTF.Checked && chkUgCCC.Checked)
                    { clsGbl.locType = "CCC"; }
                }
                else if (tcCountries.SelectedTab == tpNg)
                {
                    if (optNgAll.Checked)
                    { clsGbl.locType = "All"; }
                    else if (optNgLPTF.Checked && !chkNgCCC.Checked)
                    { clsGbl.locType = "LPTF"; }
                    else if (optNgLPTF.Checked && chkNgCCC.Checked)
                    { clsGbl.locType = "CCC"; }
                }
                else if (tcCountries.SelectedTab == tpHt)
                {
                    if (optHt_All.Checked)
                    { clsGbl.locType = "All"; }
                    else if (optHt_LPTF.Checked && !chkHt_CCC.Checked)
                    { clsGbl.locType = "LPTF"; }
                    else if (optHt_LPTF.Checked && chkHt_CCC.Checked)
                    { clsGbl.locType = "CCC"; }

                }
            }

        }

        private string getRadio(Panel x)
        {
            string str = "";
            foreach (Control y in x.Controls)
            {
                if (y.GetType().ToString().ToLower() == "system.windows.forms.radiobutton")
                {
                    RadioButton z = new RadioButton();
                    z = (RadioButton)y;
                    if (z.Checked)
                    {
                        str = z.Name;
                        break;
                    }
                }
            }
            return str;
        }

        private void OptDonorLPTF_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string SQLString;
            chkDonorLPTF.Enabled = OptDonorLPTF.Checked;
            if (OptDonorLPTF.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                theDt.Clear(); DataTableReader theDr;
                cboDonorLPTF.Items.Clear(); cboDonorLPTF.Text = "";
                if (clsGbl.PMMS.ToLower() == "iqcare")
                    SQLString = "SELECT  FacilityName From IQC_siteDetails ORDER BY FacilityID";
                else
                    SQLString = "SELECT  FacilityName From PMT_0001a";
                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, SQLString, ClsUtility.ObjectEnum.DataTable, clsGbl.PMMSType);
                theDr = theDt.CreateDataReader();

                while (theDr.Read())
                { cboDonorLPTF.Items.Add(theDr["FacilityName"].ToString()); }
            }
            else
            {
                cboDonorLPTF.Items.Clear();
                cboDonorLPTF.Text = "";
                cboDonorCCC.Text = "";
                chkDonorLPTF.Checked = OptDonorLPTF.Checked;
                chkDonorCCC.Checked = OptDonorLPTF.Checked;
            }
            Cursor.Current = Cursors.Default;
        }

        private void chkCCCs(bool sender, ComboBox cboCCC, ComboBox cboLPTF)
        {
            Cursor.Current = Cursors.WaitCursor;
            string SQLString;
            if (sender)
            {
                if (cboLPTF.Text != "")
                {
                    theDt.Clear(); DataTableReader theDr;
                    cboCCC.Items.Clear(); cboCCC.Text = "";

                    if (clsGbl.PMMS.ToLower() == "iqcare")
                        SQLString = "SELECT  FacilityName Facility From IQC_siteDetails WHERE FacilityName='" + cboLPTF.Text.Replace("'", "''") + "'";
                    else
                        SQLString = "SELECT  [Name] Facility From PMT_0001a_ALL WHERE LPTF='" + cboLPTF.Text.Replace("'", "''") + "'";
                    theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, SQLString, ClsUtility.ObjectEnum.DataTable, clsGbl.PMMSType);
                    theDr = theDt.CreateDataReader();
                    while (theDr.Read())
                    { cboCCC.Items.Add(theDr["Facility"].ToString()); }
                }
            }
            else
            {
                cboDonorCCC.Items.Clear();
                cboDonorCCC.Text = "";
            }
            Cursor.Current = Cursors.Default;
        }

        private void cboDonorCCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDonorCCC.Text != "")
                chkDonorLPTF.Checked = false;
        }

        private void cboDonorLPTF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDonorLPTF.Text != "")
                chkCCCs(true, cboDonorCCC, cboDonorLPTF);
        }

        private DataTable setCCCs(ComboBox cboLPTF, CheckBox chkLPTF)
        {
            string SQLString;
            if (cboLPTF.Text.Replace("'", "''") != "" && chkLPTF.Checked)
            {
                if (clsGbl.PMMS.ToLower() == "iqcare")
                    SQLString = "SELECT  FacilityName Facility From IQC_siteDetails ORDER By FacilityID";
                else
                    SQLString = "SELECT  [Name] Facility From PMT_0001a_ALL WHERE LPTF='" + cboLPTF.Text.Replace("'", "''") + "'";
                return (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, SQLString, ClsUtility.ObjectEnum.DataTable, clsGbl.PMMSType);
            }
            return null;
        }

        private void chkDonorLPTF_CheckedChanged(object sender, EventArgs e)
        {
            if (cboDonorLPTF.Text == "")
                chkDonorLPTF.Checked = false;

            if (chkDonorLPTF.Checked)
                chkDonorCCC.Checked = false;
            cboDonorCCC.Text = "";
        }

        private void chkDonorCCC_CheckedChanged(object sender, EventArgs e)
        {
            if (cboDonorLPTF.Text == "")
                chkDonorCCC.Checked = false;

            if (chkDonorCCC.Checked)
                chkDonorLPTF.Checked = false;
            cboDonorCCC.Text = "";
        }

        private void CmdKeReports_Click(object sender, EventArgs e)
        {
            #region Patient_Summary
            double patientAge;
            int patientPK;
            string patientID;

            if (getRadio(tlp_KeReports).ToLower() == "optke_ps")
            {
                //MessageBox.Show("Kenyatta Patient Summary");
                if (txtPatientID.Text == "")
                {
                    MessageBox.Show("No ID");
                }
                else
                {
                    //Get Ptn_Pk and Age
                    Entity en = new Entity();

                    try
                    {
                        DataRow dr = (DataRow)en.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                            , "SELECT Top 1 PatientPK, AgeLastVisit,PatientID FROM tmp_PatientMaster Where PatientID Like '%" + txtPatientID.Text.Trim() + "'", ClsUtility.ObjectEnum.DataRow, serverType);

                        patientAge = Convert.ToDouble(dr[1].ToString());
                        patientPK = Convert.ToInt32(dr[0].ToString());
                        patientID = dr[2].ToString();
                        //MessageBox.Show(patientAge.ToString() + " " + patientPK.ToString());

                        //ER
                        ER = new ExcelReports();
                        htCategories = new Hashtable();
                        ClsUtility.Init_Hashtable();

                        htCategories.Add("@PatientPk", patientPK);
                        ER.PatientSummary(htCategories, patientAge, patientID, this.prBKeReports);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("no row at position 0"))
                        {
                            MessageBox.Show("Patient Does Not Exist, Please check the Patient ID and try again", "IQTools");
                        }
                        else
                        {
                            MessageBox.Show("The following error has occured: " + ex.Message, "IQTools");
                        }
                    }
                }
            }
            #endregion

            else
            {

                if ((ChkKECCC.Checked && CboKECCC.Text == "") || (OptKELPTF.Checked && cboKELPTF.Text == ""))
                { MessageBox.Show("Please select an LPTF/CCC to proceed"); return; }

                setLocale();
                Cursor.Current = Cursors.WaitCursor;
                if (txtSDate.Text != txtEDate.Text || clsGbl.IQDirection == "IQCare: mortality report")
                {
                    ER = new ExcelReports();
                    string currReport = getRadio(tlp_KeReports).ToLower();
                    if (currReport != "")
                    {

                        clsGbl.sendToDHIS = false;
                        clsGbl.sendToDHIS = chk_KESendToDHIS.Checked;

                        if (clsGbl.sendToDHIS)
                        {
                            if (setDHISInfo() == false) return;
                        }

                        clsGbl.IQDirection = currReport;
                        switch (currReport)
                        {
                            case "optke_oidrugs":
                                if (Params("SCM"))
                                { ER.OIDrugsReport(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports); }
                                break;
                            case "optke_heiregister":
                                if (Params("SCM"))
                                { ER.HEIRegister(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports); }
                                break;
                            case "optke_tbc":
                                if (Params("AIDSRelief"))
                                { ER.TBSummary(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports); }
                                break;
                            case "optke_heica":
                                if (Params("SCM"))
                                { ER.HEICA(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports); }
                                break;
                            case "optke_mchc":
                                if (Params("SCM"))
                                { ER.MCHC(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports); }
                                break;
                            case "optke_fmap":
                                if (Params("SCM"))
                                { ER.FMAPS(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports); }
                                break;
                            case "optke_cdrr":
                                if (Params("SCM"))
                                { ER.CDRR(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports); }
                                break;
                            case "optke_moh731":
                                if (Params("AIDSRelief"))
                                { ER.MoH731(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports); }
                                break;
                            case "optke_moh711":
                                if (Params("AIDSRelief"))
                                { ER.MoH711(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports); }
                                break;
                            case "optke_rc":
                                if (Params("AIDSRelief"))
                                {
                                    ER.KeRC(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports);
                                }
                                break;
                            case "optke_moh361b":
                                if (Params("AIDSRelief"))
                                {
                                    ER.MoH361B(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports);
                                }
                                break;
                            case "optke_defaulter":
                                if (Params("AIDSRelief"))
                                {
                                    ER.DTR(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports);
                                }
                                break;
                            case "optke_pwp":
                                if (Params("AIDSRelief"))
                                {
                                    ER.PwP(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports);
                                }
                                break;
                            case "optke_tbregister":
                                if (Params("AIDSRelief"))
                                {
                                    ER.TBRegister(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports);
                                }
                                break;
                            case "optKe_MoH717":
                                if (Params("AIDSRelief"))
                                {
                                    ER.MoH717(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports);
                                }
                                break;
                            case "optKe_MoH705A":
                                if (Params("AIDSRelief"))
                                {
                                    ER.MoH705A(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports);
                                }
                                break;
                            case "optKe_MoH705B":
                                if (Params("AIDSRelief"))
                                {
                                    ER.MoH705B(htCategories, clsGbl.locType, cboKELPTF.Text, CboKECCC.Text, setCCCs(cboKELPTF, ChkKELPTF), ChkKELPTF.Checked, this.prBKeReports);
                                }
                                break;
                            case "optke_lwak":
                                if (Params("cdc"))
                                {
                                    AccessExtracts AE = new AccessExtracts();
                                    string connString = AE.AcessDB(htCategories);
                                    if (connString != "")
                                    {
                                        string tblName = "";
                                        string QryName = "";
                                        string sCon = "";

                                        string curruid = "";
                                        string currpwd = "";

                                        int dbIndex = 0;
                                        int dbUid = 0;
                                        int dbPwd = 0;


                                        for (x = 0; x < 5; x++)
                                        {
                                            switch (x)
                                            {
                                                case 0:
                                                    tblName = "[Demography]";
                                                    QryName = "IQC_0026a";
                                                    break;
                                                case 1:
                                                    tblName = "[Follow Up]";
                                                    QryName = "IQC_0026b";
                                                    break;
                                                case 2:
                                                    tblName = "[Laboratory]";
                                                    QryName = "IQC_0026c";
                                                    break;
                                                case 3:
                                                    tblName = "[Adult Pharmacy]";
                                                    QryName = "IQC_0026d";
                                                    break;
                                                case 4:
                                                    tblName = "[Peads Pharmacy]";
                                                    QryName = "IQC_0026e";
                                                    break;
                                            }

                                            if (tblName != "" && QryName != "")
                                            {

                                                theDt.Clear();
                                                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath)
                                                    , ClsUtility.theParams, "SELECT Top 0 * from " + QryName, ClsUtility.ObjectEnum.DataTable, clsGbl.PMMSType);
                                                string TblFields = AE.CreateTable(theDt, tblName);
                                                if (TblFields != "")
                                                {
                                                    try
                                                    {
                                                        sCon = Entity.getconnString(clsGbl.xmlPath);
                                                        SqlConnection sqCon = new SqlConnection(sCon);
                                                        if (sqCon.State != ConnectionState.Open)
                                                            sqCon.Open();
                                                        clsGbl.currServer = sqCon.DataSource;
                                                        clsGbl.currData = sqCon.Database;
                                                        sqCon.Close();
                                                        sqCon.Dispose();

                                                        string tmpString = ""; int len = 0;
                                                        dbIndex = sCon.ToLower().IndexOf("catalog"); dbUid = sCon.ToLower().IndexOf("uid"); dbPwd = sCon.ToLower().IndexOf("pwd");

                                                        tmpString = sCon;
                                                        if (tmpString.IndexOf(";") > 0)
                                                            len = tmpString.IndexOf(";", dbUid);
                                                        else
                                                            len = tmpString.Length;
                                                        curruid = tmpString.Substring((dbUid + 5), len - (dbUid + 5)).Trim();
                                                        if (tmpString.IndexOf(";", dbPwd) > 0)
                                                            len = tmpString.IndexOf(";", dbPwd);
                                                        else
                                                            len = tmpString.Length;
                                                        currpwd = tmpString.Substring(dbPwd + 5, len - (dbPwd + 5)).Trim();
                                                    }
                                                    catch (Exception ex) { throw ex; }

                                                    try
                                                    {
                                                        string InsertString = "SELECT " + TblFields + " INTO " + tblName + " FROM " + QryName 
                                                            + " IN '' [ODBC;Driver={SQL Server};Server=" + clsGbl.currServer + ";Database=" + clsGbl.currData + ";Trusted_Connection=yes];";
                                                        System.Data.OleDb.OleDbConnection odConn = new System.Data.OleDb.OleDbConnection(connString);
                                                        if (odConn.State != ConnectionState.Open) odConn.Open();
                                                        System.Data.OleDb.OleDbCommand odc = new System.Data.OleDb.OleDbCommand(InsertString, odConn);
                                                        int i = 0;
                                                        i = odc.ExecuteNonQuery();
                                                        odc.Dispose(); odConn.Close(); odConn.Dispose();
                                                    }
                                                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                                                }
                                            }
                                            tblName = ""; QryName = "";
                                        }
                                        MessageBox.Show("The Database has been successfully created");
                                    }
                                    else
                                    { MessageBox.Show("There was a problem creating a Lwak Access database", "IQTools"); }
                                }
                                break;
                        }
                    }
                    else MessageBox.Show("Please specify a report to generate!");
                }

                else MessageBox.Show("Please specify a start and end date to proceed");
                Cursor.Current = Cursors.Default;
            }

        }

        private bool setDHISInfo()
        {
            frmDHISPassword DHIS2PW = new frmDHISPassword();
            DialogResult dr = DHIS2PW.ShowDialog();
            if (dr == DialogResult.Cancel) return false;

            ER.DHIS2Credentials = DHIS2PW.UName + ":" + DHIS2PW.PWord;
            ER.EndDateDHIS = txtEDate.Value;
            ER.StartDateDHIS = txtSDate.Value;
            ER.MFLCode = DHIS2PW.MFLCode;
            ER.DHIS2URL = DHIS2PW.DHIS2URL;
            DataTable qryDR;

            qryDR = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                , "SELECT [DHISCode]FROM [lnk_Facility] where [MFLCode]='" + ER.MFLCode + "'", ClsUtility.ObjectEnum.DataTable, serverType);
            if (qryDR.Rows.Count != 0)
            {
                ER.DHISCode = qryDR.Rows[0]["DHISCode"].ToString();
            }
            else
            {
                MessageBox.Show("Facility with specified code not found. Please enter a valid code");
                return false;
            }
            return true;
        }

        private void OptKELPTF_CheckedChanged(object sender, EventArgs e)
        {
            string SQLString;
            Cursor.Current = Cursors.WaitCursor;
            ChkKELPTF.Enabled = OptKELPTF.Checked;
            if (OptKELPTF.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                theDt.Clear(); DataTableReader theDr;
                cboKELPTF.Items.Clear(); cboKELPTF.Text = "";
                if (clsGbl.PMMS.ToLower() == "iqcare")
                    SQLString = "SELECT  FacilityName From IQC_siteDetails ORDER By FacilityID";
                else
                    SQLString = "SELECT  FacilityName From PMT_0001a";

                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, SQLString, ClsUtility.ObjectEnum.DataTable, clsGbl.PMMSType);
                theDr = theDt.CreateDataReader();

                while (theDr.Read())
                { cboKELPTF.Items.Add(theDr["FacilityName"].ToString()); }
            }
            else
            {
                cboKELPTF.Items.Clear();
                cboKELPTF.Text = "";
                CboKECCC.Text = "";
                ChkKELPTF.Checked = OptKELPTF.Checked;
                ChkKECCC.Checked = OptKELPTF.Checked;
            }
            Cursor.Current = Cursors.Default;
        }

        private void ChkKELPTF_CheckedChanged(object sender, EventArgs e)
        {
            if (cboKELPTF.Text == "")
                ChkKELPTF.Checked = false;

            if (ChkKELPTF.Checked)
                ChkKECCC.Checked = false;
            CboKECCC.Text = "";

        }

        private void ChkKECCC_CheckedChanged(object sender, EventArgs e)
        {
            if (cboKELPTF.Text == "")
                ChkKECCC.Checked = false;

            if (ChkKECCC.Checked)
                ChkKELPTF.Checked = false;
            CboKECCC.Text = "";
        }

        private void cboKELPTF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKELPTF.Text != "")
                chkCCCs(true, CboKECCC, cboKELPTF);
        }

        private void optMAP_CheckedChanged(object sender, EventArgs e)
        {
            if (optMAP.Checked)
                TxtMA.Text = "7";
            else
                TxtMA.Text = "";
        }

        private void OptMA_CheckedChanged(object sender, EventArgs e)
        {
            if (OptMA.Checked)
                TxtMA.Text = "14";
            else
                TxtMA.Text = "";
        }

        private void cmdUgReports_Click(object sender, EventArgs e)
        {
            if ((chkUgCCC.Checked && CboUgCCC.Text == "") || (optUgLPTF.Checked && cboUgLPTF.Text == ""))
            { MessageBox.Show("Please select an LPTF/CCC to proceed"); return; }
            setLocale();
            Cursor.Current = Cursors.WaitCursor;
            if (txtSDate.Text != txtEDate.Text || clsGbl.IQDirection == "IQCare: mortality report")
            {
                ExcelReports ER = new ExcelReports();
                string currReport = getRadio(spUganda.Panel1).ToLower();
                if (currReport != "")
                {
                    clsGbl.IQDirection = currReport;
                    switch (currReport)
                    {
                        case "optug_cmr":
                            if (Params("CDC"))
                            { ER.UCR(htCategories, clsGbl.locType, cboUgLPTF.Text, CboUgCCC.Text, setCCCs(cboUgLPTF, chkUgLPTF), chkUgLPTF.Checked, this.prBUgandaReports); }
                            break;
                        case "optug_moh":
                            if (Params("CDC"))
                            { ER.UMoH(htCategories, clsGbl.locType, cboUgLPTF.Text, CboUgCCC.Text, setCCCs(cboUgLPTF, chkUgLPTF), chkUgLPTF.Checked, this.prBUgandaReports); }
                            break;
                    }
                }
                else MessageBox.Show("Please specify a report to generate!");
            }
            else MessageBox.Show("Please specify a start and end date to proceed");
            Cursor.Current = Cursors.Default;
        }

        private void cboUgLPTF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUgLPTF.Text != "")
                chkCCCs(true, CboUgCCC, cboUgLPTF);
        }

        private void chkUgLPTF_CheckedChanged(object sender, EventArgs e)
        {
            if (cboUgLPTF.Text == "")
                chkUgLPTF.Checked = false;
            if (chkUgLPTF.Checked)
                chkUgCCC.Checked = false;
            CboUgCCC.Text = "";
        }

        private void chkUgCCC_CheckedChanged(object sender, EventArgs e)
        {
            if (cboUgLPTF.Text == "")
                chkUgCCC.Checked = false;
            if (chkUgCCC.Checked)
                chkUgLPTF.Checked = false;
            CboUgCCC.Text = "";
        }

        private void optUgLPTF_CheckedChanged(object sender, EventArgs e)
        {
            //TODO CHRIS
            string SQLString;
            Cursor.Current = Cursors.WaitCursor;
            chkUgLPTF.Enabled = optUgLPTF.Checked;
            if (optUgLPTF.Checked)
            {
                // populate combo Ug LPTF

                Cursor.Current = Cursors.WaitCursor;
                theDt.Clear(); DataTableReader theDr;
                cboUgLPTF.Items.Clear(); cboUgLPTF.Text = "";
                if (clsGbl.PMMS.ToLower() == "iqcare")
                    SQLString = "SELECT  FacilityName From IQC_siteDetails ORDER By FacilityID";
                else
                    SQLString = "SELECT  FacilityName From PMT_0001a";

                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, SQLString, ClsUtility.ObjectEnum.DataTable, clsGbl.PMMSType);
                theDr = theDt.CreateDataReader();

                while (theDr.Read())
                { cboUgLPTF.Items.Add(theDr["FacilityName"].ToString()); }
            }
            else
            {
                cboUgLPTF.Items.Clear();
                cboUgLPTF.Text = "";
                CboUgCCC.Text = "";
                chkUgLPTF.Checked = optUgLPTF.Checked;
                chkUgCCC.Checked = optUgLPTF.Checked;
            }
            Cursor.Current = Cursors.Default;
        }        
               
        public static bool VersionAllowed(string Version, double MinVersion)
        {
            double ver = double.Parse(Version);
            if (ver >= MinVersion)
            {
                return true;
            }
            return false;
        }
  
     
           
        private string getSQL(string dfn, Hashtable ht, string QryName)
        {
            foreach (DictionaryEntry qk in clsGbl.mrgQueries)
            {
                if (qk.Key.ToString().ToLower().Trim() == QryName.Trim().ToLower())
                {
                    string QryRef = qk.Value.ToString() + "0000";
                    foreach (DictionaryEntry hk in ht)
                    {
                        if (hk.Key.ToString().Substring(0, 3).ToLower().Trim() == QryRef.ToLower().Trim().Substring(0, 3))
                            dfn = dfn.Replace(hk.Key.ToString().ToLower().Trim().Substring(3, hk.Key.ToString().Length - 3), "'" + hk.Value.ToString() + "'");
                    }

                }
            }
            return dfn;
        }              

        private void cmdTzDonor_Click(object sender, EventArgs e)
        {
            setLocale();
            Cursor.Current = Cursors.WaitCursor;
            if (txtSDate.Text != txtEDate.Text || clsGbl.IQDirection == "IQCare: mortality report")
            {
                ExcelReports ER = new ExcelReports();
                string currReport = getRadio(spTanzania.Panel1).ToLower();
                if (currReport != "")
                {
                    clsGbl.IQDirection = currReport;
                    switch (currReport)
                    {
                        case "opttzcsr":
                            if (Params("AIDSRelief"))
                            { ER.TzCSR(htCategories, "all", cboDonorLPTF.Text, cboDonorCCC.Text, setCCCs(cboDonorLPTF, chkDonorLPTF), chkDonorLPTF.Checked, this.prBTZReports); }
                            break;
                        case "optcdctanzania":
                            if (Params("CDC")) ER.CDCReport_Tanzania(htCategories, "all", cboTzLPTF.Text, cboTzCCC.Text, setCCCs(cboTzLPTF, chkTzLPTF), chkTzLPTF.Checked, this.prBTZReports);
                            break;
                        case "opttzapr":
                            if (Params("AIDSRelief"))
                            { ER.TzAPR( htCategories, "all", cboDonorLPTF.Text, cboDonorCCC.Text, setCCCs ( cboDonorLPTF, chkDonorLPTF ), chkDonorLPTF.Checked, this.prBTZReports ); }
                            break;
                       
                }
                    }
                else MessageBox.Show(Assets.Messages.Report1, Assets.Messages.ErrorHeader);
            }

            else MessageBox.Show(Assets.Messages.Report2, Assets.Messages.ErrorHeader);
            Cursor.Current = Cursors.Default;
        }

        private void cboClinical_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdClinical.Text = "Run";
        }

        private void cboComparisons_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdCmp.Text = "Run";
        }

        private void cboValidations_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdVals.Text = "Run";
        }

        private void cmdExcel_Click(object sender, EventArgs e)
        {
            //if (dgvQTool.DataSource != null)
            //{
            //    ExcelReports ER = new ExcelReports();
            //    try
            //    {
            //        ER.ExportExcel((DataTable)dgvQTool.DataSource, "C:\\Cohort\\ExcelExtracts\\IQTools.xls");
            //        System.Diagnostics.Process.Start("C:\\Cohort\\ExcelExtracts\\IQTools.xls");
            //    }
            //    catch
            //    { }
            //    Cursor.Current = Cursors.Default;
            //    return;
            //}
        }

        private void gbART_Enter(object sender, EventArgs e)
        {
            cmdART.Text = Assets.Messages.ViewReport;
        }

        private void OptKe_RC_CheckedChanged(object sender, EventArgs e)
        {
            chk_RCLineLists.Visible = OptKe_RC.Checked;
            chk_RCLineLists.Checked = false;
            OptKEAll.Checked = true;
            gbKenya.Enabled = !OptKe_RC.Checked;
        }

        private void cmdNigeriaDonor_Click(object sender, EventArgs e)
        {
            if ((chkNgCCC.Checked && cboNgCCC.Text == "") || (optNgLPTF.Checked && cboNgLPTF.Text == ""))
            { MessageBox.Show("Please select an LPTF/CCC to proceed"); return; }
            setLocale();
            Cursor.Current = Cursors.WaitCursor;
            if (txtSDate.Text != txtEDate.Text || clsGbl.IQDirection == "IQCare: mortality report")
            {
                ExcelReports ER = new ExcelReports();
                string currReport = getRadio(spNigeria.Panel1).ToLower();
                if (currReport != "")
                {
                    try
                    {
                        clsGbl.IQDirection = currReport;
                        switch (currReport)
                        {
                            case "optcdcnigeria":
                                if (Params("CDC")) ER.CDCReport_Nigeria(htCategories, clsGbl.locType, cboNgLPTF.Text, cboNgCCC.Text, setCCCs(cboNgLPTF, chkNgLPTF), chkNgLPTF.Checked, this.prBNigeriaReports);
                                break;
                            case "optmonthlynigeria":
                                if (Params("CDC")) ER.MonthlyReport_Nigeria(htCategories, clsGbl.locType, cboNgLPTF.Text, cboNgCCC.Text, setCCCs(cboNgLPTF, chkNgLPTF), chkNgLPTF.Checked, this.prBNigeriaReports);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "SQL query error");
                    }
                }
                else MessageBox.Show(Assets.Messages.Report1, Assets.Messages.ErrorHeader);
            }

            else MessageBox.Show(Assets.Messages.Report2, Assets.Messages.ErrorHeader);
            Cursor.Current = Cursors.Default;
        }

        private void optNgLPTF_CheckedChanged(object sender, EventArgs e)
        {
            string SQLString;
            Cursor.Current = Cursors.WaitCursor;
            chkNgLPTF.Enabled = optNgLPTF.Checked;
            if (optNgLPTF.Checked)
            {
                Cursor.Current = Cursors.WaitCursor;
                theDt.Clear(); DataTableReader theDr;
                cboNgLPTF.Items.Clear(); cboNgLPTF.Text = "";
                if (clsGbl.PMMS.ToLower() == "iqcare")
                    SQLString = "SELECT  FacilityName From IQC_siteDetails";
                else
                    SQLString = "SELECT  FacilityName From PMT_0001a";

                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, SQLString, ClsUtility.ObjectEnum.DataTable, clsGbl.PMMSType);
                theDr = theDt.CreateDataReader();

                while (theDr.Read())
                { cboNgLPTF.Items.Add(theDr["FacilityName"].ToString()); }
            }
            else
            {
                cboNgLPTF.Items.Clear();
                cboNgLPTF.Text = "";
                cboNgCCC.Text = "";
                chkNgLPTF.Checked = optNgLPTF.Checked;
                chkNgCCC.Checked = optNgLPTF.Checked;
            }
            Cursor.Current = Cursors.Default;
        }

        private void chkNgLPTF_CheckedChanged(object sender, EventArgs e)
        {
            if (cboNgLPTF.Text == "")
                chkNgLPTF.Checked = false;

            if (chkNgLPTF.Checked)
                chkNgCCC.Checked = false;
            cboNgCCC.Text = "";
        }

        private void cboNgLPTF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNgLPTF.Text != "")
                chkCCCs(true, cboNgCCC, cboNgLPTF);
        }

        private void chkNgCCC_CheckedChanged(object sender, EventArgs e)
        {
            if (cboNgLPTF.Text == "")
                chkNgCCC.Checked = false;

            if (chkNgCCC.Checked)
                chkNgLPTF.Checked = false;
            cboNgCCC.Text = "";
        }

        private void cmdHtReport_Click(object sender, EventArgs e)
        {
            setLocale();
            Cursor.Current = Cursors.WaitCursor;
            if (txtSDate.Text != txtEDate.Text || clsGbl.IQDirection == "IQCare: mortality report")
            {
                ExcelReports ER = new ExcelReports();
                string currReport = getRadio(spHaiti.Panel1).ToLower();
                if (currReport != "")
                {
                    try
                    {
                        clsGbl.IQDirection = currReport;
                        switch (currReport)
                        {
                            case "optht_monthly":
                                if (Params("CDC")) ER.MonthlyReport_Haiti(htCategories, clsGbl.locType, cboHt_LPTF.Text, cboHt_CCC.Text, setCCCs(cboHt_LPTF, chkHt_LPTF), chkHt_LPTF.Checked, this.prBHaitiReports);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "SQL query error");
                    }
                }
                else MessageBox.Show(Assets.Messages.Report1, Assets.Messages.ErrorHeader);
            }

            else MessageBox.Show(Assets.Messages.Report2, Assets.Messages.ErrorHeader);
            Cursor.Current = Cursors.Default;
        }       

        private void cboMainLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            BusinessLayer.clsGbl.cidi = (CultureInfoDisplayItem)cboMainLanguage.SelectedItem;
            Thread.CurrentThread.CurrentUICulture = BusinessLayer.clsGbl.cidi.CultureInfo;
            FormLanguageSwitchSingleton.Instance.ChangeLanguage(this, BusinessLayer.clsGbl.cidi.CultureInfo);
        }

        private void cboGenerateCReport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (txtSDate.Text != txtEDate.Text)
            {
                ExcelReports ER = new ExcelReports();
                if (cboCustomReport.Text != "")
                {
                    try
                    {
                        if (Params("AIDSRelief"))
                        {
                            // custom parameters added here
                            foreach (System.Windows.Forms.Control control in pnlCReportFilters.Controls)
                            {
                                if (control.GetType() == typeof(System.Windows.Forms.Label)) continue;
                                if (control.GetType() == typeof(System.Windows.Forms.DateTimePicker))
                                {
                                    DateTimePicker num = (DateTimePicker)control;

                                    htCategories.Add("@" + control.Name.TrimEnd("InputBox".ToCharArray()), num.Value);
                                }
                                else if (control.GetType() == typeof(System.Windows.Forms.TextBox))
                                {

                                    TextBox num = (TextBox)control;
                                    if (num.Text.Trim() == "")
                                    {
                                        MessageBox.Show("please specify " + control.Name.TrimEnd("InputBox".ToCharArray()), "Missing Value");
                                        Cursor.Current = Cursors.Default;
                                        return;
                                    }
                                    htCategories.Add("@" + control.Name.TrimEnd("InputBox".ToCharArray()), num.Text);
                                }
                                else if (control.GetType() == typeof(System.Windows.Forms.NumericUpDown))
                                {
                                    NumericUpDown num = (NumericUpDown)control;
                                    if (num.Value == 0)
                                    {
                                        MessageBox.Show("please specify " + control.Name.TrimEnd("InputBox".ToCharArray()), "Missing Value");
                                        Cursor.Current = Cursors.Default;
                                        return;
                                    }
                                    htCategories.Add("@" + control.Name.TrimEnd("InputBox".ToCharArray()), num.Value);
                                }
                            }
                            ER.CustomReport(htCategories, cboCustomReport.Text, setCCCs(cboDonorLPTF, chkDonorLPTF), false);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else MessageBox.Show("Please specify a report to generate!");
            }
            else MessageBox.Show("Please specify a start and end date to proceed");
            Cursor.Current = Cursors.Default;
        }

        private void cboCustomReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            addCustomFilterGUI(cboCustomReport.Text);
        }

        private void addCustomFilterGUI(string reportName)
        {
            String filterName = "customInput";
            int y = 0;
            //get filters for selected report
            DataTable dt = new DataTable();
            dt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
                   "SELECT parID, parName, parType" +
                    " FROM  aa_parameter JOIN aa_CustomReports On aa_CustomReports.reportid=aa_parameter.ReportID where ReportName = '" + reportName +
                    "' and (aa_parameter.Deleteflag <>1 or aa_parameter.deleteflag is null)",
                    ClsUtility.ObjectEnum.DataTable, serverType);
            pnlCReportFilters.Controls.Clear();
            foreach (DataRow row in dt.Rows)
            {

                String[] filters = { row[1].ToString(), row[2].ToString() };
                filterName = row[1].ToString();

                //Add Label
                System.Windows.Forms.Label lb = new System.Windows.Forms.Label();

                lb.AutoSize = false;
                lb.Location = new System.Drawing.Point(5, 10 + y);
                lb.Name = filterName + "customLabel";
                lb.Text = filterName;
                lb.Visible = true;
                lb.Size = new System.Drawing.Size(200, 20);

                pnlCReportFilters.Controls.Add(lb);

                if (row[2].ToString() == "Date")
                {
                    System.Windows.Forms.DateTimePicker dtp = new System.Windows.Forms.DateTimePicker();

                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "yyyy-MM-dd";
                    dtp.Name = filterName + "InputBox";
                    dtp.Location = new System.Drawing.Point(10, 30 + y);
                    dtp.Size = new System.Drawing.Size(100, 20);
                    dtp.Visible = true;
                    pnlCReportFilters.Controls.Add(dtp);
                }
                else if (row[2].ToString() == "Number")
                {
                    System.Windows.Forms.NumericUpDown num = new System.Windows.Forms.NumericUpDown();
                    num.Name = filterName + "InputBox";
                    num.Location = new System.Drawing.Point(10, 30 + y);
                    num.Size = new System.Drawing.Size(100, 20);
                    num.Visible = true;
                    pnlCReportFilters.Controls.Add(num);
                }
                else
                {
                    System.Windows.Forms.TextBox tb = new System.Windows.Forms.TextBox();
                    tb.Name = filterName + "InputBox";
                    tb.Location = new System.Drawing.Point(10, 30 + y);
                    tb.Size = new System.Drawing.Size(100, 20);
                    tb.Visible = true;
                    pnlCReportFilters.Controls.Add(tb);
                }
                y += 45;
            }
        }

        private void cmdCReportNew_Click(object sender, EventArgs e)
        {            
            resetCustomReportScreen();
        }

        private void resetCustomReportScreen()
        {
            lblCReportId.Text = "0";
            txtCReportDesc.Text = "";
            txtCReportName.Text = "";
            cboCReportCategory.SelectedIndex = -1;
            lstCReportsFilter.Items.Clear();
            chkDeleteCReport.Checked = false;
            txtCReportTemplate.Text = "";
        }

        private void refreshCustomReportsGrid()
        {
            theDt.Clear();
            dgvCReports.DataSource = null;
            theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
                   "SELECT CR.ReportID, category.Category, CR.ReportName, CR.ReportDescription, CR.DeleteFlag" +
                    " FROM  aa_CustomReports AS CR INNER JOIN  aa_Category AS category ON CR.catID = category.catID",
                    ClsUtility.ObjectEnum.DataTable, serverType);
            dgvCReports.DataSource = theDt;
            dgvCReports.Refresh();
        }

        private void cmdCReportTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Excel 97-2003 Workbook|*.xls";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtCReportTemplate.Text = fd.FileName;
            }
        }

        private void cmdAddRemoveFilter_Click(object sender, EventArgs e)
        {
            if (txtCReportFilterName.Text.Trim() == "" | cboCReportFilterType.Text.Trim() == "")
            {
                MessageBox.Show("Please ensure that the filter name and type are specified", "IQTools Custom Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String[] filters = { txtCReportFilterName.Text.Trim(), cboCReportFilterType.Text.Trim() };

            ListViewItem filter = new ListViewItem(filters);
            lstCReportsFilter.Items.Add(filter);
            txtCReportFilterName.Text = "";
            cboCReportFilterType.SelectedIndex = -1;
        }

        Boolean updateReport = false;

        private void cmdCReportSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (txtCReportName.Text.Trim() == "" | cboCReportCategory.Text.Trim() == "" | txtCReportTemplate.Text.Trim() == "")
            {
                MessageBox.Show("Please ensure that the Excel Template,Report name and category are specified", "IQTools Custom Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ClsUtility.Init_Hashtable();
                if (txtCReportTemplate.Text != "--Browse to update existing template--")
                {
                    System.IO.File.Copy(txtCReportTemplate.Text, clsGbl.tmpFolder + txtCReportName.Text.Trim() + " Template.xls", true);
                    System.IO.File.SetAttributes(clsGbl.tmpFolder + txtCReportName.Text.Trim() + " Template.xls", FileAttributes.Hidden);
                }
                if (updateReport)
                {
                    i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
                        "UPDATE aa_CustomReports SET ReportName='" + txtCReportName.Text.Trim() + "', ReportDescription='" + txtCReportDesc.Text.Trim() +
                        "', UpdateDate=GetDate(), DeleteFlag='" +
                        chkDeleteCReport.Checked + "' WHERE ReportID=" + lblCReportId.Text,
                        ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                    saveFilters(txtCReportName.Text.Trim());
                    if (i > 0)
                    {
                        resetCustomReportScreen();
                        updateReport = false;
                    }
                }
                else
                {
                    i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
                        "INSERT INTO aa_CustomReports(catID, ReportName, ReportDescription) " +
                        "Select TOP 1 CatID,'" + txtCReportName.Text.Trim() + "','" + txtCReportDesc.Text.Trim() + 
                        "' from aa_Category where Category = '" + cboCReportCategory.Text + "'", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                    saveFilters(txtCReportName.Text.Trim());
                    if (i > 0) resetCustomReportScreen();
                }
                refreshCustomReportsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n " + ex.StackTrace);
            }
        }

        private void saveFilters(string reportName)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(Entity.getconnString(clsGbl.xmlPath));
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            cmd.CommandText = "Select ReportID from aa_CustomReports where ReportName='" + reportName + "'";
            int reportID = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();
            int i = 0;
            long filterId;
            foreach (ListViewItem item in lstCReportsFilter.Items)
            {
                filterId = 0;
                if (item.Tag != null) filterId = (long)item.Tag;

                i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
                        "UPDATE aa_parameter SET parName='" + item.SubItems[0].Text + "', parType='" + item.SubItems[1].Text +
                        "', UpdateDate=GetDate() WHERE parId=" + filterId,
                        ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                if (i > 0) continue;

                i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
              "INSERT INTO aa_parameter(parName, ReportID, parType,CreateDate) Values ('" +
              item.SubItems[0].Text + "','" + reportID + "','" + item.SubItems[1].Text + "', getDate())", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);


            }

        }

        private void loadCustomReportFilters(Int32 reportID)
        {
            lstCReportsFilter.Items.Clear();
            DataTable dt = new DataTable();
            dt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
                   "SELECT parID, parName, parType" +
                    " FROM  aa_parameter where reportID = " + reportID + " and (Deleteflag <>1 or deleteflag is null)",
                    ClsUtility.ObjectEnum.DataTable, serverType);
            foreach (DataRow row in dt.Rows)
            {
                String[] filters = { row[1].ToString(), row[2].ToString() };

                ListViewItem filter = new ListViewItem(filters);

                filter.Tag = row[0];
                lstCReportsFilter.Items.Add(filter);

            }
        }

        private void dgvCReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCReports_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCReports.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCReports.SelectedRows[0];
                // dgvCReports.CurrentRow
                if (row != null)
                {
                    //SELECT CR.ReportID, category.Category, CR.ReportName, CR.ReportDescription, CR.DeleteFlag
                    lblCReportId.Text = "" + (int)row.Cells[0].Value;
                    cboCReportCategory.Text = (String)row.Cells[1].Value;
                    txtCReportName.Text = (String)row.Cells[2].Value;
                    txtCReportDesc.Text = (String)row.Cells[3].Value;
                    chkDeleteCReport.Checked = (Boolean)row.Cells[4].Value;
                    txtCReportTemplate.Text = "--Browse to update existing template--";
                    loadCustomReportFilters((Int32)row.Cells[0].Value);

                    updateReport = true;
                    //  row.Cells[0].Value;

                }
            }
        }

        private void tcDonors_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tpDonorCustomReport)
            {

                cboCustomReport.Items.Clear();
                theDt.Clear();
                DataTableReader theDr;

                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , "SELECT DISTINCT ReportName FROM aa_CustomReports WHERE DeleteFlag=0 Or DeleteFlag Is Null", ClsUtility.ObjectEnum.DataTable, serverType);
                theDr = theDt.CreateDataReader();
                while (theDr.Read())
                {
                    cboCustomReport.Items.Add(theDr["ReportName"].ToString());
                }
            }
            //TODO CHRIS 

        }

        private void eventMetadataProvider1_ExecSQL(BaseMetadataProvider metadataProvider, string sql, bool schemaOnly, out IDataReader dataReader)
        {
            dataReader = null;
            SqlConnection cnn = new SqlConnection();
            MySqlConnection myCnn = new MySqlConnection();
            if (clsGbl.PMMSType.ToLower() == serverType)
            {
                cnn = new SqlConnection(Entity.getconnString(clsGbl.xmlPath));
            }
            else if (clsGbl.PMMSType.ToLower() == "mysql")
            {
                myCnn = (MySqlConnection)Entity.getdbConn((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), serverType), "iqtools");
            }

            try
            {
                if (cnn != null && clsGbl.PMMSType.ToLower() == serverType)
                {
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    IDbCommand command = cnn.CreateCommand();
                    command.CommandText = sql;
                    dataReader = command.ExecuteReader();
                }
            }
            catch { }
        }

        private void tcCountries_Selected(object sender, TabControlEventArgs e)
        {
            //TODO RESET Progress Bars if at 100%
            if (prBKeReports.Value == 100)
                prBKeReports.Value = 0;
        }

        private void dgvClinical_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvClinical.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                string link = this.dgvClinical[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (link != String.Empty)
                {
                    clsGbl.EMRPatientPK = link;
                    tcMain.SelectedTab = tpEMRAccess;
                }
            }
        }

        private void dgvComparisons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvComparisons.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                String FacilityID = "";
                String IQCareURL = "";
                String link = this.dgvComparisons[e.ColumnIndex, e.RowIndex].Value.ToString();

                DataRow theDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , "SELECT FacilityID FROM tmp_PatientMaster WHERE PatientPK = " + link + "", ClsUtility.ObjectEnum.DataRow, serverType);
                FacilityID = theDr["FacilityID"].ToString().Trim();

                IQCareURL = GetIQCareURL(FacilityID, link);

                System.Diagnostics.Process.Start(IQCareURL);
            }
        }

        private void dgvValidations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvValidations.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                String FacilityID = "";
                String IQCareURL = "";
                String link = this.dgvValidations[e.ColumnIndex, e.RowIndex].Value.ToString();

                DataRow theDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , "SELECT FacilityID FROM tmp_PatientMaster WHERE PatientPK = " + link + "", ClsUtility.ObjectEnum.DataRow, serverType);
                FacilityID = theDr["FacilityID"].ToString().Trim();

                IQCareURL = GetIQCareURL(FacilityID, link);

                System.Diagnostics.Process.Start(IQCareURL);
            }
        }

        private void UpdateProgress ( int p )
        {
          if (InvokeRequired)
          { this.Invoke ( new MethodInvoker ( delegate { prbLoad.Value = p; } ) ); }
        }

        private void optKE_PS_CheckedChanged(object sender, EventArgs e)
        {
            txtPatientID.Enabled = optKE_PS.Checked;
            cmdMultipleSummaries.Enabled = optKE_PS.Checked;
        }

        private void OptKe_MoH711_CheckedChanged(object sender, EventArgs e)
        {
            chk_KESendToDHIS.Enabled = OptKe_MoH711.Checked;
        }

        private void cmdMultipleSummaries_Click(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = Entity.getconnString(clsGbl.xmlPath);

            BusinessLayer.clsGbl.PatientIDs = new List<string>();

            frmBulkPatientSummaries selectPatientIDs = new frmBulkPatientSummaries(myConn.ConnectionString);
            selectPatientIDs.ShowDialog();

            //Generate bulk reports
            if (BusinessLayer.clsGbl.PatientIDs.Count > 0)
            {
                ER = new ExcelReports();

                Thread reportRunner = new Thread(() => ER.PatientSummaryBulk(BusinessLayer.clsGbl.PatientIDs, this.prBKeReports));
                reportRunner.SetApartmentState(ApartmentState.STA);
                try
                {
                    reportRunner.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.Cursor = Cursors.Default;
            }
        }

        private void optARTCohort_CheckedChanged(object sender, EventArgs e)
        {
            gbCommon.Enabled = !optARTCohort.Checked;
            flpCohortReport.Enabled = optARTCohort.Checked;
            chkCohortReportLL.Enabled = optARTCohort.Checked;
        }

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            if (txtPatientID.Text.Length > 0)
            {
                cmdMultipleSummaries.Enabled = false;
            }
            else
            {
                cmdMultipleSummaries.Enabled = true;
            }
        }

        private void getQueryParameters(string querySQL)
        {
            QueryBuilder qb = new QueryBuilder();
            if (serverType == "mssql")
            {
                MSSQLSyntaxProvider syntaxProvider = new MSSQLSyntaxProvider();
                qb.SyntaxProvider = syntaxProvider;
                qb.SQL = querySQL;

                SqlCommand cmd = new SqlCommand(querySQL);                
                if (qb.Parameters.Count > 0)
                {
                    Hashtable myParameters = new Hashtable(); 
                    int j = 0; myParameters.Clear();
                    //ParameterList pl;
                    for (int i = 0; i < qb.Parameters.Count; i++)
                    {
                        j = 0;
                        SqlParameter p = new SqlParameter();
                        p.ParameterName = qb.Parameters[i].Name;
                        p.DbType = qb.Parameters[i].DataType;
                        foreach (DictionaryEntry de in myParameters)
                        {
                            if (de.Key.ToString().Trim().ToLower() == qb.Parameters[i].Name.Trim().ToLower())
                            {
                                j = 1;
                                break;
                            }
                        }
                        if (j == 0)
                        {
                            myParameters.Add(p.ParameterName, p.DbType);                            
                        }
                    }

                    using (frmQueryParameters qp = new frmQueryParameters(qb.Parameters, cmd))
                    {
                        qp.StartPosition = FormStartPosition.CenterScreen;
                        qp.ShowDialog();
                    }
                }
            }
            
            else if (serverType == "pgsql")
            {
                PostgreSQLSyntaxProvider syntaxProvider = new PostgreSQLSyntaxProvider();
                qb.SyntaxProvider = syntaxProvider;
                qb.SQL = querySQL;  
                NpgsqlCommand cmd = new NpgsqlCommand(querySQL);

                if (qb.Parameters.Count > 0)
                {
                    Hashtable myParameters = new Hashtable(); int j = 0; myParameters.Clear();
                    for (int i = 0; i < qb.Parameters.Count; i++)
                    {
                        j = 0;

                        NpgsqlParameter p = new NpgsqlParameter();
                        p.ParameterName = qb.Parameters[i].FullName;
                        p.DbType = qb.Parameters[i].DataType;
                        foreach (DictionaryEntry de in myParameters)
                        {
                            if (de.Key.ToString().Trim().ToLower() == qb.Parameters[i].FullName.Trim().ToLower())
                            {
                                j = 1;
                                break;
                            }
                        }
                        if (j == 0)
                        {
                            cmd.Parameters.Add(p);
                            myParameters.Add(p.ParameterName, p.DbType);
                        }
                    }

                    using (frmQueryParameters qp = new frmQueryParameters(qb.Parameters, cmd))
                    {
                        qp.StartPosition = FormStartPosition.CenterScreen;
                        qp.ShowDialog();
                    }
                }
            }

        }

        private void homeScreenOption_Changed(object sender, EventArgs e)
        {
            cmdART.Text = Assets.Messages.ViewReport;
        }

        private void txtDate_DoubleClick(object sender, EventArgs e)
        {
            runRemoteServices();
        }
        
        private void setDB ( bool Access)
        {
          string connString = PMTest ( Access, pmmsType ( cboServerType.Text.ToLower ( ) ) );

          int i;
          if (connString != "")
          {

            if (connString == "1")
            {
              EMRDB = "";
              return;
            }
            else if (connString == "MyAlert")
            {
              EMRDB = "";
              return;
            }
            Entity theObject = new Entity ( ); ClsUtility.Init_Hashtable ( );
            i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                            , "UPDATE aa_Database SET "
                                            + "IPAddress = '" + EMRIPAddress + "', "
                                            + "DBase = '" + EMRDB + "',  connString='"
                                            + ClsUtility.Encrypt ( connString ) + "', PMMSType = '" + pmmsType ( cboServerTypeText )
                                            + "', IQStatus='No Data', UpdateDate=Null, PMMS = '" + MS_ACCESS_PMMS.ToLower ( ) + "',EMRVersion = '"
                                            + clsGbl.EmrVersion + "' WHERE DBName='IQTools'"
                                            , ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );

            if (i == 0)
              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                  , "INSERT INTO aa_Database(DBName,IPAddress, DBase, Server, ConnString, PMMSType, IQStatus, UpdateDate, PMMS,EMRVersion) " +
                  "VALUES('IQTools','" + EMRIPAddress + "','" + EMRDB + "', '" + " " +
                   "', '" + ClsUtility.Encrypt ( connString ) + "', '" + pmmsType ( cboServerTypeText ) + "', 'No data', Null, '" +
                   MS_ACCESS_PMMS.ToLower ( ) + "','" + clsGbl.EmrVersion + "')", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );

            clsGbl.currServer = "";
            clsGbl.currData = EMRDB;
          }
          else
          {
            if (x != 1) MessageBox.Show ( "A Connection was not established to the connected database, please try again", "PMMS Connection" );
            return;
          }

        }
         
        private void cmdPMMS_Click ( object sender, EventArgs e )
        {
          clsGbl.tblRefresh = "true";

          if (txtUID.Text == "" || txtPWD.Text == "")
          {
           MessageBox.Show(Assets.Messages.MissingCredentials, Assets.Messages.InfoHeader
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
           return;
          }

          if (Path.GetExtension ( cboDBase.Text ) != ".mdb" )
          {
            MessageBox.Show ( Assets.Messages.Access, Assets.Messages.InfoHeader
                       , MessageBoxButtons.OK, MessageBoxIcon.Information );
            return;
          }
          string selectedFacility = "";
          bool validateUser = false;
          if (String.IsNullOrEmpty ( cboServerType.Text )) 
              cboServerType.Text = STR_MicrosoftAccess;
              EMRUser = txtUID.Text;
              EMRPass = txtPWD.Text;
              EMRIPAddress = "localhost";
              EMRDB = cboDBase.Text.Trim ( ).ToLower ( );
              clsGbl.DBState = "No data";
              bool AccessDB;
              ClsUtility.Init_Hashtable ( );
             // int i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams, "UPDATE aa_database set IQStatus='Loading' DBase="+EMRDB+" UpdateDate=getDate()", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
              AccessDB = !cboServerType.Text.Trim ( ).ToLower ( ).EndsWith ( "server" );
              try
              {
                setDB ( AccessDB );
              }
              catch (Exception ex)
              {
                MessageBox.Show ( ex.Message);
              }
              frmLogin _frmLogin = new frmLogin ( );
              validateUser =_frmLogin.loginEMR (MS_ACCESS_PMMS.ToLower(), EMRUser, EMRPass, selectedFacility );
              _frmLogin.Close ( );

              try
              {
                if (validateUser)
                {
                  Thread  loadDatasetThread = new Thread ( ( ) => SetDatabase ( AccessDB ));
                  loadDatasetThread.SetApartmentState ( ApartmentState.STA );
                  loadDatasetThread.Start ( );
               
                }
              }
              catch (Exception ex) { 
                SetControlPropertyThreadSafe ( lblNotify, "Text", ex.Message );
                SetControlPropertyThreadSafe ( picProgress, "Image", null);
                SetControlPropertyThreadSafe ( cmdPMMS, "Enabled", false );
                SetControlPropertyThreadSafe ( txtUID, "ReadOnly", false );
                SetControlPropertyThreadSafe ( txtPWD, "ReadOnly", false );
              }
             
              
        }

        private string PMTest(bool dbAccess, string pmmsType)
        {
        //  SetControlPropertyThreadSafe ( cboDBase, "Text", cboDBase.Text );
         // SetControlPropertyThreadSafe ( cboPMMS, "Text", cboPMMS.Text );
    
          if (cboDBase.InvokeRequired)
          {
            cboDBase.Invoke ( new MethodInvoker ( delegate {cboDatabaseText = cboDBase.Text; } ) );
          }
          else
          {
            cboDatabaseText = cboDBase.Text;
          }

           cboPMMSText = MS_ACCESS_PMMS;
         
       
            string connString = "";
      
                if (dbAccess)
                {
                    string connectionString = Entity.getconnString(clsGbl.xmlPath);
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand command = conn.CreateCommand();
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT ID, Version, Password FROM aa_DataFilePasswords";
                        SqlDataReader reader = command.ExecuteReader();
                        using (DataTable dataFilePasswordsDataTable = new DataTable())
                        {
                            dataFilePasswordsDataTable.Load(reader);
                            try
                            {
                                        foreach (DataRow row in dataFilePasswordsDataTable.Rows)
                                        {
                                            string cipherTextPassword = row["Password"].ToString();
                                            string plainTextPassword = ClsUtility.Decrypt(cipherTextPassword);
                                            // connString = String.Format(connTemplate, cboDBase.Text, plainTextPassword);
                                            connString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;  Data Source= {0} ;Jet OLEDB:Database Password={1};Persist Security Info=False;", cboDatabaseText, plainTextPassword);
                                            //connString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;  Data Source= {0} ;Jet OLEDB:Database Password={1};Persist Security Info=False;", cboDBase.Text, plainTextPassword);
                                            try
                                            {
                                                OleDbConnection connection = new OleDbConnection(connString);
                                                connection.Open();
                                                AccessExtracts data = new AccessExtracts();

                                                foreach (string s in TABLE_NAMES)       //gets the EMR Version
                                                {
                                                    clsGbl.EmrVersion = data.DetermineCTCVersion(s, connection);
                                                    break;
                                                }
                                                connection.Close();
                                                connection.Dispose();
                                                return connString;
                                            }
                                            catch (Exception ex)
                                            {
                                                try
                                                {
                                                    OleDbException oleDbEx = (OleDbException)ex;
                                                    if (oleDbEx.ErrorCode == -2147467259)
                                                        throw ex; // Unknown format.
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                    }
               
                            catch
                            {
                                try
                                {
                                    
                                    
                                            //string connTemplate = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0};Jet OLEDB:Database Password={1};Persist Security Info=False;";
                                            foreach (DataRow row in dataFilePasswordsDataTable.Rows)
                                            {
                                                string cipherTextPassword = row["Password"].ToString();
                                                string plainTextPassword = ClsUtility.Decrypt(cipherTextPassword);
                                                //   connString = String.Format(connTemplate, cboDBase.Text, plainTextPassword);
                                                connString = "Provider=Microsoft.ACE.OLEDB.12.0;  Data Source= " + cboDBase.Text + " ;Jet OLEDB:Database Password=" + plainTextPassword + ";Persist Security Info=False;";
                                                try
                                                {
                                                    OleDbConnection connection = new OleDbConnection(connString);
                                                    connection.Open();
                                                    connection.Close();
                                                    connection.Dispose();
                                                    return connString;
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                       
                                catch
                                {
                                    return "";
                                }
                            }
                        }
                    }


                }
            
                try
                {
                    if (dbAccess)
                    {
                        System.Data.OleDb.OleDbConnection cnn = new System.Data.OleDb.OleDbConnection(connString);
                        cnn.Open(); cnn.Close(); cnn.Dispose();
                    }
                    else
                        Entity.GetConnection(connString, pmmsType);
                    return connString;
                }
                catch
                { return ""; }
            }
        
        private void SetDatabase ( bool Access )

            {
              SetControlPropertyThreadSafe ( picProgress, "Image", Properties.Resources.progressWheel5 );
              SetControlPropertyThreadSafe ( lblNotify, "Text", "Uploading Dataset..." );
              SetControlPropertyThreadSafe ( cmdPMMS, "Enabled", false );
              SetControlPropertyThreadSafe ( txtUID, "ReadOnly", true );
              SetControlPropertyThreadSafe ( txtPWD, "ReadOnly", true );
              SetControlPropertyThreadSafe ( prbLoad, "Visible", true );

              if (cboServerType.InvokeRequired)
              {
                cboDBase.Invoke ( new MethodInvoker ( delegate { cboServerTypeText = cboServerType.Text.ToLower ( ); } ) );
              }
              else
              {
                cboServerTypeText = cboServerType.Text.ToLower();
              }


                int i;
                DataRow theDr;
                if (serverType == "mysql")
                {
                  string SQL_MYSQL = "SELECT  PMMSType, PMMS, EMRVersion From aa_Database  LIMIT 1";
                  theDr = (DataRow)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                  , SQL_MYSQL, ClsUtility.ObjectEnum.DataRow, serverType );
                  clsGbl.PMMSType = serverType;
                  clsGbl.PMMS = theDr["PMMS"].ToString ( );
                  clsGbl.EmrVersion = theDr["EMRVersion"].ToString ( );
                  
                }
                else
                {
                  string SQL = "SELECT Top 1 PMMSType, PMMS, EMRVersion, IPAddress From aa_Database";
                  theDr = (DataRow)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                              , SQL, ClsUtility.ObjectEnum.DataRow, serverType );
                  clsGbl.PMMSType = serverType;
                  clsGbl.PMMS = theDr["PMMS"].ToString ( );
                  clsGbl.EmrVersion = theDr["EMRVersion"].ToString ( );
                  clsGbl.EMRIPAddress = theDr["IPAddress"].ToString();
                }
              
                #region DatabaseUpgrade
                // TODO: Need to rethink this
                //if (!versionSynchronized())
                //{
                //    MessageBox.Show(Messages.UpdateDatabase, Messages.InfoHeader);
                //    updateDatabase();
                //    //Force Refresh on Version Conflict
                //    clsGbl.IQDirection = "New load";
                //    clsGbl.tblRefresh = "true";
                //}

                #endregion
                    #region notMySQL
                    if (serverType != "mysql")
                    {
                        if (clsGbl.tblRefresh.ToLower() == "true" && Entity.getRefreshRights(BusinessLayer.clsGbl.xmlPath).ToLower() == "yes")
                        {
                            Assets.UtFunctions theDB = new Assets.UtFunctions();
                            if (!theDB.clrIQTables ( theDB.chkAccessDB ( Entity.getdbConnString ( (SqlConnection)Entity.GetConnection ( Entity.getconnString ( clsGbl.xmlPath ), "mssql" ), "IQTools" ) ), "" )
                                                        || !theDB.crtIQTables ( theDB.chkAccessDB ( Entity.getdbConnString ( (SqlConnection)Entity.GetConnection ( Entity.getconnString ( clsGbl.xmlPath ), "mssql" ), "IQTools" ) ), "", this.prbLoad ))
                                                        
                            {
                                MessageBox.Show("There Was A Problem Accessing The EMR Database, Data May Not Have Been Loaded Into IQTools"
                                                    , "IQTools Connection Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                clsGbl.IQDirection = "connect";
                            }

                            else if (clsGbl.IQDirection.ToLower() != "setusers")
                            {
                                Cursor.Current = Cursors.WaitCursor;

                               

                                #endregion

                                ClsUtility.Init_Hashtable();
                                try
                                {
                                    DataRow fDr = null;
                             

                                    #region CreateBaseTables
                                       
                                    if (clsGbl.PMMS.ToLower() == "iqcare" || clsGbl.PMMS.ToLower() == "ctc2" || clsGbl.PMMS.ToLower() == "smartcare")
                                    {
                                        if (clsGbl.PMMS.ToLower() == "iqcare")
                                        {
                                            ClsUtility.AddParameters("@FacilityName", SqlDbType.Text, fDr[0].ToString());
                                            ClsUtility.AddParameters("@EMR", SqlDbType.Text, "iqcare");
                                            ClsUtility.AddParameters("@EMRVersion", SqlDbType.Text, clsGbl.EmrVersion);
                                        }
                                        else if (clsGbl.PMMS.ToLower() == "ctc2")
                                        {
                                            ClsUtility.AddParameters("@FacilityName", SqlDbType.Text, "");
                                            ClsUtility.AddParameters("@EMR", SqlDbType.Text, "ctc2");
                                            ClsUtility.AddParameters("@EMRVersion", SqlDbType.Text, clsGbl.EmrVersion);
                                        }
                                        else if (clsGbl.PMMS.ToLower() == "smartcare")
                                        {
                                            ClsUtility.AddParameters("@FacilityName", SqlDbType.Text, "");
                                            ClsUtility.AddParameters("@EMR", SqlDbType.Text, "smartcare");
                                            ClsUtility.AddParameters("@EMRVersion", SqlDbType.Text, clsGbl.EmrVersion);
                                        }
                                            ClsUtility.AddParameters("@VisitPK", SqlDbType.Int, 0);
                                            ClsUtility.AddParameters("@PatientPK", SqlDbType.Int, 0);

                                            try
                                            {
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreateSiteDetails_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 10 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreatePatientMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 20 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreatePharmacyMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 30 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreateClinicalEncountersMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 40 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreateLastStatusMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }

                                            try
                                            {
                                              UpdateProgress ( 50 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreateARTPatientsMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 60 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreateLabMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 70 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreatePregnanciesMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 80 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreateOIsMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 85 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreateTBPatientsMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 90 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreateHEIMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 95 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreateANCMothersMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 100 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreateFamilyInfoMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 100 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreateIQToolsViews_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            try
                                            {
                                              UpdateProgress ( 100 );
                                              i = (int)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                                                  , "pr_CreateLastReportStatusMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql" );
                                            }
                                            catch (Exception ex) { MessageBox.Show ( ex.Message ); }
                                            //}
                                            ClsUtility.Init_Hashtable ( );


                                    }
                                    #endregion
                                
                                    clsGbl.IQDirection = "main";
                                }
                                catch (Exception ex)
                                {
                                  EH.LogError ( ex.Message, "<<frmMain:SetDatabase()>>", serverType );
                                    clsGbl.IQDirection = "connect";
                                }
                            }

                        }
                    }
                    string myComText = "";
                    if (clsGbl.PMMSType == "mysql")
                      myComText = "SELECT FacilityName From IQC_SiteDetails LIMIT 1";
                    else if (clsGbl.PMMS.ToLower ( ) == "smartcare" || clsGbl.PMMS.ToLower ( ) == "ctc2")
                      myComText = "SELECT TOP 1 FacilityName From IQC_SiteDetails ORDER BY FacilityID";
                    DataRow dr;
                    ClsUtility.Init_Hashtable ( );
                    dr = (DataRow)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                        , myComText, ClsUtility.ObjectEnum.DataRow, serverType );
               
                    SetControlPropertyThreadSafe (  this, "Text", "IQTools | " + dr["FacilityName"].ToString ( ).Trim ( ));
                    SetControlPropertyThreadSafe ( picProgress, "Image", null );
                    SetControlPropertyThreadSafe ( lblNotify, "Text", "Done" );
                    SetControlPropertyThreadSafe ( cmdPMMS, "Enabled", true );
                    SetControlPropertyThreadSafe ( txtUID, "ReadOnly", false );
                    SetControlPropertyThreadSafe ( txtPWD, "ReadOnly", false );
                    SetControlPropertyThreadSafe ( txtUID, "Text", "" );
                    SetControlPropertyThreadSafe ( txtPWD, "Text", "" );
                    SetControlPropertyThreadSafe ( cboDBase, "Text", "" );
                    SetControlPropertyThreadSafe ( prbLoad, "Visible", false );
                    SetControlPropertyThreadSafe ( prbLoad, "Value", 0 );

                    MessageBox.Show ( "The PMMS Connection Has Been Successfully Updated", "PMMS" );
                    }

        private void cmdDBLoad_Click ( object sender, EventArgs e )
           {
             if (!cboServerType.Text.Trim ( ).ToLower ( ).EndsWith ( "server" ))
             {
               ofdUtility.Filter = "Access Database|*.mdb|All files|*.*";
               ofdUtility.InitialDirectory = @"C:\";
               ofdUtility.Title = "Please select an access file";

               if (ofdUtility.ShowDialog ( ) == DialogResult.OK)
               {
                 if (ofdUtility.FileName != "")
                 {
                   cboDBase.Text = ofdUtility.FileName;
                 }
               }
               else
               {
                 MessageBox.Show ( "Please select a file" );
                 return;
               }
             }


           }

        private void tcMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                tcMain.Appearance = TabAppearance.Normal;
                
                //This line of code will help you to change the apperance like size,name,style.
                Font f;
                //For background color
                Brush backBrush;
                //For forground color
                Brush foreBrush;

                //This construct will hell you to deside which tab page have current focus
                //to change the style.
                if (e.Index == this.tcMain.SelectedIndex)
                {
                    //This line of code will help you to change the apperance like size,name,style.
                    f = new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                    f = new Font(e.Font, FontStyle.Bold);

                    backBrush = new System.Drawing.SolidBrush(Color.AliceBlue);
                    foreBrush = Brushes.Blue;
                    tcMain.SelectedTab.BackColor = Color.AliceBlue;
                    tcMain.SelectedTab.BorderStyle = BorderStyle.None;
                }
                else
                {
                    f = e.Font;
                    backBrush = new System.Drawing.SolidBrush(Color.AliceBlue);//new SolidBrush(e.BackColor);
                    foreBrush = new SolidBrush(e.ForeColor);
                    tcMain.SelectedTab.BorderStyle = BorderStyle.None;
                }

                //To set the alignment of the caption.
                string tabName = this.tcMain.TabPages[e.Index].Text;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;

                //Thsi will help you to fill the interior portion of
                //selected tabpage.
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                Rectangle r = e.Bounds;
                //r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
                r = new Rectangle(r.X, r.Y, r.Width, r.Height);
                e.Graphics.DrawString(tabName, f, foreBrush, r, sf);

                sf.Dispose();
                if (e.Index == this.tcMain.SelectedIndex)
                {
                    f.Dispose();
                    backBrush.Dispose();
                }
                else
                {
                    backBrush.Dispose();
                    foreBrush.Dispose();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
			

        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chk_KESendToDHIS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void optKe_MoH731_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtSDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboCReportCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    
    }
}