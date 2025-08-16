using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; private set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        private clsLicenseClass(int licenseClassID, string className, string classDescription,
            byte minimumAllowedAge, byte defaultValidityLength, decimal classFees)
        {
            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }

        public static clsLicenseClass Find(int licenseClassID)
        {
            string className = "", classDescription = "";
            byte minimumAllowedAge = 0, defaultValidityLength = 0;
            decimal classFees = 0;

            bool isFound = clsLicenseClassData.GetLicenseClassInfoByID(
                licenseClassID, ref className, ref classDescription,
                ref minimumAllowedAge, ref defaultValidityLength, ref classFees);

            if (isFound)
            {
                return new clsLicenseClass(
                    licenseClassID, className, classDescription,
                    minimumAllowedAge, defaultValidityLength, classFees
                );
            }

            return null;
        }

        public static List<String> GetAllLicenseClassNames()
        {
            return clsLicenseClassData.GetAllClassNames();
        }
    }
}
