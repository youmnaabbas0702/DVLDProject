using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopApp.Licenses
{
    public partial class frmIntLicenseInfo : Form
    {
        public frmIntLicenseInfo(int licenseID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ctrlInternationalLicenseInfo1.LoadLicenseInfo(licenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
