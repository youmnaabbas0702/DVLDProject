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

namespace DVLD_DesktopApp.Licenses
{
    public partial class frmManageDetainedLicenses : Form
    {
        private BindingSource _DetainedLicensesBindingSource = new BindingSource();

        public frmManageDetainedLicenses()
        {
            InitializeComponent();
            _SetUp();
            _RefreshList();
        }

        private void _SetUp()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1040, 500);
            cmbFilter.SelectedIndex = 0;
        }

        //list
        private void _UpdateCountLabel()
        {
            lblRecordsCount.Text = dgvDetainedLicenses.RowCount.ToString();
        }

        private void _RefreshList()
        {
            DataTable dt = clsDetainedLicense.GetAllDetainedLicenses();
            _DetainedLicensesBindingSource.DataSource = dt;
            dgvDetainedLicenses.DataSource = _DetainedLicensesBindingSource;
            _UpdateCountLabel();
        }


        //filter
        private void _FilterApps(string colName, string expression)
        {
            _DetainedLicensesBindingSource.Filter = $"CONVERT([{colName}], 'System.String') LIKE '%{expression}%'";
            _UpdateCountLabel();
        }


        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.OperationOccuredEventHandler += _RefreshList;
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() == "DetainID" || cmbFilter.SelectedItem.ToString() == "ReleaseAppID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // prevent the character from being entered
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFilter.Text))
                _FilterApps(cmbFilter.SelectedItem.ToString(), txtFilter.Text);

            else
            {
                _DetainedLicensesBindingSource.RemoveFilter();
                _UpdateCountLabel();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
            if (clsDetainedLicense.IsLicenseDetained(LicenseID))
            {
                releaseLicenseToolStripMenuItem.Enabled = true;
                return;
            }
            releaseLicenseToolStripMenuItem.Enabled = false;
        }


        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
            clsLicense license = clsLicense.Find(LicenseID);

            clsDriver driver = clsDriver.Find(license.DriverID);
            if (driver != null)
            {
                frmLicenseHistory frm = new frmLicenseHistory(driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
            clsLicense license = clsLicense.Find(LicenseID);

            clsDriver driver = clsDriver.Find(license.DriverID);
            if (driver != null)
            {
                frmPersonDetails frm = new frmPersonDetails(driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void ShowLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
            frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense(LicenseID);
            frm.OperationOccuredEventHandler += _RefreshList;
            frm.ShowDialog();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.OperationOccuredEventHandler += _RefreshList;
            frm.ShowDialog();
        }
    }
}
