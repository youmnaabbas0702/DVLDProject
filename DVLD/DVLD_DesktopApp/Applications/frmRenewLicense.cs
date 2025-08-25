using DVLD_DesktopApp.Controls;
using DVLD_DesktopApp.Licenses;
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

namespace DVLD_DesktopApp.Applications
{
    public partial class frmRenewLicense : Form
    {
        private int _NewLicenseAppID = -1;
        public frmRenewLicense()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(780, 680);
            ctrlDriverLicenseInfoWithFilter1.LicenseSelected += LoadApplicationInfo;

        }
        private void LoadApplicationInfo()
        {
            ctrlRenewLicenseApp1.InitializeApplicationInfo(ctrlDriverLicenseInfoWithFilter1.LicenseID);
            btnRenew.Enabled = true;
            lnklblLicensesHistory.Enabled = true;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            clsLicense oldLicense = clsLicense.Find(ctrlDriverLicenseInfoWithFilter1.LicenseID);
            if(oldLicense.ExpirationDate > DateTime.Today)
            {
                MessageBox.Show("License should be expired to renew it.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!oldLicense.IsActive)
            {
                MessageBox.Show("Local license should be active.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int driverID = ctrlDriverLicenseInfoWithFilter1.DriverID;

            clsApplication app = new clsApplication();

            app.ApplicantPersonID = clsDriver.Find(driverID).PersonID;
            app.ApplicationDate = DateTime.Now;
            app.ApplicationTypeID = 2;
            app.ApplicationStatus = 1;
            app.LastStatusDate = DateTime.Now;
            app.PaidFees = ctrlRenewLicenseApp1.TotalFees;
            app.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            if(app.Save())
            {
                int LicenseValidity = clsLicenseClass.Find(oldLicense.LicenseClass).DefaultValidityLength;

                clsLicense RenewedLicense = new clsLicense();
                RenewedLicense.ApplicationID = app.ApplicationID;
                RenewedLicense.LicenseClass = oldLicense.LicenseClass;
                RenewedLicense.IssueDate = DateTime.Now;
                RenewedLicense.Notes = ctrlRenewLicenseApp1.Notes;
                RenewedLicense.PaidFees = clsLicenseClass.Find(oldLicense.LicenseClass).ClassFees;
                RenewedLicense.IsActive = true;
                RenewedLicense.IssueReason = 2;
                RenewedLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

                if (RenewedLicense.Save())
                {
                    if(oldLicense.Deactivate())
                    {
                        MessageBox.Show($"License renewed successfully, new license ID = {RenewedLicense.LicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ctrlRenewLicenseApp1.SetRenewedLicenseInfo(app.ApplicationID, RenewedLicense.LicenseID);
                        _NewLicenseAppID = RenewedLicense.ApplicationID;
                        lnklblShowLicense.Enabled = true;
                        return;
                    }
                }
            }

            MessageBox.Show("Failed to renew license.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnklblShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(0, _NewLicenseAppID);
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
    }
}
