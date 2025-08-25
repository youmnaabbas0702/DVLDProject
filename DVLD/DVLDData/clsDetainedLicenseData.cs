using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsDetainedLicenseData
    {
        public static int DetainLicense(int licenseID, DateTime detainDate, decimal fineFees, int createdByUserID)
        {
            int detainID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0);
                SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LicenseID", licenseID);
                cmd.Parameters.AddWithValue("@DetainDate", detainDate);
                cmd.Parameters.AddWithValue("@FineFees", fineFees);
                cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    detainID = Convert.ToInt32(result);
            }
            return detainID;
        }

        public static bool IsLicenseDetained(int licenseID)
        {
            bool found = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 1 
                             FROM DetainedLicenses 
                             WHERE LicenseID = @LicenseID AND IsReleased = 0";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LicenseID", licenseID);

                conn.Open();
                object result = cmd.ExecuteScalar();
                found = (result != null);
            }

            return found;
        }

        public static bool ReleaseLicense(int licenseID, DateTime releaseDate, int releasedByUserID, int releaseAppID)
        {
            int rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            UPDATE DetainedLicenses
            SET IsReleased = 1,
                ReleaseDate = @ReleaseDate,
                ReleasedByUserID = @ReleasedByUserID,
                ReleaseApplicationID = @ReleaseAppID
            WHERE LicenseID = @LicenseID AND IsReleased = 0";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate);
                cmd.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserID);
                cmd.Parameters.AddWithValue("@ReleaseAppID", releaseAppID);
                cmd.Parameters.AddWithValue("@LicenseID", licenseID);

                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }

            return rowsAffected > 0;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                SELECT 
                    DL.DetainID,
                    DL.LicenseID,
                    DL.DetainDate,
                    DL.FineFees,
                    DL.IsReleased,
                    DL.ReleaseDate,
                    DL.ReleaseApplicationID as ReleaseAppID,
                    P.NationalNo,
                    P.FirstName + ' ' + P.SecondName + ' ' + P.LastName AS FullName
                FROM DetainedLicenses DL
                INNER JOIN Licenses L ON DL.LicenseID = L.LicenseID
                INNER JOIN Drivers D ON L.DriverID = D.DriverID
                INNER JOIN People P ON D.PersonID = P.PersonID;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            return dt;
        }
    }
}
