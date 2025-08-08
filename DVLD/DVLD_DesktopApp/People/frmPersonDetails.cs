using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopApp.People
{
    public partial class frmPersonDetails : Form
    {
        private int _PersonID = 0;
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _PersonID = PersonID;
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.PersonID = _PersonID;
            ctrlPersonCard1.LoadPersonInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
