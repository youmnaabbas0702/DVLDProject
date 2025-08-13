using DVLD_DesktopApp.Users;
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

namespace DVLD_DesktopApp.ApplicationTypes
{
    public partial class frmListApplicationTypes : Form
    {
        public frmListApplicationTypes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _RefreshList();
        }

        private void _RefreshList()
        {
            dgvAppTypes.DataSource = clsApplicationType.GetAllApplicationTypes();
            lblRecordsCount.Text = dgvAppTypes.RowCount.ToString();
            dgvAppTypes.Columns["ApplicationTypeTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppID = Convert.ToInt32(dgvAppTypes.CurrentRow.Cells["ApplicationTypeID"].Value);
            frmEditApplicationType frm = new frmEditApplicationType(AppID);
            frm.ApplicationTypeUpdatedEventHandler += _RefreshList;
            frm.ShowDialog();
        }
    }
}
