using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopApp.People
{
    public partial class frmManagePeople : Form
    {
        private BindingSource _PeopleBindingSource = new BindingSource();
        public frmManagePeople()
        {
            InitializeComponent();
            _SetUp();
            _RefreshAllPeople();
        }

        private void _SetUp()
        {
            this.Size = new Size(1070, 510);
            this.StartPosition = FormStartPosition.CenterScreen;
            cmbFilter.SelectedIndex = 0;
            txtFilter.Visible = false;
        }

        private void _UpdateCountLabel()
        {
            lblRecordsCount.Text = dgvPeople.RowCount.ToString();
        }

        private void _RefreshAllPeople()
        {
            DataTable dt = clsPerson.GetAllPeople();
            _PeopleBindingSource.DataSource = dt;
            dgvPeople.DataSource = _PeopleBindingSource;
            _UpdateCountLabel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _AddEditPerson(frmAddEditPerson form)
        {
            form.OperationOccuredEventHandler += Frm_OperationOccuredEventHandler;
            form.ShowDialog();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _AddEditPerson(new frmAddEditPerson());
        }

        private void Frm_OperationOccuredEventHandler()
        {
            _RefreshAllPeople();
        }

        //filter
        private void _FilterPeople(string colName, string expression)
        {
            _PeopleBindingSource.Filter = $"CONVERT({colName}, 'System.String') LIKE '%{expression}%'";
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
            if(!String.IsNullOrEmpty(txtFilter.Text))
                _FilterPeople(cmbFilter.SelectedItem.ToString().Replace(" ", ""), txtFilter.Text);
            
            else
            { 
                _PeopleBindingSource.RemoveFilter();
                _UpdateCountLabel();
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmbFilter.SelectedItem.ToString() == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // prevent the character from being entered
                }
            }
        }

        //CRUD using context menu
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddEditPerson(new frmAddEditPerson());
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);
            _AddEditPerson(new frmAddEditPerson(personID));
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);
            DialogResult result = MessageBox.Show($"Are you sure you want to delete person {personID}.", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                {
                    if (clsPerson.Delete(personID))
                    {
                        MessageBox.Show("Person deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshAllPeople();
                    }
                    else
                        MessageBox.Show("Failed to delete person.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);
            frmPersonDetails frm = new frmPersonDetails(personID);
            frm.ShowDialog();
        }

        //unimplemented features
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet");
        }
    }
}
