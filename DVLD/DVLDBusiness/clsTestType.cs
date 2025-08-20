using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsTestType
    {
        public int TestTypeID { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public clsTestType(int testTypeID, string title, string description, decimal fees)
        {
            TestTypeID = testTypeID;
            Title = title;
            Description = description;
            Fees = fees;
        }

        public static clsTestType Find(int ID)
        {
            string title = "", description = "";
            decimal fees = 0;

            bool isFound = clsTestTypeData.GetTestTypeInfoByID(ID, ref title, ref description, ref fees);

            if (isFound)
            {
                return new clsTestType(ID, title, description, fees);
            }

            return null;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

        public bool Save()
        {
            return clsTestTypeData.UpdateTestType(TestTypeID, Title, Description, Fees);
        }
    }
}
