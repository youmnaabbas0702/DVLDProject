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
    public partial class frmReleaseDetainedLicense : Form
    {
        public event Action OperationOccuredEventHandler;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(660, 650);
            ctrlDriverLicenseInfoWithFilter1.LicenseSelected += LoadDetainInfo;
        }

        public frmReleaseDetainedLicense(int LicenseID) : this()
        {
            ctrlDriverLicenseInfoWithFilter1.LicenseSelected += LoadDetainInfo;
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(LicenseID);
        }

        private void LoadDetainInfo()
        {
            int licenseID = ctrlDriverLicenseInfoWithFilter1.LicenseID;
            if(clsDetainedLicense.IsLicenseDetained(licenseID))
            {
                int DetainID = clsDetainedLicense.GetDetainIDByLicenseID(licenseID);
                ctrlReleaseLicenseInfo1.SetDetainInfo(DetainID);
                btnRelease.Enabled = true;
                lnklblShowLicense.Enabled = true;
                lnklblLicensesHistory.Enabled = true;
            }
            else
                MessageBox.Show("This license is not detained.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            int licenseID = ctrlDriverLicenseInfoWithFilter1.LicenseID;
            clsDriver driver = clsDriver.Find(ctrlDriverLicenseInfoWithFilter1.DriverID);
            
            clsApplication app = new clsApplication();
            app.ApplicantPersonID = driver.PersonID;
            app.ApplicationDate = DateTime.Now;
            app.ApplicationTypeID = 5;
            app.PaidFees = clsApplicationType.Find(5).Fees;
            app.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            app.ApplicationStatus = 1;
            app.LastStatusDate = DateTime.Now;

            if(app.Save())
            {
                if (clsDetainedLicense.ReleaseLicense(licenseID, clsGlobalSettings.CurrentUser.UserID, app.ApplicationID))
                {
                    clsLicense license = clsLicense.Find(licenseID);
                    if (license.Activate())
                    {
                        MessageBox.Show($"License released successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ctrlReleaseLicenseInfo1.SetAppID(app.ApplicationID);
                        app.ApplicationStatus = 3;
                        app.LastStatusDate = DateTime.Now;
                        app.Save();
                        return;
                    }
                }
            }
            MessageBox.Show("Failed to release license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmReleaseLicense_FormClosing(object sender, FormClosingEventArgs e)
        {
            OperationOccuredEventHandler?.Invoke();
        }

    }
}
