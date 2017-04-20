namespace IQTools.Pages
{
    partial class ucQueryParameters
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
            this.spcQueryParameters = new System.Windows.Forms.SplitContainer();
            this.dgvQueryParameters = new System.Windows.Forms.DataGridView();
            this.dgcParamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcRelatedField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcParamValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.spcQueryParameters.Panel2.SuspendLayout();
            this.spcQueryParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryParameters)).BeginInit();
            this.SuspendLayout();
            // 
            // spcQueryParameters
            // 
            this.spcQueryParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcQueryParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcQueryParameters.Location = new System.Drawing.Point(0, 0);
            this.spcQueryParameters.Name = "spcQueryParameters";
            this.spcQueryParameters.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcQueryParameters.Panel1
            // 
            this.spcQueryParameters.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            // 
            // spcQueryParameters.Panel2
            // 
            this.spcQueryParameters.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.spcQueryParameters.Panel2.Controls.Add(this.btnOK);
            this.spcQueryParameters.Panel2.Controls.Add(this.btnCancel);
            this.spcQueryParameters.Panel2.Controls.Add(this.dgvQueryParameters);
            this.spcQueryParameters.Size = new System.Drawing.Size(501, 232);
            this.spcQueryParameters.SplitterDistance = 34;
            this.spcQueryParameters.SplitterWidth = 1;
            this.spcQueryParameters.TabIndex = 0;
            // 
            // dgvQueryParameters
            // 
            this.dgvQueryParameters.AllowUserToAddRows = false;
            this.dgvQueryParameters.AllowUserToDeleteRows = false;
            this.dgvQueryParameters.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvQueryParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcParamName,
            this.dgcRelatedField,
            this.dgcDataType,
            this.dgcParamValue});
            this.dgvQueryParameters.Location = new System.Drawing.Point(14, 16);
            this.dgvQueryParameters.Name = "dgvQueryParameters";
            this.dgvQueryParameters.Size = new System.Drawing.Size(468, 129);
            this.dgvQueryParameters.TabIndex = 0;
            // 
            // dgcParamName
            // 
            this.dgcParamName.HeaderText = "Name";
            this.dgcParamName.Name = "dgcParamName";
            this.dgcParamName.ReadOnly = true;
            // 
            // dgcRelatedField
            // 
            this.dgcRelatedField.HeaderText = "Related Field";
            this.dgcRelatedField.Name = "dgcRelatedField";
            this.dgcRelatedField.ReadOnly = true;
            // 
            // dgcDataType
            // 
            this.dgcDataType.HeaderText = "Data Type";
            this.dgcDataType.Name = "dgcDataType";
            this.dgcDataType.ReadOnly = true;
            // 
            // dgcParamValue
            // 
            this.dgcParamValue.HeaderText = "Value";
            this.dgcParamValue.Name = "dgcParamValue";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(311, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(407, 152);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // ucQueryParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcQueryParameters);
            this.Name = "ucQueryParameters";
            this.Size = new System.Drawing.Size(501, 232);
            this.spcQueryParameters.Panel2.ResumeLayout(false);
            this.spcQueryParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryParameters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcQueryParameters;
        private System.Windows.Forms.DataGridView dgvQueryParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcParamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcRelatedField;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcParamValue;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
