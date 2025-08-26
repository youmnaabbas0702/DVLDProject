using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsLicense
    {
        public int LicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; private set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; private set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClass = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = true;
            IssueReason = 1;
            CreatedByUserID = -1;

        }

        public clsLicense(int licenseID, int applicationID, int driverID, int licenseClass,
                  DateTime issueDate, DateTime expirationDate, string notes,
                  decimal paidFees, bool isActive, byte issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClass = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
        }

        public static clsLicense Find(int licenseID)
        {
            int applicationID = 0, driverID = 0, licenseClass = 0, createdByUserID = 0;
            DateTime issueDate = DateTime.MinValue, expirationDate = DateTime.MinValue;
            string notes = "";
            decimal paidFees = 0;
            bool isActive = false;
            byte issueReason = 0;

            bool isFound = clsLicenseData.Find(licenseID, ref applicationID, ref driverID, ref licenseClass,
                                               ref issueDate, ref expirationDate, ref notes,
                                               ref paidFees, ref isActive, ref issueReason, ref createdByUserID);

            if (isFound)
            {
                return new clsLicense(licenseID, applicationID, driverID, licenseClass, issueDate,
                                      expirationDate, notes, paidFees, isActive, issueReason, createdByUserID);
            }
            else
            {
                return null;
            }
        }


        private bool _AddNewLicense()
        {
            clsLicenseClass licenseClassInfo = clsLicenseClass.Find(this.LicenseClass);
            if (licenseClassInfo != null)
            {
                ExpirationDate = IssueDate.AddYears(licenseClassInfo.DefaultValidityLength);
            }
            else
            {
                return false;
            }

            int personID = clsApplication.Find(this.ApplicationID).ApplicantPersonID;
            if (!clsDriver.IsDriverExist(personID))
            {
                clsDriver driver = new clsDriver()
                {
                    PersonID = personID,
                    CreatedDate = DateTime.Now,
                    CreatedByUserID = this.CreatedByUserID
                };

                if (driver.Save())
                    this.DriverID = driver.DriverID;
                else
                    return false;
            }
            else
            {
                this.DriverID = clsDriver.GetDriverIDByPersonID(personID);
            }

            this.LicenseID = clsLicenseData.AddNewLicense(
                this.ApplicationID, this.DriverID, this.LicenseClass,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
                this.IsActive, this.IssueReason, this.CreatedByUserID
            );

            if(this.LicenseID != -1)
            {
                clsApplication.ChangeStatus(ApplicationID, 3);

                return true;
            }

            return false;
        }

        public bool Save()
        {
            return _AddNewLicense();
        }

        public static int GetLicenseIDByLocalAppID(int localAppID)
        {
            return clsLicenseData.GetLicenseIDByLocalAppID(localAppID);
        }

        public bool Deactivate()
        {
            return clsLicenseData.DeactivateLicense(this.LicenseID);
        }
        
        public bool Activate()
        {
            return clsLicenseData.ActivateLicense(this.LicenseID);
        }

        public static DataRow GetLicenseDetails(int LicenseID)
        {
            return clsLicenseData.GetLicenseDetailsByLicenseID(LicenseID);
        }

        public static DataTable GetLicensesByPerson(int personID)
        {
            return clsLicenseData.GetLicensesByPersonID(personID);
        }

        public static int GetActiveLicenseID(int driverId)
        {
            return clsLicenseData.GetActiveLicenseID(driverId);
        }
    }
}
