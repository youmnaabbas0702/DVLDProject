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
    public partial class ctrlInternationalDriverInfo : UserControl
    {
        public ctrlInternationalDriverInfo()
        {
            InitializeComponent();
        }

        public void InitializeApplicationInfo(int LocalLicenseID)
        {
            lblLocalLicenseID.Text = LocalLicenseID.ToString();
            lblAppDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblIssueDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = DateTime.Today.AddYears(1).ToString("dd/MM/yyyy");
            lblFees.Text = clsTestType.Find(6)?.Fees.ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
        }

        public void SetLicenseInfo(int appID, int LicenseID)
        {
            lblILAppID.Text = appID.ToString();
            lblILID.Text = LicenseID.ToString();
        }
    }
}
