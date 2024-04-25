using System;
using System.Collections.Generic;
namespace EmployeePayrollManagement2;
class Program
{
    public static void Main(string[] args)
    {
        List<Employee> Employees = new List<Employee>();

        DateTime date1 = new DateTime(2022, 05, 15, 9, 0, 0);
        DateTime date2 = new DateTime(2022, 05, 15, 18, 10, 0);
        TimeSpan timeSpan = date2-date1;
        System.Console.WriteLine(timeSpan.Hours); 

        Console.WriteLine("Welcome");
        int option;
        do
        {
            Console.WriteLine("1.Registration\n2.Login\n3.Exit");
            Console.Write("select any option :");
            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter the role: ");
                        string role = Console.ReadLine();
                        Console.Write("Enter the work location (Chennai/Kisumu/California): ");
                        workLocation worklocation;
                        bool islocation = Enum.TryParse(Console.ReadLine(), true, out worklocation);
                        while (!islocation)
                        {
                            Console.WriteLine("Provide valid location");
                            Console.Write("Enter the work location (Chennai/Kisumu/California): ");
                            islocation = Enum.TryParse(Console.ReadLine(), true, out worklocation);
                        }
                        Console.Write("Enter the team name: ");
                        string team = Console.ReadLine();
                        Console.Write("Enter date of joining (dd/mm/yyyy): ");
                        DateTime doj = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        Console.Write("Enter no of working days: ");
                        int workingDays = int.Parse(Console.ReadLine());
                        Console.Write("Enter no of leave taken: ");
                        int leaves = int.Parse(Console.ReadLine());
                        Console.Write("Enter gender (Male or Female): ");
                        Gender gender;
                        bool isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
                        while (!isGen)
                        {
                            Console.WriteLine("Provide valid gender");
                            Console.Write("Enter gender (Male or Female): ");
                            isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
                        }

                        //new employee
                        Employee employee = new Employee(name, role, worklocation, team, doj, workingDays, leaves, gender);

                        //adding to list
                        Employees.Add(employee);
                        break;

                    }
                case 2:
                    {

                        Console.Write("Enter the employee id: ");
                        string id = Console.ReadLine();
                        bool flag = true;
                        foreach (Employee employee in Employees)
                        {
                            if (employee.EmployeeId == id)
                            {
                                flag = false;
                                int choice = 0;
                                do
                                {
                                    Console.WriteLine("1. Calculate salary\n2. display details\n3. exit");
                                    Console.Write("select any option :");
                                    option = int.Parse(Console.ReadLine());
                                    switch (option)
                                    {

                                        case 1:
                                            {
                                                Console.WriteLine($"salary of the employee: {employee.CalculateSalary(500)}");
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("================");
                                                employee.EmployeeDetails();
                                                Console.WriteLine("================");
                                                break;
                                            }
                                        case 3:
                                            {
                                                choice = 1;
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("================");
                                                Console.WriteLine("Provide valid input 1-4");
                                                Console.WriteLine("================");
                                                break;
                                            }
                                    }
                                } while (choice != 1);
                            }

                        }
                        if (flag)
                        {
                            Console.WriteLine("================");
                            Console.WriteLine("Invalid user provide valid user id");
                            Console.WriteLine("================");
                        }
                        break;
                    }
                case 3:
                    {
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