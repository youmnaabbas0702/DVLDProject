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
    public partial class ctrlReplaceLicenseApp : UserControl
    {
        public ctrlReplaceLicenseApp()
        {
            InitializeComponent();
            lblAppDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser?.UserName ?? "Unknown";
        }

        public void InitializeApplicationInfo(int OldLicenseID)
        {
            clsLicense license = clsLicense.Find(OldLicenseID);
            lblOldLicenseID.Text = license.LicenseID.ToString();
            int LicenseValidity = clsLicenseClass.Find(license.LicenseClass).DefaultValidityLength;
        }

        public void SetReplaceType(int ReplaceType)
        {
            lblAppFees.Text = clsApplicationType.Find(ReplaceType)?.Fees.ToString();
        }

        public void SetReplacedLicenseInfo(int appID, int LicenseID)
        {
            lblRenewAppID.Text = appID.ToString();
            lblReplacedID.Text = LicenseID.ToString();
        }
    }
}
