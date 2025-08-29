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
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        private string picturesFolder = @"C:\DVLD-People-Images";

        public ctrlInternationalLicenseInfo()
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

        public void LoadLicenseInfo(int licenseID)
        {
            DataRow license = clsInternationalLicense.GetLicenseDetails(licenseID);

            if (license != null)
            {
                lblName.Text = license["Name"].ToString();
                lblIntLicenseID.Text = license["IntLicenseID"].ToString();
                lblAppID.Text = license["ApplicationID"].ToString();
                lblLicenseID.Text = license["LicenseID"].ToString();
                lblIsActive.Text = license["IsActive"].ToString();
                blNationalNo.Text = license["NationalNo"].ToString();

                lblDateOfBirth.Text = Convert.ToDateTime(license["DateOfBirth"]).ToString("dd/MM/yyyy");

                blDriverID.Text = license["DriverID"].ToString();

                lblIssueDate.Text = Convert.ToDateTime(license["IssueDate"]).ToString("dd/MM/yyyy");
                lblExpirationDate.Text = Convert.ToDateTime(license["ExpirationDate"]).ToString("dd/MM/yyyy");


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
