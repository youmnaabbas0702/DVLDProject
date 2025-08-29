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
    public partial class frmIssueNewLicense : Form
    {
        public event Action OperationOccuredEventHandler;
        private int _LocalAppID = -1;
        public frmIssueNewLicense(int localAppID)
        {
            InitializeComponent();
            _LocalAppID = localAppID;
            _Setup();
        }

        private void _Setup()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(600, 470);
            ctrlLicenseAppDetails1.LicenseAppID = _LocalAppID;
            ctrlLicenseAppDetails1.LoadLicenseAppInfo();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsLocalLicenseApplication localapp = clsLocalLicenseApplication.Find(_LocalAppID);

            if (localapp != null)
            {
                clsLicense license = new clsLicense();
                license.ApplicationID = localapp.ApplicationID;
                license.IssueDate = DateTime.Now;
                license.PaidFees = clsLicenseClass.Find(localapp.LicenseClassID).ClassFees;
                license.Notes = txtNotes.Text;
                license.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
                license.IssueReason = 1;
                license.LicenseClass = localapp.LicenseClassID;
                license.IsActive = true;

                if (license.Save())
                {
                    MessageBox.Show($"License issued successfully with ID = {license.LicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            MessageBox.Show("Failed to issue license", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmIssueNewLicense_FormClosing(object sender, FormClosingEventArgs e)
        {
            OperationOccuredEventHandler?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
