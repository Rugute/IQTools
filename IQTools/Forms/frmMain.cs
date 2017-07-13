using System;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using BusinessLayer;
using DataLayer;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Windows.Forms;
using System.Reflection;
using ActiveDatabaseSoftware.ActiveQueryBuilder;
using System.Net;
using IQTools.UserControls;
//using IQTools.RemoteWebService;

namespace IQTools
{
    public delegate void SettingsEventHandler(object sender, EventArgs e);

    public delegate void formUpdateFunctionType(object message);

    public partial class frmMain : Form
    {
        ExcelReports ER;
        string serverType = Entity.GetServerType();
        string emrType = Entity.GetEMRType();
        string iqtoolsConnString = Entity.GetConnString();
        IQToolsReportDatesControl dh = new IQToolsReportDatesControl();
        Entity theObject = new Entity();
        DataTable theDt = new DataTable();
        DataTable theQryDT = new DataTable();
        string cmdARTText = string.Empty;
        public string exportPath = @"C:\Cohort\ExcelExtracts";      
        ErrorLogHelper EH = new ErrorLogHelper();
        private const string STR_MicrosoftAccess = "Microsoft Access";
        private string[] TABLE_NAMES =
        {
         "tblExposedInfants"
        };
        private readonly frmLogin _frmLogin;

        public frmMain(frmLogin FrmLogin)
        {
            InitializeComponent();
            _frmLogin = FrmLogin;
        }

        public frmMain()
        {
            InitializeComponent();

            optART.CheckedChanged += new EventHandler(homeScreenOption_Changed);
            optMAP.CheckedChanged += new EventHandler(homeScreenOption_Changed);
            OptMA.CheckedChanged += new EventHandler(homeScreenOption_Changed);
            optAllApp.CheckedChanged += new EventHandler(homeScreenOption_Changed);
            optNoARTNoCD4.CheckedChanged += new EventHandler(homeScreenOption_Changed);
            optNoARTCD4XY.CheckedChanged += new EventHandler(homeScreenOption_Changed);
            
            if (emrType != "iqcare")  //  this tab page should only appear when the connected EMR is IQCare
            {
                this.tcMain.Controls.Remove(tpEMRAccess);
            }
            if (emrType == "ctc2")
            {
            }
            if (emrType == "cpad")
            {
                          
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                loadQueries();
                clsGbl.IQToolsVersion = Application.ProductVersion;
                //txtVersion.Text = Application.ProductVersion;
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                    txtVersion.Text = "N-" + System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                else
                    txtVersion.Text = "L-" + Application.ProductVersion;


                DataRow DBVersion = (DataRow)theObject.ReturnObject(iqtoolsConnString, ClsUtility.theParams
                    , "Select DBVersion FROM aa_Version", ClsUtility.ObjectEnum.DataRow, serverType);
                txtDate.Text = DBVersion[0].ToString();

                tpEMRAccess.Text = emrType.ToUpper();

                lstClinical.Items.Clear();
                theDt.Clear();
                if (serverType != "pgsql")
                {
                    clsGbl.RemoteWebServiceURL = Entity.getRemoteServiceURL(clsGbl.xmlPath);
                    Thread remoteThread = new Thread(() => runRemoteServices());
                    remoteThread.SetApartmentState(ApartmentState.STA);
                    remoteThread.Start();

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
                    if (emrType == "iqcare" || emrType == "cpad")
                    {
                        Text = "IQTools | " + clsGbl.loggedInUser.FacilityName;
                    }                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "IQTools");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool CheckForInternetConnection()
        {
            try
            {
                SetControlPropertyThreadSafe(picProgress, "Image", Properties.Resources.progressWheel5);
                SetControlPropertyThreadSafe(lblNotify, "Text", "Checking Internet Connectivity");
                using (var webclient = new WebClient())
                using (var streamNet = webclient.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                SetControlPropertyThreadSafe(lblNotify, "Text", ex.Message);
                return false;
            }
            finally { SetControlPropertyThreadSafe(picProgress, "Image", null); }
        }

        private void runRemoteServices()
        {
            //if (CheckForInternetConnection ( ))
            //{
            //  Service1 rws = new Service1 ( );
            //  rws.Url = clsGbl.RemoteWebServiceURL;
            //  try
            //  {
            //    SetControlPropertyThreadSafe ( picProgress, "Image", Properties.Resources.progressWheel5 );
            //    SetControlPropertyThreadSafe ( lblNotify, "Text", rws.SiteHandshake ( clsGbl.loggedInUser.MFLCode, clsGbl.loggedInUser.FacilityName ) );
            //    updateDatabase ( rws );
            //    loadQueries ( );
            //  }
            //  catch (Exception ex) { SetControlPropertyThreadSafe ( lblNotify, "Text", ex.Message ); }
            //  finally { SetControlPropertyThreadSafe ( picProgress, "Image", null ); }
            //}
            //else { SetControlPropertyThreadSafe ( lblNotify, "Text", Assets.Messages.InternetConnectivity ); }
        }

        //private void updateDatabase(Service1 rws)
        //{            
        //    Entity en = new Entity();
        //    ClsUtility.Init_Hashtable();

        //    DataTable DBChanges = new DataTable();
        //    DBChanges.TableName = "Output";
        //    ClsUtility.AddParameters("@WithSyntax", SqlDbType.Text, "0");
        //    string sp = "pr_GetQueriesForUpdate_IQTools";

        //    int updates = 0;            
        //    DataSet theObjects = new DataSet();            

        //    theObjects = (DataSet)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
        //        , ClsUtility.ObjectEnum.DataSet, serverType);
        //    SetControlPropertyThreadSafe(lblNotify, "Text", "Checking For Updates");

        //    if (rws.DBCompare(theObjects.Tables[0]) != null)
        //    {
        //        string sql = string.Empty;
        //        NewQuery nq = new NewQuery();
        //        int i = 0;
        //        ClsUtility.Init_Hashtable();

        //        DBChanges = rws.DBCompare(theObjects.Tables[0]);
        //        //updates = DBChanges.Rows.Count;
        //        DataTableReader DBChangesR = DBChanges.CreateDataReader();
        //        while (DBChangesR.Read())
        //        {
        //            if (DBChangesR["ROUTINE_TYPE"].ToString().ToLower() == "procedure")
        //            {                       
        //               try
        //               {
        //                   sp = "pr_UpdateObjects_IQTools";
        //                   ClsUtility.Init_Hashtable();
        //                   ClsUtility.AddParameters("@ObjectName", SqlDbType.VarChar, DBChangesR["ROUTINE_NAME"].ToString());
        //                   ClsUtility.AddParameters("@ObjectType", SqlDbType.VarChar, "PROCEDURE");
        //                   ClsUtility.AddParameters("@ObjectDef", SqlDbType.Text,DBChangesR["ROUTINE_DEFINITION"].ToString()); 

        //                   i = (int)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
        //                               , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
        //                   updates += 1;
        //               }
        //               catch (Exception ex)
        //               {
        //                   //MessageBox.Show(ex.Message);
        //                   EH.LogError(ex.Message, "IQTools Remote Update", serverType);
        //               }
        //               finally
        //               {
        //                   if (i > 0) { }
        //                   else { }
        //               }                        
        //            }
        //            else if (DBChangesR["ROUTINE_TYPE"].ToString().ToLower() == "function")
        //            {                        
        //                try
        //                {
        //                    sp = "pr_UpdateObjects_IQTools";
        //                    ClsUtility.Init_Hashtable();
        //                    ClsUtility.AddParameters("@ObjectName", SqlDbType.VarChar, DBChangesR["ROUTINE_NAME"].ToString());
        //                    ClsUtility.AddParameters("@ObjectType", SqlDbType.VarChar, "FUNCTION");
        //                    ClsUtility.AddParameters("@ObjectDef", SqlDbType.Text, DBChangesR["ROUTINE_DEFINITION"].ToString());

        //                    i = (int)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
        //                                , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
        //                    updates += 1;

        //                }
        //                catch (Exception ex)
        //                {
        //                    //MessageBox.Show(ex.Message);
        //                    EH.LogError(ex.Message, "IQTools Remote Update", serverType);
        //                }
        //                finally
        //                {
        //                    if (i > 0) { }
        //                    else { }
        //                }    
        //            }
        //            else if (DBChangesR["ROUTINE_TYPE"].ToString().ToLower() == "query")
        //            {
        //                sp = "pr_SaveQuery_IQTools";

        //                nq.qryID = Convert.ToInt32(DBChangesR["object_id"].ToString());
        //                nq.qryName = DBChangesR["ROUTINE_NAME"].ToString();
        //                nq.qryCategory = DBChangesR["QRY_CATEGORY"].ToString();
        //                nq.qrySubCategory = DBChangesR["QRY_SBCATEGORY"].ToString();
        //                nq.qrySQL = DBChangesR["ROUTINE_DEFINITION"].ToString();
        //                nq.qryDescription = DBChangesR["QRY_DSC"].ToString();
        //                nq.qryGroup = DBChangesR["QRY_GRP"].ToString();                        

        //                ClsUtility.Init_Hashtable();
        //                ClsUtility.AddParameters("@qryName", SqlDbType.VarChar, nq.qryName);
        //                ClsUtility.AddParameters("@qryDescription", SqlDbType.VarChar, nq.qryDescription);
        //                ClsUtility.AddParameters("@qryCategory", SqlDbType.VarChar, nq.qryCategory);
        //                ClsUtility.AddParameters("@qrySubCategory", SqlDbType.VarChar, nq.qrySubCategory);
        //                ClsUtility.AddParameters("@qrySQL", SqlDbType.VarChar, nq.qrySQL);
        //                ClsUtility.AddParameters("@qryGroup", SqlDbType.VarChar, nq.qryGroup);
        //                ClsUtility.AddParameters("@devFlag", SqlDbType.Int, 1);

        //                try
        //                {
        //                    i = (int)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
        //                                , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
        //                    updates += 1;
        //                }
        //                catch (Exception ex)
        //                {
        //                    //MessageBox.Show(ex.Message);
        //                    EH.LogError(ex.Message, "IQTools Remote Update", serverType);
        //                }
        //                finally
        //                {
        //                    if (i > 0) {}
        //                    else {}                            
        //                }
        //            }
        //        }
        //        try
        //        {
        //            string DBVersion = rws.GetDBVersion();
        //            ClsUtility.Init_Hashtable();
        //            sql = "UPDATE aa_Version SET DBVersion = '" + DBVersion + "',UpdateDate = dbo.fn_GetCurrentDate()";
        //            i = (int)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sql
        //                , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
        //            txtDate.Text = DBVersion;
        //        }
        //        catch (Exception ex) { MessageBox.Show(ex.Message); EH.LogError(ex.Message, "IQTools Remote Update", serverType); }
        //    }
        //    SetControlPropertyThreadSafe(lblNotify, "Text", updates.ToString() + " Update(s) Applied");
        //    SetControlPropertyThreadSafe(picProgress, "Image", Properties.Resources.progress2);
        //}

        //private class NewQuery
        //{
        //    public int qryID;
        //    public string qryName = string.Empty;
        //    public string qryDescription;
        //    public string qryCategory;
        //    public string qrySubCategory;
        //    public string qrySQL;
        //    public string qryGroup;
        //}

        private void loadQueries()
        {
            if (serverType == "pgsql")
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
            else
            {
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
            
          if (e.TabPage == tpQueries)
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
          else if (e.TabPage == tpExcelMapping)
          {
              Pages.ucExcelMapping excelPage = new Pages.ucExcelMapping(this);
              excelPage.Parent = tcMain.SelectedTab;
              excelPage.Dock = DockStyle.Fill;
              excelPage.Show();

          }
          else if (e.TabPage == tpTemplateMapping)
          {
              Pages.ucCustomReport templatePage = new Pages.ucCustomReport(this);
              templatePage.Parent = tcMain.SelectedTab;
              templatePage.Dock = DockStyle.Fill;
              templatePage.Show();

          }
          else if (e.TabPage == tpLogout)
          {
              DialogResult dialogResult = MessageBox.Show("Are you sure you want to Logout", "IQTools Logout", MessageBoxButtons.OK);
              if (dialogResult == DialogResult.OK)
              {

                  this.Hide();
                  //this.Dispose();
                  frmLogin frm = new frmLogin();
                  frm.Show();
              }
                //else if (dialogResult == DialogResult.Cancel)
                //{
                //    //Pages.ucQueries queryPage = new Pages.ucQueries(this);
                //    //queryPage.Parent = tcMain.SelectedTab;
                //    //queryPage.Dock = DockStyle.Fill;
                //    //queryPage.Show();
                //}
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
                ClsUtility.Init_Hashtable();
                ClsUtility.AddParameters("@EMR", SqlDbType.VarChar, clsGbl.PMMS);
                ClsUtility.AddParameters("@SBC", SqlDbType.VarChar, lstClinical.Text);
                ClsUtility.AddParameters("@CATEGORY", SqlDbType.VarChar, "Clinical");
                Entity en = new Entity();
                try
                {
                    theDt = (DataTable)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
                                            , ClsUtility.ObjectEnum.DataTable, serverType);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    Thread epdThread = new Thread(() => exportDataToExcel((DataTable)dgvClinical.DataSource));
                    epdThread.SetApartmentState(ApartmentState.STA);
                    epdThread.Start();

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
                //ExcelReports Er = new ExcelReports();
                //if (Params("ART")) Er.ARTStart_IQCare(htCategories);
            }
            else if (cboClinical.Text == "3: Excel Report: Duration in days before ART start - IQChart")
            {
                //ExcelReports Er = new ExcelReports();
                //if (Params("ART")) Er.ARTStart_IQChart(htCategories, "ART Start");
            }
            else if (cboClinical.Text == "3: Excel Report: Duration in days before ART start - IQChart (by LPTF)")
            {
                //ExcelReports Er = new ExcelReports();
                //if (Params("ART")) Er.ARTStart_IQChart(htCategories, "LPTF");
            }

            else
            {
                dgvClinical.DataSource = null;
                if (cboClinical.Text != "")
                {
                    int val;
                    DataRow theDr;
                    clsGbl.IQDirection = "clinical";
                    Entity theObject = new Entity(); ClsUtility.Init_Hashtable();

                    theDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                        , "SELECT qryDefinition, qryName FROM (SELECT qryDefinition, qryName,qryDescription FROM aa_Queries)a WHERE qryDescription='" + cboClinical.Text + "'", ClsUtility.ObjectEnum.DataRow, serverType);
                    clsGbl.currQuery = theDr["qryName"].ToString();
                    try
                    {
                        getQueryParameters(theDr["qryDefinition"].ToString());
                        DataTable dt = (DataTable)theObject.ReturnObject(iqtoolsConnString, ClsUtility.theParams
                            , theDr["qryDefinition"].ToString(), ClsUtility.ObjectEnum.DataTable, serverType);
                        dgvClinical.DataSource = dt;
                        val = dgvClinical.Rows.Count - 1;
                        lblNotify.Text = val.ToString() + " Records";
                        cmdClinical.Text = "Excel";
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }

            Cursor.Current = Cursors.Default;
        }
        
        private void cmdVals_Click(object sender, EventArgs e)
        {            
            if (cmdVals.Text.ToLower() == "excel" && dgvValidations.DataSource != null)
            {
                ExcelReports ER = new ExcelReports();
                try
                {
                    Thread ValidThread = new Thread(() => exportDataToExcel((DataTable)dgvValidations.DataSource));
                    ValidThread.SetApartmentState(ApartmentState.STA);
                    ValidThread.Start();

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
                int val;
                DataRow theDr;
                clsGbl.IQDirection = "validations";
                Entity theObject = new Entity(); ClsUtility.Init_Hashtable();

                theDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , "SELECT qryDefinition, qryName FROM  (SELECT qryDefinition, qryName,qryDescription FROM aa_Queries union SELECT qryDefinition, qryName,qryDescription FROM aa_UserQueries)a WHERE a.qryDescription='" + cboValidations.Text + "'", ClsUtility.ObjectEnum.DataRow, serverType);
                clsGbl.currQuery = theDr["qryName"].ToString();
                try
                {
                    getQueryParameters(theDr["qryDefinition"].ToString());
                    DataTable dt = (DataTable)theObject.ReturnObject(iqtoolsConnString, ClsUtility.theParams
                        , theDr["qryDefinition"].ToString(), ClsUtility.ObjectEnum.DataTable, serverType);
                    dgvValidations.DataSource = dt;
                    val = dgvValidations.Rows.Count - 1;
                    lblNotify.Text = val.ToString() + " Records";
                    cmdVals.Text = "Excel";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // Cursor.Current = Cursors.Default;
        }

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
                ClsUtility.Init_Hashtable();
                ClsUtility.AddParameters("@EMR", SqlDbType.VarChar, clsGbl.PMMS);
                ClsUtility.AddParameters("@SBC", SqlDbType.VarChar, lstValidations.Text);
                ClsUtility.AddParameters("@CATEGORY", SqlDbType.VarChar, "Validations");
                Entity en = new Entity();
                try
                {
                    theDt = (DataTable)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
                                            , ClsUtility.ObjectEnum.DataTable, serverType);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                theDr = theDt.CreateDataReader();
                while (theDr.Read())
                { cboValidations.Items.Add(theDr["Description"].ToString()); }
            }
            Cursor.Current = Cursors.Default;
        }
        
        private void cmdART_Click(object sender, EventArgs e)
        {
            ClsUtility.Init_Hashtable();
            ClsUtility.AddParameters("@todate", SqlDbType.VarChar, dtpMAP.Value.ToString("s"));
            ClsUtility.AddParameters("@numdays", SqlDbType.VarChar, TxtMA.Text.Trim());
            ClsUtility.AddParameters("@appdate", SqlDbType.VarChar, dtpAllApp.Value.ToString("s"));
            ClsUtility.AddParameters("@lowCD4", SqlDbType.VarChar, txtLCD4.Text.Trim());
            ClsUtility.AddParameters("@highCD4", SqlDbType.VarChar, txtHCD4.Text.Trim());
            ClsUtility.AddParameters("@lowVL", SqlDbType.VarChar, txtLowVL.Text.Trim());
            if (dgvAdherence.DataSource != null && cmdART.Text == Assets.Messages.ExportToExcel)
            {
                try
                {
                    Thread exportDataThread = new Thread(() => exportDataToExcel((DataTable)dgvAdherence.DataSource));
                    exportDataThread.SetApartmentState(ApartmentState.STA);
                    exportDataThread.Start();
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
                    if (emrType == "iqcare" || emrType == "smartcare" || emrType == "isante" || emrType == "cpad")
                        strName = "IQC_missedARVPickup";
                    else if (emrType == "ctc2" || emrType == "ctc2mysql")
                        strName = "IQC_MissedARVTzPickup";                    
                    break;
                case "optart":
                    strName = "IQC_CorePatientLineList";                              
                    break;
                case "optapa":                   
                        strName = "IQC_ARTMissedAppointments";                    
                    break;
                case "optallapp":                   
                        strName = "IQC_patientAppointments";                   
                    break;
                case "optadherence":                    
                        strName = "IQC_ARVAdherence";                   
                    break;
                case "optnoartcd4xy":                    
                        strName = "IQC_nonARTCD4";                   
                    break;
                case "optnoartnocd4":                  
                        strName = "IQC_nonARTNoCD4";                    
                    break;
                case "optma":
                    if (emrType == "iqcare" || emrType == "smartcare" || emrType == "isante" || emrType == "cpad")
                        strName = "IQC_MissedAppointments";
                    else if (emrType == "ctc2" || emrType == "ctc2mysql")
                        strName = "IQC_MissedTzAppointments";                    
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
            int val;
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
                SetControlPropertyThreadSafe(cmdART, "Text", Assets.Messages.ExportToExcel);
                setEMRLinkColumn(dgv, clsGbl.PMMS);
            }
            catch (Exception ex)
            {
                SetControlPropertyThreadSafe(cmdART, "Text", Assets.Messages.ViewReport);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
                SetControlPropertyThreadSafe(picProgress, "Image", null);
                val = dgv.Rows.Count;
                SetControlPropertyThreadSafe(lblNotify, "Text", val.ToString() + " Records");
                SetControlPropertyThreadSafe(cmdART, "Enabled", true);
            }
        }

        private void exportDataToExcel(DataTable dT)
        {
            ExcelReports ER = new ExcelReports();
            try
            {
                SetControlPropertyThreadSafe(picProgress, "Image", Properties.Resources.progressWheel5);
                SetControlPropertyThreadSafe(lblNotify, "Text", "Exporting To Excel....");
                SetControlPropertyThreadSafe(cmdART, "Enabled", false);
                ER.ExportToExcel(dT, exportPath);
            }
            catch (Exception ex)
            {
                SetControlPropertyThreadSafe(cmdART, "Text", Assets.Messages.ExportToExcel);
                MessageBox.Show(ex.Message);
            }
            finally
            {

                SetControlPropertyThreadSafe(picProgress, "Image", null);
                SetControlPropertyThreadSafe(lblNotify, "Text", "Successfully Exported");
                SetControlPropertyThreadSafe(cmdART, "Enabled", true);
                SetControlPropertyThreadSafe(cmdART, "Text", Assets.Messages.ViewReport);

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
            else if (e.TabPage == tpVals)
            {
                clsGbl.Queries.DefaultView.RowFilter = "Category = 'Validations'";
                clsGbl.Queries.DefaultView.Sort = "SubCategory";
                lstValidations.DataSource = new BindingSource(clsGbl.Queries.DefaultView.ToTable(true, "SubCategory"), null);
                lstValidations.DisplayMember = "SubCategory";
            }
        }
        
        private bool setDHISInfo()
        {
            //frmDHISPassword DHIS2PW = new frmDHISPassword();
            //DialogResult dr = DHIS2PW.ShowDialog();
            //if (dr == DialogResult.Cancel) return false;

            //ER.DHIS2Credentials = DHIS2PW.UName + ":" + DHIS2PW.PWord;
            //ER.EndDateDHIS = dh.dtpToDate.Value;
            //ER.StartDateDHIS = dh.dtpFromDate.Value;
            //ER.MFLCode = DHIS2PW.MFLCode;
            //ER.DHIS2URL = DHIS2PW.DHIS2URL;
            //DataTable qryDR;

            //qryDR = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
            //    , "SELECT [DHISCode]FROM [lnk_Facility] where [MFLCode]='" + ER.MFLCode + "'", ClsUtility.ObjectEnum.DataTable, serverType);
            //if (qryDR.Rows.Count != 0)
            //{
            //    ER.DHISCode = qryDR.Rows[0]["DHISCode"].ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Facility with specified code not found. Please enter a valid code");
            //    return false;
            //}
            return true;
        }
        
        private void optMAP_CheckedChanged(object sender, EventArgs e)
        {
            dgvAdherence.DataSource = null;
            dgvAdherence.Refresh();
            if (optMAP.Checked)
                TxtMA.Text = "7";
            else
                TxtMA.Text = "";
        }

        private void OptMA_CheckedChanged(object sender, EventArgs e)
        {
            dgvAdherence.DataSource = null;
            dgvAdherence.Refresh();
            if (OptMA.Checked)
                TxtMA.Text = "14";
            else
                TxtMA.Text = "";
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

        private void cboClinical_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdClinical.Text = "Run";
            dgvClinical.DataSource = null;
            dgvClinical.Refresh();

        }
              
        private void cboValidations_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdVals.Text = "Run";
            dgvValidations.DataSource = null;
            dgvValidations.Refresh();
        }

        private void gbART_Enter(object sender, EventArgs e)
        {
            cmdART.Text = Assets.Messages.ViewReport;
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
                //myCnn = (MySqlConnection)Entity.getdbConn((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), serverType), "iqtools");
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
           
        private void cmdMultipleSummaries_Click(object sender, EventArgs e)
        {
            //SqlConnection myConn = new SqlConnection();
            //myConn.ConnectionString = Entity.getconnString(clsGbl.xmlPath);

            //BusinessLayer.clsGbl.PatientIDs = new List<string>();

            //frmBulkPatientSummaries selectPatientIDs = new frmBulkPatientSummaries(myConn.ConnectionString);
            //selectPatientIDs.ShowDialog();

            ////Generate bulk reports
            //if (BusinessLayer.clsGbl.PatientIDs.Count > 0)
            //{
            //    ER = new ExcelReports();

            //    Thread reportRunner = new Thread(() => ER.PatientSummaryBulk(BusinessLayer.clsGbl.PatientIDs, this.prBKeReports));
            //    reportRunner.SetApartmentState(ApartmentState.STA);
            //    try
            //    {
            //        reportRunner.Start();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }

            //    this.Cursor = Cursors.Default;
            //}
        }
         
        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            //if (txtPatientID.Text.Length > 0)
            //{
            //    cmdMultipleSummaries.Enabled = false;
            //}
            //else
            //{
            //    cmdMultipleSummaries.Enabled = true;
            //}
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
                //PostgreSQLSyntaxProvider syntaxProvider = new PostgreSQLSyntaxProvider();
                //qb.SyntaxProvider = syntaxProvider;
                //qb.SQL = querySQL;
                //NpgsqlCommand cmd = new NpgsqlCommand(querySQL);

                //if (qb.Parameters.Count > 0)
                //{
                //    Hashtable myParameters = new Hashtable(); int j = 0; myParameters.Clear();
                //    for (int i = 0; i < qb.Parameters.Count; i++)
                //    {
                //        j = 0;

                //        NpgsqlParameter p = new NpgsqlParameter();
                //        p.ParameterName = qb.Parameters[i].FullName;
                //        p.DbType = qb.Parameters[i].DataType;
                //        foreach (DictionaryEntry de in myParameters)
                //        {
                //            if (de.Key.ToString().Trim().ToLower() == qb.Parameters[i].FullName.Trim().ToLower())
                //            {
                //                j = 1;
                //                break;
                //            }
                //        }
                //        if (j == 0)
                //        {
                //            cmd.Parameters.Add(p);
                //            myParameters.Add(p.ParameterName, p.DbType);
                //        }
                //    }

                //    using (frmQueryParameters qp = new frmQueryParameters(qb.Parameters, cmd))
                //    {
                //        qp.StartPosition = FormStartPosition.CenterScreen;
                //        qp.ShowDialog();
                //    }
                //}
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

        //private void cboCustomReport_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    addCustomFilterGUI(cboCustomReport.Text);
        //}
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
            //pnlCReportFilters.Controls.Clear();
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

                //pnlCReportFilters.Controls.Add(lb);

                if (row[2].ToString() == "Date")
                {
                    System.Windows.Forms.DateTimePicker dtp = new System.Windows.Forms.DateTimePicker();

                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "yyyy-MM-dd";
                    dtp.Name = filterName + "InputBox";
                    dtp.Location = new System.Drawing.Point(10, 30 + y);
                    dtp.Size = new System.Drawing.Size(100, 20);
                    dtp.Visible = true;
                    //pnlCReportFilters.Controls.Add(dtp);
                }
                else if (row[2].ToString() == "Number")
                {
                    System.Windows.Forms.NumericUpDown num = new System.Windows.Forms.NumericUpDown();
                    num.Name = filterName + "InputBox";
                    num.Location = new System.Drawing.Point(10, 30 + y);
                    num.Size = new System.Drawing.Size(100, 20);
                    num.Visible = true;
                    //pnlCReportFilters.Controls.Add(num);
                }
                else
                {
                    System.Windows.Forms.TextBox tb = new System.Windows.Forms.TextBox();
                    tb.Name = filterName + "InputBox";
                    tb.Location = new System.Drawing.Point(10, 30 + y);
                    tb.Size = new System.Drawing.Size(100, 20);
                    tb.Visible = true;
                    //pnlCReportFilters.Controls.Add(tb);
                }
                y += 45;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void optART_CheckedChanged(object sender, EventArgs e)
        {
            //dgvAdherence.DataSource=Nothing
            dgvAdherence.DataSource=null;
            dgvAdherence.Refresh();
        }

        private void optNoARTNoCD4_CheckedChanged(object sender, EventArgs e)
        {
            dgvAdherence.DataSource = null;
            dgvAdherence.Refresh();
        }

        private void optAllApp_CheckedChanged(object sender, EventArgs e)
        {
            dgvAdherence.DataSource = null;
            dgvAdherence.Refresh();
        }

        private void optNoARTCD4XY_CheckedChanged(object sender, EventArgs e)
        {
            dgvAdherence.DataSource = null;
            dgvAdherence.Refresh();
        }

        private void optVL_CheckedChanged(object sender, EventArgs e)
        {
            dgvAdherence.DataSource = null;
            dgvAdherence.Refresh();
        }

        private void optVLDetect_CheckedChanged(object sender, EventArgs e)
        {
            dgvAdherence.DataSource = null;
            dgvAdherence.Refresh();
        }
    }
}