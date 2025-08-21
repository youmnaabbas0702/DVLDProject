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

        public static DataRow GetLicenseDetailsByApplicationID(int applicationID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 
                LC.ClassName, 
                P.FirstName + ' ' + P.SecondName + ' ' + P.LastName AS [Name], 
                L.LicenseID, 
                CASE L.IsActive 
                    WHEN 1 THEN 'Yes' ELSE 'No' 
                END AS IsActive,
                CASE 
                    WHEN EXISTS (
                        SELECT 1 
                        FROM DetainedLicenses DL
                        WHERE DL.LicenseID = L.LicenseID AND DL.IsReleased = 0
                    ) THEN 'Yes'
                    ELSE 'No'
                END AS IsDetained,
                P.NationalNo, 
                P.DateOfBirth, 
                P.Gendor, 
                D.DriverID, 
                L.IssueDate, 
                L.ExpirationDate, 
                CASE L.IssueReason
                    WHEN 1 THEN 'First time'
                    WHEN 2 THEN 'Renewal'
                    WHEN 3 THEN 'Replacement'
                    ELSE 'Unknown'
                END AS IssueReason,
                L.Notes,
                P.ImagePath
            FROM Licenses L
            INNER JOIN Drivers D ON L.DriverID = D.DriverID
            INNER JOIN People P ON D.PersonID = P.PersonID
            INNER JOIN LicenseClasses LC ON L.LicenseClass = LC.LicenseClassID
            WHERE L.ApplicationID = @ApplicationID;";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
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

    }

}
