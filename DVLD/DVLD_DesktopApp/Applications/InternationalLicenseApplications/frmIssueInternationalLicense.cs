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

namespace DVLD_DesktopApp.Applications.InternationalLicenseApplications
{
    public partial class frmIssueInternationalLicense : Form
    {
        private int IntLicenseID = -1;
        public frmIssueInternationalLicense()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(630, 670);
            ctrlDriverLicenseInfoWithFilter1.LicenseSelected += LoadApplicationInfo;
        }

        public frmIssueInternationalLicense(int LocalLicenseID) : this()
        {
            ctrlDriverLicenseInfoWithFilter1.LicenseSelected += LoadApplicationInfo;
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(LocalLicenseID);
            btnIssue.Enabled = true;
            lnklblLicensesHistory.Enabled = true;
        }

        private void LoadApplicationInfo()
        {
            ctrlInternationalDriverInfo1.InitializeApplicationInfo(ctrlDriverLicenseInfoWithFilter1.LicenseID);
            btnIssue.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int IssueApplication()
        {
            clsDriver driver = clsDriver.Find(ctrlDriverLicenseInfoWithFilter1.DriverID);
            if (driver != null) 
            {
                clsApplication app = new clsApplication();
                app.ApplicantPersonID = driver.PersonID;
                app.ApplicationDate = DateTime.Now;
                app.ApplicationTypeID = 6;
                app.ApplicationStatus = 1;
                app.LastStatusDate = DateTime.Now;
                app.PaidFees = clsApplicationType.Find(6).Fees;
                app.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

                if(app.Save())
                {
                    return app.ApplicationID;
                }
            }
            return -1;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsLicense license = clsLicense.Find(ctrlDriverLicenseInfoWithFilter1.LicenseID);
            if (license != null)
            {
                if (license.LicenseClass != 3)
                {
                    MessageBox.Show("International license can be issued only for class 3 - ordinary license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(!license.IsActive)
                {
                    MessageBox.Show("Local license should be active.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if(clsInternationalLicense.ActiveLicenseExists(ctrlDriverLicenseInfoWithFilter1.DriverID))
            {
                MessageBox.Show("There is already active license for this driver.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int appID = IssueApplication();
            if (appID != -1)
            {
                clsInternationalLicense internationalLicense = new clsInternationalLicense();
                internationalLicense.ApplicationID = appID;
                internationalLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.DriverID;
                internationalLicense.IssuedUsingLocalLicenseID = license.LicenseID;
                internationalLicense.IssueDate = DateTime.Now;
                internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
                internationalLicense.IsActive = true;
                internationalLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

                if(internationalLicense.Save())
                {
                    IntLicenseID = internationalLicense.InternationalLicenseID;
                    MessageBox.Show($"License issued successfully with ID = {IntLicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lnklblShowLicense.Enabled = true;
                    clsApplication.ChangeStatus(appID, 3);
                    ctrlInternationalDriverInfo1.SetLicenseInfo(appID, IntLicenseID);
                    return;
                }
            }

            MessageBox.Show("Something went wrong, failed to issue license", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void lnklblLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsDriver driver = clsDriver.Find(ctrlDriverLicenseInfoWithFilter1.DriverID);

            if(driver != null)
            { 
                frmLicenseHistory frm = new frmLicenseHistory(driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void lnklblShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmIntLicenseInfo frm = new frmIntLicenseInfo(IntLicenseID);
            frm.ShowDialog();
        }
    }
}
