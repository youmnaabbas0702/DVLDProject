using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsLocalLicenseApplication
    {
        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public enum enMode { AddNew, Update }
        public enMode Mode { get; private set; }

        public clsLocalLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
            Mode = enMode.AddNew;
        }

        private clsLocalLicenseApplication(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
        {
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
            Mode = enMode.Update;
        }

        public static clsLocalLicenseApplication Find(int localDrivingLicenseApplicationID)
        {
            int applicationID = -1;
            int licenseClassID = -1;

            bool isFound = clsLocalLicenseApplicationData.GetLocalLicenseApplicationInfoByID(
                localDrivingLicenseApplicationID, ref applicationID, ref licenseClassID);

            if (isFound)
            {
                return new clsLocalLicenseApplication(localDrivingLicenseApplicationID, applicationID, licenseClassID);
            }

            return null;
        }

        private bool _AddNew()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalLicenseApplicationData.AddNewLocalLicenseApplication(
                ApplicationID, LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _Update()
        {
            return clsLocalLicenseApplicationData.UpdateLocalLicenseApplication(
                LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _Update();
                default:
                    return false;
            }
        }

        public static bool Delete(int localDrivingLicenseApplicationID)
        {
            return clsLocalLicenseApplicationData.DeleteLocalLicenseApplication(localDrivingLicenseApplicationID);
        }

        public static DataTable GetAllApplications()
        {
            return clsLocalLicenseApplicationData.GetAllApplications();
        }

        public static int ExistingApplicationID(int personID, int classID)
        {
            return clsLocalLicenseApplicationData.GetActiveApplicationID(personID, classID);
        }

        public DataRow GetApplicationDetails()
        {
            return clsLocalLicenseApplicationData.GetLocalLicenseApplicationDetails(LocalDrivingLicenseApplicationID);
        }
    }

}
