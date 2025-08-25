using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsDetainedLicense
    {
        public int DetainID { get; private set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = null;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;
        }

        public static int DetainLicense(int licenseID, decimal fineFees, int createdByUserID)
        {
            return clsDetainedLicenseData.DetainLicense(licenseID, DateTime.Now, fineFees, createdByUserID);
        }

        public static bool IsLicenseDetained(int licenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(licenseID);
        }

        public static bool ReleaseLicense(int LicenseID, int releasedByUserID, int releaseAppID)
        {
            return clsDetainedLicenseData.ReleaseLicense(LicenseID, DateTime.Now, releasedByUserID, releaseAppID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }
    }
}
