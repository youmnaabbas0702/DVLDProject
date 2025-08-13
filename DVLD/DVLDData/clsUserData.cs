using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsUserData
    {
        public static bool GetUserInfoByUserID(int userID, ref int personID, ref string userName, ref string password, ref bool isActive)
        {
            bool isFound = false;
            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        personID = (int)reader["PersonID"];
                        userName = (string)reader["UserName"];
                        password = (string)reader["Password"];
                        isActive = (bool)reader["IsActive"];

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

        public static bool GetUserInfoByUserName(string userName, ref int userID, ref int personID, ref string password, ref bool isActive)
        {
            bool isFound = false;
            string query = "SELECT * FROM Users WHERE UserName = @UserName";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", userName);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        userID = (int)reader["UserID"];
                        personID = (int)reader["PersonID"];
                        password = (string)reader["Password"];
                        isActive = (bool)reader["IsActive"];

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

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int ID = -1;
            string query = @"INSERT INTO Users(PersonID, UserName, Password, IsActive)
                         VALUES (@PersonID, @UserName, @Password, @IsActive);
                         SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int Id))
                    {
                        ID = Id;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }
            return ID;
        }

        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {
            int rowsAffected = 0;
            string query = @"UPDATE Users
                     SET UserName = @UserName,
                         Password = @Password,
                         IsActive = @IsActive
                     WHERE UserID = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;
            string query = "DELETE FROM Users WHERE UserID = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", UserID);

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

        public static DataTable GetAllUsers()
        {
            string query = @"SELECT UserID, PersonID, UserName, IsActive
                         FROM Users";

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

        public static bool UserExists(string UserName, string Password)
        {
            bool isFound = false;
            string query = "SELECT Found = 1 FROM Users WHERE UserName = @UserName AND Password = @Password";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        isFound = reader.HasRows;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return isFound;
        }

        public static bool UserExists(int PersonID)
        {
            bool isFound = false;
            string query = "SELECT Found = 1 FROM Users WHERE PersonID = @PersonID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        isFound = reader.HasRows;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return isFound;
        }
    }

}
