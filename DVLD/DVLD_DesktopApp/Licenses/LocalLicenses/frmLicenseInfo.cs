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
    public partial class frmLicenseInfo : Form
    {
        public frmLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ctrlDriverLicenseInfo1.LoadLicenseInfo(LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
