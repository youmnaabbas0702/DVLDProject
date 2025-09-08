using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsLicenseData
    {
        public static bool Find(int licenseID, ref int applicationID, ref int driverID, ref int licenseClass,
                        ref DateTime issueDate, ref DateTime expirationDate, ref string notes,
                        ref decimal paidFees, ref bool isActive, ref byte issueReason, ref int createdByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            applicationID = (int)reader["ApplicationID"];
                            driverID = (int)reader["DriverID"];
                            licenseClass = (int)reader["LicenseClass"];
                            issueDate = (DateTime)reader["IssueDate"];
                            expirationDate = (DateTime)reader["ExpirationDate"];
                            notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : "";
                            paidFees = Convert.ToDecimal(reader["PaidFees"]);
                            isActive = (bool)reader["IsActive"];
                            issueReason = Convert.ToByte(reader["IssueReason"]);
                            createdByUserID = (int)reader["CreatedByUserID"];
                        }
                    }
                }
            }
            return isFound;
        }

        public static int AddNewLicense(int applicationID, int driverID, int licenseClass,
            DateTime issueDate, DateTime expirationDate, string notes, decimal paidFees,
            bool isActive, byte issueReason, int createdByUserID)
        {
            int newLicenseID = -1;

            string query = @"
            INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes,
                                  PaidFees, IsActive, IssueReason, CreatedByUserID)
            VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes,
                    @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ApplicationID", applicationID);
                command.Parameters.AddWithValue("@DriverID", driverID);
                command.Parameters.AddWithValue("@LicenseClass", licenseClass);
                command.Parameters.AddWithValue("@IssueDate", issueDate);
                command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                command.Parameters.AddWithValue("@Notes", (object)notes ?? DBNull.Value);
                command.Parameters.AddWithValue("@PaidFees", paidFees);
                command.Parameters.AddWithValue("@IsActive", isActive);
                command.Parameters.AddWithValue("@IssueReason", issueReason);
                command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        newLicenseID = insertedID;
                    }
                }
                catch
                {
                    newLicenseID = -1;
                }
            }

            return newLicenseID;
        }

        public static bool DeactivateLicense(int licenseID)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Licenses
                         SET IsActive = 0
                         WHERE LicenseID = @LicenseID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", licenseID);
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected > 0;
        }

        public static bool ActivateLicense(int licenseID)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Licenses
                         SET IsActive = 1
                         WHERE LicenseID = @LicenseID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", licenseID);
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected > 0;
        }

        public static int GetLicenseIDByLocalAppID(int localAppID)
        {
            int licenseID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT Licenses.LicenseID
            FROM Applications 
            INNER JOIN Licenses ON Applications.ApplicationID = Licenses.ApplicationID
            INNER JOIN LocalDrivingLicenseApplications 
                ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
            WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalAppID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LocalAppID", localAppID);

                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    licenseID = Convert.ToInt32(result);
            }

            return licenseID;
        }

        public static DataTable GetLicensesByPersonID(int personID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName,
                   Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive
            FROM Applications
            INNER JOIN Licenses ON Applications.ApplicationID = Licenses.ApplicationID
            INNER JOIN LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
            WHERE ApplicantPersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        public static int GetActiveLicenseID(int driverID)
        {
            int licenseID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT LicenseID
            FROM Licenses
            WHERE DriverID = @DriverID AND IsActive = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DriverID", driverID);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        licenseID = Convert.ToInt32(result);
                }
            }

            return licenseID;
        }

    }

}
