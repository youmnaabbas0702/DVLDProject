using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassInfoByID(
        int licenseClassID,
        ref string className,
        ref string classDescription,
        ref byte minimumAllowedAge,
        ref byte defaultValidityLength,
        ref decimal classFees)
        {
            bool isFound = false;
            string query = @"SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        className = (string)reader["ClassName"];
                        classDescription = (string)reader["ClassDescription"];
                        minimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"]);
                        defaultValidityLength = Convert.ToByte(reader["DefaultValidityLength"]);
                        classFees = Convert.ToDecimal(reader["ClassFees"]);

                        isFound = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogError(ex);

                return false;
            }

            return isFound;
        }

        public static List<string> GetAllClassNames()
        {
            List<string> classNames = new List<string>();

            string query = "SELECT ClassName FROM LicenseClasses";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        classNames.Add(reader["ClassName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogError(ex);

                return classNames;
            }

            return classNames;
        }

    }
}
