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
    public partial class ctrlRenewLicenseApp : UserControl
    {
        public decimal TotalFees
        {
            get
            {
                if (lblTotalFees == null || string.IsNullOrWhiteSpace(lblTotalFees.Text))
                    return 0m; // Default value if label is not set

                if (decimal.TryParse(lblTotalFees.Text, out decimal value))
                    return value;

                return 0m; // Default if parsing fails
            }
        }

        public string Notes
        {
            get
            {
                return txtNotes?.Text ?? string.Empty;
            }
        }

        public ctrlRenewLicenseApp()
        {
            InitializeComponent();
            lblAppDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblIssueDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblAppFees.Text = clsApplicationType.Find(2)?.Fees.ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser?.UserName ?? "Unknown";
        }

        public void InitializeApplicationInfo(int OldLicenseID)
        {
            clsLicense license = clsLicense.Find(OldLicenseID);
            lblOldLicenseID.Text = license.LicenseID.ToString();
            int LicenseValidity = clsLicenseClass.Find(license.LicenseClass).DefaultValidityLength;
            lblExpirationDate.Text = DateTime.Today.AddYears(LicenseValidity).ToString();
            lblLicenseFees.Text = clsLicenseClass.Find(license.LicenseClass).ClassFees.ToString();
            txtNotes.Text = license.Notes;
            lblTotalFees.Text =
                (Convert.ToDecimal(lblAppFees.Text) + Convert.ToDecimal(lblLicenseFees.Text)).ToString();
        }

        public void SetRenewedLicenseInfo(int appID, int LicenseID)
        {
            lblRenewAppID.Text = appID.ToString();
            lblRenewedID.Text = LicenseID.ToString();
        }
    }
}
