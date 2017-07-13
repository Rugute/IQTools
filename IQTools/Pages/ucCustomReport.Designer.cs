namespace IQTools.Pages
{
    partial class ucCustomReport
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboReportGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCReportSave = new System.Windows.Forms.Button();
            this.dgvCReports = new System.Windows.Forms.DataGridView();
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
            this.cboCReportFilterType = new System.Windows.Forms.ComboBox();
            this.lblFilterType = new System.Windows.Forms.Label();
            this.txtCReportDesc = new System.Windows.Forms.TextBox();
            this.lblReportDescription = new System.Windows.Forms.Label();
            this.cmdAddRemoveFilter = new System.Windows.Forms.Button();
            this.lblFilterName = new System.Windows.Forms.Label();
            this.cboCReportCategory = new System.Windows.Forms.ComboBox();
            this.lblCustomCategory = new System.Windows.Forms.Label();
            this.txtCReportName = new System.Windows.Forms.TextBox();
            this.lblReportName = new System.Windows.Forms.Label();
            this.CboCReportFilterName = new System.Windows.Forms.ComboBox();
            this.Position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCReports)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CboCReportFilterName);
            this.panel1.Controls.Add(this.cboReportGroup);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmdCReportSave);
            this.panel1.Controls.Add(this.dgvCReports);
            this.panel1.Controls.Add(this.cmdCReportTemplate);
            this.panel1.Controls.Add(this.txtCReportTemplate);
            this.panel1.Controls.Add(this.lblExcelTemplate);
            this.panel1.Controls.Add(this.cmdCReportNew);
            this.panel1.Controls.Add(this.lblReportID);
            this.panel1.Controls.Add(this.lblCReportId);
            this.panel1.Controls.Add(this.chkDeleteCReport);
            this.panel1.Controls.Add(this.lstCReportsFilter);
            this.panel1.Controls.Add(this.cboCReportFilterType);
            this.panel1.Controls.Add(this.lblFilterType);
            this.panel1.Controls.Add(this.txtCReportDesc);
            this.panel1.Controls.Add(this.lblReportDescription);
            this.panel1.Controls.Add(this.cmdAddRemoveFilter);
            this.panel1.Controls.Add(this.lblFilterName);
            this.panel1.Controls.Add(this.cboCReportCategory);
            this.panel1.Controls.Add(this.lblCustomCategory);
            this.panel1.Controls.Add(this.txtCReportName);
            this.panel1.Controls.Add(this.lblReportName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 595);
            this.panel1.TabIndex = 0;
            // 
            // cboReportGroup
            // 
            this.cboReportGroup.FormattingEnabled = true;
            this.cboReportGroup.Location = new System.Drawing.Point(726, 128);
            this.cboReportGroup.Name = "cboReportGroup";
            this.cboReportGroup.Size = new System.Drawing.Size(230, 24);
            this.cboReportGroup.TabIndex = 44;
            this.cboReportGroup.SelectedIndexChanged += new System.EventHandler(this.cboReportGroup_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(593, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "Report Group";
            // 
            // cmdCReportSave
            // 
            this.cmdCReportSave.Location = new System.Drawing.Point(662, 198);
            this.cmdCReportSave.Name = "cmdCReportSave";
            this.cmdCReportSave.Size = new System.Drawing.Size(248, 57);
            this.cmdCReportSave.TabIndex = 42;
            this.cmdCReportSave.Text = "Save";
            this.cmdCReportSave.UseVisualStyleBackColor = true;
            this.cmdCReportSave.Click += new System.EventHandler(this.cmdCReportSave_Click);
            // 
            // dgvCReports
            // 
            this.dgvCReports.AllowUserToAddRows = false;
            this.dgvCReports.AllowUserToDeleteRows = false;
            this.dgvCReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCReports.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvCReports.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCReports.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvCReports.Location = new System.Drawing.Point(6, 261);
            this.dgvCReports.Name = "dgvCReports";
            this.dgvCReports.ReadOnly = true;
            this.dgvCReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCReports.Size = new System.Drawing.Size(1021, 331);
            this.dgvCReports.TabIndex = 41;
            this.dgvCReports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCReports_CellContentClick);
            // 
            // cmdCReportTemplate
            // 
            this.cmdCReportTemplate.Location = new System.Drawing.Point(419, 47);
            this.cmdCReportTemplate.Name = "cmdCReportTemplate";
            this.cmdCReportTemplate.Size = new System.Drawing.Size(49, 23);
            this.cmdCReportTemplate.TabIndex = 40;
            this.cmdCReportTemplate.Text = "...";
            this.cmdCReportTemplate.UseVisualStyleBackColor = true;
            this.cmdCReportTemplate.Click += new System.EventHandler(this.cmdCReportTemplate_Click);
            // 
            // txtCReportTemplate
            // 
            this.txtCReportTemplate.Location = new System.Drawing.Point(105, 48);
            this.txtCReportTemplate.Name = "txtCReportTemplate";
            this.txtCReportTemplate.ReadOnly = true;
            this.txtCReportTemplate.Size = new System.Drawing.Size(305, 22);
            this.txtCReportTemplate.TabIndex = 39;
            // 
            // lblExcelTemplate
            // 
            this.lblExcelTemplate.Location = new System.Drawing.Point(15, 44);
            this.lblExcelTemplate.Name = "lblExcelTemplate";
            this.lblExcelTemplate.Size = new System.Drawing.Size(84, 34);
            this.lblExcelTemplate.TabIndex = 38;
            this.lblExcelTemplate.Text = "Excel Report Template";
            // 
            // cmdCReportNew
            // 
            this.cmdCReportNew.Location = new System.Drawing.Point(176, 9);
            this.cmdCReportNew.Name = "cmdCReportNew";
            this.cmdCReportNew.Size = new System.Drawing.Size(51, 29);
            this.cmdCReportNew.TabIndex = 37;
            this.cmdCReportNew.Text = "New";
            this.cmdCReportNew.UseVisualStyleBackColor = true;
            this.cmdCReportNew.Click += new System.EventHandler(this.cmdCReportNew_Click);
            // 
            // lblReportID
            // 
            this.lblReportID.AutoSize = true;
            this.lblReportID.Location = new System.Drawing.Point(3, 16);
            this.lblReportID.Name = "lblReportID";
            this.lblReportID.Size = new System.Drawing.Size(68, 17);
            this.lblReportID.TabIndex = 36;
            this.lblReportID.Text = "Report ID";
            // 
            // lblCReportId
            // 
            this.lblCReportId.AutoSize = true;
            this.lblCReportId.Location = new System.Drawing.Point(93, 14);
            this.lblCReportId.Name = "lblCReportId";
            this.lblCReportId.Size = new System.Drawing.Size(16, 17);
            this.lblCReportId.TabIndex = 35;
            this.lblCReportId.Text = "0";
            // 
            // chkDeleteCReport
            // 
            this.chkDeleteCReport.AutoSize = true;
            this.chkDeleteCReport.Location = new System.Drawing.Point(451, 217);
            this.chkDeleteCReport.Name = "chkDeleteCReport";
            this.chkDeleteCReport.Size = new System.Drawing.Size(141, 21);
            this.chkDeleteCReport.TabIndex = 34;
            this.chkDeleteCReport.Text = "Inactivate  Report";
            this.chkDeleteCReport.UseVisualStyleBackColor = true;
            // 
            // lstCReportsFilter
            // 
            this.lstCReportsFilter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader19,
            this.columnHeader20,
            this.Position});
            this.lstCReportsFilter.FullRowSelect = true;
            this.lstCReportsFilter.GridLines = true;
            this.lstCReportsFilter.Location = new System.Drawing.Point(105, 158);
            this.lstCReportsFilter.MultiSelect = false;
            this.lstCReportsFilter.Name = "lstCReportsFilter";
            this.lstCReportsFilter.Size = new System.Drawing.Size(328, 97);
            this.lstCReportsFilter.TabIndex = 33;
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
            // cboCReportFilterType
            // 
            this.cboCReportFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCReportFilterType.FormattingEnabled = true;
            this.cboCReportFilterType.Items.AddRange(new object[] {
            "checkbox",
            "datehelper",
            "textbox"});
            this.cboCReportFilterType.Location = new System.Drawing.Point(298, 111);
            this.cboCReportFilterType.Name = "cboCReportFilterType";
            this.cboCReportFilterType.Size = new System.Drawing.Size(112, 24);
            this.cboCReportFilterType.TabIndex = 32;
            // 
            // lblFilterType
            // 
            this.lblFilterType.AutoSize = true;
            this.lblFilterType.Location = new System.Drawing.Point(228, 113);
            this.lblFilterType.Name = "lblFilterType";
            this.lblFilterType.Size = new System.Drawing.Size(75, 17);
            this.lblFilterType.TabIndex = 31;
            this.lblFilterType.Text = "Filter Type";
            // 
            // txtCReportDesc
            // 
            this.txtCReportDesc.Location = new System.Drawing.Point(725, 68);
            this.txtCReportDesc.Multiline = true;
            this.txtCReportDesc.Name = "txtCReportDesc";
            this.txtCReportDesc.Size = new System.Drawing.Size(232, 46);
            this.txtCReportDesc.TabIndex = 30;
            // 
            // lblReportDescription
            // 
            this.lblReportDescription.AutoSize = true;
            this.lblReportDescription.Location = new System.Drawing.Point(593, 68);
            this.lblReportDescription.Name = "lblReportDescription";
            this.lblReportDescription.Size = new System.Drawing.Size(101, 17);
            this.lblReportDescription.TabIndex = 29;
            this.lblReportDescription.Text = "Report Display";
            // 
            // cmdAddRemoveFilter
            // 
            this.cmdAddRemoveFilter.Location = new System.Drawing.Point(419, 111);
            this.cmdAddRemoveFilter.Name = "cmdAddRemoveFilter";
            this.cmdAddRemoveFilter.Size = new System.Drawing.Size(54, 23);
            this.cmdAddRemoveFilter.TabIndex = 27;
            this.cmdAddRemoveFilter.Text = "+";
            this.cmdAddRemoveFilter.UseVisualStyleBackColor = true;
            this.cmdAddRemoveFilter.Click += new System.EventHandler(this.cmdAddRemoveFilter_Click_1);
            // 
            // lblFilterName
            // 
            this.lblFilterName.AutoSize = true;
            this.lblFilterName.Location = new System.Drawing.Point(12, 113);
            this.lblFilterName.Name = "lblFilterName";
            this.lblFilterName.Size = new System.Drawing.Size(80, 17);
            this.lblFilterName.TabIndex = 26;
            this.lblFilterName.Text = "Filter Name";
            // 
            // cboCReportCategory
            // 
            this.cboCReportCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCReportCategory.FormattingEnabled = true;
            this.cboCReportCategory.Location = new System.Drawing.Point(725, 28);
            this.cboCReportCategory.Name = "cboCReportCategory";
            this.cboCReportCategory.Size = new System.Drawing.Size(230, 24);
            this.cboCReportCategory.TabIndex = 25;
            this.cboCReportCategory.SelectedIndexChanged += new System.EventHandler(this.cboCReportCategory_SelectedIndexChanged);
            // 
            // lblCustomCategory
            // 
            this.lblCustomCategory.AutoSize = true;
            this.lblCustomCategory.Location = new System.Drawing.Point(593, 28);
            this.lblCustomCategory.Name = "lblCustomCategory";
            this.lblCustomCategory.Size = new System.Drawing.Size(65, 17);
            this.lblCustomCategory.TabIndex = 24;
            this.lblCustomCategory.Text = "Category";
            // 
            // txtCReportName
            // 
            this.txtCReportName.Location = new System.Drawing.Point(105, 83);
            this.txtCReportName.Name = "txtCReportName";
            this.txtCReportName.Size = new System.Drawing.Size(368, 22);
            this.txtCReportName.TabIndex = 23;
            this.txtCReportName.TextChanged += new System.EventHandler(this.txtCReportName_TextChanged);
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(12, 83);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(92, 17);
            this.lblReportName.TabIndex = 22;
            this.lblReportName.Text = "Report Name";
            // 
            // CboCReportFilterName
            // 
            this.CboCReportFilterName.FormattingEnabled = true;
            this.CboCReportFilterName.Location = new System.Drawing.Point(101, 111);
            this.CboCReportFilterName.Name = "CboCReportFilterName";
            this.CboCReportFilterName.Size = new System.Drawing.Size(121, 24);
            this.CboCReportFilterName.TabIndex = 45;
            // 
            // Position
            // 
            this.Position.Text = "Position";
            // 
            // ucCustomReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucCustomReport";
            this.Size = new System.Drawing.Size(1030, 595);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCReports;
        private System.Windows.Forms.Button cmdCReportTemplate;
        private System.Windows.Forms.TextBox txtCReportTemplate;
        private System.Windows.Forms.Label lblExcelTemplate;
        private System.Windows.Forms.Button cmdCReportNew;
        private System.Windows.Forms.Label lblReportID;
        private System.Windows.Forms.Label lblCReportId;
        private System.Windows.Forms.CheckBox chkDeleteCReport;
        private System.Windows.Forms.ListView lstCReportsFilter;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ComboBox cboCReportFilterType;
        private System.Windows.Forms.Label lblFilterType;
        private System.Windows.Forms.TextBox txtCReportDesc;
        private System.Windows.Forms.Label lblReportDescription;
        private System.Windows.Forms.Button cmdAddRemoveFilter;
        private System.Windows.Forms.Label lblFilterName;
        private System.Windows.Forms.ComboBox cboCReportCategory;
        private System.Windows.Forms.Label lblCustomCategory;
        private System.Windows.Forms.TextBox txtCReportName;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.Button cmdCReportSave;
        private System.Windows.Forms.ComboBox cboReportGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboCReportFilterName;
        private System.Windows.Forms.ColumnHeader Position;
    }
}
