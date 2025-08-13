using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsApplicationTypeData
    {
        public static bool GetApplicationTypeInfoByID(int AppTypeID, ref string title, ref decimal fees)
        {
            bool isFound = false;
            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", AppTypeID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        title = (string)reader["ApplicationTypeTitle"];
                        fees = (decimal)reader["ApplicationFees"];

                        isFound = true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return isFound;
        }

        public static DataTable GetAllApplicationTypes()
        {
            string query = @"SELECT * from ApplicationTypes";

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return dt;
            }
            return dt;
        }

        public static bool UpdateApplicationType(int ApplicationTypeID, string Title, decimal Fees)
        {
            int rowsAffected = 0;
            string query = @"UPDATE ApplicationTypes
                     SET ApplicationTypeTitle = @Title,
                         ApplicationFees = @Fees
                     WHERE ApplicationTypeID = @ApplicationTypeID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Fees", Fees);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return (rowsAffected > 0);
        }

    }
}
