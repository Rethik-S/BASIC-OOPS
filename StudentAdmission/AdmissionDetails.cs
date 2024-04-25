using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    //enum
    public enum AdmissionStatus { select, Admitted, Cancelled }

    public class AdmissionDetails
    {
        /*
            a.	AdmissionID – (Auto Increment ID - AID1001)
            b.	StudentID
            c.	DepartmentID
            d.	AdmissionDate
            e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)
        */

        //field
        private static int s_admissionID = 1000;

        //Auto properties
        public string AdmissionID { get; }//read only property
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus { get; set; }

        //Contructors
        public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus admissionStatus)
        {
            //Auto-incrementation id
            s_admissionID++;
            AdmissionID = "AID" + s_admissionID;

            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }
    }
}