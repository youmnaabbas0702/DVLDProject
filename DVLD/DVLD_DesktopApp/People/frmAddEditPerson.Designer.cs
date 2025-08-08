namespace DVLD_DesktopApp.People
{
    partial class frmAddEditPerson
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.llSetImage = new System.Windows.Forms.LinkLabel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtNationalNo = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtTName = new System.Windows.Forms.TextBox();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.epRequired = new System.Windows.Forms.ErrorProvider(this.components);
            this.epUniqueNationalNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.epEmailValidate = new System.Windows.Forms.ErrorProvider(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRequired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epUniqueNationalNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEmailValidate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gill Sans MT", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(256, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(219, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Person";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Person ID: ";
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Location = new System.Drawing.Point(138, 51);
            this.lblPersonID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(51, 23);
            this.lblPersonID.TabIndex = 2;
            this.lblPersonID.Text = "[NA]";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRemoveImage);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.rbFemale);
            this.panel1.Controls.Add(this.rbMale);
            this.panel1.Controls.Add(this.cmbCountry);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.dtpBirthDate);
            this.panel1.Controls.Add(this.llSetImage);
            this.panel1.Controls.Add(this.pbImage);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.txtNationalNo);
            this.panel1.Controls.Add(this.txtLName);
            this.panel1.Controls.Add(this.txtTName);
            this.panel1.Controls.Add(this.txtSName);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFName);
            this.panel1.Location = new System.Drawing.Point(14, 89);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 314);
            this.panel1.TabIndex = 3;
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveImage.Location = new System.Drawing.Point(617, 201);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(70, 32);
            this.btnRemoveImage.TabIndex = 45;
            this.btnRemoveImage.Text = "remove";
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Visible = false;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemale.Location = new System.Drawing.Point(214, 122);
            this.rbFemale.Margin = new System.Windows.Forms.Padding(2);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(82, 27);
            this.rbFemale.TabIndex = 33;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.Location = new System.Drawing.Point(123, 122);
            this.rbMale.Margin = new System.Windows.Forms.Padding(2);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(67, 27);
            this.rbMale.TabIndex = 32;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // cmbCountry
            // 
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(419, 159);
            this.cmbCountry.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(119, 31);
            this.cmbCountry.TabIndex = 31;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(420, 121);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(119, 26);
            this.txtPhone.TabIndex = 30;
            this.txtPhone.Leave += new System.EventHandler(this.RequiredField_Leave);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(420, 86);
            this.dtpBirthDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(119, 26);
            this.dtpBirthDate.TabIndex = 29;
            // 
            // llSetImage
            // 
            this.llSetImage.AutoSize = true;
            this.llSetImage.Location = new System.Drawing.Point(544, 204);
            this.llSetImage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llSetImage.Name = "llSetImage";
            this.llSetImage.Size = new System.Drawing.Size(87, 23);
            this.llSetImage.TabIndex = 28;
            this.llSetImage.TabStop = true;
            this.llSetImage.Text = "Set Image";
            this.llSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetImage_LinkClicked);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(128, 159);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(119, 26);
            this.txtEmail.TabIndex = 26;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(128, 201);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(398, 61);
            this.txtAddress.TabIndex = 25;
            this.txtAddress.Leave += new System.EventHandler(this.RequiredField_Leave);
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.Location = new System.Drawing.Point(128, 86);
            this.txtNationalNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.Size = new System.Drawing.Size(119, 26);
            this.txtNationalNo.TabIndex = 24;
            this.txtNationalNo.Leave += new System.EventHandler(this.RequiredField_Leave);
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(568, 47);
            this.txtLName.Margin = new System.Windows.Forms.Padding(2);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(119, 26);
            this.txtLName.TabIndex = 23;
            this.txtLName.Leave += new System.EventHandler(this.RequiredField_Leave);
            // 
            // txtTName
            // 
            this.txtTName.Location = new System.Drawing.Point(422, 47);
            this.txtTName.Margin = new System.Windows.Forms.Padding(2);
            this.txtTName.Name = "txtTName";
            this.txtTName.Size = new System.Drawing.Size(119, 26);
            this.txtTName.TabIndex = 22;
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(275, 45);
            this.txtSName.Margin = new System.Windows.Forms.Padding(2);
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(119, 26);
            this.txtSName.TabIndex = 21;
            this.txtSName.Leave += new System.EventHandler(this.RequiredField_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 47);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 23);
            this.label14.TabIndex = 20;
            this.label14.Text = "Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(309, 161);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 23);
            this.label13.TabIndex = 19;
            this.label13.Text = "Country:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(323, 121);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 23);
            this.label12.TabIndex = 18;
            this.label12.Text = "Phone:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 121);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 23);
            this.label11.TabIndex = 17;
            this.label11.Text = "Gender:";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(2, 75);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 74);
            this.label10.TabIndex = 16;
            this.label10.Text = "National\r\nNo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(305, 20);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 23);
            this.label9.TabIndex = 15;
            this.label9.Text = "Second";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(458, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Third";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(609, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Last";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(168, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "First";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 201);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 159);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Date of Birth:";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(128, 47);
            this.txtFName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(119, 26);
            this.txtFName.TabIndex = 0;
            this.txtFName.Leave += new System.EventHandler(this.RequiredField_Leave);
            // 
            // epRequired
            // 
            this.epRequired.ContainerControl = this;
            // 
            // epUniqueNationalNo
            // 
            this.epUniqueNationalNo.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // epEmailValidate
            // 
            this.epEmailValidate.ContainerControl = this;
            // 
            // label15
            // 
            this.label15.Image = global::DVLD_DesktopApp.Properties.Resources.id;
            this.label15.Location = new System.Drawing.Point(98, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 35);
            this.label15.TabIndex = 4;
            // 
            // label24
            // 
            this.label24.Image = global::DVLD_DesktopApp.Properties.Resources.Nationality;
            this.label24.Location = new System.Drawing.Point(390, 159);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(25, 33);
            this.label24.TabIndex = 44;
            // 
            // label23
            // 
            this.label23.Image = global::DVLD_DesktopApp.Properties.Resources.Phone;
            this.label23.Location = new System.Drawing.Point(384, 121);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(33, 33);
            this.label23.TabIndex = 43;
            // 
            // label22
            // 
            this.label22.Image = global::DVLD_DesktopApp.Properties.Resources.BirthDate;
            this.label22.Location = new System.Drawing.Point(388, 75);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 42);
            this.label22.TabIndex = 42;
            // 
            // label17
            // 
            this.label17.Image = global::DVLD_DesktopApp.Properties.Resources.address;
            this.label17.Location = new System.Drawing.Point(93, 202);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 33);
            this.label17.TabIndex = 41;
            // 
            // label21
            // 
            this.label21.Image = global::DVLD_DesktopApp.Properties.Resources.Email;
            this.label21.Location = new System.Drawing.Point(93, 152);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(25, 33);
            this.label21.TabIndex = 40;
            // 
            // label20
            // 
            this.label20.Image = global::DVLD_DesktopApp.Properties.Resources.Male;
            this.label20.Location = new System.Drawing.Point(98, 116);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 33);
            this.label20.TabIndex = 38;
            // 
            // label19
            // 
            this.label19.Image = global::DVLD_DesktopApp.Properties.Resources.Female;
            this.label19.Location = new System.Drawing.Point(191, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 33);
            this.label19.TabIndex = 37;
            // 
            // label18
            // 
            this.label18.Image = global::DVLD_DesktopApp.Properties.Resources.id;
            this.label18.Location = new System.Drawing.Point(84, 84);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 35);
            this.label18.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.Image = global::DVLD_DesktopApp.Properties.Resources.PersonName;
            this.label16.Location = new System.Drawing.Point(89, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 28);
            this.label16.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_DesktopApp.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(411, 273);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 39);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_DesktopApp.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(291, 273);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 39);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbImage
            // 
            this.pbImage.Image = global::DVLD_DesktopApp.Properties.Resources.MaleImage;
            this.pbImage.Location = new System.Drawing.Point(568, 88);
            this.pbImage.Margin = new System.Windows.Forms.Padding(2);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(119, 108);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 27;
            this.pbImage.TabStop = false;
            this.pbImage.Tag = "0";
            // 
            // frmAddEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 416);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Gill Sans MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAddEditPerson";
            this.Text = "Add\\Edit Person";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddEditPerson_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRequired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epUniqueNationalNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEmailValidate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtNationalNo;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtTName;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.LinkLabel llSetImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ErrorProvider epRequired;
        private System.Windows.Forms.ErrorProvider epUniqueNationalNo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.ErrorProvider epEmailValidate;
    }
}