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

namespace DVLD_DesktopApp.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public int PersonID { get; set; } = 0;
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            cmbFind.SelectedIndex = 0;
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
                btnFind.PerformClick();

            if (cmbFind.SelectedItem.ToString() == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // prevent the character from being entered
                }
            }
        }

        public void FillPersonCard()
        {
            ctrlPersonCard1.PersonID = PersonID;
            ctrlPersonCard1.LoadPersonInfo();
            gpFilter.Enabled = false;
        }

        private void FillPersonCard(int personID)
        {
            PersonID = personID;
            ctrlPersonCard1.PersonID = personID;
            ctrlPersonCard1.LoadPersonInfo();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtFind.Text))
            {
                MessageBox.Show("Please write something in the search text");
                return;
            }

            clsPerson person;
            if(cmbFind.SelectedItem.ToString() == "PersonID")
            {
                person = clsPerson.Find(Convert.ToInt32(txtFind.Text));
            }
            else
                person = clsPerson.Find(txtFind.Text);

            if (person != null)
                FillPersonCard(person.PersonID);
            else
                MessageBox.Show("Person does not exist in the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPerson form = new frmAddEditPerson();
            form.PersonAdded += FillPersonCard;
            form.ShowDialog();
        }
    }
}
