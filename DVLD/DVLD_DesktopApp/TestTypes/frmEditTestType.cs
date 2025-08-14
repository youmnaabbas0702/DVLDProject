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

namespace DVLD_DesktopApp.TestTypes
{
    public partial class frmEditTestType : Form
    {
        private int testTypeID = -1;
        private bool Updated = false;
        public event Action TestTypeUpdatedEventHandler;

        public frmEditTestType(int ID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            testTypeID = ID;
            _LoadInfo();
        }

        private void _LoadInfo()
        {
            clsTestType testType = clsTestType.Find(testTypeID);
            if (testType != null)
            {
                lblID.Text = testType.TestTypeID.ToString();
                txtTitle.Text = testType.Title;
                txtDescription.Text = testType.Description;
                txtFees.Text = testType.Fees.ToString();
            }
        }

        // Validations
        private bool _CheckNonEmpty()
        {
            return !string.IsNullOrWhiteSpace(txtTitle.Text) &&
                   !string.IsNullOrWhiteSpace(txtDescription.Text) &&
                   !string.IsNullOrWhiteSpace(txtFees.Text);
        }

        private void RequiredField_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (string.IsNullOrWhiteSpace(txt.Text))
                epRequired.SetError(txt, "This field is required.");
            else
                epRequired.SetError(txt, "");
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_CheckNonEmpty())
            {
                MessageBox.Show("There are Unfilled fields.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTestType testType = clsTestType.Find(testTypeID);

            if (testType != null)
            {
                testType.Title = txtTitle.Text;
                testType.Description = txtDescription.Text;
                testType.Fees = Convert.ToDecimal(txtFees.Text);

                if (testType.Save())
                {
                    MessageBox.Show($"Test type updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Updated = true;
                }
                else
                {
                    MessageBox.Show("Failed to edit test type", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Updated)
                TestTypeUpdatedEventHandler?.Invoke();
            this.Close();
        }
    }

}
