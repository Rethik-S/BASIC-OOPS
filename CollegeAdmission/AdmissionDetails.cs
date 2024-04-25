using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum AdmissionStatus { select, Admitted, Cancelled }
    /// <summary>
    /// 
    /// This class contains details of Admission
    /// 
    /// </summary>
    public class AdmissionDetails
    {
        //field
        /// <summary>
        /// Static field s_admissionId used to autoincrement admission Id of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        private static int s_admissionId = 1000;

        // Auto property
        /// <summary>
        /// AdmissionId Property used to hold a Admission's Id of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        public string AdmissionId { get; }
        /// <summary>
        /// StudentId Property used to hold a Student's Id of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        public string StudentId { get; set; }
        /// <summary>
        ///DepartmentID Property used to hold a Department's Id of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        ///AdmissionDate Property used to hold a Admission Date of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        public DateTime AdmissionDate { get; set; }
        /// <summary>
        ///AdmissionStatus Property used to hold a Admission Status of the instance of <see cref="AdmissionDetails"/>
        /// </summary>
        public AdmissionStatus AdmissionStatus { get; set; }

        /// <summary>
        /// Constructor AdmissionDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="studentId">studentId parameter used to assign value to its associated property</param>
        /// <param name="departmentId">departmentId parameter used to assign value to its associated property</param>
        /// <param name="admissionDate">admissionDate parameter used to assign value to its associated property</param>
        /// <param name="admissionStatus">admissionStatus parameter used to assign value to its associated property</param>
        public AdmissionDetails(string studentId, string departmentId, DateTime admissionDate, AdmissionStatus admissionStatus)
        {
            //Auto-incrementation id
            s_admissionId++;
            AdmissionId = "AID" + s_admissionId;

            StudentId = studentId;
            DepartmentId = departmentId;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }
    }
}