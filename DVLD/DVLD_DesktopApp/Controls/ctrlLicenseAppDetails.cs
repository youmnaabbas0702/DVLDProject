using DVLD_DesktopApp.People;
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
    public partial class ctrlLicenseAppDetails : UserControl
    {
        public int LicenseAppID { get; set; } = 0;

        public ctrlLicenseAppDetails()
        {
            InitializeComponent();
        }

        public void LoadLicenseAppInfo()
        {
            clsLocalLicenseApplication localLicenseApp = clsLocalLicenseApplication.Find(LicenseAppID);
            DataRow row = localLicenseApp.GetApplicationDetails();

            if (row == null)
            {
                MessageBox.Show("Application not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLicenseAppID.Text = row["LDLAppID"].ToString();
            lblLicenseClass.Text = row["LicenseClass"].ToString();
            lblPassedTests.Text = row["PassedTests"].ToString();
            lblAppID.Text = row["ApplicationID"].ToString();
            lblStatus.Text = row["Status"].ToString();
            lblFees.Text = Convert.ToDecimal(row["Fees"]).ToString("C");
            lblAppType.Text = row["Type"].ToString();
            lblApplicantName.Text = row["Applicant"].ToString();
            lblApplicationDate.Text = Convert.ToDateTime(row["ApplicationDate"]).ToShortDateString();
            lblStatusDate.Text = Convert.ToDateTime(row["LastStatusDate"]).ToShortDateString();
            lblCreatedBy.Text = row["CreatedBy"].ToString();
        }

        private void PersonInfoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLocalLicenseApplication licenseApp = clsLocalLicenseApplication.Find(LicenseAppID);
            clsApplication app = clsApplication.Find(licenseApp.ApplicationID);

            frmPersonDetails frm = new frmPersonDetails(app.ApplicantPersonID);
            frm.ShowDialog();
        }
    }
}
