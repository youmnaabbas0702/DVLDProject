using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public static class clsCountry
    {
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
