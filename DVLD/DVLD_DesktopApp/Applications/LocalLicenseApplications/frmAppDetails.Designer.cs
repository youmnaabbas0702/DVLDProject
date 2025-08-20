namespace DVLD_DesktopApp.Applications.LocalLicenseApplications
{
    partial class frmAppDetails
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
            this.ctrlLicenseAppDetails1 = new DVLD_DesktopApp.Controls.ctrlLicenseAppDetails();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlLicenseAppDetails1
            // 
            this.ctrlLicenseAppDetails1.LicenseAppID = 0;
            this.ctrlLicenseAppDetails1.Location = new System.Drawing.Point(12, 12);
            this.ctrlLicenseAppDetails1.Name = "ctrlLicenseAppDetails1";
            this.ctrlLicenseAppDetails1.Size = new System.Drawing.Size(816, 459);
            this.ctrlLicenseAppDetails1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_DesktopApp.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(708, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 47);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAppDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 532);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLicenseAppDetails1);
            this.Name = "frmAppDetails";
            this.Text = "frmAppDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlLicenseAppDetails ctrlLicenseAppDetails1;
        private System.Windows.Forms.Button btnClose;
    }
}