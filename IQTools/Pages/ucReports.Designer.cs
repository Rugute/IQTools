namespace IQTools.Pages
{
    partial class ucReports
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
            this.spcReportsMain = new System.Windows.Forms.SplitContainer();
            this.picReports = new System.Windows.Forms.PictureBox();
            this.tbCReports = new System.Windows.Forms.TabControl();
            this.tbPRunReports = new System.Windows.Forms.TabPage();
            this.spcGen1 = new System.Windows.Forms.SplitContainer();
            this.spcGen2 = new System.Windows.Forms.SplitContainer();
            this.tlPSelectReport = new System.Windows.Forms.TableLayoutPanel();
            this.cboSelectReport = new System.Windows.Forms.ComboBox();
            this.lblReportDescription = new System.Windows.Forms.Label();
            this.lblSelectReport = new System.Windows.Forms.Label();
            this.lstReportResources = new System.Windows.Forms.ListBox();
            this.lblReportResources = new System.Windows.Forms.Label();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.spcGen4 = new System.Windows.Forms.SplitContainer();
            this.tlPParameters = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.tbPReportsAdmin = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.spcReportsMain)).BeginInit();
            this.spcReportsMain.Panel1.SuspendLayout();
            this.spcReportsMain.Panel2.SuspendLayout();
            this.spcReportsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReports)).BeginInit();
            this.tbCReports.SuspendLayout();
            this.tbPRunReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcGen1)).BeginInit();
            this.spcGen1.Panel1.SuspendLayout();
            this.spcGen1.Panel2.SuspendLayout();
            this.spcGen1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcGen2)).BeginInit();
            this.spcGen2.Panel1.SuspendLayout();
            this.spcGen2.Panel2.SuspendLayout();
            this.spcGen2.SuspendLayout();
            this.tlPSelectReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcGen4)).BeginInit();
            this.spcGen4.Panel1.SuspendLayout();
            this.spcGen4.Panel2.SuspendLayout();
            this.spcGen4.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcReportsMain
            // 
            this.spcReportsMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spcReportsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcReportsMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcReportsMain.IsSplitterFixed = true;
            this.spcReportsMain.Location = new System.Drawing.Point(0, 0);
            this.spcReportsMain.Margin = new System.Windows.Forms.Padding(0);
            this.spcReportsMain.Name = "spcReportsMain";
            this.spcReportsMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcReportsMain.Panel1
            // 
            this.spcReportsMain.Panel1.BackColor = System.Drawing.Color.White;
            this.spcReportsMain.Panel1.Controls.Add(this.picReports);
            // 
            // spcReportsMain.Panel2
            // 
            this.spcReportsMain.Panel2.Controls.Add(this.tbCReports);
            this.spcReportsMain.Size = new System.Drawing.Size(1030, 595);
            this.spcReportsMain.SplitterDistance = 60;
            this.spcReportsMain.SplitterWidth = 1;
            this.spcReportsMain.TabIndex = 0;
            // 
            // picReports
            // 
            this.picReports.BackColor = System.Drawing.Color.White;
            this.picReports.Dock = System.Windows.Forms.DockStyle.Left;
            this.picReports.Image = global::IQTools.Properties.Resources.iqtools;
            this.picReports.InitialImage = null;
            this.picReports.Location = new System.Drawing.Point(0, 0);
            this.picReports.Name = "picReports";
            this.picReports.Size = new System.Drawing.Size(228, 60);
            this.picReports.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picReports.TabIndex = 0;
            this.picReports.TabStop = false;
            // 
            // tbCReports
            // 
            this.tbCReports.Controls.Add(this.tbPRunReports);
            this.tbCReports.Controls.Add(this.tbPReportsAdmin);
            this.tbCReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCReports.Location = new System.Drawing.Point(0, 0);
            this.tbCReports.Name = "tbCReports";
            this.tbCReports.SelectedIndex = 0;
            this.tbCReports.Size = new System.Drawing.Size(1030, 534);
            this.tbCReports.TabIndex = 0;
            // 
            // tbPRunReports
            // 
            this.tbPRunReports.BackColor = System.Drawing.Color.AliceBlue;
            this.tbPRunReports.Controls.Add(this.spcGen1);
            this.tbPRunReports.Location = new System.Drawing.Point(4, 22);
            this.tbPRunReports.Margin = new System.Windows.Forms.Padding(0);
            this.tbPRunReports.Name = "tbPRunReports";
            this.tbPRunReports.Size = new System.Drawing.Size(1022, 508);
            this.tbPRunReports.TabIndex = 0;
            this.tbPRunReports.Text = "Generate Reports";
            // 
            // spcGen1
            // 
            this.spcGen1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcGen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcGen1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcGen1.IsSplitterFixed = true;
            this.spcGen1.Location = new System.Drawing.Point(0, 0);
            this.spcGen1.Margin = new System.Windows.Forms.Padding(0);
            this.spcGen1.Name = "spcGen1";
            // 
            // spcGen1.Panel1
            // 
            this.spcGen1.Panel1.Controls.Add(this.spcGen2);
            // 
            // spcGen1.Panel2
            // 
            this.spcGen1.Panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.spcGen1.Panel2.Controls.Add(this.spcGen4);
            this.spcGen1.Size = new System.Drawing.Size(1022, 508);
            this.spcGen1.SplitterDistance = 692;
            this.spcGen1.SplitterWidth = 1;
            this.spcGen1.TabIndex = 0;
            // 
            // spcGen2
            // 
            this.spcGen2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcGen2.Location = new System.Drawing.Point(0, 0);
            this.spcGen2.Margin = new System.Windows.Forms.Padding(0);
            this.spcGen2.Name = "spcGen2";
            this.spcGen2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcGen2.Panel1
            // 
            this.spcGen2.Panel1.Controls.Add(this.tlPSelectReport);
            // 
            // spcGen2.Panel2
            // 
            this.spcGen2.Panel2.BackColor = System.Drawing.Color.OldLace;
            this.spcGen2.Panel2.Controls.Add(this.dgvReports);
            this.spcGen2.Size = new System.Drawing.Size(690, 506);
            this.spcGen2.SplitterDistance = 271;
            this.spcGen2.SplitterWidth = 1;
            this.spcGen2.TabIndex = 0;
            // 
            // tlPSelectReport
            // 
            this.tlPSelectReport.AutoScroll = true;
            this.tlPSelectReport.ColumnCount = 3;
            this.tlPSelectReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPSelectReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPSelectReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPSelectReport.Controls.Add(this.cboSelectReport, 1, 0);
            this.tlPSelectReport.Controls.Add(this.lblReportDescription, 1, 1);
            this.tlPSelectReport.Controls.Add(this.lblSelectReport, 0, 0);
            this.tlPSelectReport.Controls.Add(this.lstReportResources, 2, 1);
            this.tlPSelectReport.Controls.Add(this.lblReportResources, 2, 0);
            this.tlPSelectReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPSelectReport.Location = new System.Drawing.Point(0, 0);
            this.tlPSelectReport.Margin = new System.Windows.Forms.Padding(1);
            this.tlPSelectReport.Name = "tlPSelectReport";
            this.tlPSelectReport.RowCount = 2;
            this.tlPSelectReport.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPSelectReport.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPSelectReport.Size = new System.Drawing.Size(690, 271);
            this.tlPSelectReport.TabIndex = 0;
            // 
            // cboSelectReport
            // 
            this.cboSelectReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboSelectReport.FormattingEnabled = true;
            this.cboSelectReport.Location = new System.Drawing.Point(82, 1);
            this.cboSelectReport.Margin = new System.Windows.Forms.Padding(1);
            this.cboSelectReport.Name = "cboSelectReport";
            this.cboSelectReport.Size = new System.Drawing.Size(390, 21);
            this.cboSelectReport.TabIndex = 0;
            this.cboSelectReport.SelectionChangeCommitted += new System.EventHandler(this.cboSelectReport_SelectionChangeCommitted);
            // 
            // lblReportDescription
            // 
            this.lblReportDescription.AutoEllipsis = true;
            this.lblReportDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReportDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportDescription.Location = new System.Drawing.Point(82, 24);
            this.lblReportDescription.Margin = new System.Windows.Forms.Padding(1);
            this.lblReportDescription.Name = "lblReportDescription";
            this.lblReportDescription.Size = new System.Drawing.Size(390, 246);
            this.lblReportDescription.TabIndex = 2;
            // 
            // lblSelectReport
            // 
            this.lblSelectReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectReport.AutoSize = true;
            this.lblSelectReport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectReport.Location = new System.Drawing.Point(3, 10);
            this.lblSelectReport.Name = "lblSelectReport";
            this.lblSelectReport.Size = new System.Drawing.Size(75, 13);
            this.lblSelectReport.TabIndex = 1;
            this.lblSelectReport.Text = "Select Report";
            // 
            // lstReportResources
            // 
            this.lstReportResources.BackColor = System.Drawing.Color.AliceBlue;
            this.lstReportResources.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstReportResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstReportResources.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstReportResources.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lstReportResources.FormattingEnabled = true;
            this.lstReportResources.IntegralHeight = false;
            this.lstReportResources.Location = new System.Drawing.Point(474, 24);
            this.lstReportResources.Margin = new System.Windows.Forms.Padding(1);
            this.lstReportResources.Name = "lstReportResources";
            this.lstReportResources.Size = new System.Drawing.Size(215, 246);
            this.lstReportResources.TabIndex = 3;
            this.lstReportResources.Click += new System.EventHandler(this.lstReportResources_Click);
            // 
            // lblReportResources
            // 
            this.lblReportResources.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReportResources.AutoSize = true;
            this.lblReportResources.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportResources.Location = new System.Drawing.Point(476, 10);
            this.lblReportResources.Name = "lblReportResources";
            this.lblReportResources.Size = new System.Drawing.Size(97, 13);
            this.lblReportResources.TabIndex = 4;
            this.lblReportResources.Text = "Report Resources";
            // 
            // dgvReports
            // 
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.AllowUserToOrderColumns = true;
            this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReports.GridColor = System.Drawing.SystemColors.Control;
            this.dgvReports.Location = new System.Drawing.Point(0, 0);
            this.dgvReports.Margin = new System.Windows.Forms.Padding(0);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.Size = new System.Drawing.Size(690, 234);
            this.dgvReports.TabIndex = 0;
            this.dgvReports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReports_CellContentClick);
            // 
            // spcGen4
            // 
            this.spcGen4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcGen4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcGen4.IsSplitterFixed = true;
            this.spcGen4.Location = new System.Drawing.Point(0, 0);
            this.spcGen4.Name = "spcGen4";
            this.spcGen4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcGen4.Panel1
            // 
            this.spcGen4.Panel1.Controls.Add(this.tlPParameters);
            // 
            // spcGen4.Panel2
            // 
            this.spcGen4.Panel2.Controls.Add(this.btnGenerateReport);
            this.spcGen4.Size = new System.Drawing.Size(327, 506);
            this.spcGen4.SplitterDistance = 475;
            this.spcGen4.SplitterWidth = 1;
            this.spcGen4.TabIndex = 0;
            // 
            // tlPParameters
            // 
            this.tlPParameters.AutoScroll = true;
            this.tlPParameters.ColumnCount = 2;
            this.tlPParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPParameters.Location = new System.Drawing.Point(0, 0);
            this.tlPParameters.Name = "tlPParameters";
            this.tlPParameters.RowCount = 1;
            this.tlPParameters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPParameters.Size = new System.Drawing.Size(327, 475);
            this.tlPParameters.TabIndex = 0;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerateReport.Location = new System.Drawing.Point(0, 0);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(327, 30);
            this.btnGenerateReport.TabIndex = 0;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // tbPReportsAdmin
            // 
            this.tbPReportsAdmin.Location = new System.Drawing.Point(4, 22);
            this.tbPReportsAdmin.Margin = new System.Windows.Forms.Padding(0);
            this.tbPReportsAdmin.Name = "tbPReportsAdmin";
            this.tbPReportsAdmin.Size = new System.Drawing.Size(1022, 508);
            this.tbPReportsAdmin.TabIndex = 1;
            this.tbPReportsAdmin.Text = "Configure Reports";
            this.tbPReportsAdmin.UseVisualStyleBackColor = true;
            // 
            // ucReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcReportsMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucReports";
            this.Size = new System.Drawing.Size(1030, 595);
            this.Load += new System.EventHandler(this.ucReports_Load);
            this.spcReportsMain.Panel1.ResumeLayout(false);
            this.spcReportsMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcReportsMain)).EndInit();
            this.spcReportsMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picReports)).EndInit();
            this.tbCReports.ResumeLayout(false);
            this.tbPRunReports.ResumeLayout(false);
            this.spcGen1.Panel1.ResumeLayout(false);
            this.spcGen1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcGen1)).EndInit();
            this.spcGen1.ResumeLayout(false);
            this.spcGen2.Panel1.ResumeLayout(false);
            this.spcGen2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcGen2)).EndInit();
            this.spcGen2.ResumeLayout(false);
            this.tlPSelectReport.ResumeLayout(false);
            this.tlPSelectReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.spcGen4.Panel1.ResumeLayout(false);
            this.spcGen4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcGen4)).EndInit();
            this.spcGen4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcReportsMain;
        private System.Windows.Forms.TabControl tbCReports;
        private System.Windows.Forms.TabPage tbPRunReports;
        private System.Windows.Forms.TabPage tbPReportsAdmin;
        private System.Windows.Forms.SplitContainer spcGen1;
        private System.Windows.Forms.SplitContainer spcGen2;
        private System.Windows.Forms.Label lblSelectReport;
        private System.Windows.Forms.ComboBox cboSelectReport;
        private System.Windows.Forms.Label lblReportDescription;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.TableLayoutPanel tlPParameters;
        private System.Windows.Forms.TableLayoutPanel tlPSelectReport;
        private System.Windows.Forms.SplitContainer spcGen4;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.ListBox lstReportResources;
        private System.Windows.Forms.Label lblReportResources;
        private System.Windows.Forms.PictureBox picReports;
    }
}
