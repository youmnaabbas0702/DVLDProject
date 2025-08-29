namespace DVLD_DesktopApp.Applications
{
    partial class frmRenewLicense
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
            this.lnklblShowLicense = new System.Windows.Forms.LinkLabel();
            this.lnklblLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.ctrlRenewLicenseApp1 = new DVLD_DesktopApp.Controls.ctrlRenewLicenseApp();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_DesktopApp.Controls.ctrlDriverLicenseInfoWithFilter();
            this.SuspendLayout();
            // 
            // lnklblShowLicense
            // 
            this.lnklblShowLicense.AutoSize = true;
            this.lnklblShowLicense.Enabled = false;
            this.lnklblShowLicense.Location = new System.Drawing.Point(996, 926);
            this.lnklblShowLicense.Name = "lnklblShowLicense";
            this.lnklblShowLicense.Size = new System.Drawing.Size(102, 20);
            this.lnklblShowLicense.TabIndex = 16;
            this.lnklblShowLicense.TabStop = true;
            this.lnklblShowLicense.Text = "Show license";
            this.lnklblShowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblShowLicense_LinkClicked);
            // 
            // lnklblLicensesHistory
            // 
            this.lnklblLicensesHistory.AutoSize = true;
            this.lnklblLicensesHistory.Enabled = false;
            this.lnklblLicensesHistory.Location = new System.Drawing.Point(938, 892);
            this.lnklblLicensesHistory.Name = "lnklblLicensesHistory";
            this.lnklblLicensesHistory.Size = new System.Drawing.Size(160, 20);
            this.lnklblLicensesHistory.TabIndex = 15;
            this.lnklblLicensesHistory.TabStop = true;
            this.lnklblLicensesHistory.Text = "Show licenses history";
            this.lnklblLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblLicensesHistory_LinkClicked);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gill Sans MT", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(382, 21);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(332, 39);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "Renew license application";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_DesktopApp.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(965, 843);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(133, 35);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.Enabled = false;
            this.btnRenew.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenew.Image = global::DVLD_DesktopApp.Properties.Resources.DrivingLicenseApps;
            this.btnRenew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenew.Location = new System.Drawing.Point(965, 802);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(133, 35);
            this.btnRenew.TabIndex = 13;
            this.btnRenew.Text = "Renew";
            this.btnRenew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // ctrlRenewLicenseApp1
            // 
            this.ctrlRenewLicenseApp1.Location = new System.Drawing.Point(10, 607);
            this.ctrlRenewLicenseApp1.Name = "ctrlRenewLicenseApp1";
            this.ctrlRenewLicenseApp1.Size = new System.Drawing.Size(905, 391);
            this.ctrlRenewLicenseApp1.TabIndex = 19;
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(13, 63);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(922, 571);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 18;
            // 
            // frmRenewLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 1002);
            this.Controls.Add(this.ctrlRenewLicenseApp1);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lnklblShowLicense);
            this.Controls.Add(this.lnklblLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRenew);
            this.Name = "frmRenewLicense";
            this.Text = "Renew license";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnklblShowLicense;
        private System.Windows.Forms.LinkLabel lnklblLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRenew;
        private Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.Label lblTitle;
        private Controls.ctrlRenewLicenseApp ctrlRenewLicenseApp1;
    }
}