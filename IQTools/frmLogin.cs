using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using DataLayer;
using BusinessLayer;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using MySql.Data.MySqlClient;

namespace IQTools
{
    public partial class frmLogin : Form
    {
        string serverType = string.Empty;

        public static MySqlConnection db = new MySqlConnection();

        public void InitializeForm()
        {
            if (!this.Visible)
                this.Show();
            serverType = Entity.getServerType(BusinessLayer.clsGbl.xmlPath);
            cboLanguage.Items.Clear();
            LanguageCollector lc = new LanguageCollector();
            BusinessLayer.clsGbl.currUser = "";
            BusinessLayer.clsGbl.currPass = "";
            int currentLanguage;
            CultureInfoDisplayItem[] lis = lc.GetLanguages(System.Globalization.LanguageCollector.LanguageNameDisplay.EnglishName, out currentLanguage);
            cboLanguage.Items.AddRange(lis);
            this.cboLanguage.SelectedIndex = currentLanguage;



            if (!SettingsAreValid())
            {

                BusinessLayer.clsGbl.SettingsValid = false;
                BusinessLayer.clsGbl.DBState = "Incorrect settings";
                lblLoadStat.Text = "Incorrect settings";

                MessageBox.Show(Assets.Messages.InvalidSettings, Assets.Messages.InfoHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BusinessLayer.clsGbl.SettingsValid = true;

                DataLayer.Entity theObject = new DataLayer.Entity();
                DataLayer.ClsUtility.Init_Hashtable(); DataRow theDr;
                try
                {
                    LoadPic();
                    theObject = new DataLayer.Entity(); DataLayer.ClsUtility.Init_Hashtable(); DataRow dr = null;
                    if (serverType == "mssql")
                    {
                        dr = (DataRow)theObject.ReturnObject(DataLayer.Entity.getconnString(BusinessLayer.clsGbl.xmlPath)
                            , DataLayer.ClsUtility.theParams, "Select Top 1 Case When [ActCount] >= [TblCount] Then 'Proceed' Else 'Halt' End [Action], " +
                            "IQStatus,PmmsType, a.UpdateDate, a.PMMS From " +
                            "(select count(*) [ActCount] from sys.tables Where [Name] Like 'Tmp_%')Tmp1, " +
                            "(Select Count(*) [TblCount] From sys.procedures Where Name Like '%Master_IQTools%')Tmp2, aa_Database a"
                            , DataLayer.ClsUtility.ObjectEnum.DataRow, "mssql");

                    }
                    else if (serverType == "mysql")
                    {
                        dr = (DataRow)theObject.ReturnObject(DataLayer.Entity.getconnString(BusinessLayer.clsGbl.xmlPath), DataLayer.ClsUtility.theParams
                            , "Select Case When tmpTables >= MasterProcs Then 'Proceed' Else 'Halt' End `Action`, " +
                                "IQStatus,PmmsType, a.UpdateDate, a.PMMS From " +
                                "(Select COUNT(TABLE_NAME) tmpTables From aa_Database a Inner Join INFORMATION_SCHEMA.Tables b On a.DBName = b.TABLE_SCHEMA " +
                                "WHERE b.TABLE_NAME LIKE 'tmp_%' AND TABLE_TYPE = 'BASE TABLE')Tmp1, " +
                                "(Select COUNT(ROUTINE_NAME) MasterProcs From aa_Database a Inner Join INFORMATION_SCHEMA.Routines b On a.DBName = b.ROUTINE_SCHEMA " +
                                "WHERE b.ROUTINE_NAME LIKE '%Master_IQTools%' AND ROUTINE_TYPE = 'PROCEDURE')Tmp2, aa_Database a"
                                , DataLayer.ClsUtility.ObjectEnum.DataRow, serverType);
                    }
                    else if (serverType == "pgsql")
                    {
                        dr = (DataRow)theObject.ReturnObject(DataLayer.Entity.getconnString(BusinessLayer.clsGbl.xmlPath)
                            , DataLayer.ClsUtility.theParams
                            , "select case when tmptables >= masterprocs then 'proceed' else 'halt' end zaction, " + 
                               " iqstatus,pmmstype, a.updatedate, a.pmms from " +
                               " (select count(table_name) tmptables from information_schema.tables " +
                               " a inner join iqtools.aa_database b on a.table_catalog = b.dbname " +
                               " where table_schema = 'iqtools' and table_name like 'tmp%' " +
                               " )tmp1,(select count(routine_name) masterprocs from information_schema.routines " +
                               " a inner join iqtools.aa_database b on a.specific_catalog = b.dbname " +
                               " where specific_schema = 'iqtools' " +
                               " and routine_name like '%master_cpad%' " + 
                               " )tmp2, iqtools.aa_database a"
                                , DataLayer.ClsUtility.ObjectEnum.DataRow, serverType);
                    }

                    if (dr["IQStatus"].ToString().ToLower() == "no data")
                    {
                        BusinessLayer.clsGbl.DBState = "No Data";
                        lblLoadStat.Text = "No data"; lblUpdate.Text = "";
                        chkRefresh.Checked = true;
                    }
                    else if (dr[0].ToString().ToLower() != "proceed"
                                && dr["IQStatus"].ToString().ToLower() != "loading"
                                 )
                    {
                        try
                        {
                            int i = (int)theObject.ReturnObject(DataLayer.Entity.getconnString(BusinessLayer.clsGbl.xmlPath), DataLayer.ClsUtility.theParams
                              , "Update aa_Database set IQStatus='No data', UpdateDate=Null", DataLayer.ClsUtility.ObjectEnum.DataRow, serverType);
                        }
                        catch { }
                        BusinessLayer.clsGbl.DBState = "No Data";
                        lblLoadStat.Text = "No data"; lblUpdate.Text = "";
                        chkRefresh.Checked = true;
                    }
                    else
                    {
                        lblLoadStat.Text = dr["IQStatus"].ToString();
                        lblUpdate.Text = Convert.ToDateTime(dr["UpdateDate"].ToString()).Date.ToShortDateString(); //.Substring(0, 10);
                    }

                    BusinessLayer.clsGbl.DBState = lblLoadStat.Text;
                    if (lblLoadStat.Text.ToLower() != "loading" && lblLoadStat.Text.ToLower() != "No data")
                    {
                        theObject = new DataLayer.Entity(); DataLayer.ClsUtility.Init_Hashtable();
                        if (serverType == "mysql")
                        {
                            theDr = (DataRow)theObject.ReturnObject(DataLayer.Entity.getconnString(BusinessLayer.clsGbl.xmlPath), DataLayer.ClsUtility.theParams
                                , "SELECT Case WHEN DateDiff(Day, Cast('" + lblUpdate.Text.Trim() + "' As dateTime), GetDate()) >= 1 Then 2 Else 3 End [DaysOLD]"
                                , DataLayer.ClsUtility.ObjectEnum.DataRow, "mssql");

                            if (theDr["DaysOLD"].ToString().Trim() == "2")
                                chkRefresh.Checked = true;
                        }
                    }
                    clsGbl.PMMS = dr["PMMS"].ToString().ToLower();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                activateRefresh();
                activateSatelliteCombo();

            }
        }
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            BusinessLayer.clsGbl.IQDate = IQDate.Value.ToString();
            string selectedFacility = "";
            if (clsGbl.SettingsValid == false)
            {
                MessageBox.Show(Assets.Messages.InvalidSettings, Assets.Messages.InfoHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                clsGbl.DBState = lblLoadStat.Text;
                if (chkRefresh.Checked)
                {
                    clsGbl.tblRefresh = "true";
                }

                if (txtUser.Text != "" && txtPassword.Text != "")
                {
                    if(clsGbl.PMMS == "iqcare")
                    {
                        if (cboFacility.SelectedIndex > -1)
                            selectedFacility = cboFacility.SelectedItem.ToString();
                        else
                        {
                            MessageBox.Show("Please Select A Facility To Proceed", Assets.Messages.InfoHeader
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        }
                    }
                    if (loginEMR(clsGbl.PMMS, txtUser.Text.Trim(), txtPassword.Text, selectedFacility))
                    {
                        Form tmp = new frmLoad();
                        tmp.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show(Assets.Messages.MissingCredentials, Assets.Messages.InfoHeader
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblDB_Click(object sender, EventArgs e)
        {
            clsGbl.tblRefresh = chkRefresh.Checked.ToString();
            clsGbl.IQDirection = "connect";
            Form tmp = new frmGetDB(this);
            tmp.Show(); this.Hide();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void LoadPic()
        {
            Entity en = new Entity();
            ClsUtility.Init_Hashtable();
            if (Entity.getServerType(BusinessLayer.clsGbl.xmlPath) == "mysql")
            {
                DataRow dr = (DataRow)en.ReturnObject(Entity.getconnString(BusinessLayer.clsGbl.xmlPath), ClsUtility.theParams
                    , "SELECT PMMS From aa_Database LIMIT 1", ClsUtility.ObjectEnum.DataRow, "mysql");
                if (dr[0].ToString().ToLower() == "isante")
                {
                    picLogo.Image = Properties.Resources.isante_ht1;
                }
            }
        }

        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

            BusinessLayer.clsGbl.cidi = (CultureInfoDisplayItem)cboLanguage.SelectedItem;
            FormLanguageSwitchSingleton.Instance.ChangeLanguage(this, BusinessLayer.clsGbl.cidi.CultureInfo);
            //FormLanguageSwitchSingleton.Instance.ChangeCurrentThreadUICulture(BusinessLayer.clsGbl.cidi.CultureInfo);
            Thread.CurrentThread.CurrentUICulture = BusinessLayer.clsGbl.cidi.CultureInfo;

        }

        private void activateRefresh()
        {
            if (Entity.getRefreshRights(BusinessLayer.clsGbl.xmlPath).ToLower() == "no")
            {
                chkRefresh.Checked = false;
                chkRefresh.Enabled = false;
            }
        }

        public bool loginEMR(string emr, string userName, string password, string facilityName)  //This Method need to be accessed in FrmMain, internal dataset connection
        {
            string emrConnString = "";
            ClsUtility.Init_Hashtable();
            Entity en = new Entity();

            //DataRow dr = (DataRow)en.ReturnObject(Entity.getconnString(BusinessLayer.clsGbl.xmlPath), ClsUtility.theParams
            //            , "Select ConnString,DBase,DBName From aa_Database", ClsUtility.ObjectEnum.DataRow, serverType);
            //emrConnString = ClsUtility.Decrypt(dr["ConnString"].ToString());

            try
            {
                if (emr.ToLower() == "iqcare")
                {
                    DataRow dr = (DataRow)en.ReturnObject(Entity.getconnString(BusinessLayer.clsGbl.xmlPath), ClsUtility.theParams
                        , "Select ConnString,DBase,DBName From aa_Database", ClsUtility.ObjectEnum.DataRow, serverType);
                    emrConnString = ClsUtility.Decrypt(dr["ConnString"].ToString());
                    string sPassword = ClsUtility.Encrypt(password);
                    string sSQL = "SELECT top 1 a.userID, a.UserName, a.Password, a.UserFirstName, a.UserLastName, c.GroupName, f.FacilityID, f.SatelliteID MFLCode FROM " +
                                "(Select FacilityID, SatelliteID FROM mst_Facility WHERE FacilityName = '" + facilityName + "') f, " +
                                "mst_user a " +
                                "INNER JOIN dbo.lnk_UserGroup b ON a.UserID = b.UserID " +
                                "INNER JOIN dbo.mst_Groups c ON b.GroupID = c.GroupID " +
                                "WHERE a.DeleteFlag = 0 AND a.UserName = '" + userName + "' AND Password = '" + sPassword + "'";
                    try
                    {
                        dr = (DataRow)en.ReturnObject(emrConnString, ClsUtility.theParams, sSQL, ClsUtility.ObjectEnum.DataRow, serverType);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("There is no row at position 0"))
                        {
                            MessageBox.Show(Assets.Messages.InvalidUser, Assets.Messages.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else
                        {
                            MessageBox.Show(ex.Message, Assets.Messages.ErrorHeader);
                            return false;
                        }
                    }

                    if (dr.Table.Rows.Count >= 1)
                    {
                        clsGbl.loggedInUser.UserID = Convert.ToInt16(dr["userID"]);
                        clsGbl.loggedInUser.UserName = dr["UserName"].ToString();
                        clsGbl.loggedInUser.Password = dr["Password"].ToString();
                        clsGbl.loggedInUser.FirstName = dr["UserFirstName"].ToString();
                        clsGbl.loggedInUser.LastName = dr["UserLastName"].ToString();
                        clsGbl.loggedInUser.Group = dr["GroupName"].ToString();
                        clsGbl.loggedInUser.FacilityID = Convert.ToInt16(dr["FacilityID"]);
                        clsGbl.loggedInUser.FacilityName = facilityName;
                        clsGbl.loggedInUser.MFLCode = dr["MFLCode"].ToString();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(Assets.Messages.InvalidUser, Assets.Messages.ErrorHeader);
                        return false;
                    }

                }
                else if (emr.ToLower() == "ctc2")
                {
                    DataRow dr = (DataRow)en.ReturnObject(Entity.getconnString(BusinessLayer.clsGbl.xmlPath), ClsUtility.theParams
                        , "Select ConnString,DBase,DBName From aa_Database", ClsUtility.ObjectEnum.DataRow, serverType);
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
                                if (userName != "" && password != "")
                                {

                                    foreach (DataRow row in dataFilePasswordsDataTable.Rows)
                                    {
                                        string cipherTextPassword = row["Password"].ToString();
                                        string plainTextPassword = ClsUtility.Decrypt(cipherTextPassword);
                                        //string connString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;  Data Source= {0} ;Jet OLEDB:Database Password={1};Persist Security Info=False;"
                                        //                                    , dr["DBase"], plainTextPassword);

                                        string connString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;  Data Source= {0} ;Jet OLEDB:Database Password={1};Persist Security Info=False;"
                                                                            , dr["DBase"], plainTextPassword);


                                        OleDbConnection connection = new OleDbConnection(connString);
                                        try
                                        {
                                            //OleDbConnection connection = new OleDbConnection(connString);
                                            connection.Open();
                                            using (OleDbCommand cmd = new OleDbCommand("Select * from SecurityUsers where LoginName = @Username and Password = @Password", connection))
                                            {
                                                cmd.Parameters.AddWithValue("@Username", userName);
                                                cmd.Parameters.AddWithValue("@Password", password);

                                                using (OleDbDataReader r = cmd.ExecuteReader())
                                                {
                                                    if (r.HasRows)
                                                    {
                                                        r.Read();
                                                        clsGbl.loggedInUser.UserID = Convert.ToInt16(r["UserNumber"]);
                                                        clsGbl.loggedInUser.UserName = r["LoginName"].ToString();
                                                        clsGbl.loggedInUser.Password = r["Password"].ToString();
                                                        clsGbl.loggedInUser.FirstName = r["FullName"].ToString();
                                                        clsGbl.loggedInUser.LastName = r["FullName"].ToString();
                                                        clsGbl.loggedInUser.Group = r["GroupID"].ToString();
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show(Assets.Messages.InvalidUser, Assets.Messages.ErrorHeader);
                                                        return false;
                                                    }

                                                }
                                            }
                                            //connection.Close();
                                            //connection.Dispose();
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
                                                MessageBox.Show(ex.Message, Assets.Messages.ErrorHeader);
                                                return false;
                                            }
                                        }
                                        finally
                                        {
                                            connection.Close();
                                            connection.Dispose();
                                        }
                                    }

                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, Assets.Messages.ErrorHeader);
                                return false;
                            }

                        }
                        return false;
                    }
                }
                else if (emr.ToLower() == "ctc2mysql")
                {
                    try
                    {
                        /*  USED INCASE OF ODBC CONNECTION
                       MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder (emrConnString );
                        string user = builder.UserID;
                        string pass = builder.Password;
                        string database = builder.Database;
                        string server = builder.Server;
                        string newEmrConnectionString = String.Format ( "Driver={0};Server={1};Database={2};uid={3};pwd={4}", "{MySQL ODBC 3.51 Driver}", server, database, user,pass);
                        */
                        db = new MySqlConnection(emrConnString);
                        db.Open();
                        String sql = "Select * from SecurityUsers where LoginName = @Username and Password = @Password";
                        MySqlCommand query = new MySqlCommand(sql);
                        query.Connection = db;
                        query.Parameters.AddWithValue("@Username", userName);
                        query.Parameters.AddWithValue("@Password", password);
                        MySqlDataReader queryResults = query.ExecuteReader();

                        if (queryResults.HasRows)
                        {
                            queryResults.Read();
                            clsGbl.loggedInUser.UserID = Convert.ToInt16(queryResults["UserNumber"]);
                            clsGbl.loggedInUser.UserName = queryResults["LoginName"].ToString();
                            clsGbl.loggedInUser.Password = queryResults["Password"].ToString();
                            clsGbl.loggedInUser.FirstName = queryResults["FullName"].ToString();
                            clsGbl.loggedInUser.LastName = queryResults["FullName"].ToString();
                            clsGbl.loggedInUser.Group = queryResults["GroupID"].ToString();
                            db.Close();
                            db.Dispose();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show(Assets.Messages.InvalidUser, Assets.Messages.ErrorHeader);
                            db.Close();
                            db.Dispose();
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Assets.Messages.ErrorHeader);
                        return false;
                    }
                }
                else if (emr.ToLower() == "cpad")
                {
                    DataRow dr = null;
                    string sPassword = ClsUtility.Encrypt(password);
                    //string sPassword = ClsUtility.GetSHA1Hash(password);
                    //string sSQL = "SELECT a.userID, a.UserName, a.Password, a.firstname, a.lastname, b.facilityname FROM cpad.mst_user a,(select a.facilityname from cpad.mst_facility a where configured = true limit 1)b " +
                    //        "WHERE a.DeleteFlag = false AND a.username = '" + userName + "' AND password = '" + sPassword + "' " +
                    //        "limit 1";
                    string sSQL = "SELECT a.userID, a.UserName, a.Password, a.firstname, a.lastname, b.facilityname, a.salt FROM cpad.mst_user a,(select a.facilityname from cpad.mst_facility a where configured = true limit 1)b " +
                            "WHERE a.DeleteFlag = false AND a.username = '" + userName + "' limit 1";

                    try
                    {
                       dr = (DataRow)en.ReturnObject(Entity.getconnString(BusinessLayer.clsGbl.xmlPath), ClsUtility.theParams, sSQL, ClsUtility.ObjectEnum.DataRow, serverType);
                    }
                    
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("There is no row at position 0"))
                        {
                            MessageBox.Show(Assets.Messages.InvalidUser, Assets.Messages.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else
                        {
                            MessageBox.Show(ex.Message, Assets.Messages.ErrorHeader);
                            return false;
                        }
                    }

                    if (dr.Table.Rows.Count >= 1)
                    {
                        string salt = dr["salt"].ToString();
                        string p = password + salt;
                        string s = ClsUtility.GetSHA1Hash(p);
                        if (s == dr["password"].ToString())
                        {
                            clsGbl.loggedInUser.UserID = Convert.ToInt16(dr["userID"]);
                            clsGbl.loggedInUser.UserName = dr["UserName"].ToString();
                            clsGbl.loggedInUser.Password = dr["Password"].ToString();
                            clsGbl.loggedInUser.FirstName = dr["FirstName"].ToString();
                            clsGbl.loggedInUser.LastName = dr["LastName"].ToString();
                            clsGbl.loggedInUser.FacilityName = dr["facilityname"].ToString();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show(Assets.Messages.InvalidUser, Assets.Messages.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;                          
                        }
                    }
                    else
                    {
                        MessageBox.Show(Assets.Messages.InvalidUser, Assets.Messages.ErrorHeader);
                        return false;
                    }

                }

                else return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Assets.Messages.ErrorHeader);
                return false;
            }

        }

        private bool SettingsAreValid()
        {
            try
            {
                Entity en = new Entity();

                //Check connection to IQTools database
                DataRow dr = (DataRow)en.ReturnObject(DataLayer.Entity.getconnString(BusinessLayer.clsGbl.xmlPath),
                                DataLayer.ClsUtility.theParams,
                                "Select ConnString, PMMSType, PMMS From aa_Database",
                                DataLayer.ClsUtility.ObjectEnum.DataRow, serverType);
                clsGbl.PMMS = dr["PMMS"].ToString();

                //Check connection to EMR database
                string PMMSType = dr["PMMSType"].ToString();
                if (PMMSType.ToLower() == "mssql")
                {
                    string EMRConnectionString = dr["ConnString"].ToString();
                    SqlConnection con = new SqlConnection(ClsUtility.Decrypt(EMRConnectionString) + "Connection Timeout=5");
                    con.Open();
                    con.Close();
                }
                else if (PMMSType.ToLower() == "mysql")
                {

                }

                return true;
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("Unknown database"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void activateSatelliteCombo()
        {
            if (clsGbl.PMMS.ToLower() == "iqcare")
            {
                lblFacility.Visible = true;
                cboFacility.Visible = true;


                string sql = "Select FacilityName, FacilityID FROM mst_Facility WHERE DeleteFlag = 0";
                Entity en = new Entity();

                DataRow dr = (DataRow)en.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                        , "Select ConnString,DBase,DBName From aa_Database", ClsUtility.ObjectEnum.DataRow, serverType);
                string emrConnString = ClsUtility.Decrypt(dr["ConnString"].ToString());

                DataTable dt = (DataTable)en.ReturnObject(emrConnString, ClsUtility.theParams
                    , sql, ClsUtility.ObjectEnum.DataTable, serverType);
                DataTableReader dtr = dt.CreateDataReader();
                cboFacility.Items.Clear();
                while (dtr.Read())
                {
                    cboFacility.Items.Add(dtr[0].ToString());
                }
                //if (cboFacility.Items[1].ToString() != "")
                 //   cboFacility.SelectedItem = cboFacility.Items[0];
            }
            else if (clsGbl.PMMS.ToLower() == "cpad")
            {
                lblFacility.Visible = true;
                cboFacility.Visible = true;


                string sql = "Select facilityname, facilityid FROM cpad.mst_facility WHERE configured = true";
                Entity en = new Entity();
                DataTable dt = (DataTable)en.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , sql, ClsUtility.ObjectEnum.DataTable, serverType);
                DataTableReader dtr = dt.CreateDataReader();
                cboFacility.Items.Clear();
                while (dtr.Read())
                {
                    cboFacility.Items.Add(dtr[0].ToString());
                }
                //if (cboFacility.Items[1].ToString() != "")
                //   cboFacility.SelectedItem = cboFacility.Items[0];
            }
        }

    }
}