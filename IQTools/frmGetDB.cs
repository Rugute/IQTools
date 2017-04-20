using System;
using DataLayer;
using System.Xml;
using System.Data;
using BusinessLayer;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Ionic.Zip;
using System.Globalization;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Reflection;
using Npgsql;
using IQTools;


namespace IQTools
{
    public partial class frmGetDB : Form
    {
        frmLogin fLogin;
      #region PMMS Selection Constants

        bool updateDB = false;
        bool checkpMMS = false;
        string EMR = string.Empty;
        string IQToolsServer = string.Empty;
        string IQToolsDB = string.Empty;
        string IQToolsUser = string.Empty;
        string IQToolsPassword = string.Empty;
        string EMRServerType = string.Empty;
        string EMRServer = string.Empty;
        string EMRUser = string.Empty;
        string EMRPass = string.Empty;
        string EMRDB = string.Empty;
        string cboPMMSText = string.Empty;
        string cboDatabaseText = string.Empty;
        string EMRIPAddress = string.Empty;

      private const string SQL_SERVER = "Microsoft SQL Server";
      private const string MYSQL_SERVER = "MySQL Server";
      private const string POSTGRESQL_SERVER = "PostgreSQL Server";
      private const string MS_ACCESS = "Microsoft Access";

      private string[] SQL_SERVER_PMMS = 
        {
            "IQCare", "SmartCare", "Other"
        };

      private string[] MYSQL_SERVER_PMMS = 
        {
            "CTC2MySQL","ISante","OpenMRS"
        };

      private string[] POSTGRESQL_SERVER_PMMS = 
        {
            "CPAD"
        };

      private string[] MS_ACCESS_PMMS = 
        {
            "CTC2","IQChart"
        };

      private string[] TABLE_NAMES = 
      {
         "tblExposedInfants"
      };

      

      #endregion

        public frmGetDB(frmLogin frm)
        {            
            InitializeComponent();
            fLogin = frm;
            try
            {
                FormLanguageSwitchSingleton.Instance.ChangeLanguage(this, clsGbl.cidi.CultureInfo);              
            }
            catch { }
        }

        string myDir; int x = 0;

        private void lblClose_Click(object sender, EventArgs e)
        {
            if (clsGbl.IQDirection == "connect" || clsGbl.IQDirection == "pmms conn" || myDir == "connect" || myDir == "pmms conn")
            {
                Form tmp = new frmLogin(); tmp.Show(); this.Hide();
            }
            else Application.Exit();
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
        
        private void cmdSave_Click(object sender, EventArgs e)
        {
            updateDB = chkNewDB.Checked;   
            checkpMMS = chkNewPMMS.Checked;  
            EMR = cboPMMS.Text.ToLower();
            IQToolsServer = cboServer.Text.Trim().ToLower();
            IQToolsDB = cboIQTools.Text.Trim();
            IQToolsUser = txtIQTUID.Text;
            IQToolsPassword = txtIQTPWD.Text;
            EMRServerType = cboPMMSType.Text;
            EMRServer = cboDBServer.Text.Trim().ToLower();
            EMRUser = txtDbUID.Text.Trim().ToLower();
            EMRPass = txtDbPWD.Text.Trim();
            EMRDB = cboDBase.Text.Trim().ToLower();
            if (EMRServer.IndexOf("\\") != -1)
            {
                EMRIPAddress = EMRServer.Substring(0, EMRServer.IndexOf("\\"));                
            }
            else
            {
                EMRIPAddress = EMRServer;
            }
            if (EMRIPAddress == ".")
            {
                EMRIPAddress = "localhost";
            }
            
            

            Thread saveSettingsT = new Thread(() => saveSettings());
            saveSettingsT.SetApartmentState(ApartmentState.STA);
            saveSettingsT.Start();
        }

        private void saveSettings()
        {
            SetControlPropertyThreadSafe(picProgress, "Image", Properties.Resources.progressWheel5);
            SetControlPropertyThreadSafe(lblProgress, "Text", "Saving Settings...");
            SetControlPropertyThreadSafe(cmdSave,"Enabled", false);
            SetControlPropertyThreadSafe(lblClose, "Enabled", false);

            Assets.UtFunctions theDB = new Assets.UtFunctions(); 
            myDir = clsGbl.IQDirection;
            bool AccessDB = false;
            AccessDB = !EMRServerType.Trim().ToLower().EndsWith("server");

            bool isMySQL = EMRServerType.Trim().ToLower().Contains("mysql server");
            bool isPgSQL = EMRServerType.Trim().ToLower().Contains("postgresql server");

            #region NotMySQL
            if (!isMySQL && !isPgSQL)
            {
                if ((EMRDB != "" && EMRServer != "" &&  checkpMMS) || (IQToolsDB != "" && IQToolsServer != ""))

                {
                    if (updateDB)
                    {
                        if (!setIQDBase())
                        {
                            SetControlPropertyThreadSafe(picProgress, "Image", null);
                            SetControlPropertyThreadSafe(lblProgress, "Text", "Error Saving Settings");
                            SetControlPropertyThreadSafe(cmdSave, "Enabled", true);
                            SetControlPropertyThreadSafe(lblClose, "Enabled", true);
                            return;
                        }
                    }
                    if (setIQConfig())
                    {
                        if (EMR.ToLower() != "ctc2" && EMR.ToLower() != "ctc2mysql") 
                        {
                            clsGbl.EmrVersion = getEMRVersion(EMR);
                        }

                        if (IQTest(AccessDB) && theDB.setServers(AccessDB, IQToolsServer, theDB.getDbType(EMRServerType)))
                        {
                            if (getLPMMS() && !checkpMMS)
                            {
                                clsGbl.currUser = ""; clsGbl.currPass = "";
                                if (fLogin.InvokeRequired)
                                {
                                    fLogin.Invoke(new MethodInvoker(delegate { fLogin.InitializeForm(); }));
                                }
                                else fLogin.Show();
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new MethodInvoker(delegate { this.Close(); }));
                                }
                                else
                                { this.Close(); }
                            }
                            else
                            {
                                if (!checkpMMS)
                                {
                                    MessageBox.Show("Please set a connection to the PMMS database to proceed", "PMMS Connection");
                                    return;
                                }
                            }
                        }
                    }
                  

                    if (checkpMMS)
                    {
                        if (clsGbl.DBState == "")
                        {
                            //chkNewDB.Checked = true;
                            clsGbl.DBState = "No data";
                        }

                        if (EMRServerType == "" || EMRDB == "")
                        {
                            MessageBox.Show("Please enter a database name and type to proceed", "PMMS Connection");
                            return;
                        }
                        BusinessLayer.clsGbl.tblRefresh = "True";
                        int i = 0;
                        string connString = PMTest(AccessDB, pmmsType(EMRServerType));


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
                            Entity theObject = new Entity(); ClsUtility.Init_Hashtable();                           
                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                                            , "UPDATE aa_Database SET " 
                                                            + "IPAddress = '" + EMRIPAddress + "', " 
                                                            + "DBase = '" + EMRDB + "',  connString='"
                                                            + ClsUtility.Encrypt(connString) + "', PMMSType = '" + pmmsType(EMRServerType)
                                                            + "', IQStatus='No Data', UpdateDate=Null, PMMS = '" + EMR + "',EMRVersion = '"
                                                            + clsGbl.EmrVersion + "' WHERE DBName='IQTools'"
                                                            , ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");

                            if (i == 0)
                                i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                    , "INSERT INTO aa_Database(DBName,IPAddress, DBase, Server, ConnString, PMMSType, IQStatus, UpdateDate, PMMS,EMRVersion) " +
                                    "VALUES('IQTools','" + EMRIPAddress + "','" + EMRDB + "', '" + EMRServer +
                                     "', '" + ClsUtility.Encrypt(connString) + "', '" + pmmsType(EMRServerType) + "', 'No data', Null, '" + 
                                     EMR + "','" + clsGbl.EmrVersion + "')", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                            if (i > 0)
                            {
                                SetControlPropertyThreadSafe(lblProgress, "Text", "Done");
                                SetControlPropertyThreadSafe(picProgress, "Image", null);
                                SetControlPropertyThreadSafe ( cmdSave, "Enabled",  true);
                                MessageBox.Show("Connection to the PMMS has successfully updated...");
                            }
                            clsGbl.currServer = EMRServer; 
                            clsGbl.currData = EMRDB;
                        }
                        else
                        {
                            if (x != 1) MessageBox.Show("A Connection was not established to the connected database, please try again", "PMMS Connection");
                            return;
                        }

                        clsGbl.currUser = ""; clsGbl.currPass = "";                       
                      
                        if (fLogin.InvokeRequired)
                        {
                            fLogin.Invoke(new MethodInvoker(delegate { fLogin.InitializeForm(); }));
                        }
                        else fLogin.Show();
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new MethodInvoker(delegate { this.Close(); }));
                        }
                        else
                        { this.Close(); }

                    }
                }
                else MessageBox.Show("Please enter a server and database name to proceed", "Missing info.");
                clsGbl.IQDirection = myDir;
            }
            #endregion

            #region MySQL
            if(isMySQL)
            {               

                if (EMR != "" && IQToolsDB != "" && EMRServer != "" && EMRUser != "" && EMRPass != "" && EMRDB != "")
                {
                    setMySQLDB(updateDB, EMR, IQToolsDB, EMRServer, EMRUser, EMRPass, EMRDB);
                }
                else
                {
                    MessageBox.Show("Missing Parameters");
                }
            }
            #endregion

            #region PgSQL
            if (isPgSQL)
            {
                if (EMR != "" && EMRServer != "" && EMRUser != "" && EMRPass != "" && EMRDB != "")
                {
                    setPgSQLDB(updateDB, EMR, EMRDB, EMRServer, EMRUser, EMRPass, EMRDB);
                }
                else
                {
                    MessageBox.Show("Missing Parameters");
                }
            }
            #endregion

        }

        private void setPgSQLDB(bool newDB, string EMR, string IQToolsDB, string EMRServer, string EMRUser, string EMRPass, string EMRDB)
        {
            Entity en = new Entity();
            string connstring = String.Format("Server={0};Port={1};" +
                       "User Id={2};Password={3};Database={4};"
                       , EMRServer, "5432", "iqtools", EMRPass, EMRDB);
            if (newDB)
            {
                UpdateIQToolsSchema(connstring);
            }

            //Then save connection strings

            try
            {
                //IQTools ConnString to xml
                string encryptConnString = ClsUtility.Encrypt(connstring);
                ConfigurationManager.AppSettings.Set("IQToolconstr", encryptConnString);
                ConfigurationManager.AppSettings.Set("ServerType", "pgsql");
                string filepath = clsGbl.xmlPath;

                XmlDocument doc = new XmlDocument();

                doc.Load(filepath);

                XmlNode Node = doc.DocumentElement.ChildNodes.Item(1);
                XmlNode Node2 = doc.DocumentElement.ChildNodes.Item(1);
                Node = Node.ChildNodes.Item(0);
                Node.Attributes["value"].Value = encryptConnString;
                Node2 = Node2.ChildNodes.Item(1);
                Node2.Attributes["value"].Value = "pgsql";
                doc.Save(filepath);


                //EMR ConnString to aa_Database
               
                int i = 0;
                string updateSQL = "UPDATE iqtools.aa_database Set dbname='" + IQToolsDB + "' , server= '" + EMRServer
                    + "', connstring= '" + encryptConnString + "', dbase='" + EMRDB 
                    + "' , updatedate=Now(), createdate=Now(), pmmstype='pgsql', iqstatus='No Data', pmms= '" + EMR + "' WHERE dbid = 1";
                i = (int)en.ReturnObject(connstring, ClsUtility.theParams
                    , updateSQL, ClsUtility.ObjectEnum.ExecuteNonQuery, "pgsql");
                MessageBox.Show("IQTools Has Successfully Connected to " + EMR.ToUpper(), "IQTools");

                clsGbl.currUser = ""; clsGbl.currPass = "";

                if (fLogin.InvokeRequired)
                {
                    fLogin.Invoke(new MethodInvoker(delegate { fLogin.InitializeForm(); }));
                }
                else fLogin.Show();
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate { this.Close(); }));
                }
                else
                { this.Close(); }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void setMySQLDB(bool newDB, string EMR, string IQToolsDB, string EMRServer, string EMRUser, string EMRPass, string EMRDB)
        {
            string mySQLConnString = "Server="+EMRServer+";Uid="+EMRUser+";Pwd="+EMRPass+";";
            string emrConnString = "Server=" + EMRServer + ";Uid=" + EMRUser + ";Pwd=" + EMRPass + ";Database=" + EMRDB + "; Allow User Variables=TRUE;";
            string iqtConnString = "Server=" + EMRServer + ";Uid=" + EMRUser + ";Pwd=" + EMRPass + ";Database=" + IQToolsDB + "; Allow User Variables=TRUE;";

            Entity en = new Entity();
            ClsUtility.Init_Hashtable();
            int i = 0;

            if (newDB)
            {
                 BusinessLayer.clsGbl.tblRefresh = "True";
                //Unzip
                if (UnzipFile("C:\\Cohort\\DataFiles\\Database\\IQToolsMySQL.zip"))
                {
                    //Create (Recreate) IQTools DB
                    //Ensure is IQTools DB if exists
                    //Drop Database
                    //DBO Database First

                    recreateDBODatabase(mySQLConnString, iqtConnString);


                    string dropSQL = "DROP SCHEMA " + IQToolsDB;
                    try
                    {
                        i = (int)en.ReturnObject(mySQLConnString, ClsUtility.theParams, dropSQL, ClsUtility.ObjectEnum.ExecuteNonQuery, "mysql");
                    }
                    catch (Exception ex)
                    {
                      if (ex.Message.Contains ( "doesn't exist" ) || ex.Message.Contains ( "cannot be found" ))
                        {
                            //MessageBox.Show("Do Nothing?"); 
                        }
                        else
                            MessageBox.Show(ex.Message);
                    }
                    ///

                    //Create Database
                    try
                    {
                        string createSQL = "CREATE SCHEMA " + IQToolsDB;
                        i = (int)en.ReturnObject(mySQLConnString, ClsUtility.theParams, createSQL, ClsUtility.ObjectEnum.ExecuteNonQuery, "mysql");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }

                    //Restore
                    try
                    {

                        string restoreFile = "C:\\Cohort\\DataFiles\\Database\\iqtools.sql";
                        MySqlBackup mb = new MySqlBackup(iqtConnString);
                        mb.ImportInfo.FileName = restoreFile;
                        mb.Import();

                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            //Then save connection strings
            
            try
            {
                //IQTools ConnString to xml
                string encryptIqtConnString = ClsUtility.Encrypt(iqtConnString);
                ConfigurationManager.AppSettings.Set("IQToolconstr", encryptIqtConnString);
                ConfigurationManager.AppSettings.Set("ServerType", "mysql");
                string filepath = clsGbl.xmlPath;

                XmlDocument doc = new XmlDocument();

                doc.Load(filepath);

                XmlNode Node = doc.DocumentElement.ChildNodes.Item(1);
                XmlNode Node2 = doc.DocumentElement.ChildNodes.Item(1);
                Node = Node.ChildNodes.Item(0);
                Node.Attributes["value"].Value = encryptIqtConnString;
                Node2 = Node2.ChildNodes.Item(1);
                Node2.Attributes["value"].Value = "mysql";
                doc.Save(filepath);

                
                //EMR ConnString to aa_Database
                string encryptEMRConnString = ClsUtility.Encrypt(emrConnString);
                i = 0;
                string updateSQL = "UPDATE aa_Database Set DBName='" + IQToolsDB + "' , Server= '" + EMRServer + "', ConnString= '" + encryptEMRConnString + "', DBase='" + EMRDB + "' , UpdateDate=Now(), CreateDate=Now(), PMMSType='mysql', IQStatus='No Data', PMMS= '" + EMR + "'";
                i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams, updateSQL, ClsUtility.ObjectEnum.ExecuteNonQuery, "mysql");
                MessageBox.Show("IQTools Has Successfully Connected to " + EMR.ToUpper(), "IQTools");
               
                clsGbl.currUser = ""; clsGbl.currPass = "";
                Form tmp = new frmLogin(); tmp.Show();
                this.Close();              
 

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }

        private void recreateDBODatabase(string mySQLConnString, string iqtConnString)
        {
            try
            {
                    string restoreFile = "C:\\Cohort\\DataFiles\\Database\\dbo.sql";
                    MySqlBackup mb = new MySqlBackup(mySQLConnString);
                    mb.ImportInfo.FileName = restoreFile;
                    mb.Import();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private string pmmsType(string description)
        {
            //clsGbl.PMMS = cboPMMS.Text;
            switch (description.Trim().ToLower())
            {
                case "microsoft sql server":
                    return "mssql";
                case "mysql server":
                    return "mysql";
                case "microsoft access":
                    return "msaccess";
                default:
                    return "";
            }
        }

        private bool IQTest(bool AccessDB)
        {
            // check connection to IQTools Database

            if (AccessDB) return false;

            clsGbl.qryType = ""; x = 0;

            DataRow theDr; string cStr;
            Entity theObject = new Entity(); ClsUtility.Init_Hashtable();

            if (!chkTrusted.Checked)
            { cStr = "data source=" + IQToolsServer + ";initial catalog = " + IQToolsDB + ";uid=" + IQToolsUser + ";password=" + IQToolsPassword + ";"; }
            else { cStr = "data source=" + IQToolsServer + ";initial catalog = " + IQToolsDB + ";Integrated Security=SSPI;"; }

            try
            {
                theDr = (DataRow)theObject.ReturnObject(cStr, ClsUtility.theParams, "SELECT AppName, AppVersion FROM aa_Version"
                    , ClsUtility.ObjectEnum.DataRow, "mssql");

                if (theDr["AppName"].ToString().Trim().ToLower() == "iqtools")
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                x = 1;
                if (ex.Message.Substring(0, 12) == "Login failed") MessageBox.Show(ex.Message);
                else if (ex.Message.Substring(0, 7) == "Invalid") MessageBox.Show("This is NOT be a recognised IQTools queries database, Select Another!", "IQTools");
                else if (ex.Message.Substring(0, 3) != "Bad" && ex.Message.Substring(0, 11).ToLower() != "a transport") MessageBox.Show(ex.Message);

                return false;
            }
        }

        private bool setIQDBase()
        {            
            try
            {
                ServerConnection srvConn = new ServerConnection(IQToolsServer);
               
                    srvConn.LoginSecure = false;
                    srvConn.Login = IQToolsUser;
                    srvConn.Password = IQToolsPassword;
                
                SqlDataReader theDtr;
                string mdf = string.Empty, ldf = string.Empty, logicalname = string.Empty;
                try
                {
                    try ////Check if Select DB is an IQTools DB by Logical Name
                    {
                        theDtr = srvConn.ExecuteReader("USE [" + IQToolsDB + "];SELECT file_name(1) AS 'LogicalName'");
                        while (theDtr.Read())
                        {                          
                               logicalname = theDtr["LogicalName"].ToString();
                        }
                        theDtr.Close();
                    }
                    catch{}
                    //if (logicalname.Trim ( ).ToLower ( ) != "iqtools")  //Need to Redo this For Non IQTools DB
                    //{
                    //  logicalname = "iqtools";
                    //}
                    if (logicalname.Trim().ToLower() == "iqtools" || logicalname.Trim().ToLower() == "")
                    {
                        try { srvConn.ExecuteNonQuery("ALTER DATABASE " + IQToolsDB + "  SET OFFLINE WITH ROLLBACK IMMEDIATE"); }
                        catch { }
                        try { srvConn.ExecuteNonQuery("ALTER DATABASE " + IQToolsDB + "  SET ONLINE"); }
                        catch { }

                        if (EMRServerType.ToLower() == "microsoft sql server")
                        {
                            #region SQL_Server
                            try                              
                            {
                                if (EMR.ToLower() == "iqcare")
                                {
                                    try
                                    {
                                        clsGbl.DBVersion = getEMRVersion("iqcare");
                                        clsGbl.EmrVersion = clsGbl.DBVersion;
                                    }
                                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                                    BackupIQToolsDB(IQToolsDB);                                  
                                    UpdateIQToolsDB(IQToolsDB);
                                    //if (clsGbl.DBVersion.Substring(0, 3) == "3.0" || clsGbl.DBVersion.Substring(0, 3) == "3.1" 
                                    //                    || clsGbl.DBVersion.Substring(0, 3) == "3.2" || clsGbl.DBVersion.Substring(0, 3) == "3.3")
                                    //{
                                    //    clsGbl.ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQToolsIQCare3.zip";
                                    //}
                                    //else if (clsGbl.DBVersion.Substring(0, 3) == "3.4" || clsGbl.DBVersion.Substring(0, 3) == "3.5")
                                    //{
                                    //    clsGbl.ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQTools.zip";
                                    //}
                                    //else if (clsGbl.DBVersion.Substring(0, 3) == "2.4" || clsGbl.DBVersion.Substring(0, 3) == "2.3")
                                    //{
                                    //    clsGbl.ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQToolsIQCare2.zip";
                                    //}
                                    //else
                                    //{
                                    //    clsGbl.ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQTools.zip";
                                    //}
                                    //using (ZipFile zip1 = ZipFile.Read(clsGbl.ToUnPack))
                                    //{
                                    //    foreach (ZipEntry e in zip1)
                                    //    {
                                    //        e.Extract("C:\\Cohort\\DataFiles\\Database\\", ExtractExistingFileAction.OverwriteSilently);
                                    //    }
                                    //    //try { System.IO.File.Delete(@"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak"); }
                                    //    //catch { }
                                    //    //System.IO.File.Move(@"C:\\Cohort\\DataFiles\\Database\\IQToolsIQCare.Bak", @"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak");

                                    //}
                                }
                                else if (EMR.ToLower() == "icap")
                                {
                                    clsGbl.ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQToolsICAP.zip";
                                    using (ZipFile zip1 = ZipFile.Read(clsGbl.ToUnPack))
                                    {
                                        foreach (ZipEntry e in zip1)
                                        {
                                            e.Extract("C:\\Cohort\\DataFiles\\Database\\", ExtractExistingFileAction.OverwriteSilently);
                                        }
                                        try { System.IO.File.Delete(@"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak"); }
                                        catch { }
                                        System.IO.File.Move(@"C:\\Cohort\\DataFiles\\Database\\IQToolsICAP.Bak", @"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak");

                                    }
                                }
                                else if (EMR.ToLower() == "smartcare")
                                {
                                    try
                                    {
                                        clsGbl.DBVersion = getEMRVersion("smartcare");
                                        clsGbl.EmrVersion = clsGbl.DBVersion;
                                    }
                                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                                    BackupIQToolsDB(IQToolsDB);
                                    UpdateIQToolsDB(IQToolsDB);

                                    //clsGbl.ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQTools.zip";
                                    //using (ZipFile zip1 = ZipFile.Read(clsGbl.ToUnPack))
                                    //{
                                    //    foreach (ZipEntry e in zip1)
                                    //    {
                                    //        e.Extract("C:\\Cohort\\DataFiles\\Database\\", ExtractExistingFileAction.OverwriteSilently);
                                    //    }
                                    //}
                                }
                                else
                                {
                                    MessageBox.Show("The Database Type/PMMS combination is wrong, Please try again", "PMMS Connection");
                                    return false;
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return false;
                            }
                        #endregion SQL_Server
                        }
                        else if (EMRServerType.ToLower() == "mysql server")
                        {
                            #region MySQl_Server
                            if (EMR.ToLower() == "isante")
                            {
                                try
                                {
                                    String ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQToolsISante.zip";
                                    using (ZipFile zip1 = ZipFile.Read(ToUnPack))
                                    {
                                        foreach (ZipEntry e in zip1)
                                        {
                                            e.Extract("C:\\Cohort\\DataFiles\\Database\\", ExtractExistingFileAction.OverwriteSilently);
                                        }
                                        try { System.IO.File.Delete(@"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak"); }
                                        catch { }
                                        System.IO.File.Move(@"C:\\Cohort\\DataFiles\\Database\\IQToolsISante.Bak", @"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return false;
                                }
                            }
                            else if (EMR.ToLower() == "ctc2mysql")
                            {
                                try
                                {
                                    String ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQToolsCTC2MySQL.zip";
                                    using (ZipFile zip1 = ZipFile.Read(ToUnPack))
                                    {
                                        foreach (ZipEntry e in zip1)
                                        {
                                            e.Extract("C:\\Cohort\\DataFiles\\Database\\", ExtractExistingFileAction.OverwriteSilently);
                                        }
                                        try { System.IO.File.Delete(@"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak"); }
                                        catch { }
                                        System.IO.File.Move(@"C:\\Cohort\\DataFiles\\Database\\IQToolsCTC2MySQL.Bak", @"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return false;
                                }
                            }
                        #endregion MySQL_Server
                        }
                        else if (EMRServerType.ToLower() == "microsoft access" && EMR.ToLower() == "ctc2") 
                        {
                            try
                            {
                              BackupIQToolsDB ( IQToolsDB );
                              UpdateIQToolsDB ( IQToolsDB );

                              /*
                                String ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQTools.zip";
                                using (ZipFile zip1 = ZipFile.Read(ToUnPack))
                                {
                                    foreach (ZipEntry e in zip1)
                                    {
                                        e.Extract("C:\\Cohort\\DataFiles\\Database\\", ExtractExistingFileAction.OverwriteSilently);
                                    }
                                    //try { System.IO.File.Delete(@"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak"); }
                                    //catch { }
                                    //System.IO.File.Move(@"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak", @"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak");
                                }
                               */
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return false;
                            }
                        }
                        else if (EMRServerType.ToLower() == "microsoft access" && EMR.ToLower() == "iqchart")
                        {
                            try
                            {
                                String ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQToolsIQChart.zip";
                                using (ZipFile zip1 = ZipFile.Read(ToUnPack))
                                {
                                    foreach (ZipEntry e in zip1)
                                    {
                                        e.Extract("C:\\Cohort\\DataFiles\\Database\\", ExtractExistingFileAction.OverwriteSilently);
                                    }
                                    try { System.IO.File.Delete(@"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak"); }
                                    catch { }
                                    System.IO.File.Move(@"C:\\Cohort\\DataFiles\\Database\\IQToolsIQChart.Bak", @"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return false;
                            }
                        }

                        else
                        {
                            MessageBox.Show("The Database Type/EMR combination is wrong, Please try again");
                            return false;
                        }

                        /////////////////////////////////////////////////////////////////////////////////////////////////////////
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////
                      /*
                        if (EMR.ToLower() != "smartcare" && EMR.ToLower() != "iqcare")
                        {
                            theDtr = srvConn.ExecuteReader("RESTORE FILELISTONLY FROM DISK = 'C:\\Cohort\\DataFiles\\Database\\IQTools.Bak'");
                            while (theDtr.Read())
                            {
                                if (theDtr["Type"].ToString().ToLower() == "d")
                                    mdf = theDtr["LogicalName"].ToString();
                                else if (theDtr["Type"].ToString().ToLower() == "l")
                                    ldf = theDtr["LogicalName"].ToString();
                            }
                            theDtr.Close();
                            string ReString = "RESTORE DATABASE " + IQToolsDB + " \n" +
                                        "FROM DISK = 'C:\\Cohort\\DataFiles\\Database\\IQTools.Bak' " +
                                //TODO TCHRIS Comment this out for SQL 2008 Support "WITH RESTART, REPLACE, " +
                                        "WITH REPLACE, " +
                                        "MOVE '" + mdf + "' TO 'C:\\Cohort\\DataFiles\\Database\\DataFiles\\" + IQToolsDB + ".mdf' , " +
                                        "MOVE '" + ldf + "' TO 'C:\\Cohort\\DataFiles\\Database\\DataFiles\\" + IQToolsDB + "_log.ldf'";
                            try
                            {
                                srvConn.ExecuteNonQuery(ReString);
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                      */
                    }
                    else //if (!logicalname.Trim().ToLower == "iqtools")
                    {
                        MessageBox.Show("This is not an IQTools Database. Please enter a new DB or select IQTools DB");
                        return false;
                    }
                    
                }
                catch (Exception ex) { throw ex; }

                clsGbl.qryType = "";
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool setIQConfig()
        {
            try
            {
                string theConString = ClsUtility.Encrypt(string.Format("data source = {0};uid = {1};pwd = {2};initial catalog = {3}"
                    , IQToolsServer.Trim(), IQToolsUser.Trim(), IQToolsPassword.Trim(), IQToolsDB.Trim()));
                //ConfigurationSettings.AppSettings.Set("IQToolconstr", theConString);
                ConfigurationManager.AppSettings.Set("IQToolconstr", theConString);
                string filepath = clsGbl.xmlPath;

                XmlDocument doc = new XmlDocument();

                doc.Load(filepath);

                XmlNode Node = doc.DocumentElement.ChildNodes.Item(1);
                XmlNode Node2 = doc.DocumentElement.ChildNodes.Item(1);
                Node = Node.ChildNodes.Item(0);
                Node.Attributes["value"].Value = theConString;
                Node2 = Node2.ChildNodes.Item(1);
                Node2.Attributes["value"].Value = "mssql";
                doc.Save(filepath);
                return true;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool getLPMMS()
        {
            Assets.UtFunctions theDB = new Assets.UtFunctions();
            try
            {
                if (theDB.chkAccessDB(Entity.getdbConnString((SqlConnection)
                    Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools")))
                {
                    System.Data.OleDb.OleDbConnection cnn 
                        = new System.Data.OleDb.OleDbConnection(Entity.getdbConnString((SqlConnection)
                            Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools"));
                    cnn.Open(); cnn.Close(); cnn.Dispose();
                    return true;
                }
                else
                {
                    if (clsGbl.PMMSType.Trim().ToLower() == "mssql" || clsGbl.PMMSType.Trim().ToLower() == "")
                    {
                        SqlConnection cnn = new SqlConnection(Entity.getdbConnString((SqlConnection)
                            Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools"));
                        cnn.Open(); cnn.Close(); cnn.Dispose();
                        return true;
                    }
                    else if (clsGbl.PMMSType.Trim().ToLower() == "mysql")
                    {
                        MySqlConnection cnn = new MySqlConnection(Entity.getdbConnString((SqlConnection)
                            Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools"));
                        cnn.Open(); cnn.Close(); cnn.Dispose();
                        return true;
                    }
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }

        private void frmGetDB_Load(object sender, EventArgs e)
        {
            cboServer.Text = ".\\SQLExpress";
            cboDBServer.Text = ".\\SQLExpress";
            if (clsGbl.IQDirection == "pmms conn")
            {
                chkNewPMMS.Checked = true;

                chkNewDB.Visible = false;
                chkNewPMMS.Visible = false;
            }
            else
            {
                chkNewPMMS.Checked = false;
                chkNewPMMS.Visible = true;
                chkNewDB.Visible = true;
            }
            chkNewPMMS_CheckedChanged(sender, e);


            if (clsGbl.DBState == "No data" || clsGbl.DBState == "")
            {
                chkNewDB.Checked = true;
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

          if (cboPMMS.InvokeRequired)
          {
            cboPMMS.Invoke ( new MethodInvoker ( delegate { cboPMMSText = cboPMMS.Text; } ) );
          }
          else
          {
            cboPMMSText = cboPMMS.Text;
          }
            string connString = "";
            if ((EMRDB.Trim().ToLower() == IQToolsDB.Trim().ToLower()))
            {
                MessageBox.Show("Your IQTools database cannot also be the patient database", "Error Databases");
                return "MyAlert";
            }

            else if (clsGbl.currQuery == EMRDB)
            {
                return "1";
            }
            else
            {
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
                                if (chkSystem.Checked)
                                {
                                    if (txtDbPWD.Text != "" && txtDbUID.Text != "")
                                    {
                                        const string connTemplate = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0};Persist Security Info=False; Jet OLEDB:System Database=Resources\System.mdw; User ID={1}; Password={2};";
                                        connString = String.Format(connTemplate, cboDBase.Text, txtDbUID.Text, txtDbPWD.Text);
                                        OleDbConnection connection = new OleDbConnection(connString);
                                        connection.Open();
                                        connection.Close();
                                        connection.Dispose();
                                        return connString;
                                    }
                                }
                                else
                                {


                                  if (cboPMMSText == "CTC2 Export For Analysis")
                                    {
                                        connString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + cboDBase.Text + "; Persist Security Info=False;";
                                        OleDbConnection connection = new OleDbConnection(connString);
                                        connection.Open();
                                        connection.Close();
                                        connection.Dispose();
                                        return connString;
                                    }
                                    else
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
                                }
                            }
                            catch
                            {
                                try
                                {
                                    if (chkSystem.Checked)
                                    {
                                        if (txtDbPWD.Text != "" && txtDbUID.Text != "")
                                        {
                                            string connTemplate = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False; Jet OLEDB:System Database=Resources\\System.mdw;User ID={0}; Password={1};";
                                            connString = String.Format(connTemplate, cboDBase.Text, txtDbUID.Text, txtDbPWD.Text);
                                            OleDbConnection connection = new OleDbConnection(connString);
                                            connection.Open();
                                            connection.Close();
                                            connection.Dispose();
                                            return connString;
                                        }
                                    }
                                    else
                                    {
                                        //if (chkTrusted.Checked || (txtDbPWD.Text == "" && txtDbUID.Text == ""))
                                      if (cboPMMSText == "CTC2 Export For Analysis")
                                        {
                                            //string connTemplate = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Persist Security Info=False;";
                                            //connString = String.Format(connTemplate, cboDBase.Text);
                                            connString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source= " + cboDBase.Text + "; Persist Security Info=False;";
                                            OleDbConnection connection = new OleDbConnection(connString);
                                            connection.Open();
                                            connection.Close();
                                            connection.Dispose();
                                            return connString;
                                        }
                                        // connString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source= " + cboDBase.Text + "; Persist Security Info=False;";
                                        else
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
                else
                {
                    if (chkTrusted.Checked == false)
                    {
                        if (pmmsType.ToString().ToLower() != "mysql")
                        {
                            connString = "data source=" + EMRServer + ";initial catalog = " + EMRDB +
                                                ";uid=" + EMRUser + ";password=" + txtDbPWD.Text + ";";
                        }
                        else if (pmmsType.ToString().ToLower() == "mysql")
                        {
                            connString = "data source=" + cboDBServer.Text + ";initial catalog = " + cboDBase.Text +
                                                ";uid=" + txtDbUID.Text + ";password=" + txtDbPWD.Text + ";Allow User Variables=True; Connection Timeout = 60;Allow Zero Datetime=true;";//Required To Create Procedures using variables in mySQL
                        }
                    }
                    else
                        connString = "data source=" + cboDBServer.Text + ";initial catalog = " + cboDBase.Text +
                                     ";Integrated Security=SSPI;";
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
        }

        private void cmdSLoad_Click(object sender, EventArgs e)
        {
            if (cboPMMSType.Text.Trim().ToLower() == "microsoft sql server")
                LoadServers(cboServer, cboDBServer);
            else
                LoadServers(cboServer);
        }

        private void LoadServers(ComboBox mSrv)
        {
            mSrv.Items.Clear();
            Cursor.Current = Cursors.WaitCursor;
            DataTable objServers;
            string strServer;

            //retrieve a list of SQL Server instances on the network
            objServers = SmoApplication.EnumAvailableSqlServers(true);
            if (objServers.Rows.Count == 0) //SOME BUG IN THE DAMN THING MAKES IT RETURN 0!
            {
                //no servers were found running

                //    objServers = SmoApplication.EnumAvailableSqlServers(false);
            }
            foreach (DataRow dr in objServers.Rows)
            {
                strServer = dr["Server"].ToString();
                if (dr["Instance"] != null || dr["Instance"].ToString().Length > 0)
                {
                    strServer += @"\" + dr["Instance"].ToString();
                }
                mSrv.Items.Add(strServer);
            }
            Cursor.Current = Cursors.Default;
        }

        private void LoadServers(ComboBox mSrv, ComboBox sSrv)
        {
            mSrv.Items.Clear(); sSrv.Items.Clear();
            Cursor.Current = Cursors.WaitCursor;
            DataTable objServers;
            string strServer;

            //retrieve a list of SQL Server instances on the network
            objServers = SmoApplication.EnumAvailableSqlServers(true);
            if (objServers.Rows.Count == 0) //SOME BUG IN THE DAMN THING MAKES IT RETURN 0!
            {
                //no servers were found running

                //    objServers = SmoApplication.EnumAvailableSqlServers(false);
            }
            foreach (DataRow dr in objServers.Rows)
            {
                strServer = dr["Server"].ToString();
                if (dr["Instance"] != null || dr["Instance"].ToString().Length > 0)
                {
                    strServer += @"\" + dr["Instance"].ToString();
                }
                mSrv.Items.Add(strServer);
                sSrv.Items.Add(strServer);
            }
            Cursor.Current = Cursors.Default;
        }

        private void LoadDbs(ComboBox mDb, string user, string pwd, ComboBox ServerCB)
        {
            mDb.Items.Clear();
            Cursor.Current = Cursors.WaitCursor;
            if (((user != "" && pwd != "") || chkTrusted.Checked))
            {
              if (String.IsNullOrEmpty ( cboPMMSType.Text ))   //Fix to control the new dropdown control changes 
                cboPMMSType.Text = SQL_SERVER;

                if (cboPMMSType.Text.Trim().ToLower().Equals("microsoft sql server"))
                {
                    try
                    {
                        string connString;
                        DataTableReader theDr;
                        DataTable theDt = new DataTable();

                        SqlCommand comm = new SqlCommand("SELECT * from sysDatabases Order By [name]");
                        SqlConnection conn = new SqlConnection();

                        Entity theObject = new Entity();
                        ClsUtility.Init_Hashtable();
                        if (chkTrusted.Checked)
                        { connString = "data source=" + ServerCB.Text + "; Initial Catalog=Master; Integrated Security=SSPI;"; }
                        else
                        { connString = "data source=" + ServerCB.Text + "; Initial Catalog=Master; UID=" + user + "; password=" + pwd + ";"; }

                        theDt = (DataTable)theObject.ReturnObject(connString, ClsUtility.theParams, "SELECT [Name] From sysDatabases Order by [Name]", ClsUtility.ObjectEnum.DataTable, "mssql");
                        theDr = theDt.CreateDataReader();

                        while (theDr.Read())
                        {
                            if (!(theDr["Name"].ToString().Trim().ToLower() == "master" || theDr["Name"].ToString().Trim().ToLower() == "tempdb" || theDr["Name"].ToString().Trim().ToLower() == "model" || theDr["Name"].ToString().Trim().ToLower() == "msdb"))
                                mDb.Items.Add(theDr["Name"].ToString());
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (cboPMMSType.Text.Trim().ToLower().Equals("mysql server"))
                {
                    try
                    {
                        DataTableReader theDr;
                        DataTable theDt = new DataTable();
                        Entity theObject = new Entity();
                        ClsUtility.Init_Hashtable();
                        string connstring = "SERVER=" + cboDBServer.Text + "; UID=" + txtDbUID.Text + ";PASSWORD=" + txtDbPWD.Text + 
                            ";Allow User Variables=True; Connection Timeout=60; Allow Zero Datetime=true;";
                        theDt = (DataTable)theObject.ReturnObject(connstring, ClsUtility.theParams
                            , "Select SCHEMA_NAME `Database` FROM information_schema.SCHEMATA", ClsUtility.ObjectEnum.DataTable, "mysql");
                        theDr = theDt.CreateDataReader();
                        while (theDr.Read())
                        {
                            if (!(theDr["Database"].ToString().Trim().ToLower() == "information_schema"
                                || theDr["Database"].ToString().Trim().ToLower() == "mysql"))
                            {
                                mDb.Items.Add(theDr["Database"].ToString());                                
                            }
                            if (theDr["Database"].ToString().Trim().ToLower().Contains("iqtools"))
                                cboIQTools.Items.Add(theDr["Database"].ToString());

                        }
                    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (cboPMMSType.Text.Trim().ToLower().Equals("postgresql server"))
                {
                    try
                    {
                        DataTableReader theDr;
                        DataTable theDt = new DataTable();
                        Entity theObject = new Entity();
                        ClsUtility.Init_Hashtable();
                        string connstring = String.Format("Server={0};Port={1};" +
                        "User Id={2};Password={3};"
                        , cboDBServer.Text, "5432", txtDbUID.Text, txtDbPWD.Text);

                        theDt = (DataTable)theObject.ReturnObject(connstring, ClsUtility.theParams
                            , "select catalog_name from information_schema.information_schema_catalog_name"
                            , ClsUtility.ObjectEnum.DataTable, "pgsql");
                        theDr = theDt.CreateDataReader();
                        while (theDr.Read())
                        {
                            mDb.Items.Add(theDr["catalog_name"].ToString());                           
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            { MessageBox.Show("Please enter a server, username and password and try again"); }

            Cursor.Current = Cursors.Default;
        }

        private void cmdDBLoad_Click(object sender, EventArgs e)
        {
            if (!cboPMMSType.Text.Trim().ToLower().EndsWith("server"))
            {
                ofdMail.Filter = "Access Database|*.mdb|All files|*.*";
                ofdMail.ShowDialog();
                if (ofdMail.FileName != "")
                    cboDBase.Text = ofdMail.FileName;
            }
            else
                LoadDbs(cboDBase, txtDbUID.Text, txtDbPWD.Text,cboDBServer);
            //cboIQTools.Text = "iqtools";  // this was changing database name 

        }

        private void cmdIQLoad_Click(object sender, EventArgs e)
        {
            LoadDbs(cboIQTools, txtIQTUID.Text, txtIQTPWD.Text,cboServer);
        }

        private void cmdDbServer_Click(object sender, EventArgs e)
        {
            LoadServers(cboDBServer);
        }

        private void chkNewPMMS_CheckedChanged(object sender, EventArgs e)
        {
            gdbPMMS.Enabled = chkNewPMMS.Checked;
            this.Refresh();
        }

        private void cboPMMSType_SelectedIndexChanged(object sender, EventArgs e)
        {
          if (String.IsNullOrEmpty ( cboPMMSType.Text ))
          {
            if (cboPMMSType.Items.Count > 0) cboPMMSType.SelectedIndex = 0;
            return;
          }

          cboPMMS.Items.Clear ( );
          string pmms = cboPMMSType.Text;
          switch (pmms)
          {
            case SQL_SERVER:
              cboDBServer.Text = @".\SQLExpress";
              cboDBServer.Enabled = true;
              txtDbUID.Enabled = true;
              chkSystem.Enabled = true;
              txtDbPWD.Enabled = true;
              chkTrusted.Enabled = false;
              cboServer.Enabled = true;
              txtIQTUID.Enabled = true;
              txtIQTPWD.Enabled = true;
              foreach (string s in SQL_SERVER_PMMS) cboPMMS.Items.Add(s);
              break;

            case POSTGRESQL_SERVER:           
              cboDBServer.Text = @"localhost";
              cboDBServer.Enabled = true;
              txtDbUID.Enabled = true;
              chkSystem.Enabled = true;
              txtDbPWD.Enabled = true;
              chkTrusted.Enabled = false;
              cboServer.Enabled = false;
              cboServer.Text = String.Empty;
              cboIQTools.Enabled = false;
              txtIQTUID.Enabled = false;
              txtIQTPWD.Enabled = false;
              foreach (string s in POSTGRESQL_SERVER_PMMS) cboPMMS.Items.Add ( s );
              break;

            case MS_ACCESS:
              cboDBServer.Enabled = false;
              txtDbUID.Enabled = false;
              chkSystem.Enabled = false;
              txtDbPWD.Enabled = false;
              chkTrusted.Enabled = false;
              cboDBServer.Text = String.Empty;
              cboServer.Enabled = true;
              txtIQTUID.Enabled = true;
              txtIQTPWD.Enabled = true;
              foreach (string s in MS_ACCESS_PMMS) cboPMMS.Items.Add ( s );
              break;

            case MYSQL_SERVER:
              cboDBServer.Enabled = true;
              txtDbUID.Enabled = true;
              chkSystem.Enabled = false;
              txtDbPWD.Enabled = true;
              chkTrusted.Enabled = false;
              cboDBServer.Text = "localhost";
              cboServer.Enabled = false;
              txtIQTUID.Enabled = false;
              txtIQTPWD.Enabled = false;          
              foreach (string s in MYSQL_SERVER_PMMS) cboPMMS.Items.Add ( s );
              break;
          }
          if (cboPMMS.Items.Count > 0) cboPMMS.SelectedIndex = 0;
          gbServer.Text = pmms;
           /*
            gbServer.Text = cboPMMSType.Text;
            cboDBServer.Enabled = cboPMMSType.Text.Trim().ToLower().EndsWith("server");
            cmdDbServer.Enabled = cboPMMSType.Text.Trim().ToLower().EndsWith("server");
            chkSystem.Visible = !cboPMMSType.Text.Trim().ToLower().EndsWith("server");

            cboDBServer.Text = ""; cboDBServer.Items.Clear();
            cboDBase.Text = ""; cboDBase.Items.Clear();
            txtDbPWD.Text = ""; txtDbUID.Text = "";

            if (cboPMMSType.Text.ToLower() == "microsoft sql server")
            {
                cboDBServer.Text = ".\\SQLExpress";
                cboPMMS.Text = "IQCare";
            }
            else if (cboPMMSType.Text.ToLower() == "mysql server")
            {
                cboPMMS.Text = "Isante";
                cboServer.Enabled = false;
                txtIQTUID.Enabled = false;
                txtIQTPWD.Enabled = false;
            }
            else if (cboPMMSType.Text.ToLower() == "microsoft access")
                cboPMMS.Text = "CTC2";
            * */

        }

        private void chkSystem_CheckedChanged(object sender, EventArgs e)
        {
            chkTrusted.Checked = chkSystem.Checked;
        }

        private bool UnzipFile(string zipFilePath)
        {
            try
            {
                using (ZipFile zip1 = ZipFile.Read(zipFilePath))
                {
                    foreach (ZipEntry e in zip1)
                    {
                        e.Extract("C:\\Cohort\\DataFiles\\Database\\", ExtractExistingFileAction.OverwriteSilently);
                    }
                    return true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return false;
        }

        private string getEMRVersion(string emr)
        {
            string versionSQL = "";
            string emrVersion = string.Empty;
            SqlDataReader theDtr = null;
            if (EMRDB != string.Empty)
            {
                if (emr == "iqcare")
                    versionSQL = "USE [" + EMRDB + "]; " +
                                  "Select Case When SUBSTRING(DBVer,0,4) = 'Ver' " +
                                  "THEN SUBSTRING(DBVer,CHARINDEX('Ver',DBVer,0)+3,3)  " +
                                  "ELSE SUBSTRING(DBVer,0,4) END AS " +
                                  "DBVersion From AppADmin";
                else if (emr == "smartcare")
                    versionSQL = "USE [" + EMRDB + "]; " +
                                 "Select Value DBVersion From dbo.Setting Where Name = 'DbVersion'";

                try
                {
                    ServerConnection Conn = new ServerConnection(EMRServer);
                    if (chkTrusted.Checked)
                        Conn.LoginSecure = true;
                    else
                    {
                        Conn.LoginSecure = false;
                        Conn.Login = EMRUser;
                        Conn.Password = EMRPass;
                    }

                    theDtr = Conn.ExecuteReader(versionSQL);

                    while (theDtr.Read())
                    {
                        emrVersion = theDtr["DBVersion"].ToString();
                    }
                    theDtr.Close();


                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            return emrVersion;
        }

        private void cboPMMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPMMS.SelectedItem.ToString().ToLower() == "smartcare")
            {
                cboServer.Text = ".\\SmartCare40";
                cboDBServer.Text = ".\\SmartCare40";
                //txtDbUID.Text = "sa";
                //txtDbUID.Enabled = false;
                //txtDbPWD.Text = "m7r@n$4mAz";
                //txtDbPWD.Enabled = false;
                //txtIQTUID.Text = "sa";
                //txtIQTUID.Enabled = false;
                //txtIQTPWD.Text = "m7r@n$4mAz";
                //txtIQTPWD.Enabled = false;

            }
        }

        private void BackupIQToolsDB(string dbName)
        {
            SetControlPropertyThreadSafe(lblProgress, "Text", "Backing Up IQTools Database");
            string backupSQL = "IF EXISTS(Select name from sys.databases where name = '" +dbName+"') BEGIN " +
                                "BACKUP DATABASE [" + dbName + "]" +
                               "TO DISK = N'C:\\Cohort\\DataFiles\\Database\\" + dbName + "_Backup.bak' " +
                               "WITH NOFORMAT, INIT,  " +
                               "NAME = N'IQTools-Full Database Backup', " +
                               "SKIP, NOREWIND, NOUNLOAD END";

            try
            {
                ServerConnection srvConn = new ServerConnection(IQToolsServer);
                srvConn.LoginSecure = false;
                srvConn.Login = IQToolsUser;
                srvConn.Password = IQToolsPassword;
                
                srvConn.ExecuteNonQuery(backupSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateIQToolsDB(string dbName) {
            SetControlPropertyThreadSafe(lblProgress, "Text", "Updating IQTools Database");
            //string createSQL = "IF NOT EXISTS (Select name from sys.databases where name = '" + dbName + "') BEGIN " +
            //                   "CREATE DATABASE [" + dbName + "] " +
            //                   "ON  PRIMARY " +
            //                   "( NAME = N'IQTools', FILENAME = N'C:\\Cohort\\DataFiles\\Database\\DataFiles\\" + dbName + ".mdf' " +
            //                   ", SIZE = 3072KB , FILEGROWTH = 1024KB ) " +
            //                   "  LOG ON " +
            //                   "( NAME = N'IQTools_log', FILENAME = N'C:\\Cohort\\DataFiles\\Database\\DataFiles\\" + dbName + "_log.ldf' " +
            //                   ", SIZE = 4096KB , FILEGROWTH = 10%) END";

            //Size of model database may just vary from machines to machines, I decided to entirely remove the SIZE option from the CREATE DATABASE command.

            string createSQL = "IF NOT EXISTS (Select name from sys.databases where name = '" + dbName + "') BEGIN " +
                          "CREATE DATABASE [" + dbName + "] " +
                          "ON  PRIMARY " +
                          "( NAME = N'IQTools', FILENAME = N'C:\\Cohort\\DataFiles\\Database\\DataFiles\\" + dbName + ".mdf' " +
                          ") " +
                          "  LOG ON " +
                          "( NAME = N'IQTools_log', FILENAME = N'C:\\Cohort\\DataFiles\\Database\\DataFiles\\" + dbName + "_log.ldf' " +
                          ") END";

            string recoverySQL = "ALTER DATABASE [" + dbName + "] " + "SET RECOVERY SIMPLE";
            try
                {
                ServerConnection srvConn = new ServerConnection(IQToolsServer);
                srvConn.LoginSecure = false;
                srvConn.Login = IQToolsUser;
                srvConn.Password = IQToolsPassword;
                srvConn.ExecuteNonQuery(createSQL);
                srvConn.ExecuteNonQuery(recoverySQL);
                srvConn.Disconnect();

                string sqlFile = "C:\\Cohort\\DataFiles\\Database\\IQToolsMsSQL.zip";
                UnzipFile(sqlFile);

                srvConn = new ServerConnection(IQToolsServer);
                srvConn.LoginSecure = false;
                srvConn.Login = IQToolsUser;
                srvConn.Password = IQToolsPassword;
                srvConn.DatabaseName = dbName;

                FileInfo fi = new FileInfo("C:\\Cohort\\DataFiles\\Database\\IQToolsMsSQL.sql");
                string updateScript = fi.OpenText().ReadToEnd();

                srvConn.ExecuteNonQuery(updateScript);
                srvConn.Disconnect();
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        private void UpdateIQToolsSchema(string connstring)
        {
            SetControlPropertyThreadSafe(lblProgress, "Text", "Updating IQTools Database");
            string createSQL = "CREATE SCHEMA IF NOT EXISTS iqtools AUTHORIZATION iqtools;";
            try
            {
                
                NpgsqlConnection srvConn = new NpgsqlConnection(connstring);
                srvConn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(createSQL, srvConn);
                cmd.ExecuteNonQuery();

                string sqlFile = "C:\\Cohort\\DataFiles\\Database\\IQToolsPgSQL.zip";
                UnzipFile(sqlFile);
                FileInfo fi = new FileInfo("C:\\Cohort\\DataFiles\\Database\\IQToolsPgSQL.sql");
                string updateScript = fi.OpenText().ReadToEnd();

                NpgsqlCommand updatecmd = new NpgsqlCommand(updateScript, srvConn);
                updatecmd.ExecuteNonQuery();
                srvConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
    }
}