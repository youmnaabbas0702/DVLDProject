using DVLD_DesktopApp.Properties;
using DVLDBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopApp.People
{
    public partial class frmAddEditPerson : Form
    {
        public event Action OperationOccuredEventHandler;

        public delegate void PersonAddedDelegate(int personID);
        public event PersonAddedDelegate PersonAdded;
        
        private int _PersonID = -1;
        private clsPerson.enMode _Mode = clsPerson.enMode.AddNew;
        private bool _OperationOccured = false;
        private string picturesFolder = @"C:\DVLD-People-Images";

        public frmAddEditPerson()
        {
            InitializeComponent();
            _SetUp();
        }
        
        public frmAddEditPerson(int ID) : this()
        {
            _PersonID = ID;
            _Mode = clsPerson.enMode.Update;
            _LoadPersonInfo();
        }

        //setup
        private void _SetUp()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            cmbCountry.DataSource = clsCountry.GetAllCountries();

            cmbCountry.SelectedIndex = 0;
            txtNationalNo.Leave += ValidateUniqueNationalNo;
            dtpBirthDate.MaxDate = DateTime.Today.AddYears(-18);
            _SetPersonPicture(_GetGender());
        }

        private void _LoadPersonInfo()
        {
            clsPerson person = clsPerson.Find(_PersonID);
            if (person != null)
            {
                lblTitle.Text = "Update Person";
                lblPersonID.Text = person.PersonID.ToString();
                txtFName.Text = person.FirstName;
                txtSName.Text = person.SecondName;
                txtTName.Text = person.ThirdName;
                txtLName.Text = person.LastName;
                txtEmail.Text = person.Email;
                txtPhone.Text = person.Phone;
                txtNationalNo.Text = person.NationalNo;
                txtAddress.Text = person.Address;
                rbFemale.Checked = Convert.ToBoolean(person.Gender);
                cmbCountry.SelectedIndex = person.NationalityCountryID - 1;
                dtpBirthDate.Value = person.DateOfBirth;

                _SetPersonPicture(person.Gender);
                string fullPath = Path.Combine(picturesFolder, person.ImagePath);
                if (File.Exists(fullPath))
                {
                    pbImage.Image = Image.FromFile(fullPath);
                }
            }
        }

        //validations
        private void RequiredField_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(((TextBox)sender).Text))
            {
                epRequired.SetError((TextBox)sender, "This field is required");
            }
            else
                epRequired.SetError((TextBox)sender, "");
        }

        private void ValidateUniqueNationalNo(object sender, EventArgs e)
        {
            string selectedNationalNo = txtNationalNo.Text;
            if (clsPerson.IsPersonExist(selectedNationalNo))
            {
                epUniqueNationalNo.SetError((TextBox)sender, "This national number already exists");
            }
            else
                epUniqueNationalNo.SetError((TextBox)sender, "");
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!string.IsNullOrWhiteSpace(email))
            {
                // Validate only if something was entered
                bool isValid = Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);

                if (!isValid)
                {
                    epEmailValidate.SetError(txtEmail, "Please enter a valid email address.");
                }
                else
                {
                    epEmailValidate.SetError(txtEmail, "");
                }
            }
            else
            {
                epEmailValidate.SetError(txtEmail, "");
            }

        }

        private bool _CheckNonEmpty()
        {
            return !string.IsNullOrWhiteSpace(txtFName.Text) &&
       !string.IsNullOrWhiteSpace(txtSName.Text) &&
       !string.IsNullOrWhiteSpace(txtLName.Text) &&
       !string.IsNullOrWhiteSpace(txtAddress.Text) &&
       !string.IsNullOrWhiteSpace(txtNationalNo.Text) &&
       !string.IsNullOrWhiteSpace(txtPhone.Text);

        }

        //picture box
        private short _GetGender()
        {
            return rbFemale.Checked ? Convert.ToInt16(1) : Convert.ToInt16(0);
        }

        private void _SetPersonPicture(short Gender)
        {
            switch (Gender)
            {
                case 1:
                    pbImage.Image = Resources.FemaleImage;
                    break;
                default:
                    pbImage.Image = Resources.MaleImage;
                    break;
            }
            pbImage.Tag = 0;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = openFileDialog1.FileName;
                if(_Mode == clsPerson.enMode.Update)
                    pbImage.Tag = 2;
                else
                    pbImage.Tag = 1;
                llSetImage.Visible = false;
                btnRemoveImage.Visible = true;
            }
        }

        private string _SaveImage()
        {
            if (Convert.ToInt32(pbImage.Tag) == 0)
            {
                return "";
            }

            if (!Directory.Exists(picturesFolder))
                Directory.CreateDirectory(picturesFolder);

            string extension = ".jpg";
            if (pbImage.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                extension = ".png";
            else if (pbImage.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                extension = ".jpeg";

            string fileName = $"{Guid.NewGuid()}{extension}";
            string fullPath = Path.Combine(picturesFolder, fileName);

            pbImage.Image.Save(fullPath);

            return fileName;
        }
        
        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            _SetPersonPicture(_GetGender());
            llSetImage.Visible = true;
            btnRemoveImage.Visible = false;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt32(pbImage.Tag) == 0)
                _SetPersonPicture(_GetGender());
        }

        //person add\edit
        private bool _AddNewPerson()
        {
            clsPerson NewPerson = new clsPerson();
            NewPerson.NationalNo = txtNationalNo.Text.Trim();
            NewPerson.FirstName = txtFName.Text.Trim();
            NewPerson.SecondName = txtSName.Text.Trim();
            NewPerson.ThirdName = txtTName.Text.Trim();
            NewPerson.LastName = txtLName.Text.Trim();
            NewPerson.Gender = _GetGender();
            NewPerson.Email = txtEmail.Text.Trim();
            NewPerson.Phone = txtPhone.Text.Trim();
            
            if (Convert.ToInt32(pbImage.Tag) == 0)
                NewPerson.ImagePath = "";
            else
                NewPerson.ImagePath = _SaveImage();

            NewPerson.DateOfBirth = dtpBirthDate.Value;
            NewPerson.Address = txtAddress.Text.Trim();
            NewPerson.NationalityCountryID = cmbCountry.SelectedIndex + 1;
            if(NewPerson.Save())
            {
                _PersonID = NewPerson.PersonID;
                return true;
            }
            return false;
        }

        private bool _UpdatePerson()
        {
            clsPerson person = clsPerson.Find(_PersonID);
            person.NationalNo = txtNationalNo.Text.Trim();
            person.FirstName = txtFName.Text.Trim();
            person.SecondName = txtSName.Text.Trim();
            person.ThirdName = txtTName.Text.Trim();
            person.LastName = txtLName.Text.Trim();
            person.Gender = _GetGender();
            person.Email = txtEmail.Text.Trim();
            person.Phone = txtPhone.Text.Trim();

            if (Convert.ToInt32(pbImage.Tag) == 0)
                person.ImagePath = "";

            else if(Convert.ToInt32(pbImage.Tag) == 2)   
            {
                string oldImagePath = Path.Combine(picturesFolder, person.ImagePath);
                if (File.Exists(oldImagePath))
                {
                    try
                    {
                        File.Delete(oldImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting old image: {ex.Message}");
                    }
                }
                person.ImagePath = _SaveImage(); 
            }

            person.DateOfBirth = dtpBirthDate.Value;
            person.Address = txtAddress.Text.Trim();
            person.NationalityCountryID = cmbCountry.SelectedIndex + 1;
            
            return (person.Save());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_CheckNonEmpty())
            {
                MessageBox.Show("There are Unfilled fields.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (_Mode)
            {
                case clsPerson.enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        MessageBox.Show($"Person added successfully with ID = {_PersonID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _OperationOccured = true;
                        PersonAdded?.Invoke(_PersonID);
                        _Mode = clsPerson.enMode.Update;
                        _LoadPersonInfo();
                    } 
                    else
                        MessageBox.Show($"Failed to add person", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case clsPerson.enMode.Update:
                    if(_UpdatePerson())
                    {
                        MessageBox.Show($"Person with ID = {_PersonID} was updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _OperationOccured = true;
                    }
                    else
                        MessageBox.Show($"Failed to update person", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:
                    break;
            }
        }

        //on close
        private void _FireEvent()
        {
            if (_OperationOccured)
                OperationOccuredEventHandler?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _FireEvent();
            this.Close();
        }

        private void frmAddEditPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FireEvent();
        }

    }
}
