using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollManagement2
{
    public enum Gender { Select, Male, Female }
    public enum workLocation
    {
        Select, Chennai, Kisumu, California
    }
    public class Employee
    {
        private static int s_employeeId = 1000;

        public string EmployeeId { get; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public workLocation WorkLocation { get; set; }
        public string TeamName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int NumberOfWorkingDays { get; set; }
        public int NumberOfLeaveTaken { get; set; }
        public Gender Gender { get; set; }

        public Employee(string employeeName, string role, workLocation workLocation, string teamName, DateTime dateOfJoining, int numberOfWorkingDays, int numberOfLeaveTaken, Gender gender)
        {
            s_employeeId++;
            EmployeeId = "SF" + s_employeeId;

            EmployeeName = employeeName;
            Role = role;
            WorkLocation = workLocation;
            TeamName = teamName;
            DateOfJoining = dateOfJoining;
            NumberOfWorkingDays = numberOfWorkingDays;
            NumberOfLeaveTaken = numberOfLeaveTaken;
            Gender = gender;
        }

        public double CalculateSalary(double daySalary)
        {
            double salary = 30 * daySalary;
            double hra = salary * 0.8;
            double da = salary * 0.2;
            double grossSalary = (salary + hra + da) * 12;
            double tax = grossSalary * 0.05;
            double inHandSalary = grossSalary - tax;
            return inHandSalary/12;
        }

        public void EmployeeDetails()
        {
            Console.WriteLine($"Employee ID: {EmployeeId}");
            Console.WriteLine($"Employee Name: {EmployeeName}");
            Console.WriteLine($"Role: {Role}");
            Console.WriteLine($"Team Name: {TeamName}");
            Console.WriteLine($"Date Of Joining: {DateOfJoining}");
            Console.WriteLine($"Number of Working Days in Month: {NumberOfWorkingDays}");
            Console.WriteLine($"Number of Leave Taken: {NumberOfLeaveTaken}");
            Console.WriteLine($"Gender: {Gender}");
        }
    }
}