namespace DVLD_DesktopApp.Licenses
{
    partial class frmReleaseDetainedLicense
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
            this.btnRelease = new System.Windows.Forms.Button();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_DesktopApp.Controls.ctrlDriverLicenseInfoWithFilter();
            this.ctrlReleaseLicenseInfo1 = new DVLD_DesktopApp.Controls.ctrlReleaseLicenseInfo();
            this.SuspendLayout();
            // 
            // lnklblShowLicense
            // 
            this.lnklblShowLicense.AutoSize = true;
            this.lnklblShowLicense.Enabled = false;
            this.lnklblShowLicense.Location = new System.Drawing.Point(181, 891);
            this.lnklblShowLicense.Name = "lnklblShowLicense";
            this.lnklblShowLicense.Size = new System.Drawing.Size(102, 20);
            this.lnklblShowLicense.TabIndex = 37;
            this.lnklblShowLicense.TabStop = true;
            this.lnklblShowLicense.Text = "Show license";
            this.lnklblShowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblShowLicense_LinkClicked);
            // 
            // lnklblLicensesHistory
            // 
            this.lnklblLicensesHistory.AutoSize = true;
            this.lnklblLicensesHistory.Enabled = false;
            this.lnklblLicensesHistory.Location = new System.Drawing.Point(15, 890);
            this.lnklblLicensesHistory.Name = "lnklblLicensesHistory";
            this.lnklblLicensesHistory.Size = new System.Drawing.Size(160, 20);
            this.lnklblLicensesHistory.TabIndex = 36;
            this.lnklblLicensesHistory.TabStop = true;
            this.lnklblLicensesHistory.Text = "Show licenses history";
            this.lnklblLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblLicensesHistory_LinkClicked);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gill Sans MT", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(312, 17);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(312, 39);
            this.lblTitle.TabIndex = 31;
            this.lblTitle.Text = "Release detained license";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_DesktopApp.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(635, 875);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(133, 52);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Enabled = false;
            this.btnRelease.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.Image = global::DVLD_DesktopApp.Properties.Resources.ReleaseLicense;
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelease.Location = new System.Drawing.Point(780, 875);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(147, 52);
            this.btnRelease.TabIndex = 34;
            this.btnRelease.Text = "Release";
            this.btnRelease.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(13, 59);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(922, 571);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 32;
            // 
            // ctrlReleaseLicenseInfo1
            // 
            this.ctrlReleaseLicenseInfo1.Location = new System.Drawing.Point(12, 605);
            this.ctrlReleaseLicenseInfo1.Name = "ctrlReleaseLicenseInfo1";
            this.ctrlReleaseLicenseInfo1.Size = new System.Drawing.Size(830, 258);
            this.ctrlReleaseLicenseInfo1.TabIndex = 38;
            // 
            // frmReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 931);
            this.Controls.Add(this.ctrlReleaseLicenseInfo1);
            this.Controls.Add(this.lnklblShowLicense);
            this.Controls.Add(this.lnklblLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmReleaseDetainedLicense";
            this.Text = "Release detained license";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReleaseLicense_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnklblShowLicense;
        private System.Windows.Forms.LinkLabel lnklblLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRelease;
        private Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.Label lblTitle;
        private Controls.ctrlReleaseLicenseInfo ctrlReleaseLicenseInfo1;
    }
}