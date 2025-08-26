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
    public partial class ctrlReleaseLicenseInfo : UserControl
    {
        public ctrlReleaseLicenseInfo()
        {
            InitializeComponent();
        }

        public void SetDetainInfo(int DetainID)
        {
            DataRow detainInfo = clsDetainedLicense.Find(DetainID);
            if (detainInfo != null)
            {
                lblDetainID.Text = detainInfo["DetainID"].ToString();
                lblLicenseID.Text = detainInfo["LicenseID"].ToString();
                lblFineFees.Text = Convert.ToDecimal(detainInfo["FineFees"]).ToString("0.00");
                lblCreatedBy.Text = clsUser.Find(Convert.ToInt32(detainInfo["CreatedByUserID"]))?.UserName ?? "Unknown";
            }

            lblAppDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblAppFees.Text = clsApplicationType.Find(5)?.Fees.ToString();
            lblTotalFees.Text =
            (Convert.ToDecimal(lblFineFees.Text) + Convert.ToDecimal(lblAppFees.Text)).ToString("0.00");
        }

        public void SetAppID(int appID)
        {
            lblAppID.Text = appID.ToString();
        }
    }
}
