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

namespace DVLD_DesktopApp.Tests
{
    public partial class frmTakeTest : Form
    {
        public event Action OperationOccuredEventHandler;

        private int _AppointmentID = -1;
        private int _TestTypeID = -1;

        public frmTakeTest(int appointmentID, int testTypeID)
        {
            InitializeComponent();
            _AppointmentID = appointmentID;
            _TestTypeID = testTypeID;
            _Setup();
        }

        private void _Setup()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(400, 600);
            rbFail.Checked = true;
            _SetTitleAndImage();
            _LoadInfo();
        }

        private void _SetTitleAndImage()
        {
            switch (_TestTypeID)
            {
                case 1:
                    groupBox1.Text = "Vision Test";
                    pictureBox1.Image = Properties.Resources.visionTest;
                    break;
                case 2:
                    groupBox1.Text = "Written Test";
                    pictureBox1.Image = Properties.Resources.writtenTest;
                    break;
                case 3:
                    groupBox1.Text = "Street Test";
                    pictureBox1.Image = Properties.Resources.streetTest;
                    break;
                default:
                    lblTitle.Text = "Take Test";
                    break;
            }
        }

        private void _LoadInfo()
        {
            clsTestAppointment appointment = clsTestAppointment.Find(_AppointmentID);
            if (appointment != null)
            {
                clsLocalLicenseApplication localApp = clsLocalLicenseApplication.Find(appointment.LDLAppID);
                if (localApp != null)
                {
                    clsApplication app = clsApplication.Find(localApp.ApplicationID);
                    if (app != null)
                    {
                        lblLicenseAppID.Text = localApp.LocalDrivingLicenseApplicationID.ToString();
                        lblLicenseClass.Text = clsLicenseClass.Find(localApp.LicenseClassID)?.ClassName;
                        lblApplicantName.Text = clsPerson.Find(app.ApplicantPersonID)?.FullName();
                        lblFees.Text = appointment.PaidFees.ToString();
                        lblTestDate.Text = appointment.AppointmentDate.ToString("dd/MM/yyyy");
                        lblTrials.Text = clsTestAppointment.GetAppointmentsCount(appointment.LDLAppID, _TestTypeID).ToString();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTest newTest = new clsTest()
            {
                TestAppointmentID = _AppointmentID,
                TestResult = rbPass.Checked,
                Notes = txtNotes.Text,
                CreatedByUserID = clsGlobalSettings.CurrentUser.UserID
            };

            if (newTest.Save())
            {
                clsTestAppointment appointment = clsTestAppointment.Find(_AppointmentID);
                appointment.IsLocked = true;

                if (appointment.Save())
                {
                    MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblTestID.Text = newTest.TestID.ToString();
                    return;
                }
            }

            MessageBox.Show("Failed to save.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTakeTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            OperationOccuredEventHandler?.Invoke();
        }
    }
}
