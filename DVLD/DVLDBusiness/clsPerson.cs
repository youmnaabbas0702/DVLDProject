using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DesktopApp
{
    public class clsPerson
    {
        public enum enMode { AddNew, Update }

        public int PersonID { get; private set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public enMode Mode { get; private set; }

        public clsPerson()
        {
            PersonID = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            NationalNo = "";
            DateOfBirth = DateTime.Now;
            Gender = 0;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";

            Mode = enMode.AddNew;
        }

        private clsPerson(int personID, string firstName, string secondName, string thirdName,
            string lastName, string nationalNo, DateTime dateOfBirth, short gender, string address,
            string phone, string email, int nationalityCountryID, string imagePath)
        {
            PersonID = personID;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            NationalNo = nationalNo;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;

            Mode = enMode.Update;
        }

        public string FullName()
        {
            return $"{FirstName} {SecondName} {LastName}";
        }

        public static clsPerson Find(int personID)
        {
            string firstName = "", secondName = "", ThirdName = "", lastName = "", nationalNo = "", address = "", phone = "", email = "", imagePath = "";
            DateTime dateOfBirth = DateTime.Now;
            short gender = 0;
            int nationalityCountryID = -1;

            bool isFound = clsPersonData.GetPersonInfoByID(
                personID, ref firstName, ref secondName, ref ThirdName,
                ref lastName, ref nationalNo, ref dateOfBirth, ref gender,
                ref address, ref phone, ref email, ref nationalityCountryID, ref imagePath
            );

            if (isFound)
            {
                return new clsPerson(personID, firstName, secondName, ThirdName,
                    lastName, nationalNo, dateOfBirth, gender,
                    address, phone, email, nationalityCountryID, imagePath);
            }

            return null;
        }

        public static clsPerson Find(string nationalNo)
        {
            int personID = -1, nationalityCountryID = -1;
            string firstName = "", secondName = "", ThirdName = "", lastName = "", address = "", phone = "", email = "", imagePath = "";
            DateTime dateOfBirth = DateTime.Now;
            short gender = 0;

            bool isFound = clsPersonData.GetPersonInfoByNationalNo(
                nationalNo, ref firstName, ref secondName, ref ThirdName,
                ref lastName, ref personID, ref dateOfBirth, ref gender, ref address,
                ref phone, ref email, ref nationalityCountryID, ref imagePath
            );

            if (isFound)
            {
                return new clsPerson(personID, firstName, secondName, ThirdName,
                    lastName, nationalNo, dateOfBirth, gender,
                    address, phone, email, nationalityCountryID, imagePath);
            }

            return null;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(FirstName, SecondName, ThirdName,
            LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email,
            NationalityCountryID, ImagePath);
            return this.PersonID != -1;
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(PersonID, FirstName, SecondName, ThirdName,
                LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email,
                NationalityCountryID, ImagePath);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdatePerson();
                default:
                    return false; ;
            }
        }


        public static bool Delete(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }

    }
}
