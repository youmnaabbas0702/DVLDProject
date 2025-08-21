using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsDriver
    {
        public int DriverID { get; private set; }
        public int PersonID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }


        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedDate = DateTime.Now;
            CreatedByUserID = -1;
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(PersonID, CreatedDate, CreatedByUserID);
            return this.DriverID != -1;
        }

        public bool Save()
        {
            return _AddNewDriver();
        }

        public static bool IsDriverExist(int personID)
        {
            return clsDriverData.IsDriverExist(personID);
        }
        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }

        public static int GetDriverIDByPersonID(int personID)
        {
            return clsDriverData.GetDriverIDByPersonID(personID);
        }
    }
}
