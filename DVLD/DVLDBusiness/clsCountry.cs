using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsCountry
    {
        public int ID { get; set; }
        public string CountryName { get; set; }

        private clsCountry(int ID, string CountryName)

        {
            this.ID = ID;
            this.CountryName = CountryName;
        }

        public static clsCountry Find(int ID)
        {
            string CountryName = "";

            if (clsCountryData.FindCountryByID(ID, ref CountryName))

                return new clsCountry(ID, CountryName);
            else
                return null;

        }

        public static List<string> GetAllCountries()
        {
            return clsCountryData.GetAllCountries().AsEnumerable()
                .Select(row => row["CountryName"].ToString()).ToList();
        }

        public static string GetCountryName(int ID)
        {
            string countryName = "";
            if(clsCountryData.FindCountryByID(ID, ref countryName))
                return countryName;
            return "";
        }
    }
}
