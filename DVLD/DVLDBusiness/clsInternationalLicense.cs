using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsInternationalLicense
    {
        public int InternationalLicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = true;
            CreatedByUserID = -1;
        }
        
        private bool _AddNew()
        {
            InternationalLicenseID = clsInternationalLicenseData.AddNew(ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                   IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            return InternationalLicenseID != -1;
        }
        public bool Save()
        {
            return _AddNew();
        }

        public static DataRow GetLicenseDetails(int IntLicenseID)
        {
            return clsInternationalLicenseData.GetLicenseDetails(IntLicenseID);
        }

        public static bool ActiveLicenseExists(int driverID)
        {
            return clsInternationalLicenseData.ActiveLicenseExists(driverID);
        }

        public static DataTable GetLicensesHistory(int DriverID)
        {
            return clsInternationalLicenseData.GetInternationalLicensesByDriverID(DriverID);
        }

        public static DataTable GetAllLicenses()
        {
            return clsInternationalLicenseData.GetAllLicenses();
        }
    }
}
