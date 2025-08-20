using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopApp.Applications.LocalLicenseApplications
{
    public partial class frmAppDetails : Form
    {
        public frmAppDetails(int AppID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ctrlLicenseAppDetails1.LicenseAppID = AppID;
            ctrlLicenseAppDetails1.LoadLicenseAppInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
