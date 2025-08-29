namespace DVLD_DesktopApp.ApplicationTypes
{
    partial class frmListApplicationTypes
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
            this.components = new System.ComponentModel.Container();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvAppTypes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateApplicationTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(144, 614);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(23, 29);
            this.lblRecordsCount.TabIndex = 25;
            this.lblRecordsCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 614);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 29);
            this.label3.TabIndex = 24;
            this.label3.Text = "# records:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_DesktopApp.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(648, 614);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 46);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvAppTypes
            // 
            this.dgvAppTypes.AllowUserToAddRows = false;
            this.dgvAppTypes.AllowUserToDeleteRows = false;
            this.dgvAppTypes.AllowUserToOrderColumns = true;
            this.dgvAppTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppTypes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAppTypes.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvAppTypes.Location = new System.Drawing.Point(44, 204);
            this.dgvAppTypes.Name = "dgvAppTypes";
            this.dgvAppTypes.ReadOnly = true;
            this.dgvAppTypes.RowHeadersWidth = 62;
            this.dgvAppTypes.RowTemplate.Height = 28;
            this.dgvAppTypes.Size = new System.Drawing.Size(746, 384);
            this.dgvAppTypes.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(220, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 33);
            this.label1.TabIndex = 21;
            this.label1.Text = "Manage application types";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_DesktopApp.Properties.Resources.manageAppTypes;
            this.pictureBox1.Location = new System.Drawing.Point(369, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateApplicationTypeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(270, 69);
            // 
            // updateApplicationTypeToolStripMenuItem
            // 
            this.updateApplicationTypeToolStripMenuItem.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateApplicationTypeToolStripMenuItem.Image = global::DVLD_DesktopApp.Properties.Resources.manageAppTypes;
            this.updateApplicationTypeToolStripMenuItem.Name = "updateApplicationTypeToolStripMenuItem";
            this.updateApplicationTypeToolStripMenuItem.Size = new System.Drawing.Size(269, 32);
            this.updateApplicationTypeToolStripMenuItem.Text = "Update application type";
            this.updateApplicationTypeToolStripMenuItem.Click += new System.EventHandler(this.updateApplicationTypeToolStripMenuItem_Click);
            // 
            // frmListApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 677);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvAppTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmListApplicationTypes";
            this.Text = "frmListApplicationTypes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvAppTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateApplicationTypeToolStripMenuItem;
    }
}