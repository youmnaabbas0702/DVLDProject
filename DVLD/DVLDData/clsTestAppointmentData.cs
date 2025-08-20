using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsTestAppointmentData
    {
        public static bool GetTestAppointmentInfoByID(int appointmentID,
    ref int testTypeID, ref int localAppID, ref DateTime appointmentDate,
    ref decimal paidFees, ref int createdByUserID, ref bool isLocked)
        {
            bool isFound = false;
            string query = @"SELECT * FROM TestAppointments WHERE TestAppointmentID = @AppointmentID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentID", appointmentID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        testTypeID = (int)reader["TestTypeID"];
                        localAppID = (int)reader["LocalDrivingLicenseApplicationID"];
                        appointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                        paidFees = Convert.ToDecimal(reader["PaidFees"]);
                        createdByUserID = (int)reader["CreatedByUserID"];
                        isLocked = (bool)reader["IsLocked"];

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

        public static DataTable GetAppointmentsByTypeAndApplication(int localAppID, int testTypeID)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT TestAppointmentID, AppointmentDate, PaidFees, IsLocked
                         FROM TestAppointments
                         WHERE LocalDrivingLicenseApplicationID = @AppID 
                           AND TestTypeID = @TestTypeID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppID", localAppID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
            }
            catch (Exception)
            {
                return dt;
            }

            return dt;
        }

        public static int AddNewAppointment(int testTypeID, int localAppID, DateTime appointmentDate, decimal paidFees, int createdByUserID, bool isLocked)
        {
            int newID = -1;
            string query = @"INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked)
                         VALUES (@TestTypeID, @AppID, @Date, @Fees, @UserID, @IsLocked);
                         SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    command.Parameters.AddWithValue("@AppID", localAppID);
                    command.Parameters.AddWithValue("@Date", appointmentDate);
                    command.Parameters.AddWithValue("@Fees", paidFees);
                    command.Parameters.AddWithValue("@UserID", createdByUserID);
                    command.Parameters.AddWithValue("@IsLocked", isLocked);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                        newID = id;
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return newID;
        }

        public static bool UpdateAppointment(int testAppointmentID, DateTime appointmentDate, decimal paidFees, bool isLocked)
        {
            int rowsAffected = 0;
            string query = @"UPDATE TestAppointments 
                         SET AppointmentDate = @Date,
                             PaidFees = @Fees,
                             IsLocked = @IsLocked
                         WHERE TestAppointmentID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", appointmentDate);
                    command.Parameters.AddWithValue("@Fees", paidFees);
                    command.Parameters.AddWithValue("@IsLocked", isLocked);
                    command.Parameters.AddWithValue("@ID", testAppointmentID);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return rowsAffected > 0;
        }

        public static bool HasPassed(int localAppID, int testTypeID)
        {
            string query = @"SELECT Passed = 1
                         FROM Tests 
                         JOIN TestAppointments 
                         ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                         WHERE LocalDrivingLicenseApplicationID = @AppID 
                           AND TestTypeID = @TestTypeID 
                           AND TestResult = 1";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppID", localAppID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows; // true if any record exists
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool HasFailed(int localAppID, int testTypeID)
        {
            string query = @"SELECT Failed = 1
                         FROM Tests 
                         JOIN TestAppointments 
                         ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                         WHERE LocalDrivingLicenseApplicationID = @AppID 
                           AND TestTypeID = @TestTypeID 
                           AND TestResult = 0";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppID", localAppID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int GetAppointmentsCount(int localAppID, int testTypeID)
        {
            int count = 0;
            string query = @"SELECT COUNT(*)
                     FROM TestAppointments
                     WHERE LocalDrivingLicenseApplicationID = @AppID
                       AND TestTypeID = @TestTypeID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppID", localAppID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                        count = Convert.ToInt32(result);
                }
            }
            catch (Exception)
            {
                return 0;
            }

            return count;
        }

    }

}
