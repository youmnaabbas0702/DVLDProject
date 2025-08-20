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

namespace DVLD_DesktopApp
{
    public partial class frmListDrivers : Form
    {
        private BindingSource _DriversBindingSource = new BindingSource();

        public frmListDrivers()
        {
            InitializeComponent();
            _SetUp();
            _RefreshList();
        }

        private void _SetUp()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(750, 530);
            cmbFilter.SelectedIndex = 0;
        }

        //list
        private void _UpdateCountLabel()
        {
            lblRecordsCount.Text = dgvDrivers.RowCount.ToString();
        }

        private void _RefreshList()
        {
            DataTable dt = clsDriver.GetAllDrivers();
            _DriversBindingSource.DataSource = dt;
            dgvDrivers.DataSource = _DriversBindingSource;
            _UpdateCountLabel();
        }

        private void _FilterDrivers(string colName, string expression)
        {
            _DriversBindingSource.Filter = $"CONVERT([{colName}], 'System.String') LIKE '%{expression}%'";
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
                _FilterDrivers(cmbFilter.SelectedItem.ToString(), txtFilter.Text);

            else
            {
                _DriversBindingSource.RemoveFilter();
                _UpdateCountLabel();
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() == "DriverID" || cmbFilter.SelectedItem.ToString() == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // prevent the character from being entered
                }
            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dgvDrivers.CurrentRow.Cells["PersonID"].Value);
            frmPersonDetails frm = new frmPersonDetails(personID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
