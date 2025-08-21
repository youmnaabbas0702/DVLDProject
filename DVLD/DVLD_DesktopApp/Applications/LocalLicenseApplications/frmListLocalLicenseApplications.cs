using DVLD_DesktopApp.Licenses;
using DVLD_DesktopApp.TestAppointments;
using DVLD_DesktopApp.TestAppointments.VisionTest;
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
    public partial class frmListLocalLicenseApplications : Form
    {
        private BindingSource _ApplicationsBindingSource = new BindingSource();

        public frmListLocalLicenseApplications()
        {
            InitializeComponent();
            _SetUp();
            _RefreshList();
        }

        private void _SetUp()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(820, 480);
            cmbFilter.SelectedIndex = 0;
        }

        //list
        private void _UpdateCountLabel()
        {
            lblRecordsCount.Text = dgvApplications.RowCount.ToString();
        }

        private void _RefreshList()
        {
            DataTable dt = clsLocalLicenseApplication.GetAllApplications();
            _ApplicationsBindingSource.DataSource = dt;
            dgvApplications.DataSource = _ApplicationsBindingSource;
            _UpdateCountLabel();
        }


        //filter
        private void _FilterApps(string colName, string expression)
        {
            _ApplicationsBindingSource.Filter = $"CONVERT([{colName}], 'System.String') LIKE '%{expression}%'";
            _UpdateCountLabel();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex != 0)
            {
                txtFilter.Visible = true;
            }
            else
                txtFilter.Visible = false;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFilter.Text))
                _FilterApps(cmbFilter.SelectedItem.ToString(), txtFilter.Text);

            else
            {
                _ApplicationsBindingSource.RemoveFilter();
                _UpdateCountLabel();
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() == "L.D.L.AppID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // prevent the character from being entered
                }
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _HandleTestsAccessability(int passedTests)
        {
            scheduleTestsToolStripMenuItem.Enabled = true;

            switch (passedTests)
            {
                case 0:
                    visionTestToolStripMenuItem.Enabled = true;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    break;
                case 1:
                    visionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = true;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    break;
                case 2:
                    visionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = true;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    break;
                case 3:
                    scheduleTestsToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int appID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value);
            clsLocalLicenseApplication LocalLicenseApplication = clsLocalLicenseApplication.Find(appID);
            if (LocalLicenseApplication != null)
            {
                clsApplication Application = clsApplication.Find(LocalLicenseApplication.ApplicationID);
                if (Application != null)
                {
                    switch (Application.ApplicationStatus)
                    {
                        case 1:
                            {
                                int PassedTests = Convert.ToInt32(dgvApplications.CurrentRow.Cells["Passed tests"].Value);

                                editApplicationToolStripMenuItem.Enabled = true;
                                deleteApplicationToolStripMenuItem.Enabled = true;
                                cancelApplicationToolStripMenuItem.Enabled = true;
                                _HandleTestsAccessability(PassedTests);
                                showLicenseToolStripMenuItem.Enabled = false;
                            }
                            break;
                        case 2:
                            {
                                editApplicationToolStripMenuItem.Enabled = false;
                                deleteApplicationToolStripMenuItem.Enabled = false;
                                cancelApplicationToolStripMenuItem.Enabled = false;
                                scheduleTestsToolStripMenuItem.Enabled = false;
                                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                                showLicenseToolStripMenuItem.Enabled = false;
                            }
                            break;
                        case 3:
                            {
                                editApplicationToolStripMenuItem.Enabled = false;
                                deleteApplicationToolStripMenuItem.Enabled = false;
                                cancelApplicationToolStripMenuItem.Enabled = false;
                                scheduleTestsToolStripMenuItem.Enabled = false;
                                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                                showLicenseToolStripMenuItem.Enabled = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        //add
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicenseApplication frm = new frmAddEditLocalLicenseApplication();
            frm.OperationOccuredEventHandler += _RefreshList;
            frm.ShowDialog();
        }

        //app details
        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localLicenseAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value);
            frmAppDetails frm = new frmAppDetails(localLicenseAppID);
            frm.ShowDialog();
        }

        //edit
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value);
            frmAddEditLocalLicenseApplication frm = new frmAddEditLocalLicenseApplication(appID);
            frm.OperationOccuredEventHandler += _RefreshList;
            frm.ShowDialog();
        }
        //delete
        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localLicenseAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value);
            DialogResult result = MessageBox.Show($"Are you sure you want to delete local driving license application number {localLicenseAppID}?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {                
                clsLocalLicenseApplication localLicenseApplication = clsLocalLicenseApplication.Find(localLicenseAppID);
                if (localLicenseApplication != null)
                {
                    int appID = localLicenseApplication.ApplicationID;
                    if (clsLocalLicenseApplication.Delete(localLicenseAppID))
                    {
                        if(clsApplication.Delete(appID))
                        {
                            MessageBox.Show("application deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _RefreshList();
                            return;
                        }
                    }
                }

                MessageBox.Show("Failed to delete application.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //cancel
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localLicenseAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value);
            DialogResult result = MessageBox.Show($"Are you sure you want to cancel local driving license application number {localLicenseAppID}?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                clsLocalLicenseApplication localLicenseApplication = clsLocalLicenseApplication.Find(localLicenseAppID);
                if (localLicenseApplication != null)
                {
                    if (clsApplication.ChangeStatus(localLicenseApplication.ApplicationID, 2))
                    {
                        MessageBox.Show("application cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshList();
                        return;
                    }
                }
            }
            MessageBox.Show("Failed to cancel application.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //schedule test
        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localLicenseAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value);
            frmTestAppointments frm = new frmTestAppointments(localLicenseAppID, 1);
            frm.OperationOccuredEventHandler += _RefreshList;
            frm.ShowDialog();
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localLicenseAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value);
            frmTestAppointments frm = new frmTestAppointments(localLicenseAppID, 2);
            frm.OperationOccuredEventHandler += _RefreshList;
            frm.ShowDialog();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localLicenseAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value);
            frmTestAppointments frm = new frmTestAppointments(localLicenseAppID, 3);
            frm.OperationOccuredEventHandler += _RefreshList;
            frm.ShowDialog();
        }

        //issue license
        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localLicenseAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value);
            frmIssueNewLicense frm = new frmIssueNewLicense(localLicenseAppID);
            frm.OperationOccuredEventHandler += _RefreshList;
            frm.ShowDialog();
        }

        //show license
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localLicenseAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value);
            frmLicenseInfo frm = new frmLicenseInfo(localLicenseAppID);
            frm.ShowDialog();
        }

        //show licenses history
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localLicenseAppID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value);
            clsLocalLicenseApplication localapp = clsLocalLicenseApplication.Find(localLicenseAppID);
            if (localapp != null)
            {
                clsApplication app = clsApplication.Find(localapp.ApplicationID);
                if (app != null)
                {
                    frmLicenseHistory frm = new frmLicenseHistory(app.ApplicantPersonID);
                    frm.ShowDialog();
                }
            }
        }
    }
}
