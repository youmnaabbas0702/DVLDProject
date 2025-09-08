using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsPersonData
    {
        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName,
            ref string LastName, ref string NationalNo, ref DateTime DateOfBirth, ref short Gender, ref string Address, ref string Phone,
            ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        FirstName = (string)reader["FirstName"];
                        SecondName = (string)reader["SecondName"];

                        if (reader["ThirdName"] != DBNull.Value)
                        {
                            ThirdName = (string)reader["ThirdName"];
                        }
                        else
                            ThirdName = "";

                        LastName = (string)reader["LastName"];
                        NationalNo = (string)reader["NationalNo"];
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                        Gender = Convert.ToInt16(reader["Gendor"]);
                        Address = (string)reader["Address"];
                        Phone = (string)reader["Phone"];

                        if (reader["Email"] != DBNull.Value)
                        {
                            Email = (string)reader["Email"];
                        }
                        else
                            Email = "";

                        NationalityCountryID = (int)reader["NationalityCountryID"];

                        if (reader["ImagePath"] != DBNull.Value)
                        {
                            ImagePath = (string)reader["ImagePath"];
                        }
                        else
                            ImagePath = "";
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

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
            ref string LastName, ref int PersonID, ref DateTime DateOfBirth, ref short Gender, ref string Address, ref string Phone,
            ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        FirstName = (string)reader["FirstName"];
                        SecondName = (string)reader["SecondName"];

                        if (reader["ThirdName"] != DBNull.Value)
                        {
                            ThirdName = (string)reader["ThirdName"];
                        }
                        else
                            ThirdName = "";

                        LastName = (string)reader["LastName"];
                        PersonID = (int)reader["PersonID"];
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                        Gender = Convert.ToInt16(reader["Gendor"]);
                        Address = (string)reader["Address"];
                        Phone = (string)reader["Phone"];

                        if (reader["Email"] != DBNull.Value)
                        {
                            Email = (string)reader["Email"];
                        }
                        else
                            Email = "";

                        NationalityCountryID = (int)reader["NationalityCountryID"];

                        if (reader["ImagePath"] != DBNull.Value)
                        {
                            ImagePath = (string)reader["ImagePath"];
                        }
                        else
                            ImagePath = "";
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

        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName,
            string LastName, string NationalNo, DateTime DateOfBirth, short Gender, string Address, string Phone,
            string Email, int NationalityCountryID, string ImagePath)
        {
            int ID = -1;
            string query = @"insert into People(FirstName, SecondName, ThirdName,LastName, NationalNo,
                             DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                             Values (@FirstName, @SecondName, @ThirdName,@LastName, @NationalNo, @DateOfBirth, 
                            @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath)
                            SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                    if (ThirdName != "")
                        command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    else
                        command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

                    if (Email != "")
                        command.Parameters.AddWithValue("@Email", Email);
                    else
                        command.Parameters.AddWithValue("@Email", DBNull.Value);

                    if (ImagePath != "")
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    else
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if(result != null && int.TryParse(result.ToString(), out int Id))
                    {
                        ID = Id;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogError(ex);

                return -1;
            }
            return ID;
        }

        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName, string ThirdName,
            string LastName, string NationalNo, DateTime DateOfBirth, short Gender, string Address, string Phone,
            string Email, int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;
            string query = @"UPDATE People
                            Set FirstName = @FirstName,
                            SecondName = @SecondName, 
                            ThirdName = @ThirdName,
                            LastName = @LastName, 
                            NationalNo = @NationalNo,
                            DateOfBirth = @DateOfBirth,
                            Gendor = @Gender,
                            Address = @Address,
                            Phone = @Phone,
                            Email = @Email,
                            NationalityCountryID = @NationalityCountryID, 
                            ImagePath = @ImagePath
                            Where PersonID = @PersonID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                    if (ThirdName != "")
                        command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    else
                        command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

                    if (Email != "")
                        command.Parameters.AddWithValue("@Email", Email);
                    else
                        command.Parameters.AddWithValue("@Email", DBNull.Value);

                    if (ImagePath != "")
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    else
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                    
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogError(ex);

                return false;
            }
            return (rowsAffected > 0);
        }

        public static bool DeletePerson(int PersonID)
        {
            string query = @"delete from People where PersonID = @PersonID";
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogError(ex);

                return false;
            }
            return (rowsAffected > 0);
        }

        public static DataTable GetAllPeople()
        {
            string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, 
                        People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth,
                        CASE Gendor
                            WHEN 0 THEN 'Male'
                            WHEN 1 THEN 'Female'
                            ELSE 'Unknown'
                        END AS Gender, 
                        People.Address, Countries.CountryName AS Nationality, 
                        People.Phone, People.Email
                    FROM Countries
                    INNER JOIN People ON Countries.CountryID = People.NationalityCountryID";

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
            catch (Exception ex)
            {
                clsLogger.LogError(ex);

                return dt;
            }
            return dt;
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;
            string query = "SELECT Found = 1 FROM People WHERE PersonID = @PersonID";

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
            catch (Exception ex)
            {
                clsLogger.LogError(ex);

                return false;
            }
            return isFound;
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;
            string query = "SELECT Found = 1 FROM People WHERE NationalNo = @NationalNo";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        isFound = reader.HasRows;
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

    }
}
