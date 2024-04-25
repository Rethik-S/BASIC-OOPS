using System;
using System.Collections.Generic;
using BankAccountOpening2;

namespace BankAccountOpening3;
class Program
{
    public static void Main(string[] args)
    {
        List<Account> accounts = new List<Account>();

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
                        Console.Write("Enter money to deposit: ");
                        double amount = double.Parse(Console.ReadLine());
                        Console.Write("Enter gender (Male or Female): ");
                        Gender gender;
                        bool isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
                        while (!isGen)
                        {
                            Console.WriteLine("Provide valid gender");
                            Console.Write("Enter gender (Male or Female): ");
                            isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
                        }
                        Console.Write("Enter Phone number: ");
                        long phone = long.Parse(Console.ReadLine());
                        Console.Write("Enter Mail id: ");
                        string mail = Console.ReadLine();
                        Console.Write("Enter date of birth (dd/mm/yyyy): ");
                        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                        Account account = new Account(name, amount, gender, phone, mail, dob);

                        accounts.Add(account);

                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter User Id: ");
                        string usrId = Console.ReadLine();
                        bool flag = true;
                        foreach (Account account in accounts)
                        {
                            if (account.CustomerId == usrId)
                            {
                                flag = false;
                                int choice = 0;
                                do
                                {
                                    Console.WriteLine("1. Deposit\n2. withdraw\n3. balance check\n4. exit");
                                    Console.Write("select any option :");
                                    option = int.Parse(Console.ReadLine());
                                    switch (option)
                                    {
                                        case 1:
                                            {
                                                Console.Write("Enter the amount");
                                                double amount = double.Parse(Console.ReadLine());
                                                Console.WriteLine($"balance: {account.Deposit(amount)}");
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.Write("Enter the amount");
                                                double amount = double.Parse(Console.ReadLine());
                                                Console.WriteLine($"balance: {account.Withdraw(amount)}");
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.WriteLine($"balance: {account.CheckBalance()}");
                                                break;
                                            }
                                        case 4:
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