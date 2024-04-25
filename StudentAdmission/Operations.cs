using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeAdmission;

namespace StudentAdmission
{
    //static class
    public static class Operations
    {
        //Local/Global Object Creation
        static StudentDetails currentLoggedInStudent;
        //static list creation
        static List<StudentDetails> studentList = new List<StudentDetails>();
        static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

        //Main menu
        public static void MainMenu()
        {
            System.Console.WriteLine("*********** Welcome to syncfusion college ***********");
            string mainChoice = "yes";
            do
            {
                //Need to show main menu option.
                System.Console.WriteLine("Main menu\n1. Registration\n2. Login\n3. Department wise seat availability\n4. Exit");
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
                            System.Console.WriteLine("********* Student Registration *********");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("********* Student Login *********");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("********* Department wise seat availability *********");
                            DepartmentWiseSeatAvailabilty();
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
                            System.Console.WriteLine("");
                            break;
                        }
                }
                //Need to iterate until the option is exit
            } while (mainChoice == "yes");
        }//main menu ends

        //Student Registration
        public static void StudentRegistration()
        {
            //Need to get required details

            Console.Write("Enter your Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter your Father Name: ");
            string fatherName = Console.ReadLine();

            Console.Write("Enter your Date of birth: ");
            DateTime dob;
            bool isDOBValid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
            while (!isDOBValid)
            {
                Console.Write("Enter your Date of birth: ");
                isDOBValid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
            }

            System.Console.Write("Enter your Gender: ");
            Gender gender;
            bool isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
            while (!isGen)
            {
                Console.WriteLine("Provide valid gender");
                Console.Write("Enter gender ( Male or Female or Transgender ): ");
                isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
            }

            System.Console.Write("Enter your Physics mark: ");
            int physicsMark;
            bool isphysicsMarkValid = int.TryParse(Console.ReadLine(), out physicsMark);
            while (!isphysicsMarkValid || !(physicsMark >= 0 && physicsMark <= 100))
            {
                Console.WriteLine("Enter valid input between (0-100)");
                Console.Write("Enter your Physics mark: ");
                isphysicsMarkValid = int.TryParse(Console.ReadLine(), null, out physicsMark);
            }
            System.Console.Write("Enter your chemistry mark: ");
            int chemistryMark;
            bool ischemistryMarkValid = int.TryParse(Console.ReadLine(), null, out chemistryMark);
            while (!ischemistryMarkValid || !(chemistryMark >= 0 && chemistryMark <= 100))
            {
                Console.WriteLine("Enter valid input between (0-100)");
                Console.Write("Enter your chemistry mark: ");
                ischemistryMarkValid = int.TryParse(Console.ReadLine(), null, out chemistryMark);

            }
            System.Console.Write("Enter your math mark: ");
            int mathsMark;
            bool ismathsMarkValid = int.TryParse(Console.ReadLine(), null, out mathsMark);
            while (!ismathsMarkValid || !(mathsMark >= 0 && mathsMark <= 100))
            {
                Console.WriteLine("Enter valid input between (0-100)");
                Console.Write("Enter Maths mark: ");
                ismathsMarkValid = int.TryParse(Console.ReadLine(), null, out mathsMark);
            }

            //Need to create an object
            StudentDetails student = new StudentDetails(studentName, fatherName, dob, gender, physicsMark, chemistryMark, mathsMark);

            //Need to add in the list
            studentList.Add(student);

            //Need to display confirmation message and ID
            System.Console.WriteLine($"Student Registered Successfully and StudentID is {student.StudentID}");

        }//Student Registration ends

        //Student Login
        public static void StudentLogin()
        {
            //Need to get Id input
            System.Console.Write("Enter your Student ID: ");
            string loginID = Console.ReadLine().ToUpper();
            //Validate by its prescence in list
            bool flag = true;
            foreach (StudentDetails student in studentList)
            {
                if (loginID.Equals(student.StudentID))
                {
                    flag = false;
                    //assigning current user to glabal variable
                    currentLoggedInStudent = student;
                    System.Console.WriteLine("Logged In Successfully.");
                    //Need to call sub menu
                    Submenu();
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid ID or ID is not present.");
            }
            //If not - Invalid Valid.
        }//Student Login ends

        //Submenu
        public static void Submenu()
        {
            string subChoice = "yes";
            do
            {
                System.Console.WriteLine("********** SubMenu **********");
                //Need to show sub menu option
                System.Console.WriteLine("1. Check Eligibility\n2. Show Details\n3. Take Admission\n4. Cancel Admission\n5. Show Admission Details\n6. Exit");
                //Getting user option
                System.Console.Write("Select an option: ");
                int subOption;
                bool issubOptionValid = int.TryParse(Console.ReadLine(), out subOption);
                while (!issubOptionValid)
                {
                    Console.WriteLine("Enter valid number as input");
                    Console.Write("select an option :");
                    issubOptionValid = int.TryParse(Console.ReadLine(), out subOption);
                }
                //Need to create Sub menu structure
                switch (subOption)
                {
                    case 1:
                        {
                            System.Console.WriteLine("******** Check Eligibilty ********");
                            CheckEligibility();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("******** Show Details ********");
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("******** Take Admission ********");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("******** Cancel Admission ********");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("******** Show Admission Details ********");
                            ShowAdmissionDetails();
                            break;
                        }
                    case 6:
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
                //Iterate till the option is Exit.

            } while (subChoice == "yes");
        }//Submenu Ends

        //CheckEligibilty
        public static void CheckEligibility()
        {
            //set a cutoff value as input
            System.Console.Write("Enter the cutoff value: ");
            double cutOff = double.Parse(Console.ReadLine());
            //check eligibile or not
            if (currentLoggedInStudent.CheckEligibility(cutOff))
            {
                System.Console.WriteLine("Student is eligible.");
            }
            else
            {
                System.Console.WriteLine("Student is not eligible.");
            }
        }
        //ShowDetails
        public static void ShowDetails()
        {
            //Need to show current student details
            Console.WriteLine($"Student ID: {currentLoggedInStudent.StudentID}");
            Console.WriteLine($"Student Name: {currentLoggedInStudent.StudentName}");
            Console.WriteLine($"Date of birth : {currentLoggedInStudent.DateOfBirth:dd/MM/yyyy}");
            Console.WriteLine($"Gender: {currentLoggedInStudent.Gender}");
            Console.WriteLine($"Physics Marks: {currentLoggedInStudent.PhysicsMark}");
            Console.WriteLine($"Chemistry Marks: {currentLoggedInStudent.ChemistryMark}");
            Console.WriteLine($"Maths Marks: {currentLoggedInStudent.MathsMark}");
        }//ShowDetails ends

        //TakeAdmission
        public static void TakeAdmission()
        {
            //Need to show available department details
            DepartmentWiseSeatAvailabilty();
            //Ask department ID from user
            System.Console.Write("Select a department ID");
            string departmentID = Console.ReadLine().ToUpper();
            //check the ID is present or not
            bool flag = true;
            foreach (DepartmentDetails department in departmentList)
            {
                if (department.DepartmentID.Equals(departmentID))
                {
                    flag = false;
                    //check the student is eligible or not
                    if (currentLoggedInStudent.CheckEligibility(75.0))
                    {
                        //check the seat availabilty
                        if (department.NumberOfSeats > 0)
                        {
                            int count = 0;
                            foreach (AdmissionDetails admission in admissionList)
                            {
                                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;
                                }
                            }
                            //check Student already taken any admission
                            if (count == 0)
                            {
                                //create admission object
                                AdmissionDetails admissionTaken = new AdmissionDetails(currentLoggedInStudent.StudentID, department.DepartmentID, DateTime.Now, AdmissionStatus.Admitted);
                                //Reduce a seat count
                                department.NumberOfSeats--;
                                //Add to the admission list
                                admissionList.Add(admissionTaken);
                                //Display admission successful message
                                System.Console.WriteLine($"Admission took successfully. Your admission ID – {admissionTaken.AdmissionID}");
                            }
                            else
                            {
                                System.Console.WriteLine("you have already taken an admission.");
                            }
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Student is not eligible");
                    }
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid ID or ID not present.");
            }

        }//TakeAdmission ends

        //CancelAdmission
        public static void CancelAdmission()
        {
            //Check the student is taken any admission and display it.
            bool flag = true;
            foreach (AdmissionDetails admission in admissionList)
            {
                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    flag = false;
                    //cancel the found admission.
                    admission.AdmissionStatus = AdmissionStatus.Cancelled;
                    //return the seat to department.
                    foreach (DepartmentDetails department in departmentList)
                    {
                        if (admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            break;
                        }
                    }
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("You have not admission to cancel");
            }

        }//CancelAdmission ends

        //ShowAdmissionDetails
        public static void ShowAdmissionDetails()
        {
            System.Console.WriteLine("|Admission ID|Student ID|Department ID|Admission Date|Admission Status|");
            //Need to show current logged in student's admission detail
            foreach (AdmissionDetails admission in admissionList)
            {
                if (currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                {
                    Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}|");
                }
            }
        }//ShowAdmissionDetails ends


        //Department Wise Seat Availabilty
        public static void DepartmentWiseSeatAvailabilty()
        {
            System.Console.WriteLine("Department ID | Department Name | Number of seats");
            foreach (DepartmentDetails department in departmentList)
            {
                if (department.NumberOfSeats > 0)
                {
                    System.Console.WriteLine($"|{department.DepartmentID}|{department.DepartmentName}|{department.NumberOfSeats}|");
                }
            }

        }


        //adding default data
        public static void AddDefaultData()
        {
            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);

            studentList.AddRange(new List<StudentDetails> { student1, student2 });

            DepartmentDetails EEE = new DepartmentDetails("EEE", 29);
            DepartmentDetails CSE = new DepartmentDetails("CSE", 29);
            DepartmentDetails MECH = new DepartmentDetails("MECH", 30);
            DepartmentDetails ECE = new DepartmentDetails("ECE", 30);

            departmentList.AddRange(new List<DepartmentDetails> { EEE, CSE, MECH, ECE });

            AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID, ECE.DepartmentID, new DateTime(2022, 05, 11), AdmissionStatus.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails(student2.StudentID, CSE.DepartmentID, new DateTime(2022, 05, 12), AdmissionStatus.Admitted);

            admissionList.AddRange(new List<AdmissionDetails> { admission1, admission2 });

            //printing data
            foreach (StudentDetails student in studentList)
            {
                System.Console.WriteLine($"|{student.StudentID}|{student.FatherName}|{student.DateOfBirth}|{student.Gender}|{student.PhysicsMark}|{student.ChemistryMark}|{student.MathsMark}|");
            }

            foreach (DepartmentDetails department in departmentList)
            {
                System.Console.WriteLine($"{department.DepartmentID}|{department.DepartmentName}|{department.NumberOfSeats}|");
            }

            foreach (AdmissionDetails admission in admissionList)
            {
                System.Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}|");
            }
        }
    }
}