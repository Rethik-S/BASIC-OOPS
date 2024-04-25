using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class DepartmentDetails
    {

        /*
            a.	DepartmentID – (AutoIncrement - DID101)
            b.	DepartmentName
            c.	NumberOfSeats
        */

        //field
        private static int s_departmentID = 100;


        //Auto properties
        public string DepartmentID { get; }//read only property
        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }


        //Contructors
        public DepartmentDetails(string departmentName, int numberOfSeats)
        {
            //Auto-incrementation id
            s_departmentID++;
            DepartmentID = "DID" + s_departmentID;

            DepartmentName = departmentName;
            NumberOfSeats = numberOfSeats;
        }
    }
}