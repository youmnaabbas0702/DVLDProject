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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DesktopApp.Applications.LocalLicenseApplications
{
    public partial class frmAddEditLocalLicenseApplication : Form
    {
        public event Action OperationOccuredEventHandler;
        bool allowTabChange = false;
        private int _AppID = -1;
        private clsLocalLicenseApplication.enMode _Mode = clsLocalLicenseApplication.enMode.AddNew;

        public frmAddEditLocalLicenseApplication()
        {
            InitializeComponent();
            _SetUp();
        }

        public frmAddEditLocalLicenseApplication(int AppID) : this()
        {
            _AppID = AppID;
            _Mode = clsLocalLicenseApplication.enMode.Update;
            lblTitle.Text = "Edit local driving license application";
            _LoadApplicationInfo();
        }

        private void _SetUp()
        {
            this.Size = new Size(660, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmbLicenseClasses.DataSource = clsLicenseClass.GetAllLicenseClassNames();
            cmbLicenseClasses.SelectedIndex = 0;
        }

        private void _LoadApplicationInfo()
        {
            clsLocalLicenseApplication localLicenseApp = clsLocalLicenseApplication.Find(_AppID);
            if (localLicenseApp != null)
            {
                clsApplication app = clsApplication.Find(localLicenseApp.ApplicationID);

                if(app != null)
                {
                    lblLicenseAppID.Text = localLicenseApp.LocalDrivingLicenseApplicationID.ToString();
                    ctrlPersonCardWithFilter1.PersonID = app.ApplicantPersonID;
                    ctrlPersonCardWithFilter1.FillPersonCard();
                    cmbLicenseClasses.SelectedIndex = localLicenseApp.LicenseClassID - 1;
                }
            }
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

        private bool _UpdateApplication()
        {
            clsLocalLicenseApplication localLicenseApp = clsLocalLicenseApplication.Find(Convert.ToInt32(lblLicenseAppID.Text));
            if (localLicenseApp != null)
            {
                clsApplication app = clsApplication.Find(localLicenseApp.ApplicationID);
                if (app != null)
                {
                    app.ApplicationDate = DateTime.Now;
                    app.LastStatusDate = DateTime.Now;
                    app.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;

                    if (app.Save())
                    {
                        localLicenseApp.LicenseClassID = cmbLicenseClasses.SelectedIndex + 1;
                        if (localLicenseApp.Save())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int personID = ctrlPersonCardWithFilter1.PersonID;
            int classID = cmbLicenseClasses.SelectedIndex + 1;
            int ExistingAppID = clsLocalLicenseApplication.ExistingApplicationID(personID, classID);

            switch (_Mode)
            {
                case clsLocalLicenseApplication.enMode.AddNew:
                    {
                        if (ExistingAppID != -1)
                        {
                            MessageBox.Show($"Person already have an application of the same license class with ID = {ExistingAppID}.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        clsPerson person = clsPerson.Find(personID);
                        if (person != null)
                        {
                            int age = DateTime.Now.Year - person.DateOfBirth.Year;
                            clsLicenseClass licenseClassInfo = clsLicenseClass.Find(classID);
                            if (age < licenseClassInfo.MinimumAllowedAge)
                            {
                                MessageBox.Show($"Applicant must be at least {licenseClassInfo.MinimumAllowedAge} years old.",
                                "Age Restriction",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        

                        if (_AddNewApplication())
                            MessageBox.Show("Application issued successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Failed to issue application.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case clsLocalLicenseApplication.enMode.Update:
                    {
                        if (ExistingAppID != Convert.ToInt32(lblLicenseAppID.Text) && ExistingAppID != -1)
                        {
                            MessageBox.Show($"Person already have an application of the same license class with ID = {ExistingAppID}.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (_UpdateApplication())
                            MessageBox.Show("Application updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Failed to update application.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    break;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OperationOccuredEventHandler?.Invoke();
            this.Close();
        }
    }
}
