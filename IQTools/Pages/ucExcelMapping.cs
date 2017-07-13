using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;
using System.Collections;

namespace IQTools.Pages
{
    public partial class ucExcelMapping : UserControl
    {
        frmMain fMain;
        string serverType = Entity.getServerType(clsGbl.xmlPath);
        ErrorLogHelper EH = new ErrorLogHelper();
        Entity theObject = new Entity();
        DataTable theDt = new DataTable();
        Hashtable htCategories; 
        public ucExcelMapping(frmMain frm)
        {
            InitializeComponent();
            fMain = frm;
            // get all the excel kind reports in the combo;
            theDt.Clear();
            DataTableReader theDr;
            ClsUtility.Init_Hashtable();

            theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT catId, Category FROM aa_Category WHERE Excel=1", ClsUtility.ObjectEnum.DataTable, serverType);
            theDr = theDt.CreateDataReader();
            cboReports.Items.Clear();
            htCategories = new Hashtable();
            htCategories.Clear();
            while (theDr.Read())
            {
                cboReports.Items.Add(theDr["Category"].ToString());
                htCategories.Add(theDr["CatID"].ToString(), theDr["Category"].ToString());
            }
        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstQueries.Items.Clear();
            dgXls.DataSource = null;
            if (lstCategories.SelectedItem != "")
            {
                // get the queries associated with the category
                //theDt.Clear();
                if (theDt != null)
                {
                    DataTableReader theDr;
                    //theDr = theDt.CreateDataReader();

                    theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT DISTINCT qryName, qryDescription FROM " +
                                " aa_Queries a  LEFT JOIN aa_SBCategory b ON a.QryID = b.QryID " +
                                 "WHERE sbCategory='" + lstCategories.Text + "'"
                                , ClsUtility.ObjectEnum.DataTable, serverType);
                    theDr = theDt.CreateDataReader();
                    while (theDr.Read())
                    {
                        lstQueries.Items.Add(theDr["qryName"].ToString());
                    }
                }
            }
        }

        private void lstQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgXls.DataSource = null;
            //txtDesc.Text = "";

            if (theDt != null)
            {
                DataTableReader theDr;
                theDr = theDt.CreateDataReader();

                try
                {
                    while (theDr.Read())
                    {
                        if (theDr["qryName"].ToString().Trim().ToLower() == lstQueries.Items[lstQueries.SelectedIndex].ToString().Trim().ToLower())
                        {
                            txtEDesc.Text = theDr["qryDescription"].ToString();

                            DataTable eDT = new DataTable();
                            // get the parameters
                            eDT = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                                , "SELECT DISTINCT xlsCell, xlsTitle, DHISElementID, CategoryOptionID FROM " +
                                   "aa_XLMaps LEFT JOIN aa_Queries ON aa_XLMaps.QryID = aa_Queries.QryID " +
                                   "LEFT JOIN  aa_SBCategory ON aa_XLMaps.xlCatID = aa_SBCategory.sbCatID " +
                                   "where (aa_SBCategory.DeleteFlag=0 Or aa_SBCategory.DeleteFlag Is Null) And " +
                                   "(aa_Queries.DeleteFlag=0 Or aa_Queries.DeleteFlag Is Null) And " +
                                   "(aa_XLMaps.DeleteFlag=0 Or aa_XLMaps.DeleteFlag Is Null)  and qryName= '" + lstQueries.Items[lstQueries.SelectedIndex].ToString() + "' And sbCategory = '" + lstCategories.Items[lstCategories.SelectedIndex].ToString() + " ' "
                                        , ClsUtility.ObjectEnum.DataTable, serverType);
                            dgXls.DataSource = eDT;
                            dgXls.Refresh();
                            break;
                        }
                    }
                }
                catch { }
            }
        }

        private void cmdEMap_Click(object sender, EventArgs e)
        {
            //TODO Replace with pr_SaveUpdateExcelMapping_IQTools
            Cursor.Current = Cursors.WaitCursor;
            DataRow qryDR; DataRow catDR;
            ClsUtility.Init_Hashtable(); int i = 0;

            qryDR = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                , "SELECT qryID FROM aa_Queries  WHERE qryName = '" + lstQueries.Items[lstQueries.SelectedIndex].ToString() + "'"
                , ClsUtility.ObjectEnum.DataRow, serverType);
            catDR = (DataRow)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                , "SELECT sbCatID FROM aa_SBCategory " +
                  "WHERE sbCategory = '" + lstCategories.Items[lstCategories.SelectedIndex].ToString()
                + "' And QryId=" + qryDR["QryID"], ClsUtility.ObjectEnum.DataRow, serverType);

            i = 0;
            try
            {
                string sql = "DELETE FROM aa_XLMaps WHERE QryID=" + qryDR["qryID"].ToString() + " AND xlCatID=" + catDR["sbCatID"].ToString();
                i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, sql
                , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);
                foreach (DataGridViewRow dr in dgXls.Rows)
                {
                    if (dr.Cells["xlsCell"].Value.ToString().Length > 1)
                    {
                        i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                            , "UPDATE aa_XLMaps SET xlsCell, QryID, xlsTitle, xlCatID, CreateDate, DhisElementID, CategoryOptionID) VALUES('" +
                            dr.Cells["xlsCell"].Value.ToString() + "', " + qryDR["qryID"].ToString() + ", '"
                            + dr.Cells["xlsTitle"].Value.ToString() + "', " + catDR["sbCatID"].ToString() + ", dbo.fn_GetCurrentDate(), '"
                            + dr.Cells["DHISElementID"].Value.ToString() + "','" + dr.Cells["categoryOptionID"].Value.ToString() + "' )"
                            , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);

                        i = (int)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams
                            , "INSERT INTO aa_XLMaps (xlsCell, QryID, xlsTitle, xlCatID, CreateDate, DhisElementID, CategoryOptionID) VALUES('" +
                            dr.Cells["xlsCell"].Value.ToString() + "', " + qryDR["qryID"].ToString() + ", '"
                            + dr.Cells["xlsTitle"].Value.ToString() + "', " + catDR["sbCatID"].ToString() + ", dbo.fn_GetCurrentDate(), '"
                            + dr.Cells["DHISElementID"].Value.ToString() + "','" + dr.Cells["categoryOptionID"].Value.ToString() + "' )"
                            , ClsUtility.ObjectEnum.ExecuteNonQuery, serverType);

                    }
                }
                MessageBox.Show("Query Mapping Was Saved Successfully", Assets.Messages.InfoHeader);
            }
            catch (Exception ex)
            {
                EH.LogError(ex.Message, "Excel Mapping", serverType);
            }
            Cursor.Current = Cursors.Default;
        }

        private void cboReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update the list for queries associated with that report
            lstCategories.Items.Clear();
            lstQueries.Items.Clear();
            //txtDesc.Text = "";
            dgXls.DataSource = null;

            if (cboReports.Text != "")
            {
                // get the queries associated with the category
                theDt.Clear();
                DataTableReader theDr;
                ClsUtility.Init_Hashtable();

                theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT DISTINCT sbCategory " +
                            "FROM aa_SBCategory a LEFT JOIN aa_Category b ON a.CatID = b.CatID " +
                            "WHERE Category='" + cboReports.Text + "'"
                            , ClsUtility.ObjectEnum.DataTable, serverType);
                theDr = theDt.CreateDataReader();
                while (theDr.Read())
                {
                    lstCategories.Items.Add(theDr["sbCategory"].ToString());
                }
            }
        }


       

     
    }
       
}
