using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsTestTypeData
    {
        public static bool GetTestTypeInfoByID(int TestTypeID, ref string title, ref string description, ref decimal fees)
        {
            bool isFound = false;
            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", TestTypeID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        title = (string)reader["TestTypeTitle"];
                        description = (string)reader["TestTypeDescription"];
                        fees = (decimal)reader["TestTypeFees"];

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

        public static DataTable GetAllTestTypes()
        {
            string query = @"SELECT * from TestTypes";

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

        public static bool UpdateTestType(int TestTypeID, string Title, string Description, decimal Fees)
        {
            int rowsAffected = 0;
            string query = @"UPDATE TestTypes
                     SET TestTypeTitle = @Title,
                         TestTypeDescription = @Description,
                         TestTypeFees = @Fees
                     WHERE TestTypeID = @TestTypeID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Description", Description);
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
