using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDData
{
    public class clsTestData
    {
        public static int AddNewTest(int testAppointmentID, bool testResult,
            string notes, int createdByUserID)
        {
            int testID = -1;

            string query = @"
            INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
            VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
            SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", testResult);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    if (!string.IsNullOrEmpty(notes))
                        command.Parameters.AddWithValue("@Notes", notes);
                    else
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int newID))
                    {
                        testID = newID;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogError(ex);

                return -1;
            }

            return testID;
        }
    }

}
