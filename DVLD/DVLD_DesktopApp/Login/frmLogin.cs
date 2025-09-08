using DVLD_DesktopApp.GeneralClasses;
using DVLDBusiness;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadCredentials();
        }

        private void LoadCredentials()
        {
            string username = string.Empty;
            string password = string.Empty;

            if (clsLoginManager.LoadCredentials(ref username, ref password))
            {
                txtUserName.Text = username;
                txtPassword.Text = password;
                chkRememberMe.Checked = true;
            }
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

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (clsUser.UserExists(txtUserName.Text, txtPassword.Text))
            {
                clsUser currentUser = clsUser.Find(txtUserName.Text);
                if (currentUser.IsActive)
                {
                    clsGlobalSettings.CurrentUser = currentUser;
                    this.DialogResult = DialogResult.OK;

                    if (chkRememberMe.Checked)
                    {
                        if(!clsLoginManager.SaveCredentials(currentUser.UserName, currentUser.Password))
                            MessageBox.Show("Failed to save username and password.", "Fail",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        clsLoginManager.ClearCredentials();
                }
                else
                    MessageBox.Show("Your Account is not active please contact your admin.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Invalid UserName or Password.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
