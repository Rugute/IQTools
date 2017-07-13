using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;



namespace IQTools.Reports
{

    /// <summary>
    /// Custom reports collection class - not yet fully implemented, Kenya team to take over
    /// </summary>
    public partial class CustomReports
    {
        private System.Data.SqlClient.SqlConnectionStringBuilder m_connectinfo;

        private List<CustomReport> _reports = new List<CustomReport>();
        /// <summary>
        /// 
        /// </summary>
        public CustomReports() { }


        /// <summary>
        /// Gets/sets reports collection
        /// </summary>
        public List<CustomReport> Reports
        {
            get { return this._reports; }
            set { this._reports = value; }
        }

        /// <summary>
        /// Gets/set internal property of SqlConnectionStringBuilder
        /// </summary>
        internal SqlConnectionStringBuilder SqlConnectInfo
        {
            get { return m_connectinfo; }
            set { m_connectinfo = value; }
        }

        /// <summary>
        /// Calls GetReports again
        /// </summary>
        public void Refresh()
        {
            GetReports();
        }


        /// <summary>
        /// Get the reports from the database
        /// </summary>
        public virtual void GetReports()
        {
            using (SqlConnection con = new SqlConnection(m_connectinfo.ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("dbo.msp_GetReports", con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();

                   // try
                 //   {
                        if (con.State == ConnectionState.Closed) con.Open();
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            CustomReport rep = new CustomReport(dr);
                           
                            rep.ConnectInfo = this.m_connectinfo;
                            this._reports.Add(rep);
                        }
                    //}
                    //catch (SqlException sqlex)
                    //{
                    //    System.Windows.Forms.MessageBox.Show(sqlex.Message);
                    //}
                }
            }
        }
    }


    /// <summary>
    /// Report parameter object
    /// </summary>
    public class ReportParam
    {
        private int m_ParamPK;
        private int m_ReportFK;
        public string ParameterName;
        public string ParameterType;
        public int Decimals;
        public string InputMask;
        public bool Required;

        /// <summary>
        /// Primary key
        /// </summary>
        public int ParamPK
        {
            get { return m_ParamPK; }
        }

        /// <summary>
        /// Foreign key
        /// </summary>
        public int ReportFK
        {
            get { return m_ReportFK; }
        }

        public ReportParam() { }

        public ReportParam(DataRow dr)
        {
            SetProperties(dr);
        }

        private void SetProperties(DataRow dr)
        {
            m_ParamPK = Convert.ToInt32(dr["ParamPK"]);
            m_ReportFK = Convert.ToInt32(dr["ReportFK"]);
            ParameterName = (string) dr["ParameterName"];
            ParameterType = (string) dr["ParameterType"];
            Decimals = Convert.ToInt32(dr["Decimals"]);
            InputMask = (string) dr["InputMask"];
            Required = (bool) dr["Required"];
        }
    }

    /// <summary>
    /// Individual custom report object
    /// </summary>
    public partial class CustomReport
    {
        public string Name;
        public string SPName;
        public bool HasExcelExport;
        public string ExcelExportMethod;
        public bool HasRegularSP;
        public bool HasForm;
        public string FormName;
        public string ReportCategory;
        private int m_ReportPK;
        private SqlConnectionStringBuilder m_connectinfo;
        private List<ReportParam> m_ReportParams = new List<ReportParam>();

        public List<ReportParam> ReportParams
        {
            get { return m_ReportParams; }
            set { m_ReportParams = value; }
        }

        public int ReportPK
        {
            get {return m_ReportPK; }
        }

        public CustomReport() { }

        public CustomReport(System.Data.DataRow dr)
        {
            SetProperties(dr);

        }

        /// <summary>
        /// SqlConnectionStringBuilder class
        /// </summary>
        internal SqlConnectionStringBuilder ConnectInfo
        {
            get { return m_connectinfo; }
            set { m_connectinfo = value; }
        }

        /// <summary>
        /// Get the parameters for this Report
        /// </summary>
        public virtual void GetParams()
        {
            using (SqlConnection con = new SqlConnection(m_connectinfo.ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("dbo.msp_GetParams", con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@ReportFK", m_ReportPK));

                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();

                    try
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            ReportParam repparam = new ReportParam(dr);
                            this.m_ReportParams.Add(repparam);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        System.Windows.Forms.MessageBox.Show(sqlex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Delete the report - not implemented
        /// </summary>
        internal void Delete()
        {
            throw new NotImplementedException("Delete is not yet implemented");
            //delete from db
            //remove from list
        }

        /// <summary>
        /// Set the properties of this class
        /// </summary>
        /// <param name="dr"></param>
        private void SetProperties(System.Data.DataRow dr)
        {
            ExcelExportMethod = (string)dr["excelexportmethod"];
            HasRegularSP = (bool)dr["hasregularSP"];
            SPName = (string)dr["SPName"];
            HasForm = (bool)dr["hasform"];
            if (dr["formname"] != DBNull.Value)
            {
                FormName = (string)dr["formname"];
            }
            HasExcelExport = (bool)dr["hasexcelexport"];
            Name = (string)dr["reportname"];
            ReportCategory = (string)dr["repcategory"];
            m_ReportPK = Convert.ToInt32(dr["ReportPK"]);
        }
    }
}
