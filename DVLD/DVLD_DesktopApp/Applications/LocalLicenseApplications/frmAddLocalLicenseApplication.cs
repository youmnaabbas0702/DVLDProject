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

namespace DVLD_DesktopApp.Applications.LocalLicenseApplications
{
    public partial class frmAddLocalLicenseApplication : Form
    {
        public event Action OperationOccuredEventHandler;
        bool allowTabChange = false;

        public frmAddLocalLicenseApplication()
        {
            InitializeComponent();
            _SetUp();
        }

        private void _SetUp()
        {
            this.Size = new Size(660, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
            lblApplicationDate.Text = DateTime.Now.ToString("ddd/MM/yyyy");
            cmbLicenseClasses.DataSource = clsLicenseClass.GetAllLicenseClassNames();
            cmbLicenseClasses.SelectedIndex = 0;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tpAppInfo && !allowTabChange)
            {
                e.Cancel = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.PersonID != 0)
                allowTabChange = true;
            tabControl1.SelectedTab = tpAppInfo;
            allowTabChange = false;
        }

        private bool _AddNewApplication()
        {
            clsApplication app = new clsApplication();
            app.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            app.ApplicationDate = DateTime.Now;
            app.ApplicationTypeID = 1;
            app.ApplicationStatus = 1;
            app.LastStatusDate = DateTime.Now;
            app.PaidFees = Convert.ToDecimal(lblAppFees.Text);
            app.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

            if(app.Save())
            {
                clsLocalLicenseApplication localLicenseApp = new clsLocalLicenseApplication();
                localLicenseApp.ApplicationID = app.ApplicationID;
                localLicenseApp.LicenseClassID = cmbLicenseClasses.SelectedIndex + 1;
                if(localLicenseApp.Save())
                {
                    lblLicenseAppID.Text = localLicenseApp.LocalDrivingLicenseApplicationID.ToString();
                    return true;
                }

            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int personID = ctrlPersonCardWithFilter1.PersonID;
            int classID = cmbLicenseClasses.SelectedIndex + 1;
            int ExistingAppID = clsLocalLicenseApplication.ExistingApplicationID(personID, classID);
            if (ExistingAppID != -1)
                {
                MessageBox.Show($"Person already have an application of the same license class with ID = {ExistingAppID}.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }

            if (_AddNewApplication())
                MessageBox.Show("Application issued successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to issue application.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OperationOccuredEventHandler?.Invoke();
            this.Close();
        }
    }
}
