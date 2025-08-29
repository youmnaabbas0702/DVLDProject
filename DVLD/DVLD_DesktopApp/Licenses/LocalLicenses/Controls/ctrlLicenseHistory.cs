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
    public partial class ctrlLicenseHistory : UserControl
    {
        public ctrlLicenseHistory()
        {
            InitializeComponent();
        }

        public void LoadLocalLicenses(int PersonID)
        {
            dgvLocalLicenses.DataSource = clsLicense.GetLicensesByPerson(PersonID);
            lblLocalCount.Text = dgvLocalLicenses.RowCount.ToString();
        }

        public void LoadInternationalLicenses(int DriverID)
        {
            dgvInternationalLicenses.DataSource = clsInternationalLicense.GetLicensesHistory(DriverID);
            lblIntCount.Text = dgvInternationalLicenses.RowCount.ToString();
        }
    }
}
