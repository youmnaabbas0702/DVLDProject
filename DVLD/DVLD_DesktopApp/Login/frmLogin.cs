using DVLDBusiness;
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
            string filePath = Path.Combine(Application.StartupPath, "credentials.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length >= 2)
                {
                    txtUserName.Text = lines[0];
                    txtPassword.Text = lines[1];
                    chkRememberMe.Checked = true;
                }
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

        private void SaveCredentials(string username, string password)
        {
            string filePath = Path.Combine(Application.StartupPath, "credentials.txt");
            File.WriteAllText(filePath, $"{username}\n{password}");
        }

        private void ClearCredentials()
        {
            string filePath = Path.Combine(Application.StartupPath, "credentials.txt");
            if (File.Exists(filePath))
                File.Delete(filePath);
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
                        SaveCredentials(currentUser.UserName, currentUser.Password);
                    }
                    else
                        ClearCredentials();
                }
                else
                    MessageBox.Show("Your Account is not active please contact your admin.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Invalid UserName or Password.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
