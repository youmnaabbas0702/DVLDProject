using DVLD_DesktopApp;
using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsUser
    {
        public enum enMode { AddNew, Update }

        public int UserID { get; private set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsPerson PersonInfo;

        public enMode Mode { get; private set; }

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            this.PersonInfo = clsPerson.Find(PersonID);//composition
            UserName = userName;
            Password = password;
            IsActive = isActive;

            Mode = enMode.Update;
        }

        public static clsUser Find(int userID)
        {
            int personID = -1;
            string userName = "", password = "";
            bool isActive = false;

            bool isFound = clsUserData.GetUserInfoByUserID(userID, ref personID, ref userName, ref password, ref isActive);

            if (isFound)
            {
                return new clsUser(userID, personID, userName, password, isActive);
            }

            return null;
        }

        public static clsUser Find(string userName)
        {
            int userID = -1;
            int personID = -1;
            string password = "";
            bool isActive = false;

            bool isFound = clsUserData.GetUserInfoByUserName(userName, ref userID, ref personID, ref password, ref isActive);

            if (isFound)
            {
                return new clsUser(userID, personID, userName, password, isActive);
            }

            return null;
        }

        private bool _AddNewUser()
        {
            if (UserExists(PersonID))
                return false; // handle user not duplicated for same personID

            this.UserID = clsUserData.AddNewUser(PersonID, UserName, Password, IsActive);
            return this.UserID != -1;
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(UserID, UserName, Password, IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateUser();
                default:
                    return false;
            }
        }

        public static bool Delete(int userID)
        {
            return clsUserData.DeleteUser(userID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool UserExists(string userName, string password)
        {
            return clsUserData.UserExists(userName, password);
        }

        public static bool UserExists(int personID)
        {
            return clsUserData.UserExists(personID);
        }
    }

}
