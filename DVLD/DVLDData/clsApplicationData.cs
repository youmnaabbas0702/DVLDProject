using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsApplicationData
    {
        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantPersonID,ref DateTime ApplicationDate,
            ref int ApplicationTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;
            string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        ApplicantPersonID = (int)reader["ApplicantPersonID"];
                        ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                        ApplicationTypeID = (int)reader["ApplicationTypeID"];
                        ApplicationStatus = Convert.ToByte(reader["ApplicationStatus"]);
                        LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                        PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                        CreatedByUserID = (int)reader["CreatedByUserID"];

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

        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int ID = -1;

            string query = @"
            INSERT INTO Applications
            (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
            VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID)
            SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int newID))
                        ID = newID;
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return ID;
        }

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int rowsAffected = 0;

            string query = @"
            UPDATE Applications
            SET ApplicantPersonID = @ApplicantPersonID,
                ApplicationDate = @ApplicationDate,
                ApplicationTypeID = @ApplicationTypeID,
                ApplicationStatus = @ApplicationStatus,
                LastStatusDate = @LastStatusDate,
                PaidFees = @PaidFees,
                CreatedByUserID = @CreatedByUserID
            WHERE ApplicationID = @ApplicationID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        public static bool DeleteApplication(int ApplicationID)
        {
            int rowsAffected = 0;
            string query = "DELETE FROM Applications WHERE ApplicationID = @ApplicationID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static bool ChangeStatus(int ApplicationID, byte NewStatus, DateTime LastStatusDate)
        {
            int rowsAffected = 0;
            string query = @"
            UPDATE Applications
            SET ApplicationStatus = @NewStatus,
                LastStatusDate = @LastStatusDate
            WHERE ApplicationID = @ApplicationID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@NewStatus", NewStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);

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
