using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsApplicationType
    {
        
        public int ApplicationTypeID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }

        public clsApplicationType(int applicationTypeID, string title, decimal fees)
        {
            ApplicationTypeID = applicationTypeID;
            Title = title;
            Fees = fees;
        }

        public static clsApplicationType Find(int ID)
        {
            string title = "";
            decimal fees = 0;

            bool isFound = clsApplicationTypeData.GetApplicationTypeInfoByID(ID, ref title, ref fees);

            if (isFound)
            {
                return new clsApplicationType(ID, title, fees);
            }

            return null;
        }
        
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }

        public bool Save()
        {
            return clsApplicationTypeData.UpdateApplicationType(ApplicationTypeID, Title, Fees);
        }
    }
}
