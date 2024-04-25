using System;
using System.Collections.Generic;
namespace CollegeAdmission;
class Program
{
    public static void Main(string[] args)
    {
        List<StudentDetails> studentDetailsList = new List<StudentDetails>();
        List<DepartmentDetails> departmentDetailsList = new List<DepartmentDetails>();
        List<AdmissionDetails> admissionDetailsList = new List<AdmissionDetails>();


        DepartmentDetails EEE = new DepartmentDetails("EEE", 29);
        DepartmentDetails CSE = new DepartmentDetails("CSE", 29);
        DepartmentDetails MECH = new DepartmentDetails("MECH", 30);
        DepartmentDetails ECE = new DepartmentDetails("ECE", 30);

        departmentDetailsList.Add(EEE);
        departmentDetailsList.Add(CSE);
        departmentDetailsList.Add(MECH);
        departmentDetailsList.Add(ECE);

        DateTime dob1 = new DateTime(1999, 11, 11);
        DateTime dob2 = new DateTime(1999, 11, 11);

        StudentDetails studentDetails1 = new StudentDetails("Ravichandran E", "Ettapparajan", dob1, Gender.Male, 95, 95, 95);
        StudentDetails studentDetails2 = new StudentDetails("Baskaran S", "Sethurajan", dob2, Gender.Male, 95, 95, 95);

        studentDetailsList.Add(studentDetails1);
        studentDetailsList.Add(studentDetails2);

        DateTime admissionDate1 = new DateTime(2022, 05, 11);
        DateTime admissionDate2 = new DateTime(2022, 05, 12);

        AdmissionDetails admissionDetails1 = new AdmissionDetails(studentDetails1.StudentId, ECE.DepartmentId, admissionDate1, AdmissionStatus.Admitted);
        AdmissionDetails admissionDetails2 = new AdmissionDetails(studentDetails2.StudentId, CSE.DepartmentId, admissionDate2, AdmissionStatus.Admitted);

        admissionDetailsList.Add(admissionDetails1);
        admissionDetailsList.Add(admissionDetails2);


        int choice = 0;
        do
        {
            Console.WriteLine("1. Student Registration\n2. Student Login\n3. Department wise seat availability\n4. Exit");

            int option;
            Console.Write("select any option :");
            bool isoptValid = int.TryParse(Console.ReadLine(), out option);
            while (!isoptValid)
            {
                Console.WriteLine("Enter valid number as input");
                Console.Write("select any option :");
                isoptValid = int.TryParse(Console.ReadLine(), out option);
            }

            switch (option)
            {
                case 1:
                    {
                        //Student Registration

                        Console.Write("Enter student name: ");
                        string studentName = Console.ReadLine();

                        Console.Write("Enter Father name: ");
                        string fatherName = Console.ReadLine();

                        Console.Write("Enter date of birth (dd/mm/yyyy): ");
                        DateTime dob;
                        bool isDobValid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
                        while (!isDobValid)
                        {
                            Console.WriteLine("Provide valid Date of birth");
                            Console.Write("Enter date of birth (dd/mm/yyyy): ");
                            isDobValid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
                        }


                        int physics;
                        Console.Write("Enter Physics mark: ");
                        bool isPhyValid = int.TryParse(Console.ReadLine(), out physics);
                        while (!isPhyValid || !(physics >= 0 && physics <= 100))
                        {
                            Console.WriteLine("Enter valid input between (0-100)");
                            Console.Write("Enter Physics mark: ");
                            isPhyValid = int.TryParse(Console.ReadLine(), null, out physics);
                        }

                        int Chemistry;
                        Console.Write("Enter Chemistry mark: ");
                        bool ischemValid = int.TryParse(Console.ReadLine(), null, out Chemistry);
                        while (!ischemValid || !(Chemistry >= 0 && Chemistry <= 100))
                        {
                            Console.WriteLine("Enter valid input between (0-100)");
                            Console.Write("Enter Chemistry mark: ");
                            ischemValid = int.TryParse(Console.ReadLine(), null, out Chemistry);

                        }

                        int maths;
                        Console.Write("Enter Maths mark: ");
                        bool ismathValid = int.TryParse(Console.ReadLine(), null, out maths);
                        while (!ismathValid || !(maths >= 0 && maths <= 100))
                        {
                            Console.WriteLine("Enter valid input between (0-100)");
                            Console.Write("Enter Maths mark: ");
                            ismathValid = int.TryParse(Console.ReadLine(), null, out maths);
                        }

                        Console.Write("Enter gender (Male or Female or Transgender): ");
                        Gender gender;
                        bool isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
                        while (!isGen)
                        {
                            Console.WriteLine("Provide valid gender");
                            Console.Write("Enter gender ( Male or Female or Transgender ): ");
                            isGen = Enum.TryParse(Console.ReadLine(), true, out gender);
                        }

                        StudentDetails student = new StudentDetails(studentName, fatherName, dob, gender, physics, Chemistry, maths);

                        studentDetailsList.Add(student);
                        Console.WriteLine($"Student Registered Successfully and StudentID is {student.StudentId}");
                        break;
                    }
                case 2:
                    {
                        // Student Login
                        Console.Write("Enter the Student id: ");
                        string id = Console.ReadLine().ToUpper();
                        bool flag = true;
                        foreach (StudentDetails studentDetails in studentDetailsList)
                        {
                            if (studentDetails.StudentId == id)
                            {
                                flag = false;
                                int choice1 = 0;
                                do
                                {
                                    Console.WriteLine("1. Check Eligibility\n2. Show Details\n3. Take Admission\n4. Cancel Admission\n5. Show Admission Details \n6. Exit");

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
                                                //Check Eligibility
                                                if (studentDetails.CheckEligibility())
                                                {
                                                    Console.WriteLine("Student is eligible");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Student is not eligible");
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                //Show Details
                                                studentDetails.ShowDetails();
                                                break;
                                            }
                                        case 3:
                                            {
                                                //Take Admission
                                                foreach (DepartmentDetails departmentDetails in departmentDetailsList)
                                                {
                                                    Console.WriteLine($"Dept Id: {departmentDetails.DepartmentId} |  No of seats in {departmentDetails.DepartmentName} : {departmentDetails.NumberOfSeats}");
                                                }

                                                Console.Write("Enter the department Id: ");
                                                string dept = Console.ReadLine();
                                                bool flag1 = true;
                                                foreach (DepartmentDetails departmentDetails1 in departmentDetailsList)
                                                {
                                                    if (departmentDetails1.DepartmentId == dept)
                                                    {
                                                        flag1 = false;
                                                        if (studentDetails.CheckEligibility())
                                                        {
                                                            if (departmentDetails1.NumberOfSeats > 0)
                                                            {
                                                                bool adminFlag = true;
                                                                foreach (AdmissionDetails admissionDetails in admissionDetailsList)
                                                                {
                                                                    if (admissionDetails.StudentId == studentDetails.StudentId)
                                                                    {
                                                                        if (admissionDetails.AdmissionStatus == AdmissionStatus.Admitted)
                                                                        {
                                                                            adminFlag = false;
                                                                        }
                                                                        else if (admissionDetails.AdmissionStatus == AdmissionStatus.Cancelled)
                                                                        {

                                                                            adminFlag = true;
                                                                        }
                                                                    }

                                                                }
                                                                if (adminFlag)
                                                                {
                                                                    departmentDetails1.NumberOfSeats -= 1;
                                                                    AdmissionDetails admission = new AdmissionDetails(studentDetails.StudentId, departmentDetails1.DepartmentId, DateTime.Now, AdmissionStatus.Admitted);
                                                                    admissionDetailsList.Add(admission);
                                                                    Console.WriteLine($"Admission took successfully. Your admission ID: {admission.AdmissionId}");
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    System.Console.WriteLine("this student is already admitted");
                                                                    break;
                                                                }

                                                            }
                                                            else
                                                            {
                                                                System.Console.WriteLine($"There are no seats left in {departmentDetails1.DepartmentName}");
                                                                break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Student is not eligible");
                                                            break;
                                                        }

                                                    }
                                                }
                                                if (flag1)
                                                {
                                                    System.Console.WriteLine("Enter valid Department");
                                                }
                                                break;
                                            }
                                        case 4:
                                            {
                                                //Cancel Admission
                                                bool cancelFlag = true;
                                                int cancelIndex = 0;
                                                bool isFound = true;
                                                foreach (AdmissionDetails admissionDetails in admissionDetailsList)
                                                {
                                                    if (admissionDetails.StudentId == studentDetails.StudentId)
                                                    {
                                                        isFound = false;
                                                        if (admissionDetails.AdmissionStatus == AdmissionStatus.Admitted)
                                                        {
                                                            cancelFlag = true;
                                                        }
                                                        else
                                                        {
                                                            cancelFlag = false;
                                                        }
                                                        cancelIndex = admissionDetailsList.IndexOf(admissionDetails);
                                                    }
                                                }
                                                if (isFound)
                                                {
                                                    Console.WriteLine("No admission record for this student to cancel.");
                                                    break;
                                                }
                                                if (cancelFlag)
                                                {
                                                    AdmissionDetails admission = admissionDetailsList[cancelIndex];
                                                    admission.AdmissionStatus = AdmissionStatus.Cancelled;
                                                    foreach (DepartmentDetails departmentDetails in departmentDetailsList)
                                                    {
                                                        if (departmentDetails.DepartmentId == admission.DepartmentId)
                                                        {
                                                            departmentDetails.NumberOfSeats += 1;
                                                            break;
                                                        }
                                                    }
                                                    Console.WriteLine("Admission cancelled successfully.");
                                                }
                                                break;
                                            }
                                        case 5:
                                            {
                                                //Show Admission Details
                                                foreach (AdmissionDetails admissionDetails in admissionDetailsList)
                                                {
                                                    Console.WriteLine($"{admissionDetails.AdmissionId} | {admissionDetails.StudentId} | {admissionDetails.DepartmentId} | {admissionDetails.AdmissionDate:dd/MM/yyyy} | {admissionDetails.AdmissionStatus}");
                                                }
                                                break;
                                            }
                                        case 6:
                                            {
                                                //Exit
                                                choice1 = 1;
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Provide valid input 1-6");
                                                break;
                                            }
                                    }
                                } while (choice1 != 1);
                            }
                        }
                        if (flag)
                        {
                            Console.WriteLine("================");
                            Console.WriteLine("Invalid provide valid student id");
                            Console.WriteLine("================");
                        }
                        break;
                    }
                case 3:
                    {
                        //Department wise seat availability
                        foreach (DepartmentDetails departmentDetails in departmentDetailsList)
                        {
                            Console.WriteLine($"Dept Id: {departmentDetails.DepartmentId} |  No of seats in {departmentDetails.DepartmentName} : {departmentDetails.NumberOfSeats}");
                        }
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
                        Console.WriteLine("Provide valid input 1-4");
                        break;
                    }
            }

        } while (choice != 1);

    }
}
