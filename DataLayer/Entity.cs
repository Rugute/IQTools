using System;
using System.Data;
using System.Data.SqlClient; 
using System.Collections;
using MySql.Data.MySqlClient;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Xml;
using System.Data.OleDb;
using System.Xml.XPath;
using System.Text;
using Npgsql;

namespace DataLayer
{
    public class Entity : ProcessBase
    {
        public Entity()
        {
        }

        public static string getconnString(string xmlPath)
        {
            XmlDocument theXML = new XmlDocument();
            theXML.Load(xmlPath);
            XmlNode nd = theXML.SelectSingleNode("//add[@key='IQToolconstr']"); //get the node with an attribute of “key” =  IQToolconstr
            if (nd != null)
            {
                return ClsUtility.Decrypt(nd.Attributes["value"].Value); //return the value of the value attribute of this node
            }
            return "";
        }

        public static string getServerType(string xmlPath)
        {
            XmlDocument theXML = new XmlDocument();
            theXML.Load(xmlPath);
            XmlNode nd = theXML.SelectSingleNode("//add[@key='ServerType']");
            if (nd != null)
            {
                return nd.Attributes["value"].Value; //return the value of the value attribute of this node
            }
            return "";
        }

        public static string getDevelopmentRight ( string xmlPath )
        {
          XmlDocument theXML = new XmlDocument ( );
          theXML.Load ( xmlPath );
          XmlNode nd = theXML.SelectSingleNode ( "//add[@key='Development']" );
          if (nd != null)
          {
            return nd.Attributes["value"].Value; //return the value of the value attribute of this node
          }
          return "";
        }  

        public static string getRefreshRights(string xmlPath)
        {
            XmlDocument theXML = new XmlDocument();
            theXML.Load(xmlPath);
            XmlNode nd = theXML.SelectSingleNode("//add[@key='AllowRefresh']");
            if (nd != null)
            {
                return nd.Attributes["value"].Value; //return the value of the value attribute of this node
            }
            return "";
        }

        public object ReturnObject(string ConString,Hashtable Params, string CommandText, ClsUtility.ObjectEnum Obj, string pmmsType)
        {
            switch (pmmsType.Trim().ToLower())
            
            {
                case "mssql":
                    {
                        return MsSQLObject(ConString, Params,CommandText, Obj);
                    }
                case "mysql":
                    {
                        return MySQLObject(ConString, Params, CommandText, Obj);
                    }
                case "pgsql":
                    {
                        return PgSQLObject(ConString, Params, CommandText, Obj);
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
                cnn = (SqlConnection)GetConnection(ConString,"mssql");
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

            for (i = 1; i <= Params.Count;)
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
            { if (CommandText.Substring(0, 15).ToUpper() == "DROP TABLE [TMP" || CommandText.Substring(0, 15).ToUpper() == "DROP TABLE [MGR" || CommandText.Substring(0, 15).ToUpper() == "DROP TABLE [TPS")  theCmd.CommandType = CommandType.Text; }
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
                //throw err;
                return null;
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
                
                cnn = (MySqlConnection)GetConnection(ConString,"mysql");
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

            for (i = 1; i < Params.Count; )
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
            { if (CommandText.Substring(0, 15).ToUpper() == "DROP TABLE `TMP" 
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
                
                theCmd.CommandType = CommandType.Text; }          
           
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

            for (i = 1; i <= Params.Count; )
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
        
        public static object getdbConn(SqlConnection conn,  String pmm)
        {
            string connStr;  string pmmType;
            connStr = ""; pmmType = "";

                try
                {
                    SqlCommand comm;
                    if (pmm == "msaccess")
                    {  comm = new SqlCommand("SELECT connString, PMMSType From aa_Database WHERE DbName = '" + "IQTools" + "'", conn); }
                    else
                    {  comm = new SqlCommand("SELECT connString, PMMSType From aa_Database WHERE DbName = '" + pmm + "'", conn); }
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

        public static object getdbConn(MySqlConnection conn, String pmm)
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
        
        public static string getdbConnString(SqlConnection conn, String pmm)
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

        public static string getdbConnString(MySqlConnection conn, String pmm)
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
            XmlDocument theXML = new XmlDocument();
            theXML.Load(xmlPath);
            XmlNode nd = theXML.SelectSingleNode("//add[@key='RemoteWebServiceURL']");
            if (nd != null)
            {
                return nd.Attributes["value"].Value; //return the value of the value attribute of this node
            }
            return "";
        }
    
    }
}
