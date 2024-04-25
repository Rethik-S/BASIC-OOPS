using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //enum
    public enum Gender { Select, Male, Female, Transgender }
    public class StudentDetails
    {
        /*
            a.	StudentID – (AutoGeneration ID – SF3000)
            b.	StudentName
            c.	FatherName
            d.	DOB
            e.	Gender – Enum (Male, Female, Transgender)
            f.	Physics
            g.	Chemistry
            h.	Maths
        */

        //field
        private static int s_studentID = 3000;

        //Auto property
        public string StudentID { get; }//read only property
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int PhysicsMark { get; set; }
        public int ChemistryMark { get; set; }
        public int MathsMark { get; set; }


        //constructor
        public StudentDetails()
        {
            StudentName = "Enter your Full Name";
            FatherName = "Enter your Father Name";
            Gender = Gender.Select;
        }


        public StudentDetails(string studentName, string fatherName, DateTime dateOfBirth, Gender gender, int physicsMark, int chemistryMark, int mathsMark)
        {
            //Auto incrementation
            s_studentID++;
            StudentID = "SF" + s_studentID;

            StudentName = studentName;
            FatherName = fatherName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhysicsMark = physicsMark;
            ChemistryMark = chemistryMark;
            MathsMark = mathsMark;
        }

        //Methods
        private double Average()
        {
            return (PhysicsMark + ChemistryMark + MathsMark) / 3;
        }

        public bool CheckEligibility(double cutOff)
        {
            if (Average() >= cutOff)
            {
                return true;
            }

            return false;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Student ID: {StudentID}");
            Console.WriteLine($"Student Name: {StudentName}");
            Console.WriteLine($"Date of birth : {DateOfBirth:dd/MM/yyyy}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Physics Marks: {PhysicsMark}");
            Console.WriteLine($"Chemistry Marks: {ChemistryMark}");
            Console.WriteLine($"Maths Marks: {MathsMark}");
            Console.WriteLine($"Eligibilty: {CheckEligibility(75.0)}"); 
        }
    }
}