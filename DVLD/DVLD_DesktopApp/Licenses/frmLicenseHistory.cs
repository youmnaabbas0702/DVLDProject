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

namespace DVLD_DesktopApp.Licenses
{
    public partial class frmLicenseHistory : Form
    {
        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(710, 670);
            ctrlPersonCardWithFilter1.PersonID = PersonID;
            ctrlPersonCardWithFilter1.FillPersonCard();

            LoadLicensesHistory(PersonID);

        }

        private void LoadLicensesHistory(int PersonID)
        {
            ctrlLicenseHistory1.LoadLocalLicenses(PersonID);
            int DriverID = clsDriver.GetDriverIDByPersonID(PersonID);
            ctrlLicenseHistory1.LoadInternationalLicenses(DriverID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
