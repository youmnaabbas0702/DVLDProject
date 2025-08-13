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
    public partial class frmAddEditUser : Form
    {
        public event Action OperationOccuredEventHandler;
        private int _UserID = -1;
        private clsUser.enMode _Mode = clsUser.enMode.AddNew;
        private bool _OperationOccured = false;
        bool allowTabChange = false;
        
        public frmAddEditUser()
        {
            InitializeComponent();
            _SetUp();
        }

        public frmAddEditUser(int ID) : this()
        {
            _UserID = ID;
            _Mode = clsUser.enMode.Update;
            lblTitle.Text = "Update User";
            _LoadUserInfo();
        }

        private void _SetUp()
        {
            this.Size = new Size(650, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            txtConfirmPassword.Leave += ConfirmPassword_Leave;
        }

        private void _LoadUserInfo()
        {
            clsUser user = clsUser.Find(_UserID);
            ctrlPersonCardWithFilter1.PersonID = user.PersonID;
            ctrlPersonCardWithFilter1.FillPersonCard();
            lblUserID.Text = user.UserID.ToString();
            txtUserName.Text = user.UserName;
            txtPassword.Text = user.Password;
            txtConfirmPassword.Text = user.Password;
            chkIsActive.Checked = user.IsActive;
        }

        //validations
        private void RequiredField_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (string.IsNullOrWhiteSpace(txt.Text))
                epRequired.SetError(txt, "This field is required.");
            else
                epRequired.SetError(txt, "");
        }

        private void ConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
                epPassMatch.SetError(txtConfirmPassword, "Passwords do not match.");
            else
                epPassMatch.SetError(txtConfirmPassword, "");
        }

        private bool _CheckNonEmpty()
        {
            return !string.IsNullOrWhiteSpace(txtUserName.Text) &&
           !string.IsNullOrWhiteSpace(txtPassword.Text) &&
           !string.IsNullOrWhiteSpace(txtConfirmPassword.Text);
        }

        //Add\Edit
        private bool _AddNewUser()
        {
            clsUser user = new clsUser();
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.PersonID = ctrlPersonCardWithFilter1.PersonID;
            user.IsActive = chkIsActive.Checked;
            if (user.Save())
            {
                lblUserID.Text = user.UserID.ToString();
                _UserID = user.UserID;
                return true;
            }
            return false;
        }

        private bool _EditUser()
        {
            clsUser user = clsUser.Find(Convert.ToInt32(lblUserID.Text));
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.PersonID = ctrlPersonCardWithFilter1.PersonID;
            user.IsActive = chkIsActive.Checked;
            return user.Save();
        }

        //tab change
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tpLoginInfo && !allowTabChange)
            {
                e.Cancel = true;
            }
        }

        //buttons
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if(_Mode == clsUser.enMode.AddNew)
            {
                if (clsUser.UserExists(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected person already has a user, choose another one.", "Choose another person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if(ctrlPersonCardWithFilter1.PersonID != 0)
                allowTabChange = true;
            tabControl1.SelectedTab = tpLoginInfo;
            allowTabChange = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OperationOccuredEventHandler?.Invoke();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_CheckNonEmpty())
            {
                MessageBox.Show("There are Unfilled fields.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (_Mode)
            {
                case clsUser.enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {
                            MessageBox.Show($"User added successfully with ID = {_UserID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mode = clsUser.enMode.Update;
                            _OperationOccured = true;
                        }
                        else
                            MessageBox.Show("Failed to add user", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case clsUser.enMode.Update:
                    if(_EditUser())
                    {
                        _OperationOccured = true;
                        MessageBox.Show($"User updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Failed to edit user", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }
    }
}
