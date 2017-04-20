using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DataLayer;
using System.Data.SqlClient;
using BusinessLayer;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Threading;

namespace IQTools
{
    public partial class frmLoad : Form
    {
        string serverType = Entity.getServerType(clsGbl.xmlPath);
        ErrorLogHelper EH = new ErrorLogHelper();
        
        public frmLoad()
        {
            InitializeComponent();
            FormLanguageSwitchSingleton.Instance.ChangeLanguage(this, clsGbl.cidi.CultureInfo);      
        }

        private void frmLoad_Shown(object sender, EventArgs e)
        {
            Thread loadThread = new Thread(() => loadIQTools());
            loadThread.SetApartmentState(ApartmentState.STA);
            loadThread.Start();
        }

        private void updateDatabase()
        {
            //Checks for EMR Version and Update Accordingly
            FileInfo file = new FileInfo( "Update\\UpdateScript.sql");
            string sqlConnectionString = Entity.getconnString(clsGbl.xmlPath);

            if (clsGbl.PMMS.ToLower() == "iqcare")
                file = new FileInfo("Update\\UpdateScript.sql");
            else if (clsGbl.PMMS.ToLower() == "isante")
                file = new FileInfo("Update\\UpdateScript_Isante.sql");
            else
                return;

            string script = file.OpenText().ReadToEnd();
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            Server server = new Server(new ServerConnection(conn));
            try
            {
                server.ConnectionContext.ExecuteNonQuery(script);
            }
            catch { }
        }

        private bool versionSynchronized()
        {
            Entity theObject = new Entity();
            DataRow thedr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                , "SELECT AppVersion from aa_Version", ClsUtility.ObjectEnum.DataRow, serverType);
            return (Application.ProductVersion.Trim().ToLower() == thedr[0].ToString().ToLower());
        }        

        private void loadIQTools()
        {
            int i = 0;
            Entity theObject = new Entity(); ClsUtility.Init_Hashtable();

            #region TryLoad
            try
            {

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
                else if(serverType == "mssql")
                {
                  string SQL = "SELECT Top 1 PMMSType, PMMS, EMRVersion, IPAddress From aa_Database";
                  theDr = (DataRow)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                                                              , SQL, ClsUtility.ObjectEnum.DataRow, serverType );
                  clsGbl.PMMSType = serverType;
                  clsGbl.PMMS = theDr["PMMS"].ToString ( );
                  clsGbl.EmrVersion = theDr["EMRVersion"].ToString ( );
                  clsGbl.EMRIPAddress = theDr["IPAddress"].ToString();
                }
                else if (serverType == "pgsql")
                {
                    string SQL = "SELECT pmmstype, pmms, emrversion, server From iqtools.aa_database";
                    theDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                , SQL, ClsUtility.ObjectEnum.DataRow, serverType);
                    clsGbl.PMMSType = serverType;
                    clsGbl.PMMS = theDr["PMMS"].ToString();
                    clsGbl.EmrVersion = theDr["EMRVersion"].ToString();
                    clsGbl.EMRIPAddress = theDr["server"].ToString();
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

                if (BusinessLayer.clsGbl.IQDirection != "login")
                {
                    #region notMySQL
                    if (serverType == "mssql")
                    {
                        if (clsGbl.tblRefresh.ToLower() == "true" && Entity.getRefreshRights(BusinessLayer.clsGbl.xmlPath).ToLower() == "yes")
                        {
                            Assets.UtFunctions theDB = new Assets.UtFunctions();
                            if (!theDB.clrIQTables(theDB.chkAccessDB(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools")), "")
                                                        || !theDB.crtIQTables(theDB.chkAccessDB(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools")), "", this.prbLoad))
                            {
                                MessageBox.Show("There Was A Problem Accessing The EMR Database, Data May Not Have Been Loaded Into IQTools"
                                                    , "IQTools Connection Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                clsGbl.IQDirection = "connect";
                            }

                            else if (clsGbl.IQDirection.ToLower() != "setusers")
                            {
                                Cursor.Current = Cursors.WaitCursor;

                                #region mst_Patient
                                try
                                {

                                    if (clsGbl.currData != "")
                                    {
                                        theDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                    , "SELECT * FROM [" + clsGbl.currData + "].dbo." + "AppAdmin", ClsUtility.ObjectEnum.DataRow, "mssql");
                                        {
                                            string SQLString = "";
                                            i = 0; int j = 0;
                                            //open symmetric key
                                            SqlConnection myConn = new SqlConnection();
                                            myConn.ConnectionString = Entity.getconnString(clsGbl.xmlPath);

                                            myConn.Open(); string IQDb = myConn.Database; myConn.ChangeDatabase(clsGbl.currData);
                                            SqlCommand myComm = new SqlCommand("Open symmetric key Key_CTC decryption by password='ttwbvXWpqb5WOLfLrBgisw=='", myConn);
                                            j = myComm.ExecuteNonQuery(); j = 0;

                                            ////////////////////////////////////////////////

                                            SQLString = "Select *, " +
                                                              " convert(varchar(100),decryptbykey(MiddleName)) dMiddleName," +
                                                              " convert(varchar(100),decryptbykey(firstname)) dFirstName, convert(varchar(100),decryptbykey(LastName))dLastName," +
                                                              " convert(varchar(100),decryptbykey(Address))dAddress, convert(varchar(100),decryptbykey(Phone)) dPhone" +
                                                              " INTO " + IQDb + ".dbo.mst_patient_decoded  From ";


                                            //try
                                            //{
                                            //    j = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                            //                                      , "DROP SYNONYM Mst_Patient", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                            //}
                                            //catch (Exception ex) { EH.LogError(ex.Message, "<<frmLoad:Drop Synonym Mst_Patient>>", serverType); }
                                            myComm.Dispose(); j = 0;

                                            myComm = new SqlCommand(SQLString + "mst_patient Where mst_patient.deleteflag is null or mst_patient.deleteflag=0", myConn);
                                            j = myComm.ExecuteNonQuery(); j = 0;

                                            //close the key and do final dispose
                                            myComm.Dispose();

                                            myComm = new SqlCommand("close symmetric key Key_CTC", myConn);
                                            j = myComm.ExecuteNonQuery();
                                            myComm.Dispose();
                                            myComm = null;
                                            myConn.Close();
                                            myConn.Dispose();
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    EH.LogError(ex.Message, "<<frm_Load:Decode Mst_Patient>>", serverType);
                                }

                                #endregion

                                ClsUtility.Init_Hashtable();
                                try
                                {
                                    DataRow fDr = null;
                                    if (clsGbl.PMMS.ToLower() == "iqcare")
                                    {
                                        fDr = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                              , "SELECT TOP 1 FacilityName FROM mst_Facility WHERE DeleteFlag = 0", ClsUtility.ObjectEnum.DataRow, "mssql");
                                    }

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
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreateSiteDetails_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(10);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreatePatientMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(20);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreatePharmacyMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(30);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreateClinicalEncountersMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(40);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreateLastStatusMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }

                                        try
                                        {
                                            UpdateProgress(50);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreateARTPatientsMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(60);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreateLabMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(70);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreatePregnanciesMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(80);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreateOIsMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(85);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreateTBPatientsMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(90);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreateHEIMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(95);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreateANCMothersMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(100);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreateFamilyInfoMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(100);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreateIQToolsViews_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        try
                                        {
                                            UpdateProgress(100);
                                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                                                , "pr_CreateLastReportStatusMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                        }
                                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                                        //}
                                        ClsUtility.Init_Hashtable();

                                    }
                                    #endregion

                                    Cursor.Current = Cursors.Default;
                                    clsGbl.IQDirection = "main";
                                }
                                catch (Exception ex)
                                {
                                    EH.LogError(ex.Message, "<<frmLoad:loadIQTools()>>", serverType);
                                    clsGbl.IQDirection = "connect";
                                }
                            }

                        }
                    }
                    #endregion
                    else if (serverType == "mysql")
                    {

                        if (clsGbl.tblRefresh.ToLower() == "true")
                        {
                            clearMySQLTables();
                            createMySQLTables();
                        }
                        clsGbl.IQDirection = "main";
                    }
                    else if (serverType == "pgsql")
                    {
                        string connstring = Entity.getconnString(clsGbl.xmlPath);                      

                        if (clsGbl.tblRefresh.ToLower() == "true")
                        {
                            clearPgSQLTables(connstring);
                            createPgSQLTables(connstring);
                        }
                        clsGbl.IQDirection = "main";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("IQTools Could Not Connect To The EMR Database, Please Configure IQTools. Error Message="+ex.Message
                                    , "IQTools Connection Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                clsGbl.IQDirection = "connect"; 
            }
            #endregion TryLoad
                    
            if (BusinessLayer.clsGbl.IQDirection == "login")
            {
                Form tmp = new frmLogin();
                tmp.Show(); this.Hide();
            }
            else if (clsGbl.IQDirection == "connect")
            {
                //Form tmp = new frmGetDB(this);
                //AccessContol();
                //Application.Run(tmp);                
            }
            else //Success?
            {
                Form tmp = new frmMain();
                AccessContol();
                Application.Run(tmp);
            }
            Cursor.Current = Cursors.Default;
        }

        private void UpdateProgress(int p)
        {
            if (InvokeRequired)
            { this.Invoke(new MethodInvoker(delegate { prbLoad.Value = p; })); }
        }

        private void AccessContol()
        {
            if (InvokeRequired)
            { this.Invoke(new MethodInvoker(delegate { this.Hide(); })); }
            else { this.Hide(); }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            if (clsGbl.IQDirection == "login" || clsGbl.IQDirection == "")
            {
                Form tmp = new frmLogin();
                AccessContol();
                Application.Run(tmp);
            }
            else
            {
                Application.Exit();
            }
        }        

        private void clearMySQLTables()
        {
            string iqtConnString = Entity.getconnString(clsGbl.xmlPath);
            string EMRConnString = "";
            Entity en = new Entity();
            DataRow dr = (DataRow)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "Select ConnString From aa_Database", ClsUtility.ObjectEnum.DataRow, serverType);
            EMRConnString = ClsUtility.Decrypt(dr[0].ToString());
            MySql.Data.MySqlClient.MySqlConnectionStringBuilder mcr = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder(iqtConnString);
            string IQToolsDB = mcr.Database;
            ClsUtility.Init_Hashtable();

            //Use Procedure to do this
            ClsUtility.AddParameters("dbName", SqlDbType.VarChar, IQToolsDB);
            try { int i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_DropIQToolsObjects_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void createMySQLTables()
        {
            string iqtConnString = Entity.getconnString(clsGbl.xmlPath);
            string EMRConnString = "";
            string sql = "";
            Entity en = new Entity();
            ClsUtility.Init_Hashtable();
            DataRow dr = (DataRow)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "Select ConnString,PMMS From aa_Database", ClsUtility.ObjectEnum.DataRow, serverType);
            EMRConnString = ClsUtility.Decrypt(dr[0].ToString());
            clsGbl.PMMS = dr["PMMS"].ToString();
            MySql.Data.MySqlClient.MySqlConnectionStringBuilder mcr = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder(EMRConnString);
            string EMRDB = mcr.Database;

            int i = 0;
            string toCreate = "SELECT TABLE_NAME, TABLE_TYPE FROM INFORMATION_SCHEMA.TABLES " +
                              "WHERE TABLE_SCHEMA = '" + EMRDB + "'";

            DataTable dt = new DataTable();

            dt = (DataTable)en.ReturnObject(EMRConnString, ClsUtility.theParams, toCreate, ClsUtility.ObjectEnum.DataTable, serverType);
            DataTableReader d = dt.CreateDataReader();

            //Create 'Synonyms'>>Views to EMR Tables
            while (d.Read())
            {
                try
                {
                    sql = "CREATE OR REPLACE VIEW `" + d[0].ToString() + "` AS SELECT * FROM `" + EMRDB + "`.`" + d[0].ToString() + "`;";
                    i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams, sql, ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                }
                catch (Exception ex) 
                {
                    if (ex.Message.ToLower().Contains("not view"))
                    {
                        //Silently write to errorlogs                        
                        EH.LogError(ex.Message, "<<frmLoad: Create Or Replace View>>", serverType);                        
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            d.Dispose();
            dt = null;

            //Create Temp Tables
            //Using Procedures
            ClsUtility.Init_Hashtable();
            ClsUtility.AddParameters("facilityName", SqlDbType.Text, "");
            if (clsGbl.PMMS.Contains("ctc2"))
                ClsUtility.AddParameters("emr", SqlDbType.Text, "CTC2");
            else if (clsGbl.PMMS.Contains("isante"))
                ClsUtility.AddParameters("emr", SqlDbType.VarChar, "isante");            
            else if (clsGbl.PMMS.Contains("openmrs")) 
                ClsUtility.AddParameters("emr", SqlDbType.VarChar, "openmrs");
            
            ClsUtility.AddParameters("emrversion", SqlDbType.VarChar, "");
            
            UpdateProgress(5);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreateSiteDetails_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            UpdateProgress(20);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreatePatientMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            UpdateProgress(30);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreatePharmacyMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }            
            UpdateProgress(40);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreateClinicalEncountersMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            UpdateProgress(50);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreateLastStatusMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            UpdateProgress(60);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreateARTPatientsMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            UpdateProgress(70);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreateLabMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }            
            UpdateProgress(80);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreateOIsMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            UpdateProgress(90);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreatePregnanciesMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            UpdateProgress(95);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreateTBPatientsMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            UpdateProgress(95);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreateANCMothersMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            UpdateProgress(95);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreateHEIMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            UpdateProgress(95);
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreateFamilyInfoMaster_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            UpdateProgress ( 96 );
            try { i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams
                , "pr_CreateIQToolsViews_IQTools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            ClsUtility.Init_Hashtable();
        }

        private void clearPgSQLTables(string connstring)
        {
            Entity en = new Entity();
            ClsUtility.Init_Hashtable();
            //prbLoad.Visible = false;
            try
            {                
                int i = (int)en.ReturnObject(connstring, ClsUtility.theParams
                    , "pr_dropiqtoolsobjects_iqtools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void createPgSQLTables(string connstring)
        {            
            Entity en = new Entity();
            ClsUtility.Init_Hashtable();
            try
            {                
                int i = (int)en.ReturnObject(connstring, ClsUtility.theParams
                    , "pr_createiqtoolsobjects_iqtools", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);          
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void UpdateProgressWheel()
        {

        }
    
    }
}