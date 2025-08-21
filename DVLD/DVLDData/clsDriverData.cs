using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsDriverData
    {
        public static int AddNewDriver(int personID, DateTime createdDate, int createdByUserID)
        {
            int newDriverID = -1;

            string query = @"INSERT INTO Drivers (PersonID, CreatedDate, CreatedByUserID) 
                         VALUES (@PersonID, @CreatedDate, @CreatedByUserID);
                         SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", personID);
                command.Parameters.AddWithValue("@CreatedDate", createdDate);
                command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        newDriverID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    newDriverID = -1;
                }
            }

            return newDriverID;
        }

        public static bool IsDriverExist(int personID)
        {
            bool isExist = false;
            string query = "SELECT Found = 1 FROM Drivers WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", personID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null) isExist = true;
                }
                catch { isExist = false; }
            }

            return isExist;
        }

        public static int GetDriverIDByPersonID(int personID)
        {
            int driverID = -1;

            string query = @"SELECT DriverID FROM Drivers WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", personID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        driverID = id;
                    }
                }
                catch
                {
                    driverID = -1; // in case of error
                }
            }

            return driverID;
        }

        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM vw_Drivers";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
            }

            return dt;
        }
    }
}
