using DVLD_DesktopApp.People;
using DVLD_DesktopApp.Properties;
using DVLDBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopApp.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        public int PersonID { set; get; }

        private string picturesFolder = @"C:\DVLD-People-Images";

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void _SetPersonPicture(short Gender)
        {
            switch (Gender)
            {
                case 1:
                    pbImage.Image = Resources.FemaleImage;
                    break;
                default:
                    pbImage.Image = Resources.MaleImage;
                    break;
            }
            //pbImage.Tag = 0;
        }

        public void LoadPersonInfo()
        {
            clsPerson person = clsPerson.Find(PersonID);
            if (person != null)
            {
                lblPersonID.Text = person.PersonID.ToString();
                lblName.Text = person.FullName();
                lblEmail.Text = person.Email;
                lblPhone.Text = person.Phone;
                lblNationalNo.Text = person.NationalNo;
                lblAddress.Text = person.Address;
                
                if(person.Gender == 0)
                {
                    lblGender.Text = "Male";
                    lblGenderIcon.Image = Resources.Male;
                }
                else
                {
                    lblGender.Text = "Female";
                    lblGenderIcon.Image = Resources.Female;
                }
                
                lblCountry.Text = clsCountry.GetCountryName(person.NationalityCountryID);
                lblDateOfBirth.Text = person.DateOfBirth.ToString("yyyy-MM-dd");

                _SetPersonPicture(person.Gender);
                string fullPath = Path.Combine(picturesFolder, person.ImagePath);
                if (File.Exists(fullPath))
                {
                    pbImage.Image = Image.FromFile(fullPath);
                }
            }
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(PersonID);
            frm.OperationOccuredEventHandler += LoadPersonInfo;
            frm.ShowDialog();
        }
    }
}
