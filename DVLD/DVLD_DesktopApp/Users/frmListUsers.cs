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

namespace DVLD_DesktopApp.Users
{
    public partial class frmListUsers : Form
    {

        private BindingSource _UsersBindingSource = new BindingSource();

        public frmListUsers()
        {
            InitializeComponent();
            _SetUp();
            _RefreshAllUsers();
        }

        private void _SetUp()
        {
            this.Size = new Size(650, 510);
            this.StartPosition = FormStartPosition.CenterScreen;
            cmbFilter.SelectedIndex = 0;
            txtFilter.Visible = false;
            cmbIsActive.SelectedIndex = 0;
        }

        private void _UpdateCountLabel()
        {
            lblRecordsCount.Text = dgvUsers.RowCount.ToString();
        }

        private void _RefreshAllUsers()
        {
            DataTable dt = clsUser.GetAllUsers();
            _UsersBindingSource.DataSource = dt;
            dgvUsers.DataSource = _UsersBindingSource;

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 90;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 90;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 180;

                dgvUsers.Columns[3].HeaderText = "UserName";
                dgvUsers.Columns[3].Width = 100;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 90;
            }
            _UpdateCountLabel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _AddEditUser(frmAddEditUser form)
        {
            form.OperationOccuredEventHandler += Frm_OperationOccuredEventHandler;
            form.ShowDialog();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _AddEditUser(new frmAddEditUser());
        }

        private void Frm_OperationOccuredEventHandler()
        {
            _RefreshAllUsers();
        }

        // filter
        private void _FilterUsers(string colName, string expression)
        {
            _UsersBindingSource.Filter = $"CONVERT({colName}, 'System.String') LIKE '%{expression}%'";
            _UpdateCountLabel();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIsActive.Visible = (cmbFilter.SelectedItem.ToString().Replace(" ", "") == "IsActive");
            txtFilter.Visible = (cmbFilter.SelectedItem.ToString() != "None") &&(cmbFilter.SelectedItem.ToString().Replace(" ", "") != "IsActive");
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilter.Text))
                _FilterUsers(cmbFilter.SelectedItem.ToString().Replace(" ", ""), txtFilter.Text);
            else
            {
                _UsersBindingSource.RemoveFilter();
                _UpdateCountLabel();
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() == "UserID"
                || cmbFilter.SelectedItem.ToString() == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIsActive.SelectedIndex == 1)
            {
                _UsersBindingSource.Filter = "IsActive = 1";
            }
            else if (cmbIsActive.SelectedIndex == 2)
            {
                _UsersBindingSource.Filter = "IsActive = 0";
            }
            else
                _UsersBindingSource.RemoveFilter();
        }

        // CRUD using context menu
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddEditUser(new frmAddEditUser());
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            _AddEditUser(new frmAddEditUser(userID));
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            DialogResult result = MessageBox.Show($"Are you sure you want to delete user {userID}?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                if (clsUser.Delete(userID))
                {
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshAllUsers();
                }
                else
                    MessageBox.Show("Failed to delete user.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            frmUserDetails frm = new frmUserDetails(userID);
            frm.ShowDialog();
        }

        private void ChangePassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            frmChangePassword frm = new frmChangePassword(userID);
            frm.ShowDialog();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
