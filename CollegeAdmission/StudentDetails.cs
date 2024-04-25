using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    /// <summary>
    /// 
    /// DataType Gender used to select a instance of <see cref="StudentDetails" /> Gender Information
    /// 
    /// </summary>
    public enum Gender { Select, Male, Female, Transgender }
    /// <summary>
    /// 
    /// This class contains details of Student
    /// Refer documentation on <see href="www.syncfusion.com"/> 
    /// </summary>
    public class StudentDetails
    {
        //Field
        /// <summary>
        /// Static field s_studentId used to autoincrement StudentID of the instance of <see cref="StudentDetails"/>
        /// </summary>
        private static int s_studentId = 3000;


        //Auto Property
        /// <summary>
        /// StudentID Property used to hold a Students's ID of the instance of <see cref="StudentDetails"/>
        /// </summary>
        public string StudentId { get; }
        /// <summary>
        /// StudentName Property used to hold a Students's Name of the instance of <see cref="StudentDetails"/>
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// FatherName Property used to hold a Students's Father Name of the instance of <see cref="StudentDetails"/>
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// DateOfBirth Property used to hold a Students's Date Of Birth of the instance of <see cref="StudentDetails"/>
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Gender Property used to hold a Students's Gender of the instance of <see cref="StudentDetails"/>
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Gender Property used to hold a Students's Physics marks of the instance of <see cref="StudentDetails"/>
        /// </summary>
        /// <value>provide a integer value between 0 to 100</value>
        public int Physics { get; set; }
        /// <summary>
        /// Chemistry Property used to hold a Students's Chemistry marks of the instance of <see cref="StudentDetails"/>
        /// </summary>
        /// <value>provide a integer value between 0 to 100</value>
        public int Chemistry { get; set; }
        /// <summary>
        /// Maths Property used to hold a Students's Maths marks of the instance of <see cref="StudentDetails"/>
        /// </summary>
        /// <value>provide a integer value between 0 to 100</value>
        public int Maths { get; set; }

        /// <summary>
        /// Constructor StudentDetails used to initialize default values to its properties
        /// </summary>
        public StudentDetails()
        {
            StudentName = "Enter your Full Name";
            FatherName = "Enter your Father Name";
            Gender = Gender.Select;
        }

        /// <summary>
        /// Constructor StudentDetails used to initialize parameterized values to its properties
        /// </summary>
        /// <param name="studentName">studentName parameter used to assign value to its associated property</param>
        /// <param name="fatherName">fatherName parameter used to assign value to its associated property</param>
        /// <param name="dateOfBirth">dateOfBirth parameter used to assign value to its associated property</param>
        /// <param name="gender">gender parameter used to assign value to its associated property</param>
        /// <param name="physics">physics parameter used to assign value to its associated property</param>
        /// <param name="chemistry">chemistry parameter used to assign value to its associated property</param>
        /// <param name="maths">maths parameter used to assign value to its associated property</param>
        public StudentDetails(string studentName, string fatherName, DateTime dateOfBirth, Gender gender, int physics, int chemistry, int maths)
        {
            //Auto-incrementation id
            s_studentId++;
            StudentId = "SF" + s_studentId;

            StudentName = studentName;
            FatherName = fatherName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }


        //Methods
        /// <summary>
        /// Method CheckEligibility used to check eligibilty of instance of <see cref="StudentDetails"/> based on cutoff
        /// </summary>
        /// <returns>Return true if eligibile, else false.</returns>
        public bool CheckEligibility()
        {
            double avg = (Physics + Chemistry + Maths) / 3;
            if (avg >= 75.0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method ShowDetail used to display details of instance of <see cref="StudentDetails"/>
        /// </summary>
        public void ShowDetails()
        {
            Console.WriteLine($"Student ID: {StudentId}");
            Console.WriteLine($"Student Name: {StudentName}");
            Console.WriteLine($"Date of birth : {DateOfBirth:dd/MM/yyyy}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Physics Marks: {Physics}");
            Console.WriteLine($"Chemistry Marks: {Chemistry}");
            Console.WriteLine($"Maths Marks: {Maths}");
            Console.WriteLine($"Eligibilty: {CheckEligibility()}");

        }
    }
}