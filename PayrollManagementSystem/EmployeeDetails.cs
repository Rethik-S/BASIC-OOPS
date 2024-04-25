using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollManagementSystem
{
    public enum Gender { Select, Male, Female, Transgender }
    public enum Branch
    {
        Select, Eymard, Karuna, Madhura
    }
    public enum Team
    {
        Select, Network, Hardware, Developer, Facility
    }
    public class EmployeeDetails
    {
        //field
        private static int s_employeeId = 3000;

        //auto property
        public string EmployeeId { get; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public long MobileNumber { get; set; }
        public Gender Gender { get; set; }
        public Branch Branch { get; set; }
        public Team Team { get; set; }

        //constructor
        public EmployeeDetails(string fullName, DateTime dateOfBirth, long mobileNumber, Gender gender, Branch branch, Team team)
        {
            s_employeeId++;
            EmployeeId = "SF" + s_employeeId;

            FullName = fullName;
            DOB = dateOfBirth;
            MobileNumber = mobileNumber;
            Gender = gender;
            Branch = branch;
            Team = team;
        }
        
        //Methods
        public double CalculateSalary(double daySalary, int days)
        {
            DateTime today = DateTime.Now;
            int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
            double salary = daysInMonth * daySalary;
            double hra = salary * 0.8;
            double da = salary * 0.2;
            double grossSalary = (salary + hra + da) * 12;
            double tax = grossSalary * 0.05;
            double inHandSalary = grossSalary - tax;
            double salaryPerMonth = inHandSalary / 12;
            double salaryPerDay = salaryPerMonth / daysInMonth;
            return salaryPerDay * days;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {EmployeeId}");
            Console.WriteLine($"Employee Name: {FullName}");
            Console.WriteLine($"Date Of Birth: {DOB:dd/MM/yyyy}");
            Console.WriteLine($"Mobile Number: {MobileNumber}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Branch: {Branch}");
            Console.WriteLine($"Team: {Team}");
        }


    }
}