using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class DepartmentDetails
    {
        /// <summary>
        /// Static field s_departmentId used to autoincrement department Id of the instance of <see cref="DepartmentDetails"/>
        /// </summary>
        private static int s_departmentId = 100;


        // Auto property
        /// <summary>
        /// DepartmentID Property used to hold a Department's Id of the instance of <see cref="DepartmentDetails"/>
        /// </summary>
        public string DepartmentId { get; }
        /// <summary>
        /// DepartmentName Property used to hold a Department Name of the instance of <see cref="DepartmentDetails"/>
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// NumberOfSeats Property used to hold a Number Of Seats of the instance of <see cref="DepartmentDetails"/>
        /// </summary>
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// Constructor DepartmentDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="departmentName">departmentName parameter used to assign value to its associated property</param>
        /// <param name="numberOfSeats">numberOfSeats parameter used to assign value to its associated property</param>
        public DepartmentDetails(string departmentName, int numberOfSeats)
        {
            //Auto-incrementation id
            s_departmentId++;
            DepartmentId = "DID" + s_departmentId;

            DepartmentName = departmentName;
            NumberOfSeats = numberOfSeats;
        }
    }
}