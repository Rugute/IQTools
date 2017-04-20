namespace IQTools
{
    partial class frmGetDB
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.picProgress = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.txtIQTUID = new System.Windows.Forms.TextBox();
            this.cboIQTools = new System.Windows.Forms.ComboBox();
            this.txtIQTPWD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdIQLoad = new System.Windows.Forms.Button();
            this.cmdSLoad = new System.Windows.Forms.Button();
            this.pnlAdherence = new System.Windows.Forms.Panel();
            this.label71 = new System.Windows.Forms.Label();
            this.chkNewPMMS = new System.Windows.Forms.CheckBox();
            this.gdbPMMS = new System.Windows.Forms.GroupBox();
            this.cboPMMS = new System.Windows.Forms.ComboBox();
            this.lblPMMS = new System.Windows.Forms.Label();
            this.gbServer = new System.Windows.Forms.GroupBox();
            this.chkSystem = new System.Windows.Forms.CheckBox();
            this.txtDbPWD = new System.Windows.Forms.TextBox();
            this.cmdDBLoad = new System.Windows.Forms.Button();
            this.chkTrusted = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDBServer = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboDBase = new System.Windows.Forms.ComboBox();
            this.txtDbUID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDBServer = new System.Windows.Forms.Label();
            this.cmdDbServer = new System.Windows.Forms.Button();
            this.cboPMMSType = new System.Windows.Forms.ComboBox();
            this.lblPMMSType = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkNewDB = new System.Windows.Forms.CheckBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.pbGetDB = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.ofdMail = new System.Windows.Forms.OpenFileDialog();
            this.lblSaveProgress = new System.Windows.Forms.Label();
            this.picSettingsProgress = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlAdherence.SuspendLayout();
            this.gdbPMMS.SuspendLayout();
            this.gbServer.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGetDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSettingsProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.pnlMain);
            this.panel1.Controls.Add(this.pbGetDB);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 453);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.pictureBox4.Location = new System.Drawing.Point(0, 22);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(758, 2);
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.panel5.Controls.Add(this.lblProgress);
            this.panel5.Controls.Add(this.picProgress);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 415);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(758, 36);
            this.panel5.TabIndex = 36;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.White;
            this.lblProgress.Location = new System.Drawing.Point(39, 17);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 19);
            this.lblProgress.TabIndex = 1;
            // 
            // picProgress
            // 
            this.picProgress.Location = new System.Drawing.Point(1, 2);
            this.picProgress.Name = "picProgress";
            this.picProgress.Size = new System.Drawing.Size(32, 32);
            this.picProgress.TabIndex = 0;
            this.picProgress.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.lblSaveProgress);
            this.pnlMain.Controls.Add(this.picSettingsProgress);
            this.pnlMain.Controls.Add(this.panel4);
            this.pnlMain.Controls.Add(this.pnlAdherence);
            this.pnlMain.Controls.Add(this.chkNewPMMS);
            this.pnlMain.Controls.Add(this.gdbPMMS);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 94);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlMain.Size = new System.Drawing.Size(758, 357);
            this.pnlMain.TabIndex = 35;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cboServer);
            this.panel4.Controls.Add(this.txtIQTUID);
            this.panel4.Controls.Add(this.cboIQTools);
            this.panel4.Controls.Add(this.txtIQTPWD);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cmdIQLoad);
            this.panel4.Controls.Add(this.cmdSLoad);
            this.panel4.Location = new System.Drawing.Point(6, 88);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(375, 151);
            this.panel4.TabIndex = 52;
            // 
            // cboServer
            // 
            this.cboServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Location = new System.Drawing.Point(121, 15);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(169, 28);
            this.cboServer.TabIndex = 23;
            // 
            // txtIQTUID
            // 
            this.txtIQTUID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIQTUID.ForeColor = System.Drawing.Color.Black;
            this.txtIQTUID.Location = new System.Drawing.Point(121, 47);
            this.txtIQTUID.Name = "txtIQTUID";
            this.txtIQTUID.Size = new System.Drawing.Size(192, 27);
            this.txtIQTUID.TabIndex = 24;
            // 
            // cboIQTools
            // 
            this.cboIQTools.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIQTools.FormattingEnabled = true;
            this.cboIQTools.Location = new System.Drawing.Point(121, 109);
            this.cboIQTools.Name = "cboIQTools";
            this.cboIQTools.Size = new System.Drawing.Size(169, 28);
            this.cboIQTools.TabIndex = 26;
            // 
            // txtIQTPWD
            // 
            this.txtIQTPWD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIQTPWD.ForeColor = System.Drawing.Color.Black;
            this.txtIQTPWD.Location = new System.Drawing.Point(121, 78);
            this.txtIQTPWD.Name = "txtIQTPWD";
            this.txtIQTPWD.PasswordChar = '*';
            this.txtIQTPWD.Size = new System.Drawing.Size(192, 27);
            this.txtIQTPWD.TabIndex = 25;
            this.txtIQTPWD.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "Database:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(20, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(20, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "SQL Server:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Password:";
            // 
            // cmdIQLoad
            // 
            this.cmdIQLoad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmdIQLoad.Location = new System.Drawing.Point(290, 108);
            this.cmdIQLoad.Name = "cmdIQLoad";
            this.cmdIQLoad.Size = new System.Drawing.Size(25, 24);
            this.cmdIQLoad.TabIndex = 42;
            this.cmdIQLoad.TabStop = false;
            this.cmdIQLoad.Text = "...";
            this.cmdIQLoad.UseVisualStyleBackColor = true;
            this.cmdIQLoad.Click += new System.EventHandler(this.cmdIQLoad_Click);
            // 
            // cmdSLoad
            // 
            this.cmdSLoad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmdSLoad.Location = new System.Drawing.Point(290, 14);
            this.cmdSLoad.Name = "cmdSLoad";
            this.cmdSLoad.Size = new System.Drawing.Size(25, 24);
            this.cmdSLoad.TabIndex = 31;
            this.cmdSLoad.TabStop = false;
            this.cmdSLoad.Text = "...";
            this.cmdSLoad.UseVisualStyleBackColor = true;
            this.cmdSLoad.Click += new System.EventHandler(this.cmdSLoad_Click);
            // 
            // pnlAdherence
            // 
            this.pnlAdherence.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pnlAdherence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pnlAdherence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdherence.Controls.Add(this.label71);
            this.pnlAdherence.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAdherence.Location = new System.Drawing.Point(0, 0);
            this.pnlAdherence.Name = "pnlAdherence";
            this.pnlAdherence.Size = new System.Drawing.Size(756, 34);
            this.pnlAdherence.TabIndex = 51;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.label71.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.label71.Location = new System.Drawing.Point(3, 14);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(132, 20);
            this.label71.TabIndex = 3;
            this.label71.Text = "Data Connections";
            // 
            // chkNewPMMS
            // 
            this.chkNewPMMS.AutoSize = true;
            this.chkNewPMMS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNewPMMS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNewPMMS.Location = new System.Drawing.Point(275, 58);
            this.chkNewPMMS.Name = "chkNewPMMS";
            this.chkNewPMMS.Size = new System.Drawing.Size(127, 24);
            this.chkNewPMMS.TabIndex = 49;
            this.chkNewPMMS.TabStop = false;
            this.chkNewPMMS.Text = "Change PMMS";
            this.chkNewPMMS.UseVisualStyleBackColor = true;
            this.chkNewPMMS.CheckedChanged += new System.EventHandler(this.chkNewPMMS_CheckedChanged);
            // 
            // gdbPMMS
            // 
            this.gdbPMMS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gdbPMMS.Controls.Add(this.cboPMMS);
            this.gdbPMMS.Controls.Add(this.lblPMMS);
            this.gdbPMMS.Controls.Add(this.gbServer);
            this.gdbPMMS.Controls.Add(this.cboPMMSType);
            this.gdbPMMS.Controls.Add(this.lblPMMSType);
            this.gdbPMMS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gdbPMMS.Location = new System.Drawing.Point(386, 42);
            this.gdbPMMS.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.gdbPMMS.Name = "gdbPMMS";
            this.gdbPMMS.Padding = new System.Windows.Forms.Padding(0);
            this.gdbPMMS.Size = new System.Drawing.Size(367, 272);
            this.gdbPMMS.TabIndex = 43;
            this.gdbPMMS.TabStop = false;
            this.gdbPMMS.Text = "Database";
            // 
            // cboPMMS
            // 
            this.cboPMMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPMMS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPMMS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboPMMS.FormattingEnabled = true;
            this.cboPMMS.Items.AddRange(new object[] {
            "IQCare",
            "CTC2",
            "CTC2MySQL",
            "ISante",
            "CPAD",
            "OpenMRS",
            "IQChart",
            "SmartCare",
            "Other"});
            this.cboPMMS.Location = new System.Drawing.Point(132, 46);
            this.cboPMMS.Name = "cboPMMS";
            this.cboPMMS.Size = new System.Drawing.Size(212, 28);
            this.cboPMMS.TabIndex = 53;
            this.cboPMMS.SelectedIndexChanged += new System.EventHandler(this.cboPMMS_SelectedIndexChanged);
            // 
            // lblPMMS
            // 
            this.lblPMMS.AutoSize = true;
            this.lblPMMS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMMS.Location = new System.Drawing.Point(28, 46);
            this.lblPMMS.Name = "lblPMMS";
            this.lblPMMS.Size = new System.Drawing.Size(54, 20);
            this.lblPMMS.TabIndex = 52;
            this.lblPMMS.Text = "PMMS:";
            // 
            // gbServer
            // 
            this.gbServer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbServer.Controls.Add(this.chkSystem);
            this.gbServer.Controls.Add(this.txtDbPWD);
            this.gbServer.Controls.Add(this.cmdDBLoad);
            this.gbServer.Controls.Add(this.chkTrusted);
            this.gbServer.Controls.Add(this.label7);
            this.gbServer.Controls.Add(this.cboDBServer);
            this.gbServer.Controls.Add(this.label9);
            this.gbServer.Controls.Add(this.cboDBase);
            this.gbServer.Controls.Add(this.txtDbUID);
            this.gbServer.Controls.Add(this.label6);
            this.gbServer.Controls.Add(this.lblDBServer);
            this.gbServer.Controls.Add(this.cmdDbServer);
            this.gbServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.gbServer.Location = new System.Drawing.Point(31, 89);
            this.gbServer.Name = "gbServer";
            this.gbServer.Size = new System.Drawing.Size(313, 171);
            this.gbServer.TabIndex = 51;
            this.gbServer.TabStop = false;
            this.gbServer.Text = "Microsoft SQL Server";
            // 
            // chkSystem
            // 
            this.chkSystem.AutoSize = true;
            this.chkSystem.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSystem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSystem.ForeColor = System.Drawing.Color.Black;
            this.chkSystem.Location = new System.Drawing.Point(213, 78);
            this.chkSystem.Name = "chkSystem";
            this.chkSystem.Size = new System.Drawing.Size(81, 24);
            this.chkSystem.TabIndex = 51;
            this.chkSystem.TabStop = false;
            this.chkSystem.Text = "System:";
            this.chkSystem.UseVisualStyleBackColor = true;
            this.chkSystem.Visible = false;
            this.chkSystem.CheckedChanged += new System.EventHandler(this.chkSystem_CheckedChanged);
            // 
            // txtDbPWD
            // 
            this.txtDbPWD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbPWD.ForeColor = System.Drawing.Color.Black;
            this.txtDbPWD.Location = new System.Drawing.Point(101, 106);
            this.txtDbPWD.Name = "txtDbPWD";
            this.txtDbPWD.PasswordChar = '*';
            this.txtDbPWD.Size = new System.Drawing.Size(105, 27);
            this.txtDbPWD.TabIndex = 30;
            this.txtDbPWD.UseSystemPasswordChar = true;
            // 
            // cmdDBLoad
            // 
            this.cmdDBLoad.ForeColor = System.Drawing.Color.Black;
            this.cmdDBLoad.Location = new System.Drawing.Point(264, 137);
            this.cmdDBLoad.Name = "cmdDBLoad";
            this.cmdDBLoad.Size = new System.Drawing.Size(25, 24);
            this.cmdDBLoad.TabIndex = 44;
            this.cmdDBLoad.TabStop = false;
            this.cmdDBLoad.Text = "...";
            this.cmdDBLoad.UseVisualStyleBackColor = true;
            this.cmdDBLoad.Click += new System.EventHandler(this.cmdDBLoad_Click);
            // 
            // chkTrusted
            // 
            this.chkTrusted.AutoSize = true;
            this.chkTrusted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTrusted.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrusted.ForeColor = System.Drawing.Color.Black;
            this.chkTrusted.Location = new System.Drawing.Point(212, 106);
            this.chkTrusted.Name = "chkTrusted";
            this.chkTrusted.Size = new System.Drawing.Size(82, 24);
            this.chkTrusted.TabIndex = 50;
            this.chkTrusted.TabStop = false;
            this.chkTrusted.Text = "Trusted:";
            this.chkTrusted.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 41;
            this.label7.Text = "Database:";
            // 
            // cboDBServer
            // 
            this.cboDBServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDBServer.ForeColor = System.Drawing.Color.Black;
            this.cboDBServer.FormattingEnabled = true;
            this.cboDBServer.Location = new System.Drawing.Point(101, 37);
            this.cboDBServer.Name = "cboDBServer";
            this.cboDBServer.Size = new System.Drawing.Size(159, 28);
            this.cboDBServer.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 45;
            this.label9.Text = "Username:";
            // 
            // cboDBase
            // 
            this.cboDBase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDBase.ForeColor = System.Drawing.Color.Black;
            this.cboDBase.FormattingEnabled = true;
            this.cboDBase.Location = new System.Drawing.Point(101, 137);
            this.cboDBase.Name = "cboDBase";
            this.cboDBase.Size = new System.Drawing.Size(159, 28);
            this.cboDBase.TabIndex = 31;
            // 
            // txtDbUID
            // 
            this.txtDbUID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbUID.ForeColor = System.Drawing.Color.Black;
            this.txtDbUID.Location = new System.Drawing.Point(101, 75);
            this.txtDbUID.Name = "txtDbUID";
            this.txtDbUID.Size = new System.Drawing.Size(105, 27);
            this.txtDbUID.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 41;
            this.label6.Text = "Password:";
            // 
            // lblDBServer
            // 
            this.lblDBServer.AutoSize = true;
            this.lblDBServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBServer.ForeColor = System.Drawing.Color.Black;
            this.lblDBServer.Location = new System.Drawing.Point(6, 40);
            this.lblDBServer.Name = "lblDBServer";
            this.lblDBServer.Size = new System.Drawing.Size(77, 20);
            this.lblDBServer.TabIndex = 25;
            this.lblDBServer.Text = "DB Server:";
            // 
            // cmdDbServer
            // 
            this.cmdDbServer.ForeColor = System.Drawing.Color.Black;
            this.cmdDbServer.Location = new System.Drawing.Point(264, 37);
            this.cmdDbServer.Name = "cmdDbServer";
            this.cmdDbServer.Size = new System.Drawing.Size(25, 24);
            this.cmdDbServer.TabIndex = 31;
            this.cmdDbServer.TabStop = false;
            this.cmdDbServer.Text = "...";
            this.cmdDbServer.UseVisualStyleBackColor = true;
            this.cmdDbServer.Click += new System.EventHandler(this.cmdDbServer_Click);
            // 
            // cboPMMSType
            // 
            this.cboPMMSType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPMMSType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPMMSType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboPMMSType.FormattingEnabled = true;
            this.cboPMMSType.Items.AddRange(new object[] {
            "MySQL Server",
            "Microsoft Access",
            "PostgreSQL Server",
            "Microsoft SQL Server"});
            this.cboPMMSType.Location = new System.Drawing.Point(132, 13);
            this.cboPMMSType.Name = "cboPMMSType";
            this.cboPMMSType.Size = new System.Drawing.Size(213, 28);
            this.cboPMMSType.TabIndex = 27;
            this.cboPMMSType.SelectedIndexChanged += new System.EventHandler(this.cboPMMSType_SelectedIndexChanged);
            // 
            // lblPMMSType
            // 
            this.lblPMMSType.AutoSize = true;
            this.lblPMMSType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMMSType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPMMSType.Location = new System.Drawing.Point(27, 16);
            this.lblPMMSType.Name = "lblPMMSType";
            this.lblPMMSType.Size = new System.Drawing.Size(110, 20);
            this.lblPMMSType.TabIndex = 42;
            this.lblPMMSType.Text = "Database Type:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chkNewDB);
            this.panel3.Controls.Add(this.cmdSave);
            this.panel3.Location = new System.Drawing.Point(6, 258);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(7);
            this.panel3.Size = new System.Drawing.Size(375, 56);
            this.panel3.TabIndex = 48;
            // 
            // chkNewDB
            // 
            this.chkNewDB.AutoSize = true;
            this.chkNewDB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNewDB.Checked = true;
            this.chkNewDB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewDB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNewDB.ForeColor = System.Drawing.Color.Black;
            this.chkNewDB.Location = new System.Drawing.Point(-1, 1);
            this.chkNewDB.Margin = new System.Windows.Forms.Padding(0);
            this.chkNewDB.Name = "chkNewDB";
            this.chkNewDB.Size = new System.Drawing.Size(157, 24);
            this.chkNewDB.TabIndex = 40;
            this.chkNewDB.TabStop = false;
            this.chkNewDB.Text = "Update IQTools DB";
            this.chkNewDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNewDB.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(270, 9);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(99, 37);
            this.cmdSave.TabIndex = 38;
            this.cmdSave.TabStop = false;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // pbGetDB
            // 
            this.pbGetDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.pbGetDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbGetDB.Location = new System.Drawing.Point(0, 84);
            this.pbGetDB.Name = "pbGetDB";
            this.pbGetDB.Size = new System.Drawing.Size(758, 10);
            this.pbGetDB.TabIndex = 8;
            this.pbGetDB.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::IQTools.Properties.Resources.IQToolsCollageShort;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(758, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 24);
            this.panel2.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(3);
            this.label8.Size = new System.Drawing.Size(72, 26);
            this.label8.TabIndex = 3;
            this.label8.Text = "Settings";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.lblClose.Location = new System.Drawing.Point(707, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Padding = new System.Windows.Forms.Padding(3);
            this.lblClose.Size = new System.Drawing.Size(51, 26);
            this.lblClose.TabIndex = 2;
            this.lblClose.Text = "Close";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // ofdMail
            // 
            this.ofdMail.FileName = "openFileDialog1";
            // 
            // lblSaveProgress
            // 
            this.lblSaveProgress.AutoSize = true;
            this.lblSaveProgress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaveProgress.Location = new System.Drawing.Point(94, 55);
            this.lblSaveProgress.Name = "lblSaveProgress";
            this.lblSaveProgress.Size = new System.Drawing.Size(96, 20);
            this.lblSaveProgress.TabIndex = 54;
            this.lblSaveProgress.Text = "Save Progress";
            // 
            // picSettingsProgress
            // 
            this.picSettingsProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSettingsProgress.Location = new System.Drawing.Point(67, 55);
            this.picSettingsProgress.Margin = new System.Windows.Forms.Padding(0);
            this.picSettingsProgress.Name = "picSettingsProgress";
            this.picSettingsProgress.Size = new System.Drawing.Size(24, 24);
            this.picSettingsProgress.TabIndex = 53;
            this.picSettingsProgress.TabStop = false;
            // 
            // frmGetDB
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 453);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGetDB";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB Connect";
            this.Load += new System.EventHandler(this.frmGetDB_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlAdherence.ResumeLayout(false);
            this.pnlAdherence.PerformLayout();
            this.gdbPMMS.ResumeLayout(false);
            this.gdbPMMS.PerformLayout();
            this.gbServer.ResumeLayout(false);
            this.gbServer.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGetDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSettingsProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbGetDB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Button cmdSLoad;
        private System.Windows.Forms.ComboBox cboIQTools;
        private System.Windows.Forms.ComboBox cboServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.CheckBox chkNewDB;
        private System.Windows.Forms.OpenFileDialog ofdMail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPMMSType;
        private System.Windows.Forms.Label lblPMMSType;
        private System.Windows.Forms.GroupBox gdbPMMS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDBase;
        private System.Windows.Forms.ComboBox cboDBServer;
        private System.Windows.Forms.Label lblDBServer;
        private System.Windows.Forms.Button cmdDbServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIQTPWD;
        private System.Windows.Forms.Button cmdDBLoad;
        private System.Windows.Forms.TextBox txtDbPWD;
        private System.Windows.Forms.TextBox txtDbUID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIQTUID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdIQLoad;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkNewPMMS;
        private System.Windows.Forms.CheckBox chkTrusted;
        private System.Windows.Forms.Panel pnlAdherence;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbServer;
        private System.Windows.Forms.CheckBox chkSystem;
        private System.Windows.Forms.Label lblPMMS;
        private System.Windows.Forms.ComboBox cboPMMS;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.PictureBox picProgress;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblSaveProgress;
        private System.Windows.Forms.PictureBox picSettingsProgress;

    }
}