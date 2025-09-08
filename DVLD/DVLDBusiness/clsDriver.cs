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
    public class clsDriver
    {
        public int DriverID { get; private set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }


        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedDate = DateTime.Now;
            CreatedByUserID = -1;
        }

        private clsDriver(int driverID, int personID, DateTime createdDate, int createdByUserID)
        {
            DriverID = driverID;
            PersonID = personID;
            this.PersonInfo = clsPerson.Find(personID);
            CreatedDate = createdDate;
            CreatedByUserID = createdByUserID;
        }

        public static clsDriver Find(int driverID)
        {
            int personID = -1;
            DateTime createdDate = DateTime.Now;
            int createdByUserID = -1;

            if (clsDriverData.Find(driverID, ref personID, ref createdDate, ref createdByUserID))
            {
                return new clsDriver(driverID, personID, createdDate, createdByUserID);
            }
            else
                return null;
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
