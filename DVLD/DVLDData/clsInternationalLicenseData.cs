using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsInternationalLicenseData
    {
        public static int AddNew(int applicationID, int driverID, int issuedUsingLocalLicenseID,
    DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            int newID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            INSERT INTO InternationalLicenses
            (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
            VALUES (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
            SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                    cmd.Parameters.AddWithValue("@DriverID", driverID);
                    cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
                    cmd.Parameters.AddWithValue("@IssueDate", issueDate);
                    cmd.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null) newID = Convert.ToInt32(result);
                }
            }

            return newID;
        }

        public static bool ActiveLicenseExists(int driverID)
        {
            bool exists = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 1 
            FROM InternationalLicenses
            WHERE DriverID = @DriverID 
              AND IsActive = 1 
              AND ExpirationDate > GETDATE()";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DriverID", driverID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    exists = reader.HasRows;
                }
            }

            return exists;
        }

        public static DataTable GetInternationalLicensesByDriverID(int driverID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 
                InternationalLicenseID AS [Int.LicenseID], 
                ApplicationID, 
                IssuedUsingLocalLicenseID AS [L.LicenseID], 
                IssueDate, 
                ExpirationDate, 
                IsActive
            FROM InternationalLicenses
            WHERE DriverID = @DriverID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DriverID", driverID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public static DataRow GetLicenseDetails(int IntLicenseID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                SELECT P.FirstName + ' ' + P.SecondName + ' ' + P.LastName AS [Name],  IL.InternationalLicenseID as IntLicenseID, IL.ApplicationID, IL.IssuedUsingLocalLicenseID as LicenseID, CASE IL.IsActive 
                WHEN 1 THEN 'Yes' ELSE 'No' 
                END AS IsActive, P.NationalNo, P.DateOfBirth, P.Gendor, 
                Drivers.DriverID, IL.IssueDate, IL.ExpirationDate, P.ImagePath
                FROM   InternationalLicenses IL INNER JOIN
                Drivers ON IL.DriverID = Drivers.DriverID INNER JOIN
                People P ON Drivers.PersonID = P.PersonID
                Where IL.InternationalLicenseID = @LicenseID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LicenseID", IntLicenseID);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }


        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();
            string query = "SELECT InternationalLicenseID as IntLicenseID, ApplicationID,DriverID, IssuedUsingLocalLicenseID as LocalLicenseID, IssueDate, ExpirationDate, IsActive FROM   InternationalLicenses";

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
            catch (Exception ex)
            {
                clsLogger.LogError(ex);
            }

            return dt;
        }
    }
}
