using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer;
using System.Text.RegularExpressions;
using DataLayer;
using System.IO;
using BusinessLayer;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace IQTools.Assets
{
    class UtFunctions
    {        

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
        
        public bool crtTable(string connString, string tblName, DataTable theDt)
        {
            Cursor.Current = Cursors.WaitCursor;
            Server svr = new Server(new ServerConnection(new SqlConnection(connString)));
            Microsoft.SqlServer.Management.Smo.Database db = svr.Databases[getConnItem("database", new SqlConnection(connString))];
            Microsoft.SqlServer.Management.Smo.Table tmp = new Microsoft.SqlServer.Management.Smo.Table(db, tblName);
            Column tmpC = new Column();
            string dataType;

            if (clsGbl.PMMS.ToLower() == "ctc2")
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
                    MessageBox.Show(ex.Message);
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
                        MessageBox.Show(ex.Message, Assets.Messages.ErrorHeader);
                        return false; 
                    }
                    bulkcopy.Close();
                }
            }
            
            theDt.Clear(); tmpC = null; tmp = null; svr = null; theDt.Columns.Clear(); theDt = null;
            Cursor.Current = Cursors.Default;
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

        public bool chkAccessDB(string conntring)
        {
            if (conntring.Trim().Substring(0, 8).ToLower() == "provider" && clsGbl.PMMSType.ToLower() != "mysql")
                return true;
            else
                return false;
        }

        void bulkcopy_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            Console.WriteLine(e.RowsCopied.ToString());
            //throw new Exception("The method or operation is not implemented.");
        }        

        private void UpdateProgress(int p, ProgressBar pr)
        {
            if (pr == null) return;

            if (pr.InvokeRequired)
            { pr.Invoke(new MethodInvoker(delegate { pr.Value = p; })); }
        }

        public string getDbType(ComboBox pmmsType)
        {
            switch (pmmsType.Text.ToLower().Trim())
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

        public bool setServers(bool chkAccess, string cboServer, string srvType)
        {
            clsGbl.currServer = cboServer;
            bool retVal;
            if (!chkAccess)
            {
                int i = 0;
                Entity theObject = new Entity(); ClsUtility.Init_Hashtable();

                if (srvType.ToLower() == "sql server")
                {
                   i = 0;
                    try
                    { i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "EXEC sp_dropserver '" + clsGbl.currServer + "', 'DropLogIns'", ClsUtility.ObjectEnum.ExecuteNonQuery, clsGbl.PMMSType); retVal = true; }
                    catch { retVal = false; }

                    try
                    { i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "EXEC sp_AddLinkedServer '" + clsGbl.currServer + "', @srvproduct = N'" + srvType + "'", ClsUtility.ObjectEnum.ExecuteNonQuery, clsGbl.PMMSType); retVal = true; ; }
                    catch { retVal = false; }
                    return retVal;
                }
                else return true;
            }
            else
                return true;
        }
        
        public bool clrIQTables(bool chkAccess, string Comparison)
        {
            Cursor.Current = Cursors.WaitCursor;

            //if ((clsGbl.DBState == "Loading" || clsGbl.DBState == "Connected") && Comparison == "")
            //{
            //    if(clsGbl.IQDirection.ToLower() != "clearall")
            //        return true;

            //}
            // this function deletes all the temporary tables in the IQTools database
            if (!chkAccess)
            {
                if (clsGbl.PMMSType.Trim().ToLower() == "mssql" || clsGbl.PMMSType.Trim().ToLower() == "")
                {
                 //   SqlConnection conn = new SqlConnection(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools"));
                    SqlConnection conn = new SqlConnection ( Entity.getconnString ( clsGbl.xmlPath ) );
                    clsGbl.currData = conn.Database;
                    clsGbl.currServer = conn.DataSource;
                }
                else if (clsGbl.PMMSType.Trim().ToLower() == "mysql")
                {
                    MySqlConnection conn = new MySqlConnection(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools"));
                    clsGbl.currData = conn.Database;
                    clsGbl.currServer = conn.DataSource;
                }
            }
            try
            {
                DataTable theDt = new DataTable(); int i = 0;
                Entity theObject = new Entity(); ClsUtility.Init_Hashtable();

                if (Comparison == "")
                {
                    if (chkAccess)
                    {
                        if (clsGbl.IQDirection == "ClearAll")
                            theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                , "SELECT [Name] tblName, [Name] snName FROM Sys.Tables WHERE [Name] Like '%Tps%' UNION SELECT [Name] tblName, " + 
                                "[Name] snName FROM Sys.Tables WHERE [Name] Like '%Mgr%' UNION SELECT [Name] tblName, [Name] snName FROM Sys.Tables WHERE [Name] " + 
                                "Like '%Tmp%' UNION SELECT tblName, snName FROM aa_Tables WHERE snActive=1 And (Comparison Is Null Or Comparison = '')", ClsUtility.ObjectEnum.DataTable, "mssql");
                        else
                            theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                , "SELECT [Name] tblName, [Name] snName FROM Sys.Tables WHERE [Name] Like '%Tmp%' " +
                                "UNION SELECT tblName, snName FROM aa_Tables WHERE snActive=1 And (Comparison Is Null Or Comparison = '')", ClsUtility.ObjectEnum.DataTable, "mssql");
                    }

                    else
                        if (clsGbl.PMMSType.Trim().ToLower() == "mssql" || clsGbl.PMMSType.Trim().ToLower() == "")
                        {
                            if (clsGbl.IQDirection == "ClearAll")
                                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                    , "SELECT [Name] FROM sys.Synonyms UNION SELECT [Name] From Sys.Tables Where [Name] Like 'TPS%' Or [Name] Like 'Mgr%' Or [Name] Like 'Tmp%'"
                                    , ClsUtility.ObjectEnum.DataTable, "mssql");
                            else
                                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                    , "SELECT [Name] FROM sys.Synonyms UNION SELECT [Name] From Sys.Tables Where [Name] Like 'Tmp%'"
                                    , ClsUtility.ObjectEnum.DataTable, "mssql");
                        }
                        else if (clsGbl.PMMSType.Trim().ToLower() == "mysql")
                        {
                            if (clsGbl.PMMS.ToLower() == "isante")
                            {
                                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                    , "SELECT tblName, flServer, snName, snActive, qryDefinition, mkTable from aa_Tables INNER JOIN aa_Queries ON aa_Tables.snName = aa_Queries.QryName WHERE SnActive = 1 And (Comparison Is Null Or Comparison = '') And aa_Queries.mkView is not null ORDER By mkView", ClsUtility.ObjectEnum.DataTable, "mssql");
                            }
                            else
                            theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT tblName, snName FROM aa_Tables INNER JOIN aa_Queries ON aa_Tables.snName = aa_Queries.QryName", ClsUtility.ObjectEnum.DataTable, "mssql");
                        }
                }
                else
                {
                    if (Comparison.ToLower() == "all")
                        theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT tblName, snName FROM aa_Tables WHERE snActive=1 And (Comparison Is Not Null Or Comparison <>'')", ClsUtility.ObjectEnum.DataTable, "mssql");
                    else
                        theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT tblName, snName FROM aa_Tables WHERE snActive=1 And Comparison='" + Comparison + "'", ClsUtility.ObjectEnum.DataTable, "mssql");
                }


                DataTableReader dTr;
                dTr = theDt.CreateDataReader();

                if (!chkAccess)
                {
                    if (clsGbl.PMMSType.Trim().ToLower() == "mssql" || clsGbl.PMMSType.Trim().ToLower() == "" || clsGbl.PMMSType.Trim().ToLower() == "msaccess")
                    {
                        while (dTr.Read())
                        {
                            try { i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                , "DROP Synonym [dbo].[" + dTr[0].ToString().Trim() + "]", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql"); }
                            catch { }

                            try { i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                , "DROP Table [" + dTr[0].ToString().Trim() + "]", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql"); }
                            catch { }
                        }
                        try { i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                            , "DROP TABLE mst_Patient_decoded", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql"); }
                        catch { }
                        try { i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                            , "DROP TABLE dtl_PatientContacts", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql"); }
                        catch { }
                    }
                    else if (clsGbl.PMMSType.Trim().ToLower() == "mysql")
                    {
                        string tblName;
                        while (dTr.Read())
                        {
                            if (clsGbl.PMMS.ToLower() == "isante")
                            {
                                if (dTr[5].ToString().ToLower() != "")
                                {
                                    tblName = dTr[0].ToString().Substring(4, dTr[0].ToString().Length - 4);
                                    try
                                    { i = (int)theObject.ReturnObject(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools")
                                        , ClsUtility.theParams, "DROP TABLE `TMP_" + tblName + "`;", ClsUtility.ObjectEnum.ExecuteNonQuery, "mysql"); }
                                    catch
                                    { }
                                }
                                try { i = (int)theObject.ReturnObject(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "iqtools")
                                    , ClsUtility.theParams, "DROP VIEW " + dTr[0].ToString().Trim() + "", ClsUtility.ObjectEnum.ExecuteNonQuery, clsGbl.PMMSType); }
                                catch { }

                            }
                            else
                            {
                                try { i = (int)theObject.ReturnObject(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "iqtools")
                                    , ClsUtility.theParams, "DROP View " + dTr[0].ToString().Trim() + "", ClsUtility.ObjectEnum.ExecuteNonQuery, clsGbl.PMMSType); }
                                catch { }
                            }
                        }
                    }
                }
                else
                {
                    SqlConnection cnn = new SqlConnection(Entity.getconnString(clsGbl.xmlPath));
                    cnn.Open();
                    SqlCommand cmm = new SqlCommand(); cmm.Connection = cnn;

                    while (dTr.Read())
                    {
                        try
                        {
                          cmm.CommandText = "IF OBJECT_ID('" +dTr[0].ToString ( ).Trim ( ) +"') IS NOT NULL DROP TABLE [dbo].[" + dTr[0].ToString ( ).Trim ( ) + "]";
                            i = cmm.ExecuteNonQuery();
                        }
                        catch { }
                    }
                    cnn.Close();
                    cnn.Dispose();
                }


                try
                {
                    if (Comparison == "")
                    {
                        if (clsGbl.DBState != "Ready" && clsGbl.DBState.ToLower() != "new load")
                        {
                            clsGbl.DBState = "No data";
                            ClsUtility.Init_Hashtable();
                            i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                , "UPDATE aa_Database SET IQStatus='No data', UpdateDate= null", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                        }
                    }
                }

                catch { }


                Cursor.Current = Cursors.Default;
                return true;



            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Substring(0, 21) == "cannot use drop table")
                {
                    SqlConnection cnn = new SqlConnection(Entity.getconnString(clsGbl.xmlPath));
                    cnn.Open();
                    SqlCommand cmm = new SqlCommand("UPDATE aa_Database Set Connstring = '' WHERE DBName = 'IQTools'"); cmm.Connection = cnn;
                    int i = cmm.ExecuteNonQuery();
                    cnn.Close(); cmm.Dispose(); cnn.Dispose();
                }
                Cursor.Current = Cursors.Default;
                return true;
            }
        }

        public bool crtIQTables(bool chkAccess, string Comparison, ProgressBar pb)
        {
            // this function creates all the synonms in IQTools database
            
            Cursor.Current = Cursors.WaitCursor;
            clsGbl.DBState = "Loading";

            if (!chkAccess)
            {
                if (clsGbl.PMMSType.Trim().ToLower() == "mssql" || clsGbl.PMMSType.Trim().ToLower() == "" )
                {
                 SqlConnection conn = new SqlConnection(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools"));
                    clsGbl.currData = conn.Database;
                    clsGbl.currServer = conn.DataSource;
                }
                else if (clsGbl.PMMSType.Trim().ToLower() == "mysql")
                {
                    MySqlConnection conn = new MySqlConnection(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools"));
                    clsGbl.currData = conn.Database;
                    clsGbl.currServer = conn.DataSource;
                }
            }
            //TODO DONE VY create formbuilder form views
            //TODO CHRIS Only Do this for IQCARE
            if (clsGbl.PMMS.ToLower() == "iqcare")
            {
                SqlConnection IQcareConn = new SqlConnection();
                IQcareConn.ConnectionString = Entity.getconnString(clsGbl.xmlPath);
                IQcareConn.Open(); IQcareConn.ChangeDatabase(clsGbl.currData);
                String viewsQry = @"
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
                // mycmd.CommandType = CommandType.StoredProcedure;
                int resuting = mycmd.ExecuteNonQuery();

                mycmd.Dispose();
            }
            try
            {
                DataTable theDt = new DataTable(); DataTableReader theDr; int i = 0;
                Entity theObject = new Entity(); ClsUtility.Init_Hashtable();


                if (Comparison == "")
                {
                    if (clsGbl.PMMSType.Trim().ToLower() == "mssql" || clsGbl.PMMSType.Trim().ToLower() == "" || clsGbl.PMMSType.Trim().ToLower() == "msaccess")
                    {
                        try
                        {
                            i = 0; string DtFormat = "";
                            int m = 99; int d = 99; int y = 99;
                            m = clsGbl.IQDate.IndexOf("12");
                            d = clsGbl.IQDate.IndexOf("31");
                            y = clsGbl.IQDate.IndexOf("10");

                            if (m < y && m < d)
                            {
                                DtFormat = "m";
                                if (y < d)
                                    DtFormat += "yd";
                                else
                                    DtFormat += "dy";
                            }
                            else if (d < y && d < m)
                            {
                                DtFormat = "d";
                                if (y < m)
                                    DtFormat += "ym";
                                else
                                    DtFormat += "my";
                            }
                            else if (y < m && y < d)
                            {
                                DtFormat = "y";
                                if (m < d)
                                    DtFormat += "md";
                                else
                                    DtFormat += "dm";
                            }
                            ClsUtility.SDate = DtFormat;
                        }
                        catch { }

                        if(clsGbl.PMMS.ToLower() == "ctc2")                       
                          theDt = (DataTable)theObject.ReturnObject ( Entity.getconnString ( clsGbl.xmlPath ), ClsUtility.theParams
                              , "SELECT tblName, flServer, snName, snActive from aa_Tables WHERE EMR = '" + clsGbl.PMMS + "' AND SnActive = 1 And (Comparison Is Null Or Comparison = '') ORDER By tblOrder, snName", ClsUtility.ObjectEnum.DataTable, "mssql" );
                        else
                          //TODO: DONE Vincent Add code that updates aa_tables with new formbuilder tables i.e. all forms with '_FB'
                          //TODO: CHRIS Add All Tables Where Clause Filters Out AppAdmin
                          //theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT TABLE_NAME,'" + clsGbl.currServer + "' flServer,TABLE_NAME,'true' snActive FROM [" + clsGbl.currData + "].INFORMATION_SCHEMA.TABLES where Table_name like '%[_]%' ", ClsUtility.ObjectEnum.DataTable, "mssql");
                          theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT TABLE_NAME,'" + clsGbl.currServer + "' flServer,TABLE_NAME,'true' snActive FROM [" + clsGbl.currData + "].INFORMATION_SCHEMA.TABLES where Table_Name not like '%sysdiagrams%'", ClsUtility.ObjectEnum.DataTable, "mssql");
                          //theDt = (DataTable)theObject.ReturnObject(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "iqtools"), ClsUtility.theParams, "SELECT TABLE_NAME,'" + clsGbl.currServer + "' flServer,TABLE_NAME,'true' snActive FROM INFORMATION_SCHEMA.TABLES where Table_Name not like '%sysdiagrams%'", ClsUtility.ObjectEnum.DataTable, "mssql");
                       
                    }
                    else if (clsGbl.PMMSType.Trim().ToLower() == "mysql")
                        //TODO change this to create synonyms for all IQCare tables
                       
                    {
                        theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                            , "SELECT tblName, flServer, snName, snActive, qryDefinition, mkTable from aa_Tables INNER JOIN aa_Queries ON aa_Tables.snName = aa_Queries.QryName WHERE SnActive = 1 And (Comparison Is Null Or Comparison = '') And aa_Queries.mkView is not null ORDER By mkView;", ClsUtility.ObjectEnum.DataTable, "mssql");

                    }
                }
                else
                {
                    theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                        , "SELECT tblName, flServer, snName, snActive from aa_Tables WHERE SnActive = 1 And Comparison LIKE '%" + Comparison.Substring(0, 8) + "%' ORDER By snName", ClsUtility.ObjectEnum.DataTable, "mssql");

                }
                theDr = theDt.CreateDataReader();
                
                double tableCount = 0;
                DataRow dr1 = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                    , "SELECT Count(qryID) Total FROM aa_Queries where MkTable Is Not Null and deleteflag is null", ClsUtility.ObjectEnum.DataRow, "mssql");
                int numberOfTables = (int)dr1[0];
                double progress = 0;

                if (!chkAccess)
                {
                    while (theDr.Read())
                    {
                        if (theDr[3].ToString().ToLower() == "true")
                        {
                            if (clsGbl.PMMSType.Trim().ToLower() == "mssql" || clsGbl.PMMSType.Trim().ToLower() == "")
                            {
                                try
                                {
                                    i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "CREATE SYNONYM [dbo].[" + theDr[2].ToString() + "] FOR " +
                                           "[" + clsGbl.currServer + "].[" + clsGbl.currData + "].[dbo].[" + theDr[0].ToString() + "]", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else if (clsGbl.PMMSType.Trim().ToLower() == "mysql")
                            {
                                String tblName;
                                // i = (int)theObject.ReturnObject(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath),"mssql"),"iqtools"), ClsUtility.theParams, "CREATE VIEW [" + theDr[2].ToString() + "] AS " +
                                //        "[" + clsGbl.currServer + "].[" + clsGbl.currData + "].[dbo].[" + theDr[0].ToString() + "]", ClsUtility.ObjectEnum.ExecuteNonQuery, clsGbl.PMMSType);

                                // create a view based on the query equivalent in IQTools
                                try
                                {
                                    if (theDr[4].ToString().ToLower().IndexOf("order by") > 0)
                                    { i = (int)theObject.ReturnObject(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "iqtools"), ClsUtility.theParams, "CREATE OR REPLACE VIEW `" + theDr[2].ToString() + "` AS " + theDr[4].ToString().Substring(0, theDr[4].ToString().ToLower().IndexOf("order by")) + ";", ClsUtility.ObjectEnum.ExecuteNonQuery, clsGbl.PMMSType); }
                                    else
                                    { i = (int)theObject.ReturnObject(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "iqtools"), ClsUtility.theParams, "CREATE OR REPLACE VIEW `" + theDr[2].ToString() + "` AS " + theDr[4].ToString() + ";", ClsUtility.ObjectEnum.ExecuteNonQuery, clsGbl.PMMSType); }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                /////Create TMP Tables right after creating the view
                                

                                try
                                {
                                    if (theDr[5].ToString().ToLower() != "")
                                    {
                                        tableCount = tableCount + 1;
                                        double div = tableCount / numberOfTables;
                                        progress = div * 100;
                                        tblName = theDr[0].ToString().Substring(4, theDr[0].ToString().Length - 4);
                                        try
                                        { i = (int)theObject.ReturnObject(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools"), ClsUtility.theParams, "DROP TABLE `TMP_" + tblName + "`;", ClsUtility.ObjectEnum.ExecuteNonQuery, "mysql"); }
                                        catch
                                        { }
                                        i = 0;
                                        /////Try Creating indexes based on EMR Testing CTC2MySQL PatientID Should be something like if clsGbl.pmms = CTC2MySQL//////
                                        try
                                        {
                                            if (clsGbl.PMMS.ToLower() == "ctc2mysql" || clsGbl.PMMS.ToLower() == "isante")
                                            {
                                                i = (int)theObject.ReturnObject(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "iqtools"), ClsUtility.theParams, "CREATE TABLE IF NOT EXISTS TMP_" + tblName + " (Index(PatientID)) " + theDr[4].ToString() + ";", ClsUtility.ObjectEnum.ExecuteNonQuery, clsGbl.PMMSType);
                                            }
                                            else // Add Indexing for other MySQL based EMRs here
                                            {
                                                i = (int)theObject.ReturnObject(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "iqtools"), ClsUtility.theParams, "CREATE TABLE IF NOT EXISTS TMP_" + tblName + " " + theDr[4].ToString() + ";", ClsUtility.ObjectEnum.ExecuteNonQuery, clsGbl.PMMSType);
                                            }

                                        }//If this fails create without index :-(
                                        catch { i = (int)theObject.ReturnObject(Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "iqtools"), ClsUtility.theParams, "CREATE TABLE IF NOT EXISTS TMP_" + tblName + " " + theDr[4].ToString() + ";", ClsUtility.ObjectEnum.ExecuteNonQuery, clsGbl.PMMSType);  }
                                        UpdateProgress((int)progress,pb );
                                    }
                                }
                                catch (Exception ex) { MessageBox.Show(ex.Message); }
                             }
                        }
                    }
                }
                else
                {

                    System.Data.OleDb.OleDbDataAdapter da; DataTable dt = new DataTable("temp"); ;

                    string connstring = "";
                    if (Comparison == "")
                    {
                      //connstring = Entity.getdbConnString((SqlConnection)Entity.GetConnection(Entity.getconnString(clsGbl.xmlPath), "mssql"), "IQTools");
                      string connectionString = Entity.getconnString ( clsGbl.xmlPath );
                      string dbType = "mssql";
                      SqlConnection connection = (SqlConnection)Entity.GetConnection ( connectionString, dbType );
                      string pmm = "IQTools";
                      connstring = Entity.getdbConnString ( connection, pmm );
                    }
                    else
                      connstring = clsGbl.StrComparisons;

                    while (theDr.Read())
                    {
                        if (theDr[3].ToString().ToLower() == "true")
                        {
                            try 
                            {
                            dt.Clear();
                            da = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " + theDr[0].ToString(), connstring);
                            dt.BeginLoadData();
                            da.Fill(dt);
                            dt.EndLoadData();
                            }
                            catch //(Exception ex)
                            {
                                //MessageBox.Show(ex.Message);
                            }
                            UtFunctions theTable = new UtFunctions();
                            if (!theTable.crtTable(Entity.getconnString(clsGbl.xmlPath), theDr[2].ToString(), dt))
                                MessageBox.Show(theDr[0].ToString() + " could not be uploaded into IQTools");
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
                return true;
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                return false;
            }

            finally
            {
                clsGbl.DBState = "Connected";
            }

        }      

        public enum TabType
        {
            Errors = 1,
            Warnings = 0,
            Diagnostics = 2
        }
    }

    

    static class Common
    {

        public static System.Data.OleDb.OleDbConnectionStringBuilder CreateAccessConnectionString(string AccessDB)
        {
            return CreateAccessConnectionString(AccessDB, null, null, null);
        }

        /// <summary>
        /// I know there is going to be a bug in this one!  Be prepared!
        /// </summary>
        /// <param name="AccessDB">Access database</param>
        /// <param name="AccessMDW">Access MDW file</param>
        /// <param name="UserId">User Id</param>
        /// <param name="Password">Password</param>
        /// <returns></returns>
        public static System.Data.OleDb.OleDbConnectionStringBuilder CreateAccessConnectionString(string AccessDB, string AccessMDW, string UserId, string Password)
        {
            System.Data.OleDb.OleDbConnectionStringBuilder oci = new System.Data.OleDb.OleDbConnectionStringBuilder();
            oci.Provider = "Microsoft.Jet.OLEDB.4.0";
            oci.DataSource = AccessDB;

            if (!string.IsNullOrEmpty(AccessMDW))
            {
                oci["Jet OLEDB:System Database"] = AccessMDW;
            }
            if (!string.IsNullOrEmpty(UserId))
            {
                oci["User Id"] = UserId;
            }
            else
            {
                oci["User Id"] = "Admin";
            }
            if (!string.IsNullOrEmpty(Password))
            {
                oci["Password"] = Password;
            }
            else
            {
                oci["Password"] = "";
            }
            return oci;
        }

        private static System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
        private static System.Windows.Forms.FolderBrowserDialog fbd = new FolderBrowserDialog();

        public static void AddTableMergedToTree(TreeView treeView, string AccessDB, string TableName)
        {
            TreeNode tn = new TreeNode(TableName);
            tn.Checked = false;
            tn.Tag = TableName;
            tn.ImageIndex = 2;
            tn.ToolTipText = TableName;
            tn.Expand();
            tn.Nodes[0].Nodes["AccessDB"].Nodes.Add(tn);
        }



        /// <summary>
        /// Copy a file to the Application.StartupPath
        /// </summary>
        /// <param name="Filename"></param>
        public static void CopyToApplicationPath(string Filename)
        {
            string apppath = Application.StartupPath;
            if (!apppath.EndsWith(@"\")) apppath += @"\";

            FileInfo f = new FileInfo(Filename);
            File.Copy(Filename, apppath + f.Name);
            f = null;
        }


        internal static void AddToWarningTab(Exception ex, System.Windows.Forms.ListView listView, FarsiLibrary.Win.FATabStripItem ftsWarning)
        {
            if (listView == null) return;
            if (ex != null)
            {
                ListViewItem lvi = null;
                if (ex is System.Configuration.ConfigurationException)
                {
                    lvi = new ListViewItem("Configuration file could not be found");
                }
                else
                {
                    lvi = new ListViewItem(ex.Message);
                }
                lvi.ImageKey = "warning";
                lvi.SubItems.Add(string.Empty);
                if (ex.InnerException != null) lvi.SubItems.Add(ex.InnerException.Message);
                listView.Items.Add(lvi);
                SetTabCaption(ftsWarning, listView.Items.Count + " Warnings");
            }
        }

        internal static void SetTabCaption(FarsiLibrary.Win.FATabStripItem ftsTab, string Title)
        {
            ftsTab.Title = Title;
        }

        static void AddToErrorTab(System.Data.SqlClient.SqlException sqlex, System.Windows.Forms.ListView listView, FarsiLibrary.Win.FATabStripItem ftsError)
        {
            if (listView == null) return;
            if (sqlex != null)
            {
                ListViewItem lvi = new ListViewItem(sqlex.Message);
                lvi.ImageKey = "error";
                lvi.SubItems.Add(string.Empty);
                if (sqlex.InnerException != null) lvi.SubItems.Add(sqlex.InnerException.Message);
                listView.Items.Add(lvi);
                SetTabCaption(ftsError, listView.Items.Count + " Errors");
            }
        }

        internal static void AddToErrorTab(SqlException sqlex, System.Windows.Forms.ListView listView, string LPTFName, FarsiLibrary.Win.FATabStripItem ftsError)
        {
            if (listView == null) return;
            if (sqlex != null)
            {
                foreach (System.Data.SqlClient.SqlError oerr in sqlex.Errors)
                {
                    ListViewItem lvi = new ListViewItem(oerr.Message);
                    lvi.ImageKey = "error";
                    if (LPTFName == string.Empty)
                    {
                        lvi.SubItems.Add(sqlex.Message);
                    }
                    else
                    {
                        lvi.SubItems.Add(LPTFName);
                    }
                    lvi.SubItems.Add(oerr.Source);
                    lvi.SubItems.Add(oerr.Number.ToString());
                    listView.Items.Add(lvi);
                    SetTabCaption(ftsError, listView.Items.Count + " Errors");
                }
            }
        }

        internal static void AddToErrorTab(OleDbException oex, System.Windows.Forms.ListView listView, string LPTFName, FarsiLibrary.Win.FATabStripItem ftsError)
        {
            if (listView == null) return;
            if (oex != null)
            {
                foreach (System.Data.OleDb.OleDbError oerr in oex.Errors)
                {
                    ListViewItem lvi = new ListViewItem(oerr.Message);
                    lvi.ImageKey = "error";
                    lvi.SubItems.Add(oerr.NativeError.ToString());
                    lvi.SubItems.Add(LPTFName);
                    lvi.SubItems.Add(oerr.SQLState);
                    listView.Items.Add(lvi);
                    SetTabCaption(ftsError, listView.Items.Count + " Errors");
                }
            }
        }


        internal static void AddToErrorTab(Exception ex, System.Windows.Forms.ListView listView, string LPTFName, FarsiLibrary.Win.FATabStripItem ftsError)
        {
            if (listView == null) return;
            if (ex != null)
            {

                ListViewItem lvi = new ListViewItem(ex.Message);
                lvi.ImageKey = "error";
                if (ex.InnerException != null) lvi.SubItems.Add(ex.InnerException.Message);
                listView.Items.Add(lvi);
                SetTabCaption(ftsError, listView.Items.Count + " Errors");

            }
        }

        internal static void AddToErrorTab(Exception ex, string TableName, string LPTFName, System.Windows.Forms.ListView listView, FarsiLibrary.Win.FATabStripItem ftsError)
        {
            if (listView == null) return;
            if (ex != null)
            {
                ListViewItem lvi = new ListViewItem(TableName + ": " + ex.Message);
                if (ex.InnerException != null) lvi.SubItems.Add(ex.InnerException.Message);
                if (!string.IsNullOrEmpty(LPTFName)) lvi.SubItems.Add(LPTFName);
                listView.Items.Add(lvi);

                SetTabCaption(ftsError, listView.Items.Count + " Errors");
            }
        }

        public static string OpenMDWFileDialog()
        {
            ofd.Filter = "MDW Files (*.mdw)|*.mdw";
            ofd.FilterIndex = 1;
            ofd.InitialDirectory = @"C:\";
            ofd.Multiselect = false;
            ofd.Title = "Browse for MDW files";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return ofd.FileName;
            }
            return string.Empty;
        }

        /// <summary>
        /// Calls Common.OpenAccessFileDialog(false)
        /// </summary>
        /// <returns></returns>
        public static string OpenAccessFileDialog()
        {
            return Common.OpenAccessFileDialog(false)[0];
        }



        public static System.Collections.Specialized.StringCollection OpenAccessFolderDialog()
        {
            System.Collections.Specialized.StringCollection strColList = new System.Collections.Specialized.StringCollection();
            fbd.Description = "Select the folder to scan for MS Access databases";
            fbd.ShowNewFolderButton = false;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string selectedpath = fbd.SelectedPath;
                GetAccessFiles(selectedpath, ref strColList);
            }
            return strColList;

        }

        private static void GetAccessFiles(string directory, ref System.Collections.Specialized.StringCollection filescollection)
        {
            GetFolders(directory, ref filescollection);
        }

        private static void GetFiles(string directory, ref System.Collections.Specialized.StringCollection filescollection)
        {
            //recursive function
            string[] files = System.IO.Directory.GetFiles(directory);
            filescollection.AddRange(files);
        }

        /// <summary>
        /// Recursive function - performance hit, best to use loop
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filescollection"></param>
        private static void GetFolders(string directory, ref System.Collections.Specialized.StringCollection filescollection)
        {
            GetFiles(directory, ref filescollection);
            string[] dirs = System.IO.Directory.GetDirectories(directory);
            foreach (string dir in dirs)
            {
                GetFolders(dir, ref filescollection);
            }
        }


        public static string[] OpenAccessFileDialog(bool MultiSelect)
        {
            ofd.Filter = "Access Databases (*.mdb)|*.mdb";
            ofd.FilterIndex = 1;
            ofd.InitialDirectory = @"C:\";
            ofd.Multiselect = MultiSelect;
            ofd.DefaultExt = "mdb";

            ofd.Title = "Browse for Access Databases";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return ofd.FileNames;
            }
            return null;
        }

        public static string GetCheckSumFilePath()
        {
            return System.IO.Path.Combine(Application.StartupPath, "checksums.xml");
        }

        /// <summary>
        /// Must use Application.ExecutablePath and not Application.StartupPath
        /// </summary>
        /// <returns></returns>
        public static string GetMDWPath()
        {
            return System.IO.Path.Combine(Application.StartupPath, "System.mdw");
        }

        



    }
}