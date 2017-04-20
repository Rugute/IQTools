using System.Windows.Forms;
namespace IQTools
{
  partial class frmMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose ( bool disposing )
    {
      if (disposing && (components != null))
      {

        components.Dispose ( );

      }
      base.Dispose ( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ( )
    {
            System.Windows.Forms.SplitContainer spCommon;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tlpCommon = new System.Windows.Forms.TableLayoutPanel();
            this.OptAR = new System.Windows.Forms.RadioButton();
            this.OptCDC = new System.Windows.Forms.RadioButton();
            this.optARTCohort = new System.Windows.Forms.RadioButton();
            this.flpCohortReport = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCohortReport = new System.Windows.Forms.Label();
            this.cboCohortFollowUp = new System.Windows.Forms.ComboBox();
            this.chkCohortReportLL = new System.Windows.Forms.CheckBox();
            this.optHIVQual = new System.Windows.Forms.RadioButton();
            this.panel63 = new System.Windows.Forms.Panel();
            this.gbCommon = new System.Windows.Forms.GroupBox();
            this.cboDonorCCC = new System.Windows.Forms.ComboBox();
            this.chkDonorCCC = new System.Windows.Forms.CheckBox();
            this.cboDonorLPTF = new System.Windows.Forms.ComboBox();
            this.chkDonorLPTF = new System.Windows.Forms.CheckBox();
            this.OptDonorAll = new System.Windows.Forms.RadioButton();
            this.OptDonorLPTF = new System.Windows.Forms.RadioButton();
            this.panel46 = new System.Windows.Forms.Panel();
            this.pgBCommon = new System.Windows.Forms.ProgressBar();
            this.cmdCReport = new System.Windows.Forms.Button();
            this.tpHelp = new System.Windows.Forms.TabPage();
            this.spcHelp = new System.Windows.Forms.SplitContainer();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.spcHelpTab = new System.Windows.Forms.SplitContainer();
            this.lstDocuments = new System.Windows.Forms.ListBox();
            this.webHelp = new System.Windows.Forms.WebBrowser();
            this.pnlVersionLabels = new System.Windows.Forms.Panel();
            this.lblAppVersion = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblDBVersion = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.tpAdmin = new System.Windows.Forms.TabPage();
            this.spcAdminTab = new System.Windows.Forms.SplitContainer();
            this.picAdmin = new System.Windows.Forms.PictureBox();
            this.tcAdmin = new System.Windows.Forms.TabControl();
            this.tpCats = new System.Windows.Forms.TabPage();
            this.panel58 = new System.Windows.Forms.Panel();
            this.spcQueryCategories = new System.Windows.Forms.SplitContainer();
            this.lstCats = new System.Windows.Forms.ListBox();
            this.spcQueryCategory = new System.Windows.Forms.SplitContainer();
            this.lblNewCat = new System.Windows.Forms.Label();
            this.cmdSQC = new System.Windows.Forms.Button();
            this.cmdASC = new System.Windows.Forms.Button();
            this.txtSbCats = new System.Windows.Forms.TextBox();
            this.lblQuerySubCategory = new System.Windows.Forms.Label();
            this.chkCatActive = new System.Windows.Forms.CheckBox();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            this.txtCats = new System.Windows.Forms.TextBox();
            this.lblQueryCategory = new System.Windows.Forms.Label();
            this.lstSubCats = new System.Windows.Forms.ListBox();
            this.pnlQueryCategories = new System.Windows.Forms.Panel();
            this.lblQuerySubCategories = new System.Windows.Forms.Label();
            this.tpEMaps = new System.Windows.Forms.TabPage();
            this.spcExcelMapping = new System.Windows.Forms.SplitContainer();
            this.panel29 = new System.Windows.Forms.Panel();
            this.lstQueries = new System.Windows.Forms.ListBox();
            this.panel30 = new System.Windows.Forms.Panel();
            this.lstCategories = new System.Windows.Forms.ListBox();
            this.panel28 = new System.Windows.Forms.Panel();
            this.lblExcelReport = new System.Windows.Forms.Label();
            this.cboReports = new System.Windows.Forms.ComboBox();
            this.pnlExcelMapping = new System.Windows.Forms.Panel();
            this.dgXls = new System.Windows.Forms.DataGridView();
            this.panel19 = new System.Windows.Forms.Panel();
            this.txtEDesc = new System.Windows.Forms.TextBox();
            this.panel31 = new System.Windows.Forms.Panel();
            this.cmdEMap = new System.Windows.Forms.Button();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.spcUsers = new System.Windows.Forms.SplitContainer();
            this.lblAddUser = new System.Windows.Forms.Label();
            this.txtCPWord = new System.Windows.Forms.TextBox();
            this.lblCPWord = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtPWord = new System.Windows.Forms.TextBox();
            this.lblPWord = new System.Windows.Forms.Label();
            this.cmdUpdateUser = new System.Windows.Forms.Button();
            this.txtIQName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.cboUserGroup = new System.Windows.Forms.ComboBox();
            this.chkUserActive = new System.Windows.Forms.CheckBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tpCReports = new System.Windows.Forms.TabPage();
            this.cmdCReportTemplate = new System.Windows.Forms.Button();
            this.txtCReportTemplate = new System.Windows.Forms.TextBox();
            this.lblExcelTemplate = new System.Windows.Forms.Label();
            this.cmdCReportNew = new System.Windows.Forms.Button();
            this.lblReportID = new System.Windows.Forms.Label();
            this.lblCReportId = new System.Windows.Forms.Label();
            this.chkDeleteCReport = new System.Windows.Forms.CheckBox();
            this.lstCReportsFilter = new System.Windows.Forms.ListView();
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdCReportSave = new System.Windows.Forms.Button();
            this.cboCReportFilterType = new System.Windows.Forms.ComboBox();
            this.lblFilterType = new System.Windows.Forms.Label();
            this.txtCReportDesc = new System.Windows.Forms.TextBox();
            this.lblReportDescription = new System.Windows.Forms.Label();
            this.dgvCReports = new System.Windows.Forms.DataGridView();
            this.txtCReportFilterName = new System.Windows.Forms.TextBox();
            this.cmdAddRemoveFilter = new System.Windows.Forms.Button();
            this.lblFilterName = new System.Windows.Forms.Label();
            this.cboCReportCategory = new System.Windows.Forms.ComboBox();
            this.lblCustomCategory = new System.Windows.Forms.Label();
            this.txtCReportName = new System.Windows.Forms.TextBox();
            this.lblReportName = new System.Windows.Forms.Label();
            this.tpDataConnection = new System.Windows.Forms.TabPage();
            this.pnlDataConnections = new System.Windows.Forms.Panel();
            this.prbLoad = new System.Windows.Forms.ProgressBar();
            this.cmdPMMS = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.Label();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.Database = new System.Windows.Forms.Label();
            this.cboDBase = new System.Windows.Forms.ComboBox();
            this.cmdDBLoad = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.Label();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.lblDatabaseType = new System.Windows.Forms.Label();
            this.cboServerType = new System.Windows.Forms.ComboBox();
            this.ofdUtility = new System.Windows.Forms.OpenFileDialog();
            this.tpSMS = new System.Windows.Forms.TabPage();
            this.tpQueries = new System.Windows.Forms.TabPage();
            this.tpReports = new System.Windows.Forms.TabPage();
            this.spcHome = new System.Windows.Forms.SplitContainer();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.tcReports = new System.Windows.Forms.TabControl();
            this.tpARTAdh = new System.Windows.Forms.TabPage();
            this.spcHomeTab1 = new System.Windows.Forms.SplitContainer();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.gbART = new System.Windows.Forms.GroupBox();
            this.lblLowVL = new System.Windows.Forms.Label();
            this.txtLowVL = new System.Windows.Forms.TextBox();
            this.optVLDetect = new System.Windows.Forms.RadioButton();
            this.optVL = new System.Windows.Forms.RadioButton();
            this.TxtMA = new System.Windows.Forms.TextBox();
            this.lblMA = new System.Windows.Forms.Label();
            this.OptMA = new System.Windows.Forms.RadioButton();
            this.optART = new System.Windows.Forms.RadioButton();
            this.txtHCD4 = new System.Windows.Forms.TextBox();
            this.txtLCD4 = new System.Windows.Forms.TextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.optNoARTNoCD4 = new System.Windows.Forms.RadioButton();
            this.optNoARTCD4XY = new System.Windows.Forms.RadioButton();
            this.dtpAllApp = new System.Windows.Forms.DateTimePicker();
            this.optAllApp = new System.Windows.Forms.RadioButton();
            this.label84 = new System.Windows.Forms.Label();
            this.dtpMAP = new System.Windows.Forms.DateTimePicker();
            this.optMAP = new System.Windows.Forms.RadioButton();
            this.cmdART = new System.Windows.Forms.Button();
            this.dgvAdherence = new System.Windows.Forms.DataGridView();
            this.tpDonor = new System.Windows.Forms.TabPage();
            this.spcHomeTab2 = new System.Windows.Forms.SplitContainer();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.lstPeriods = new System.Windows.Forms.ListBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.pnlCustomDates = new System.Windows.Forms.Panel();
            this.cboMonths = new System.Windows.Forms.ComboBox();
            this.txtSDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.txtQStart = new System.Windows.Forms.TextBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.txtEDate = new System.Windows.Forms.DateTimePicker();
            this.panel22 = new System.Windows.Forms.Panel();
            this.tcDonors = new System.Windows.Forms.TabControl();
            this.tpCommon = new System.Windows.Forms.TabPage();
            this.tpCountry = new System.Windows.Forms.TabPage();
            this.tcCountries = new System.Windows.Forms.TabControl();
            this.tpKe = new System.Windows.Forms.TabPage();
            this.SpKenya = new System.Windows.Forms.SplitContainer();
            this.tlp_KeReports = new System.Windows.Forms.TableLayoutPanel();
            this.optKe_FMAP = new System.Windows.Forms.RadioButton();
            this.OptKe_MoH711 = new System.Windows.Forms.RadioButton();
            this.optKe_MoH731 = new System.Windows.Forms.RadioButton();
            this.OptKe_RC = new System.Windows.Forms.RadioButton();
            this.OptKe_Lwak = new System.Windows.Forms.RadioButton();
            this.chk_RCLineLists = new System.Windows.Forms.CheckBox();
            this.optKe_MCHC = new System.Windows.Forms.RadioButton();
            this.optKE_PS = new System.Windows.Forms.RadioButton();
            this.flp_PS = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.cmdMultipleSummaries = new System.Windows.Forms.Button();
            this.optKe_TBC = new System.Windows.Forms.RadioButton();
            this.optKe_HEICA = new System.Windows.Forms.RadioButton();
            this.optKe_CDRR = new System.Windows.Forms.RadioButton();
            this.optKe_MoH361B = new System.Windows.Forms.RadioButton();
            this.optKe_Defaulter = new System.Windows.Forms.RadioButton();
            this.optKe_PwP = new System.Windows.Forms.RadioButton();
            this.optKe_TBRegister = new System.Windows.Forms.RadioButton();
            this.optke_OIDrugs = new System.Windows.Forms.RadioButton();
            this.optKe_MoH717 = new System.Windows.Forms.RadioButton();
            this.optKe_MoH705A = new System.Windows.Forms.RadioButton();
            this.optKe_MoH705B = new System.Windows.Forms.RadioButton();
            this.optHEIRegister = new System.Windows.Forms.RadioButton();
            this.prBKeReports = new System.Windows.Forms.ProgressBar();
            this.CmdKeReports = new System.Windows.Forms.Button();
            this.gbKenya = new System.Windows.Forms.GroupBox();
            this.chk_KESendToDHIS = new System.Windows.Forms.CheckBox();
            this.CboKECCC = new System.Windows.Forms.ComboBox();
            this.ChkKECCC = new System.Windows.Forms.CheckBox();
            this.cboKELPTF = new System.Windows.Forms.ComboBox();
            this.ChkKELPTF = new System.Windows.Forms.CheckBox();
            this.OptKEAll = new System.Windows.Forms.RadioButton();
            this.OptKELPTF = new System.Windows.Forms.RadioButton();
            this.tpUg = new System.Windows.Forms.TabPage();
            this.spUganda = new System.Windows.Forms.SplitContainer();
            this.OptUg_MoH = new System.Windows.Forms.RadioButton();
            this.optUg_CMR = new System.Windows.Forms.RadioButton();
            this.cmdUgReports = new System.Windows.Forms.Button();
            this.prBUgandaReports = new System.Windows.Forms.ProgressBar();
            this.txtUgNumDays = new System.Windows.Forms.TextBox();
            this.LblNumDays = new System.Windows.Forms.Label();
            this.gbUganda = new System.Windows.Forms.GroupBox();
            this.CboUgCCC = new System.Windows.Forms.ComboBox();
            this.chkUgCCC = new System.Windows.Forms.CheckBox();
            this.cboUgLPTF = new System.Windows.Forms.ComboBox();
            this.chkUgLPTF = new System.Windows.Forms.CheckBox();
            this.optUgAll = new System.Windows.Forms.RadioButton();
            this.optUgLPTF = new System.Windows.Forms.RadioButton();
            this.TpTz = new System.Windows.Forms.TabPage();
            this.spTanzania = new System.Windows.Forms.SplitContainer();
            this.optCDCTanzania = new System.Windows.Forms.RadioButton();
            this.optTzAPR = new System.Windows.Forms.RadioButton();
            this.optTzCSR = new System.Windows.Forms.RadioButton();
            this.cmdTzDonor = new System.Windows.Forms.Button();
            this.prBTZReports = new System.Windows.Forms.ProgressBar();
            this.gbTZ = new System.Windows.Forms.GroupBox();
            this.cboTzCCC = new System.Windows.Forms.ComboBox();
            this.chkTzCCC = new System.Windows.Forms.CheckBox();
            this.cboTzLPTF = new System.Windows.Forms.ComboBox();
            this.chkTzLPTF = new System.Windows.Forms.CheckBox();
            this.optTzAll = new System.Windows.Forms.RadioButton();
            this.optTzLPTF = new System.Windows.Forms.RadioButton();
            this.tpNg = new System.Windows.Forms.TabPage();
            this.spNigeria = new System.Windows.Forms.SplitContainer();
            this.optMonthlyNigeria = new System.Windows.Forms.RadioButton();
            this.optCDCNigeria = new System.Windows.Forms.RadioButton();
            this.cmdNigeriaDonor = new System.Windows.Forms.Button();
            this.prBNigeriaReports = new System.Windows.Forms.ProgressBar();
            this.gbNigeria = new System.Windows.Forms.GroupBox();
            this.cboNgCCC = new System.Windows.Forms.ComboBox();
            this.chkNgCCC = new System.Windows.Forms.CheckBox();
            this.cboNgLPTF = new System.Windows.Forms.ComboBox();
            this.chkNgLPTF = new System.Windows.Forms.CheckBox();
            this.optNgAll = new System.Windows.Forms.RadioButton();
            this.optNgLPTF = new System.Windows.Forms.RadioButton();
            this.tpHt = new System.Windows.Forms.TabPage();
            this.spHaiti = new System.Windows.Forms.SplitContainer();
            this.optHt_Monthly = new System.Windows.Forms.RadioButton();
            this.prBHaitiReports = new System.Windows.Forms.ProgressBar();
            this.cmdHtReport = new System.Windows.Forms.Button();
            this.gbHaiti = new System.Windows.Forms.GroupBox();
            this.cboHt_CCC = new System.Windows.Forms.ComboBox();
            this.chkHt_CCC = new System.Windows.Forms.CheckBox();
            this.chkHt_LPTF = new System.Windows.Forms.CheckBox();
            this.cboHt_LPTF = new System.Windows.Forms.ComboBox();
            this.optHt_LPTF = new System.Windows.Forms.RadioButton();
            this.optHt_All = new System.Windows.Forms.RadioButton();
            this.tpDonorCustomReport = new System.Windows.Forms.TabPage();
            this.gbCReportFilters = new System.Windows.Forms.GroupBox();
            this.cboGenerateCReport = new System.Windows.Forms.Button();
            this.pnlCReportFilters = new System.Windows.Forms.Panel();
            this.cboCustomReport = new System.Windows.Forms.ComboBox();
            this.label149 = new System.Windows.Forms.Label();
            this.spCD4s = new System.Windows.Forms.Panel();
            this.lblCD4Cuttoff = new System.Windows.Forms.Label();
            this.txtCD4 = new System.Windows.Forms.TextBox();
            this.tpClinical = new System.Windows.Forms.TabPage();
            this.spcClinicalTab = new System.Windows.Forms.SplitContainer();
            this.lstClinical = new System.Windows.Forms.ListBox();
            this.dgvClinical = new System.Windows.Forms.DataGridView();
            this.pnlClinical = new System.Windows.Forms.Panel();
            this.cboClinical = new System.Windows.Forms.ComboBox();
            this.cmdClinical = new System.Windows.Forms.Button();
            this.tpComparisons = new System.Windows.Forms.TabPage();
            this.lblRComparisons = new System.Windows.Forms.Label();
            this.spcComparisonsTab = new System.Windows.Forms.SplitContainer();
            this.lstComparisons = new System.Windows.Forms.ListBox();
            this.dgvComparisons = new System.Windows.Forms.DataGridView();
            this.pnlComparisons = new System.Windows.Forms.Panel();
            this.cboComparisons = new System.Windows.Forms.ComboBox();
            this.cmdCmp = new System.Windows.Forms.Button();
            this.tpVals = new System.Windows.Forms.TabPage();
            this.spcValidationsTab = new System.Windows.Forms.SplitContainer();
            this.lstValidations = new System.Windows.Forms.ListBox();
            this.dgvValidations = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cboValidations = new System.Windows.Forms.ComboBox();
            this.cmdVals = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpNewReports = new System.Windows.Forms.TabPage();
            this.tpEMRAccess = new System.Windows.Forms.TabPage();
            this.tpForum = new System.Windows.Forms.TabPage();
            this.panel59 = new System.Windows.Forms.Panel();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.cboMainLanguage = new System.Windows.Forms.ComboBox();
            this.label148 = new System.Windows.Forms.Label();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.lblNotify = new System.Windows.Forms.Label();
            this.picProgress = new System.Windows.Forms.PictureBox();
            this.pictureBox31 = new System.Windows.Forms.PictureBox();
            spCommon = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(spCommon)).BeginInit();
            spCommon.Panel1.SuspendLayout();
            spCommon.Panel2.SuspendLayout();
            spCommon.SuspendLayout();
            this.tlpCommon.SuspendLayout();
            this.flpCohortReport.SuspendLayout();
            this.panel63.SuspendLayout();
            this.gbCommon.SuspendLayout();
            this.panel46.SuspendLayout();
            this.tpHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcHelp)).BeginInit();
            this.spcHelp.Panel1.SuspendLayout();
            this.spcHelp.Panel2.SuspendLayout();
            this.spcHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcHelpTab)).BeginInit();
            this.spcHelpTab.Panel1.SuspendLayout();
            this.spcHelpTab.Panel2.SuspendLayout();
            this.spcHelpTab.SuspendLayout();
            this.pnlVersionLabels.SuspendLayout();
            this.tpAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcAdminTab)).BeginInit();
            this.spcAdminTab.Panel1.SuspendLayout();
            this.spcAdminTab.Panel2.SuspendLayout();
            this.spcAdminTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdmin)).BeginInit();
            this.tcAdmin.SuspendLayout();
            this.tpCats.SuspendLayout();
            this.panel58.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcQueryCategories)).BeginInit();
            this.spcQueryCategories.Panel1.SuspendLayout();
            this.spcQueryCategories.Panel2.SuspendLayout();
            this.spcQueryCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcQueryCategory)).BeginInit();
            this.spcQueryCategory.Panel1.SuspendLayout();
            this.spcQueryCategory.Panel2.SuspendLayout();
            this.spcQueryCategory.SuspendLayout();
            this.pnlQueryCategories.SuspendLayout();
            this.tpEMaps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcExcelMapping)).BeginInit();
            this.spcExcelMapping.Panel1.SuspendLayout();
            this.spcExcelMapping.Panel2.SuspendLayout();
            this.spcExcelMapping.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel28.SuspendLayout();
            this.pnlExcelMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgXls)).BeginInit();
            this.panel19.SuspendLayout();
            this.panel31.SuspendLayout();
            this.tpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcUsers)).BeginInit();
            this.spcUsers.Panel1.SuspendLayout();
            this.spcUsers.Panel2.SuspendLayout();
            this.spcUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tpCReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCReports)).BeginInit();
            this.tpDataConnection.SuspendLayout();
            this.pnlDataConnections.SuspendLayout();
            this.tpReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcHome)).BeginInit();
            this.spcHome.Panel1.SuspendLayout();
            this.spcHome.Panel2.SuspendLayout();
            this.spcHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.tcReports.SuspendLayout();
            this.tpARTAdh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcHomeTab1)).BeginInit();
            this.spcHomeTab1.Panel1.SuspendLayout();
            this.spcHomeTab1.Panel2.SuspendLayout();
            this.spcHomeTab1.SuspendLayout();
            this.pnlHome.SuspendLayout();
            this.gbART.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdherence)).BeginInit();
            this.tpDonor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcHomeTab2)).BeginInit();
            this.spcHomeTab2.Panel1.SuspendLayout();
            this.spcHomeTab2.Panel2.SuspendLayout();
            this.spcHomeTab2.SuspendLayout();
            this.pnlCustomDates.SuspendLayout();
            this.panel22.SuspendLayout();
            this.tcDonors.SuspendLayout();
            this.tpCommon.SuspendLayout();
            this.tpCountry.SuspendLayout();
            this.tcCountries.SuspendLayout();
            this.tpKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpKenya)).BeginInit();
            this.SpKenya.Panel1.SuspendLayout();
            this.SpKenya.Panel2.SuspendLayout();
            this.SpKenya.SuspendLayout();
            this.tlp_KeReports.SuspendLayout();
            this.flp_PS.SuspendLayout();
            this.gbKenya.SuspendLayout();
            this.tpUg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spUganda)).BeginInit();
            this.spUganda.Panel1.SuspendLayout();
            this.spUganda.Panel2.SuspendLayout();
            this.spUganda.SuspendLayout();
            this.gbUganda.SuspendLayout();
            this.TpTz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spTanzania)).BeginInit();
            this.spTanzania.Panel1.SuspendLayout();
            this.spTanzania.Panel2.SuspendLayout();
            this.spTanzania.SuspendLayout();
            this.gbTZ.SuspendLayout();
            this.tpNg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spNigeria)).BeginInit();
            this.spNigeria.Panel1.SuspendLayout();
            this.spNigeria.Panel2.SuspendLayout();
            this.spNigeria.SuspendLayout();
            this.gbNigeria.SuspendLayout();
            this.tpHt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spHaiti)).BeginInit();
            this.spHaiti.Panel1.SuspendLayout();
            this.spHaiti.Panel2.SuspendLayout();
            this.spHaiti.SuspendLayout();
            this.gbHaiti.SuspendLayout();
            this.tpDonorCustomReport.SuspendLayout();
            this.gbCReportFilters.SuspendLayout();
            this.spCD4s.SuspendLayout();
            this.tpClinical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcClinicalTab)).BeginInit();
            this.spcClinicalTab.Panel1.SuspendLayout();
            this.spcClinicalTab.Panel2.SuspendLayout();
            this.spcClinicalTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinical)).BeginInit();
            this.pnlClinical.SuspendLayout();
            this.tpComparisons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcComparisonsTab)).BeginInit();
            this.spcComparisonsTab.Panel1.SuspendLayout();
            this.spcComparisonsTab.Panel2.SuspendLayout();
            this.spcComparisonsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparisons)).BeginInit();
            this.pnlComparisons.SuspendLayout();
            this.tpVals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcValidationsTab)).BeginInit();
            this.spcValidationsTab.Panel1.SuspendLayout();
            this.spcValidationsTab.Panel2.SuspendLayout();
            this.spcValidationsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidations)).BeginInit();
            this.panel6.SuspendLayout();
            this.tcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).BeginInit();
            this.SuspendLayout();
            // 
            // spCommon
            // 
            spCommon.BackColor = System.Drawing.Color.Transparent;
            spCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            spCommon.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            spCommon.IsSplitterFixed = true;
            spCommon.Location = new System.Drawing.Point(0, 0);
            spCommon.Margin = new System.Windows.Forms.Padding(0);
            spCommon.Name = "spCommon";
            // 
            // spCommon.Panel1
            // 
            spCommon.Panel1.AutoScroll = true;
            spCommon.Panel1.Controls.Add(this.tlpCommon);
            // 
            // spCommon.Panel2
            // 
            spCommon.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            spCommon.Panel2.Controls.Add(this.panel63);
            spCommon.Panel2.Controls.Add(this.panel46);
            spCommon.Size = new System.Drawing.Size(997, 358);
            spCommon.SplitterDistance = 809;
            spCommon.SplitterWidth = 1;
            spCommon.TabIndex = 15;
            // 
            // tlpCommon
            // 
            this.tlpCommon.BackColor = System.Drawing.Color.Transparent;
            this.tlpCommon.ColumnCount = 3;
            this.tlpCommon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCommon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCommon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCommon.Controls.Add(this.OptAR, 0, 0);
            this.tlpCommon.Controls.Add(this.OptCDC, 0, 1);
            this.tlpCommon.Controls.Add(this.optARTCohort, 0, 2);
            this.tlpCommon.Controls.Add(this.flpCohortReport, 1, 2);
            this.tlpCommon.Controls.Add(this.chkCohortReportLL, 2, 2);
            this.tlpCommon.Controls.Add(this.optHIVQual, 0, 4);
            this.tlpCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCommon.Location = new System.Drawing.Point(0, 0);
            this.tlpCommon.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCommon.Name = "tlpCommon";
            this.tlpCommon.RowCount = 15;
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCommon.Size = new System.Drawing.Size(809, 358);
            this.tlpCommon.TabIndex = 0;
            // 
            // OptAR
            // 
            this.OptAR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OptAR.AutoSize = true;
            this.OptAR.Location = new System.Drawing.Point(3, 3);
            this.OptAR.Name = "OptAR";
            this.OptAR.Size = new System.Drawing.Size(307, 24);
            this.OptAR.TabIndex = 7;
            this.OptAR.Text = "HIV Care And Treatment (Monthly) Report";
            this.OptAR.UseVisualStyleBackColor = true;
            // 
            // OptCDC
            // 
            this.OptCDC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OptCDC.AutoSize = true;
            this.OptCDC.Location = new System.Drawing.Point(3, 33);
            this.OptCDC.Name = "OptCDC";
            this.OptCDC.Size = new System.Drawing.Size(244, 24);
            this.OptCDC.TabIndex = 6;
            this.OptCDC.Text = "CDC Track 1.0 (Quarterly) Report";
            this.OptCDC.UseVisualStyleBackColor = true;
            // 
            // optARTCohort
            // 
            this.optARTCohort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.optARTCohort.AutoSize = true;
            this.optARTCohort.Location = new System.Drawing.Point(3, 68);
            this.optARTCohort.Name = "optARTCohort";
            this.optARTCohort.Size = new System.Drawing.Size(211, 24);
            this.optARTCohort.TabIndex = 9;
            this.optARTCohort.Text = "ART Cohort Analysis Report";
            this.optARTCohort.UseVisualStyleBackColor = true;
            this.optARTCohort.CheckedChanged += new System.EventHandler(this.optARTCohort_CheckedChanged);
            // 
            // flpCohortReport
            // 
            this.flpCohortReport.AutoSize = true;
            this.flpCohortReport.Controls.Add(this.lblCohortReport);
            this.flpCohortReport.Controls.Add(this.cboCohortFollowUp);
            this.flpCohortReport.Enabled = false;
            this.flpCohortReport.Location = new System.Drawing.Point(316, 63);
            this.flpCohortReport.Name = "flpCohortReport";
            this.flpCohortReport.Size = new System.Drawing.Size(220, 34);
            this.flpCohortReport.TabIndex = 10;
            // 
            // lblCohortReport
            // 
            this.lblCohortReport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCohortReport.AutoSize = true;
            this.lblCohortReport.Location = new System.Drawing.Point(3, 7);
            this.lblCohortReport.Name = "lblCohortReport";
            this.lblCohortReport.Size = new System.Drawing.Size(121, 20);
            this.lblCohortReport.TabIndex = 11;
            this.lblCohortReport.Text = "Followed Up For:";
            // 
            // cboCohortFollowUp
            // 
            this.cboCohortFollowUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCohortFollowUp.FormattingEnabled = true;
            this.cboCohortFollowUp.Items.AddRange(new object[] {
            "12 Months",
            "24 Months",
            "36 Months",
            "48 Months",
            "60 Months"});
            this.cboCohortFollowUp.Location = new System.Drawing.Point(130, 3);
            this.cboCohortFollowUp.Name = "cboCohortFollowUp";
            this.cboCohortFollowUp.Size = new System.Drawing.Size(87, 28);
            this.cboCohortFollowUp.TabIndex = 10;
            this.cboCohortFollowUp.Text = "12 Months";
            // 
            // chkCohortReportLL
            // 
            this.chkCohortReportLL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkCohortReportLL.AutoSize = true;
            this.chkCohortReportLL.Enabled = false;
            this.chkCohortReportLL.Location = new System.Drawing.Point(542, 68);
            this.chkCohortReportLL.Name = "chkCohortReportLL";
            this.chkCohortReportLL.Size = new System.Drawing.Size(136, 24);
            this.chkCohortReportLL.TabIndex = 11;
            this.chkCohortReportLL.Text = "Include Line List";
            this.chkCohortReportLL.UseVisualStyleBackColor = true;
            // 
            // optHIVQual
            // 
            this.optHIVQual.AutoSize = true;
            this.optHIVQual.Location = new System.Drawing.Point(3, 103);
            this.optHIVQual.Name = "optHIVQual";
            this.optHIVQual.Size = new System.Drawing.Size(160, 24);
            this.optHIVQual.TabIndex = 12;
            this.optHIVQual.Text = "QI Summary Report";
            this.optHIVQual.UseVisualStyleBackColor = true;
            // 
            // panel63
            // 
            this.panel63.AutoScroll = true;
            this.panel63.Controls.Add(this.gbCommon);
            this.panel63.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel63.Location = new System.Drawing.Point(0, 0);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(187, 312);
            this.panel63.TabIndex = 13;
            // 
            // gbCommon
            // 
            this.gbCommon.Controls.Add(this.cboDonorCCC);
            this.gbCommon.Controls.Add(this.chkDonorCCC);
            this.gbCommon.Controls.Add(this.cboDonorLPTF);
            this.gbCommon.Controls.Add(this.chkDonorLPTF);
            this.gbCommon.Controls.Add(this.OptDonorAll);
            this.gbCommon.Controls.Add(this.OptDonorLPTF);
            this.gbCommon.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCommon.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.gbCommon.Location = new System.Drawing.Point(0, 0);
            this.gbCommon.Name = "gbCommon";
            this.gbCommon.Size = new System.Drawing.Size(187, 164);
            this.gbCommon.TabIndex = 10;
            this.gbCommon.TabStop = false;
            this.gbCommon.Text = "Location";
            // 
            // cboDonorCCC
            // 
            this.cboDonorCCC.FormattingEnabled = true;
            this.cboDonorCCC.Location = new System.Drawing.Point(66, 134);
            this.cboDonorCCC.Name = "cboDonorCCC";
            this.cboDonorCCC.Size = new System.Drawing.Size(144, 28);
            this.cboDonorCCC.TabIndex = 4;
            this.cboDonorCCC.SelectedIndexChanged += new System.EventHandler(this.cboDonorCCC_SelectedIndexChanged);
            // 
            // chkDonorCCC
            // 
            this.chkDonorCCC.AutoSize = true;
            this.chkDonorCCC.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkDonorCCC.Location = new System.Drawing.Point(9, 136);
            this.chkDonorCCC.Name = "chkDonorCCC";
            this.chkDonorCCC.Size = new System.Drawing.Size(61, 24);
            this.chkDonorCCC.TabIndex = 7;
            this.chkDonorCCC.Text = "CCC:";
            this.chkDonorCCC.UseVisualStyleBackColor = true;
            this.chkDonorCCC.CheckedChanged += new System.EventHandler(this.chkDonorCCC_CheckedChanged);
            // 
            // cboDonorLPTF
            // 
            this.cboDonorLPTF.FormattingEnabled = true;
            this.cboDonorLPTF.Location = new System.Drawing.Point(66, 70);
            this.cboDonorLPTF.Name = "cboDonorLPTF";
            this.cboDonorLPTF.Size = new System.Drawing.Size(144, 28);
            this.cboDonorLPTF.TabIndex = 6;
            this.cboDonorLPTF.SelectedIndexChanged += new System.EventHandler(this.cboDonorLPTF_SelectedIndexChanged);
            // 
            // chkDonorLPTF
            // 
            this.chkDonorLPTF.AutoSize = true;
            this.chkDonorLPTF.Enabled = false;
            this.chkDonorLPTF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkDonorLPTF.Location = new System.Drawing.Point(66, 97);
            this.chkDonorLPTF.Name = "chkDonorLPTF";
            this.chkDonorLPTF.Size = new System.Drawing.Size(158, 24);
            this.chkDonorLPTF.TabIndex = 3;
            this.chkDonorLPTF.Text = "Disaggragate CCCs";
            this.chkDonorLPTF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDonorLPTF.UseVisualStyleBackColor = true;
            this.chkDonorLPTF.CheckedChanged += new System.EventHandler(this.chkDonorLPTF_CheckedChanged);
            // 
            // OptDonorAll
            // 
            this.OptDonorAll.AutoSize = true;
            this.OptDonorAll.Checked = true;
            this.OptDonorAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OptDonorAll.Location = new System.Drawing.Point(9, 34);
            this.OptDonorAll.Name = "OptDonorAll";
            this.OptDonorAll.Size = new System.Drawing.Size(84, 24);
            this.OptDonorAll.TabIndex = 2;
            this.OptDonorAll.TabStop = true;
            this.OptDonorAll.Text = "All Data";
            this.OptDonorAll.UseVisualStyleBackColor = true;
            // 
            // OptDonorLPTF
            // 
            this.OptDonorLPTF.AutoSize = true;
            this.OptDonorLPTF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OptDonorLPTF.Location = new System.Drawing.Point(9, 71);
            this.OptDonorLPTF.Name = "OptDonorLPTF";
            this.OptDonorLPTF.Size = new System.Drawing.Size(60, 24);
            this.OptDonorLPTF.TabIndex = 0;
            this.OptDonorLPTF.Text = "LPTF";
            this.OptDonorLPTF.UseVisualStyleBackColor = true;
            this.OptDonorLPTF.CheckedChanged += new System.EventHandler(this.OptDonorLPTF_CheckedChanged);
            // 
            // panel46
            // 
            this.panel46.Controls.Add(this.pgBCommon);
            this.panel46.Controls.Add(this.cmdCReport);
            this.panel46.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel46.Location = new System.Drawing.Point(0, 312);
            this.panel46.Name = "panel46";
            this.panel46.Padding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.panel46.Size = new System.Drawing.Size(187, 46);
            this.panel46.TabIndex = 12;
            // 
            // pgBCommon
            // 
            this.pgBCommon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgBCommon.Location = new System.Drawing.Point(3, 38);
            this.pgBCommon.Name = "pgBCommon";
            this.pgBCommon.Size = new System.Drawing.Size(177, 5);
            this.pgBCommon.TabIndex = 12;
            // 
            // cmdCReport
            // 
            this.cmdCReport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdCReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdCReport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCReport.Location = new System.Drawing.Point(3, 3);
            this.cmdCReport.Name = "cmdCReport";
            this.cmdCReport.Size = new System.Drawing.Size(177, 31);
            this.cmdCReport.TabIndex = 11;
            this.cmdCReport.Text = "Generate Report";
            this.cmdCReport.UseVisualStyleBackColor = false;
            this.cmdCReport.Click += new System.EventHandler(this.cmdCReport_Click);
            // 
            // tpHelp
            // 
            this.tpHelp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpHelp.Controls.Add(this.spcHelp);
            this.tpHelp.Location = new System.Drawing.Point(4, 29);
            this.tpHelp.Margin = new System.Windows.Forms.Padding(0);
            this.tpHelp.Name = "tpHelp";
            this.tpHelp.Size = new System.Drawing.Size(1299, 516);
            this.tpHelp.TabIndex = 7;
            this.tpHelp.Text = "Help";
            // 
            // spcHelp
            // 
            this.spcHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcHelp.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcHelp.IsSplitterFixed = true;
            this.spcHelp.Location = new System.Drawing.Point(0, 0);
            this.spcHelp.Name = "spcHelp";
            this.spcHelp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcHelp.Panel1
            // 
            this.spcHelp.Panel1.BackColor = System.Drawing.Color.White;
            this.spcHelp.Panel1.Controls.Add(this.picHelp);
            // 
            // spcHelp.Panel2
            // 
            this.spcHelp.Panel2.Controls.Add(this.spcHelpTab);
            this.spcHelp.Size = new System.Drawing.Size(1299, 516);
            this.spcHelp.SplitterDistance = 60;
            this.spcHelp.SplitterWidth = 1;
            this.spcHelp.TabIndex = 5;
            // 
            // picHelp
            // 
            this.picHelp.BackColor = System.Drawing.Color.White;
            this.picHelp.Dock = System.Windows.Forms.DockStyle.Left;
            this.picHelp.Image = global::IQTools.Properties.Resources.iqtools;
            this.picHelp.InitialImage = null;
            this.picHelp.Location = new System.Drawing.Point(0, 0);
            this.picHelp.Margin = new System.Windows.Forms.Padding(0);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(228, 60);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 2;
            this.picHelp.TabStop = false;
            // 
            // spcHelpTab
            // 
            this.spcHelpTab.BackColor = System.Drawing.Color.Transparent;
            this.spcHelpTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcHelpTab.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcHelpTab.IsSplitterFixed = true;
            this.spcHelpTab.Location = new System.Drawing.Point(0, 0);
            this.spcHelpTab.Margin = new System.Windows.Forms.Padding(0);
            this.spcHelpTab.Name = "spcHelpTab";
            // 
            // spcHelpTab.Panel1
            // 
            this.spcHelpTab.Panel1.Controls.Add(this.lstDocuments);
            this.spcHelpTab.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // spcHelpTab.Panel2
            // 
            this.spcHelpTab.Panel2.Controls.Add(this.webHelp);
            this.spcHelpTab.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.spcHelpTab.Size = new System.Drawing.Size(1299, 455);
            this.spcHelpTab.SplitterDistance = 239;
            this.spcHelpTab.SplitterWidth = 1;
            this.spcHelpTab.TabIndex = 4;
            // 
            // lstDocuments
            // 
            this.lstDocuments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.lstDocuments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDocuments.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDocuments.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lstDocuments.FormattingEnabled = true;
            this.lstDocuments.ItemHeight = 21;
            this.lstDocuments.Items.AddRange(new object[] {
            "Query Guide"});
            this.lstDocuments.Location = new System.Drawing.Point(5, 5);
            this.lstDocuments.Name = "lstDocuments";
            this.lstDocuments.Size = new System.Drawing.Size(229, 445);
            this.lstDocuments.TabIndex = 1;
            this.lstDocuments.SelectedIndexChanged += new System.EventHandler(this.lstDocuments_SelectedIndexChanged);
            // 
            // webHelp
            // 
            this.webHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webHelp.Location = new System.Drawing.Point(5, 5);
            this.webHelp.Margin = new System.Windows.Forms.Padding(0);
            this.webHelp.MinimumSize = new System.Drawing.Size(20, 20);
            this.webHelp.Name = "webHelp";
            this.webHelp.Size = new System.Drawing.Size(1049, 445);
            this.webHelp.TabIndex = 0;
            this.webHelp.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // pnlVersionLabels
            // 
            this.pnlVersionLabels.BackColor = System.Drawing.Color.Transparent;
            this.pnlVersionLabels.Controls.Add(this.lblAppVersion);
            this.pnlVersionLabels.Controls.Add(this.txtVersion);
            this.pnlVersionLabels.Controls.Add(this.lblDBVersion);
            this.pnlVersionLabels.Controls.Add(this.txtDate);
            this.pnlVersionLabels.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlVersionLabels.Location = new System.Drawing.Point(1023, 0);
            this.pnlVersionLabels.Name = "pnlVersionLabels";
            this.pnlVersionLabels.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlVersionLabels.Size = new System.Drawing.Size(284, 32);
            this.pnlVersionLabels.TabIndex = 7;
            // 
            // lblAppVersion
            // 
            this.lblAppVersion.AutoSize = true;
            this.lblAppVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblAppVersion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppVersion.ForeColor = System.Drawing.Color.White;
            this.lblAppVersion.Location = new System.Drawing.Point(3, 10);
            this.lblAppVersion.Name = "lblAppVersion";
            this.lblAppVersion.Size = new System.Drawing.Size(97, 17);
            this.lblAppVersion.TabIndex = 7;
            this.lblAppVersion.Text = "IQTools Version:";
            this.lblAppVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVersion
            // 
            this.txtVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVersion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersion.ForeColor = System.Drawing.Color.White;
            this.txtVersion.Location = new System.Drawing.Point(85, 10);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(50, 17);
            this.txtVersion.TabIndex = 8;
            this.txtVersion.Text = "AppVersion";
            // 
            // lblDBVersion
            // 
            this.lblDBVersion.AutoSize = true;
            this.lblDBVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblDBVersion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBVersion.ForeColor = System.Drawing.Color.White;
            this.lblDBVersion.Location = new System.Drawing.Point(141, 10);
            this.lblDBVersion.Name = "lblDBVersion";
            this.lblDBVersion.Size = new System.Drawing.Size(110, 17);
            this.lblDBVersion.TabIndex = 5;
            this.lblDBVersion.Text = "Database Version:";
            this.lblDBVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDate.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.ForeColor = System.Drawing.Color.White;
            this.txtDate.Location = new System.Drawing.Point(234, 10);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(50, 17);
            this.txtDate.TabIndex = 6;
            this.txtDate.Text = "DBVersion";
            this.txtDate.DoubleClick += new System.EventHandler(this.txtDate_DoubleClick);
            // 
            // tpAdmin
            // 
            this.tpAdmin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpAdmin.Controls.Add(this.spcAdminTab);
            this.tpAdmin.Location = new System.Drawing.Point(4, 29);
            this.tpAdmin.Margin = new System.Windows.Forms.Padding(0);
            this.tpAdmin.Name = "tpAdmin";
            this.tpAdmin.Size = new System.Drawing.Size(1299, 516);
            this.tpAdmin.TabIndex = 1;
            this.tpAdmin.Text = "Administration";
            // 
            // spcAdminTab
            // 
            this.spcAdminTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcAdminTab.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcAdminTab.IsSplitterFixed = true;
            this.spcAdminTab.Location = new System.Drawing.Point(0, 0);
            this.spcAdminTab.Margin = new System.Windows.Forms.Padding(0);
            this.spcAdminTab.Name = "spcAdminTab";
            this.spcAdminTab.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcAdminTab.Panel1
            // 
            this.spcAdminTab.Panel1.BackColor = System.Drawing.Color.White;
            this.spcAdminTab.Panel1.Controls.Add(this.picAdmin);
            // 
            // spcAdminTab.Panel2
            // 
            this.spcAdminTab.Panel2.Controls.Add(this.tcAdmin);
            this.spcAdminTab.Size = new System.Drawing.Size(1299, 516);
            this.spcAdminTab.SplitterDistance = 60;
            this.spcAdminTab.SplitterWidth = 1;
            this.spcAdminTab.TabIndex = 3;
            // 
            // picAdmin
            // 
            this.picAdmin.BackColor = System.Drawing.Color.White;
            this.picAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.picAdmin.Image = global::IQTools.Properties.Resources.iqtools;
            this.picAdmin.InitialImage = null;
            this.picAdmin.Location = new System.Drawing.Point(0, 0);
            this.picAdmin.Margin = new System.Windows.Forms.Padding(0);
            this.picAdmin.Name = "picAdmin";
            this.picAdmin.Size = new System.Drawing.Size(228, 60);
            this.picAdmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAdmin.TabIndex = 2;
            this.picAdmin.TabStop = false;
            // 
            // tcAdmin
            // 
            this.tcAdmin.Controls.Add(this.tpCats);
            this.tcAdmin.Controls.Add(this.tpEMaps);
            this.tcAdmin.Controls.Add(this.tpUsers);
            this.tcAdmin.Controls.Add(this.tpCReports);
            this.tcAdmin.Controls.Add(this.tpDataConnection);
            this.tcAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAdmin.Location = new System.Drawing.Point(0, 0);
            this.tcAdmin.Margin = new System.Windows.Forms.Padding(0);
            this.tcAdmin.Name = "tcAdmin";
            this.tcAdmin.Padding = new System.Drawing.Point(0, 0);
            this.tcAdmin.SelectedIndex = 0;
            this.tcAdmin.Size = new System.Drawing.Size(1299, 455);
            this.tcAdmin.TabIndex = 2;
            this.tcAdmin.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcAdmin_Selected);
            // 
            // tpCats
            // 
            this.tpCats.BackColor = System.Drawing.Color.Transparent;
            this.tpCats.Controls.Add(this.panel58);
            this.tpCats.Location = new System.Drawing.Point(4, 29);
            this.tpCats.Margin = new System.Windows.Forms.Padding(0);
            this.tpCats.Name = "tpCats";
            this.tpCats.Size = new System.Drawing.Size(1291, 422);
            this.tpCats.TabIndex = 9;
            this.tpCats.Text = "Query Categories";
            // 
            // panel58
            // 
            this.panel58.Controls.Add(this.spcQueryCategories);
            this.panel58.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel58.Location = new System.Drawing.Point(0, 0);
            this.panel58.Name = "panel58";
            this.panel58.Padding = new System.Windows.Forms.Padding(5);
            this.panel58.Size = new System.Drawing.Size(1291, 422);
            this.panel58.TabIndex = 27;
            // 
            // spcQueryCategories
            // 
            this.spcQueryCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcQueryCategories.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcQueryCategories.IsSplitterFixed = true;
            this.spcQueryCategories.Location = new System.Drawing.Point(5, 5);
            this.spcQueryCategories.Margin = new System.Windows.Forms.Padding(0);
            this.spcQueryCategories.Name = "spcQueryCategories";
            // 
            // spcQueryCategories.Panel1
            // 
            this.spcQueryCategories.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.spcQueryCategories.Panel1.Controls.Add(this.lstCats);
            // 
            // spcQueryCategories.Panel2
            // 
            this.spcQueryCategories.Panel2.Controls.Add(this.spcQueryCategory);
            this.spcQueryCategories.Size = new System.Drawing.Size(1281, 412);
            this.spcQueryCategories.SplitterDistance = 300;
            this.spcQueryCategories.SplitterWidth = 1;
            this.spcQueryCategories.TabIndex = 26;
            // 
            // lstCats
            // 
            this.lstCats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.lstCats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCats.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lstCats.FormattingEnabled = true;
            this.lstCats.ItemHeight = 20;
            this.lstCats.Location = new System.Drawing.Point(0, 0);
            this.lstCats.Margin = new System.Windows.Forms.Padding(0);
            this.lstCats.Name = "lstCats";
            this.lstCats.Size = new System.Drawing.Size(300, 412);
            this.lstCats.TabIndex = 1;
            this.lstCats.SelectedIndexChanged += new System.EventHandler(this.lstCats_SelectedIndexChanged);
            // 
            // spcQueryCategory
            // 
            this.spcQueryCategory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spcQueryCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcQueryCategory.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcQueryCategory.IsSplitterFixed = true;
            this.spcQueryCategory.Location = new System.Drawing.Point(0, 0);
            this.spcQueryCategory.Name = "spcQueryCategory";
            this.spcQueryCategory.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcQueryCategory.Panel1
            // 
            this.spcQueryCategory.Panel1.Controls.Add(this.lblNewCat);
            this.spcQueryCategory.Panel1.Controls.Add(this.cmdSQC);
            this.spcQueryCategory.Panel1.Controls.Add(this.cmdASC);
            this.spcQueryCategory.Panel1.Controls.Add(this.txtSbCats);
            this.spcQueryCategory.Panel1.Controls.Add(this.lblQuerySubCategory);
            this.spcQueryCategory.Panel1.Controls.Add(this.chkCatActive);
            this.spcQueryCategory.Panel1.Controls.Add(this.chkExcel);
            this.spcQueryCategory.Panel1.Controls.Add(this.txtCats);
            this.spcQueryCategory.Panel1.Controls.Add(this.lblQueryCategory);
            // 
            // spcQueryCategory.Panel2
            // 
            this.spcQueryCategory.Panel2.Controls.Add(this.lstSubCats);
            this.spcQueryCategory.Panel2.Controls.Add(this.pnlQueryCategories);
            this.spcQueryCategory.Size = new System.Drawing.Size(980, 412);
            this.spcQueryCategory.SplitterDistance = 85;
            this.spcQueryCategory.SplitterWidth = 1;
            this.spcQueryCategory.TabIndex = 0;
            // 
            // lblNewCat
            // 
            this.lblNewCat.AutoSize = true;
            this.lblNewCat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.lblNewCat.Location = new System.Drawing.Point(598, 9);
            this.lblNewCat.Name = "lblNewCat";
            this.lblNewCat.Size = new System.Drawing.Size(103, 20);
            this.lblNewCat.TabIndex = 22;
            this.lblNewCat.Text = "New Category";
            this.lblNewCat.Click += new System.EventHandler(this.lblNewCat_Click);
            // 
            // cmdSQC
            // 
            this.cmdSQC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSQC.Location = new System.Drawing.Point(601, 47);
            this.cmdSQC.Name = "cmdSQC";
            this.cmdSQC.Size = new System.Drawing.Size(95, 35);
            this.cmdSQC.TabIndex = 21;
            this.cmdSQC.Text = "Save";
            this.cmdSQC.UseVisualStyleBackColor = true;
            this.cmdSQC.Click += new System.EventHandler(this.cmdSQC_Click);
            // 
            // cmdASC
            // 
            this.cmdASC.Location = new System.Drawing.Point(249, 53);
            this.cmdASC.Name = "cmdASC";
            this.cmdASC.Size = new System.Drawing.Size(24, 24);
            this.cmdASC.TabIndex = 10;
            this.cmdASC.Text = "+";
            this.cmdASC.UseVisualStyleBackColor = true;
            this.cmdASC.Click += new System.EventHandler(this.cmdASC_Click);
            // 
            // txtSbCats
            // 
            this.txtSbCats.BackColor = System.Drawing.Color.White;
            this.txtSbCats.Location = new System.Drawing.Point(91, 54);
            this.txtSbCats.Name = "txtSbCats";
            this.txtSbCats.Size = new System.Drawing.Size(155, 27);
            this.txtSbCats.TabIndex = 9;
            // 
            // lblQuerySubCategory
            // 
            this.lblQuerySubCategory.AutoSize = true;
            this.lblQuerySubCategory.Location = new System.Drawing.Point(7, 57);
            this.lblQuerySubCategory.Name = "lblQuerySubCategory";
            this.lblQuerySubCategory.Size = new System.Drawing.Size(103, 20);
            this.lblQuerySubCategory.TabIndex = 8;
            this.lblQuerySubCategory.Text = "Sub-Category:";
            // 
            // chkCatActive
            // 
            this.chkCatActive.AutoSize = true;
            this.chkCatActive.Location = new System.Drawing.Point(299, 54);
            this.chkCatActive.Name = "chkCatActive";
            this.chkCatActive.Size = new System.Drawing.Size(72, 24);
            this.chkCatActive.TabIndex = 7;
            this.chkCatActive.Text = "Active";
            this.chkCatActive.UseVisualStyleBackColor = true;
            // 
            // chkExcel
            // 
            this.chkExcel.AutoSize = true;
            this.chkExcel.Location = new System.Drawing.Point(419, 53);
            this.chkExcel.Name = "chkExcel";
            this.chkExcel.Size = new System.Drawing.Size(129, 24);
            this.chkExcel.TabIndex = 6;
            this.chkExcel.Text = "Excel Category";
            this.chkExcel.UseVisualStyleBackColor = true;
            // 
            // txtCats
            // 
            this.txtCats.BackColor = System.Drawing.Color.White;
            this.txtCats.Location = new System.Drawing.Point(91, 16);
            this.txtCats.Name = "txtCats";
            this.txtCats.ReadOnly = true;
            this.txtCats.Size = new System.Drawing.Size(155, 27);
            this.txtCats.TabIndex = 5;
            // 
            // lblQueryCategory
            // 
            this.lblQueryCategory.AutoSize = true;
            this.lblQueryCategory.Location = new System.Drawing.Point(7, 19);
            this.lblQueryCategory.Name = "lblQueryCategory";
            this.lblQueryCategory.Size = new System.Drawing.Size(72, 20);
            this.lblQueryCategory.TabIndex = 4;
            this.lblQueryCategory.Text = "Category:";
            // 
            // lstSubCats
            // 
            this.lstSubCats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.lstSubCats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSubCats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSubCats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSubCats.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lstSubCats.FormattingEnabled = true;
            this.lstSubCats.ItemHeight = 20;
            this.lstSubCats.Location = new System.Drawing.Point(0, 31);
            this.lstSubCats.Name = "lstSubCats";
            this.lstSubCats.Size = new System.Drawing.Size(980, 295);
            this.lstSubCats.TabIndex = 0;
            this.lstSubCats.SelectedIndexChanged += new System.EventHandler(this.lstSubCats_SelectedIndexChanged);
            // 
            // pnlQueryCategories
            // 
            this.pnlQueryCategories.Controls.Add(this.lblQuerySubCategories);
            this.pnlQueryCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQueryCategories.Location = new System.Drawing.Point(0, 0);
            this.pnlQueryCategories.Margin = new System.Windows.Forms.Padding(0);
            this.pnlQueryCategories.Name = "pnlQueryCategories";
            this.pnlQueryCategories.Size = new System.Drawing.Size(980, 31);
            this.pnlQueryCategories.TabIndex = 1;
            // 
            // lblQuerySubCategories
            // 
            this.lblQuerySubCategories.AutoSize = true;
            this.lblQuerySubCategories.Location = new System.Drawing.Point(3, 12);
            this.lblQuerySubCategories.Name = "lblQuerySubCategories";
            this.lblQuerySubCategories.Size = new System.Drawing.Size(150, 20);
            this.lblQuerySubCategories.TabIndex = 0;
            this.lblQuerySubCategories.Text = "Query sub-categories";
            // 
            // tpEMaps
            // 
            this.tpEMaps.BackColor = System.Drawing.Color.Transparent;
            this.tpEMaps.Controls.Add(this.spcExcelMapping);
            this.tpEMaps.Location = new System.Drawing.Point(4, 29);
            this.tpEMaps.Margin = new System.Windows.Forms.Padding(0);
            this.tpEMaps.Name = "tpEMaps";
            this.tpEMaps.Size = new System.Drawing.Size(1291, 422);
            this.tpEMaps.TabIndex = 2;
            this.tpEMaps.Text = "Excel Mapping";
            // 
            // spcExcelMapping
            // 
            this.spcExcelMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcExcelMapping.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcExcelMapping.IsSplitterFixed = true;
            this.spcExcelMapping.Location = new System.Drawing.Point(0, 0);
            this.spcExcelMapping.Margin = new System.Windows.Forms.Padding(0);
            this.spcExcelMapping.Name = "spcExcelMapping";
            // 
            // spcExcelMapping.Panel1
            // 
            this.spcExcelMapping.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.spcExcelMapping.Panel1.Controls.Add(this.panel29);
            this.spcExcelMapping.Panel1.Controls.Add(this.panel30);
            this.spcExcelMapping.Panel1.Controls.Add(this.panel28);
            this.spcExcelMapping.Panel1.Padding = new System.Windows.Forms.Padding(0, 5, 1, 5);
            // 
            // spcExcelMapping.Panel2
            // 
            this.spcExcelMapping.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.spcExcelMapping.Panel2.Controls.Add(this.pnlExcelMapping);
            this.spcExcelMapping.Panel2.Controls.Add(this.panel19);
            this.spcExcelMapping.Panel2.Controls.Add(this.panel31);
            this.spcExcelMapping.Panel2.Margin = new System.Windows.Forms.Padding(5);
            this.spcExcelMapping.Panel2.Padding = new System.Windows.Forms.Padding(1, 5, 0, 5);
            this.spcExcelMapping.Size = new System.Drawing.Size(1291, 422);
            this.spcExcelMapping.SplitterDistance = 300;
            this.spcExcelMapping.SplitterWidth = 1;
            this.spcExcelMapping.TabIndex = 24;
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.lstQueries);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel29.Location = new System.Drawing.Point(0, 180);
            this.panel29.Name = "panel29";
            this.panel29.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel29.Size = new System.Drawing.Size(299, 237);
            this.panel29.TabIndex = 2;
            // 
            // lstQueries
            // 
            this.lstQueries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.lstQueries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstQueries.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstQueries.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lstQueries.FormattingEnabled = true;
            this.lstQueries.ItemHeight = 20;
            this.lstQueries.Location = new System.Drawing.Point(0, 1);
            this.lstQueries.Name = "lstQueries";
            this.lstQueries.Size = new System.Drawing.Size(299, 236);
            this.lstQueries.TabIndex = 0;
            this.lstQueries.SelectedIndexChanged += new System.EventHandler(this.lstQueries_SelectedIndexChanged);
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.lstCategories);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel30.Location = new System.Drawing.Point(0, 40);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(299, 140);
            this.panel30.TabIndex = 3;
            // 
            // lstCategories
            // 
            this.lstCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.lstCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCategories.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lstCategories.FormattingEnabled = true;
            this.lstCategories.ItemHeight = 20;
            this.lstCategories.Location = new System.Drawing.Point(0, 0);
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(299, 140);
            this.lstCategories.TabIndex = 0;
            this.lstCategories.SelectedIndexChanged += new System.EventHandler(this.lstCategories_SelectedIndexChanged);
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.lblExcelReport);
            this.panel28.Controls.Add(this.cboReports);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel28.Location = new System.Drawing.Point(0, 5);
            this.panel28.Name = "panel28";
            this.panel28.Padding = new System.Windows.Forms.Padding(5);
            this.panel28.Size = new System.Drawing.Size(299, 35);
            this.panel28.TabIndex = 0;
            // 
            // lblExcelReport
            // 
            this.lblExcelReport.AutoSize = true;
            this.lblExcelReport.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblExcelReport.Location = new System.Drawing.Point(6, 8);
            this.lblExcelReport.Name = "lblExcelReport";
            this.lblExcelReport.Size = new System.Drawing.Size(57, 20);
            this.lblExcelReport.TabIndex = 1;
            this.lblExcelReport.Text = "Report:";
            // 
            // cboReports
            // 
            this.cboReports.Dock = System.Windows.Forms.DockStyle.Right;
            this.cboReports.FormattingEnabled = true;
            this.cboReports.Location = new System.Drawing.Point(88, 5);
            this.cboReports.Name = "cboReports";
            this.cboReports.Size = new System.Drawing.Size(206, 28);
            this.cboReports.TabIndex = 0;
            this.cboReports.SelectedIndexChanged += new System.EventHandler(this.cboReports_SelectedIndexChanged);
            // 
            // pnlExcelMapping
            // 
            this.pnlExcelMapping.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlExcelMapping.Controls.Add(this.dgXls);
            this.pnlExcelMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExcelMapping.Location = new System.Drawing.Point(1, 60);
            this.pnlExcelMapping.Name = "pnlExcelMapping";
            this.pnlExcelMapping.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlExcelMapping.Size = new System.Drawing.Size(989, 322);
            this.pnlExcelMapping.TabIndex = 1;
            // 
            // dgXls
            // 
            this.dgXls.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgXls.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgXls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgXls.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgXls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgXls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgXls.Location = new System.Drawing.Point(0, 5);
            this.dgXls.Name = "dgXls";
            this.dgXls.Size = new System.Drawing.Size(989, 312);
            this.dgXls.TabIndex = 0;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.txtEDesc);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(1, 5);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(989, 55);
            this.panel19.TabIndex = 0;
            // 
            // txtEDesc
            // 
            this.txtEDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtEDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEDesc.Location = new System.Drawing.Point(0, 0);
            this.txtEDesc.Multiline = true;
            this.txtEDesc.Name = "txtEDesc";
            this.txtEDesc.ReadOnly = true;
            this.txtEDesc.Size = new System.Drawing.Size(989, 55);
            this.txtEDesc.TabIndex = 0;
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.cmdEMap);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel31.Location = new System.Drawing.Point(1, 382);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(989, 35);
            this.panel31.TabIndex = 2;
            // 
            // cmdEMap
            // 
            this.cmdEMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdEMap.Location = new System.Drawing.Point(896, 0);
            this.cmdEMap.Name = "cmdEMap";
            this.cmdEMap.Size = new System.Drawing.Size(93, 35);
            this.cmdEMap.TabIndex = 0;
            this.cmdEMap.Text = "Save";
            this.cmdEMap.UseVisualStyleBackColor = true;
            this.cmdEMap.Click += new System.EventHandler(this.cmdEMap_Click);
            // 
            // tpUsers
            // 
            this.tpUsers.BackColor = System.Drawing.Color.Transparent;
            this.tpUsers.Controls.Add(this.spcUsers);
            this.tpUsers.Location = new System.Drawing.Point(4, 29);
            this.tpUsers.Margin = new System.Windows.Forms.Padding(0);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Size = new System.Drawing.Size(1291, 422);
            this.tpUsers.TabIndex = 3;
            this.tpUsers.Text = "Users";
            // 
            // spcUsers
            // 
            this.spcUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcUsers.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcUsers.Location = new System.Drawing.Point(0, 0);
            this.spcUsers.Name = "spcUsers";
            this.spcUsers.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcUsers.Panel1
            // 
            this.spcUsers.Panel1.Controls.Add(this.lblAddUser);
            this.spcUsers.Panel1.Controls.Add(this.txtCPWord);
            this.spcUsers.Panel1.Controls.Add(this.lblCPWord);
            this.spcUsers.Panel1.Controls.Add(this.txtLName);
            this.spcUsers.Panel1.Controls.Add(this.label42);
            this.spcUsers.Panel1.Controls.Add(this.txtPWord);
            this.spcUsers.Panel1.Controls.Add(this.lblPWord);
            this.spcUsers.Panel1.Controls.Add(this.cmdUpdateUser);
            this.spcUsers.Panel1.Controls.Add(this.txtIQName);
            this.spcUsers.Panel1.Controls.Add(this.txtFName);
            this.spcUsers.Panel1.Controls.Add(this.cboUserGroup);
            this.spcUsers.Panel1.Controls.Add(this.chkUserActive);
            this.spcUsers.Panel1.Controls.Add(this.label41);
            this.spcUsers.Panel1.Controls.Add(this.label40);
            this.spcUsers.Panel1.Controls.Add(this.label36);
            // 
            // spcUsers.Panel2
            // 
            this.spcUsers.Panel2.Controls.Add(this.dgvUsers);
            this.spcUsers.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.spcUsers.Size = new System.Drawing.Size(1291, 422);
            this.spcUsers.SplitterDistance = 25;
            this.spcUsers.TabIndex = 0;
            // 
            // lblAddUser
            // 
            this.lblAddUser.AutoSize = true;
            this.lblAddUser.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.lblAddUser.Location = new System.Drawing.Point(891, 12);
            this.lblAddUser.Name = "lblAddUser";
            this.lblAddUser.Size = new System.Drawing.Size(82, 19);
            this.lblAddUser.TabIndex = 16;
            this.lblAddUser.Text = "Add User";
            this.lblAddUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAddUser.Click += new System.EventHandler(this.lblAddUser_Click);
            // 
            // txtCPWord
            // 
            this.txtCPWord.Location = new System.Drawing.Point(600, 70);
            this.txtCPWord.Name = "txtCPWord";
            this.txtCPWord.Size = new System.Drawing.Size(125, 27);
            this.txtCPWord.TabIndex = 6;
            this.txtCPWord.UseSystemPasswordChar = true;
            this.txtCPWord.Visible = false;
            // 
            // lblCPWord
            // 
            this.lblCPWord.AutoSize = true;
            this.lblCPWord.Location = new System.Drawing.Point(481, 74);
            this.lblCPWord.Name = "lblCPWord";
            this.lblCPWord.Size = new System.Drawing.Size(132, 20);
            this.lblCPWord.TabIndex = 14;
            this.lblCPWord.Text = "Confirm password:";
            this.lblCPWord.Visible = false;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(340, 31);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(118, 27);
            this.txtLName.TabIndex = 2;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(267, 32);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(79, 20);
            this.label42.TabIndex = 12;
            this.label42.Text = "Last name:";
            // 
            // txtPWord
            // 
            this.txtPWord.Location = new System.Drawing.Point(340, 70);
            this.txtPWord.Name = "txtPWord";
            this.txtPWord.Size = new System.Drawing.Size(118, 27);
            this.txtPWord.TabIndex = 5;
            this.txtPWord.UseSystemPasswordChar = true;
            this.txtPWord.Visible = false;
            // 
            // lblPWord
            // 
            this.lblPWord.AutoSize = true;
            this.lblPWord.Location = new System.Drawing.Point(267, 73);
            this.lblPWord.Name = "lblPWord";
            this.lblPWord.Size = new System.Drawing.Size(73, 20);
            this.lblPWord.TabIndex = 10;
            this.lblPWord.Text = "Password:";
            this.lblPWord.Visible = false;
            // 
            // cmdUpdateUser
            // 
            this.cmdUpdateUser.Location = new System.Drawing.Point(877, 66);
            this.cmdUpdateUser.Name = "cmdUpdateUser";
            this.cmdUpdateUser.Size = new System.Drawing.Size(97, 31);
            this.cmdUpdateUser.TabIndex = 9;
            this.cmdUpdateUser.TabStop = false;
            this.cmdUpdateUser.Text = "Save";
            this.cmdUpdateUser.UseVisualStyleBackColor = true;
            this.cmdUpdateUser.Click += new System.EventHandler(this.cmdUpdateUser_Click);
            // 
            // txtIQName
            // 
            this.txtIQName.BackColor = System.Drawing.Color.White;
            this.txtIQName.Location = new System.Drawing.Point(600, 30);
            this.txtIQName.Name = "txtIQName";
            this.txtIQName.ReadOnly = true;
            this.txtIQName.Size = new System.Drawing.Size(125, 27);
            this.txtIQName.TabIndex = 3;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(97, 31);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(118, 27);
            this.txtFName.TabIndex = 1;
            // 
            // cboUserGroup
            // 
            this.cboUserGroup.FormattingEnabled = true;
            this.cboUserGroup.Location = new System.Drawing.Point(97, 71);
            this.cboUserGroup.Name = "cboUserGroup";
            this.cboUserGroup.Size = new System.Drawing.Size(118, 28);
            this.cboUserGroup.TabIndex = 4;
            // 
            // chkUserActive
            // 
            this.chkUserActive.AutoSize = true;
            this.chkUserActive.Location = new System.Drawing.Point(757, 73);
            this.chkUserActive.Name = "chkUserActive";
            this.chkUserActive.Size = new System.Drawing.Size(116, 24);
            this.chkUserActive.TabIndex = 7;
            this.chkUserActive.Text = "Activate user";
            this.chkUserActive.UseVisualStyleBackColor = true;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(24, 33);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(80, 20);
            this.label41.TabIndex = 2;
            this.label41.Text = "First name:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(20, 74);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(85, 20);
            this.label40.TabIndex = 1;
            this.label40.Text = "User group:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(523, 33);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(78, 20);
            this.label36.TabIndex = 0;
            this.label36.Text = "Username:";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvUsers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(5, 5);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.Size = new System.Drawing.Size(1281, 383);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);
            // 
            // tpCReports
            // 
            this.tpCReports.BackColor = System.Drawing.Color.Transparent;
            this.tpCReports.Controls.Add(this.cmdCReportTemplate);
            this.tpCReports.Controls.Add(this.txtCReportTemplate);
            this.tpCReports.Controls.Add(this.lblExcelTemplate);
            this.tpCReports.Controls.Add(this.cmdCReportNew);
            this.tpCReports.Controls.Add(this.lblReportID);
            this.tpCReports.Controls.Add(this.lblCReportId);
            this.tpCReports.Controls.Add(this.chkDeleteCReport);
            this.tpCReports.Controls.Add(this.lstCReportsFilter);
            this.tpCReports.Controls.Add(this.cmdCReportSave);
            this.tpCReports.Controls.Add(this.cboCReportFilterType);
            this.tpCReports.Controls.Add(this.lblFilterType);
            this.tpCReports.Controls.Add(this.txtCReportDesc);
            this.tpCReports.Controls.Add(this.lblReportDescription);
            this.tpCReports.Controls.Add(this.dgvCReports);
            this.tpCReports.Controls.Add(this.txtCReportFilterName);
            this.tpCReports.Controls.Add(this.cmdAddRemoveFilter);
            this.tpCReports.Controls.Add(this.lblFilterName);
            this.tpCReports.Controls.Add(this.cboCReportCategory);
            this.tpCReports.Controls.Add(this.lblCustomCategory);
            this.tpCReports.Controls.Add(this.txtCReportName);
            this.tpCReports.Controls.Add(this.lblReportName);
            this.tpCReports.Location = new System.Drawing.Point(4, 29);
            this.tpCReports.Margin = new System.Windows.Forms.Padding(0);
            this.tpCReports.Name = "tpCReports";
            this.tpCReports.Size = new System.Drawing.Size(1291, 422);
            this.tpCReports.TabIndex = 12;
            this.tpCReports.Text = "Custom Reports";
            // 
            // cmdCReportTemplate
            // 
            this.cmdCReportTemplate.Location = new System.Drawing.Point(447, 42);
            this.cmdCReportTemplate.Name = "cmdCReportTemplate";
            this.cmdCReportTemplate.Size = new System.Drawing.Size(49, 23);
            this.cmdCReportTemplate.TabIndex = 21;
            this.cmdCReportTemplate.Text = "...";
            this.cmdCReportTemplate.UseVisualStyleBackColor = true;
            this.cmdCReportTemplate.Click += new System.EventHandler(this.cmdCReportTemplate_Click);
            // 
            // txtCReportTemplate
            // 
            this.txtCReportTemplate.Location = new System.Drawing.Point(133, 43);
            this.txtCReportTemplate.Name = "txtCReportTemplate";
            this.txtCReportTemplate.ReadOnly = true;
            this.txtCReportTemplate.Size = new System.Drawing.Size(305, 27);
            this.txtCReportTemplate.TabIndex = 20;
            // 
            // lblExcelTemplate
            // 
            this.lblExcelTemplate.Location = new System.Drawing.Point(43, 39);
            this.lblExcelTemplate.Name = "lblExcelTemplate";
            this.lblExcelTemplate.Size = new System.Drawing.Size(84, 34);
            this.lblExcelTemplate.TabIndex = 19;
            this.lblExcelTemplate.Text = "Excel Report Template";
            // 
            // cmdCReportNew
            // 
            this.cmdCReportNew.Location = new System.Drawing.Point(204, 4);
            this.cmdCReportNew.Name = "cmdCReportNew";
            this.cmdCReportNew.Size = new System.Drawing.Size(51, 29);
            this.cmdCReportNew.TabIndex = 18;
            this.cmdCReportNew.Text = "New";
            this.cmdCReportNew.UseVisualStyleBackColor = true;
            this.cmdCReportNew.Click += new System.EventHandler(this.cmdCReportNew_Click);
            // 
            // lblReportID
            // 
            this.lblReportID.AutoSize = true;
            this.lblReportID.Location = new System.Drawing.Point(31, 11);
            this.lblReportID.Name = "lblReportID";
            this.lblReportID.Size = new System.Drawing.Size(73, 20);
            this.lblReportID.TabIndex = 17;
            this.lblReportID.Text = "Report ID";
            // 
            // lblCReportId
            // 
            this.lblCReportId.AutoSize = true;
            this.lblCReportId.Location = new System.Drawing.Point(121, 9);
            this.lblCReportId.Name = "lblCReportId";
            this.lblCReportId.Size = new System.Drawing.Size(17, 20);
            this.lblCReportId.TabIndex = 16;
            this.lblCReportId.Text = "0";
            // 
            // chkDeleteCReport
            // 
            this.chkDeleteCReport.AutoSize = true;
            this.chkDeleteCReport.Location = new System.Drawing.Point(549, 173);
            this.chkDeleteCReport.Name = "chkDeleteCReport";
            this.chkDeleteCReport.Size = new System.Drawing.Size(148, 24);
            this.chkDeleteCReport.TabIndex = 15;
            this.chkDeleteCReport.Text = "Inactivate  Report";
            this.chkDeleteCReport.UseVisualStyleBackColor = true;
            // 
            // lstCReportsFilter
            // 
            this.lstCReportsFilter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader19,
            this.columnHeader20});
            this.lstCReportsFilter.FullRowSelect = true;
            this.lstCReportsFilter.GridLines = true;
            this.lstCReportsFilter.Location = new System.Drawing.Point(133, 139);
            this.lstCReportsFilter.MultiSelect = false;
            this.lstCReportsFilter.Name = "lstCReportsFilter";
            this.lstCReportsFilter.Size = new System.Drawing.Size(305, 97);
            this.lstCReportsFilter.TabIndex = 14;
            this.lstCReportsFilter.UseCompatibleStateImageBehavior = false;
            this.lstCReportsFilter.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Filter Name";
            this.columnHeader19.Width = 143;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Filter Type";
            this.columnHeader20.Width = 117;
            // 
            // cmdCReportSave
            // 
            this.cmdCReportSave.Location = new System.Drawing.Point(818, 203);
            this.cmdCReportSave.Name = "cmdCReportSave";
            this.cmdCReportSave.Size = new System.Drawing.Size(75, 31);
            this.cmdCReportSave.TabIndex = 13;
            this.cmdCReportSave.Text = "Save";
            this.cmdCReportSave.UseVisualStyleBackColor = true;
            this.cmdCReportSave.Click += new System.EventHandler(this.cmdCReportSave_Click);
            // 
            // cboCReportFilterType
            // 
            this.cboCReportFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCReportFilterType.FormattingEnabled = true;
            this.cboCReportFilterType.Items.AddRange(new object[] {
            "Date",
            "Text",
            "Number"});
            this.cboCReportFilterType.Location = new System.Drawing.Point(326, 106);
            this.cboCReportFilterType.Name = "cboCReportFilterType";
            this.cboCReportFilterType.Size = new System.Drawing.Size(112, 28);
            this.cboCReportFilterType.TabIndex = 12;
            // 
            // lblFilterType
            // 
            this.lblFilterType.AutoSize = true;
            this.lblFilterType.Location = new System.Drawing.Point(256, 108);
            this.lblFilterType.Name = "lblFilterType";
            this.lblFilterType.Size = new System.Drawing.Size(77, 20);
            this.lblFilterType.TabIndex = 11;
            this.lblFilterType.Text = "Filter Type";
            // 
            // txtCReportDesc
            // 
            this.txtCReportDesc.Location = new System.Drawing.Point(661, 116);
            this.txtCReportDesc.Multiline = true;
            this.txtCReportDesc.Name = "txtCReportDesc";
            this.txtCReportDesc.Size = new System.Drawing.Size(232, 46);
            this.txtCReportDesc.TabIndex = 10;
            // 
            // lblReportDescription
            // 
            this.lblReportDescription.AutoSize = true;
            this.lblReportDescription.Location = new System.Drawing.Point(546, 116);
            this.lblReportDescription.Name = "lblReportDescription";
            this.lblReportDescription.Size = new System.Drawing.Size(134, 20);
            this.lblReportDescription.TabIndex = 9;
            this.lblReportDescription.Text = "Report Description";
            // 
            // dgvCReports
            // 
            this.dgvCReports.AllowUserToAddRows = false;
            this.dgvCReports.AllowUserToDeleteRows = false;
            this.dgvCReports.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCReports.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCReports.Location = new System.Drawing.Point(13, 242);
            this.dgvCReports.Name = "dgvCReports";
            this.dgvCReports.ReadOnly = true;
            this.dgvCReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCReports.Size = new System.Drawing.Size(750, 181);
            this.dgvCReports.TabIndex = 8;
            this.dgvCReports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCReports_CellContentClick);
            this.dgvCReports.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCReports_RowEnter);
            // 
            // txtCReportFilterName
            // 
            this.txtCReportFilterName.Location = new System.Drawing.Point(133, 108);
            this.txtCReportFilterName.Name = "txtCReportFilterName";
            this.txtCReportFilterName.Size = new System.Drawing.Size(104, 27);
            this.txtCReportFilterName.TabIndex = 7;
            // 
            // cmdAddRemoveFilter
            // 
            this.cmdAddRemoveFilter.Location = new System.Drawing.Point(447, 106);
            this.cmdAddRemoveFilter.Name = "cmdAddRemoveFilter";
            this.cmdAddRemoveFilter.Size = new System.Drawing.Size(54, 23);
            this.cmdAddRemoveFilter.TabIndex = 6;
            this.cmdAddRemoveFilter.Text = "+";
            this.cmdAddRemoveFilter.UseVisualStyleBackColor = true;
            this.cmdAddRemoveFilter.Click += new System.EventHandler(this.cmdAddRemoveFilter_Click);
            // 
            // lblFilterName
            // 
            this.lblFilterName.AutoSize = true;
            this.lblFilterName.Location = new System.Drawing.Point(40, 108);
            this.lblFilterName.Name = "lblFilterName";
            this.lblFilterName.Size = new System.Drawing.Size(86, 20);
            this.lblFilterName.TabIndex = 5;
            this.lblFilterName.Text = "Filter Name";
            // 
            // cboCReportCategory
            // 
            this.cboCReportCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCReportCategory.FormattingEnabled = true;
            this.cboCReportCategory.Location = new System.Drawing.Point(663, 76);
            this.cboCReportCategory.Name = "cboCReportCategory";
            this.cboCReportCategory.Size = new System.Drawing.Size(230, 28);
            this.cboCReportCategory.TabIndex = 3;
            this.cboCReportCategory.SelectedIndexChanged += new System.EventHandler(this.cboCReportCategory_SelectedIndexChanged);
            // 
            // lblCustomCategory
            // 
            this.lblCustomCategory.AutoSize = true;
            this.lblCustomCategory.Location = new System.Drawing.Point(546, 76);
            this.lblCustomCategory.Name = "lblCustomCategory";
            this.lblCustomCategory.Size = new System.Drawing.Size(69, 20);
            this.lblCustomCategory.TabIndex = 2;
            this.lblCustomCategory.Text = "Category";
            // 
            // txtCReportName
            // 
            this.txtCReportName.Location = new System.Drawing.Point(133, 78);
            this.txtCReportName.Name = "txtCReportName";
            this.txtCReportName.Size = new System.Drawing.Size(368, 27);
            this.txtCReportName.TabIndex = 1;
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(40, 78);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(98, 20);
            this.lblReportName.TabIndex = 0;
            this.lblReportName.Text = "Report Name";
            // 
            // tpDataConnection
            // 
            this.tpDataConnection.Controls.Add(this.pnlDataConnections);
            this.tpDataConnection.Location = new System.Drawing.Point(4, 29);
            this.tpDataConnection.Name = "tpDataConnection";
            this.tpDataConnection.Size = new System.Drawing.Size(1291, 422);
            this.tpDataConnection.TabIndex = 13;
            this.tpDataConnection.Text = "Data Connection";
            this.tpDataConnection.UseVisualStyleBackColor = true;
            // 
            // pnlDataConnections
            // 
            this.pnlDataConnections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pnlDataConnections.Controls.Add(this.prbLoad);
            this.pnlDataConnections.Controls.Add(this.cmdPMMS);
            this.pnlDataConnections.Controls.Add(this.Username);
            this.pnlDataConnections.Controls.Add(this.txtUID);
            this.pnlDataConnections.Controls.Add(this.Database);
            this.pnlDataConnections.Controls.Add(this.cboDBase);
            this.pnlDataConnections.Controls.Add(this.cmdDBLoad);
            this.pnlDataConnections.Controls.Add(this.Password);
            this.pnlDataConnections.Controls.Add(this.txtPWD);
            this.pnlDataConnections.Controls.Add(this.lblDatabaseType);
            this.pnlDataConnections.Controls.Add(this.cboServerType);
            this.pnlDataConnections.Location = new System.Drawing.Point(10, 57);
            this.pnlDataConnections.Name = "pnlDataConnections";
            this.pnlDataConnections.Size = new System.Drawing.Size(456, 259);
            this.pnlDataConnections.TabIndex = 24;
            // 
            // prbLoad
            // 
            this.prbLoad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prbLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.prbLoad.Location = new System.Drawing.Point(0, 244);
            this.prbLoad.Name = "prbLoad";
            this.prbLoad.Size = new System.Drawing.Size(456, 15);
            this.prbLoad.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prbLoad.TabIndex = 68;
            this.prbLoad.Visible = false;
            // 
            // cmdPMMS
            // 
            this.cmdPMMS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPMMS.Location = new System.Drawing.Point(157, 202);
            this.cmdPMMS.Name = "cmdPMMS";
            this.cmdPMMS.Size = new System.Drawing.Size(259, 38);
            this.cmdPMMS.TabIndex = 67;
            this.cmdPMMS.TabStop = false;
            this.cmdPMMS.Text = "Save";
            this.cmdPMMS.UseVisualStyleBackColor = true;
            this.cmdPMMS.Click += new System.EventHandler(this.cmdPMMS_Click);
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Username.Location = new System.Drawing.Point(21, 133);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(78, 20);
            this.Username.TabIndex = 61;
            this.Username.Text = "Username:";
            // 
            // txtUID
            // 
            this.txtUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUID.Location = new System.Drawing.Point(157, 126);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(259, 24);
            this.txtUID.TabIndex = 60;
            // 
            // Database
            // 
            this.Database.AutoSize = true;
            this.Database.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Database.Location = new System.Drawing.Point(23, 85);
            this.Database.Name = "Database";
            this.Database.Size = new System.Drawing.Size(75, 20);
            this.Database.TabIndex = 65;
            this.Database.Text = "Database:";
            // 
            // cboDBase
            // 
            this.cboDBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDBase.FormattingEnabled = true;
            this.cboDBase.Location = new System.Drawing.Point(154, 77);
            this.cboDBase.Name = "cboDBase";
            this.cboDBase.Size = new System.Drawing.Size(259, 26);
            this.cboDBase.TabIndex = 64;
            // 
            // cmdDBLoad
            // 
            this.cmdDBLoad.Location = new System.Drawing.Point(424, 77);
            this.cmdDBLoad.Name = "cmdDBLoad";
            this.cmdDBLoad.Size = new System.Drawing.Size(25, 24);
            this.cmdDBLoad.TabIndex = 66;
            this.cmdDBLoad.TabStop = false;
            this.cmdDBLoad.Text = "...";
            this.cmdDBLoad.UseVisualStyleBackColor = true;
            this.cmdDBLoad.Click += new System.EventHandler(this.cmdDBLoad_Click);
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Password.Location = new System.Drawing.Point(24, 181);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(73, 20);
            this.Password.TabIndex = 63;
            this.Password.Text = "Password:";
            // 
            // txtPWD
            // 
            this.txtPWD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPWD.Location = new System.Drawing.Point(157, 175);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.Size = new System.Drawing.Size(259, 24);
            this.txtPWD.TabIndex = 62;
            this.txtPWD.UseSystemPasswordChar = true;
            // 
            // lblDatabaseType
            // 
            this.lblDatabaseType.AutoSize = true;
            this.lblDatabaseType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDatabaseType.Location = new System.Drawing.Point(24, 38);
            this.lblDatabaseType.Name = "lblDatabaseType";
            this.lblDatabaseType.Size = new System.Drawing.Size(110, 20);
            this.lblDatabaseType.TabIndex = 59;
            this.lblDatabaseType.Text = "Database Type:";
            // 
            // cboServerType
            // 
            this.cboServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServerType.FormattingEnabled = true;
            this.cboServerType.Items.AddRange(new object[] {
            "Microsoft Access"});
            this.cboServerType.Location = new System.Drawing.Point(157, 27);
            this.cboServerType.Name = "cboServerType";
            this.cboServerType.Size = new System.Drawing.Size(259, 26);
            this.cboServerType.TabIndex = 58;
            // 
            // ofdUtility
            // 
            this.ofdUtility.FileName = "IQTools.Bak";
            this.ofdUtility.Filter = "\"SQL Backup|*.Bak|Access Files|*.mdb|All Files|*.*\"";
            this.ofdUtility.InitialDirectory = "\\\\Database";
            // 
            // tpSMS
            // 
            this.tpSMS.BackColor = System.Drawing.Color.Transparent;
            this.tpSMS.Location = new System.Drawing.Point(4, 29);
            this.tpSMS.Margin = new System.Windows.Forms.Padding(0);
            this.tpSMS.Name = "tpSMS";
            this.tpSMS.Size = new System.Drawing.Size(1299, 516);
            this.tpSMS.TabIndex = 5;
            this.tpSMS.Text = "Messaging";
            this.tpSMS.UseVisualStyleBackColor = true;
            // 
            // tpQueries
            // 
            this.tpQueries.Location = new System.Drawing.Point(4, 29);
            this.tpQueries.Margin = new System.Windows.Forms.Padding(0);
            this.tpQueries.Name = "tpQueries";
            this.tpQueries.Size = new System.Drawing.Size(1299, 516);
            this.tpQueries.TabIndex = 4;
            this.tpQueries.Text = "Queries";
            this.tpQueries.UseVisualStyleBackColor = true;
            // 
            // tpReports
            // 
            this.tpReports.BackColor = System.Drawing.Color.Transparent;
            this.tpReports.Controls.Add(this.spcHome);
            this.tpReports.Location = new System.Drawing.Point(4, 29);
            this.tpReports.Margin = new System.Windows.Forms.Padding(0);
            this.tpReports.Name = "tpReports";
            this.tpReports.Size = new System.Drawing.Size(1299, 516);
            this.tpReports.TabIndex = 2;
            this.tpReports.Text = "Home";
            // 
            // spcHome
            // 
            this.spcHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcHome.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcHome.IsSplitterFixed = true;
            this.spcHome.Location = new System.Drawing.Point(0, 0);
            this.spcHome.Margin = new System.Windows.Forms.Padding(0);
            this.spcHome.Name = "spcHome";
            this.spcHome.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcHome.Panel1
            // 
            this.spcHome.Panel1.BackColor = System.Drawing.Color.White;
            this.spcHome.Panel1.Controls.Add(this.picHome);
            // 
            // spcHome.Panel2
            // 
            this.spcHome.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spcHome.Panel2.Controls.Add(this.tcReports);
            this.spcHome.Size = new System.Drawing.Size(1299, 516);
            this.spcHome.SplitterDistance = 60;
            this.spcHome.SplitterWidth = 1;
            this.spcHome.TabIndex = 7;
            // 
            // picHome
            // 
            this.picHome.BackColor = System.Drawing.Color.White;
            this.picHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.picHome.Image = global::IQTools.Properties.Resources.iqtools;
            this.picHome.InitialImage = null;
            this.picHome.Location = new System.Drawing.Point(0, 0);
            this.picHome.Margin = new System.Windows.Forms.Padding(0);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(228, 60);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHome.TabIndex = 1;
            this.picHome.TabStop = false;
            // 
            // tcReports
            // 
            this.tcReports.Controls.Add(this.tpARTAdh);
            this.tcReports.Controls.Add(this.tpDonor);
            this.tcReports.Controls.Add(this.tpClinical);
            this.tcReports.Controls.Add(this.tpComparisons);
            this.tcReports.Controls.Add(this.tpVals);
            this.tcReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcReports.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcReports.Location = new System.Drawing.Point(0, 0);
            this.tcReports.Margin = new System.Windows.Forms.Padding(0);
            this.tcReports.Name = "tcReports";
            this.tcReports.Padding = new System.Drawing.Point(0, 0);
            this.tcReports.SelectedIndex = 0;
            this.tcReports.Size = new System.Drawing.Size(1299, 455);
            this.tcReports.TabIndex = 6;
            this.tcReports.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcReports_Selected);
            // 
            // tpARTAdh
            // 
            this.tpARTAdh.BackColor = System.Drawing.Color.White;
            this.tpARTAdh.Controls.Add(this.spcHomeTab1);
            this.tpARTAdh.Location = new System.Drawing.Point(4, 29);
            this.tpARTAdh.Margin = new System.Windows.Forms.Padding(0);
            this.tpARTAdh.Name = "tpARTAdh";
            this.tpARTAdh.Size = new System.Drawing.Size(1291, 422);
            this.tpARTAdh.TabIndex = 4;
            this.tpARTAdh.Text = "Adherence";
            this.tpARTAdh.UseVisualStyleBackColor = true;
            // 
            // spcHomeTab1
            // 
            this.spcHomeTab1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spcHomeTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcHomeTab1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcHomeTab1.IsSplitterFixed = true;
            this.spcHomeTab1.Location = new System.Drawing.Point(0, 0);
            this.spcHomeTab1.Margin = new System.Windows.Forms.Padding(0);
            this.spcHomeTab1.Name = "spcHomeTab1";
            // 
            // spcHomeTab1.Panel1
            // 
            this.spcHomeTab1.Panel1.AutoScroll = true;
            this.spcHomeTab1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spcHomeTab1.Panel1.Controls.Add(this.pnlHome);
            // 
            // spcHomeTab1.Panel2
            // 
            this.spcHomeTab1.Panel2.Controls.Add(this.dgvAdherence);
            this.spcHomeTab1.Size = new System.Drawing.Size(1291, 422);
            this.spcHomeTab1.SplitterDistance = 285;
            this.spcHomeTab1.SplitterWidth = 1;
            this.spcHomeTab1.TabIndex = 4;
            // 
            // pnlHome
            // 
            this.pnlHome.AutoScroll = true;
            this.pnlHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pnlHome.Controls.Add(this.gbART);
            this.pnlHome.Controls.Add(this.cmdART);
            this.pnlHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHome.Location = new System.Drawing.Point(0, 0);
            this.pnlHome.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Padding = new System.Windows.Forms.Padding(5);
            this.pnlHome.Size = new System.Drawing.Size(285, 422);
            this.pnlHome.TabIndex = 0;
            // 
            // gbART
            // 
            this.gbART.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.gbART.Controls.Add(this.lblLowVL);
            this.gbART.Controls.Add(this.txtLowVL);
            this.gbART.Controls.Add(this.optVLDetect);
            this.gbART.Controls.Add(this.optVL);
            this.gbART.Controls.Add(this.TxtMA);
            this.gbART.Controls.Add(this.lblMA);
            this.gbART.Controls.Add(this.OptMA);
            this.gbART.Controls.Add(this.optART);
            this.gbART.Controls.Add(this.txtHCD4);
            this.gbART.Controls.Add(this.txtLCD4);
            this.gbART.Controls.Add(this.label85);
            this.gbART.Controls.Add(this.label67);
            this.gbART.Controls.Add(this.optNoARTNoCD4);
            this.gbART.Controls.Add(this.optNoARTCD4XY);
            this.gbART.Controls.Add(this.dtpAllApp);
            this.gbART.Controls.Add(this.optAllApp);
            this.gbART.Controls.Add(this.label84);
            this.gbART.Controls.Add(this.dtpMAP);
            this.gbART.Controls.Add(this.optMAP);
            this.gbART.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbART.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbART.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbART.Location = new System.Drawing.Point(5, 36);
            this.gbART.Margin = new System.Windows.Forms.Padding(0);
            this.gbART.Name = "gbART";
            this.gbART.Padding = new System.Windows.Forms.Padding(0);
            this.gbART.Size = new System.Drawing.Size(254, 490);
            this.gbART.TabIndex = 0;
            this.gbART.TabStop = false;
            this.gbART.Enter += new System.EventHandler(this.gbART_Enter);
            // 
            // lblLowVL
            // 
            this.lblLowVL.AutoSize = true;
            this.lblLowVL.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowVL.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLowVL.Location = new System.Drawing.Point(69, 401);
            this.lblLowVL.Name = "lblLowVL";
            this.lblLowVL.Size = new System.Drawing.Size(55, 19);
            this.lblLowVL.TabIndex = 23;
            this.lblLowVL.Text = "Low VL:";
            // 
            // txtLowVL
            // 
            this.txtLowVL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLowVL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowVL.Location = new System.Drawing.Point(119, 398);
            this.txtLowVL.Name = "txtLowVL";
            this.txtLowVL.Size = new System.Drawing.Size(79, 27);
            this.txtLowVL.TabIndex = 22;
            this.txtLowVL.Text = "1000";
            // 
            // optVLDetect
            // 
            this.optVLDetect.AutoSize = true;
            this.optVLDetect.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optVLDetect.Location = new System.Drawing.Point(7, 375);
            this.optVLDetect.Name = "optVLDetect";
            this.optVLDetect.Size = new System.Drawing.Size(201, 23);
            this.optVLDetect.TabIndex = 21;
            this.optVLDetect.TabStop = true;
            this.optVLDetect.Text = "Detectable Viral Load above";
            this.optVLDetect.UseVisualStyleBackColor = true;
            // 
            // optVL
            // 
            this.optVL.AutoSize = true;
            this.optVL.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optVL.Location = new System.Drawing.Point(7, 341);
            this.optVL.Name = "optVL";
            this.optVL.Size = new System.Drawing.Size(183, 23);
            this.optVL.TabIndex = 20;
            this.optVL.TabStop = true;
            this.optVL.Text = "Due For a Viral Load Test";
            this.optVL.UseVisualStyleBackColor = true;
            // 
            // TxtMA
            // 
            this.TxtMA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMA.Location = new System.Drawing.Point(151, 114);
            this.TxtMA.Name = "TxtMA";
            this.TxtMA.Size = new System.Drawing.Size(47, 27);
            this.TxtMA.TabIndex = 19;
            // 
            // lblMA
            // 
            this.lblMA.AutoSize = true;
            this.lblMA.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMA.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblMA.Location = new System.Drawing.Point(77, 118);
            this.lblMA.Name = "lblMA";
            this.lblMA.Size = new System.Drawing.Size(71, 19);
            this.lblMA.TabIndex = 18;
            this.lblMA.Text = "# of Days:";
            this.lblMA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OptMA
            // 
            this.OptMA.AutoSize = true;
            this.OptMA.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptMA.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OptMA.Location = new System.Drawing.Point(6, 137);
            this.OptMA.Name = "OptMA";
            this.OptMA.Size = new System.Drawing.Size(199, 23);
            this.OptMA.TabIndex = 17;
            this.OptMA.Text = "Missed Appointments (ALL)";
            this.OptMA.UseVisualStyleBackColor = true;
            this.OptMA.CheckedChanged += new System.EventHandler(this.OptMA_CheckedChanged);
            // 
            // optART
            // 
            this.optART.AutoSize = true;
            this.optART.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optART.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optART.Location = new System.Drawing.Point(6, 22);
            this.optART.Name = "optART";
            this.optART.Size = new System.Drawing.Size(102, 23);
            this.optART.TabIndex = 16;
            this.optART.Text = "All Patients ";
            this.optART.UseVisualStyleBackColor = true;
            // 
            // txtHCD4
            // 
            this.txtHCD4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHCD4.Location = new System.Drawing.Point(119, 307);
            this.txtHCD4.Name = "txtHCD4";
            this.txtHCD4.Size = new System.Drawing.Size(79, 27);
            this.txtHCD4.TabIndex = 13;
            this.txtHCD4.Text = "500";
            // 
            // txtLCD4
            // 
            this.txtLCD4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLCD4.Location = new System.Drawing.Point(119, 280);
            this.txtLCD4.Name = "txtLCD4";
            this.txtLCD4.Size = new System.Drawing.Size(79, 27);
            this.txtLCD4.TabIndex = 12;
            this.txtLCD4.Text = "0";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label85.Location = new System.Drawing.Point(60, 311);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(73, 19);
            this.label85.TabIndex = 11;
            this.label85.Text = "High CD4:";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label67.Location = new System.Drawing.Point(60, 284);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(67, 19);
            this.label67.TabIndex = 10;
            this.label67.Text = "Low CD4:";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // optNoARTNoCD4
            // 
            this.optNoARTNoCD4.AutoSize = true;
            this.optNoARTNoCD4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optNoARTNoCD4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optNoARTNoCD4.Location = new System.Drawing.Point(6, 225);
            this.optNoARTNoCD4.Name = "optNoARTNoCD4";
            this.optNoARTNoCD4.Size = new System.Drawing.Size(213, 23);
            this.optNoARTNoCD4.TabIndex = 9;
            this.optNoARTNoCD4.Text = "Not on ART and no CD4 done";
            this.optNoARTNoCD4.UseVisualStyleBackColor = true;
            // 
            // optNoARTCD4XY
            // 
            this.optNoARTCD4XY.AutoSize = true;
            this.optNoARTCD4XY.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optNoARTCD4XY.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optNoARTCD4XY.Location = new System.Drawing.Point(7, 257);
            this.optNoARTCD4XY.Name = "optNoARTCD4XY";
            this.optNoARTCD4XY.Size = new System.Drawing.Size(214, 23);
            this.optNoARTCD4XY.TabIndex = 8;
            this.optNoARTCD4XY.Text = "Not on ART and CD4 between";
            this.optNoARTCD4XY.UseVisualStyleBackColor = true;
            // 
            // dtpAllApp
            // 
            this.dtpAllApp.CustomFormat = "yyyy-MM-dd";
            this.dtpAllApp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAllApp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAllApp.Location = new System.Drawing.Point(69, 196);
            this.dtpAllApp.Name = "dtpAllApp";
            this.dtpAllApp.ShowCheckBox = true;
            this.dtpAllApp.Size = new System.Drawing.Size(129, 27);
            this.dtpAllApp.TabIndex = 6;
            // 
            // optAllApp
            // 
            this.optAllApp.AutoSize = true;
            this.optAllApp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optAllApp.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optAllApp.Location = new System.Drawing.Point(6, 170);
            this.optAllApp.Name = "optAllApp";
            this.optAllApp.Size = new System.Drawing.Size(183, 23);
            this.optAllApp.TabIndex = 5;
            this.optAllApp.Text = "View all appointment for:";
            this.optAllApp.UseVisualStyleBackColor = true;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label84.Location = new System.Drawing.Point(27, 88);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(44, 19);
            this.label84.TabIndex = 3;
            this.label84.Text = "As at:";
            // 
            // dtpMAP
            // 
            this.dtpMAP.CustomFormat = "yyyy-MM-dd";
            this.dtpMAP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMAP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMAP.Location = new System.Drawing.Point(69, 86);
            this.dtpMAP.Name = "dtpMAP";
            this.dtpMAP.ShowCheckBox = true;
            this.dtpMAP.Size = new System.Drawing.Size(129, 27);
            this.dtpMAP.TabIndex = 2;
            // 
            // optMAP
            // 
            this.optMAP.AutoSize = true;
            this.optMAP.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optMAP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optMAP.Location = new System.Drawing.Point(6, 58);
            this.optMAP.Name = "optMAP";
            this.optMAP.Size = new System.Drawing.Size(200, 23);
            this.optMAP.TabIndex = 1;
            this.optMAP.Text = "Missed ARV Pickup Analysis";
            this.optMAP.UseVisualStyleBackColor = true;
            this.optMAP.CheckedChanged += new System.EventHandler(this.optMAP_CheckedChanged);
            // 
            // cmdART
            // 
            this.cmdART.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdART.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdART.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.cmdART.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.cmdART.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdART.Location = new System.Drawing.Point(5, 5);
            this.cmdART.Name = "cmdART";
            this.cmdART.Size = new System.Drawing.Size(254, 31);
            this.cmdART.TabIndex = 0;
            this.cmdART.Text = "View the report";
            this.cmdART.UseVisualStyleBackColor = true;
            this.cmdART.Click += new System.EventHandler(this.cmdART_Click);
            // 
            // dgvAdherence
            // 
            this.dgvAdherence.AllowUserToAddRows = false;
            this.dgvAdherence.AllowUserToDeleteRows = false;
            this.dgvAdherence.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAdherence.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAdherence.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAdherence.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAdherence.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvAdherence.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAdherence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdherence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdherence.Location = new System.Drawing.Point(0, 0);
            this.dgvAdherence.Margin = new System.Windows.Forms.Padding(0);
            this.dgvAdherence.Name = "dgvAdherence";
            this.dgvAdherence.ReadOnly = true;
            this.dgvAdherence.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAdherence.RowHeadersWidth = 17;
            this.dgvAdherence.Size = new System.Drawing.Size(1005, 422);
            this.dgvAdherence.TabIndex = 4;
            this.dgvAdherence.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdherence_CellContentClick);
            this.dgvAdherence.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAdherence_DataError);
            // 
            // tpDonor
            // 
            this.tpDonor.BackColor = System.Drawing.Color.Transparent;
            this.tpDonor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tpDonor.Controls.Add(this.spcHomeTab2);
            this.tpDonor.Location = new System.Drawing.Point(4, 29);
            this.tpDonor.Margin = new System.Windows.Forms.Padding(0);
            this.tpDonor.Name = "tpDonor";
            this.tpDonor.Size = new System.Drawing.Size(1291, 422);
            this.tpDonor.TabIndex = 1;
            this.tpDonor.Text = "Reports";
            // 
            // spcHomeTab2
            // 
            this.spcHomeTab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcHomeTab2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcHomeTab2.IsSplitterFixed = true;
            this.spcHomeTab2.Location = new System.Drawing.Point(0, 0);
            this.spcHomeTab2.Margin = new System.Windows.Forms.Padding(0);
            this.spcHomeTab2.Name = "spcHomeTab2";
            // 
            // spcHomeTab2.Panel1
            // 
            this.spcHomeTab2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.spcHomeTab2.Panel1.Controls.Add(this.cboPeriod);
            this.spcHomeTab2.Panel1.Controls.Add(this.lstPeriods);
            this.spcHomeTab2.Panel1.Controls.Add(this.txtYear);
            this.spcHomeTab2.Panel1.Controls.Add(this.pnlCustomDates);
            // 
            // spcHomeTab2.Panel2
            // 
            this.spcHomeTab2.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spcHomeTab2.Panel2.Controls.Add(this.panel22);
            this.spcHomeTab2.Size = new System.Drawing.Size(1291, 422);
            this.spcHomeTab2.SplitterDistance = 285;
            this.spcHomeTab2.SplitterWidth = 1;
            this.spcHomeTab2.TabIndex = 7;
            // 
            // cboPeriod
            // 
            this.cboPeriod.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboPeriod.FormattingEnabled = true;
            this.cboPeriod.Items.AddRange(new object[] {
            "Monthly",
            "Quarterly",
            "Custom period"});
            this.cboPeriod.Location = new System.Drawing.Point(0, 0);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(285, 28);
            this.cboPeriod.TabIndex = 4;
            this.cboPeriod.SelectedIndexChanged += new System.EventHandler(this.cboPeriod_SelectedIndexChanged);
            // 
            // lstPeriods
            // 
            this.lstPeriods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.lstPeriods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPeriods.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPeriods.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lstPeriods.FormattingEnabled = true;
            this.lstPeriods.ItemHeight = 21;
            this.lstPeriods.Location = new System.Drawing.Point(4, 92);
            this.lstPeriods.Name = "lstPeriods";
            this.lstPeriods.Size = new System.Drawing.Size(285, 359);
            this.lstPeriods.TabIndex = 0;
            this.lstPeriods.SelectedIndexChanged += new System.EventHandler(this.lstPeriods_SelectedIndexChanged);
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.txtYear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtYear.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.txtYear.Location = new System.Drawing.Point(0, 390);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(285, 32);
            this.txtYear.TabIndex = 20;
            this.txtYear.Text = "2011";
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            // 
            // pnlCustomDates
            // 
            this.pnlCustomDates.Controls.Add(this.cboMonths);
            this.pnlCustomDates.Controls.Add(this.txtSDate);
            this.pnlCustomDates.Controls.Add(this.lblStartDate);
            this.pnlCustomDates.Controls.Add(this.txtQStart);
            this.pnlCustomDates.Controls.Add(this.lblEndDate);
            this.pnlCustomDates.Controls.Add(this.txtEDate);
            this.pnlCustomDates.Enabled = false;
            this.pnlCustomDates.Location = new System.Drawing.Point(0, 26);
            this.pnlCustomDates.Name = "pnlCustomDates";
            this.pnlCustomDates.Size = new System.Drawing.Size(285, 65);
            this.pnlCustomDates.TabIndex = 13;
            // 
            // cboMonths
            // 
            this.cboMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonths.FormattingEnabled = true;
            this.cboMonths.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboMonths.Location = new System.Drawing.Point(6, 96);
            this.cboMonths.Name = "cboMonths";
            this.cboMonths.Size = new System.Drawing.Size(216, 25);
            this.cboMonths.TabIndex = 11;
            this.cboMonths.Visible = false;
            // 
            // txtSDate
            // 
            this.txtSDate.CustomFormat = "yyyy-MM-dd";
            this.txtSDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSDate.Location = new System.Drawing.Point(93, 8);
            this.txtSDate.Name = "txtSDate";
            this.txtSDate.Size = new System.Drawing.Size(128, 26);
            this.txtSDate.TabIndex = 2;
            this.txtSDate.Value = new System.DateTime(2011, 5, 18, 0, 0, 0, 0);
            this.txtSDate.ValueChanged += new System.EventHandler(this.txtSDate_ValueChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStartDate.Location = new System.Drawing.Point(4, 14);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(85, 21);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date:";
            this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQStart
            // 
            this.txtQStart.Location = new System.Drawing.Point(232, 19);
            this.txtQStart.Name = "txtQStart";
            this.txtQStart.Size = new System.Drawing.Size(28, 27);
            this.txtQStart.TabIndex = 12;
            this.txtQStart.Visible = false;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEndDate.Location = new System.Drawing.Point(3, 39);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(77, 21);
            this.lblEndDate.TabIndex = 1;
            this.lblEndDate.Text = "End Date:";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEDate
            // 
            this.txtEDate.CustomFormat = "yyyy-MM-dd";
            this.txtEDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtEDate.Location = new System.Drawing.Point(93, 37);
            this.txtEDate.Name = "txtEDate";
            this.txtEDate.Size = new System.Drawing.Size(128, 26);
            this.txtEDate.TabIndex = 3;
            this.txtEDate.Value = new System.DateTime(2011, 5, 18, 0, 0, 0, 0);
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.tcDonors);
            this.panel22.Controls.Add(this.spCD4s);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(0, 0);
            this.panel22.Margin = new System.Windows.Forms.Padding(300);
            this.panel22.Name = "panel22";
            this.panel22.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel22.Size = new System.Drawing.Size(1005, 422);
            this.panel22.TabIndex = 4;
            // 
            // tcDonors
            // 
            this.tcDonors.Controls.Add(this.tpCommon);
            this.tcDonors.Controls.Add(this.tpCountry);
            this.tcDonors.Controls.Add(this.tpDonorCustomReport);
            this.tcDonors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDonors.Location = new System.Drawing.Point(0, 31);
            this.tcDonors.Margin = new System.Windows.Forms.Padding(0);
            this.tcDonors.Name = "tcDonors";
            this.tcDonors.Padding = new System.Drawing.Point(0, 0);
            this.tcDonors.SelectedIndex = 0;
            this.tcDonors.Size = new System.Drawing.Size(1005, 391);
            this.tcDonors.TabIndex = 6;
            this.tcDonors.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcDonors_Selected);
            // 
            // tpCommon
            // 
            this.tpCommon.BackColor = System.Drawing.Color.Transparent;
            this.tpCommon.Controls.Add(spCommon);
            this.tpCommon.Location = new System.Drawing.Point(4, 29);
            this.tpCommon.Name = "tpCommon";
            this.tpCommon.Size = new System.Drawing.Size(997, 358);
            this.tpCommon.TabIndex = 0;
            this.tpCommon.Text = "Common";
            // 
            // tpCountry
            // 
            this.tpCountry.BackColor = System.Drawing.Color.Transparent;
            this.tpCountry.Controls.Add(this.tcCountries);
            this.tpCountry.Location = new System.Drawing.Point(4, 29);
            this.tpCountry.Margin = new System.Windows.Forms.Padding(0);
            this.tpCountry.Name = "tpCountry";
            this.tpCountry.Size = new System.Drawing.Size(997, 358);
            this.tpCountry.TabIndex = 1;
            this.tpCountry.Text = "Country";
            // 
            // tcCountries
            // 
            this.tcCountries.Controls.Add(this.tpKe);
            this.tcCountries.Controls.Add(this.tpUg);
            this.tcCountries.Controls.Add(this.TpTz);
            this.tcCountries.Controls.Add(this.tpNg);
            this.tcCountries.Controls.Add(this.tpHt);
            this.tcCountries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCountries.Location = new System.Drawing.Point(0, 0);
            this.tcCountries.Margin = new System.Windows.Forms.Padding(0);
            this.tcCountries.Name = "tcCountries";
            this.tcCountries.Padding = new System.Drawing.Point(0, 0);
            this.tcCountries.SelectedIndex = 0;
            this.tcCountries.Size = new System.Drawing.Size(997, 358);
            this.tcCountries.TabIndex = 3;
            this.tcCountries.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcCountries_Selected);
            // 
            // tpKe
            // 
            this.tpKe.BackColor = System.Drawing.Color.Transparent;
            this.tpKe.Controls.Add(this.SpKenya);
            this.tpKe.Location = new System.Drawing.Point(4, 29);
            this.tpKe.Margin = new System.Windows.Forms.Padding(0);
            this.tpKe.Name = "tpKe";
            this.tpKe.Size = new System.Drawing.Size(989, 325);
            this.tpKe.TabIndex = 0;
            this.tpKe.Text = "Kenya";
            // 
            // SpKenya
            // 
            this.SpKenya.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpKenya.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SpKenya.IsSplitterFixed = true;
            this.SpKenya.Location = new System.Drawing.Point(0, 0);
            this.SpKenya.Margin = new System.Windows.Forms.Padding(0);
            this.SpKenya.Name = "SpKenya";
            // 
            // SpKenya.Panel1
            // 
            this.SpKenya.Panel1.AutoScroll = true;
            this.SpKenya.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SpKenya.Panel1.Controls.Add(this.tlp_KeReports);
            // 
            // SpKenya.Panel2
            // 
            this.SpKenya.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.SpKenya.Panel2.Controls.Add(this.prBKeReports);
            this.SpKenya.Panel2.Controls.Add(this.CmdKeReports);
            this.SpKenya.Panel2.Controls.Add(this.gbKenya);
            this.SpKenya.Size = new System.Drawing.Size(989, 325);
            this.SpKenya.SplitterDistance = 788;
            this.SpKenya.SplitterWidth = 1;
            this.SpKenya.TabIndex = 16;
            // 
            // tlp_KeReports
            // 
            this.tlp_KeReports.AutoScroll = true;
            this.tlp_KeReports.ColumnCount = 4;
            this.tlp_KeReports.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_KeReports.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_KeReports.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_KeReports.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_KeReports.Controls.Add(this.optKe_FMAP, 1, 6);
            this.tlp_KeReports.Controls.Add(this.OptKe_MoH711, 1, 1);
            this.tlp_KeReports.Controls.Add(this.optKe_MoH731, 1, 2);
            this.tlp_KeReports.Controls.Add(this.OptKe_RC, 1, 3);
            this.tlp_KeReports.Controls.Add(this.OptKe_Lwak, 1, 4);
            this.tlp_KeReports.Controls.Add(this.chk_RCLineLists, 2, 3);
            this.tlp_KeReports.Controls.Add(this.optKe_MCHC, 1, 8);
            this.tlp_KeReports.Controls.Add(this.optKE_PS, 1, 10);
            this.tlp_KeReports.Controls.Add(this.flp_PS, 2, 10);
            this.tlp_KeReports.Controls.Add(this.optKe_TBC, 1, 5);
            this.tlp_KeReports.Controls.Add(this.optKe_HEICA, 1, 9);
            this.tlp_KeReports.Controls.Add(this.optKe_CDRR, 1, 7);
            this.tlp_KeReports.Controls.Add(this.optKe_MoH361B, 1, 11);
            this.tlp_KeReports.Controls.Add(this.optKe_Defaulter, 1, 12);
            this.tlp_KeReports.Controls.Add(this.optKe_PwP, 1, 13);
            this.tlp_KeReports.Controls.Add(this.optKe_TBRegister, 1, 15);
            this.tlp_KeReports.Controls.Add(this.optke_OIDrugs, 1, 16);
            this.tlp_KeReports.Controls.Add(this.optKe_MoH717, 1, 18);
            this.tlp_KeReports.Controls.Add(this.optKe_MoH705A, 1, 19);
            this.tlp_KeReports.Controls.Add(this.optKe_MoH705B, 1, 20);
            this.tlp_KeReports.Controls.Add(this.optHEIRegister, 1, 21);
            this.tlp_KeReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_KeReports.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlp_KeReports.Location = new System.Drawing.Point(0, 0);
            this.tlp_KeReports.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_KeReports.Name = "tlp_KeReports";
            this.tlp_KeReports.RowCount = 22;
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_KeReports.Size = new System.Drawing.Size(788, 325);
            this.tlp_KeReports.TabIndex = 0;
            // 
            // optKe_FMAP
            // 
            this.optKe_FMAP.AutoSize = true;
            this.optKe_FMAP.Location = new System.Drawing.Point(3, 153);
            this.optKe_FMAP.Name = "optKe_FMAP";
            this.optKe_FMAP.Size = new System.Drawing.Size(223, 24);
            this.optKe_FMAP.TabIndex = 13;
            this.optKe_FMAP.Text = "F-MAPS Consumption Report";
            this.optKe_FMAP.UseVisualStyleBackColor = true;
            // 
            // OptKe_MoH711
            // 
            this.OptKe_MoH711.AutoSize = true;
            this.OptKe_MoH711.Location = new System.Drawing.Point(3, 3);
            this.OptKe_MoH711.Name = "OptKe_MoH711";
            this.OptKe_MoH711.Size = new System.Drawing.Size(208, 24);
            this.OptKe_MoH711.TabIndex = 7;
            this.OptKe_MoH711.Text = "MoH 711 (Monthly) Report";
            this.OptKe_MoH711.UseVisualStyleBackColor = true;
            this.OptKe_MoH711.CheckedChanged += new System.EventHandler(this.OptKe_MoH711_CheckedChanged);
            // 
            // optKe_MoH731
            // 
            this.optKe_MoH731.AutoSize = true;
            this.optKe_MoH731.Location = new System.Drawing.Point(3, 33);
            this.optKe_MoH731.Name = "optKe_MoH731";
            this.optKe_MoH731.Size = new System.Drawing.Size(208, 24);
            this.optKe_MoH731.TabIndex = 11;
            this.optKe_MoH731.Text = "MoH 731 (Monthly) Report";
            this.optKe_MoH731.UseVisualStyleBackColor = true;
            this.optKe_MoH731.CheckedChanged += new System.EventHandler(this.optKe_MoH731_CheckedChanged);
            // 
            // OptKe_RC
            // 
            this.OptKe_RC.AutoSize = true;
            this.OptKe_RC.Location = new System.Drawing.Point(3, 63);
            this.OptKe_RC.Name = "OptKe_RC";
            this.OptKe_RC.Size = new System.Drawing.Size(185, 24);
            this.OptKe_RC.TabIndex = 9;
            this.OptKe_RC.Text = "(Quarterly) Report Card";
            this.OptKe_RC.UseVisualStyleBackColor = true;
            this.OptKe_RC.CheckedChanged += new System.EventHandler(this.OptKe_RC_CheckedChanged);
            // 
            // OptKe_Lwak
            // 
            this.OptKe_Lwak.AutoSize = true;
            this.OptKe_Lwak.Location = new System.Drawing.Point(3, 93);
            this.OptKe_Lwak.Name = "OptKe_Lwak";
            this.OptKe_Lwak.Size = new System.Drawing.Size(227, 24);
            this.OptKe_Lwak.TabIndex = 8;
            this.OptKe_Lwak.Text = "CDC Database Extracts (Lwak)";
            this.OptKe_Lwak.UseVisualStyleBackColor = true;
            // 
            // chk_RCLineLists
            // 
            this.chk_RCLineLists.AutoSize = true;
            this.chk_RCLineLists.Location = new System.Drawing.Point(260, 63);
            this.chk_RCLineLists.Name = "chk_RCLineLists";
            this.chk_RCLineLists.Size = new System.Drawing.Size(142, 24);
            this.chk_RCLineLists.TabIndex = 10;
            this.chk_RCLineLists.Text = "Include Line Lists";
            this.chk_RCLineLists.UseVisualStyleBackColor = true;
            this.chk_RCLineLists.Visible = false;
            // 
            // optKe_MCHC
            // 
            this.optKe_MCHC.AutoSize = true;
            this.optKe_MCHC.Location = new System.Drawing.Point(3, 213);
            this.optKe_MCHC.Name = "optKe_MCHC";
            this.optKe_MCHC.Size = new System.Drawing.Size(196, 24);
            this.optKe_MCHC.TabIndex = 15;
            this.optKe_MCHC.Text = "MCHC (Quarterly) Report";
            this.optKe_MCHC.UseVisualStyleBackColor = true;
            // 
            // optKE_PS
            // 
            this.optKE_PS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.optKE_PS.AutoSize = true;
            this.optKE_PS.Location = new System.Drawing.Point(3, 273);
            this.optKE_PS.Name = "optKE_PS";
            this.optKE_PS.Size = new System.Drawing.Size(251, 24);
            this.optKE_PS.TabIndex = 17;
            this.optKE_PS.Text = "Patient Summary Report";
            this.optKE_PS.UseVisualStyleBackColor = true;
            this.optKE_PS.CheckedChanged += new System.EventHandler(this.optKE_PS_CheckedChanged);
            // 
            // flp_PS
            // 
            this.flp_PS.Controls.Add(this.lblPatientID);
            this.flp_PS.Controls.Add(this.txtPatientID);
            this.flp_PS.Controls.Add(this.cmdMultipleSummaries);
            this.flp_PS.Location = new System.Drawing.Point(260, 273);
            this.flp_PS.Name = "flp_PS";
            this.flp_PS.Size = new System.Drawing.Size(365, 24);
            this.flp_PS.TabIndex = 18;
            // 
            // lblPatientID
            // 
            this.lblPatientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Location = new System.Drawing.Point(3, 3);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(76, 20);
            this.lblPatientID.TabIndex = 0;
            this.lblPatientID.Text = "Patient ID:";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Enabled = false;
            this.txtPatientID.Location = new System.Drawing.Point(82, 0);
            this.txtPatientID.Margin = new System.Windows.Forms.Padding(0);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(143, 27);
            this.txtPatientID.TabIndex = 1;
            this.txtPatientID.TextChanged += new System.EventHandler(this.txtPatientID_TextChanged);
            // 
            // cmdMultipleSummaries
            // 
            this.cmdMultipleSummaries.Enabled = false;
            this.cmdMultipleSummaries.Location = new System.Drawing.Point(225, 0);
            this.cmdMultipleSummaries.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMultipleSummaries.Name = "cmdMultipleSummaries";
            this.cmdMultipleSummaries.Size = new System.Drawing.Size(117, 24);
            this.cmdMultipleSummaries.TabIndex = 3;
            this.cmdMultipleSummaries.Text = "Generate Multiple";
            this.cmdMultipleSummaries.UseVisualStyleBackColor = true;
            this.cmdMultipleSummaries.Click += new System.EventHandler(this.cmdMultipleSummaries_Click);
            // 
            // optKe_TBC
            // 
            this.optKe_TBC.AutoSize = true;
            this.optKe_TBC.Location = new System.Drawing.Point(3, 123);
            this.optKe_TBC.Name = "optKe_TBC";
            this.optKe_TBC.Size = new System.Drawing.Size(106, 24);
            this.optKe_TBC.TabIndex = 16;
            this.optKe_TBC.Text = "TB Cascade";
            this.optKe_TBC.UseVisualStyleBackColor = true;
            // 
            // optKe_HEICA
            // 
            this.optKe_HEICA.AutoSize = true;
            this.optKe_HEICA.Location = new System.Drawing.Point(3, 243);
            this.optKe_HEICA.Name = "optKe_HEICA";
            this.optKe_HEICA.Size = new System.Drawing.Size(159, 24);
            this.optKe_HEICA.TabIndex = 14;
            this.optKe_HEICA.Text = "HEI Cohort Analysis";
            this.optKe_HEICA.UseVisualStyleBackColor = true;
            // 
            // optKe_CDRR
            // 
            this.optKe_CDRR.AutoSize = true;
            this.optKe_CDRR.Location = new System.Drawing.Point(3, 183);
            this.optKe_CDRR.Name = "optKe_CDRR";
            this.optKe_CDRR.Size = new System.Drawing.Size(209, 24);
            this.optKe_CDRR.TabIndex = 12;
            this.optKe_CDRR.Text = "CDRR Consumption Report";
            this.optKe_CDRR.UseVisualStyleBackColor = true;
            // 
            // optKe_MoH361B
            // 
            this.optKe_MoH361B.AutoSize = true;
            this.optKe_MoH361B.Location = new System.Drawing.Point(3, 303);
            this.optKe_MoH361B.Name = "optKe_MoH361B";
            this.optKe_MoH361B.Size = new System.Drawing.Size(229, 24);
            this.optKe_MoH361B.TabIndex = 19;
            this.optKe_MoH361B.Text = "MoH 361B (CCC ART Register)";
            this.optKe_MoH361B.UseVisualStyleBackColor = true;
            // 
            // optKe_Defaulter
            // 
            this.optKe_Defaulter.AutoSize = true;
            this.optKe_Defaulter.Location = new System.Drawing.Point(3, 333);
            this.optKe_Defaulter.Name = "optKe_Defaulter";
            this.optKe_Defaulter.Size = new System.Drawing.Size(193, 24);
            this.optKe_Defaulter.TabIndex = 20;
            this.optKe_Defaulter.Text = "Defaulter Tracing Report";
            this.optKe_Defaulter.UseVisualStyleBackColor = true;
            // 
            // optKe_PwP
            // 
            this.optKe_PwP.AutoSize = true;
            this.optKe_PwP.Location = new System.Drawing.Point(3, 363);
            this.optKe_PwP.Name = "optKe_PwP";
            this.optKe_PwP.Size = new System.Drawing.Size(174, 24);
            this.optKe_PwP.TabIndex = 21;
            this.optKe_PwP.Text = "PwP (Monthly) Report";
            this.optKe_PwP.UseVisualStyleBackColor = true;
            // 
            // optKe_TBRegister
            // 
            this.optKe_TBRegister.AutoSize = true;
            this.optKe_TBRegister.Location = new System.Drawing.Point(3, 393);
            this.optKe_TBRegister.Name = "optKe_TBRegister";
            this.optKe_TBRegister.Size = new System.Drawing.Size(105, 24);
            this.optKe_TBRegister.TabIndex = 22;
            this.optKe_TBRegister.Text = "TB Register";
            this.optKe_TBRegister.UseVisualStyleBackColor = true;
            // 
            // optke_OIDrugs
            // 
            this.optke_OIDrugs.AutoSize = true;
            this.optke_OIDrugs.Location = new System.Drawing.Point(3, 423);
            this.optke_OIDrugs.Name = "optke_OIDrugs";
            this.optke_OIDrugs.Size = new System.Drawing.Size(137, 24);
            this.optke_OIDrugs.TabIndex = 23;
            this.optke_OIDrugs.Text = "OI Drugs Report";
            this.optke_OIDrugs.UseVisualStyleBackColor = true;
            // 
            // optKe_MoH717
            // 
            this.optKe_MoH717.AutoSize = true;
            this.optKe_MoH717.Location = new System.Drawing.Point(3, 453);
            this.optKe_MoH717.Name = "optKe_MoH717";
            this.optKe_MoH717.Size = new System.Drawing.Size(223, 24);
            this.optKe_MoH717.TabIndex = 26;
            this.optKe_MoH717.Text = "MoH 717 (OutPatient) Report";
            this.optKe_MoH717.UseVisualStyleBackColor = true;
            // 
            // optKe_MoH705A
            // 
            this.optKe_MoH705A.AutoSize = true;
            this.optKe_MoH705A.Location = new System.Drawing.Point(3, 483);
            this.optKe_MoH705A.Name = "optKe_MoH705A";
            this.optKe_MoH705A.Size = new System.Drawing.Size(251, 24);
            this.optKe_MoH705A.TabIndex = 27;
            this.optKe_MoH705A.Text = "MoH 705A (Morbidity <5) Report";
            this.optKe_MoH705A.UseVisualStyleBackColor = true;
            // 
            // optKe_MoH705B
            // 
            this.optKe_MoH705B.AutoSize = true;
            this.optKe_MoH705B.Location = new System.Drawing.Point(3, 513);
            this.optKe_MoH705B.Name = "optKe_MoH705B";
            this.optKe_MoH705B.Size = new System.Drawing.Size(250, 24);
            this.optKe_MoH705B.TabIndex = 28;
            this.optKe_MoH705B.Text = "MoH 705B (Morbidity >5) Report";
            this.optKe_MoH705B.UseVisualStyleBackColor = true;
            // 
            // optHEIRegister
            // 
            this.optHEIRegister.AutoSize = true;
            this.optHEIRegister.Location = new System.Drawing.Point(3, 543);
            this.optHEIRegister.Name = "optHEIRegister";
            this.optHEIRegister.Size = new System.Drawing.Size(111, 24);
            this.optHEIRegister.TabIndex = 25;
            this.optHEIRegister.Text = "HEI Register";
            this.optHEIRegister.UseVisualStyleBackColor = true;
            this.optHEIRegister.Visible = false;
            // 
            // prBKeReports
            // 
            this.prBKeReports.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prBKeReports.Location = new System.Drawing.Point(0, 289);
            this.prBKeReports.Name = "prBKeReports";
            this.prBKeReports.Size = new System.Drawing.Size(200, 5);
            this.prBKeReports.TabIndex = 12;
            // 
            // CmdKeReports
            // 
            this.CmdKeReports.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CmdKeReports.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CmdKeReports.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdKeReports.Location = new System.Drawing.Point(0, 294);
            this.CmdKeReports.Name = "CmdKeReports";
            this.CmdKeReports.Size = new System.Drawing.Size(200, 31);
            this.CmdKeReports.TabIndex = 11;
            this.CmdKeReports.Text = "Generate Report";
            this.CmdKeReports.UseVisualStyleBackColor = false;
            this.CmdKeReports.Click += new System.EventHandler(this.CmdKeReports_Click);
            // 
            // gbKenya
            // 
            this.gbKenya.Controls.Add(this.chk_KESendToDHIS);
            this.gbKenya.Controls.Add(this.CboKECCC);
            this.gbKenya.Controls.Add(this.ChkKECCC);
            this.gbKenya.Controls.Add(this.cboKELPTF);
            this.gbKenya.Controls.Add(this.ChkKELPTF);
            this.gbKenya.Controls.Add(this.OptKEAll);
            this.gbKenya.Controls.Add(this.OptKELPTF);
            this.gbKenya.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbKenya.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.gbKenya.Location = new System.Drawing.Point(0, 0);
            this.gbKenya.Name = "gbKenya";
            this.gbKenya.Size = new System.Drawing.Size(200, 210);
            this.gbKenya.TabIndex = 10;
            this.gbKenya.TabStop = false;
            this.gbKenya.Text = "Location";
            // 
            // chk_KESendToDHIS
            // 
            this.chk_KESendToDHIS.AutoSize = true;
            this.chk_KESendToDHIS.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chk_KESendToDHIS.Location = new System.Drawing.Point(9, 173);
            this.chk_KESendToDHIS.Name = "chk_KESendToDHIS";
            this.chk_KESendToDHIS.Size = new System.Drawing.Size(122, 24);
            this.chk_KESendToDHIS.TabIndex = 11;
            this.chk_KESendToDHIS.Text = "Send To DHIS";
            this.chk_KESendToDHIS.UseVisualStyleBackColor = true;
            this.chk_KESendToDHIS.CheckedChanged += new System.EventHandler(this.chk_KESendToDHIS_CheckedChanged);
            // 
            // CboKECCC
            // 
            this.CboKECCC.FormattingEnabled = true;
            this.CboKECCC.Location = new System.Drawing.Point(66, 134);
            this.CboKECCC.Name = "CboKECCC";
            this.CboKECCC.Size = new System.Drawing.Size(144, 28);
            this.CboKECCC.TabIndex = 4;
            // 
            // ChkKECCC
            // 
            this.ChkKECCC.AutoSize = true;
            this.ChkKECCC.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkKECCC.Location = new System.Drawing.Point(9, 136);
            this.ChkKECCC.Name = "ChkKECCC";
            this.ChkKECCC.Size = new System.Drawing.Size(61, 24);
            this.ChkKECCC.TabIndex = 7;
            this.ChkKECCC.Text = "CCC:";
            this.ChkKECCC.UseVisualStyleBackColor = true;
            this.ChkKECCC.CheckedChanged += new System.EventHandler(this.ChkKECCC_CheckedChanged);
            // 
            // cboKELPTF
            // 
            this.cboKELPTF.FormattingEnabled = true;
            this.cboKELPTF.Location = new System.Drawing.Point(66, 70);
            this.cboKELPTF.Name = "cboKELPTF";
            this.cboKELPTF.Size = new System.Drawing.Size(144, 28);
            this.cboKELPTF.TabIndex = 6;
            this.cboKELPTF.SelectedIndexChanged += new System.EventHandler(this.cboKELPTF_SelectedIndexChanged);
            // 
            // ChkKELPTF
            // 
            this.ChkKELPTF.AutoSize = true;
            this.ChkKELPTF.Enabled = false;
            this.ChkKELPTF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChkKELPTF.Location = new System.Drawing.Point(66, 97);
            this.ChkKELPTF.Name = "ChkKELPTF";
            this.ChkKELPTF.Size = new System.Drawing.Size(158, 24);
            this.ChkKELPTF.TabIndex = 3;
            this.ChkKELPTF.Text = "Disaggregate CCCs";
            this.ChkKELPTF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkKELPTF.UseVisualStyleBackColor = true;
            this.ChkKELPTF.CheckedChanged += new System.EventHandler(this.ChkKELPTF_CheckedChanged);
            // 
            // OptKEAll
            // 
            this.OptKEAll.AutoSize = true;
            this.OptKEAll.Checked = true;
            this.OptKEAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OptKEAll.Location = new System.Drawing.Point(9, 34);
            this.OptKEAll.Name = "OptKEAll";
            this.OptKEAll.Size = new System.Drawing.Size(84, 24);
            this.OptKEAll.TabIndex = 2;
            this.OptKEAll.TabStop = true;
            this.OptKEAll.Text = "All Data";
            this.OptKEAll.UseVisualStyleBackColor = true;
            // 
            // OptKELPTF
            // 
            this.OptKELPTF.AutoSize = true;
            this.OptKELPTF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OptKELPTF.Location = new System.Drawing.Point(9, 71);
            this.OptKELPTF.Name = "OptKELPTF";
            this.OptKELPTF.Size = new System.Drawing.Size(60, 24);
            this.OptKELPTF.TabIndex = 0;
            this.OptKELPTF.Text = "LPTF";
            this.OptKELPTF.UseVisualStyleBackColor = true;
            this.OptKELPTF.CheckedChanged += new System.EventHandler(this.OptKELPTF_CheckedChanged);
            // 
            // tpUg
            // 
            this.tpUg.BackColor = System.Drawing.Color.Transparent;
            this.tpUg.Controls.Add(this.spUganda);
            this.tpUg.Location = new System.Drawing.Point(4, 29);
            this.tpUg.Margin = new System.Windows.Forms.Padding(0);
            this.tpUg.Name = "tpUg";
            this.tpUg.Size = new System.Drawing.Size(989, 329);
            this.tpUg.TabIndex = 3;
            this.tpUg.Text = "Uganda";
            // 
            // spUganda
            // 
            this.spUganda.BackColor = System.Drawing.Color.Transparent;
            this.spUganda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spUganda.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spUganda.IsSplitterFixed = true;
            this.spUganda.Location = new System.Drawing.Point(0, 0);
            this.spUganda.Margin = new System.Windows.Forms.Padding(0);
            this.spUganda.Name = "spUganda";
            // 
            // spUganda.Panel1
            // 
            this.spUganda.Panel1.AutoScroll = true;
            this.spUganda.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spUganda.Panel1.Controls.Add(this.OptUg_MoH);
            this.spUganda.Panel1.Controls.Add(this.optUg_CMR);
            // 
            // spUganda.Panel2
            // 
            this.spUganda.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.spUganda.Panel2.Controls.Add(this.cmdUgReports);
            this.spUganda.Panel2.Controls.Add(this.prBUgandaReports);
            this.spUganda.Panel2.Controls.Add(this.txtUgNumDays);
            this.spUganda.Panel2.Controls.Add(this.LblNumDays);
            this.spUganda.Panel2.Controls.Add(this.gbUganda);
            this.spUganda.Size = new System.Drawing.Size(989, 329);
            this.spUganda.SplitterDistance = 788;
            this.spUganda.SplitterWidth = 1;
            this.spUganda.TabIndex = 17;
            // 
            // OptUg_MoH
            // 
            this.OptUg_MoH.AutoSize = true;
            this.OptUg_MoH.Location = new System.Drawing.Point(16, 16);
            this.OptUg_MoH.Name = "OptUg_MoH";
            this.OptUg_MoH.Size = new System.Drawing.Size(187, 24);
            this.OptUg_MoH.TabIndex = 8;
            this.OptUg_MoH.Text = "MoH (Quarterly) Report";
            this.OptUg_MoH.UseVisualStyleBackColor = true;
            // 
            // optUg_CMR
            // 
            this.optUg_CMR.AutoSize = true;
            this.optUg_CMR.Location = new System.Drawing.Point(16, 51);
            this.optUg_CMR.Name = "optUg_CMR";
            this.optUg_CMR.Size = new System.Drawing.Size(249, 24);
            this.optUg_CMR.TabIndex = 7;
            this.optUg_CMR.Text = "Comprehensive (Monthly) Report";
            this.optUg_CMR.UseVisualStyleBackColor = true;
            // 
            // cmdUgReports
            // 
            this.cmdUgReports.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdUgReports.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdUgReports.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUgReports.Location = new System.Drawing.Point(0, 294);
            this.cmdUgReports.Name = "cmdUgReports";
            this.cmdUgReports.Size = new System.Drawing.Size(200, 30);
            this.cmdUgReports.TabIndex = 11;
            this.cmdUgReports.Text = "Generate Report";
            this.cmdUgReports.UseVisualStyleBackColor = false;
            this.cmdUgReports.Click += new System.EventHandler(this.cmdUgReports_Click);
            // 
            // prBUgandaReports
            // 
            this.prBUgandaReports.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prBUgandaReports.Location = new System.Drawing.Point(0, 324);
            this.prBUgandaReports.Name = "prBUgandaReports";
            this.prBUgandaReports.Size = new System.Drawing.Size(200, 5);
            this.prBUgandaReports.TabIndex = 12;
            // 
            // txtUgNumDays
            // 
            this.txtUgNumDays.Location = new System.Drawing.Point(184, 15);
            this.txtUgNumDays.Name = "txtUgNumDays";
            this.txtUgNumDays.Size = new System.Drawing.Size(32, 27);
            this.txtUgNumDays.TabIndex = 9;
            this.txtUgNumDays.Text = "14";
            // 
            // LblNumDays
            // 
            this.LblNumDays.AutoSize = true;
            this.LblNumDays.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumDays.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LblNumDays.Location = new System.Drawing.Point(41, 18);
            this.LblNumDays.Name = "LblNumDays";
            this.LblNumDays.Size = new System.Drawing.Size(182, 18);
            this.LblNumDays.TabIndex = 8;
            this.LblNumDays.Text = "Missed ART Days Cutoff:";
            this.LblNumDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbUganda
            // 
            this.gbUganda.Controls.Add(this.CboUgCCC);
            this.gbUganda.Controls.Add(this.chkUgCCC);
            this.gbUganda.Controls.Add(this.cboUgLPTF);
            this.gbUganda.Controls.Add(this.chkUgLPTF);
            this.gbUganda.Controls.Add(this.optUgAll);
            this.gbUganda.Controls.Add(this.optUgLPTF);
            this.gbUganda.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.gbUganda.Location = new System.Drawing.Point(8, 41);
            this.gbUganda.Name = "gbUganda";
            this.gbUganda.Size = new System.Drawing.Size(216, 164);
            this.gbUganda.TabIndex = 10;
            this.gbUganda.TabStop = false;
            this.gbUganda.Text = "Location";
            // 
            // CboUgCCC
            // 
            this.CboUgCCC.FormattingEnabled = true;
            this.CboUgCCC.Location = new System.Drawing.Point(66, 134);
            this.CboUgCCC.Name = "CboUgCCC";
            this.CboUgCCC.Size = new System.Drawing.Size(144, 28);
            this.CboUgCCC.TabIndex = 4;
            // 
            // chkUgCCC
            // 
            this.chkUgCCC.AutoSize = true;
            this.chkUgCCC.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkUgCCC.Location = new System.Drawing.Point(9, 136);
            this.chkUgCCC.Name = "chkUgCCC";
            this.chkUgCCC.Size = new System.Drawing.Size(61, 24);
            this.chkUgCCC.TabIndex = 7;
            this.chkUgCCC.Text = "CCC:";
            this.chkUgCCC.UseVisualStyleBackColor = true;
            this.chkUgCCC.CheckedChanged += new System.EventHandler(this.chkUgCCC_CheckedChanged);
            // 
            // cboUgLPTF
            // 
            this.cboUgLPTF.FormattingEnabled = true;
            this.cboUgLPTF.Location = new System.Drawing.Point(66, 70);
            this.cboUgLPTF.Name = "cboUgLPTF";
            this.cboUgLPTF.Size = new System.Drawing.Size(144, 28);
            this.cboUgLPTF.TabIndex = 6;
            this.cboUgLPTF.SelectedIndexChanged += new System.EventHandler(this.cboUgLPTF_SelectedIndexChanged);
            // 
            // chkUgLPTF
            // 
            this.chkUgLPTF.AutoSize = true;
            this.chkUgLPTF.Enabled = false;
            this.chkUgLPTF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkUgLPTF.Location = new System.Drawing.Point(66, 97);
            this.chkUgLPTF.Name = "chkUgLPTF";
            this.chkUgLPTF.Size = new System.Drawing.Size(158, 24);
            this.chkUgLPTF.TabIndex = 3;
            this.chkUgLPTF.Text = "Disaggregate CCCs";
            this.chkUgLPTF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUgLPTF.UseVisualStyleBackColor = true;
            this.chkUgLPTF.CheckedChanged += new System.EventHandler(this.chkUgLPTF_CheckedChanged);
            // 
            // optUgAll
            // 
            this.optUgAll.AutoSize = true;
            this.optUgAll.Checked = true;
            this.optUgAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optUgAll.Location = new System.Drawing.Point(9, 34);
            this.optUgAll.Name = "optUgAll";
            this.optUgAll.Size = new System.Drawing.Size(84, 24);
            this.optUgAll.TabIndex = 2;
            this.optUgAll.TabStop = true;
            this.optUgAll.Text = "All Data";
            this.optUgAll.UseVisualStyleBackColor = true;
            // 
            // optUgLPTF
            // 
            this.optUgLPTF.AutoSize = true;
            this.optUgLPTF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optUgLPTF.Location = new System.Drawing.Point(9, 71);
            this.optUgLPTF.Name = "optUgLPTF";
            this.optUgLPTF.Size = new System.Drawing.Size(60, 24);
            this.optUgLPTF.TabIndex = 0;
            this.optUgLPTF.Text = "LPTF";
            this.optUgLPTF.UseVisualStyleBackColor = true;
            this.optUgLPTF.CheckedChanged += new System.EventHandler(this.optUgLPTF_CheckedChanged);
            // 
            // TpTz
            // 
            this.TpTz.BackColor = System.Drawing.Color.Transparent;
            this.TpTz.Controls.Add(this.spTanzania);
            this.TpTz.Location = new System.Drawing.Point(4, 29);
            this.TpTz.Margin = new System.Windows.Forms.Padding(0);
            this.TpTz.Name = "TpTz";
            this.TpTz.Size = new System.Drawing.Size(989, 329);
            this.TpTz.TabIndex = 1;
            this.TpTz.Text = "Tanzania";
            // 
            // spTanzania
            // 
            this.spTanzania.BackColor = System.Drawing.Color.Transparent;
            this.spTanzania.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spTanzania.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spTanzania.IsSplitterFixed = true;
            this.spTanzania.Location = new System.Drawing.Point(0, 0);
            this.spTanzania.Name = "spTanzania";
            // 
            // spTanzania.Panel1
            // 
            this.spTanzania.Panel1.AutoScroll = true;
            this.spTanzania.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spTanzania.Panel1.Controls.Add(this.optCDCTanzania);
            this.spTanzania.Panel1.Controls.Add(this.optTzAPR);
            this.spTanzania.Panel1.Controls.Add(this.optTzCSR);
            // 
            // spTanzania.Panel2
            // 
            this.spTanzania.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.spTanzania.Panel2.Controls.Add(this.cmdTzDonor);
            this.spTanzania.Panel2.Controls.Add(this.prBTZReports);
            this.spTanzania.Panel2.Controls.Add(this.gbTZ);
            this.spTanzania.Size = new System.Drawing.Size(989, 329);
            this.spTanzania.SplitterDistance = 788;
            this.spTanzania.SplitterWidth = 1;
            this.spTanzania.TabIndex = 17;
            // 
            // optCDCTanzania
            // 
            this.optCDCTanzania.AutoSize = true;
            this.optCDCTanzania.Location = new System.Drawing.Point(18, 59);
            this.optCDCTanzania.Name = "optCDCTanzania";
            this.optCDCTanzania.Size = new System.Drawing.Size(315, 24);
            this.optCDCTanzania.TabIndex = 8;
            this.optCDCTanzania.Text = "CDC Track 1.0 (Quarterly) Report - Tanzania";
            this.optCDCTanzania.UseVisualStyleBackColor = true;
            // 
            // optTzAPR
            // 
            this.optTzAPR.AutoSize = true;
            this.optTzAPR.Location = new System.Drawing.Point(18, 97);
            this.optTzAPR.Name = "optTzAPR";
            this.optTzAPR.Size = new System.Drawing.Size(98, 24);
            this.optTzAPR.TabIndex = 7;
            this.optTzAPR.Text = "APR/SAPR";
            this.optTzAPR.UseVisualStyleBackColor = true;
            // 
            // optTzCSR
            // 
            this.optTzCSR.AutoSize = true;
            this.optTzCSR.Location = new System.Drawing.Point(18, 24);
            this.optTzCSR.Name = "optTzCSR";
            this.optTzCSR.Size = new System.Drawing.Size(179, 24);
            this.optTzCSR.TabIndex = 7;
            this.optTzCSR.Text = "Cross Sectional Report";
            this.optTzCSR.UseVisualStyleBackColor = true;
            // 
            // cmdTzDonor
            // 
            this.cmdTzDonor.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdTzDonor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdTzDonor.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTzDonor.Location = new System.Drawing.Point(0, 294);
            this.cmdTzDonor.Name = "cmdTzDonor";
            this.cmdTzDonor.Size = new System.Drawing.Size(200, 30);
            this.cmdTzDonor.TabIndex = 11;
            this.cmdTzDonor.Text = "Generate Report";
            this.cmdTzDonor.UseVisualStyleBackColor = false;
            this.cmdTzDonor.Click += new System.EventHandler(this.cmdTzDonor_Click);
            // 
            // prBTZReports
            // 
            this.prBTZReports.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prBTZReports.Location = new System.Drawing.Point(0, 324);
            this.prBTZReports.Name = "prBTZReports";
            this.prBTZReports.Size = new System.Drawing.Size(200, 5);
            this.prBTZReports.TabIndex = 12;
            // 
            // gbTZ
            // 
            this.gbTZ.Controls.Add(this.cboTzCCC);
            this.gbTZ.Controls.Add(this.chkTzCCC);
            this.gbTZ.Controls.Add(this.cboTzLPTF);
            this.gbTZ.Controls.Add(this.chkTzLPTF);
            this.gbTZ.Controls.Add(this.optTzAll);
            this.gbTZ.Controls.Add(this.optTzLPTF);
            this.gbTZ.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTZ.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.gbTZ.Location = new System.Drawing.Point(0, 0);
            this.gbTZ.Name = "gbTZ";
            this.gbTZ.Size = new System.Drawing.Size(200, 164);
            this.gbTZ.TabIndex = 12;
            this.gbTZ.TabStop = false;
            this.gbTZ.Text = "Location";
            // 
            // cboTzCCC
            // 
            this.cboTzCCC.FormattingEnabled = true;
            this.cboTzCCC.Location = new System.Drawing.Point(66, 134);
            this.cboTzCCC.Name = "cboTzCCC";
            this.cboTzCCC.Size = new System.Drawing.Size(144, 28);
            this.cboTzCCC.TabIndex = 4;
            // 
            // chkTzCCC
            // 
            this.chkTzCCC.AutoSize = true;
            this.chkTzCCC.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkTzCCC.Location = new System.Drawing.Point(9, 136);
            this.chkTzCCC.Name = "chkTzCCC";
            this.chkTzCCC.Size = new System.Drawing.Size(61, 24);
            this.chkTzCCC.TabIndex = 7;
            this.chkTzCCC.Text = "CCC:";
            this.chkTzCCC.UseVisualStyleBackColor = true;
            // 
            // cboTzLPTF
            // 
            this.cboTzLPTF.FormattingEnabled = true;
            this.cboTzLPTF.Location = new System.Drawing.Point(66, 70);
            this.cboTzLPTF.Name = "cboTzLPTF";
            this.cboTzLPTF.Size = new System.Drawing.Size(144, 28);
            this.cboTzLPTF.TabIndex = 6;
            // 
            // chkTzLPTF
            // 
            this.chkTzLPTF.AutoSize = true;
            this.chkTzLPTF.Enabled = false;
            this.chkTzLPTF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkTzLPTF.Location = new System.Drawing.Point(66, 97);
            this.chkTzLPTF.Name = "chkTzLPTF";
            this.chkTzLPTF.Size = new System.Drawing.Size(158, 24);
            this.chkTzLPTF.TabIndex = 3;
            this.chkTzLPTF.Text = "Disaggregate CCCs";
            this.chkTzLPTF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTzLPTF.UseVisualStyleBackColor = true;
            // 
            // optTzAll
            // 
            this.optTzAll.AutoSize = true;
            this.optTzAll.Checked = true;
            this.optTzAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optTzAll.Location = new System.Drawing.Point(9, 34);
            this.optTzAll.Name = "optTzAll";
            this.optTzAll.Size = new System.Drawing.Size(84, 24);
            this.optTzAll.TabIndex = 2;
            this.optTzAll.TabStop = true;
            this.optTzAll.Text = "All Data";
            this.optTzAll.UseVisualStyleBackColor = true;
            // 
            // optTzLPTF
            // 
            this.optTzLPTF.AutoSize = true;
            this.optTzLPTF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optTzLPTF.Location = new System.Drawing.Point(9, 71);
            this.optTzLPTF.Name = "optTzLPTF";
            this.optTzLPTF.Size = new System.Drawing.Size(60, 24);
            this.optTzLPTF.TabIndex = 0;
            this.optTzLPTF.Text = "LPTF";
            this.optTzLPTF.UseVisualStyleBackColor = true;
            // 
            // tpNg
            // 
            this.tpNg.BackColor = System.Drawing.Color.Transparent;
            this.tpNg.Controls.Add(this.spNigeria);
            this.tpNg.Location = new System.Drawing.Point(4, 29);
            this.tpNg.Margin = new System.Windows.Forms.Padding(0);
            this.tpNg.Name = "tpNg";
            this.tpNg.Size = new System.Drawing.Size(989, 329);
            this.tpNg.TabIndex = 2;
            this.tpNg.Text = "Nigeria";
            // 
            // spNigeria
            // 
            this.spNigeria.BackColor = System.Drawing.Color.Transparent;
            this.spNigeria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spNigeria.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spNigeria.IsSplitterFixed = true;
            this.spNigeria.Location = new System.Drawing.Point(0, 0);
            this.spNigeria.Margin = new System.Windows.Forms.Padding(0);
            this.spNigeria.Name = "spNigeria";
            // 
            // spNigeria.Panel1
            // 
            this.spNigeria.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spNigeria.Panel1.Controls.Add(this.optMonthlyNigeria);
            this.spNigeria.Panel1.Controls.Add(this.optCDCNigeria);
            // 
            // spNigeria.Panel2
            // 
            this.spNigeria.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.spNigeria.Panel2.Controls.Add(this.cmdNigeriaDonor);
            this.spNigeria.Panel2.Controls.Add(this.prBNigeriaReports);
            this.spNigeria.Panel2.Controls.Add(this.gbNigeria);
            this.spNigeria.Size = new System.Drawing.Size(989, 329);
            this.spNigeria.SplitterDistance = 788;
            this.spNigeria.SplitterWidth = 1;
            this.spNigeria.TabIndex = 0;
            // 
            // optMonthlyNigeria
            // 
            this.optMonthlyNigeria.AutoSize = true;
            this.optMonthlyNigeria.Location = new System.Drawing.Point(19, 53);
            this.optMonthlyNigeria.Name = "optMonthlyNigeria";
            this.optMonthlyNigeria.Size = new System.Drawing.Size(171, 24);
            this.optMonthlyNigeria.TabIndex = 1;
            this.optMonthlyNigeria.TabStop = true;
            this.optMonthlyNigeria.Text = "Monthly Report Form";
            this.optMonthlyNigeria.UseVisualStyleBackColor = true;
            // 
            // optCDCNigeria
            // 
            this.optCDCNigeria.AutoSize = true;
            this.optCDCNigeria.Checked = true;
            this.optCDCNigeria.Location = new System.Drawing.Point(19, 19);
            this.optCDCNigeria.Name = "optCDCNigeria";
            this.optCDCNigeria.Size = new System.Drawing.Size(307, 24);
            this.optCDCNigeria.TabIndex = 0;
            this.optCDCNigeria.TabStop = true;
            this.optCDCNigeria.Text = "CDC Track 1.0 (Quarterly) Report - Nigeria";
            this.optCDCNigeria.UseVisualStyleBackColor = true;
            // 
            // cmdNigeriaDonor
            // 
            this.cmdNigeriaDonor.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdNigeriaDonor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdNigeriaDonor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNigeriaDonor.Location = new System.Drawing.Point(0, 293);
            this.cmdNigeriaDonor.Name = "cmdNigeriaDonor";
            this.cmdNigeriaDonor.Size = new System.Drawing.Size(200, 31);
            this.cmdNigeriaDonor.TabIndex = 12;
            this.cmdNigeriaDonor.Text = "Generate Report";
            this.cmdNigeriaDonor.UseVisualStyleBackColor = false;
            this.cmdNigeriaDonor.Click += new System.EventHandler(this.cmdNigeriaDonor_Click);
            // 
            // prBNigeriaReports
            // 
            this.prBNigeriaReports.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prBNigeriaReports.Location = new System.Drawing.Point(0, 324);
            this.prBNigeriaReports.Name = "prBNigeriaReports";
            this.prBNigeriaReports.Size = new System.Drawing.Size(200, 5);
            this.prBNigeriaReports.TabIndex = 13;
            // 
            // gbNigeria
            // 
            this.gbNigeria.Controls.Add(this.cboNgCCC);
            this.gbNigeria.Controls.Add(this.chkNgCCC);
            this.gbNigeria.Controls.Add(this.cboNgLPTF);
            this.gbNigeria.Controls.Add(this.chkNgLPTF);
            this.gbNigeria.Controls.Add(this.optNgAll);
            this.gbNigeria.Controls.Add(this.optNgLPTF);
            this.gbNigeria.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbNigeria.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.gbNigeria.Location = new System.Drawing.Point(0, 0);
            this.gbNigeria.Name = "gbNigeria";
            this.gbNigeria.Size = new System.Drawing.Size(200, 164);
            this.gbNigeria.TabIndex = 11;
            this.gbNigeria.TabStop = false;
            this.gbNigeria.Text = "Location";
            // 
            // cboNgCCC
            // 
            this.cboNgCCC.FormattingEnabled = true;
            this.cboNgCCC.Location = new System.Drawing.Point(66, 134);
            this.cboNgCCC.Name = "cboNgCCC";
            this.cboNgCCC.Size = new System.Drawing.Size(144, 28);
            this.cboNgCCC.TabIndex = 4;
            // 
            // chkNgCCC
            // 
            this.chkNgCCC.AutoSize = true;
            this.chkNgCCC.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkNgCCC.Location = new System.Drawing.Point(9, 136);
            this.chkNgCCC.Name = "chkNgCCC";
            this.chkNgCCC.Size = new System.Drawing.Size(61, 24);
            this.chkNgCCC.TabIndex = 7;
            this.chkNgCCC.Text = "CCC:";
            this.chkNgCCC.UseVisualStyleBackColor = true;
            this.chkNgCCC.CheckedChanged += new System.EventHandler(this.chkNgCCC_CheckedChanged);
            // 
            // cboNgLPTF
            // 
            this.cboNgLPTF.FormattingEnabled = true;
            this.cboNgLPTF.Location = new System.Drawing.Point(66, 70);
            this.cboNgLPTF.Name = "cboNgLPTF";
            this.cboNgLPTF.Size = new System.Drawing.Size(144, 28);
            this.cboNgLPTF.TabIndex = 6;
            this.cboNgLPTF.SelectedIndexChanged += new System.EventHandler(this.cboNgLPTF_SelectedIndexChanged);
            // 
            // chkNgLPTF
            // 
            this.chkNgLPTF.AutoSize = true;
            this.chkNgLPTF.Enabled = false;
            this.chkNgLPTF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkNgLPTF.Location = new System.Drawing.Point(66, 97);
            this.chkNgLPTF.Name = "chkNgLPTF";
            this.chkNgLPTF.Size = new System.Drawing.Size(158, 24);
            this.chkNgLPTF.TabIndex = 3;
            this.chkNgLPTF.Text = "Disaggregate CCCs";
            this.chkNgLPTF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNgLPTF.UseVisualStyleBackColor = true;
            this.chkNgLPTF.CheckedChanged += new System.EventHandler(this.chkNgLPTF_CheckedChanged);
            // 
            // optNgAll
            // 
            this.optNgAll.AutoSize = true;
            this.optNgAll.Checked = true;
            this.optNgAll.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optNgAll.Location = new System.Drawing.Point(9, 34);
            this.optNgAll.Name = "optNgAll";
            this.optNgAll.Size = new System.Drawing.Size(84, 24);
            this.optNgAll.TabIndex = 2;
            this.optNgAll.TabStop = true;
            this.optNgAll.Text = "All Data";
            this.optNgAll.UseVisualStyleBackColor = true;
            // 
            // optNgLPTF
            // 
            this.optNgLPTF.AutoSize = true;
            this.optNgLPTF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optNgLPTF.Location = new System.Drawing.Point(9, 71);
            this.optNgLPTF.Name = "optNgLPTF";
            this.optNgLPTF.Size = new System.Drawing.Size(60, 24);
            this.optNgLPTF.TabIndex = 0;
            this.optNgLPTF.Text = "LPTF";
            this.optNgLPTF.UseVisualStyleBackColor = true;
            this.optNgLPTF.CheckedChanged += new System.EventHandler(this.optNgLPTF_CheckedChanged);
            // 
            // tpHt
            // 
            this.tpHt.BackColor = System.Drawing.Color.Transparent;
            this.tpHt.Controls.Add(this.spHaiti);
            this.tpHt.Location = new System.Drawing.Point(4, 29);
            this.tpHt.Margin = new System.Windows.Forms.Padding(0);
            this.tpHt.Name = "tpHt";
            this.tpHt.Size = new System.Drawing.Size(989, 329);
            this.tpHt.TabIndex = 5;
            this.tpHt.Text = "Haiti";
            // 
            // spHaiti
            // 
            this.spHaiti.BackColor = System.Drawing.Color.Transparent;
            this.spHaiti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spHaiti.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spHaiti.IsSplitterFixed = true;
            this.spHaiti.Location = new System.Drawing.Point(0, 0);
            this.spHaiti.Margin = new System.Windows.Forms.Padding(0);
            this.spHaiti.Name = "spHaiti";
            // 
            // spHaiti.Panel1
            // 
            this.spHaiti.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spHaiti.Panel1.Controls.Add(this.optHt_Monthly);
            // 
            // spHaiti.Panel2
            // 
            this.spHaiti.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.spHaiti.Panel2.Controls.Add(this.prBHaitiReports);
            this.spHaiti.Panel2.Controls.Add(this.cmdHtReport);
            this.spHaiti.Panel2.Controls.Add(this.gbHaiti);
            this.spHaiti.Size = new System.Drawing.Size(989, 329);
            this.spHaiti.SplitterDistance = 788;
            this.spHaiti.SplitterWidth = 1;
            this.spHaiti.TabIndex = 0;
            // 
            // optHt_Monthly
            // 
            this.optHt_Monthly.AutoSize = true;
            this.optHt_Monthly.Checked = true;
            this.optHt_Monthly.Location = new System.Drawing.Point(18, 16);
            this.optHt_Monthly.Name = "optHt_Monthly";
            this.optHt_Monthly.Size = new System.Drawing.Size(137, 24);
            this.optHt_Monthly.TabIndex = 0;
            this.optHt_Monthly.TabStop = true;
            this.optHt_Monthly.Text = "Monthly Report ";
            this.optHt_Monthly.UseVisualStyleBackColor = true;
            // 
            // prBHaitiReports
            // 
            this.prBHaitiReports.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prBHaitiReports.Location = new System.Drawing.Point(0, 294);
            this.prBHaitiReports.Name = "prBHaitiReports";
            this.prBHaitiReports.Size = new System.Drawing.Size(200, 5);
            this.prBHaitiReports.TabIndex = 14;
            // 
            // cmdHtReport
            // 
            this.cmdHtReport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdHtReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdHtReport.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdHtReport.Location = new System.Drawing.Point(0, 299);
            this.cmdHtReport.Name = "cmdHtReport";
            this.cmdHtReport.Size = new System.Drawing.Size(200, 30);
            this.cmdHtReport.TabIndex = 13;
            this.cmdHtReport.Text = "Generate Report";
            this.cmdHtReport.UseVisualStyleBackColor = false;
            this.cmdHtReport.Click += new System.EventHandler(this.cmdHtReport_Click);
            // 
            // gbHaiti
            // 
            this.gbHaiti.Controls.Add(this.cboHt_CCC);
            this.gbHaiti.Controls.Add(this.chkHt_CCC);
            this.gbHaiti.Controls.Add(this.chkHt_LPTF);
            this.gbHaiti.Controls.Add(this.cboHt_LPTF);
            this.gbHaiti.Controls.Add(this.optHt_LPTF);
            this.gbHaiti.Controls.Add(this.optHt_All);
            this.gbHaiti.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHaiti.Enabled = false;
            this.gbHaiti.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.gbHaiti.Location = new System.Drawing.Point(0, 0);
            this.gbHaiti.Name = "gbHaiti";
            this.gbHaiti.Size = new System.Drawing.Size(200, 178);
            this.gbHaiti.TabIndex = 0;
            this.gbHaiti.TabStop = false;
            this.gbHaiti.Text = "Location";
            // 
            // cboHt_CCC
            // 
            this.cboHt_CCC.FormattingEnabled = true;
            this.cboHt_CCC.Location = new System.Drawing.Point(73, 130);
            this.cboHt_CCC.Name = "cboHt_CCC";
            this.cboHt_CCC.Size = new System.Drawing.Size(155, 28);
            this.cboHt_CCC.TabIndex = 5;
            // 
            // chkHt_CCC
            // 
            this.chkHt_CCC.AutoSize = true;
            this.chkHt_CCC.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkHt_CCC.Location = new System.Drawing.Point(18, 134);
            this.chkHt_CCC.Name = "chkHt_CCC";
            this.chkHt_CCC.Size = new System.Drawing.Size(61, 24);
            this.chkHt_CCC.TabIndex = 4;
            this.chkHt_CCC.Text = "CCC:";
            this.chkHt_CCC.UseVisualStyleBackColor = true;
            // 
            // chkHt_LPTF
            // 
            this.chkHt_LPTF.AutoSize = true;
            this.chkHt_LPTF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkHt_LPTF.Location = new System.Drawing.Point(73, 94);
            this.chkHt_LPTF.Name = "chkHt_LPTF";
            this.chkHt_LPTF.Size = new System.Drawing.Size(158, 24);
            this.chkHt_LPTF.TabIndex = 3;
            this.chkHt_LPTF.Text = "Disaggregate CCCs";
            this.chkHt_LPTF.UseVisualStyleBackColor = true;
            // 
            // cboHt_LPTF
            // 
            this.cboHt_LPTF.FormattingEnabled = true;
            this.cboHt_LPTF.Location = new System.Drawing.Point(73, 66);
            this.cboHt_LPTF.Name = "cboHt_LPTF";
            this.cboHt_LPTF.Size = new System.Drawing.Size(155, 28);
            this.cboHt_LPTF.TabIndex = 2;
            // 
            // optHt_LPTF
            // 
            this.optHt_LPTF.AutoSize = true;
            this.optHt_LPTF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optHt_LPTF.Location = new System.Drawing.Point(18, 66);
            this.optHt_LPTF.Name = "optHt_LPTF";
            this.optHt_LPTF.Size = new System.Drawing.Size(60, 24);
            this.optHt_LPTF.TabIndex = 1;
            this.optHt_LPTF.TabStop = true;
            this.optHt_LPTF.Text = "LPTF";
            this.optHt_LPTF.UseVisualStyleBackColor = true;
            // 
            // optHt_All
            // 
            this.optHt_All.AutoSize = true;
            this.optHt_All.Checked = true;
            this.optHt_All.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.optHt_All.Location = new System.Drawing.Point(18, 33);
            this.optHt_All.Name = "optHt_All";
            this.optHt_All.Size = new System.Drawing.Size(84, 24);
            this.optHt_All.TabIndex = 0;
            this.optHt_All.TabStop = true;
            this.optHt_All.Text = "All Data";
            this.optHt_All.UseVisualStyleBackColor = true;
            // 
            // tpDonorCustomReport
            // 
            this.tpDonorCustomReport.BackColor = System.Drawing.Color.Transparent;
            this.tpDonorCustomReport.Controls.Add(this.gbCReportFilters);
            this.tpDonorCustomReport.Controls.Add(this.cboCustomReport);
            this.tpDonorCustomReport.Controls.Add(this.label149);
            this.tpDonorCustomReport.Location = new System.Drawing.Point(4, 29);
            this.tpDonorCustomReport.Name = "tpDonorCustomReport";
            this.tpDonorCustomReport.Size = new System.Drawing.Size(997, 358);
            this.tpDonorCustomReport.TabIndex = 3;
            this.tpDonorCustomReport.Text = "Custom Reports";
            // 
            // gbCReportFilters
            // 
            this.gbCReportFilters.Controls.Add(this.cboGenerateCReport);
            this.gbCReportFilters.Controls.Add(this.pnlCReportFilters);
            this.gbCReportFilters.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbCReportFilters.Location = new System.Drawing.Point(785, 0);
            this.gbCReportFilters.Name = "gbCReportFilters";
            this.gbCReportFilters.Size = new System.Drawing.Size(212, 358);
            this.gbCReportFilters.TabIndex = 13;
            this.gbCReportFilters.TabStop = false;
            this.gbCReportFilters.Text = "Report Filters";
            // 
            // cboGenerateCReport
            // 
            this.cboGenerateCReport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cboGenerateCReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cboGenerateCReport.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGenerateCReport.Location = new System.Drawing.Point(3, 315);
            this.cboGenerateCReport.Name = "cboGenerateCReport";
            this.cboGenerateCReport.Size = new System.Drawing.Size(206, 40);
            this.cboGenerateCReport.TabIndex = 12;
            this.cboGenerateCReport.Text = "Generate Report";
            this.cboGenerateCReport.UseVisualStyleBackColor = false;
            this.cboGenerateCReport.Click += new System.EventHandler(this.cboGenerateCReport_Click);
            // 
            // pnlCReportFilters
            // 
            this.pnlCReportFilters.AutoScroll = true;
            this.pnlCReportFilters.Location = new System.Drawing.Point(3, 19);
            this.pnlCReportFilters.Name = "pnlCReportFilters";
            this.pnlCReportFilters.Size = new System.Drawing.Size(206, 243);
            this.pnlCReportFilters.TabIndex = 2;
            // 
            // cboCustomReport
            // 
            this.cboCustomReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCustomReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomReport.FormattingEnabled = true;
            this.cboCustomReport.Location = new System.Drawing.Point(113, 38);
            this.cboCustomReport.Name = "cboCustomReport";
            this.cboCustomReport.Size = new System.Drawing.Size(540, 28);
            this.cboCustomReport.TabIndex = 1;
            this.cboCustomReport.SelectedIndexChanged += new System.EventHandler(this.cboCustomReport_SelectedIndexChanged);
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.Location = new System.Drawing.Point(20, 46);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(98, 20);
            this.label149.TabIndex = 0;
            this.label149.Text = "Select Report";
            // 
            // spCD4s
            // 
            this.spCD4s.Controls.Add(this.lblCD4Cuttoff);
            this.spCD4s.Controls.Add(this.txtCD4);
            this.spCD4s.Dock = System.Windows.Forms.DockStyle.Top;
            this.spCD4s.Location = new System.Drawing.Point(0, 5);
            this.spCD4s.Name = "spCD4s";
            this.spCD4s.Size = new System.Drawing.Size(1005, 26);
            this.spCD4s.TabIndex = 4;
            // 
            // lblCD4Cuttoff
            // 
            this.lblCD4Cuttoff.AutoSize = true;
            this.lblCD4Cuttoff.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCD4Cuttoff.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCD4Cuttoff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCD4Cuttoff.Location = new System.Drawing.Point(824, 0);
            this.lblCD4Cuttoff.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblCD4Cuttoff.Name = "lblCD4Cuttoff";
            this.lblCD4Cuttoff.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblCD4Cuttoff.Size = new System.Drawing.Size(149, 21);
            this.lblCD4Cuttoff.TabIndex = 8;
            this.lblCD4Cuttoff.Text = "CD4 Cutoff For ART:";
            this.lblCD4Cuttoff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCD4
            // 
            this.txtCD4.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtCD4.Location = new System.Drawing.Point(973, 0);
            this.txtCD4.Name = "txtCD4";
            this.txtCD4.Size = new System.Drawing.Size(32, 27);
            this.txtCD4.TabIndex = 9;
            this.txtCD4.Text = "500";
            // 
            // tpClinical
            // 
            this.tpClinical.BackColor = System.Drawing.Color.Transparent;
            this.tpClinical.Controls.Add(this.spcClinicalTab);
            this.tpClinical.Location = new System.Drawing.Point(4, 29);
            this.tpClinical.Margin = new System.Windows.Forms.Padding(0);
            this.tpClinical.Name = "tpClinical";
            this.tpClinical.Size = new System.Drawing.Size(1291, 422);
            this.tpClinical.TabIndex = 0;
            this.tpClinical.Text = "Clinical";
            // 
            // spcClinicalTab
            // 
            this.spcClinicalTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcClinicalTab.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcClinicalTab.IsSplitterFixed = true;
            this.spcClinicalTab.Location = new System.Drawing.Point(0, 0);
            this.spcClinicalTab.Name = "spcClinicalTab";
            // 
            // spcClinicalTab.Panel1
            // 
            this.spcClinicalTab.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.spcClinicalTab.Panel1.Controls.Add(this.lstClinical);
            // 
            // spcClinicalTab.Panel2
            // 
            this.spcClinicalTab.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spcClinicalTab.Panel2.Controls.Add(this.dgvClinical);
            this.spcClinicalTab.Panel2.Controls.Add(this.pnlClinical);
            this.spcClinicalTab.Size = new System.Drawing.Size(1291, 422);
            this.spcClinicalTab.SplitterDistance = 300;
            this.spcClinicalTab.SplitterWidth = 1;
            this.spcClinicalTab.TabIndex = 2;
            // 
            // lstClinical
            // 
            this.lstClinical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.lstClinical.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstClinical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstClinical.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstClinical.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lstClinical.FormattingEnabled = true;
            this.lstClinical.ItemHeight = 21;
            this.lstClinical.Location = new System.Drawing.Point(0, 0);
            this.lstClinical.Name = "lstClinical";
            this.lstClinical.Size = new System.Drawing.Size(300, 422);
            this.lstClinical.TabIndex = 0;
            this.lstClinical.SelectedIndexChanged += new System.EventHandler(this.lstClinical_SelectedIndexChanged);
            // 
            // dgvClinical
            // 
            this.dgvClinical.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvClinical.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvClinical.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClinical.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvClinical.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClinical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClinical.Location = new System.Drawing.Point(0, 32);
            this.dgvClinical.Name = "dgvClinical";
            this.dgvClinical.Size = new System.Drawing.Size(990, 390);
            this.dgvClinical.TabIndex = 3;
            this.dgvClinical.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClinical_CellContentClick);
            // 
            // pnlClinical
            // 
            this.pnlClinical.BackColor = System.Drawing.Color.Transparent;
            this.pnlClinical.Controls.Add(this.cboClinical);
            this.pnlClinical.Controls.Add(this.cmdClinical);
            this.pnlClinical.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClinical.Location = new System.Drawing.Point(0, 0);
            this.pnlClinical.Name = "pnlClinical";
            this.pnlClinical.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.pnlClinical.Size = new System.Drawing.Size(990, 32);
            this.pnlClinical.TabIndex = 2;
            // 
            // cboClinical
            // 
            this.cboClinical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboClinical.FormattingEnabled = true;
            this.cboClinical.Location = new System.Drawing.Point(0, 5);
            this.cboClinical.Name = "cboClinical";
            this.cboClinical.Size = new System.Drawing.Size(940, 28);
            this.cboClinical.TabIndex = 0;
            this.cboClinical.SelectedIndexChanged += new System.EventHandler(this.cboClinical_SelectedIndexChanged);
            // 
            // cmdClinical
            // 
            this.cmdClinical.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdClinical.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClinical.Location = new System.Drawing.Point(940, 5);
            this.cmdClinical.Name = "cmdClinical";
            this.cmdClinical.Size = new System.Drawing.Size(50, 24);
            this.cmdClinical.TabIndex = 1;
            this.cmdClinical.Text = "Run";
            this.cmdClinical.UseVisualStyleBackColor = true;
            this.cmdClinical.Click += new System.EventHandler(this.cmdClinical_Click);
            // 
            // tpComparisons
            // 
            this.tpComparisons.BackColor = System.Drawing.Color.Transparent;
            this.tpComparisons.Controls.Add(this.lblRComparisons);
            this.tpComparisons.Controls.Add(this.spcComparisonsTab);
            this.tpComparisons.Location = new System.Drawing.Point(4, 29);
            this.tpComparisons.Margin = new System.Windows.Forms.Padding(0);
            this.tpComparisons.Name = "tpComparisons";
            this.tpComparisons.Size = new System.Drawing.Size(1291, 422);
            this.tpComparisons.TabIndex = 3;
            this.tpComparisons.Text = "Comparisons";
            // 
            // lblRComparisons
            // 
            this.lblRComparisons.AutoSize = true;
            this.lblRComparisons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.lblRComparisons.Location = new System.Drawing.Point(924, 18);
            this.lblRComparisons.Name = "lblRComparisons";
            this.lblRComparisons.Size = new System.Drawing.Size(0, 20);
            this.lblRComparisons.TabIndex = 4;
            // 
            // spcComparisonsTab
            // 
            this.spcComparisonsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcComparisonsTab.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcComparisonsTab.IsSplitterFixed = true;
            this.spcComparisonsTab.Location = new System.Drawing.Point(0, 0);
            this.spcComparisonsTab.Margin = new System.Windows.Forms.Padding(0);
            this.spcComparisonsTab.Name = "spcComparisonsTab";
            // 
            // spcComparisonsTab.Panel1
            // 
            this.spcComparisonsTab.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.spcComparisonsTab.Panel1.Controls.Add(this.lstComparisons);
            // 
            // spcComparisonsTab.Panel2
            // 
            this.spcComparisonsTab.Panel2.Controls.Add(this.dgvComparisons);
            this.spcComparisonsTab.Panel2.Controls.Add(this.pnlComparisons);
            this.spcComparisonsTab.Size = new System.Drawing.Size(1291, 422);
            this.spcComparisonsTab.SplitterDistance = 300;
            this.spcComparisonsTab.SplitterWidth = 1;
            this.spcComparisonsTab.TabIndex = 2;
            // 
            // lstComparisons
            // 
            this.lstComparisons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.lstComparisons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstComparisons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstComparisons.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstComparisons.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lstComparisons.FormattingEnabled = true;
            this.lstComparisons.ItemHeight = 21;
            this.lstComparisons.Location = new System.Drawing.Point(0, 0);
            this.lstComparisons.Name = "lstComparisons";
            this.lstComparisons.Size = new System.Drawing.Size(300, 422);
            this.lstComparisons.TabIndex = 0;
            this.lstComparisons.SelectedIndexChanged += new System.EventHandler(this.lstComparisons_SelectedIndexChanged);
            // 
            // dgvComparisons
            // 
            this.dgvComparisons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvComparisons.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvComparisons.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvComparisons.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvComparisons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComparisons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComparisons.Location = new System.Drawing.Point(0, 32);
            this.dgvComparisons.Name = "dgvComparisons";
            this.dgvComparisons.RowHeadersWidth = 20;
            this.dgvComparisons.Size = new System.Drawing.Size(990, 390);
            this.dgvComparisons.TabIndex = 3;
            this.dgvComparisons.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComparisons_CellContentClick);
            // 
            // pnlComparisons
            // 
            this.pnlComparisons.Controls.Add(this.cboComparisons);
            this.pnlComparisons.Controls.Add(this.cmdCmp);
            this.pnlComparisons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComparisons.Location = new System.Drawing.Point(0, 0);
            this.pnlComparisons.Name = "pnlComparisons";
            this.pnlComparisons.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.pnlComparisons.Size = new System.Drawing.Size(990, 32);
            this.pnlComparisons.TabIndex = 2;
            // 
            // cboComparisons
            // 
            this.cboComparisons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboComparisons.FormattingEnabled = true;
            this.cboComparisons.Location = new System.Drawing.Point(0, 5);
            this.cboComparisons.Name = "cboComparisons";
            this.cboComparisons.Size = new System.Drawing.Size(940, 28);
            this.cboComparisons.TabIndex = 0;
            this.cboComparisons.SelectedIndexChanged += new System.EventHandler(this.cboComparisons_SelectedIndexChanged);
            // 
            // cmdCmp
            // 
            this.cmdCmp.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdCmp.Location = new System.Drawing.Point(940, 5);
            this.cmdCmp.Name = "cmdCmp";
            this.cmdCmp.Size = new System.Drawing.Size(50, 24);
            this.cmdCmp.TabIndex = 1;
            this.cmdCmp.Text = "Run";
            this.cmdCmp.UseVisualStyleBackColor = true;
            this.cmdCmp.Click += new System.EventHandler(this.cmdCmp_Click);
            // 
            // tpVals
            // 
            this.tpVals.BackColor = System.Drawing.Color.Transparent;
            this.tpVals.Controls.Add(this.spcValidationsTab);
            this.tpVals.Location = new System.Drawing.Point(4, 29);
            this.tpVals.Margin = new System.Windows.Forms.Padding(0);
            this.tpVals.Name = "tpVals";
            this.tpVals.Size = new System.Drawing.Size(1291, 422);
            this.tpVals.TabIndex = 2;
            this.tpVals.Text = "Validations";
            // 
            // spcValidationsTab
            // 
            this.spcValidationsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcValidationsTab.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcValidationsTab.IsSplitterFixed = true;
            this.spcValidationsTab.Location = new System.Drawing.Point(0, 0);
            this.spcValidationsTab.Margin = new System.Windows.Forms.Padding(0);
            this.spcValidationsTab.Name = "spcValidationsTab";
            // 
            // spcValidationsTab.Panel1
            // 
            this.spcValidationsTab.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.spcValidationsTab.Panel1.Controls.Add(this.lstValidations);
            // 
            // spcValidationsTab.Panel2
            // 
            this.spcValidationsTab.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spcValidationsTab.Panel2.Controls.Add(this.dgvValidations);
            this.spcValidationsTab.Panel2.Controls.Add(this.panel6);
            this.spcValidationsTab.Size = new System.Drawing.Size(1291, 422);
            this.spcValidationsTab.SplitterDistance = 300;
            this.spcValidationsTab.SplitterWidth = 1;
            this.spcValidationsTab.TabIndex = 2;
            // 
            // lstValidations
            // 
            this.lstValidations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.lstValidations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstValidations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstValidations.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstValidations.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lstValidations.FormattingEnabled = true;
            this.lstValidations.ItemHeight = 21;
            this.lstValidations.Location = new System.Drawing.Point(0, 0);
            this.lstValidations.Name = "lstValidations";
            this.lstValidations.Size = new System.Drawing.Size(300, 422);
            this.lstValidations.TabIndex = 0;
            this.lstValidations.SelectedIndexChanged += new System.EventHandler(this.lstValidations_SelectedIndexChanged);
            // 
            // dgvValidations
            // 
            this.dgvValidations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvValidations.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvValidations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvValidations.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvValidations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValidations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValidations.Location = new System.Drawing.Point(0, 32);
            this.dgvValidations.Name = "dgvValidations";
            this.dgvValidations.RowHeadersWidth = 20;
            this.dgvValidations.Size = new System.Drawing.Size(990, 390);
            this.dgvValidations.TabIndex = 3;
            this.dgvValidations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvValidations_CellContentClick);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cboValidations);
            this.panel6.Controls.Add(this.cmdVals);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.panel6.Size = new System.Drawing.Size(990, 32);
            this.panel6.TabIndex = 2;
            // 
            // cboValidations
            // 
            this.cboValidations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboValidations.FormattingEnabled = true;
            this.cboValidations.Location = new System.Drawing.Point(0, 5);
            this.cboValidations.Name = "cboValidations";
            this.cboValidations.Size = new System.Drawing.Size(940, 28);
            this.cboValidations.TabIndex = 0;
            this.cboValidations.SelectedIndexChanged += new System.EventHandler(this.cboValidations_SelectedIndexChanged);
            // 
            // cmdVals
            // 
            this.cmdVals.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdVals.Location = new System.Drawing.Point(940, 5);
            this.cmdVals.Name = "cmdVals";
            this.cmdVals.Size = new System.Drawing.Size(50, 24);
            this.cmdVals.TabIndex = 1;
            this.cmdVals.Text = "Run ";
            this.cmdVals.UseVisualStyleBackColor = true;
            this.cmdVals.Click += new System.EventHandler(this.cmdVals_Click);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpReports);
            this.tcMain.Controls.Add(this.tpQueries);
            this.tcMain.Controls.Add(this.tpNewReports);
            this.tcMain.Controls.Add(this.tpEMRAccess);
            this.tcMain.Controls.Add(this.tpSMS);
            this.tcMain.Controls.Add(this.tpHelp);
            this.tcMain.Controls.Add(this.tpForum);
            this.tcMain.Controls.Add(this.tpAdmin);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Margin = new System.Windows.Forms.Padding(0);
            this.tcMain.Name = "tcMain";
            this.tcMain.Padding = new System.Drawing.Point(0, 0);
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1307, 549);
            this.tcMain.TabIndex = 0;
            this.tcMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tcMain_DrawItem);
            this.tcMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcMain_Selected);
            // 
            // tpNewReports
            // 
            this.tpNewReports.Location = new System.Drawing.Point(4, 29);
            this.tpNewReports.Name = "tpNewReports";
            this.tpNewReports.Size = new System.Drawing.Size(1299, 516);
            this.tpNewReports.TabIndex = 11;
            this.tpNewReports.Text = "Reports+";
            this.tpNewReports.UseVisualStyleBackColor = true;
            // 
            // tpEMRAccess
            // 
            this.tpEMRAccess.Location = new System.Drawing.Point(4, 29);
            this.tpEMRAccess.Name = "tpEMRAccess";
            this.tpEMRAccess.Size = new System.Drawing.Size(1299, 516);
            this.tpEMRAccess.TabIndex = 9;
            this.tpEMRAccess.Text = "EMR";
            this.tpEMRAccess.UseVisualStyleBackColor = true;
            // 
            // tpForum
            // 
            this.tpForum.Location = new System.Drawing.Point(4, 29);
            this.tpForum.Name = "tpForum";
            this.tpForum.Size = new System.Drawing.Size(1299, 516);
            this.tpForum.TabIndex = 10;
            this.tpForum.Text = "Forum";
            this.tpForum.UseVisualStyleBackColor = true;
            // 
            // panel59
            // 
            this.panel59.Location = new System.Drawing.Point(0, 0);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(200, 100);
            this.panel59.TabIndex = 0;
            // 
            // cboMainLanguage
            // 
            this.cboMainLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMainLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMainLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMainLanguage.FormattingEnabled = true;
            this.cboMainLanguage.Location = new System.Drawing.Point(1646, 1);
            this.cboMainLanguage.Name = "cboMainLanguage";
            this.cboMainLanguage.Size = new System.Drawing.Size(121, 28);
            this.cboMainLanguage.TabIndex = 1;
            this.cboMainLanguage.SelectedIndexChanged += new System.EventHandler(this.cboMainLanguage_SelectedIndexChanged);
            // 
            // label148
            // 
            this.label148.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label148.AutoSize = true;
            this.label148.BackColor = System.Drawing.SystemColors.Window;
            this.label148.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label148.Location = new System.Drawing.Point(1577, 4);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(74, 20);
            this.label148.TabIndex = 2;
            this.label148.Text = "Language";
            // 
            // spcMain
            // 
            this.spcMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcMain.IsSplitterFixed = true;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Margin = new System.Windows.Forms.Padding(0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.tcMain);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.spcMain.Panel2.Controls.Add(this.pnlVersionLabels);
            this.spcMain.Panel2.Controls.Add(this.lblNotify);
            this.spcMain.Panel2.Controls.Add(this.picProgress);
            this.spcMain.Panel2MinSize = 32;
            this.spcMain.Size = new System.Drawing.Size(1307, 582);
            this.spcMain.SplitterDistance = 549;
            this.spcMain.SplitterWidth = 1;
            this.spcMain.TabIndex = 3;
            // 
            // lblNotify
            // 
            this.lblNotify.AutoSize = true;
            this.lblNotify.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotify.ForeColor = System.Drawing.Color.White;
            this.lblNotify.Location = new System.Drawing.Point(46, 11);
            this.lblNotify.MaximumSize = new System.Drawing.Size(500, 20);
            this.lblNotify.MinimumSize = new System.Drawing.Size(10, 0);
            this.lblNotify.Name = "lblNotify";
            this.lblNotify.Size = new System.Drawing.Size(10, 20);
            this.lblNotify.TabIndex = 1;
            // 
            // picProgress
            // 
            this.picProgress.Location = new System.Drawing.Point(8, 1);
            this.picProgress.Name = "picProgress";
            this.picProgress.Size = new System.Drawing.Size(32, 32);
            this.picProgress.TabIndex = 0;
            this.picProgress.TabStop = false;
            // 
            // pictureBox31
            // 
            this.pictureBox31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.pictureBox31.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox31.Location = new System.Drawing.Point(3, 3);
            this.pictureBox31.Name = "pictureBox31";
            this.pictureBox31.Size = new System.Drawing.Size(980, 40);
            this.pictureBox31.TabIndex = 25;
            this.pictureBox31.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1307, 582);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.label148);
            this.Controls.Add(this.cboMainLanguage);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 558);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " IQTools ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            spCommon.Panel1.ResumeLayout(false);
            spCommon.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(spCommon)).EndInit();
            spCommon.ResumeLayout(false);
            this.tlpCommon.ResumeLayout(false);
            this.tlpCommon.PerformLayout();
            this.flpCohortReport.ResumeLayout(false);
            this.flpCohortReport.PerformLayout();
            this.panel63.ResumeLayout(false);
            this.gbCommon.ResumeLayout(false);
            this.gbCommon.PerformLayout();
            this.panel46.ResumeLayout(false);
            this.tpHelp.ResumeLayout(false);
            this.spcHelp.Panel1.ResumeLayout(false);
            this.spcHelp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcHelp)).EndInit();
            this.spcHelp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            this.spcHelpTab.Panel1.ResumeLayout(false);
            this.spcHelpTab.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcHelpTab)).EndInit();
            this.spcHelpTab.ResumeLayout(false);
            this.pnlVersionLabels.ResumeLayout(false);
            this.pnlVersionLabels.PerformLayout();
            this.tpAdmin.ResumeLayout(false);
            this.spcAdminTab.Panel1.ResumeLayout(false);
            this.spcAdminTab.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcAdminTab)).EndInit();
            this.spcAdminTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAdmin)).EndInit();
            this.tcAdmin.ResumeLayout(false);
            this.tpCats.ResumeLayout(false);
            this.panel58.ResumeLayout(false);
            this.spcQueryCategories.Panel1.ResumeLayout(false);
            this.spcQueryCategories.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcQueryCategories)).EndInit();
            this.spcQueryCategories.ResumeLayout(false);
            this.spcQueryCategory.Panel1.ResumeLayout(false);
            this.spcQueryCategory.Panel1.PerformLayout();
            this.spcQueryCategory.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcQueryCategory)).EndInit();
            this.spcQueryCategory.ResumeLayout(false);
            this.pnlQueryCategories.ResumeLayout(false);
            this.pnlQueryCategories.PerformLayout();
            this.tpEMaps.ResumeLayout(false);
            this.spcExcelMapping.Panel1.ResumeLayout(false);
            this.spcExcelMapping.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcExcelMapping)).EndInit();
            this.spcExcelMapping.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.pnlExcelMapping.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgXls)).EndInit();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.tpUsers.ResumeLayout(false);
            this.spcUsers.Panel1.ResumeLayout(false);
            this.spcUsers.Panel1.PerformLayout();
            this.spcUsers.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcUsers)).EndInit();
            this.spcUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tpCReports.ResumeLayout(false);
            this.tpCReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCReports)).EndInit();
            this.tpDataConnection.ResumeLayout(false);
            this.pnlDataConnections.ResumeLayout(false);
            this.pnlDataConnections.PerformLayout();
            this.tpReports.ResumeLayout(false);
            this.spcHome.Panel1.ResumeLayout(false);
            this.spcHome.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcHome)).EndInit();
            this.spcHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.tcReports.ResumeLayout(false);
            this.tpARTAdh.ResumeLayout(false);
            this.spcHomeTab1.Panel1.ResumeLayout(false);
            this.spcHomeTab1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcHomeTab1)).EndInit();
            this.spcHomeTab1.ResumeLayout(false);
            this.pnlHome.ResumeLayout(false);
            this.gbART.ResumeLayout(false);
            this.gbART.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdherence)).EndInit();
            this.tpDonor.ResumeLayout(false);
            this.spcHomeTab2.Panel1.ResumeLayout(false);
            this.spcHomeTab2.Panel1.PerformLayout();
            this.spcHomeTab2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcHomeTab2)).EndInit();
            this.spcHomeTab2.ResumeLayout(false);
            this.pnlCustomDates.ResumeLayout(false);
            this.pnlCustomDates.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.tcDonors.ResumeLayout(false);
            this.tpCommon.ResumeLayout(false);
            this.tpCountry.ResumeLayout(false);
            this.tcCountries.ResumeLayout(false);
            this.tpKe.ResumeLayout(false);
            this.SpKenya.Panel1.ResumeLayout(false);
            this.SpKenya.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpKenya)).EndInit();
            this.SpKenya.ResumeLayout(false);
            this.tlp_KeReports.ResumeLayout(false);
            this.tlp_KeReports.PerformLayout();
            this.flp_PS.ResumeLayout(false);
            this.flp_PS.PerformLayout();
            this.gbKenya.ResumeLayout(false);
            this.gbKenya.PerformLayout();
            this.tpUg.ResumeLayout(false);
            this.spUganda.Panel1.ResumeLayout(false);
            this.spUganda.Panel1.PerformLayout();
            this.spUganda.Panel2.ResumeLayout(false);
            this.spUganda.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spUganda)).EndInit();
            this.spUganda.ResumeLayout(false);
            this.gbUganda.ResumeLayout(false);
            this.gbUganda.PerformLayout();
            this.TpTz.ResumeLayout(false);
            this.spTanzania.Panel1.ResumeLayout(false);
            this.spTanzania.Panel1.PerformLayout();
            this.spTanzania.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spTanzania)).EndInit();
            this.spTanzania.ResumeLayout(false);
            this.gbTZ.ResumeLayout(false);
            this.gbTZ.PerformLayout();
            this.tpNg.ResumeLayout(false);
            this.spNigeria.Panel1.ResumeLayout(false);
            this.spNigeria.Panel1.PerformLayout();
            this.spNigeria.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spNigeria)).EndInit();
            this.spNigeria.ResumeLayout(false);
            this.gbNigeria.ResumeLayout(false);
            this.gbNigeria.PerformLayout();
            this.tpHt.ResumeLayout(false);
            this.spHaiti.Panel1.ResumeLayout(false);
            this.spHaiti.Panel1.PerformLayout();
            this.spHaiti.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spHaiti)).EndInit();
            this.spHaiti.ResumeLayout(false);
            this.gbHaiti.ResumeLayout(false);
            this.gbHaiti.PerformLayout();
            this.tpDonorCustomReport.ResumeLayout(false);
            this.tpDonorCustomReport.PerformLayout();
            this.gbCReportFilters.ResumeLayout(false);
            this.spCD4s.ResumeLayout(false);
            this.spCD4s.PerformLayout();
            this.tpClinical.ResumeLayout(false);
            this.spcClinicalTab.Panel1.ResumeLayout(false);
            this.spcClinicalTab.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcClinicalTab)).EndInit();
            this.spcClinicalTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinical)).EndInit();
            this.pnlClinical.ResumeLayout(false);
            this.tpComparisons.ResumeLayout(false);
            this.tpComparisons.PerformLayout();
            this.spcComparisonsTab.Panel1.ResumeLayout(false);
            this.spcComparisonsTab.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcComparisonsTab)).EndInit();
            this.spcComparisonsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparisons)).EndInit();
            this.pnlComparisons.ResumeLayout(false);
            this.tpVals.ResumeLayout(false);
            this.spcValidationsTab.Panel1.ResumeLayout(false);
            this.spcValidationsTab.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcValidationsTab)).EndInit();
            this.spcValidationsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidations)).EndInit();
            this.panel6.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            this.spcMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox31)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private TabPage tpHelp;
    private TabPage tpAdmin;
    private TabControl tcAdmin;
    private TabPage tpEMaps;
    private TabPage tpUsers;
    private SplitContainer spcUsers;
    private Button cmdUpdateUser;
    private TextBox txtIQName;
    private TextBox txtFName;
    private ComboBox cboUserGroup;
    private CheckBox chkUserActive;
    private Label label41;
    private Label label40;
    private Label label36;
    private DataGridView dgvUsers;
    private TabPage tpSMS;
    private TabPage tpQueries;
    private TabPage tpReports;
    private SplitContainer spcExcelMapping;
    private Panel pnlExcelMapping;
    private DataGridView dgXls;
    private Panel panel19;
    private TextBox txtEDesc;
    private Panel panel29;
    private ListBox lstQueries;
    private Panel panel28;
    private Label lblExcelReport;
    private ComboBox cboReports;
    private Panel panel30;
    private ListBox lstCategories;
    private Panel panel31;
    private Button cmdEMap;
    private Label lblDBVersion;
    private TextBox txtDate;
    private TextBox txtPWord;
    private Label lblPWord;
    private TextBox txtCPWord;
    private Label lblCPWord;
    private TextBox txtLName;
    private Label label42;
    private Label lblAddUser;
    private TabPage tpCats;
    private SplitContainer spcQueryCategories;
    private SplitContainer spcQueryCategory;
    private CheckBox chkCatActive;
    private CheckBox chkExcel;
    private TextBox txtCats;
    private Label lblQueryCategory;
    private ListBox lstSubCats;
    private ListBox lstCats;
    private Button cmdASC;
    private TextBox txtSbCats;
    private Label lblQuerySubCategory;
    private Panel pnlQueryCategories;
    private Label lblQuerySubCategories;
    private Panel panel58;
    private Panel panel59;
    private Label lblNewCat;
    private Button cmdSQC;   
    private PictureBox pictureBox31;   
    private FolderBrowserDialog fbd;
    private ComboBox cboMainLanguage;
    private Label label148;
    private TabPage tpCReports;
    private Button cmdCReportTemplate;
    private TextBox txtCReportTemplate;
    private Label lblExcelTemplate;
    private Button cmdCReportNew;
    private Label lblReportID;
    private Label lblCReportId;
    private CheckBox chkDeleteCReport;
    private ListView lstCReportsFilter;
    private ColumnHeader columnHeader19;
    private ColumnHeader columnHeader20;
    private Button cmdCReportSave;
    private ComboBox cboCReportFilterType;
    private Label lblFilterType;
    private TextBox txtCReportDesc;
    private Label lblReportDescription;
    private DataGridView dgvCReports;
    private TextBox txtCReportFilterName;
    private Button cmdAddRemoveFilter;
    private Label lblFilterName;
    private ComboBox cboCReportCategory;
    private Label lblCustomCategory;
    private TextBox txtCReportName;
    private Label lblReportName;
    private Label lblAppVersion;
    private TextBox txtVersion;
    private SplitContainer spcMain;
    public PictureBox picProgress;
    public Label lblNotify;
    private TabPage tpForum;
    public TabControl tcMain;
    public TabPage tpEMRAccess;
    private TabPage tpDataConnection;
    private Panel pnlDataConnections;
    private Button cmdPMMS;
    private Button cmdDBLoad;
    private Label Database;
    private ComboBox cboDBase;
    private Label Password;
    private TextBox txtPWD;
    private Label Username;
    private TextBox txtUID;
    private Label lblDatabaseType;
    private ComboBox cboServerType;
    private ProgressBar prbLoad;
    private TabPage tpNewReports;
    private SplitContainer spcHome;
    private TabControl tcReports;
    private TabPage tpARTAdh;
    private SplitContainer spcHomeTab1;
    private GroupBox gbART;
    private TextBox TxtMA;
    private Label lblMA;
    private RadioButton OptMA;
    private RadioButton optART;
    private TextBox txtHCD4;
    private TextBox txtLCD4;
    private Label label85;
    private Label label67;
    private RadioButton optNoARTNoCD4;
    private RadioButton optNoARTCD4XY;
    private DateTimePicker dtpAllApp;
    private RadioButton optAllApp;
    private Label label84;
    private DateTimePicker dtpMAP;
    private RadioButton optMAP;
    private Button cmdART;
    private DataGridView dgvAdherence;
    private TabPage tpDonor;
    private SplitContainer spcHomeTab2;
    private ListBox lstPeriods;
    private TextBox txtYear;
    private TextBox txtQStart;
    private Panel pnlCustomDates;
    private ComboBox cboMonths;
    private DateTimePicker txtSDate;
    private Label lblStartDate;
    private Label lblEndDate;
    private DateTimePicker txtEDate;
    private ComboBox cboPeriod;
    private Panel panel22;
    private TabControl tcDonors;
    private TabPage tpCommon;
    private TableLayoutPanel tlpCommon;
    private RadioButton OptAR;
    private RadioButton OptCDC;
    private RadioButton optARTCohort;
    private FlowLayoutPanel flpCohortReport;
    private Label lblCohortReport;
    private ComboBox cboCohortFollowUp;
    private CheckBox chkCohortReportLL;
    private RadioButton optHIVQual;
    private Panel panel63;
    private GroupBox gbCommon;
    private ComboBox cboDonorCCC;
    private CheckBox chkDonorCCC;
    private ComboBox cboDonorLPTF;
    private CheckBox chkDonorLPTF;
    private RadioButton OptDonorAll;
    private RadioButton OptDonorLPTF;
    private Panel panel46;
    private ProgressBar pgBCommon;
    private Button cmdCReport;
    private TabPage tpCountry;
    private TabControl tcCountries;
    private TabPage tpKe;
    private SplitContainer SpKenya;
    private TableLayoutPanel tlp_KeReports;
    private RadioButton optKe_FMAP;
    private RadioButton OptKe_MoH711;
    private RadioButton optKe_MoH731;
    private RadioButton OptKe_RC;
    private RadioButton OptKe_Lwak;
    private CheckBox chk_RCLineLists;
    private RadioButton optKe_MCHC;
    private RadioButton optKE_PS;
    private FlowLayoutPanel flp_PS;
    private Label lblPatientID;
    private TextBox txtPatientID;
    private Button cmdMultipleSummaries;
    private RadioButton optKe_TBC;
    private RadioButton optKe_HEICA;
    private RadioButton optKe_CDRR;
    private RadioButton optKe_MoH361B;
    private RadioButton optKe_Defaulter;
    private RadioButton optKe_PwP;
    private RadioButton optKe_TBRegister;
    private RadioButton optke_OIDrugs;
    private RadioButton optKe_MoH717;
    private RadioButton optHEIRegister;
    private RadioButton optKe_MoH705A;
    private RadioButton optKe_MoH705B;
    private CheckBox chk_KESendToDHIS;
    private GroupBox gbKenya;
    private ComboBox CboKECCC;
    private CheckBox ChkKECCC;
    private ComboBox cboKELPTF;
    private CheckBox ChkKELPTF;
    private RadioButton OptKEAll;
    private RadioButton OptKELPTF;
    private ProgressBar prBKeReports;
    private Button CmdKeReports;
    private TabPage tpUg;
    private SplitContainer spUganda;
    private RadioButton OptUg_MoH;
    private RadioButton optUg_CMR;
    private ProgressBar prBUgandaReports;
    private Button cmdUgReports;
    private GroupBox gbUganda;
    private ComboBox CboUgCCC;
    private CheckBox chkUgCCC;
    private ComboBox cboUgLPTF;
    private CheckBox chkUgLPTF;
    private RadioButton optUgAll;
    private RadioButton optUgLPTF;
    private TextBox txtUgNumDays;
    private Label LblNumDays;
    private TabPage TpTz;
    private SplitContainer spTanzania;
    private RadioButton optCDCTanzania;
    private RadioButton optTzCSR;
    private GroupBox gbTZ;
    private ComboBox cboTzCCC;
    private CheckBox chkTzCCC;
    private ComboBox cboTzLPTF;
    private CheckBox chkTzLPTF;
    private RadioButton optTzAll;
    private RadioButton optTzLPTF;
    private ProgressBar prBTZReports;
    private Button cmdTzDonor;
    private TabPage tpNg;
    private SplitContainer spNigeria;
    private RadioButton optMonthlyNigeria;
    private RadioButton optCDCNigeria;
    private ProgressBar prBNigeriaReports;
    private Button cmdNigeriaDonor;
    private GroupBox gbNigeria;
    private ComboBox cboNgCCC;
    private CheckBox chkNgCCC;
    private ComboBox cboNgLPTF;
    private CheckBox chkNgLPTF;
    private RadioButton optNgAll;
    private RadioButton optNgLPTF;
    private TabPage tpHt;
    private SplitContainer spHaiti;
    private RadioButton optHt_Monthly;
    private ProgressBar prBHaitiReports;
    private Button cmdHtReport;
    private GroupBox gbHaiti;
    private ComboBox cboHt_CCC;
    private CheckBox chkHt_CCC;
    private CheckBox chkHt_LPTF;
    private ComboBox cboHt_LPTF;
    private RadioButton optHt_LPTF;
    private RadioButton optHt_All;
    private TabPage tpDonorCustomReport;
    private GroupBox gbCReportFilters;
    private Button cboGenerateCReport;
    private Panel pnlCReportFilters;
    private ComboBox cboCustomReport;
    private Label label149;
    private Panel spCD4s;
    private Label lblCD4Cuttoff;
    private TextBox txtCD4;
    private TabPage tpClinical;
    private SplitContainer spcClinicalTab;
    private ListBox lstClinical;
    private DataGridView dgvClinical;
    private Panel pnlClinical;
    private ComboBox cboClinical;
    private Button cmdClinical;
    private TabPage tpComparisons;
    private Label lblRComparisons;
    private SplitContainer spcComparisonsTab;
    private ListBox lstComparisons;
    private DataGridView dgvComparisons;
    private Panel pnlComparisons;
    private ComboBox cboComparisons;
    private Button cmdCmp;
    private TabPage tpVals;
    private SplitContainer spcValidationsTab;
    private ListBox lstValidations;
    private DataGridView dgvValidations;
    private Panel panel6;
    private ComboBox cboValidations;
    private Button cmdVals;
    private PictureBox picHome;
    private Panel pnlHome;
    private RadioButton optVL;
    private Label lblLowVL;
    private TextBox txtLowVL;
    private RadioButton optVLDetect;
    private SplitContainer spcHelpTab;
    private ListBox lstDocuments;
    private WebBrowser webHelp;
    private SplitContainer spcHelp;
    private PictureBox picHelp;
    private Panel pnlVersionLabels;
    private OpenFileDialog ofdUtility;
    private SplitContainer spcAdminTab;
    private PictureBox picAdmin;
    private RadioButton optTzAPR;

  }
}

