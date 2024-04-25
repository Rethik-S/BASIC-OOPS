using System;
using System.Collections.Generic;
namespace PayrollManagementSystem;
class Program
{
    public static void Main(string[] args)
    {
        List<EmployeeDetails> employeeDetailsList = new List<EmployeeDetails>();
        List<AttendanceDetails> attendanceDetailsList = new List<AttendanceDetails>();

        //Default values
        EmployeeDetails employee1 = new EmployeeDetails("Ravi", new DateTime(1999, 11, 11), 9958858888, Gender.Male, Branch.Eymard, Team.Developer);

        employeeDetailsList.Add(employee1);

        AttendanceDetails attendanceDetails1 = new AttendanceDetails("SF3001", new DateTime(2022, 05, 15), new DateTime(2022, 05, 15, 9, 0, 0), new DateTime(2022, 05, 15, 18, 10, 0), 8);
        AttendanceDetails attendanceDetails2 = new AttendanceDetails("SF3002", new DateTime(2022, 05, 16), new DateTime(2022, 05, 15, 9, 10, 0), new DateTime(2022, 05, 15, 18, 50, 0), 8);

        attendanceDetailsList.Add(attendanceDetails1);
        attendanceDetailsList.Add(attendanceDetails2);
        //end of Default values

        DateTime today = DateTime.Now;

        Console.WriteLine("Welcome");
        int option;
        do
        {
            Console.WriteLine("1.Employee Registration\n2.Employee Login\n3.Exit");
            Console.Write("select any option :");
            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        //Employee Registration

                        Console.Write("Enter name: ");
                        string fullName = Console.ReadLine();

                        Console.Write("Enter date of birth (dd/mm/yyyy): ");
                        DateTime dob;
                        bool isDobValid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
                        while (!isDobValid)
                        {
                            Console.WriteLine("Provide valid Date of birth");
                            Console.Write("Enter date of birth (dd/mm/yyyy): ");
                            isDobValid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
                        }

                        long phoneNumber;
                        Console.Write("Enter Phone Number: ");
                        bool isphoneNumberValid = long.TryParse(Console.ReadLine(), null, out phoneNumber);
                        while (!isphoneNumberValid || !(phoneNumber > 0))
                        {
                            Console.WriteLine("Enter valid Number");
                            Console.Write("Enter Phone Number: ");
                            isphoneNumberValid = long.TryParse(Console.ReadLine(), null, out phoneNumber);

                        }
                        Console.Write("Enter gender (Male or Female or Transgender): ");
                        Gender gender;
                        bool isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
                        while (!isGen)
                        {
                            Console.WriteLine("Provide valid gender");
                            Console.Write("Enter gender (Male or Female or Transgender): ");
                            isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
                        }

                        Console.Write("Enter branch (Eymard / Karuna /Madhura): ");
                        Branch branch;
                        bool isbranch = Enum.TryParse(Console.ReadLine(), true, out branch);
                        while (!isbranch)
                        {
                            Console.WriteLine("Provide valid branch");
                            Console.Write("Enter branch (Eymard / Karuna /Madhura): ");
                            isbranch = Enum.TryParse(Console.ReadLine(), true, out branch);
                        }

                        Console.Write("Enter Team (Network, Hardware, Developer, Facility): ");
                        Team team;
                        bool isteam = Enum.TryParse(Console.ReadLine(), true, out team);
                        while (!isteam)
                        {
                            Console.WriteLine("Provide valid branch");
                            Console.Write("Enter branch (Eymard / Karuna /Madhura): ");
                            isteam = Enum.TryParse(Console.ReadLine(), true, out team);
                        }

                        //new employee
                        EmployeeDetails employee = new EmployeeDetails(fullName, dob, phoneNumber, gender, branch, team);

                        //adding to list
                        employeeDetailsList.Add(employee);

                        Console.WriteLine($"Employee added successfully your id is: {employee.EmployeeId}");
                        break;

                    }
                case 2:
                    {
                        //Employee Login

                        Console.Write("Enter the employee id: ");
                        string id = Console.ReadLine();
                        bool flag = true;
                        foreach (EmployeeDetails employee in employeeDetailsList)
                        {
                            if (employee.EmployeeId == id)
                            {
                                flag = false;
                                int choice = 0;
                                do
                                {
                                    Console.WriteLine("1. Add Attendance\n2. Display details\n3. Calculate Salary\n4. exit");
                                    int option1;
                                    Console.Write("select any option :");
                                    bool isopt1Valid = int.TryParse(Console.ReadLine(), out option1);
                                    while (!isopt1Valid)
                                    {
                                        Console.WriteLine("Enter valid number as input");
                                        Console.Write("select any option :");
                                        isopt1Valid = int.TryParse(Console.ReadLine(), out option1);
                                    }
                                    switch (option1)
                                    {

                                        case 1:
                                            {
                                                //Add Attendance
                                                System.Console.Write("Do you want to check-in (yes or no) : ");
                                                if (Console.ReadLine().ToLower().Trim() == "yes")
                                                {
                                                    Console.Write("Enter check-in (dd/mm/yyyy hh:mm tt): ");
                                                    DateTime checkIn;
                                                    bool ischeckInValid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null, System.Globalization.DateTimeStyles.None, out checkIn);
                                                    while (!ischeckInValid)
                                                    {
                                                        Console.WriteLine("Provide valid Date of birth");
                                                        Console.Write("Enter date of birth (dd/mm/yyyy): ");
                                                        ischeckInValid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null, System.Globalization.DateTimeStyles.None, out checkIn);
                                                    }

                                                    Console.Write("Do you want to check-out (yes or no) : ");
                                                    if (Console.ReadLine().ToLower().Trim() == "yes")
                                                    {
                                                        Console.Write("Enter check-out (dd/mm/yyyy hh:mm tt): ");
                                                        DateTime checkOut;
                                                        bool ischeckOutValid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null, System.Globalization.DateTimeStyles.None, out checkOut);
                                                        while (!ischeckOutValid)
                                                        {
                                                            Console.WriteLine("Provide valid Date of birth");
                                                            Console.Write("Enter date of birth (dd/mm/yyyy): ");
                                                            ischeckOutValid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null, System.Globalization.DateTimeStyles.None, out checkOut);
                                                        }

                                                        TimeSpan timeSpan = checkOut - checkIn;
                                                        int hoursWorked = timeSpan.Hours;
                                                        if (timeSpan.Hours < 8)
                                                        {
                                                            System.Console.WriteLine("provide valid check-in and check-out should work for 8 hours");
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            if (hoursWorked > 8)
                                                            {
                                                                hoursWorked = 8;
                                                            }
                                                            AttendanceDetails attendanceDetails = new AttendanceDetails(employee.EmployeeId, checkIn, checkIn, checkOut, hoursWorked);
                                                            attendanceDetailsList.Add(attendanceDetails);
                                                            System.Console.WriteLine("Check-in and Checkout Successful and today you have worked 8 Hours");
                                                        }
                                                    }

                                                    else
                                                    {
                                                        System.Console.WriteLine("Provide both for attendance");
                                                    }
                                                }
                                                else
                                                {
                                                    System.Console.WriteLine("Provide both for attendance");
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                //Display details
                                                Console.WriteLine("=================================");
                                                employee.DisplayDetails();
                                                Console.WriteLine("=================================");
                                                break;
                                            }
                                        case 3:
                                            {
                                                //Calculate Salary
                                                int hours = 0;

                                                foreach (AttendanceDetails attendanceDetails in attendanceDetailsList)
                                                {
                                                    if (employee.EmployeeId == attendanceDetails.EmployeeId && attendanceDetails.Date.Year == today.Year && attendanceDetails.Date.Month == today.Month)
                                                    {
                                                        hours += attendanceDetails.HoursWorked;
                                                        Console.WriteLine($"| {attendanceDetails.AttendanceId} | {attendanceDetails.EmployeeId} | {attendanceDetails.Date:dd/MM/yyyy} | {attendanceDetails.CheckInTime:hh:mm tt} | {attendanceDetails.CheckOutTime:hh:mm tt} | {attendanceDetails.HoursWorked} |");
                                                    }
                                                }
                                                int days = hours / 8;
                                                if (days > DateTime.DaysInMonth(today.Year, today.Month))
                                                {
                                                    System.Console.WriteLine("There are some extra entries in the attendance");
                                                }
                                                Console.WriteLine($"Total number of hours worked in this month : {hours}");
                                                Console.WriteLine($"Total Salary for this Month : {employee.CalculateSalary(500, days)}");
                                                break;
                                            }
                                        case 4:
                                            {
                                                //Exit

                                                choice = 1;
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("=========================");
                                                Console.WriteLine("Provide valid input 1-4");
                                                Console.WriteLine("=========================");
                                                break;
                                            }
                                    }
                                } while (choice != 1);
                            }

                        }
                        if (flag)
                        {
                            Console.WriteLine("===================================");
                            Console.WriteLine("Invalid user provide valid user id");
                            Console.WriteLine("===================================");
                        }
                        break;
                    }
                case 3:
                    {
                        //Exit
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Provide valid input 1-3");
                        break;
                    }
            }
        } while (option != 3);
    }
}