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
    public partial class frmChangePassword : Form
    {
        private int UserID = -1;
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            UserID = userID;
            txtOldPass.Leave += OldPassCheck;
            txtConfirmPassword.Leave += ConfirmPassCheck;

            ctrlUserCard1.UserID = UserID;
            ctrlUserCard1.LoadUserInfo();
        }

        private bool _CheckNonEmpty()
        {
            return !string.IsNullOrWhiteSpace(txtOldPass.Text) &&
       !string.IsNullOrWhiteSpace(txtNewPass.Text) &&
       !string.IsNullOrWhiteSpace(txtConfirmPassword.Text);

        }


        private void RequiredField_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(((TextBox)sender).Text))
            {
                epRequired.SetError((TextBox)sender, "This field is required");
            }
            else
                epRequired.SetError((TextBox)sender, "");
        }
        
        private void OldPassCheck(object sender, EventArgs e)
        {
            clsUser user = clsUser.Find(UserID);

            if(user != null)
            {
                if (SecurityHelper.HashPassword(txtOldPass.Text) != user.Password)
                {
                    epOldPassword.SetError(txtOldPass, "Old password is incorrect.");
                }
                else
                {
                    epOldPassword.SetError(txtOldPass, "");
                }
            }
        }

        private void ConfirmPassCheck(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPass.Text)
            {
                epPassMatch.SetError(txtConfirmPassword, "Passwords do not match.");
            }
            else
            {
                epPassMatch.SetError(txtConfirmPassword, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_CheckNonEmpty())
            {
                MessageBox.Show("There are Unfilled fields.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsUser user = clsUser.Find(UserID);

            if (user != null)
            {
                user.Password = txtNewPass.Text;
                if(user.Save())
                    MessageBox.Show("Password successfully changed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Password was not changed.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
