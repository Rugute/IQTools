namespace IQTools
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboFacility = new System.Windows.Forms.ComboBox();
            this.lblFacility = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.lblLoadStat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblDBLoad = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.IQDate = new System.Windows.Forms.DateTimePicker();
            this.chkRefresh = new System.Windows.Forms.CheckBox();
            this.cmdLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblUID = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblDB = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblMain = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cboFacility);
            this.panel1.Controls.Add(this.lblFacility);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Controls.Add(this.cboLanguage);
            this.panel1.Controls.Add(this.lblLoadStat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblUpdate);
            this.panel1.Controls.Add(this.lblDBLoad);
            this.panel1.Controls.Add(this.lblLastUpdate);
            this.panel1.Controls.Add(this.IQDate);
            this.panel1.Controls.Add(this.chkRefresh);
            this.panel1.Controls.Add(this.cmdLogin);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.lblPwd);
            this.panel1.Controls.Add(this.lblUID);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 316);
            this.panel1.TabIndex = 0;
            // 
            // cboFacility
            // 
            this.cboFacility.FormattingEnabled = true;
            this.cboFacility.Location = new System.Drawing.Point(193, 186);
            this.cboFacility.Name = "cboFacility";
            this.cboFacility.Size = new System.Drawing.Size(156, 21);
            this.cboFacility.TabIndex = 3;
            this.cboFacility.Visible = false;
            // 
            // lblFacility
            // 
            this.lblFacility.AutoSize = true;
            this.lblFacility.Location = new System.Drawing.Point(98, 189);
            this.lblFacility.Name = "lblFacility";
            this.lblFacility.Size = new System.Drawing.Size(90, 13);
            this.lblFacility.TabIndex = 17;
            this.lblFacility.Text = "Facility/Satellite:";
            this.lblFacility.Visible = false;
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(381, 127);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 70);
            this.picLogo.TabIndex = 16;
            this.picLogo.TabStop = false;
            // 
            // cboLanguage
            // 
            this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(381, 265);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(101, 23);
            this.cboLanguage.TabIndex = 5;
            this.cboLanguage.SelectedIndexChanged += new System.EventHandler(this.cboLanguage_SelectedIndexChanged);
            // 
            // lblLoadStat
            // 
            this.lblLoadStat.AutoSize = true;
            this.lblLoadStat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadStat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.lblLoadStat.Location = new System.Drawing.Point(44, 99);
            this.lblLoadStat.Name = "lblLoadStat";
            this.lblLoadStat.Size = new System.Drawing.Size(41, 15);
            this.lblLoadStat.TabIndex = 15;
            this.lblLoadStat.Text = "Ready";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(320, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Language";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUpdate.Location = new System.Drawing.Point(98, 275);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(73, 15);
            this.lblUpdate.TabIndex = 15;
            this.lblUpdate.Text = "01/01/2014";
            // 
            // lblDBLoad
            // 
            this.lblDBLoad.AutoSize = true;
            this.lblDBLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBLoad.ForeColor = System.Drawing.Color.Gray;
            this.lblDBLoad.Location = new System.Drawing.Point(3, 99);
            this.lblDBLoad.Name = "lblDBLoad";
            this.lblDBLoad.Size = new System.Drawing.Size(42, 15);
            this.lblDBLoad.TabIndex = 14;
            this.lblDBLoad.Text = "Status:";
            this.lblDBLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdate.ForeColor = System.Drawing.Color.Gray;
            this.lblLastUpdate.Location = new System.Drawing.Point(3, 275);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(71, 15);
            this.lblLastUpdate.TabIndex = 14;
            this.lblLastUpdate.Text = "Last update:";
            this.lblLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IQDate
            // 
            this.IQDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.IQDate.Location = new System.Drawing.Point(6, 221);
            this.IQDate.Name = "IQDate";
            this.IQDate.Size = new System.Drawing.Size(79, 22);
            this.IQDate.TabIndex = 13;
            this.IQDate.Value = new System.DateTime(2010, 12, 31, 0, 0, 0, 0);
            this.IQDate.Visible = false;
            // 
            // chkRefresh
            // 
            this.chkRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRefresh.AutoSize = true;
            this.chkRefresh.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRefresh.ForeColor = System.Drawing.Color.Gray;
            this.chkRefresh.Location = new System.Drawing.Point(416, 98);
            this.chkRefresh.Name = "chkRefresh";
            this.chkRefresh.Size = new System.Drawing.Size(92, 19);
            this.chkRefresh.TabIndex = 12;
            this.chkRefresh.Text = "Refresh Data";
            this.chkRefresh.UseVisualStyleBackColor = true;
            // 
            // cmdLogin
            // 
            this.cmdLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLogin.Location = new System.Drawing.Point(193, 213);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(156, 32);
            this.cmdLogin.TabIndex = 4;
            this.cmdLogin.Text = "Login";
            this.cmdLogin.UseVisualStyleBackColor = true;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(193, 156);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(156, 23);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(193, 127);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(156, 23);
            this.txtUser.TabIndex = 1;
            // 
            // lblPwd
            // 
            this.lblPwd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPwd.AutoSize = true;
            this.lblPwd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPwd.Location = new System.Drawing.Point(98, 157);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(60, 15);
            this.lblPwd.TabIndex = 6;
            this.lblPwd.Text = "Password:";
            // 
            // lblUID
            // 
            this.lblUID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUID.AutoSize = true;
            this.lblUID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUID.Location = new System.Drawing.Point(98, 128);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(63, 15);
            this.lblUID.TabIndex = 5;
            this.lblUID.Text = "Username:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Location = new System.Drawing.Point(0, 82);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(512, 10);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::IQTools.Properties.Resources.IQToolsCollageShort;
            this.pictureBox1.Location = new System.Drawing.Point(0, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.lblDB);
            this.panel2.Controls.Add(this.lblClose);
            this.panel2.Controls.Add(this.lblMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(512, 32);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.pictureBox4.Location = new System.Drawing.Point(-1, 30);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(515, 2);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.lblDB.Location = new System.Drawing.Point(394, 8);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(49, 15);
            this.lblDB.TabIndex = 3;
            this.lblDB.Text = "Settings";
            this.lblDB.Click += new System.EventHandler(this.lblDB_Click);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.lblClose.Location = new System.Drawing.Point(472, 8);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(36, 15);
            this.lblClose.TabIndex = 2;
            this.lblClose.Text = "Close";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.lblMain.Location = new System.Drawing.Point(3, 8);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(37, 15);
            this.lblMain.TabIndex = 0;
            this.lblMain.Text = "Login";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 40);
            this.panel3.Size = new System.Drawing.Size(514, 341);
            this.panel3.TabIndex = 1;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.cmdLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 341);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblUID;
        private System.Windows.Forms.Button cmdLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.CheckBox chkRefresh;
        private System.Windows.Forms.DateTimePicker IQDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblLoadStat;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblDBLoad;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.ComboBox cboLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.ComboBox cboFacility;
        private System.Windows.Forms.Label lblFacility;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;

    }
}