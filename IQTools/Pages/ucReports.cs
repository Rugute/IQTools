using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IQTools.UserControls;
using DataLayer;
using BusinessLayer;
using System.Collections;
using System.Threading;
using System.Reflection;
using System.Xml;
using System.Data.SqlClient;
using System.Net;
using System.IO;

namespace IQTools.Pages
{
    public partial class ucReports : UserControl
    {
        frmMain fMain;
        string server = Entity.getServerType(clsGbl.xmlPath);
        string iqtoolsConnString = Entity.getconnString(clsGbl.xmlPath);
        DataSet reportsDS = new DataSet();
        IQToolsReportDatesControl dh = new IQToolsReportDatesControl();
        DataTable reportParameters = new DataTable();
        DataTable satellites = new DataTable();
        DataRow r;
        bool bySatellite = false;
        bool linelists = false;
        //For Sending data to DHIS2 ADX
        bool SendtoDHIS2 = false;
        bool SendtoADX = false;
        //For Sending data to DHIS2 ADX
        RadioButton dhis = new RadioButton();
        RadioButton adx = new RadioButton();
        public DataTable DHISADX;
        public string MFLCode;
        public String DHIS2URL = "";
        string DHISReport;
        Entity theObject; Hashtable myParameters;
        XmlDocument xld = new XmlDocument();

        public ucReports(frmMain frm)
        {
            InitializeComponent();
            fMain = frm;         
        }

        private void ucReports_Load(object sender, EventArgs e)
        {
            getReports();
        }

        private void getReports()
        {
            string sp = "pr_GetReports_IQTools";
            Entity en = new Entity();
            ClsUtility.Init_Hashtable();
            try
            {
                reportsDS = (DataSet)en.ReturnObject(iqtoolsConnString
                    , ClsUtility.theParams, sp, ClsUtility.ObjectEnum.DataSet, server);
                //cboSelectReport.DataSource = new BindingSource(reportsDS.Tables[0], null);
                //cboSelectReport.DisplayMember = "ReportDisplayName";
                //cboSelectReport.ValueMember = "ReportID";
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            //
            try
            {
                
                //tlPSelectReport.RowCount += 1;
                //DataTableReader dr = reportsDS.Tables[0].CreateDataReader();
                DataTableReader groups = reportsDS.Tables[7].CreateDataReader();
                while (groups.Read())
                {
                    
                    Label partition = new Label();
                    //Partition?
                    tlPSelectReport.RowCount = tlPSelectReport.RowCount + 1;
                    
                    partition.Text = groups["GroupName"].ToString();
                    partition.ForeColor = Color.DarkGreen;
                    
                    partition.Anchor = AnchorStyles.Left;
                    partition.AutoSize = true;

                    tlPSelectReport.Controls.Add(partition, 1, tlPSelectReport.RowCount);
                    DataTable currentGroup = reportsDS.Tables[0].DefaultView.ToTable();
                    currentGroup.DefaultView.RowFilter = "GroupName = '" + groups["GroupName"].ToString() + "'";
                    currentGroup = currentGroup.DefaultView.ToTable();
                    DataTableReader dr = currentGroup.CreateDataReader();
                    while (dr.Read())
                    {
                        tlPSelectReport.RowCount = tlPSelectReport.RowCount + 1;
                        RadioButton rd = new RadioButton();
                        rd.CheckedChanged += new EventHandler(Rd_CheckedChanged);
                        rd.Name = dr["ReportName"].ToString();
                        rd.Text = dr["ReportDisplayName"].ToString();
                        rd.TabIndex = Convert.ToInt16(dr["ReportID"].ToString());
                        rd.AutoSize = true;
                        rd.ForeColor = Color.SteelBlue;
                        tlPSelectReport.Controls.Add(rd, 1, tlPSelectReport.RowCount);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //
        }

        private void Rd_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            if (r.Checked)
                GetReport(r.TabIndex);
        }

        private void GetReport(int reportID)
        {
            DataTable selectedReport = new DataTable();
            selectedReport = reportsDS.Tables[0].DefaultView.ToTable();
            selectedReport.DefaultView.RowFilter = "ReportID = " + reportID;
            selectedReport = selectedReport.DefaultView.ToTable();

            r = selectedReport.Rows[0];
          
            //    //lblReportDescription.Text = r["ReportDescription"].ToString();

            //    getExistingReports(reportID); 

            reportParameters = reportsDS.Tables[1].DefaultView.ToTable();
            reportParameters.DefaultView.RowFilter = "ReportID = " + reportID;
            reportParameters = reportParameters.DefaultView.ToTable();


            satellites = reportsDS.Tables[5].DefaultView.ToTable();

            createParameterControls(reportParameters);

            populateReportResources(reportID);
        }

        //private void cboSelectReport_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    string reportID = cboSelectReport.SelectedValue.ToString();
        //    DataTable selectedReport = new DataTable();
        //    selectedReport = reportsDS.Tables[0].DefaultView.ToTable();
        //    selectedReport.DefaultView.RowFilter = "ReportID = " + reportID;
        //    selectedReport = selectedReport.DefaultView.ToTable();

        //    r = selectedReport.Rows[0];
        //    //lblReportDescription.Text = r["ReportDescription"].ToString();

        //    getExistingReports(reportID); 

        //    reportParameters = reportsDS.Tables[1].DefaultView.ToTable();
        //    reportParameters.DefaultView.RowFilter = "ReportID = " + reportID;
        //    reportParameters = reportParameters.DefaultView.ToTable();


        //    satellites = reportsDS.Tables[5].DefaultView.ToTable();

        //    createParameterControls(reportParameters);

        //    populateReportResources(reportID);
        //}

        private void getExistingReports(string ReportID)
        {
            //dgvReports.DataSource = null;
            //try
            //{
            //    DataTable selectedReport = reportsDS.Tables[4].DefaultView.ToTable();
            //    selectedReport.DefaultView.RowFilter = "ReportID = " + ReportID;
            //    selectedReport = selectedReport.DefaultView.ToTable();
            //    dgvReports.DataSource = selectedReport;
            //    DataGridViewLinkColumn dgvlc = new DataGridViewLinkColumn();
            //    dgvlc.DataPropertyName = "ReportLink";
            //    dgvlc.Name = "Report_Link";
            //    dgvlc.HeaderText = "Click To Open The Report";
            //    dgvReports.Columns.Add(dgvlc);
            //    dgvReports.Columns["ReportLink"].Visible = false;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        
        private void createParameterControls(DataTable parameters)
        {    
            tlPParameters.Controls.Clear();
            DataTableReader paramReader = parameters.CreateDataReader();
            string paramType = String.Empty;
            if (paramReader.HasRows)
            {
                try
                {
                    while (paramReader.Read())
                    {
                        paramType = paramReader["ParamType"].ToString();
                        if (paramType.ToLower() == "date")
                        {
                            //Label
                            Label l = new Label();
                            l.Text = paramReader["ParamLabel"].ToString();
                            l.TextAlign = ContentAlignment.MiddleRight;
                            l.Anchor = AnchorStyles.Right;
                            l.AutoSize = true;
                            tlPParameters.Controls.Add(l);

                            DateTimePicker d = new DateTimePicker();
                            //d.Name = "dtp" + paramReader["ParamName"].ToString();
                            d.Name = paramReader["ParamName"].ToString();
                            d.Format = DateTimePickerFormat.Custom;
                            d.CustomFormat = "dd/MM/yyyy";
                            tlPParameters.Controls.Add(d);
                        }
                        else if (paramType.ToLower() == "checkbox")
                        {
                            //Label
                            Label l = new Label();
                            l.Text = paramReader["ParamLabel"].ToString();
                            l.TextAlign = ContentAlignment.MiddleRight;
                            l.Anchor = AnchorStyles.Right;
                            l.AutoSize = true;
                            tlPParameters.Controls.Add(l);

                            CheckBox c = new CheckBox();
                            //c.Name = "chk" + paramReader["ParamName"].ToString();
                            c.Name = paramReader["ParamName"].ToString();
                            c.Checked = Convert.ToBoolean(paramReader["ParamDefaultValue"].ToString());
                            c.CheckAlign = ContentAlignment.MiddleLeft;
                            tlPParameters.Controls.Add(c);
                        }
                        else if (paramType.ToLower() == "textbox")
                        {
                            //Label
                            Label l = new Label();
                            l.Text = paramReader["ParamLabel"].ToString();
                            l.TextAlign = ContentAlignment.MiddleRight;
                            l.Anchor = AnchorStyles.Right;
                            l.AutoSize = true;
                            tlPParameters.Controls.Add(l);

                            TextBox t = new TextBox();
                            t.Name = paramReader["ParamName"].ToString();
                            t.Text = paramReader["ParamDefaultValue"].ToString();
                            tlPParameters.Controls.Add(t);
                        }
                        else if (paramType.ToLower() == "datehelper")
                        {
                            //Label
                            Label l = new Label();
                            l.Text = paramReader["ParamLabel"].ToString();
                            l.TextAlign = ContentAlignment.MiddleRight;
                            l.Anchor = AnchorStyles.Top;
                            //l.Margin.Top = 5;
                            var margin = l.Margin;
                            margin.Top = 6;
                            l.Margin = margin;
                            l.AutoSize = true;
                            tlPParameters.Controls.Add(l);
                           

                            //IQToolsDateHelper dh = new IQToolsDateHelper();
                            dh.cboDateRanges.SelectedIndexChanged += new EventHandler(cboDateRanges_SelectedIndexChanged);
                            dh.cboDateRanges.SelectedIndex = 0;//paramReader["ParamDefaultValue"].ToString();
                            dh.lstPeriods.SelectedIndexChanged += new EventHandler(lstPeriods_SelectedIndexChanged);
                            dh.Dock = DockStyle.Top;
                            //dh.lstPeriods.SelectedIndexChanged += new EventHandler(lstPeriods_SelectedIndexChanged);
                            tlPParameters.Controls.Add(dh);

                            

                        }

                    }
                    

                    //Add a Last Row. Should be some kind of footer
                    Label end = new Label();
                    //end.Text = "_";
                    tlPParameters.Controls.Add(end);
                    //IQTools.UserControls.IQToolsDateHelper dh = new UserControls.IQToolsDateHelper();
                    //tlPParameters.Controls.Add(dh);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }

        void lstPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (dh.cboDateRanges.SelectedIndex)
            {
                case 0:
                    DateTime selected = Convert.ToDateTime(dh.lstPeriods.SelectedItem.ToString());
                    int year = selected.Year;
                    int month = selected.Month;
                    int lastday = DateTime.DaysInMonth(year, month);
                    DateTime enddate = Convert.ToDateTime(year.ToString() + "/" + month.ToString() + "/" + lastday.ToString());
                    DateTime startdate = Convert.ToDateTime(year.ToString() + "/" + month.ToString() + "/1");
                    dh.dtpToDate.Value = enddate;
                    dh.dtpFromDate.Value = startdate;
                    break;
                case 1:
                    selected = Convert.ToDateTime(dh.lstPeriods.SelectedItem.ToString().Substring(6));
                    year = selected.Year;
                    month = selected.Month;
                    lastday = DateTime.DaysInMonth(year, month);
                    
                    enddate = Convert.ToDateTime(year.ToString() + "/" + month.ToString() + "/" + lastday.ToString());
                    startdate = Convert.ToDateTime(enddate.AddMonths(-2).Year.ToString() + "/" + enddate.AddMonths(-2).Month.ToString() + "/1");
                    dh.dtpToDate.Value = enddate;
                    dh.dtpFromDate.Value = startdate;
                    break;
                case 2:
                    selected = Convert.ToDateTime(dh.lstPeriods.SelectedItem.ToString().Substring(6));
                    year = selected.Year;
                    month = selected.Month;
                    lastday = DateTime.DaysInMonth(year, month);

                    enddate = Convert.ToDateTime(year.ToString() + "/" + month.ToString() + "/" + lastday.ToString());
                    startdate = Convert.ToDateTime(enddate.AddMonths(-5).Year.ToString() + "/" + enddate.AddMonths(-5).Month.ToString() + "/1");
                    dh.dtpToDate.Value = enddate;
                    dh.dtpFromDate.Value = startdate;
                    break;
                case 3:
                    selected = Convert.ToDateTime(dh.lstPeriods.SelectedItem.ToString().Substring(6));
                    year = selected.Year;
                    month = selected.Month;
                    lastday = DateTime.DaysInMonth(year, month);

                    enddate = Convert.ToDateTime(year.ToString() + "/" + month.ToString() + "/" + lastday.ToString());
                    startdate = Convert.ToDateTime(enddate.AddMonths(-11).Year.ToString() + "/" + enddate.AddMonths(-11).Month.ToString() + "/1");
                    dh.dtpToDate.Value = enddate;
                    dh.dtpFromDate.Value = startdate;
                    break;
            }
        }

        void cboDateRanges_SelectedIndexChanged(object sender, EventArgs e)
        {           
            populateDatePeriods();
        }

        //private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (this.dgvReports.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
        //    {
        //        string reportLocation = this.dgvReports[e.ColumnIndex, e.RowIndex].Value.ToString();
        //        if (reportLocation != String.Empty)
        //        {
        //            //MessageBox.Show(reportLocation);
        //            System.Diagnostics.Process.Start(reportLocation);
        //        }
        //    }
        //}

        private void populateDatePeriods()
        {
            dh.lstPeriods.Items.Clear();
            dh.lstPeriods.Visible = true;
            switch (dh.cboDateRanges.SelectedIndex)
            {
                case 0:                    
                    var today = DateTime.Today;
                    string[] n = new string[12];
                    for (int i = today.Month; i > today.Month - 12; i--)
                    {
                        int theYear = today.Year;
                        int j = i;
                        if (i <= 0)
                        {
                            j = i + 12; ;
                            theYear = today.Year - 1;
                        }
                        dh.lstPeriods.Items.Add(String.Format("{0:MMMM yyyy}"
                            , new DateTime(theYear, j, 1)));
                    }
                    break;

                case 1:
                    for (int i = 13; i >= 6; i--)
                    {
                        switch ((Math.Abs(i) % 4) + 1)
                        {
                            case 1:
                                dh.lstPeriods.Items.Add("Jan - Mar " + (DateTime.Now.Year + ((i / 4) - 3)));
                                break;
                            case 2:
                                dh.lstPeriods.Items.Add("Apr - Jun " + (DateTime.Now.Year + ((i / 4) - 3)));
                                break;
                            case 3:
                                dh.lstPeriods.Items.Add("Jul - Sep " + (DateTime.Now.Year + ((i / 4) - 3)));
                                break;
                            case 4:
                                dh.lstPeriods.Items.Add("Oct - Dec " + (DateTime.Now.Year + ((i / 4) - 3)));
                                break;
                        }
                    }
                    break;
                case 2:
                    for (int i = 13; i >= 6; i--)
                    {
                        switch ((Math.Abs(i) % 4) + 1)
                        {
                            case 1:
                                dh.lstPeriods.Items.Add("Jan - Jun " + (DateTime.Now.Year + ((i / 4) - 3)));
                                break;
                            case 2:
                                dh.lstPeriods.Items.Add("Oct - Mar " + (DateTime.Now.Year + ((i / 4) - 3)));
                                break;
                            case 3:
                                dh.lstPeriods.Items.Add("Jul - Dec " + (DateTime.Now.Year + ((i / 4) - 3)));
                                break;
                            case 4:
                                dh.lstPeriods.Items.Add("Apr - Sep " + (DateTime.Now.Year + ((i / 4) - 3)));
                                break;
                        }
                    }
                    break;
                case 3:
                    for (int i = 13; i >= 6; i--)
                    {
                        switch ((Math.Abs(i) % 4) + 1)
                        {
                            case 1:
                                dh.lstPeriods.Items.Add("Jan - Dec " + (DateTime.Now.Year + ((i / 4) - 3)));
                                break;
                            case 2:
                                dh.lstPeriods.Items.Add("Oct - Sep " + (DateTime.Now.Year + ((i / 4) - 3)));
                                break;                         
                        }
                    }
                    break;
            }
        }


        public void saveReportLog(string SiteCode, DateTime ReportRunDate, string ReportName, XmlDocument ReportADX, DateTime CreatedDate)
        {
            string sp = "pr_SaveReport_Logs";
            string xml; 
            ClsUtility.Init_Hashtable();
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                ReportADX.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
               xml=  stringWriter.GetStringBuilder().ToString();
            }
            ClsUtility.AddParameters("@SiteCode", SqlDbType.Int, SiteCode);
            ClsUtility.AddParameters("@ReportRunDate", SqlDbType.DateTime, ReportRunDate.ToString());
            ClsUtility.AddParameters("@ReportName", SqlDbType.VarChar, ReportName);
            ClsUtility.AddParameters("@ReportADX", SqlDbType.VarChar, xml);
            ClsUtility.AddParameters("@CreatedDate", SqlDbType.DateTime, CreatedDate.ToString());
            ClsUtility.AddParameters("@devFlag", SqlDbType.Int, Convert.ToInt32(Entity.getDevelopmentRight(clsGbl.xmlPath)));

            Entity en = new Entity();
            int i = 0;
            try
            {
                i = (int)en.ReturnObject(iqtoolsConnString, ClsUtility.theParams, sp
                            , ClsUtility.ObjectEnum.ExecuteNonQuery, server);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (i != 0)
                    Console.WriteLine(ReportName + " Report log was Saved Successfully", "Save Report Log", MessageBoxButtons.OK);
                else
                {
                    if (MessageBox.Show("Oops, " + ReportName + " Report log was Not Saved. Please Try Again.", "Saving Report Log", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                        saveReportLog(SiteCode, ReportRunDate, ReportName, ReportADX, CreatedDate);
                }
            }

        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            Thread report = new Thread(() => runReport());
            report.SetApartmentState(ApartmentState.STA);
            report.Start();
        }

        private void runReport()
        {
            //DateTime localDate = new DateTime();
            //XmlDocument ReportADX;
            //ReportADX=xld.ToString();
            string connectionString = Entity.GetConnString();
            Entity en = new Entity();
            DataRow fDr = null;
            {
                fDr = (DataRow)en.ReturnObject(connectionString, ClsUtility.theParams
                      , "SELECT TOP 1 ConnString, DBase,MFLCode,DHISPortal FROM aa_Database"
                      , ClsUtility.ObjectEnum.DataRow, "mssql");
                DHIS2URL = fDr[3].ToString();
                MFLCode = fDr[2].ToString();

            }

            SetControlPropertyThreadSafe(fMain.picProgress, "Image", Properties.Resources.progressWheel5);
            SetControlPropertyThreadSafe(fMain.lblNotify, "Text", "Generating Report....");
            SetControlPropertyThreadSafe(this.btnGenerateReport, "Enabled", false);
            try
            {
                
                Hashtable rh = setParameters();
                ReportsManager RM = new ReportsManager();
                RM.runReport(rh,satellites,bySatellite,linelists, SendtoDHIS2);
                
                if (SendtoDHIS2 == true)
                {
                    //adx.Checked = false;
                    //frmDHISPassword DHIS2PW = new frmDHISPassword();
                    //DialogResult dr = DHIS2PW.ShowDialog();
                    
                    SendtoIL();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Assets.Messages.ErrorHeader);
            }
            finally
            {
                SetControlPropertyThreadSafe(fMain.picProgress, "Image", null);
                SetControlPropertyThreadSafe(fMain.lblNotify, "Text", "");
                SetControlPropertyThreadSafe(this.btnGenerateReport, "Enabled", true);
                //dhis.Checked = false;
                saveReportLog(MFLCode.ToString(), dh.dtpFromDate.Value, DHISReport, xld, DateTime.Now.Date);
            }
        }
        
        private void SendtoIL()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\Cohort\MoH_731_ADX.xml");
            

                ClsUtility.Init_Hashtable();
                //byte[] bytes = Encoding.UTF8.GetBytes(usernamePassword.ToCharArray());
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(DHIS2URL);
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(xmlDoc.InnerXml);
                //request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(bytes);
                request.Method = "POST";
                request.Accept = "application/adx+xml";
                request.ContentLength = buffer.Length;
                request.ContentType = "application/adx+xml";
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Close();
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    String respString;
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        respString = sr.ReadToEnd();
                    }

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        MessageBox.Show(respString);

                    }
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} {1}", ex.Message, "Post to DHIS ADX");
                MessageBox.Show(ex.Message, "Post to DHIS ADX");
            }
            finally
            { }
            Console.ReadLine();
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

        private Hashtable setParameters()
        {
            Hashtable rh = new Hashtable();
            rh.Add("ReportName", r["ReportName"].ToString());
            rh.Add("ExcelTemplateName", r["ExcelTemplateName"].ToString());
            rh.Add("ExcelWorksheetName", r["ExcelWorksheetName"].ToString());
            rh.Add("GroupName", r["GroupName"].ToString());
            ClsUtility.Init_Hashtable();
            DHISReport = r["ReportName"].ToString();
            foreach (Control c in tlPParameters.Controls)
            {               
                if (c.GetType().ToString().ToLower().Contains("checkbox"))
                {
                    string x = ReflectPropertyValue(c, "Checked").ToString();
                    ClsUtility.AddParameters("@"+c.Name, SqlDbType.VarChar, x);
                    if (c.Name.ToLower().Contains("bysatellite"))
                    {
                        bySatellite = Convert.ToBoolean(ReflectPropertyValue(c, "Checked").ToString());
                    }
                    if (c.Name.ToLower().Contains("linelist"))
                    {
                        linelists = Convert.ToBoolean(ReflectPropertyValue(c, "Checked").ToString());
                    }
                    if (c.Name.ToLower().Contains("sendtodhis2"))
                    {
                        SendtoDHIS2 = Convert.ToBoolean(ReflectPropertyValue(c, "Checked").ToString());
                        if (SendtoDHIS2==true)
                        {
                            createDHIS2XMLFileADX();

                        }                    
                        
    }
                   
                }
                else if (c.GetType().ToString().ToLower().Contains("datetime"))
                {
                    string x = ReflectPropertyValue(c, "Value").ToString();
                    ClsUtility.AddParameters("@" + c.Name, SqlDbType.VarChar, x);
                }
                else if (c.GetType().ToString().ToLower().Contains("textbox"))
                {
                    string x = ReflectPropertyValue(c, "Text").ToString();
                    ClsUtility.AddParameters("@" + c.Name, SqlDbType.VarChar, x);
                }
                else if (c.GetType().ToString().ToLower().Contains("iqtoolsreportdatescontrol"))
                {
                    //string x = ReflectPropertyValueDH(dh.dtpFromDate, "Value").ToString();
                    ClsUtility.AddParameters("@FromDate", SqlDbType.VarChar, dh.dtpFromDate.Value.ToString());
                    ClsUtility.AddParameters("@ToDate", SqlDbType.VarChar, dh.dtpToDate.Value.ToString());
                }
                
            }
     
            return rh;
        }

        public static object ReflectPropertyValue(object source, string property)
        {
            return source.GetType().GetProperty(property).GetValue(source, null);
        }        

        public class reportResource
        {
            private string displayName;
            private Uri url;

            public reportResource(string _displayName, Uri _url)
            {
                this.displayName = _displayName;
                this.url = _url;
            }

            public string DisplayName
            {
                get { return displayName; }
            }
            public Uri URL
            {
                get { return url; }
            }

        }
        public XmlDocument createDHIS2XMLFileADX()
        {
            theObject = new Entity();
            DateTimeOffset localDate = new DateTimeOffset(DateTime.Now, TimeZoneInfo.Local.GetUtcOffset(DateTime.Now));
            DHISADX = (DataTable)(theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT CatID FROM aa_Category WHERE Category = 'NASCOP MOH 731_2016'", ClsUtility.ObjectEnum.DataTable, clsGbl.PMMSType));
            //MFLCode = (DataTable)(theObject.ReturnObject(Entity.getconnString(clsGbl.xmlPath), ClsUtility.theParams, "SELECT CatID FROM aa_Category WHERE Category = 'NASCOP MOH 731_2016'", ClsUtility.ObjectEnum.DataTable, clsGbl.PMMSType));

            XmlTextWriter xtw = new XmlTextWriter("C:\\Cohort\\MoH_731_ADX.xml", System.Text.Encoding.UTF8);
            xtw.WriteStartDocument(true);
            xtw.Formatting = Formatting.Indented;
            xtw.Indentation = 2;

            xtw.WriteStartElement("adx");

            xtw.WriteAttributeString("xmlns", "urn:ihe:qrph:adx:2015");
            xtw.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xtw.WriteAttributeString("xsi:schemaLocation", "urn:ihe:qrph:adx:2015../schema/adx_loose.xsd");

            xtw.WriteAttributeString("exported", DateTime.Now.Date.ToString(" yyyy-mm-ddThh:mm:sszzzzzz"));
            

            xtw.WriteStartElement("group");
            xtw.WriteAttributeString("dataSet", "Vo4KDrUFwnA");
            xtw.WriteAttributeString("period", dh.dtpFromDate.Value.ToString("yyyy-MM-dd")+ "/P1M");
            xtw.WriteAttributeString("orgUnit", MFLCode.ToString()); 

            string connectionstring;
            connectionstring = Entity.getconnString(clsGbl.xmlPath);
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("[dbo].[pr_MOH731ADX2]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dh.dtpFromDate.Value.ToString();
            cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dh.dtpToDate.Value.ToString();
          
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(DHISADX);

            foreach (DataRow row in DHISADX.Rows)
            {
                if (DHISADX.Rows.IndexOf(row) != 0)
                {
                    xtw.WriteStartElement("dataValue");
                    xtw.WriteAttributeString("value", row["value"].ToString());
                    xtw.WriteAttributeString("dataElement", row["dataElement"].ToString());
                    xtw.WriteEndElement();
                }
            }

            xtw.WriteEndElement();
            xtw.WriteEndElement();
            xtw.WriteEndDocument();
            xtw.Close();

            //XmlDocument xld = new XmlDocument();
            xld.Load(@"C:\\Cohort\\MoH_731_ADX.xml");

            return xld;

        }
        private void populateReportResources(int reportID)
        {
            lstReportResources.DataSource = null;

            DataTable selectedReport = reportsDS.Tables[6].DefaultView.ToTable();
            selectedReport.DefaultView.RowFilter = "ReportID = " + reportID;
            selectedReport = selectedReport.DefaultView.ToTable();
            

            lstReportResources.DataSource = selectedReport;
            lstReportResources.DisplayMember = "DisplayName";
            lstReportResources.ValueMember = "ResourceURL";
            lstReportResources.ClearSelected();
        }

        private void lstReportResources_Click(object sender, EventArgs e)
        {
            if (lstReportResources.SelectedIndex != -1)
            {
                System.Diagnostics.Process.Start(lstReportResources.SelectedValue.ToString());
            }
        }

        private void lstReportResources_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
