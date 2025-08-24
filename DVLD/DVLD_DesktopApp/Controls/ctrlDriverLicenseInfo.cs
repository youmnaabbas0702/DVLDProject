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
        public int LocalLicenseAppID { get; set; } = 0;
        public int AppID { get; set; } = 0;

        private string picturesFolder = @"C:\DVLD-People-Images";

        public int LicenseID
        {
            get
            {
                return Convert.ToInt32(lblLicenseID.Text);
            }
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

        public void LoadLicenseInfo()
        {
            if(LocalLicenseAppID != 0)
            {
                clsLocalLicenseApplication localapp = clsLocalLicenseApplication.Find(LocalLicenseAppID);
                if (localapp != null)
                {
                    AppID = localapp.ApplicationID;
                }
            }
            DataRow license = clsLicense.GetLicenseDetails(AppID);

            if (license != null)
            {
                lblClass.Text = license["ClassName"].ToString();
                lblName.Text = license["Name"].ToString();
                lblLicenseID.Text = license["LicenseID"].ToString();
                lblIsActive.Text = license["IsActive"].ToString();
                lblIsDetained.Text = license["IsDetained"].ToString();
                blNationalNo.Text = license["NationalNo"].ToString();

                lblDateOfBirth.Text = Convert.ToDateTime(license["DateOfBirth"]).ToString("dd/MM/yyyy");

                blDriverID.Text = license["DriverID"].ToString();

                lblIssueDate.Text = Convert.ToDateTime(license["IssueDate"]).ToString("dd/MM/yyyy");
                lblExpirationDate.Text = Convert.ToDateTime(license["ExpirationDate"]).ToString("dd/MM/yyyy");

                lblIssueReason.Text = license["IssueReason"].ToString();

                if (String.IsNullOrWhiteSpace(license["Notes"].ToString()))
                {
                    lblNotes.Text = "No notes";
                }
                else
                    lblNotes.Text = license["Notes"].ToString();

                short gender = Convert.ToInt16(license["Gendor"]);
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
                string fullPath = Path.Combine(picturesFolder, license["ImagePath"].ToString());
                if (File.Exists(fullPath))
                {
                    pbImage.Image = Image.FromFile(fullPath);
                }
            }
        }
    }
}
