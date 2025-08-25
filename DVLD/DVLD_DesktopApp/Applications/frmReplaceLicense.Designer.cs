namespace DVLD_DesktopApp.Applications
{
    partial class frmReplaceLicense
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
            this.gpReplaceFor = new System.Windows.Forms.GroupBox();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.lnklblShowLicense = new System.Windows.Forms.LinkLabel();
            this.lnklblLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.ctrlReplaceLicenseApp1 = new DVLD_DesktopApp.Controls.ctrlReplaceLicenseApp();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_DesktopApp.Controls.ctrlDriverLicenseInfoWithFilter();
            this.gpReplaceFor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gill Sans MT", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(331, 25);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(348, 39);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Replace license application";
            // 
            // gpReplaceFor
            // 
            this.gpReplaceFor.Controls.Add(this.rbDamaged);
            this.gpReplaceFor.Controls.Add(this.rbLost);
            this.gpReplaceFor.Location = new System.Drawing.Point(830, 76);
            this.gpReplaceFor.Name = "gpReplaceFor";
            this.gpReplaceFor.Size = new System.Drawing.Size(179, 100);
            this.gpReplaceFor.TabIndex = 21;
            this.gpReplaceFor.TabStop = false;
            this.gpReplaceFor.Text = "Replacement for:";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Location = new System.Drawing.Point(6, 65);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(118, 24);
            this.rbLost.TabIndex = 0;
            this.rbLost.TabStop = true;
            this.rbLost.Text = "Lost license";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.ReplaceCheckedChanged);
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Location = new System.Drawing.Point(6, 29);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(157, 24);
            this.rbDamaged.TabIndex = 1;
            this.rbDamaged.TabStop = true;
            this.rbDamaged.Text = "Damaged license";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.ReplaceCheckedChanged);
            // 
            // lnklblShowLicense
            // 
            this.lnklblShowLicense.AutoSize = true;
            this.lnklblShowLicense.Enabled = false;
            this.lnklblShowLicense.Location = new System.Drawing.Point(192, 893);
            this.lnklblShowLicense.Name = "lnklblShowLicense";
            this.lnklblShowLicense.Size = new System.Drawing.Size(102, 20);
            this.lnklblShowLicense.TabIndex = 26;
            this.lnklblShowLicense.TabStop = true;
            this.lnklblShowLicense.Text = "Show license";
            this.lnklblShowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblShowLicense_LinkClicked);
            // 
            // lnklblLicensesHistory
            // 
            this.lnklblLicensesHistory.AutoSize = true;
            this.lnklblLicensesHistory.Enabled = false;
            this.lnklblLicensesHistory.Location = new System.Drawing.Point(26, 893);
            this.lnklblLicensesHistory.Name = "lnklblLicensesHistory";
            this.lnklblLicensesHistory.Size = new System.Drawing.Size(160, 20);
            this.lnklblLicensesHistory.TabIndex = 25;
            this.lnklblLicensesHistory.TabStop = true;
            this.lnklblLicensesHistory.Text = "Show licenses history";
            this.lnklblLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblLicensesHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_DesktopApp.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(753, 875);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(133, 35);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Enabled = false;
            this.btnIssue.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::DVLD_DesktopApp.Properties.Resources.DrivingLicenseApps;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(892, 875);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(117, 35);
            this.btnIssue.TabIndex = 23;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // ctrlReplaceLicenseApp1
            // 
            this.ctrlReplaceLicenseApp1.Location = new System.Drawing.Point(27, 618);
            this.ctrlReplaceLicenseApp1.Name = "ctrlReplaceLicenseApp1";
            this.ctrlReplaceLicenseApp1.Size = new System.Drawing.Size(912, 244);
            this.ctrlReplaceLicenseApp1.TabIndex = 22;
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(27, 67);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(922, 571);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 20;
            // 
            // frmReplaceLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 922);
            this.Controls.Add(this.lnklblShowLicense);
            this.Controls.Add(this.lnklblLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.ctrlReplaceLicenseApp1);
            this.Controls.Add(this.gpReplaceFor);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmReplaceLicense";
            this.Text = "Replace license";
            this.gpReplaceFor.ResumeLayout(false);
            this.gpReplaceFor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gpReplaceFor;
        private System.Windows.Forms.RadioButton rbDamaged;
        private System.Windows.Forms.RadioButton rbLost;
        private Controls.ctrlReplaceLicenseApp ctrlReplaceLicenseApp1;
        private System.Windows.Forms.LinkLabel lnklblShowLicense;
        private System.Windows.Forms.LinkLabel lnklblLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
    }
}