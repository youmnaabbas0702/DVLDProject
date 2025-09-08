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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopApp.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {

        private string picturesFolder = @"C:\DVLD-People-Images";

        private int _LicenseID;

        private clsLicense _License;
        public int LicenseID
        {
            get
            {
                return Convert.ToInt32(lblLicenseID.Text);
            }
        }

        public clsLicense SelectedLicenseInfo
        {
            get { return _License; }
        }

        public int DriverID
        {
            get
            {
                return Convert.ToInt32(blDriverID.Text);
            }
        }

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
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
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(LicenseID);


            if (_License != null)
            {
                lblClass.Text = _License.LicenseClassInfo.ClassName;
                lblName.Text = _License.DriverInfo.PersonInfo.FullName();
                lblLicenseID.Text = _License.LicenseID.ToString();
                lblIsActive.Text = _License.IsActive ? "Yes" : "No";
                lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
                blNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;

                lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MM/yyyy");

                blDriverID.Text = _License.DriverID.ToString();

                lblIssueDate.Text = _License.IssueDate.ToString("dd/MM/yyyy");
                lblExpirationDate.Text = _License.ExpirationDate.ToString("dd/MM/yyyy");

                lblIssueReason.Text = _License.IssueReasonText;

                if (String.IsNullOrWhiteSpace(_License.Notes))
                {
                    lblNotes.Text = "No notes";
                }
                else
                    lblNotes.Text = _License.Notes;

                short gender = Convert.ToInt16(_License.DriverInfo.PersonInfo.Gender);
                if (gender == 0)
                {
                    lblGender.Text = "Male";
                    lblGenderIcon.Image = Resources.Male;
                }
                else
                {
                    lblGender.Text = "Female";
                    lblGenderIcon.Image = Resources.Female;
                }

                _SetPersonPicture(gender);
                string fullPath = Path.Combine(picturesFolder, _License.DriverInfo.PersonInfo.ImagePath);
                if (File.Exists(fullPath))
                {
                    pbImage.Image = Image.FromFile(fullPath);
                }
            }
        }
    }
}
