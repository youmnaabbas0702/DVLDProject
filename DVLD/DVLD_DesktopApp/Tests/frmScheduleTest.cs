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

namespace DVLD_DesktopApp.TestAppointments.VisionTest
{
    public partial class frmScheduleTest : Form
    {
        public event Action OperationOccuredEventHandler;

        private int _LocalAppID;
        private int _AppointmentID;
        private int _TestTypeID;
        private bool _IsRetake = false;

        private clsTestAppointment.enMode _Mode = clsTestAppointment.enMode.AddNew;

        public frmScheduleTest(int localAppID, int testTypeID, int appointmentID = -1)
        {
            InitializeComponent();
            _LocalAppID = localAppID;
            _AppointmentID = appointmentID;
            _TestTypeID = testTypeID;
            _Mode = appointmentID == -1 ? clsTestAppointment.enMode.AddNew : clsTestAppointment.enMode.Update;
            _Setup();
        }

        private void _Setup()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(400, 550);
            dtpAppointmentDate.MinDate = DateTime.Now;

            // dynamic form title and image
            switch (_TestTypeID)
            {
                case 1:
                    lblTitle.Text = "Schedule Vision Test";
                    groupBox1.Text = "Vision Test";
                    pictureBox1.Image = Properties.Resources.visionTest;
                    break;
                case 2:
                    lblTitle.Text = "Schedule Written Test";
                    groupBox1.Text = "Written Test";
                    pictureBox1.Image = Properties.Resources.writtenTest;
                    break;
                case 3:
                    lblTitle.Text = "Schedule Street Test";
                    groupBox1.Text = "Street Test";
                    pictureBox1.Image = Properties.Resources.streetTest;
                    break;
            }

            _LoadInfo();
        }

        private void _LoadInfo()
        {
            clsLocalLicenseApplication localApp = clsLocalLicenseApplication.Find(_LocalAppID);
            if (localApp == null) return;

            if (_Mode == clsTestAppointment.enMode.Update)
            {
                clsTestAppointment appointment = clsTestAppointment.Find(_AppointmentID);
                if (appointment != null)
                {
                    dtpAppointmentDate.Value = appointment.AppointmentDate;

                    if (appointment.IsLocked)
                    {
                        lblLocked.Visible = true;
                        dtpAppointmentDate.Enabled = false;
                        btnSave.Enabled = false;
                    }
                }
            }

            clsApplication app = clsApplication.Find(localApp.ApplicationID);
            if (app != null)
            {
                lblLicenseAppID.Text = localApp.LocalDrivingLicenseApplicationID.ToString();
                lblLicenseClass.Text = clsLicenseClass.Find(localApp.LicenseClassID)?.ClassName;
                lblApplicantName.Text = clsPerson.Find(app.ApplicantPersonID)?.FullName();
                lblFees.Text = clsTestType.Find(_TestTypeID)?.Fees.ToString();

                lblTrials.Text = clsTestAppointment.GetAppointmentsCount(_LocalAppID, _TestTypeID).ToString();
            }

            if (clsTestAppointment.HasFailed(_LocalAppID, _TestTypeID))
            {
                _IsRetake = true;
                lblTitle.Text = "Schedule Retake Test";
                gbRetakeTest.Enabled = true;

                lblRetakeAppFees.Text = clsApplicationType.Find(8)?.Fees.ToString();
            }


            lblTotalFees.Text =
                (Convert.ToDecimal(lblRetakeAppFees.Text) + Convert.ToDecimal(lblFees.Text)).ToString();
        }

        private bool _AddAppointment()
        {
            clsTestAppointment appointment = new clsTestAppointment();
            appointment.LDLAppID = _LocalAppID;
            appointment.TestTypeID = _TestTypeID;
            appointment.PaidFees = Convert.ToDecimal(lblTotalFees.Text);
            appointment.AppointmentDate = dtpAppointmentDate.Value;
            appointment.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            appointment.IsLocked = false;

            if (appointment.Save())
            {
                _AppointmentID = appointment.TestAppointmentID;
                return true;
            }

            return false;
        }

        private bool _UpdateAppointment()
        {
            clsTestAppointment appointment = clsTestAppointment.Find(_AppointmentID);
            appointment.AppointmentDate = dtpAppointmentDate.Value;
            return appointment.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case clsTestAppointment.enMode.AddNew:
                    if (_AddAppointment())
                    {
                        MessageBox.Show($"Appointment added successfully with ID = {_AppointmentID}",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (_IsRetake)
                            lblRetakeAppID.Text = _AppointmentID.ToString();

                        _Mode = clsTestAppointment.enMode.Update;
                    }
                    break;
                case clsTestAppointment.enMode.Update:
                    if (_UpdateAppointment())
                    {
                        MessageBox.Show($"Appointment updated successfully",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
