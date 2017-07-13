using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using System.IO;
using BusinessLayer;
using System.Data.SqlClient;

namespace IQTools.Pages
{
    public partial class ucCustomReport : UserControl
    {
        frmMain fMain;
        string serverType = Entity.getServerType(clsGbl.xmlPath);
        Entity theObject = new Entity();
        DataTable theDt = new DataTable();
        public ucCustomReport(frmMain frm)
        {
           InitializeComponent();
            fMain = frm;
            //For the Combobox
            cboCReportCategory.Items.Clear();
            theDt.Clear();
            DataTableReader theDr;

            theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                , "SELECT DISTINCT Category FROM aa_Category", ClsUtility.ObjectEnum.DataTable, serverType);
            theDr = theDt.CreateDataReader();
            while (theDr.Read())
            {
                cboCReportCategory.Items.Add(theDr["Category"].ToString());
            }
            // For the grid
            refreshCustomReportsGrid(); 
           
        }

        //private void cmdAddRemoveFilter_Click(object sender, EventArgs e)
        //{
        //    if (txtCReportFilterName.Text.Trim() == "" | cboCReportFilterType.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Please ensure that the filter name and type are specified", "IQTools Custom Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    String[] filters = { txtCReportFilterName.Text.Trim(), cboCReportFilterType.Text.Trim() };

        //    ListViewItem filter = new ListViewItem(filters);
        //    lstCReportsFilter.Items.Add(filter);
        //    txtCReportFilterName.Text = "";
        //    cboCReportFilterType.SelectedIndex = -1;
        //}

        private void saveFilters(string reportName)
        {
            String ParamLabel = "";
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(Entity.getconnString(clsGbl.xmlPath));
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            cmd.CommandText = "select ReportID from (Select ReportID,ReportName from aa_Reports union Select ReportID,ReportName from aa_CustomReports)a where ReportName='" + reportName + "'";
            int reportID = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();
            int i = 0;
            long filterId;
            foreach (ListViewItem item in lstCReportsFilter.Items)
            {
                switch (item.SubItems[0].Text)
                {
                    case "iqtDateHelper": ParamLabel= "Select Reporting Period";
                        break;
                    case "cd4cutoff": ParamLabel = "CD4 Cut-Off For ART";
                        break;
                    case "bySatellite": ParamLabel = "Separate Satellites";
                        break;
                    case "linelist":ParamLabel = "Include Line List";
                        break;
                    case "PatientID":ParamLabel = "PatientID";
                        break;
                    case "xYears": ParamLabel = "Number of Years";
                        break;
                } 
                filterId = 0;
                if (item.Tag != null) filterId = (long)item.Tag;

                i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
                        "UPDATE aa_ReportParameters SET ParamName='" + item.SubItems[0].Text + "', ParamType='" + item.SubItems[1].Text +
                        "', UpdateDate=GetDate() WHERE ReportParamID=" + filterId,
                        ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                if (i > 0) continue;

                i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
              "INSERT INTO aa_ReportParameters(ParamName, ReportID,ParamLabel, ParamType,position,CreateDate) Values ('" +
              item.SubItems[0].Text + "','" + reportID + "','" + ParamLabel +"','" + item.SubItems[1].Text + "',1, getDate())", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);


            }

        }

        private void loadCustomReportFilters(Int32 reportID)
        {
            lstCReportsFilter.Items.Clear();
            DataTable dt = new DataTable();
            dt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
                   "SELECT parID, parName, parType" +
                    " FROM  aa_parameter where reportID = " + reportID + " and (Deleteflag <>1 or deleteflag is null)",
                    ClsUtility.ObjectEnum.DataTable, serverType);
            foreach (DataRow row in dt.Rows)
            {
                String[] filters = { row[1].ToString(), row[2].ToString() };

                ListViewItem filter = new ListViewItem(filters);

                filter.Tag = row[0];
                lstCReportsFilter.Items.Add(filter);

            }
        }

        private void resetCustomReportScreen()
        {
            lblCReportId.Text = "0";
            txtCReportDesc.Text = "";
            txtCReportName.Text = "";
            cboCReportCategory.SelectedIndex = -1;
            lstCReportsFilter.Items.Clear();
            chkDeleteCReport.Checked = false;
            txtCReportTemplate.Text = "";
        }

        private void refreshCustomReportsGrid()
        {
            theDt.Clear();
            dgvCReports.DataSource = null;
            theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
                   "SELECT CR.ReportID, category.Category, CR.ReportName, CR.ReportDescription" +
                    " FROM  aa_Reports AS CR INNER JOIN  aa_Category AS category ON CR.QueryCategoryID = category.catID",
                    ClsUtility.ObjectEnum.DataTable, serverType);
            dgvCReports.DataSource = theDt;
            dgvCReports.Refresh();
        }

        

        Boolean updateReport = false;

        private void cmdCReportSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (txtCReportName.Text.Trim() == "" | cboCReportCategory.Text.Trim() == "" | txtCReportTemplate.Text.Trim() == "")
            {
                MessageBox.Show("Please ensure that the Excel Template,Report name and category are specified", "IQTools Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ClsUtility.Init_Hashtable();
                if (txtCReportTemplate.Text != "--Browse to update existing template--")
                {
                    System.IO.File.Copy(txtCReportTemplate.Text, clsGbl.tmpFolder + txtCReportName.Text.Trim() + " Template.xlsx", true);
                    System.IO.File.SetAttributes(clsGbl.tmpFolder + txtCReportName.Text.Trim() + " Template.xlsx", FileAttributes.Hidden);
                }
                if (updateReport)
                {
                    i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
                        "UPDATE aa_Reports SET ReportName='" + txtCReportName.Text.Trim() + "', ReportDescription='" + txtCReportDesc.Text.Trim() +
                        //"', DeleteFlag='" + chkDeleteCReport.Checked + 
                        "' WHERE ReportID=" + lblCReportId.Text,
                        ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                    saveFilters(txtCReportName.Text.Trim());
                    if (i > 0)
                    {
                        resetCustomReportScreen();
                        updateReport = false;
                    }
                }
                else
                {
                    int GroupVal=0;
                    switch (cboReportGroup.Text)
                    {
                        case "MOH Reports":
                            GroupVal = 1; break;
                        case "MOH Registers":
                            GroupVal = 2; break;
                        case "HIV Care Routine Reports":
                            GroupVal = 3; break;
                        case "Pharmacy Consumption Reports":
                            GroupVal = 4; break;
                        default:
                            GroupVal = 5; break;
                    }

                    i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams,
                        "INSERT INTO aa_Reports(QueryCategoryID,ReportGroupID,ReportName,ExcelWorksheetName,ReportDisplayName, ReportDescription,ExcelTemplateName) " +
                        "Select top 1 CatID,'" + GroupVal + "','" + txtCReportName.Text.Trim() + "','" + txtCReportName.Text.Trim() + "','" + txtCReportName.Text.Trim() + "','" + txtCReportDesc.Text.Trim() + "','" + txtCReportName.Text.Trim() + " Template.xlsx" +
                        "' from (Select  CatID,Category  from aa_Category) aa_Cat  where aa_Cat.Category = '" + cboCReportCategory.Text.Trim() + "'", ClsUtility.ObjectEnum.ExecuteNonQuery, serverType); 
                    saveFilters(txtCReportName.Text.Trim());
                    if (i > 0) resetCustomReportScreen();
                }
                refreshCustomReportsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n " + ex.StackTrace);
            }
        }

        private void cmdCReportNew_Click(object sender, EventArgs e)
        {
            resetCustomReportScreen();
        }

        private void cmdCReportTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            //fd.Filter = "Excel 97-2003 Workbook|*.xls"; 
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtCReportTemplate.Text = fd.FileName;
            }
        }

        private void cboCReportCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //For the Combobox for Report Group
            cboReportGroup.Items.Clear();
            theDt.Clear();
            DataTableReader theDr;

            theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                , "SELECT Distinct  GroupName, Position FROM aa_ReportGroups order by Position asc", ClsUtility.ObjectEnum.DataTable, serverType);
            theDr = theDt.CreateDataReader();
            while (theDr.Read())
            {
                cboReportGroup.Items.Add(theDr["GroupName"].ToString());

            }
        }

        private void dgvCReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dvgCReports_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCReports.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCReports.SelectedRows[0];
                // dgvCReports.CurrentRow
                if (row != null)
                {
                    //SELECT CR.ReportID, category.Category, CR.ReportName, CR.ReportDescription, CR.DeleteFlag
                    lblCReportId.Text = "" + (int)row.Cells[0].Value;
                    cboCReportCategory.Text = (String)row.Cells[1].Value;
                    txtCReportName.Text = (String)row.Cells[2].Value;
                    txtCReportDesc.Text = (String)row.Cells[3].Value;
                    chkDeleteCReport.Checked = (Boolean)row.Cells[4].Value;
                    txtCReportTemplate.Text = "--Browse to update existing template--";
                    loadCustomReportFilters((Int32)row.Cells[0].Value);

                    updateReport = true;
                    //  row.Cells[0].Value;

                }
            }
        }

        private void cboReportGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int Position;
            DataTableReader theDr;
            theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                , "SELECT Distinct  GroupName, Position FROM aa_ReportGroups where GroupName = '" + cboReportGroup.SelectedText + "'", ClsUtility.ObjectEnum.DataTable, serverType);
            theDr = theDt.CreateDataReader();
            while (theDr.Read())
            {
                cboReportGroup.SelectedValue = theDr["Position"];
                //Position = theDr["Position"];

            }
        }

        private void cmdAddRemoveFilter_Click_1(object sender, EventArgs e)
        {
            if (CboCReportFilterName.Text.Trim() == "" | cboCReportFilterType.Text.Trim() == "")
            {
                MessageBox.Show("Please ensure that the filter name and type are specified", "IQTools Custom Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String[] filters = { CboCReportFilterName.Text.Trim(), cboCReportFilterType.Text.Trim(), "1" };

            ListViewItem filter = new ListViewItem(filters);
            lstCReportsFilter.Items.Add(filter);
            CboCReportFilterName.Text = "";
            cboCReportFilterType.SelectedIndex = -1;
        }

        private void txtCReportName_TextChanged(object sender, EventArgs e)
        {
            CboCReportFilterName.Items.Clear();
            theDt.Clear();
            DataTableReader theDr;

            theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                , "Select distinct ParamName from aa_ReportParameters", ClsUtility.ObjectEnum.DataTable, serverType);
            theDr = theDt.CreateDataReader();
            while (theDr.Read())
            {
                CboCReportFilterName.Items.Add(theDr["ParamName"].ToString());

            }
        }
    }
}
