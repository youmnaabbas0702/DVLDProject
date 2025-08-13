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
    public partial class ctrlUserCard : UserControl
    {
        public int UserID { get; set; }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void LoadUserInfo()
        {
            clsUser user = clsUser.Find(UserID);
            if (user != null)
            {
                ctrlPersonCard1.PersonID = user.PersonID;
                ctrlPersonCard1.LoadPersonInfo();

                lblUserID.Text = user.UserID.ToString();
                lblUserName.Text = user.UserName;
                lblIsActive.Text = user.IsActive ? "Yes" : "No";
            }
        }
    }
}
