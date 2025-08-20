using DVLDData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusiness
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew, Update }

        public int TestAppointmentID { get; private set; }
        public int TestTypeID { get; set; }
        public int LDLAppID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        public enMode Mode { get; private set; }

        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LDLAppID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;

            Mode = enMode.AddNew;
        }

        private clsTestAppointment(int testAppointmentID, int testTypeID, int localAppID, DateTime appointmentDate, decimal paidFees, int createdByUserID, bool isLocked)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LDLAppID = localAppID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;

            Mode = enMode.Update;
        }

        public static clsTestAppointment Find(int appointmentID)
        {
            int testTypeID = -1, localAppID = -1, createdByUserID = -1;
            DateTime appointmentDate = DateTime.Now;
            decimal paidFees = 0;
            bool isLocked = false;

            bool isFound = clsTestAppointmentData.GetTestAppointmentInfoByID(
                appointmentID, ref testTypeID, ref localAppID,
                ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked);

            if (isFound)
            {
                return new clsTestAppointment(appointmentID, testTypeID, localAppID,
                    appointmentDate, paidFees, createdByUserID, isLocked);
            }

            return null;
        }

        private bool _AddNew()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewAppointment(
                this.TestTypeID, this.LDLAppID, this.AppointmentDate,
                this.PaidFees, this.CreatedByUserID, this.IsLocked);

            return this.TestAppointmentID != -1;
        }

        private bool _Update()
        {
            return clsTestAppointmentData.UpdateAppointment(
                this.TestAppointmentID, this.AppointmentDate, this.PaidFees, this.IsLocked);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _Update();
                default:
                    return false;
            }
        }

        public static bool HasPassed(int localAppID, int testTypeID)
        {
            return clsTestAppointmentData.HasPassed(localAppID, testTypeID);
        }

        public static bool HasFailed(int localAppID, int testTypeID)
        {
            return clsTestAppointmentData.HasFailed(localAppID, testTypeID);
        }

        public static DataTable GetAppointments(int localAppID, int testTypeID)
        {
            return clsTestAppointmentData.GetAppointmentsByTypeAndApplication(localAppID, testTypeID);
        }

        public static int GetAppointmentsCount(int localAppID, int testTypeID)
        {
            return clsTestAppointmentData.GetAppointmentsCount(localAppID, testTypeID);
        }

    }
}
