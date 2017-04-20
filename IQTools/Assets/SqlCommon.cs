using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.IO;



    #region "EventArgs"


    public class ErrorEventArgs : EventArgs
    {
        private Exception _ex;
        public new static ErrorEventArgs Empty;

        public ErrorEventArgs(Exception Exception)
        {
            this._ex = Exception;
        }

        public Exception Exception
        {
            get { return this._ex; }
        }
    }

    public class RestoreEventArgs : EventArgs
    {
        private string _restoreto;
        private string _restorefrom;

        public new static RestoreEventArgs Empty;


        public RestoreEventArgs(string RestoreTo, string RestoreFrom)
        {
            this._restoreto = RestoreTo;
            this._restorefrom = RestoreFrom;
        }

        public string RestoreFrom
        {
            get { return this._restorefrom; }
        }

        public string RestoreTo
        {
            get { return this._restoreto; }
        }
    }

    public class LinkServerEventArgs : EventArgs
    {
        private Microsoft.SqlServer.Management.Smo.LinkedServer _linkedServer;
        public new static LinkServerEventArgs Empty;

        public LinkServerEventArgs(Microsoft.SqlServer.Management.Smo.LinkedServer linkedServer)
        {
            this._linkedServer = linkedServer;
        }

        public Microsoft.SqlServer.Management.Smo.LinkedServer LinkedServer
        {
            get { return this._linkedServer; }
        }
        
    }

    public class DatabaseCreateEventArgs : EventArgs
    {
        private string _databasename;

        public new static DatabaseCreateEventArgs Empty;

        public DatabaseCreateEventArgs() { }
        public DatabaseCreateEventArgs(string DatabaseName)
        {
            this._databasename = DatabaseName;
        }

        public string DatabaseName
        {
            get { return this._databasename; }
        }
    }


    /// <summary>
    /// EventArgs for backup operations
    /// </summary>
    public class BackupEventArgs : EventArgs
    {
        private string _backupdb;
        private string _backupfile;

        public new static BackupEventArgs Empty;

        public BackupEventArgs() { }

        public BackupEventArgs(
            string BackupDB, 
            string BackupFile)
        {
            this._backupdb = BackupDB;
            this._backupfile = BackupFile;
        }

        public string BackupDB
        {
            get { return this._backupdb; }
        }

        public string BackupFile
        {
            get { return this._backupfile; }
        }
    }


    #endregion

    /// <summary>
    /// ErrorEventHandler: Handles error events
    /// </summary>
    /// <param name="sender">Sender as object</param>
    /// <param name="e">ErrorEventArgs object</param>
    public delegate void ErrorEventHandler(object sender, ErrorEventArgs e);
    /// <summary>
    /// BackupEventHandler: Handles backup events
    /// </summary>
    /// <param name="sender">Sender as object</param>
    /// <param name="e">BackupEventArgs object</param>
    public delegate void BackupEventHandler(object sender, BackupEventArgs e);
    /// <summary>
    /// RestoredEventHandler: Handles restoration events
    /// </summary>
    /// <param name="sender">Sender as object</param>
    /// <param name="e">RestoreEventArgs object</param>
    public delegate void RestoreEventHandler(object sender, RestoreEventArgs e);

    public delegate void LinkServerEventHandler(object sender, LinkServerEventArgs e);

    /// <summary>
    /// DatabaseCreateEventHandler: Handles database creation events
    /// </summary>
    /// <param name="sender">Sender as object</param>
    /// <param name="e">DatabaseCreateEventArgs object</param>
    public delegate void DatabaseCreateEventHandler(object sender, DatabaseCreateEventArgs e);


/// <summary>
/// This class acts as a wrapper class which uses SMO objects
/// to perform restoration/backup/link server management
/// </summary>
    public class SqlCommon
    {
        /// <summary>
        /// Not yet implemented but can be used to fire error event
        /// </summary>
        public event ErrorEventHandler Error;

        /// <summary>
        /// Fires when a database is restored
        /// </summary>
        public event RestoreEventHandler DatabaseRestored;
        public event RestoreEventHandler BeforeDatabaseRestore;
        public event LinkServerEventHandler LinkServerCreated;
        //public event LinkServerEventHandler BeforeLinkServerCreate;

        /// <summary>
        /// Fires when a database is backed up
        /// </summary>
        public event BackupEventHandler DatabaseBackedUp;
        /// <summary>
        /// Not yet implemented
        /// </summary>
        public event BackupEventHandler BeforeDatabaseBackup;
        // public event ColumnRenamedHandler OnColumnRenamed;

        /// <summary>
        /// Fires when a database is created
        /// </summary>
        public event DatabaseCreateEventHandler DatabaseCreated;
        /// <summary>
        /// Not in use at present but this option can be implemented
        /// </summary>
        public event DatabaseCreateEventHandler BeforeDatabaseCreated;


        /// <summary>
        /// Add databases to a particular combobox
        /// </summary>
        /// <param name="SQLServer">SQL server to interrogate</param>
        /// <param name="comboBoxDB">Combobox to fill</param>
        public virtual void AddDatabases(string SQLServer, System.Windows.Forms.ComboBox comboBoxDB)
        {
            Server srv = new Server(SQLServer);
            try
            {
                foreach (Database db in srv.Databases)
                {
                    comboBoxDB.Items.Add(db.Name);
                }
            }
            catch (Exception ex)
            {
                Error(this, new ErrorEventArgs(ex));
            }
        }

        public void OnError(ErrorEventArgs e)
        {
            if (Error != null)
            {
                Error(this, e);
            }
        }

        /// <summary>
        /// Add SQL servers to the items collection in comboboxes
        /// </summary>
        /// <param name="comboBoxes">Array of comboboxes to populate</param>
        public virtual void AddSQLServers(System.Windows.Forms.ComboBox[] comboBoxes)
        {
            string strServer;
            //retrieve a list of SQL Server instances on the network
            DataTable objServers = SmoApplication.EnumAvailableSqlServers(false);
            foreach (DataRow dr in objServers.Rows)
            {
                strServer = dr["Server"].ToString();
                if (!(dr["Instance"] is DBNull) && (dr["Instance"].ToString().Length > 0))
                {
                    strServer += @"\" + dr["Instance"].ToString();
                }
                foreach (System.Windows.Forms.ComboBox cbo in comboBoxes)
                {
                    cbo.Items.Add(strServer);
                }
            }
        }

        /// <summary>
        /// Add SQL Servers to a particular combobox
        /// </summary>
        /// <param name="comboBox"></param>
        public virtual void AddSQLServers(
            System.Windows.Forms.ComboBox comboBox)
        {
            System.Windows.Forms.ComboBox[] cbs = { comboBox };
            AddSQLServers(cbs);
        }



        /// <summary>
        /// Restore a database using SMO
        /// </summary>
        /// <param name="ServCon">ServerConnection object</param>
        /// <param name="BackupFilePath">Full path to backup file</param>
        /// <param name="destinationDatabaseName">Name of database that will have the backup restored to</param>
        /// <param name="DatabaseFolder">Folder in which the database must be placed</param>
        /// <param name="DatabaseFileName">MDF logic name only</param>
        /// <param name="DatabaseLogFileName">Logfile logic name only</param>
        public void RestoreDatabase(
            ServerConnection ServCon, 
            string BackupFilePath,
            string DestinationDatabaseName,
            string DatabaseFolder,
            string DatabaseFileName,
            string DatabaseLogFileName)
        {
            Server serv = new Server(ServCon);
            Restore rest = new Restore();
            rest.Database = DestinationDatabaseName;
            try
            {
                // OnBeforeDatabaseRestore(this, RestoreEventArgs.Empty);
                Database currentDb = serv.Databases[DestinationDatabaseName];
                if (currentDb != null) serv.KillAllProcesses(DestinationDatabaseName);

                rest.Devices.AddDevice(BackupFilePath, DeviceType.File);

                string DataFileLocation = System.IO.Path.Combine(DatabaseFolder, DestinationDatabaseName + ".mdf");
                string LogFileLocation = System.IO.Path.Combine(DatabaseFolder, DestinationDatabaseName + "_log.ldf");

                rest.RelocateFiles.Add(new RelocateFile(DatabaseFileName, DataFileLocation));
                rest.RelocateFiles.Add(new RelocateFile(DatabaseLogFileName, LogFileLocation));

                //rest.RelocateFiles.Add(new RelocateFile("GMaps", @"C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\G.mdf"));
                //rest.RelocateFiles.Add(new RelocateFile("GMaps_log", @"C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\G_log.ldf"));


                rest.ReplaceDatabase = true;
                rest.PercentCompleteNotification = 10;

                // rest.PercentComplete += new PercentCompleteEventHandler(rest_PercentComplete);
                // rest.Complete += new ServerMessageEventHandler(rest_Complete);

                // Console.WriteLine("Restoring:{0}", DestinationDatabaseName);

                rest.SqlRestore(serv);
                currentDb = serv.Databases[DestinationDatabaseName];
                currentDb.SetOnline();
                OnDatabaseRestored( new RestoreEventArgs(DestinationDatabaseName, DatabaseFileName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void OnDatabaseRestored(RestoreEventArgs e)
        {
            if (DatabaseRestored != null)
            {
                DatabaseRestored(this, e);
            }
        }

        //static void rest_Complete(object sender, Microsoft.SqlServer.Management.Common.ServerMessageEventArgs e)
        //{
        //    Console.WriteLine(e.ToString() + " Complete");
        //}

        //static void rest_PercentComplete(object sender, PercentCompleteEventArgs e)
        //{
        //    Console.WriteLine(e.Percent.ToString() + "% Complete");
        //} 


        /// <summary>
        /// Backup a database using SMO.  If "C:\Temp\Database does not
        /// exist it will be created.
        /// Backup options used:  Checksum = true
        ///         ContinueAfterError = true
        ///         Incremental = false
        ///         BackupTruncateLogType.Truncate
        /// Uses OnDatabaseBackedUp when successful
        /// </summary>
        /// <param name="con">ServerConnection object</param>
        /// <param name="DBToBackup">Database name to backup</param>
        /// <param name="DBBackupFile">Specified backup file</param>
        /// <returns>Boolean value</returns>
        public virtual bool BackupDatabase(ServerConnection con, string DBToBackup, string DBBackupFile)
        {

            Server serv = new Server(con);
            try
            {
                // OnBeforeDatabaseBackup(this, new BackupEventArgs(DBToBackup, DBBackupFile));

                Backup bk = new Backup();
                bk.Action = BackupActionType.Database;
                bk.Database = DBToBackup;
                //temp\database will be created if it does not exist
                if (!Directory.Exists(@"C:\Temp\Database"))
                {
                    Directory.CreateDirectory(@"C:\Temp\Database");
                }
                if (File.Exists(DBBackupFile))
                {
                    File.Delete(DBBackupFile);
                }
                bk.Initialize = true;
                bk.Checksum = true;
                bk.ContinueAfterError = true;
                bk.Incremental = false;
                bk.LogTruncation = BackupTruncateLogType.Truncate;
                BackupDeviceItem bdi = new BackupDeviceItem(DBBackupFile, DeviceType.File);
                bk.Devices.Add(bdi);
                bk.SqlBackup(serv);
                OnDatabaseBackedUp( new BackupEventArgs(DBToBackup, DBBackupFile));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }

            ////this.Text = "Backing up Smartcare..";
            //string bkup = @"BACKUP DATABASE {0} to Disk = '\{1}.bak";
            //using (SqlCommand com = new SqlCommand(string.Format(bkup, DBToBackup, DBBackupFile, con)))
            //{
            //    //"BACKUP DATABASE " + DBToBackup + @" to Disk = '\" + DBBackupFile + ".bak'",con);
            //    // @"BACKUP DATABASE {0} to Disk = '\{1}.bak";
            //    com.Connection = con;
            //    com.CommandType = CommandType.Text;

            //    try
            //    {
            //        OnBeforeDatabaseBackup(this, BackupEventArgs.Empty);
            //        if (con.State == ConnectionState.Closed) con.Open();
            //        com.ExecuteNonQuery();
            //        OnDatabaseBackedUp(this, new BackupEventArgs(DBToBackup, DBBackupFile));
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        OnError(this, new ErrorEventArgs(ex));
            //        return false;
            //    }
            //}
        }

        public virtual void OnDatabaseBackedUp(BackupEventArgs e)
        {
            if (DatabaseBackedUp != null)
            {
                DatabaseBackedUp(this, e);
            }
        }

        public virtual void OnBeforeDatabaseRestore(RestoreEventArgs e)
        {
            if (BeforeDatabaseRestore != null)
            {
                BeforeDatabaseRestore(this, e);
            }
        }
        /// <summary>
        /// Creates a database using SMO.
        /// Calls OnDatabaseCreated when completed
        /// </summary>
        /// <param name="ServCon"></param>
        /// <param name="DBToCreate"></param>
        /// <returns></returns>
        public bool CreateDatabase(ServerConnection ServCon, string DBToCreate)
        {
            Server serv = new Server(ServCon);
            try
            {
                OnBeforeDatabaseCreated(new DatabaseCreateEventArgs(DBToCreate));
                //  OnBeforeDatabaseCreated(this, new DatabaseCreateEventArgs(DBToCreate));
                // Define a Database object variable by supplying the server and the database name arguments in the constructor.
                Database db = new Database(serv, DBToCreate);
                // Create the database on the instance of SQL Server.
                db.Create();
                OnDatabaseCreated( new DatabaseCreateEventArgs(DBToCreate));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public virtual void OnBeforeDatabaseCreated(DatabaseCreateEventArgs e)
        {
            if (BeforeDatabaseCreated != null)
            {
                BeforeDatabaseCreated(this, e);
            }
        }

        public virtual void OnDatabaseCreated(DatabaseCreateEventArgs e)
        {
            if (DatabaseCreated != null)
            {
                DatabaseCreated(this, e);
            }
        }

        public virtual void OnBeforeDatabaseBackup(BackupEventArgs e)
        {
            if (BeforeDatabaseBackup != null)
            {
                BeforeDatabaseBackup(this, e);
            }
        }


        public bool AddAccessLinkServer(
            ServerConnection SrvConn,
            string AccessDBPath,
            string RemoteUser,
            string RemotePassword,
            string LinkName)
        {
            Server srv = new Server(SrvConn);
            foreach (LinkedServer ls in srv.LinkedServers)
            {
                if (ls.Name == LinkName)
                {
                    foreach (LinkedServerLogin lsl in ls.LinkedServerLogins)
                    {
                        lsl.Drop();
                        break;
                    }
                    ls.Drop();
                    break;
                }
            }
         
            Server Serv = new Server(SrvConn);
            LinkedServer linkServer = new LinkedServer(Serv, LinkName);//, DestinationServer);
            linkServer.ProviderName = "Microsoft.Jet.OLEDB.4.0";
            linkServer.ProductName = "OLE DB Provider for Jet";
            linkServer.DataSource = AccessDBPath;
            linkServer.Create();
            return true;
       
        }

        public virtual void OnLinkServerCreated(LinkServerEventArgs e)
        {
            if (LinkServerCreated != null)
            {
                LinkServerCreated(this, e);
            }
        }

        public bool DropLinkServer(ServerConnection SrvConn, string LinkName)
        {
            try
            {
                   Server serv = new Server(SrvConn);
                   LinkedServerCollection LnkServerList = serv.LinkedServers;
                   foreach (LinkedServer Lnk in LnkServerList)
                    {
                        if (Lnk.Name ==LinkName) 
                        {
                            Lnk.Drop(true);
                            break;
                        }
                    }
                    SrvConn.Disconnect();
                    return true;
                 }
                catch
                {
                   return false;
                }
        }


        // Load all linked servers...
        public bool LoadLinkServers(
            string SourceServer, 
            ref System.Collections.ArrayList LinkServerList)
        {
            try
            {
                ServerConnection SrvConn = new ServerConnection();
                SrvConn.ServerInstance = SourceServer;
                SrvConn.LoginSecure = true;
                Server SQLServer = new Server(SrvConn);
                LinkedServerCollection LnkSrvList = SQLServer.LinkedServers;
                foreach (LinkedServer Lnk in LnkSrvList)
                {
                    LinkServerList.Add(Lnk.Name);
                }
                SrvConn.Disconnect();
                return true;
            }
            catch
            {
               return false;
            }

        }

        

    }
