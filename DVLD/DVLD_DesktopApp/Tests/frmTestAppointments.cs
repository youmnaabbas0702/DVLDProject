using DVLD_DesktopApp.Controls;
using DVLD_DesktopApp.TestAppointments.VisionTest;
using DVLD_DesktopApp.Tests;
using DVLDBusiness;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_DesktopApp.TestAppointments
{
    public partial class frmTestAppointments : Form
    {
        public event Action OperationOccuredEventHandler;

        private int _LicenseAppID;
        private int _TestTypeID;

        public frmTestAppointments(int licenseAppID, int testTypeID)
        {
            InitializeComponent();
            _LicenseAppID = licenseAppID;
            _TestTypeID = testTypeID;
            _Setup();
        }

        private void _Setup()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(600, 600);
            ctrlLicenseAppDetails1.LicenseAppID = _LicenseAppID;
            ctrlLicenseAppDetails1.LoadLicenseAppInfo();

            // Set UI based on test type
            switch (_TestTypeID)
            {
                case 1:
                    lblTitle.Text = "Vision Test Appointments";
                    pictureBox1.Image = Properties.Resources.visionTest;
                    break;
                case 2:
                    lblTitle.Text = "Written Test Appointments";
                    pictureBox1.Image = Properties.Resources.writtenTest;
                    break;
                case 3:
                    lblTitle.Text = "Street Test Appointments";
                    pictureBox1.Image = Properties.Resources.writtenTest;
                    break;
            }

            _LoadAppointmentsList();
        }

        private void _LoadAppointmentsList()
        {
            dgvAppointments.DataSource = clsTestAppointment.GetAppointments(_LicenseAppID, _TestTypeID);
            lblRecordsCount.Text = dgvAppointments.RowCount.ToString();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.HasPassed(_LicenseAppID, _TestTypeID))
            {
                MessageBox.Show($"Person already passed this test, you can't add an appointment.",
                    "Unable to add appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvAppointments.RowCount == 0 || clsTestAppointment.HasFailed(_LicenseAppID, _TestTypeID))
            {
                frmScheduleTest frm = new frmScheduleTest(_LicenseAppID, _TestTypeID);
                frm.OperationOccuredEventHandler += _LoadAppointmentsList;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show($"Person already has an active appointment for this test.",
                    "Unable to add appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appointmentID = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value);

            frmScheduleTest frm = new frmScheduleTest(_LicenseAppID, _TestTypeID, appointmentID);
            frm.OperationOccuredEventHandler += _LoadAppointmentsList;
            frm.ShowDialog();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appointmentID = Convert.ToInt32(dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value);

            frmTakeTest frm = new frmTakeTest(appointmentID, _TestTypeID);
            frm.OperationOccuredEventHandler += _LoadAppointmentsList;
            frm.ShowDialog();
        }

        private void frmTestAppointments_FormClosing(object sender, FormClosingEventArgs e)
        {
            OperationOccuredEventHandler?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bool isLocked = Convert.ToBoolean(dgvAppointments.CurrentRow.Cells["IsLocked"].Value);
            if (isLocked)
                takeTestToolStripMenuItem.Enabled = false;
            else
                takeTestToolStripMenuItem.Enabled = true;
        }
    }
}
