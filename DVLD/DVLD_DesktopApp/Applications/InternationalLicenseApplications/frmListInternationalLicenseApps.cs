using DVLD_DesktopApp.Controls;
using DVLD_DesktopApp.Licenses;
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

namespace DVLD_DesktopApp.Applications.InternationalLicenseApplications
{
    public partial class frmListInternationalLicenseApps : Form
    {
        private BindingSource _ApplicationsBindingSource = new BindingSource();

        public frmListInternationalLicenseApps()
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
            DataTable dt = clsInternationalLicense.GetAllLicenses();
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicense frm = new frmIssueInternationalLicense();
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["DriverID"].Value);
            clsDriver driver = clsDriver.Find(DriverID);

            if (driver != null)
            {
                frmLicenseHistory frm = new frmLicenseHistory(driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["DriverID"].Value);
            clsDriver driver = clsDriver.Find(DriverID);

            if (driver != null)
            {
                frmPersonDetails frm = new frmPersonDetails(driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void ShowLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int IntLicenseID = Convert.ToInt32(dgvApplications.CurrentRow.Cells["IntLicenseID"].Value);

            frmIntLicenseInfo frm = new frmIntLicenseInfo(IntLicenseID);
            frm.ShowDialog();
        }
    }
}
