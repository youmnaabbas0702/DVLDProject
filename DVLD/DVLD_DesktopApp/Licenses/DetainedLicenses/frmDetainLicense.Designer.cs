namespace DVLD_DesktopApp.Licenses
{
    partial class frmDetainLicense
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lnklblShowLicense = new System.Windows.Forms.LinkLabel();
            this.lnklblLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.ctrlDetainLicenseInfo1 = new DVLD_DesktopApp.Controls.ctrlDetainLicenseInfo();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_DesktopApp.Controls.ctrlDriverLicenseInfoWithFilter();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gill Sans MT", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(372, 32);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(188, 39);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Detain license";
            // 
            // lnklblShowLicense
            // 
            this.lnklblShowLicense.AutoSize = true;
            this.lnklblShowLicense.Enabled = false;
            this.lnklblShowLicense.Location = new System.Drawing.Point(180, 852);
            this.lnklblShowLicense.Name = "lnklblShowLicense";
            this.lnklblShowLicense.Size = new System.Drawing.Size(102, 20);
            this.lnklblShowLicense.TabIndex = 30;
            this.lnklblShowLicense.TabStop = true;
            this.lnklblShowLicense.Text = "Show license";
            this.lnklblShowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblShowLicense_LinkClicked);
            // 
            // lnklblLicensesHistory
            // 
            this.lnklblLicensesHistory.AutoSize = true;
            this.lnklblLicensesHistory.Enabled = false;
            this.lnklblLicensesHistory.Location = new System.Drawing.Point(14, 851);
            this.lnklblLicensesHistory.Name = "lnklblLicensesHistory";
            this.lnklblLicensesHistory.Size = new System.Drawing.Size(160, 20);
            this.lnklblLicensesHistory.TabIndex = 29;
            this.lnklblLicensesHistory.TabStop = true;
            this.lnklblLicensesHistory.Text = "Show licenses history";
            this.lnklblLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblLicensesHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_DesktopApp.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(631, 824);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(133, 52);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.Enabled = false;
            this.btnDetain.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetain.Image = global::DVLD_DesktopApp.Properties.Resources.detainLicense;
            this.btnDetain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetain.Location = new System.Drawing.Point(776, 824);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(147, 52);
            this.btnDetain.TabIndex = 27;
            this.btnDetain.Text = "Detain";
            this.btnDetain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // ctrlDetainLicenseInfo1
            // 
            this.ctrlDetainLicenseInfo1.Location = new System.Drawing.Point(12, 624);
            this.ctrlDetainLicenseInfo1.Name = "ctrlDetainLicenseInfo1";
            this.ctrlDetainLicenseInfo1.Size = new System.Drawing.Size(810, 206);
            this.ctrlDetainLicenseInfo1.TabIndex = 21;
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(12, 74);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(922, 571);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 20;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 897);
            this.Controls.Add(this.lnklblShowLicense);
            this.Controls.Add(this.lnklblLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.ctrlDetainLicenseInfo1);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmDetainLicense";
            this.Text = "Detain license";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDetainLicense_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.Label lblTitle;
        private Controls.ctrlDetainLicenseInfo ctrlDetainLicenseInfo1;
        private System.Windows.Forms.LinkLabel lnklblShowLicense;
        private System.Windows.Forms.LinkLabel lnklblLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDetain;
    }
}