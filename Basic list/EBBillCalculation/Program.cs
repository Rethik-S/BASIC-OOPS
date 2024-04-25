using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
namespace EBBillCalculation;
class Program
{
    public static void Main(string[] args)
    {
        List<Meter> houseMeters = new List<Meter>();

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
                        Console.Write("Enter user name: ");
                        string uName = Console.ReadLine();
                        Console.Write("Enter phone number: ");
                        long phone = long.Parse(Console.ReadLine());
                        Console.Write("Enter Mail id: ");
                        string mail = Console.ReadLine();

                        Meter meter = new Meter(uName, phone, mail);

                        houseMeters.Add(meter);
                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter User Id: ");
                        string usrId = Console.ReadLine();
                        bool flag = true;
                        foreach (Meter meter in houseMeters)
                        {
                            if (meter.MeterId == usrId)
                            {
                                flag = false;
                                int choice = 0;
                                do
                                {
                                    Console.WriteLine("1. Calculate Amount\n2. display details\n3. exit");
                                    Console.Write("select any option :");
                                    int option2 = int.Parse(Console.ReadLine());
                                    switch (option2)
                                    {

                                        case 1:
                                            {
                                                Console.Write($"Enter the units used : ");
                                                double units = double.Parse(Console.ReadLine());
                                                double amount = meter.CalculateAmount(units);
                                                Console.WriteLine("======Bill======");
                                                Console.WriteLine($"Meter id : {meter.MeterId}");
                                                Console.WriteLine($"User Name : {meter.UserName}");
                                                Console.WriteLine($"Units : {meter.Units}");
                                                Console.WriteLine($"Amount : {amount}"); 
                                                Console.WriteLine("================");
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("================");
                                                Console.WriteLine($"Meter id : {meter.MeterId}");
                                                Console.WriteLine($"User Name : {meter.UserName}");
                                                Console.WriteLine($"Phone number : {meter.PhoneNumber}");
                                                Console.WriteLine($"Mail id : {meter.MailId}");
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
                                                Console.WriteLine("Provide valid input 1-4");
                                                break;
                                            }
                                    }

                                } while (choice != 1);
                            }
                        }

                        if (flag)
                        {
                            Console.WriteLine("Invalid user ID");
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