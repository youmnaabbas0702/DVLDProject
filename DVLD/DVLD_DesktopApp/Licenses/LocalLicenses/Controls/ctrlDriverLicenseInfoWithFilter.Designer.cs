namespace DVLD_DesktopApp.Controls
{
    partial class ctrlDriverLicenseInfoWithFilter
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
            this.gpFilter = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfo1 = new DVLD_DesktopApp.Controls.ctrlDriverLicenseInfo();
            this.gpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpFilter
            // 
            this.gpFilter.Controls.Add(this.btnFind);
            this.gpFilter.Controls.Add(this.txtFind);
            this.gpFilter.Controls.Add(this.label2);
            this.gpFilter.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpFilter.Location = new System.Drawing.Point(3, 12);
            this.gpFilter.Name = "gpFilter";
            this.gpFilter.Size = new System.Drawing.Size(789, 95);
            this.gpFilter.TabIndex = 2;
            this.gpFilter.TabStop = false;
            this.gpFilter.Text = "Filter";
            // 
            // btnFind
            // 
            this.btnFind.BackgroundImage = global::DVLD_DesktopApp.Properties.Resources.LicenseInfo;
            this.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFind.Location = new System.Drawing.Point(368, 35);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(44, 46);
            this.btnFind.TabIndex = 49;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(133, 42);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(219, 31);
            this.txtFind.TabIndex = 48;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 46;
            this.label2.Text = "LicenseID:";
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(3, 113);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(913, 453);
            this.ctrlDriverLicenseInfo1.TabIndex = 3;
            // 
            // ctrlDriverLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Controls.Add(this.gpFilter);
            this.Name = "ctrlDriverLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(922, 571);
            this.gpFilter.ResumeLayout(false);
            this.gpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpFilter;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label2;
        private ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
    }
}
