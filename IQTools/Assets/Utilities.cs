using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections;

//we can work functionality to record the location and details of the last imports - then when the import is done again, 
//the latest files are used - those that havent changed don't import, those that do (I imagine we can use # checksum?) 
//we can delete from the tables and re-import.  
//If any files are missing, they are excluded (unchecked) or something like that

public enum TabType
{
    Errors = 1,
    Warnings = 0,
    Diagnostics = 2
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


    /// <summary>
    /// Add table to treeview for merge
    /// </summary>
    /// <param name="treeView">TreeView control to create node</param>
    /// <param name="AccessDB"></param>
    /// <param name="TableName"></param>
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

    //public class CheckSum
    //{
    //    public static string CreateMD5Checksum(string FileName)
    //    {
    //        FileStream fs = new FileStream(FileName, FileMode.Open);
    //        MD5 md5 = new MD5CryptoServiceProvider();
    //        byte[] retVal = md5.ComputeHash(fs);
    //        fs.Close();

    //        ASCIIEncoding enc = new ASCIIEncoding();
    //        return enc.GetString(retVal);

    //    }

    //    public static string CreateSHAChecksum(string FileName)
    //    {
    //        using (FileStream fs = File.OpenRead(FileName))
    //        {
    //            SHA256Managed sha = new SHA256Managed();
    //            byte[] checksum = sha.ComputeHash(fs);
    //            return BitConverter.ToString(checksum).Replace("-", String.Empty);
    //        }
    //    }

    //    static System.Text.ASCIIEncoding AsciiEncoding = new System.Text.ASCIIEncoding();
    //    byte[] Checksum = Calculate(AsciiEncoding.GetBytes("Checksum This!")); // String to bytes
    //   // MessageBox.Show(AsciiEncoding.GetString(Checksum)); // Return checksum


    /// <summary>
    /// Add a warning to the warning tab.
    /// 
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="listView"></param>
    /// <param name="ftsWarning"></param>
    internal static void AddToWarningTab(Exception ex, System.Windows.Forms.ListView listView, FarsiLibrary.Win.FATabStripItem ftsWarning)
    {
        if (listView == null) return;
        if (ex != null)
        {
            ListViewItem lvi = null;
            if (ex is System.Configuration.ConfigurationErrorsException)
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


    /// <summary>
    /// Open FileDialog
    /// 1. Set Filter to mdw
    /// 2. Initial Directory = c:\
    /// 3. Set tile and multiselect= false and DefaulExt
    /// 4. Open dialog
    /// </summary>
    /// <returns></returns>
    public static string OpenMDWFileDialog()
    {
        ofd.Filter = "MDW Files (*.mdw)|*.mdw";
        ofd.FilterIndex = 1;
        ofd.InitialDirectory = @"C:\";
        ofd.Multiselect = false;
        ofd.Title = "Browse for MDW files";
        ofd.DefaultExt = "mdw";

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
        if (Common.OpenAccessFileDialog(false) == null)
        {
            return null;
        }
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


    /// <summary>
    /// Use recursive function technique to return all Access files in a directory
    /// Calls GetFolders(String, Ref StringCollection)
    /// </summary>
    /// <param name="directory"></param>
    /// <param name="filescollection"></param>
    private static void GetAccessFiles(string directory, ref System.Collections.Specialized.StringCollection filescollection)
    {
        GetFolders(directory, ref filescollection);
    }


    /// <summary>
    /// Returns a collection of files using recursive function.
    /// 1. Calls System.IO.Directory.GetFiles(Directory, "*.mdb") for directory
    /// 2. Adds the files from the function to the Filescollection variable
    /// </summary>
    /// <param name="directory"></param>
    /// <param name="filescollection"></param>
    private static void GetFiles(string Directory, ref System.Collections.Specialized.StringCollection Filescollection)
    {
        //recursive function
        string[] Files = System.IO.Directory.GetFiles(Directory, "*.mdb");
        Filescollection.AddRange(Files);
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

    /// <summary>
    /// Open Access FileDialog
    /// 1. Set filter to mdb
    /// 2. Initial directory = c:\
    /// 3. Multiselect = false
    /// </summary>
    /// <param name="MultiSelect"></param>
    /// <returns></returns>
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

    

        /// <summary>
        /// Return the checksum file path (file which contains the checksums for files
        /// merged).
        /// Calls System.IO.Path.Combine(Application.StartupPath, "checksums.xml")
        /// </summary>
        /// <returns></returns>
        public static string GetCheckSumFilePath()
        {
            return System.IO.Path.Combine(Application.StartupPath, "checksums.xml");
        }

        /// <summary>
        /// Delete checksums.xml file. If it does not exist and Exception will 
        /// not be thrown
        /// </summary>
        public static bool Delete()
        {
            try
            {
                string checksumpath = System.IO.Path.Combine(Application.StartupPath, "checksums.xml");
                System.IO.File.Delete(checksumpath);
                return true;
            }
            catch (IOException ioex)
            {
                MessageBox.Show(ioex.Message, "Error deleting checksum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error deleting checksum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

