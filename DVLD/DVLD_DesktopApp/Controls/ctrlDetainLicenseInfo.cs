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
    public partial class ctrlDetainLicenseInfo : UserControl
    {
        public decimal FineFees
        {
            get
            {
                if (txtFineFees == null || string.IsNullOrWhiteSpace(txtFineFees.Text))
                    return 0m; // Default value if label is not set

                if (decimal.TryParse(txtFineFees.Text, out decimal value))
                    return value;

                return 0m; // Default if parsing fails
            }
        }

        public ctrlDetainLicenseInfo()
        {
            InitializeComponent();
            lblAppDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser?.UserName ?? "Unknown";
        }

        public void SetLicenseID(int LicenseID)
        {
            lblLicenseID.Text = LicenseID.ToString();
        }

        public void SetDetainID(int DetainID)
        {
            lblDetainID.Text = DetainID.ToString();
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
