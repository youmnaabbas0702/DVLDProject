using DVLDBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopApp.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public event Action LicenseSelected;

        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public int LicenseID
        {
            get
            {
                return ctrlDriverLicenseInfo1.LicenseID;
            }
        }

        public int DriverID
        {
            get
            {
                return ctrlDriverLicenseInfo1.DriverID;
            }
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // prevent the character from being entered
            }
        }

        public void LoadLicenseInfo(int licenseID)
        {
            clsLicense license = clsLicense.Find(licenseID);
            ctrlDriverLicenseInfo1.AppID = license.ApplicationID;
            ctrlDriverLicenseInfo1.LoadLicenseInfo();
            gpFilter.Enabled = false;
            LicenseSelected?.Invoke();

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFind.Text))
            {
                MessageBox.Show("Please write something in the search text");
                return;
            }

            clsLicense license = clsLicense.Find(Convert.ToInt32(txtFind.Text));

            if (license != null)
            {
                ctrlDriverLicenseInfo1.AppID = license.ApplicationID;
                ctrlDriverLicenseInfo1.LoadLicenseInfo();
                LicenseSelected?.Invoke();
            }
            else
                MessageBox.Show("License does not exist in the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
