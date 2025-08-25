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
    public partial class frmReplaceLicense : Form
    {
        private int _ReplacedLicenseID = 0;
        public frmReplaceLicense()
        {
            InitializeComponent();
            rbDamaged.Checked = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(730, 650);
            ctrlDriverLicenseInfoWithFilter1.LicenseSelected += LoadApplicationInfo;

        }

        private void LoadApplicationInfo()
        {
            ctrlReplaceLicenseApp1.InitializeApplicationInfo(ctrlDriverLicenseInfoWithFilter1.LicenseID);
            btnIssue.Enabled = true;
            lnklblLicensesHistory.Enabled = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsLicense oldLicense = clsLicense.Find(ctrlDriverLicenseInfoWithFilter1.LicenseID);
            if (!oldLicense.IsActive)
            {
                MessageBox.Show("Local license should be active.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int driverID = ctrlDriverLicenseInfoWithFilter1.DriverID;

            clsApplication app = new clsApplication();

            app.ApplicantPersonID = clsDriver.Find(driverID).PersonID;
            app.ApplicationDate = DateTime.Now;
            app.ApplicationStatus = 1;
            app.LastStatusDate = DateTime.Now;

            int AppType = rbDamaged.Checked ? 4 : 3;
            app.ApplicationTypeID = AppType;
            app.PaidFees = clsApplicationType.Find(AppType).Fees;
            app.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            if (app.Save())
            {
                int LicenseValidity = clsLicenseClass.Find(oldLicense.LicenseClass).DefaultValidityLength;

                clsLicense ReplacedLicense = new clsLicense();
                ReplacedLicense.ApplicationID = app.ApplicationID;
                ReplacedLicense.LicenseClass = oldLicense.LicenseClass;
                ReplacedLicense.IssueDate = oldLicense.IssueDate;
                ReplacedLicense.PaidFees = app.PaidFees;
                ReplacedLicense.IsActive = true;
                ReplacedLicense.IssueReason = (byte)AppType;
                ReplacedLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

                if (ReplacedLicense.Save())
                {
                    if (oldLicense.Deactivate())
                    {
                        MessageBox.Show($"License renewed successfully, new license ID = {ReplacedLicense.LicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ctrlReplaceLicenseApp1.SetReplacedLicenseInfo(app.ApplicationID, ReplacedLicense.LicenseID);
                        _ReplacedLicenseID = ReplacedLicense.LicenseID;
                        lnklblShowLicense.Enabled = true;
                        gpReplaceFor.Enabled = false;
                        return;
                    }
                }
            }

            MessageBox.Show("Failed to replace license.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnklblShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_ReplacedLicenseID);
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

        private void ReplaceCheckedChanged(object sender, EventArgs e)
        {
            int AppType = rbDamaged.Checked ? 4 : 3;
            ctrlReplaceLicenseApp1.SetReplaceType(AppType);
        }
    }
}
