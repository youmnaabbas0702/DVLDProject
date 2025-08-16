using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsLocalLicenseApplicationData
    {
        public static bool GetLocalLicenseApplicationInfoByID(
            int localDrivingLicenseApplicationID,
            ref int applicationID,
            ref int licenseClassID)
        {
            bool isFound = false;
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", localDrivingLicenseApplicationID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        applicationID = (int)reader["ApplicationID"];
                        licenseClassID = (int)reader["LicenseClassID"];
                        isFound = true;
                    }
                }
            }
            catch
            {
                return false;
            }

            return isFound;
        }

        public static int AddNewLocalLicenseApplication(int applicationID, int licenseClassID)
        {
            int newID = -1;
            string query = @"
            INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
            VALUES (@ApplicationID, @LicenseClassID);
            SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                        newID = id;
                }
            }
            catch
            {
                return -1;
            }

            return newID;
        }

        public static bool UpdateLocalLicenseApplication(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
        {
            int rowsAffected = 0;
            string query = @"
            UPDATE LocalDrivingLicenseApplications
            SET ApplicationID = @ApplicationID,
                LicenseClassID = @LicenseClassID
            WHERE LocalDrivingLicenseApplicationID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    command.Parameters.AddWithValue("@ID", localDrivingLicenseApplicationID);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteLocalLicenseApplication(int localDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;
            string query = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @ID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", localDrivingLicenseApplicationID);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM vwLocalLicenseApplicationsSummary";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }

            return dt;
        }

        public static int GetActiveApplicationID(int personID, int classID)
        {
            int applicationID = -1;

            string query = @"
        SELECT LA.ApplicationID
        FROM   Applications A 
               INNER JOIN LocalDrivingLicenseApplications LA 
               ON A.ApplicationID = LA.ApplicationID
        WHERE ApplicantPersonID = @PersonID 
              AND LicenseClassID = @ClassID 
              AND A.ApplicationStatus != 2
        GROUP BY LA.ApplicationID, LicenseClassID, ApplicantPersonID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@ClassID", classID);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int appID))
                    {
                        applicationID = appID;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return applicationID;
        }

    }

}
