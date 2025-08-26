using DVLD_DesktopApp.Controls;
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

namespace DVLD_DesktopApp.Licenses
{
    public partial class frmDetainLicense : Form
    {
        public event Action OperationOccuredEventHandler;

        public frmDetainLicense()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(660, 630);
            ctrlDriverLicenseInfoWithFilter1.LicenseSelected += LoadDetainInfo;
        }

        private void LoadDetainInfo()
        {
            ctrlDetainLicenseInfo1.SetLicenseID(ctrlDriverLicenseInfoWithFilter1.LicenseID);
            btnDetain.Enabled = true;
            lnklblShowLicense.Enabled = true;
            lnklblLicensesHistory.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            int licenseID = ctrlDriverLicenseInfoWithFilter1.LicenseID;

            if (clsDetainedLicense.IsLicenseDetained(licenseID))
            {
                MessageBox.Show("This license is already detained.", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int detainID = clsDetainedLicense.DetainLicense(licenseID,ctrlDetainLicenseInfo1.FineFees,clsGlobalSettings.CurrentUser.UserID);

            if (detainID != -1)
            {
                clsLicense license = clsLicense.Find(licenseID);
                if (license.Deactivate())
                {
                    MessageBox.Show($"License detained successfully. Detain ID: {detainID}","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctrlDetainLicenseInfo1.SetDetainID(detainID);
                    return;
                }
            }
                MessageBox.Show("Failed to detain license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnklblShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(ctrlDriverLicenseInfoWithFilter1.LicenseID);
            frm.ShowDialog();
        }

        private void lnklblLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsDriver driver = clsDriver.Find(ctrlDriverLicenseInfoWithFilter1.DriverID);

            if (driver != null)
            {
                frmLicenseHistory frm = new frmLicenseHistory(driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void frmDetainLicense_FormClosing(object sender, FormClosingEventArgs e)
        {
            OperationOccuredEventHandler?.Invoke();
        }
    }
}
