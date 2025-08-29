namespace DVLD_DesktopApp.Controls
{
    partial class ctrlPersonCardWithFilter
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.cmbFind = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlPersonCard1 = new DVLD_DesktopApp.Controls.ctrlPersonCard();
            this.gpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpFilter
            // 
            this.gpFilter.Controls.Add(this.btnAdd);
            this.gpFilter.Controls.Add(this.btnFind);
            this.gpFilter.Controls.Add(this.txtFind);
            this.gpFilter.Controls.Add(this.cmbFind);
            this.gpFilter.Controls.Add(this.label2);
            this.gpFilter.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpFilter.Location = new System.Drawing.Point(0, 9);
            this.gpFilter.Name = "gpFilter";
            this.gpFilter.Size = new System.Drawing.Size(789, 95);
            this.gpFilter.TabIndex = 1;
            this.gpFilter.TabStop = false;
            this.gpFilter.Text = "Filter";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::DVLD_DesktopApp.Properties.Resources.personAdd;
            this.btnAdd.Location = new System.Drawing.Point(628, 43);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 46);
            this.btnAdd.TabIndex = 50;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::DVLD_DesktopApp.Properties.Resources.personSearch;
            this.btnFind.Location = new System.Drawing.Point(566, 43);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(56, 46);
            this.btnFind.TabIndex = 49;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(331, 50);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(219, 31);
            this.txtFind.TabIndex = 48;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // cmbFind
            // 
            this.cmbFind.FormattingEnabled = true;
            this.cmbFind.Items.AddRange(new object[] {
            "PersonID",
            "National No"});
            this.cmbFind.Location = new System.Drawing.Point(98, 43);
            this.cmbFind.Name = "cmbFind";
            this.cmbFind.Size = new System.Drawing.Size(215, 37);
            this.cmbFind.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 46;
            this.label2.Text = "Find By:";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(0, 116);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.PersonID = 0;
            this.ctrlPersonCard1.Size = new System.Drawing.Size(802, 362);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpFilter);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(809, 478);
            this.gpFilter.ResumeLayout(false);
            this.gpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.GroupBox gpFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFind;
    }
}
