using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public static class Operations
    {
        //Local/Global Object Creation
        static Beneficiary currentLoggedInUser;
        //static list creation
        static List<Beneficiary> beneficiariesList = new List<Beneficiary>();
        static List<Vaccine> vaccinesList = new List<Vaccine>();
        static List<Vaccination> vaccinationsList = new List<Vaccination>();

        //MainMenu
        public static void MainMenu()
        {
            System.Console.WriteLine("*********** Welcome to syncfusion college ***********");
            string mainChoice = "yes";
            do
            {
                //Need to show main menu option.
                System.Console.WriteLine("Main menu\n1. Beneficiary Registration\n2. Login\n3. Get Vaccine Info\n4. Exit");
                //Need to get an input from user and validate.
                System.Console.Write("Select an option: ");
                int mainOption;
                bool ismainOptionValid = int.TryParse(Console.ReadLine(), out mainOption);
                while (!ismainOptionValid)
                {
                    Console.WriteLine("Enter valid number as input");
                    Console.Write("select any option :");
                    ismainOptionValid = int.TryParse(Console.ReadLine(), out mainOption);
                }

                //Need to create main menu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("********* Beneficiary Registration *********");
                            BeneficiaryRegistration();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("********* Login *********");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("********* Get Vaccine Info *********");
                            GetVaccineInfo();
                            break;
                        }
                    case 4:
                        {
                            mainChoice = "no";
                            System.Console.WriteLine("Application Exited Successfully.");
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Enter a valid option");
                            break;
                        }
                }
                //Need to iterate until the option is exit
            } while (mainChoice == "yes");
        }//main menu ends

        //Registration
        public static void BeneficiaryRegistration()
        {
            //Need to get required details

            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            System.Console.Write("Enter your Age: ");
            int age;
            bool isAgeValid = int.TryParse(Console.ReadLine(), out age);
            while (!(isAgeValid && age > 0))
            {
                Console.WriteLine("Enter valid number");
                Console.Write("Enter your Age: ");
                isAgeValid = int.TryParse(Console.ReadLine(), null, out age);
            }

            System.Console.Write("Enter your Gender ( Male or Female or other ): ");
            Gender gender;
            bool isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
            while (!isGen)
            {
                Console.WriteLine("Provide valid gender");
                System.Console.Write("Enter your Gender ( Male or Female or other ): ");
                isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
            }

            Console.Write("Enter your Mobile Number: ");
            string mobileNumber = Console.ReadLine();

            Console.Write("Enter your City: ");
            string city = Console.ReadLine();

            //Need to create an object
            Beneficiary beneficiary = new Beneficiary(name, age, gender, mobileNumber, city);

            //Need to add in the list
            beneficiariesList.Add(beneficiary);

            //Need to display confirmation message and ID
            System.Console.WriteLine($"Registraion is successfull. Your user ID is {beneficiary.BeneficiaryID}");

        }//Registration ends

        //user login
        public static void Login()
        {
            //need to get user ID
            System.Console.Write("Enter your user ID: ");
            string regNumber = Console.ReadLine().ToUpper();
            bool flag = true;
            //validate user id 
            foreach (Beneficiary beneficiary in beneficiariesList)
            {
                if (regNumber.Equals(beneficiary.BeneficiaryID))
                {
                    flag = false;
                    //assign user to current login user
                    currentLoggedInUser = beneficiary;
                    Console.WriteLine("Logged In Successfully.");
                    //Need to call sub menu
                    SubMenu();
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid User ID. Please enter a valid one.");
            } //If not - Invalid Valid.
        }//Login ends

        //GetVaccineInfo
        public static void GetVaccineInfo()
        {
            foreach (Vaccine vaccine in vaccinesList)
            {
                Console.WriteLine($"|{vaccine.VaccineID}|{vaccine.VaccineName}|{vaccine.NoOfDoseAvailable}|");
            }
        }//GetVaccineInfo ends

        //SubMenu
        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                System.Console.WriteLine("******* Sub Menu *******");
                //display sub menu and get option from user
                System.Console.WriteLine("1. Show My Details.\n2. Take Vaccination.\n3. My Vaccination History\n4. Next Due Date.\n5. Exit");
                //Getting user option
                System.Console.Write("Select a option: ");
                string subOption = Console.ReadLine();
                //Need to create Sub menu structure
                switch (subOption)
                {
                    case "1":
                        {
                            Console.WriteLine("******** Show My Details ********");
                            ShowMyDetails();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("******** Take Vaccination ********");
                            TakeVaccination();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("******** My Vaccination History ********");
                            MyVaccinationHistory();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("******** Next Due Date ********");
                            NextDueDate();
                            break;
                        }
                    case "5":
                        {
                            subChoice = "no";
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Enter a valid option");
                            break;
                        }
                }
            } while (subChoice == "yes");//Iterate till the option is Exit.
        }//Submenu Ends

        //ShowMyDetails
        public static void ShowMyDetails()
        {
            Console.WriteLine($"|{currentLoggedInUser.BeneficiaryID}|{currentLoggedInUser.Name}|{currentLoggedInUser.Age}|{currentLoggedInUser.Gender}|{currentLoggedInUser.MobileNumber}|{currentLoggedInUser.City}|");
        }//ShowMyDetails ends

        //TakeVaccination
        public static void TakeVaccination()
        {
            GetVaccineInfo();
            Console.Write("Enter the vaccine ID: ");
            string vaccineID = Console.ReadLine().ToUpper();
            bool flag = true;
            //validate vaccine number
            foreach (Vaccine vaccine in vaccinesList)
            {
                if (vaccineID.Equals(vaccine.VaccineID))
                {
                    flag = false;
                    int vaccinesTaken = 0;
                    string prevVaccineID = "";
                    DateTime date = new DateTime();
                    foreach (Vaccination vaccination in vaccinationsList)
                    {
                        if (vaccination.RegistrationNumber.Equals(currentLoggedInUser.BeneficiaryID))
                        {
                            //assign values of last vaccination detail of the user
                            vaccinesTaken++;
                            prevVaccineID = vaccination.VaccineID;
                            date = vaccination.VaccinatedDate;
                        }
                    }
                    //validate the current and previous vaccine
                    if (vaccine.VaccineID.Equals(prevVaccineID) || vaccinesTaken == 0)
                    {
                        if (vaccinesTaken == 1)
                        {
                            TimeSpan timeSpan = DateTime.Now - date.AddDays(30);
                            if (timeSpan.Days > 30)
                            {
                                //create object
                                Vaccination vaccination = new Vaccination(currentLoggedInUser.BeneficiaryID, vaccineID, DoseNumber.two, DateTime.Now);
                                //add vaccination to list
                                vaccinationsList.Add(vaccination);
                                //decrease vaccine count
                                vaccine.NoOfDoseAvailable--;
                                Console.WriteLine($"You have vaccinated your Second dose.");
                                return;
                            }
                            else
                            {
                                Console.WriteLine($"Wait till the due date for next dose");

                            }
                        }
                        else if (vaccinesTaken == 2)
                        {

                            TimeSpan timeSpan = DateTime.Now - date.AddDays(30);
                            if (timeSpan.Days > 30)
                            {
                                Vaccination vaccination = new Vaccination(currentLoggedInUser.BeneficiaryID, vaccineID, DoseNumber.three, DateTime.Now);
                                vaccinationsList.Add(vaccination);
                                vaccine.NoOfDoseAvailable--;
                                Console.WriteLine($"You have vaccinated your Third dose.");
                                return;
                            }
                            else
                            {
                                Console.WriteLine($"Wait till the due date for next dose");

                            }

                        }

                        else if (vaccinesTaken == 3)
                        {
                            Console.WriteLine("All the three Vaccination are completed, you cannot be vaccinated now");
                            return;

                        }
                        else
                        {
                            //check user age is above 14
                            if (currentLoggedInUser.Age > 14)
                            {
                                Vaccination vaccination = new Vaccination(currentLoggedInUser.BeneficiaryID, vaccineID, DoseNumber.one, DateTime.Now);
                                vaccinationsList.Add(vaccination);
                                vaccine.NoOfDoseAvailable--;
                                Console.WriteLine($"You have vaccinated your First dose.");
                                return;
                            }
                            else
                            {
                                Console.WriteLine($"Your are not above 14 years");
                                return;
                            }
                        }
                    }
                    else
                    {
                        foreach (Vaccine vaccinated in vaccinesList)
                        {
                            if (prevVaccineID.Equals(vaccinated.VaccineID))
                            {
                                Console.WriteLine($"You have selected different vaccine. You can vaccine with {vaccinated.VaccineName}");
                                return;
                            }
                        }

                    }
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Enter valid vaccine ID");
            }
        }//TakeVaccination ends

        //MyVaccinationHistory
        public static void MyVaccinationHistory()
        {
            bool flag = true;
            foreach (Vaccination vaccination in vaccinationsList)
            {
                if (vaccination.RegistrationNumber.Equals(currentLoggedInUser.BeneficiaryID))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine($"You have not vaccinated to show vaccination history");
            }
            else
            {
                foreach (Vaccination vaccination in vaccinationsList)
                {
                    if (vaccination.RegistrationNumber.Equals(currentLoggedInUser.BeneficiaryID))
                    {
                        Console.WriteLine($"|{vaccination.VaccinationID}|{vaccination.RegistrationNumber}|{vaccination.VaccineID}|{vaccination.DoseNumber}|{vaccination.VaccinatedDate:dd/MM/yyyy}|");
                    }
                }
            }
        }//MyVaccinationHistory ends

        //NextDueDate
        public static void NextDueDate()
        {
            bool flag = true;
            Vaccination vaccineInformation = new Vaccination();
            foreach (Vaccination vaccination in vaccinationsList)
            {
                if (vaccination.RegistrationNumber.Equals(currentLoggedInUser.BeneficiaryID))
                {
                    flag = false;
                    vaccineInformation = vaccination;
                }
            }
            //check previous vaccination
            if (flag)
            {
                Console.WriteLine($"you can take vaccine now");
                return;
            }
            else
            {
                if (vaccineInformation.DoseNumber == DoseNumber.one || vaccineInformation.DoseNumber == DoseNumber.two)
                {
                    Console.WriteLine($"Next due date to vaccine is {vaccineInformation.VaccinatedDate.AddDays(30):dd/MM/yyyy}");
                    return;

                }
                else if (vaccineInformation.DoseNumber == DoseNumber.three)
                {
                    Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive.");

                }
            }

        }//NextDueDate ends

        //adding default data
        public static void AddDefaultData()
        {
            Beneficiary beneficiary1 = new Beneficiary("Ravichandran", 21, Gender.Male, "8484484", "Chennai");
            Beneficiary beneficiary2 = new Beneficiary("Baskaran", 22, Gender.Male, "8484747", "Chennai");

            beneficiariesList.AddRange(new List<Beneficiary> { beneficiary1, beneficiary2 });

            Vaccine vaccine1 = new Vaccine("Covishield", 50);
            Vaccine vaccine2 = new Vaccine("Covaccine", 50);

            vaccinesList.AddRange(new List<Vaccine> { vaccine1, vaccine2 });

            Vaccination vaccination1 = new Vaccination("BID1001", "CID2001", DoseNumber.one, new DateTime(2021, 11, 11));
            Vaccination vaccination2 = new Vaccination("BID1001", "CID2001", DoseNumber.two, new DateTime(2022, 03, 11));
            Vaccination vaccination3 = new Vaccination("BID1002", "CID2002", DoseNumber.one, new DateTime(2022, 04, 04));

            vaccinationsList.AddRange(new List<Vaccination> { vaccination1, vaccination2, vaccination3 });


        }//default data ends

    }
}