using DVLD_DesktopApp.TestTypes;
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

namespace DVLD_DesktopApp.TestTypes
{
    public partial class frmListTestTypes : Form
    {
        public frmListTestTypes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _RefreshList();
        }

        private void _RefreshList()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();
            lblRecordsCount.Text = dgvTestTypes.RowCount.ToString();
            dgvTestTypes.Columns["TestTypeTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTestTypes.Columns["TestTypeDescription"].Width = 250;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppID = Convert.ToInt32(dgvTestTypes.CurrentRow.Cells["TestTypeID"].Value);
            frmEditTestType frm = new frmEditTestType(AppID);
            frm.TestTypeUpdatedEventHandler += _RefreshList;
            frm.ShowDialog();
        }
    }
}
