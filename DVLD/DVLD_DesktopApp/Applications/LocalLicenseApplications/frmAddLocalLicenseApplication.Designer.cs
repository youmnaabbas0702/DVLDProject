namespace DVLD_DesktopApp.Applications.LocalLicenseApplications
{
    partial class frmAddLocalLicenseApplication
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpAppInfo = new System.Windows.Forms.TabPage();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLicenseAppID = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.UserID = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new DVLD_DesktopApp.Controls.ctrlPersonCardWithFilter();
            this.tabControl1.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.tpAppInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gill Sans MT", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(282, 26);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(462, 39);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "New local driving license application";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPersonInfo);
            this.tabControl1.Controls.Add(this.tpAppInfo);
            this.tabControl1.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(47, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(911, 633);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.Controls.Add(this.btnNext);
            this.tpPersonInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tpPersonInfo.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 32);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonInfo.Size = new System.Drawing.Size(903, 597);
            this.tpPersonInfo.TabIndex = 0;
            this.tpPersonInfo.Text = "Person Info";
            this.tpPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLD_DesktopApp.Properties.Resources.nextTap;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(765, 544);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(109, 35);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpAppInfo
            // 
            this.tpAppInfo.Controls.Add(this.lblCreatedBy);
            this.tpAppInfo.Controls.Add(this.label10);
            this.tpAppInfo.Controls.Add(this.label9);
            this.tpAppInfo.Controls.Add(this.lblAppFees);
            this.tpAppInfo.Controls.Add(this.label7);
            this.tpAppInfo.Controls.Add(this.label6);
            this.tpAppInfo.Controls.Add(this.cmbLicenseClasses);
            this.tpAppInfo.Controls.Add(this.label5);
            this.tpAppInfo.Controls.Add(this.label4);
            this.tpAppInfo.Controls.Add(this.lblApplicationDate);
            this.tpAppInfo.Controls.Add(this.label3);
            this.tpAppInfo.Controls.Add(this.label1);
            this.tpAppInfo.Controls.Add(this.lblLicenseAppID);
            this.tpAppInfo.Controls.Add(this.label15);
            this.tpAppInfo.Controls.Add(this.UserID);
            this.tpAppInfo.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpAppInfo.Location = new System.Drawing.Point(4, 32);
            this.tpAppInfo.Name = "tpAppInfo";
            this.tpAppInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpAppInfo.Size = new System.Drawing.Size(903, 597);
            this.tpAppInfo.TabIndex = 1;
            this.tpAppInfo.Text = "Application Info";
            this.tpAppInfo.UseVisualStyleBackColor = true;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(284, 311);
            this.lblCreatedBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(44, 23);
            this.lblCreatedBy.TabIndex = 73;
            this.lblCreatedBy.Text = "[NA]";
            // 
            // label10
            // 
            this.label10.Image = global::DVLD_DesktopApp.Properties.Resources.userLogin;
            this.label10.Location = new System.Drawing.Point(235, 300);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 38);
            this.label10.TabIndex = 72;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(131, 311);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 23);
            this.label9.TabIndex = 71;
            this.label9.Text = "Created by:";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.Location = new System.Drawing.Point(284, 255);
            this.lblAppFees.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(26, 23);
            this.lblAppFees.TabIndex = 70;
            this.lblAppFees.Text = "15";
            // 
            // label7
            // 
            this.label7.Image = global::DVLD_DesktopApp.Properties.Resources.AppFees;
            this.label7.Location = new System.Drawing.Point(235, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 38);
            this.label7.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(90, 253);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 23);
            this.label6.TabIndex = 68;
            this.label6.Text = "Application Fees:";
            // 
            // cmbLicenseClasses
            // 
            this.cmbLicenseClasses.FormattingEnabled = true;
            this.cmbLicenseClasses.Location = new System.Drawing.Point(284, 191);
            this.cmbLicenseClasses.Name = "cmbLicenseClasses";
            this.cmbLicenseClasses.Size = new System.Drawing.Size(290, 31);
            this.cmbLicenseClasses.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.Image = global::DVLD_DesktopApp.Properties.Resources.licenseClass;
            this.label5.Location = new System.Drawing.Point(235, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 38);
            this.label5.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(120, 195);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 23);
            this.label4.TabIndex = 65;
            this.label4.Text = "License class:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(284, 135);
            this.lblApplicationDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(44, 23);
            this.lblApplicationDate.TabIndex = 64;
            this.lblApplicationDate.Text = "[NA]";
            // 
            // label3
            // 
            this.label3.Image = global::DVLD_DesktopApp.Properties.Resources.BirthDate;
            this.label3.Location = new System.Drawing.Point(235, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 38);
            this.label3.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 23);
            this.label1.TabIndex = 62;
            this.label1.Text = "Application date:";
            // 
            // lblLicenseAppID
            // 
            this.lblLicenseAppID.AutoSize = true;
            this.lblLicenseAppID.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseAppID.Location = new System.Drawing.Point(284, 79);
            this.lblLicenseAppID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLicenseAppID.Name = "lblLicenseAppID";
            this.lblLicenseAppID.Size = new System.Drawing.Size(44, 23);
            this.lblLicenseAppID.TabIndex = 61;
            this.lblLicenseAppID.Text = "[NA]";
            // 
            // label15
            // 
            this.label15.Image = global::DVLD_DesktopApp.Properties.Resources.id;
            this.label15.Location = new System.Drawing.Point(235, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 38);
            this.label15.TabIndex = 58;
            // 
            // UserID
            // 
            this.UserID.AutoSize = true;
            this.UserID.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserID.Location = new System.Drawing.Point(72, 79);
            this.UserID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(157, 23);
            this.UserID.TabIndex = 57;
            this.UserID.Text = "D.L.Application ID: ";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_DesktopApp.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(727, 726);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 47);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_DesktopApp.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(842, 726);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 47);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.PersonID = 0;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(905, 538);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // frmAddLocalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 808);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAddLocalLicenseApplication";
            this.Text = "New local driving license application";
            this.tabControl1.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.tpAppInfo.ResumeLayout(false);
            this.tpAppInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.Button btnNext;
        private Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.TabPage tpAppInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLicenseAppID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label UserID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbLicenseClasses;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label10;
    }
}