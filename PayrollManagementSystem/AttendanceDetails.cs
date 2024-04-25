using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagementSystem
{
    public class AttendanceDetails
    {
        //field
        private static int s_attendanceId = 1000;

        //auto property
        public string AttendanceId { get; }
        public string EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public int HoursWorked { get; set; }
        
        //Constructor
        public AttendanceDetails(string employeeId, DateTime date, DateTime checkInTime, DateTime checkOutTime, int hoursWorked)
        {
            s_attendanceId++;
            AttendanceId = "AID" + s_attendanceId;

            EmployeeId = employeeId;
            Date = date;
            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
            HoursWorked = hoursWorked;
        }


    }
}