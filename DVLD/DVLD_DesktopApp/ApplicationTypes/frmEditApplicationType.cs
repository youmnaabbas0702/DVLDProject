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

namespace DVLD_DesktopApp.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private int appTypeID = -1;
        private bool Updated = false;
        public event Action ApplicationTypeUpdatedEventHandler;

        public frmEditApplicationType(int ID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            appTypeID = ID;
            _LoadInfo();
        }

        private void _LoadInfo()
        {
            clsApplicationType appType = clsApplicationType.Find(appTypeID);
            if (appType != null)
            {
                lblID.Text = appType.ApplicationTypeID.ToString();
                txtTitle.Text = appType.Title;
                txtFees.Text = appType.Fees.ToString();
            }
        }

        //validations
        private bool _CheckNonEmpty()
        {
            return !string.IsNullOrWhiteSpace(txtTitle.Text) &&
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

            clsApplicationType applicationType = clsApplicationType.Find(appTypeID);
            
            if(applicationType != null)
            {
                applicationType.Title = txtTitle.Text;
                applicationType.Fees = Convert.ToDecimal(txtFees.Text);

                if (applicationType.Save())
                {
                    {
                        MessageBox.Show($"Application type updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Updated = true;
                    }
                }
                else
                    MessageBox.Show("Failed to edit application type", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Updated)
                ApplicationTypeUpdatedEventHandler?.Invoke();
            this.Close();
        }

        
    }
}
