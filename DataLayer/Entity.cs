using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using Npgsql;
using System.Configuration;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DataLayer
{
    public class Entity : ProcessBase
    {

        public Entity()
        {
        }

        private void CreateFormBuilderViews(string connString)
        {
            SqlConnection IQcareConn = new SqlConnection();
            IQcareConn.ConnectionString = connString;
            IQcareConn.Open();
            string viewsQry = @"
                    declare @tableNames Varchar(150)

                    declare tablesCursor  Cursor FOR
                    Select name from sys.tables where name like '%DTL_FB%'

                    open tablesCursor
                    Fetch next from tablesCursor into @tableNames
                    while (@@FETCH_STATUS=0)
                    BEGIN
	                    declare @id int,@column_Name varchar(100),@bindTable varchar(100),@sqlQry varchar(max);  
	                    set @sqlQry='SELECT '                          
	                    declare columnsCursor cursor for
	                    select distinct clm.ordinal_position, clm.column_name,cf.BindTable from information_schema.columns  clm
	                    left join mst_customFormField cf on clm.Column_name=cf.FieldName
	                    where clm.table_name= @tableNames order by clm.ORDINAL_POSITION
	                    open columnscursor
	                    Fetch next from columnsCursor into @id, @column_Name,@bindTable
	                    while (@@FETCH_STATUS=0)
	                    BEGIN
		                    if (@bindTable is null or @bindTable='')
		                    Begin
			                    set	@sqlQry=@sqlQry + '[' +@column_Name + '],'
		                    end
		                    else
		                    Begin
			                    set @sqlQry=@sqlQry + '(SELECT NAME FROM mst_moddecode where id=[' + @column_Name + '])[' + @column_Name + '],'
		                    end
		                    fetch columnsCursor into @id,@column_Name,@bindTable
	                    end
	                    set @sqlQry=substring(@sqlQry, 1, (len(@sqlQry) - 1)) + ' FROM [' + @tableNames +']'


                        exec('IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N''[dbo].[vw_' + @tableNames + ']''))
                        DROP VIEW [dbo].[vw_' + @tableNames + ']')
                        exec('CREATE VIEW [dbo].[vw_' + @tableNames + '] AS ' +@sqlQry);

	                        CLOSE columnsCursor;
	                        DEALLOCATE columnsCursor;
                         fetch tablesCursor into @tableNames
                        end
                        CLOSE tablesCursor;
                        DEALLOCATE tablesCursor;";
            SqlCommand mycmd = new SqlCommand(viewsQry, IQcareConn);
            int resuting = mycmd.ExecuteNonQuery();
            mycmd.Dispose();
        }

        public static string GetEMRType()
        {
            //TODO
            return "iqcare";
        }

        public static bool DropIQToolsObjects(string emrType, string serverType)
        {
            string connString = GetConnString();
            try
            {
                DataTable theDt = new DataTable(); int i = 0;
                Entity theObject = new Entity(); ClsUtility.Init_Hashtable();
                string toDrop = "Select Name FROM sys.synonyms";
                theDt = (DataTable)theObject.ReturnObject(connString, ClsUtility.theParams
                    , toDrop, ClsUtility.ObjectEnum.DataTable, serverType);
                DataTableReader dTr;
                dTr = theDt.CreateDataReader();

                if (serverType.ToLower() == "mssql" || emrType.ToLower() == "" || emrType.ToLower() == "msaccess")
                {
                    while (dTr.Read())
                    {
                        try
                        {
                            i = (int)theObject.ReturnObject(connString, ClsUtility.theParams
                          , "DROP Synonym [dbo].[" + dTr[0].ToString().Trim() + "]", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                        }
                        catch { }

                        try
                        {
                            i = (int)theObject.ReturnObject(connString, ClsUtility.theParams
                          , "DROP Table [" + dTr[0].ToString().Trim() + "]", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                        }
                        catch { }
                    }
                    try
                    {
                        i = (int)theObject.ReturnObject(connString, ClsUtility.theParams
                      , "DROP TABLE mst_Patient_decoded", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                    }
                    catch { }
                    try
                    {
                        i = (int)theObject.ReturnObject(connString, ClsUtility.theParams
                      , "DROP TABLE dtl_PatientContacts", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                    }
                    catch { }
                }
                return true;

            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Substring(0, 21) == "cannot use drop table")
                {
                    //SqlConnection cnn = new SqlConnection(Entity.getconnString(clsGbl.xmlPath));
                    //cnn.Open();
                    //SqlCommand cmm = new SqlCommand("UPDATE aa_Database Set Connstring = '' WHERE DBName = 'IQTools'"); cmm.Connection = cnn;
                    //int i = cmm.ExecuteNonQuery();
                    //cnn.Close(); cmm.Dispose(); cnn.Dispose();
                }

                return true;
            }
        }

        public static bool CreateIQToolsObjects(string emrType, string serverType)
        {
            string connString = GetConnString();
            Entity en = new Entity();
            DataRow dr = (DataRow)en.ReturnObject(connString, ClsUtility.theParams, "SELECT TOP 1 ConnString, DBase FROM aa_Database", ClsUtility.ObjectEnum.DataRow, serverType);
            string EMRDatabase = dr["DBase"].ToString();
            string EMRConnString = ClsUtility.Decrypt(dr["ConnString"].ToString());
            if (emrType.ToLower() == "iqcare")
            {
                //TODO
                //en.CreateFormBuilderViews(dr["ConnString"].ToString());
            }
            try
            {
                
                string toCreate = "select '[' + (select top 1 name from sys.servers where product = 'SQL Server') + '].[" + EMRDatabase + "].[' + b.name + '].[' + a.name + ']' s, '[' + b.name + '].[' + a.name + ']' o " +
                                    " from sys.tables a inner join sys.schemas b on a.schema_id = b.schema_id where a.name not like 'sys%' " +
                                    " union " +
                                    " select '[' + (select top 1 name from sys.servers where product = 'SQL Server') +'].[" + EMRDatabase + "].[' + b.name + '].[' + a.name + ']' s, '[' + b.name + '].[' + a.name + ']' o " +
                                    " from sys.views a inner " +
                                    " join sys.schemas b on a.schema_id = b.schema_id where a.name not like 'sys%' ";
                DataTable dt = (DataTable)en.ReturnObject(EMRConnString, null, toCreate, ClsUtility.ObjectEnum.DataTable, serverType);
                DataTableReader dreader = dt.CreateDataReader();
                while (dreader.Read())
                {
                    string createSynonym = "CREATE SYNONYM " + dreader["o"].ToString() + "FOR " + dreader["s"].ToString();
                    int i = (int)en.ReturnObject(connString, ClsUtility.theParams, createSynonym, ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string getconnString(string xmlPath)
        {
            //XmlDocument theXML = new XmlDocument();
            //theXML.Load(xmlPath);
            //XmlNode nd = theXML.SelectSingleNode("//add[@key='IQToolconstr']"); //get the node with an attribute of “key” =  IQToolconstr
            //if (nd != null)
            //{
            //    return ClsUtility.Decrypt(nd.Attributes["value"].Value); //return the value of the value attribute of this node
            //}
            //return "";
            return GetConnString();
        }

        public static string GetConnString()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = configFile.AppSettings.Settings;
            return ClsUtility.Decrypt(appSettings["ConnectionString"].Value);
        }

        public static void SetConnString(string ConnectionString)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = configFile.AppSettings.Settings;
            appSettings["ConnectionString"].Value = ClsUtility.Encrypt(ConnectionString);
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        public static void SetEMRConnString(string IQToolsConnectionString, string EMRConnectionString
            , string IPAddress, string EMRDB, string EMRType, string ServerType, string EMRVersion)
        {
            try {
                Entity en = new Entity();
                ClsUtility.Init_Hashtable();
                string sql = "UPDATE aa_Database SET "
                                                + "IPAddress = '" + IPAddress + "', "
                                                + "DBase = '" + EMRDB + "',  connString='"
                                                + ClsUtility.Encrypt(EMRConnectionString) + "', PMMSType = '" + ServerType
                                                + "', IQStatus='No Data', UpdateDate=Null, PMMS = '" + EMRType + "',EMRVersion = '"
                                                + EMRVersion + "' WHERE DBName='IQTools'";
                int i = (int)en.ReturnObject(IQToolsConnectionString, ClsUtility.theParams
                                                , sql
                                                , ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void SetServerType(string ServerType)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = configFile.AppSettings.Settings;
            appSettings["ServerType"].Value = ServerType;
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        public static string GetServerType()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = configFile.AppSettings.Settings;
            return appSettings["ServerType"].Value.ToLower();
        }

        public static string GetRefreshRights()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = configFile.AppSettings.Settings;
            return appSettings["AllowRefresh"].Value.ToLower();
        }

        public static string GetDevRights()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = configFile.AppSettings.Settings;
            return appSettings["Development"].Value.ToLower();
        }

        public static string getServerType(string xmlPath)
        {
            //XmlDocument theXML = new XmlDocument();
            //theXML.Load(xmlPath);
            //XmlNode nd = theXML.SelectSingleNode("//add[@key='ServerType']");
            //if (nd != null)
            //{
            //    return nd.Attributes["value"].Value; //return the value of the value attribute of this node
            //}
            //return "";
            return GetServerType();
        }

        public static string getDevelopmentRight(string xmlPath)
        {
            //XmlDocument theXML = new XmlDocument();
            //theXML.Load(xmlPath);
            //XmlNode nd = theXML.SelectSingleNode("//add[@key='Development']");
            //if (nd != null)
            //{
            //    return nd.Attributes["value"].Value; //return the value of the value attribute of this node
            //}
           
            return GetDevRights();
        }

        public static string getRefreshRights(string xmlPath)
        {
            //XmlDocument theXML = new XmlDocument();
            //theXML.Load(xmlPath);
            //XmlNode nd = theXML.SelectSingleNode("//add[@key='AllowRefresh']");
            //if (nd != null)
            //{
            //    return nd.Attributes["value"].Value; //return the value of the value attribute of this node
            //}
            //return "";
            return GetRefreshRights();
        }

        public object ReturnObject(string ConString, Hashtable Params, string CommandText, ClsUtility.ObjectEnum Obj, string pmmsType)
        {
            switch (pmmsType.Trim().ToLower())

            {
                case "mssql":
                    {
                        return MsSQLObject(ConString, Params, CommandText, Obj);
                    }
                case "mysql":
                    {
                        return MySQLObject(ConString, Params, CommandText, Obj);
                    }
                case "pgsql":
                    {
                        return PgSQLObject(ConString, Params, CommandText, Obj);
                    }
                case "access":
                    {
                        return AccessObject(ConString, Params, CommandText, Obj);
                    }
                default:
                    {
                        return MsSQLObject(ConString, Params, CommandText, Obj);
                    }

            }

        }

        private object MsSQLObject(string ConString, Hashtable Params, string CommandText, ClsUtility.ObjectEnum Obj)
        {
            int i;
            string cmdpara, cmdvalue, cmddbtype;
            SqlCommand theCmd = new SqlCommand();
            SqlTransaction theTran = (SqlTransaction)this.Transaction;
            SqlConnection cnn;

            if (null == this.Connection)
            {
                cnn = (SqlConnection)GetConnection(ConString, "mssql");
            }
            else
            {
                cnn = (SqlConnection)this.Connection;
            }

            if (null == this.Transaction)
            {
                theCmd = new SqlCommand(CommandText, cnn);
            }
            else
            {
                theCmd = new SqlCommand(CommandText, cnn, theTran);
            }
            if (Params != null)
            {
                for (i = 1; i <= Params.Count;)
                {
                    cmdpara = Params[i].ToString();
                    cmddbtype = Params[i + 1].ToString();
                    cmdvalue = Params[i + 2].ToString();
                    theCmd.Parameters.AddWithValue(cmdpara, cmddbtype).Value = cmdvalue;
                    i = i + 3;
                }
            }
            theCmd.CommandTimeout = 0;
            theCmd.CommandType = CommandType.StoredProcedure;
            string theSubstring = CommandText.Substring(0, 6).ToUpper();
            switch (theSubstring)
            {
                case "SELECT":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "UPDATE":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "RESTOR":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "INSERT":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "DELETE":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "CREATE":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "DROP S":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "DROP V":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "DBCC C":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "DBCC S":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "BACKUP":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "EXEC S":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "SET DA":
                    theCmd.CommandType = CommandType.Text;
                    break;
                    //case "WITH I"://TODO DONE for common table expressions start with an I for the CTE name
                    //    theCmd.CommandType = CommandType.Text;
                    //    break;
            }
            if (CommandText.Substring(0, 4).ToUpper() == "WITH") //CTE
                theCmd.CommandType = CommandType.Text;
            if (CommandText.IndexOf("SET OFFLINE") > 0 || CommandText.IndexOf("SET ONLINE") > 0)
                theCmd.CommandType = CommandType.Text;
            if (CommandText.Length >= 15)
            { if (CommandText.Substring(0, 15).ToUpper() == "DROP TABLE [TMP" || CommandText.Substring(0, 15).ToUpper() == "DROP TABLE [MGR" || CommandText.Substring(0, 15).ToUpper() == "DROP TABLE [TPS") theCmd.CommandType = CommandType.Text; }
            if (CommandText.Length >= 10)
            { if (CommandText.Substring(0, 10).ToUpper() == "DROP SYNON") theCmd.CommandType = CommandType.Text; }
            if (CommandText.Length >= 22)
            { if (CommandText.Substring(0, 22).ToUpper() == "DROP TABLE MST_PATIENT") theCmd.CommandType = CommandType.Text; }
            if (CommandText.Length >= 30)
            { if (CommandText.Substring(0, 30).ToUpper() == "DROP TABLE DTL_PATIENTCONTACTS") theCmd.CommandType = CommandType.Text; }



            theCmd.Connection = cnn;

            try
            {
                SqlCommand cm;
                if (ClsUtility.SDate != "")
                {
                    cm = new SqlCommand("SET Dateformat " + ClsUtility.SDate, cnn);
                    cm.ExecuteNonQuery();
                    cm.Dispose();
                }
                cm = null;
                if (Obj == ClsUtility.ObjectEnum.DataSet)
                {
                    SqlDataAdapter theAdpt = new SqlDataAdapter(theCmd);
                    DataSet theDS = new DataSet();
                    //theDS.Tables[0].BeginLoadData();
                    theAdpt.Fill(theDS);
                    //theDS.Tables[0].EndLoadData();
                    return theDS;
                }

                if (Obj == ClsUtility.ObjectEnum.DataTable)
                {
                    SqlDataAdapter theAdpt = new SqlDataAdapter(theCmd);
                    DataTable theDT = new DataTable();
                    theDT.BeginLoadData();
                    theAdpt.Fill(theDT);
                    theDT.EndLoadData();
                    return theDT;
                }

                if (Obj == ClsUtility.ObjectEnum.DataRow)
                {
                    SqlDataAdapter theAdpt = new SqlDataAdapter(theCmd);
                    DataTable theDT = new DataTable();
                    theDT.BeginLoadData();
                    theAdpt.Fill(theDT);
                    theDT.EndLoadData();
                    return theDT.Rows[0];
                }

                if (Obj == ClsUtility.ObjectEnum.ExecuteNonQuery)
                {
                    int NoRowsAffected = theCmd.ExecuteNonQuery();
                    return NoRowsAffected;
                }

                if (null == this.Connection)
                    cnn.Close();
                return 0;
            }
            catch (Exception err)
            {
                throw err;
                //return null;
            }

            finally
            {
                if (null != cnn)
                    if (null == this.Connection)
                        cnn.Close();
            }
        }

        private object MySQLObject(string ConString, Hashtable Params, string CommandText, ClsUtility.ObjectEnum Obj)
        {
            int i;
            string cmdpara, cmdvalue, cmddbtype;
            MySqlCommand theCmd = new MySqlCommand();
            MySqlTransaction theTran = (MySqlTransaction)this.Transaction;
            MySqlConnection cnn;


            if (null == this.Connection)
            {

                cnn = (MySqlConnection)GetConnection(ConString, "mysql");
            }



            else
            {
                cnn = (MySqlConnection)this.Connection;
            }

            if (null == this.Transaction)
            {
                theCmd = new MySqlCommand(CommandText, cnn);
            }
            else
            {
                theCmd = new MySqlCommand(CommandText, cnn, theTran);
            }

            for (i = 1; i < Params.Count;)
            {
                cmdpara = Params[i].ToString();
                cmddbtype = Params[i + 1].ToString();
                cmdvalue = Params[i + 2].ToString();
                theCmd.Parameters.AddWithValue(cmdpara, cmddbtype).Value = cmdvalue;
                i = i + 3;
            }
            theCmd.CommandTimeout = 0;
            theCmd.CommandType = CommandType.StoredProcedure;
            string theSubstring = CommandText.Substring(0, 6).ToUpper();
            switch (theSubstring)
            {
                case "SELECT":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "CREATE":
                    theCmd.CommandType = CommandType.Text;
                    break;

            }
            if (CommandText.Length >= 10)
            {
                if (CommandText.Substring(0, 15).ToUpper() == "DROP TABLE `TMP"
                  || CommandText.Substring(0, 15).ToUpper() == "DROP TABLE `MGR"
                  || CommandText.Substring(0, 15).ToUpper() == "DROP TABLE `TPS"
                  || CommandText.Substring(0, 15).ToUpper() == "DROP PROCEDURE "
                  || CommandText.Substring(0, 13).ToUpper() == "DROP FUNCTION"
                  || CommandText.Substring(0, 14).ToUpper() == "DELETE FROM AA"
                  || CommandText.Substring(0, 14).ToUpper() == "INSERT INTO AA"
                  || CommandText.Substring(0, 10).ToUpper() == "UPDATE AA_"
                  || CommandText.Substring(0, 14).ToUpper() == "SHOW DATABASES"
                  || CommandText.Substring(0, 19).ToUpper() == "DROP SCHEMA IQTOOLS"
                  || CommandText.Substring(0, 21).ToUpper() == "CREATE SCHEMA IQTOOLS"
                  || CommandText.Substring(0, 24).ToUpper() == "REPLACE INTO aa_Database"
                  )

                    theCmd.CommandType = CommandType.Text;
            }

            theCmd.Connection = cnn;

            try
            {
                if (Obj == ClsUtility.ObjectEnum.DataSet)
                {
                    MySqlDataAdapter theAdpt = new MySqlDataAdapter(theCmd);
                    DataSet theDS = new DataSet();
                    theDS.Tables[0].BeginLoadData();
                    theAdpt.Fill(theDS);
                    theDS.Tables[0].EndLoadData();
                    return theDS;
                }

                if (Obj == ClsUtility.ObjectEnum.DataTable)
                {
                    MySqlDataAdapter theAdpt = new MySqlDataAdapter(theCmd);
                    DataTable theDT = new DataTable();
                    theDT.BeginLoadData();
                    theAdpt.Fill(theDT);
                    theDT.EndLoadData();
                    return theDT;
                }

                if (Obj == ClsUtility.ObjectEnum.DataRow)
                {
                    MySqlDataAdapter theAdpt = new MySqlDataAdapter(theCmd);
                    DataTable theDT = new DataTable();
                    theDT.BeginLoadData();
                    theAdpt.Fill(theDT);
                    theDT.EndLoadData();
                    return theDT.Rows[0];
                }

                if (Obj == ClsUtility.ObjectEnum.ExecuteNonQuery)
                {
                    int NoRowsAffected = theCmd.ExecuteNonQuery();
                    return NoRowsAffected;
                }

                if (null == this.Connection)
                    cnn.Close();
                return 0;
            }
            catch (Exception err)
            {
                throw err;
            }

            finally
            {
                if (null != cnn)
                    if (null == this.Connection)
                        cnn.Close();
            }
        }

        private object PgSQLObject(string ConString, Hashtable Params, string CommandText, ClsUtility.ObjectEnum Obj)
        {
            int i;
            string cmdpara, cmdvalue, cmddbtype;
            CommandText = CommandText.ToLower();
            NpgsqlConnection conn = new NpgsqlConnection(ConString);
            conn.Open();
            NpgsqlTransaction tran = conn.BeginTransaction();
            NpgsqlCommand theCmd = new NpgsqlCommand(CommandText, conn);
            theCmd.CommandType = CommandType.StoredProcedure;
            string theSubstring = CommandText.Substring(0, 6).ToUpper();
            switch (theSubstring)
            {
                case "SELECT":
                    theCmd.CommandType = CommandType.Text;
                    break;
            }
            if (CommandText.Substring(0, 14).ToUpper() == "UPDATE IQTOOLS")
                theCmd.CommandType = CommandType.Text;

            if (CommandText.Substring(0, 4).ToUpper() == "WITH") //CTE
                theCmd.CommandType = CommandType.Text;

            for (i = 1; i <= Params.Count;)
            {

                cmdpara = Params[i].ToString();
                if (cmdpara.Contains("@"))
                {
                    cmdpara = cmdpara.Substring(1, cmdpara.Length - 1);
                }
                cmddbtype = Params[i + 1].ToString();
                cmdvalue = Params[i + 2].ToString();
                theCmd.Parameters.AddWithValue(cmdpara, cmddbtype).Value = cmdvalue;
                i = i + 3;
            }
            try
            {

                if (Obj == ClsUtility.ObjectEnum.DataSet)
                {
                    DataSet ds = new DataSet();
                    int j = 0;
                    int k = 0;
                    NpgsqlDataReader dr = theCmd.ExecuteReader();
                    for (j = 0; j <= 10; j++)
                    {
                        if (!dr.IsClosed)
                        { dr.Close(); }
                        dr = theCmd.ExecuteReader();

                        for (k = 0; k < j; k++)
                        {
                            dr.NextResult();
                        }
                        //if (dr.HasRows)
                        //{
                        ds.Tables.Add();
                        //if (dr.HasRows)
                        //{
                        ds.Tables[j].Load(dr);
                        //}
                        //}
                        //else
                        //{
                        //  break;
                        //}

                    }
                    //tran.Commit();
                    return ds;
                }

                if (Obj == ClsUtility.ObjectEnum.DataTable)
                {

                    DataTable theDT = new DataTable();
                    NpgsqlDataReader dr = theCmd.ExecuteReader();
                    theDT.Load(dr);
                    tran.Commit();
                    return theDT;
                }

                if (Obj == ClsUtility.ObjectEnum.DataRow)
                {
                    DataTable theDT = new DataTable();
                    NpgsqlDataReader dr = theCmd.ExecuteReader();
                    theDT.Load(dr);
                    return theDT.Rows[0];
                }

                if (Obj == ClsUtility.ObjectEnum.ExecuteNonQuery)
                {
                    int NoRowsAffected = theCmd.ExecuteNonQuery();
                    tran.Commit();
                    return NoRowsAffected;
                }
                return 0;
            }
            catch (Exception err)
            {
                throw err;
            }

            finally
            {
                conn.Close();
            }
        }

        private object AccessObject(string ConString, Hashtable Params, string CommandText, ClsUtility.ObjectEnum Obj)
        {
            return null;
        }

        public static object getdbConn(SqlConnection conn, string pmm)
        {
            string connStr; string pmmType;
            connStr = ""; pmmType = "";

            try
            {
                SqlCommand comm;
                if (pmm == "msaccess")
                { comm = new SqlCommand("SELECT connString, PMMSType From aa_Database WHERE DbName = '" + "IQTools" + "'", conn); }
                else
                { comm = new SqlCommand("SELECT connString, PMMSType From aa_Database WHERE DbName = '" + pmm + "'", conn); }
                SqlDataReader sDR = comm.ExecuteReader();
                while (sDR.Read())
                {
                    connStr = ClsUtility.Decrypt(sDR[0].ToString());
                    if (pmm == "msaccess")
                    { pmmType = "msaccess"; }
                    else
                    { pmmType = sDR[1].ToString(); }
                    break;
                }
            }
            catch (Exception ex)
            {
                connStr = ex.Message;
                connStr = "";
            }

            return GetConnection(connStr, pmmType);
        }

        public static object getdbConn(NpgsqlConnection conn, string pmm)
        {
            string connStr; string pmmType;
            connStr = ""; pmmType = "";

            try
            {
                NpgsqlCommand comm;

                comm = new NpgsqlCommand("SELECT connString, PMMSType From iqtools.aa_Database WHERE DbName = '" + pmm + "'", conn);
                NpgsqlDataReader sDR = comm.ExecuteReader();
                while (sDR.Read())
                {
                    connStr = ClsUtility.Decrypt(sDR[0].ToString());
                    pmmType = sDR[1].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                connStr = ex.Message;
                connStr = "";
            }

            return GetConnection(connStr, pmmType);
        }

        public static object getdbConn(MySqlConnection conn, string pmm)
        {
            string connStr; string pmmType;
            connStr = ""; pmmType = "";

            try
            {
                MySqlCommand comm;
                if (pmm == "msaccess")
                { comm = new MySqlCommand("SELECT connString, PMMSType From aa_Database WHERE DbName = '" + "IQTools" + "'", conn); }
                else
                { comm = new MySqlCommand("SELECT connString, PMMSType From aa_Database WHERE DbName = '" + pmm + "'", conn); }
                MySqlDataReader sDR = comm.ExecuteReader();
                while (sDR.Read())
                {
                    connStr = ClsUtility.Decrypt(sDR[0].ToString());
                    if (pmm == "msaccess")
                    { pmmType = "msaccess"; }
                    else
                    { pmmType = sDR[1].ToString(); }
                    break;
                }
            }
            catch (Exception ex)
            {
                connStr = ex.Message;
                connStr = "";
            }

            return GetConnection(connStr, pmmType);
        }

        public static string getdbConnString(SqlConnection conn, string pmm)
        {
            string connStr;
            connStr = "";

            try
            {
                SqlCommand comm = new SqlCommand("SELECT connString From aa_Database WHERE DbName = '" + pmm + "'", conn);
                SqlDataReader sDR = comm.ExecuteReader();
                while (sDR.Read())
                {
                    connStr = ClsUtility.Decrypt(sDR[0].ToString()); //+ "Allow User Variables=True";
                    break;
                }
            }
            catch (Exception ex)
            {
                connStr = ex.Message;
                connStr = "";
            }
            return connStr;
        }

        public static object GetConnection(string ConString, string dbType)
        {
            switch (dbType)
            {
                case "mssql":
                    {
                        SqlConnection connection = new SqlConnection(ConString);
                        connection.Open();
                        return connection;
                    }
                case "mysql":
                    {
                        MySqlConnection connection = new MySqlConnection(ConString);
                        connection.Open();
                        return connection;
                    }

                case "msaccess":
                    {
                        OleDbConnection connection = new OleDbConnection(ConString);
                        connection.Open();
                        return connection;
                    }
                case "pgsql":
                    {
                        NpgsqlConnection connection = new NpgsqlConnection(ConString);
                        connection.Open();
                        return connection;
                    }
                default:
                    {
                        SqlConnection connection = new SqlConnection(ConString);
                        connection.Open();
                        return connection;
                    }
            }
        }

        public static string getdbConnString(MySqlConnection conn, string pmm)
        {
            string connStr;
            connStr = "";

            try
            {
                MySqlCommand comm = new MySqlCommand("SELECT connString From aa_Database WHERE DbName = '" + pmm + "'", conn);
                MySqlDataReader sDR = comm.ExecuteReader();
                while (sDR.Read())
                {
                    connStr = ClsUtility.Decrypt(sDR[0].ToString()); //+ "Allow User Variables=True";
                    break;
                }
            }
            catch (Exception ex)
            {
                connStr = ex.Message;
                connStr = "";
            }
            return connStr;
        }

        public static string getdbConnString(NpgsqlConnection conn, string pmm)
        {
            string connStr;
            connStr = "";

            try
            {
                NpgsqlCommand comm = new NpgsqlCommand("SELECT connString From iqtools.aa_Database WHERE DbName = '" + pmm + "'", conn);
                NpgsqlDataReader sDR = comm.ExecuteReader();
                while (sDR.Read())
                {
                    connStr = ClsUtility.Decrypt(sDR[0].ToString()); //+ "Allow User Variables=True";
                    break;
                }
            }
            catch (Exception ex)
            {
                connStr = ex.Message;
                connStr = "";
            }
            return connStr;
        }

        public static string getRemoteServiceURL(string xmlPath)
        {
            //XmlDocument theXML = new XmlDocument();
            //theXML.Load(xmlPath);
            //XmlNode nd = theXML.SelectSingleNode("//add[@key='RemoteWebServiceURL']");
            //if (nd != null)
            //{
            //    return nd.Attributes["value"].Value; //return the value of the value attribute of this node
            //}
            //return "";
            return GetRemoteServiceURL();
        }

        public static string GetRemoteServiceURL()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = configFile.AppSettings.Settings;
            return appSettings["RemoteWebServiceURL"].Value.ToLower();
        }

        private static void BackupIQToolsDB(string dbName, string Server, string User, string Password)
        {
            try
            {
                ServerConnection srvConn = new ServerConnection(Server);
                srvConn.LoginSecure = false;
                srvConn.Login = User;
                srvConn.Password = Password;
                Server s = new Server(srvConn);
                string BackupPath = s.BackupDirectory;
                
                string backupSQL = "IF EXISTS(Select name from sys.databases where name = '" + dbName + "') BEGIN " +
                                "BACKUP DATABASE [" + dbName + "]" +
                               "TO DISK = N'" + BackupPath + "\\" + dbName + "_Backup.bak' " +
                               "WITH NOFORMAT, INIT,  " +
                               "NAME = N'IQTools-Full Database Backup', " +
                               "SKIP, NOREWIND, NOUNLOAD END";

                srvConn.ExecuteNonQuery(backupSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void UpdateIQToolsDB(string dbName, string Server, string User, string Password)
        {
           
            try
            {
                ServerConnection srvConn = new ServerConnection(Server);
                srvConn.LoginSecure = false;
                srvConn.Login = User;
                srvConn.Password = Password;
                Server s = new Server(srvConn);
                //string createPath = s.Settings.DefaultFile;
                //string createPath = "C:\\Cohort\\DataFiles\\Database\\DataFiles";

                //C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\

                //string createSQL = "IF NOT EXISTS (Select name from sys.databases where name = '" + dbName + "') BEGIN " +
                //   "CREATE DATABASE [" + dbName + "] " +
                //   "ON  PRIMARY " +
                //   "( NAME = N'IQTools', FILENAME = N'" + createPath + "\\" + dbName + ".mdf' " +
                //   ", SIZE = 3072KB , FILEGROWTH = 1024KB ) " +
                //   "  LOG ON " +
                //   "( NAME = N'IQTools_log', FILENAME = N'" + createPath + "\\" + dbName + "_log.ldf' " +
                //   ", SIZE = 4096KB , FILEGROWTH = 10%) END";
                string createSQL = "IF NOT EXISTS (Select name from sys.databases where name = '" + dbName + "') CREATE DATABASE [" + dbName + "]";
               
                try
                {
                    srvConn.ExecuteNonQuery(createSQL);
                    srvConn.Disconnect();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(createSQL + " - " + ex.Message);
                }
                
                string TableDef = "DB\\IQCare\\Tables.sql";
                string FunctionDef = "DB\\IQCare\\Functions.sql";
                string ProcDef = "DB\\IQCare\\Procedures.sql";
                string TableData = "DB\\IQCare\\TableData.sql";

                srvConn = new ServerConnection(Server);
                srvConn.LoginSecure = false;
                srvConn.Login = User;
                srvConn.Password = Password;
                srvConn.DatabaseName = dbName;

                //FileInfo fi = new FileInfo("C:\\Cohort\\DataFiles\\Database\\IQToolsMsSQL.sql");
                FileInfo tables = new FileInfo(TableDef);
                string tablesScript = tables.OpenText().ReadToEnd();
                srvConn.ExecuteNonQuery(tablesScript);

                FileInfo functions = new FileInfo(FunctionDef);
                string functionsScript = functions.OpenText().ReadToEnd();
                srvConn.ExecuteNonQuery(functionsScript);

                FileInfo procs = new FileInfo(ProcDef);
                string procsScript = procs.OpenText().ReadToEnd();
                srvConn.ExecuteNonQuery(procsScript);

                FileInfo tData = new FileInfo(TableData);
                string tDataScript = tData.OpenText().ReadToEnd();
                srvConn.ExecuteNonQuery(tDataScript);

                srvConn.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString(), "Updating IQtools");
                throw ex;
            }
        }

        public static bool CreateIQToolsDB(string EMRServerType, string IQToolsUser, string IQToolsServer, string IQToolsPassword
            , string IQToolsDB, string EMR)
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
                    catch { }
                    if (logicalname.Trim().ToLower().Contains("iqtools") || logicalname.Trim().ToLower() == "")
                    {                      
                        if (EMRServerType.ToLower() == "microsoft sql server")
                        {
                            #region SQL_Server
                            try
                            {
                                if (EMR.ToLower() == "iqcare")
                                {
                                    try {
                                        BackupIQToolsDB(IQToolsDB, IQToolsServer, IQToolsUser, IQToolsPassword);
                                    }
                                    catch(Exception ex)
                                    {
                                        MessageBox.Show("Backup " + ex.Message);
                                    }
                                    try {
                                        UpdateIQToolsDB(IQToolsDB, IQToolsServer, IQToolsUser, IQToolsPassword);
                                    }
                                    catch(Exception ex)
                                    { MessageBox.Show(ex.Message); }
                                }
                                else if (EMR.ToLower() == "icap")
                                {
                                    //clsGbl.ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQToolsICAP.zip";
                                    //using (ZipFile zip1 = ZipFile.Read(clsGbl.ToUnPack))
                                    //{
                                    //    foreach (ZipEntry e in zip1)
                                    //    {
                                    //        e.Extract("C:\\Cohort\\DataFiles\\Database\\", ExtractExistingFileAction.OverwriteSilently);
                                    //    }
                                    //    try { System.IO.File.Delete(@"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak"); }
                                    //    catch { }
                                    //    System.IO.File.Move(@"C:\\Cohort\\DataFiles\\Database\\IQToolsICAP.Bak", @"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak");

                                    //}
                                }
                                else if (EMR.ToLower() == "smartcare")
                                {
                                    BackupIQToolsDB(IQToolsDB, IQToolsServer, IQToolsUser, IQToolsPassword);
                                    UpdateIQToolsDB(IQToolsDB, IQToolsServer, IQToolsUser, IQToolsPassword);

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
                                    return false;
                                }

                            }
                            catch(Exception ex)                            {
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
                                    //String ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQToolsISante.zip";
                                    //using (ZipFile zip1 = ZipFile.Read(ToUnPack))
                                    //{
                                    //    foreach (ZipEntry e in zip1)
                                    //    {
                                    //        e.Extract("C:\\Cohort\\DataFiles\\Database\\", ExtractExistingFileAction.OverwriteSilently);
                                    //    }
                                    //    try { System.IO.File.Delete(@"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak"); }
                                    //    catch { }
                                    //    System.IO.File.Move(@"C:\\Cohort\\DataFiles\\Database\\IQToolsISante.Bak", @"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak");
                                    //}
                                }
                                catch 
                                {
                                    return false;
                                }
                            }
                            else if (EMR.ToLower() == "ctc2mysql")
                            {
                                try
                                {
                                    //String ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQToolsCTC2MySQL.zip";
                                    //using (ZipFile zip1 = ZipFile.Read(ToUnPack))
                                    //{
                                    //    foreach (ZipEntry e in zip1)
                                    //    {
                                    //        e.Extract("C:\\Cohort\\DataFiles\\Database\\", ExtractExistingFileAction.OverwriteSilently);
                                    //    }
                                    //    try { System.IO.File.Delete(@"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak"); }
                                    //    catch { }
                                    //    System.IO.File.Move(@"C:\\Cohort\\DataFiles\\Database\\IQToolsCTC2MySQL.Bak", @"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak");
                                    //}
                                }
                                catch 
                                {
                                    return false;
                                }
                            }
                            #endregion MySQL_Server
                        }
                        else if (EMRServerType.ToLower() == "microsoft access" && EMR.ToLower() == "ctc2")
                        {
                            try
                            {
                                BackupIQToolsDB(IQToolsDB, IQToolsServer, IQToolsUser, IQToolsPassword);
                                UpdateIQToolsDB(IQToolsDB, IQToolsServer, IQToolsUser, IQToolsPassword);

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
                            catch 
                            {
                                return false;
                            }
                        }
                        else if (EMRServerType.ToLower() == "microsoft access" && EMR.ToLower() == "iqchart")
                        {
                            try
                            {
                                //String ToUnPack = "C:\\Cohort\\DataFiles\\Database\\IQToolsIQChart.zip";
                                //using (ZipFile zip1 = ZipFile.Read(ToUnPack))
                                //{
                                //    foreach (ZipEntry e in zip1)
                                //    {
                                //        e.Extract("C:\\Cohort\\DataFiles\\Database\\", ExtractExistingFileAction.OverwriteSilently);
                                //    }
                                //    try { System.IO.File.Delete(@"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak"); }
                                //    catch { }
                                //    System.IO.File.Move(@"C:\\Cohort\\DataFiles\\Database\\IQToolsIQChart.Bak", @"C:\\Cohort\\DataFiles\\Database\\IQTools.Bak");
                                //}
                            }
                            catch 
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex) { throw ex; }
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static void UpdateIQToolsSchema(string connString)
        {
            string createSQL = "CREATE SCHEMA IF NOT EXISTS iqtools AUTHORIZATION iqtools;";
            try
            {

                NpgsqlConnection srvConn = new NpgsqlConnection(connString);
                srvConn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(createSQL, srvConn);
                cmd.ExecuteNonQuery();

                //string sqlFile = "C:\\Cohort\\DataFiles\\Database\\IQToolsPgSQL.zip";
                //UnzipFile(sqlFile);
                FileInfo fi = new FileInfo("DB\\CPAD\\IQToolsPgSQL.sql");
                string updateScript = fi.OpenText().ReadToEnd();

                NpgsqlCommand updatecmd = new NpgsqlCommand(updateScript, srvConn);
                updatecmd.ExecuteNonQuery();
                srvConn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void SetMySQLDB(bool newDB, string EMR, string IQToolsDB, string EMRServer, string EMRUser, string EMRPass, string EMRDB)
        {
            string mySQLConnString = "Server=" + EMRServer + ";Uid=" + EMRUser + ";Pwd=" + EMRPass + ";";
            string emrConnString = "Server=" + EMRServer + ";Uid=" + EMRUser + ";Pwd=" + EMRPass + ";Database=" + EMRDB + "; Allow User Variables=TRUE;";
            string iqtConnString = "Server=" + EMRServer + ";Uid=" + EMRUser + ";Pwd=" + EMRPass + ";Database=" + IQToolsDB + "; Allow User Variables=TRUE;";

            Entity en = new Entity();
            ClsUtility.Init_Hashtable();
            int i = 0;

            if (newDB)
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
                    if (ex.Message.Contains("doesn't exist") || ex.Message.Contains("cannot be found"))
                    {
                        //MessageBox.Show("Do Nothing?"); 
                    }
                    else
                        throw ex;
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
                    throw ex;
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
                    throw ex;
                }

            }

            //Then save connection strings

            try
            {
                //IQTools ConnString to xml  

                SetConnString(iqtConnString);
                SetServerType("mysql");

                //EMR ConnString to aa_Database
                string encryptEMRConnString = ClsUtility.Encrypt(emrConnString);
                i = 0;
                string updateSQL = "UPDATE aa_Database Set DBName='" + IQToolsDB + "' , Server= '" + EMRServer + "', ConnString= '" + encryptEMRConnString + "', DBase='" + EMRDB + "' , UpdateDate=Now(), CreateDate=Now(), PMMSType='mysql', IQStatus='No Data', PMMS= '" + EMR + "'";
                i = (int)en.ReturnObject(iqtConnString, ClsUtility.theParams, updateSQL, ClsUtility.ObjectEnum.ExecuteNonQuery, "mysql");
              
            }
            catch (Exception ex) { throw ex; }
        }

        private static void recreateDBODatabase(string mySQLConnString, string iqtConnString)
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
                throw ex;
            }

        }

        public static bool ValidateSettings(string serverType)
        {
            try
            {
                Entity en = new Entity();
                DataRow dr = (DataRow)en.ReturnObject(Entity.GetConnString(),
                                ClsUtility.theParams,
                                "Select ConnString, PMMSType, PMMS From aa_Database",
                                ClsUtility.ObjectEnum.DataRow, serverType);  

                string PMMSType = dr["PMMSType"].ToString();
                if (PMMSType.ToLower() == "mssql")
                {
                    string EMRConnectionString = dr["ConnString"].ToString();
                    SqlConnection con = new SqlConnection(ClsUtility.Decrypt(EMRConnectionString) + ";Connection Timeout=5");
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

        private DataType GetDataType(string dataType)
        {
            DataType DTTemp = null;

            switch (dataType)
            {
                case ("System.Decimal"):
                    DTTemp = DataType.Decimal(2, 18);
                    break;
                case ("System.Byte"):
                    DTTemp = DataType.TinyInt;
                    break;
                case ("System.Boolean"):
                    DTTemp = DataType.Bit;
                    break;
                case ("System.String"):
                    DTTemp = DataType.NVarChar(255);
                    break;
                case ("System.Int16"):
                    DTTemp = DataType.SmallInt;
                    break;
                case ("System.Int32"):
                    DTTemp = DataType.Int;
                    break;
                case ("System.Int64"):
                    DTTemp = DataType.BigInt;
                    break;
                case ("System.DateTime"):

                    DTTemp = DataType.DateTime;
                    break;
                case ("System.Double"):
                    DTTemp = DataType.Float;
                    break;
                case ("System.Single"):
                    DTTemp = DataType.Real;
                    break;
                default:
                    DTTemp = DataType.Variant;
                    break;
            }
            return DTTemp;
        }

        private string GetDBDataType(string dataType)
        {
            string type = "TEXT";
            switch (dataType)
            {
                case ("System.Decimal"):
                case ("System.Double"):
                case ("System.Single"):
                    type = "DECIMAL";
                    break;

                case ("System.Boolean"):
                    type = "BIT";
                    break;

                case ("System.String"):
                    type = "NVARCHAR(255)";
                    break;

                case ("System.Int16"):
                case ("System.Int32"):
                case ("System.Int64"):
                case ("System.Byte"):
                    type = "INT";
                    break;

                case ("System.DateTime"):
                    type = "DATETIME";
                    break;
            }
            return type;
        }

        public bool crtTable(string connString, string tblName, DataTable theDt, string emrType)
        {            
            Server svr = new Server(new ServerConnection(new SqlConnection(connString)));
            Microsoft.SqlServer.Management.Smo.Database db = svr.Databases[getConnItem("database", new SqlConnection(connString))];
            Microsoft.SqlServer.Management.Smo.Table tmp = new Microsoft.SqlServer.Management.Smo.Table(db, tblName);
            Column tmpC = new Column();
            string dataType;

            if (emrType.ToLower() == "ctc2")
            {
                try
                {
                    StringBuilder sBuilder = new StringBuilder();
                    sBuilder.Append(String.Format("CREATE TABLE [{0}] (", tblName));
                    string columnName = theDt.Columns[0].ColumnName;
                    dataType = GetDBDataType(theDt.Columns[0].DataType.ToString());
                    sBuilder.Append(String.Format("[{0}] {1} NULL", columnName, dataType));

                    for (int i = 1; i < theDt.Columns.Count; i++)
                    {
                        sBuilder.Append(",");
                        columnName = theDt.Columns[i].ColumnName;
                        dataType = GetDBDataType(theDt.Columns[i].DataType.ToString());
                        sBuilder.Append(String.Format("[{0}] {1} NULL", columnName, dataType));
                    }
                    sBuilder.Append(")");
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = sBuilder.ToString();
                    command.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;                    
                }
            }
            else
            {

                //Server svr = new Server(new ServerConnection(new SqlConnection(connString)));
                //Microsoft.SqlServer.Management.Smo.Database db = svr.Databases[getConnItem("database", new SqlConnection(connString))];
                //Microsoft.SqlServer.Management.Smo.Table tmp = new Microsoft.SqlServer.Management.Smo.Table(db, tblName);
                //Column tmpC = new Column();
                //string dataType;

                foreach (DataColumn dc in theDt.Columns)
                {
                    //Create columns from datatable column schema
                    if (tblName == "tblARTPatientMasterInformation" && dc.DataType.ToString() == "System.DateTime")
                        dataType = "System.String";
                    else
                        dataType = dc.DataType.ToString();
                    tmpC = new Column(tmp, dc.ColumnName);
                    //tmpC.DataType = GetDataType(dc.DataType.ToString());
                    tmpC.DataType = GetDataType(dataType);
                    tmp.Columns.Add(tmpC);
                }
                tmp.Create();
            }

            //Open a connection with destination database to bulk copy it
            // TODO CHRIS Figure Out how to handle out-or-range datetime value Errors

            using (SqlConnection connection =
                   new SqlConnection(connString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                //Open bulkcopy connection.
                using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connection))
                {
                    //Set destination table name
                    //to table previously created.
                    bulkcopy.DestinationTableName = "dbo.[" + tblName + "]";
                    bulkcopy.NotifyAfter = 1;
                    try
                    {
                        bulkcopy.WriteToServer(theDt);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    bulkcopy.Close();
                }
            }

            theDt.Clear(); tmpC = null; tmp = null; svr = null; theDt.Columns.Clear(); theDt = null;            
            return true;

        }

        private string getConnItem(string item, SqlConnection conn)
        {
            switch (item.ToLower())
            {
                case "database":
                    return conn.Database;
                case "server":
                    return conn.DataSource;
                default:
                    return string.Empty;
            }
        }

        public bool chkAccessDB(string conntring, string emrType)
        {
            if (conntring.Trim().Substring(0, 8).ToLower() == "provider" && emrType.ToLower() != "mysql")
                return true;
            else
                return false;
        }

        void bulkcopy_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            Console.WriteLine(e.RowsCopied.ToString());
            //throw new Exception("The method or operation is not implemented.");
        }          

        public string getDbType(string pmmsType)
        {
            switch (pmmsType.ToLower().Trim())
            {
                case "microsoft sql server":
                    return "SQL Server";
                case "microsoft access":
                    return "Access database";
                case "mysql server":
                    return "MySQL";
                case "postgresql server":
                    return "PostGre";
                case "db2 database server":
                    return "db2";
                default:
                    return "";
            }
        }

        public static bool DecryptMstPatient()
        {
            Entity en = new Entity();
            string connectionString = GetConnString();
            try
            {
                DataRow dr = (DataRow)en.ReturnObject(connectionString, null, "Select dbase IQCareDB from aa_database", ClsUtility.ObjectEnum.DataRow, "mssql");
                string IQCareDB = dr["IQCareDB"].ToString();
                string SQLString = string.Empty;
                int j = 0;               
                SqlConnection myConn = new SqlConnection();
                myConn.ConnectionString = connectionString;
                myConn.Open();

                string IQToolsDB = myConn.Database;
                myConn.ChangeDatabase(IQCareDB);
                SqlCommand myComm = new SqlCommand("Open symmetric key Key_CTC decryption by password='ttwbvXWpqb5WOLfLrBgisw=='", myConn);
                j = myComm.ExecuteNonQuery();
                myComm.Dispose(); j = 0;
                 SQLString = "Select *, " +
                                  " convert(varchar(100),decryptbykey(MiddleName)) dMiddleName," +
                                  " convert(varchar(100),decryptbykey(firstname)) dFirstName, convert(varchar(100),decryptbykey(LastName))dLastName," +
                                  " convert(varchar(100),decryptbykey(Address))dAddress, convert(varchar(100),decryptbykey(Phone)) dPhone" +
                                  " INTO [" + IQToolsDB + "].dbo.mst_patient_decoded  From " +
                                  "mst_patient Where mst_patient.deleteflag is null or mst_patient.deleteflag=0";


                myComm = new SqlCommand(SQLString, myConn);
                j = myComm.ExecuteNonQuery(); j = 0;
                myComm.Dispose();

                myComm = new SqlCommand("close symmetric key Key_CTC", myConn);
                j = myComm.ExecuteNonQuery();
                myComm.Dispose();
                myComm = null;
                myConn.Close();
                myConn.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;//EH.LogError(ex.Message, "<<frm_Load:Decode Mst_Patient>>", serverType);
            }
        }

    }

}
