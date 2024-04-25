using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public static class Operations
    {
        //current logged in user
        static UserDetails currentLoggedInUser;
        //need to create lists to store data
        static List<UserDetails> usersList = new List<UserDetails>();
        static List<BookDetails> booksList = new List<BookDetails>();
        static List<BorrowDetails> borrowsList = new List<BorrowDetails>();


        //Main menu
        public static void MainMenu()
        {
            System.Console.WriteLine("********* Welcome to Syncfusion Library *********");
            System.Console.WriteLine();
            string mainChoice = "yes";
            do
            {
                Console.WriteLine("********* Main Menu *********");
                //display main menu and ask for a option
                System.Console.WriteLine("1. User Registration\n2. User Login\n3. Exit");
                System.Console.Write("Select a option: ");
                string mainOption = Console.ReadLine();
                switch (mainOption)
                {
                    case "1":
                        {
                            UserRegistration();
                            break;
                        }
                    case "2":
                        {
                            UserLogin();
                            break;
                        }
                    case "3":
                        {
                            mainChoice = "no";
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine("Enter a valid option");
                            break;
                        }

                }

            } while (mainChoice == "yes");
        }//end of main menu

        //user registration
        public static void UserRegistration()
        {
            System.Console.WriteLine("******* User Registration *******");

            //Getting user details
            Console.Write("Enter your Name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter your Gender( Male or Female or other ): ");
            Gender gender;
            bool isGendervalid = Enum.TryParse(Console.ReadLine(), true, out gender);
            while (!isGendervalid)
            {
                Console.WriteLine("Provide valid gender");
                Console.Write("Enter gender ( Male or Female or other ): ");
                isGendervalid = Enum.TryParse(Console.ReadLine(), true, out gender);
            }
            Console.Write("Enter your Department (ECE,EEE,CSE): ");
            Department department;
            bool isdepartmentvalid = Enum.TryParse(Console.ReadLine(), true, out department);
            while (!isdepartmentvalid)
            {
                Console.WriteLine("Provide valid Department");
                Console.Write("Enter Department (ECE,EEE,CSE): ");
                isdepartmentvalid = Enum.TryParse(Console.ReadLine(), true, out department);
            }

            Console.Write("Enter your Mobile Number: ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter your Mail ID: ");
            string mailID = Console.ReadLine();
            Console.Write("Enter the amount to deposit in wallet: ");
            double walletBalance;
            bool iswalletBalancevalid = double.TryParse(Console.ReadLine(), out walletBalance);
            while (!(iswalletBalancevalid && walletBalance > 0))
            {
                Console.WriteLine("Provide valid amount");
                Console.Write("Enter the amount to deposit in wallet: ");
                iswalletBalancevalid = double.TryParse(Console.ReadLine(), out walletBalance);
            }

            //user object creation
            UserDetails user = new UserDetails(userName, gender, department, mobileNumber, mailID, walletBalance);

            //Adding user to list
            usersList.Add(user);

            //showing the user ID
            System.Console.WriteLine($"Registraion is successfull. Your user ID is {user.UserID}");

        }//end of user registration

        //user login
        public static void UserLogin()
        {
            System.Console.WriteLine("******* User Login *******");
            //need to get user ID
            System.Console.Write("Enter your user ID: ");
            string userID = Console.ReadLine().ToUpper();
            bool flag = true;
            //validate user id 
            foreach (UserDetails user in usersList)
            {
                if (userID.Equals(user.UserID))
                {
                    flag = false;
                    //assign user to current login user
                    currentLoggedInUser = user;
                    SubMenu();
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid User ID. Please enter a valid one.");
            }
        }

        //SubMenu
        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                System.Console.WriteLine("******* Sub Menu *******");
                //display sub menu and get option from user
                System.Console.WriteLine("1. Borrow book.\n2. Show Borrowed History.\n3. Return Books\n4. Wallet Recharge.\n5. Exit");
                System.Console.Write("Select a option: ");
                string subOption = Console.ReadLine();
                switch (subOption)
                {
                    case "1":
                        {
                            BorrowBook();
                            break;
                        }
                    case "2":
                        {
                            ShowBorrowedHistory();
                            break;
                        }
                    case "3":
                        {
                            ReturnBooks();
                            break;
                        }
                    case "4":
                        {
                            WalletRecharge();
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
            } while (subChoice == "yes");
        }

        //BorrowBook
        public static void BorrowBook()
        {
            Console.WriteLine("******** Borrow Book ********");
            //display book details
            foreach (BookDetails showBook in booksList)
            {
                System.Console.WriteLine($"|{showBook.BookID}|{showBook.BookName}|{showBook.AuthorName}|{showBook.BookCount}");
            }
            //get book id from user
            System.Console.Write("Enter Book ID to borrow: ");
            string bookID = Console.ReadLine().ToUpper();
            bool flag = true;
            //validate book id
            foreach (BookDetails book in booksList)
            {
                if (book.BookID.Equals(bookID))
                {
                    flag = false;
                    System.Console.Write("Enter the count of the book: ");
                    int bookCount = int.Parse(Console.ReadLine());
                    //validate book count
                    if (!(bookCount > 0 && book.BookCount > 0 && bookCount <= book.BookCount))
                    {
                        System.Console.WriteLine("Books are not available for the selected count.");
                        //display book availabilty
                        foreach (BorrowDetails borrow in borrowsList)
                        {
                            if (book.BookID.Equals(borrow.BookID))
                            {
                                Console.WriteLine($"The book will be available on {borrow.BorrowedDate.AddDays(15):dd/MM/yyyy}");
                                break;
                            }
                        }
                        return;
                    }
                    else
                    {
                        //getting user current borrows
                        int totalBorrows = 0;
                        foreach (BorrowDetails borrow in borrowsList)
                        {
                            if (currentLoggedInUser.UserID.Equals(borrow.UserID))
                            {
                                if (borrow.Status == Status.Borrowed)
                                {
                                    totalBorrows += borrow.BorrowBookCount;
                                }
                            }
                        }

                        if (totalBorrows >= 3)
                        {
                            System.Console.WriteLine("You have borrowed 3 books already");
                            return;
                        }
                        else if ((bookCount + totalBorrows) > 3)
                        {
                            System.Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {totalBorrows} and requested count is {bookCount}, which exceeds 3");
                            return;
                        }
                        else
                        {
                            //need to create book details object
                            BorrowDetails borrowDetails = new BorrowDetails(book.BookID, currentLoggedInUser.UserID, DateTime.Now, bookCount, Status.Borrowed, 0);

                            //Add borrowed book details to books list
                            borrowsList.Add(borrowDetails);
                            //returning the book count
                            book.BookCount -= bookCount;

                            System.Console.WriteLine("Book Borrowed sucessfully");
                        }
                        return;
                    }
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid Book ID, Please enter valid ID.");
            }
        }//end of borrow book

        //show borrowed history
        public static void ShowBorrowedHistory()
        {
            Console.WriteLine("******** Show Borrowed History ********");
            bool flag = true; ;
            //display history if present
            foreach (BorrowDetails borrow in borrowsList)
            {
                if (currentLoggedInUser.UserID.Equals(borrow.UserID))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("You have not borrowed books to show history");
            }
            else
            {
                System.Console.WriteLine($"||");
                foreach (BorrowDetails borrow in borrowsList)
                {
                    if (currentLoggedInUser.UserID.Equals(borrow.UserID))
                    {
                        System.Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowedDate:dd/MM/yyyy}|{borrow.BorrowBookCount}|{borrow.Status}|{borrow.PaidFineAmount}|");
                    }
                }
            }


        }//end of show borrowed history
         //return books
        public static void ReturnBooks()
        {
            Console.WriteLine("******** Return Books ********");

            bool flag = true; ;
            //return book if present
            foreach (BorrowDetails borrow in borrowsList)
            {
                if (currentLoggedInUser.UserID.Equals(borrow.UserID))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                System.Console.WriteLine("You have not borrowed books to return");
            }
            else
            {
                //display books borrowed
                System.Console.WriteLine($"||");
                foreach (BorrowDetails borrow in borrowsList)
                {
                    if (currentLoggedInUser.UserID.Equals(borrow.UserID) && borrow.Status == Status.Borrowed)
                    {
                        DateTime showReturnDate = borrow.BorrowedDate.AddDays(15);
                        Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowedDate:dd/MM/yyyy}|{borrow.BorrowBookCount}|{borrow.Status}|{borrow.PaidFineAmount}|{showReturnDate:dd/MM/yyyy}|");

                    }
                }
                System.Console.Write("Enter the borrow ID: ");
                string borrowID = Console.ReadLine().ToUpper();
                foreach (BorrowDetails borrow in borrowsList)
                {
                    if (borrow.BorrowID.Equals(borrowID))
                    {
                        double fine = 0;
                        //add return date 15 days
                        DateTime returnDate = borrow.BorrowedDate.AddDays(15);
                        //difference between actual return date and today
                        TimeSpan timeSpan = DateTime.Now - returnDate;
                        if (timeSpan.Days > 0)
                        {
                            fine = timeSpan.Days;
                            //check balance of user
                            if (fine > currentLoggedInUser.WalletBalance)
                            {
                                System.Console.WriteLine("Insufficient balance. Please rechange and proceed");
                                return;
                            }
                            else
                            {
                                //deduct fine from user
                                currentLoggedInUser.DeductBalance(fine);
                                //change status to return
                                borrow.Status = Status.Returned;
                                //assign fine to paid
                                borrow.PaidFineAmount = fine;
                                System.Console.WriteLine("Book returned sucessfully");
                                //return book count
                                foreach (BookDetails book in booksList)
                                {
                                    if (book.BookID.Equals(borrow.BookID))
                                    {
                                        book.BookCount += borrow.BorrowBookCount;
                                        break;
                                    }
                                }
                                return;
                            }
                        }
                        else
                        {
                            borrow.Status = Status.Returned;
                            foreach (BookDetails book in booksList)
                            {
                                if (book.BookID.Equals(borrow.BookID))
                                {
                                    book.BookCount += borrow.BorrowBookCount;
                                    break;
                                }
                            }
                            System.Console.WriteLine("Book returned sucessfully");

                        }
                        return;
                    }
                }
            }



        }//end of return books

        //wallet recharge
        public static void WalletRecharge()
        {
            Console.WriteLine("******** Wallet Recharge ********");
            //ask user to recharge
            System.Console.Write("Do you want to recharge(yes/no): ");
            if (Console.ReadLine() == "yes")
            {
                System.Console.Write("Enter the amount to recharge: ");
                double walletBalance;
                bool iswalletBalancevalid = double.TryParse(Console.ReadLine(), out walletBalance);
                while (!iswalletBalancevalid && walletBalance > 0)
                {
                    Console.WriteLine("Provide valid amount");
                    Console.Write("Enter the amount to recharge: ");
                    iswalletBalancevalid = double.TryParse(Console.ReadLine(), out walletBalance);
                }
                //add amount to user
                System.Console.WriteLine($"Recharged sucessfully , your current balance - {currentLoggedInUser.WalletRecharge(walletBalance)}");
            }
            else
            {
                return;
            }
        }//end of wallet recharge


        //Default data
        public static void DefaultData()
        {
            UserDetails user1 = new UserDetails("Ravichandran", Gender.Male, Department.EEE, "9938388333", "ravi@gmail.com", 100);
            UserDetails user2 = new UserDetails("Priyadharshini", Gender.Female, Department.CSE, "99444444455", "priya@gmail.com", 150);

            usersList.AddRange(new List<UserDetails> { user1, user2 });

            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            BookDetails book2 = new BookDetails("HTML", "Author2", 5);
            BookDetails book3 = new BookDetails("CSS", "Author1", 3);
            BookDetails book4 = new BookDetails("JS", "Author1", 3);
            BookDetails book5 = new BookDetails("TS", "Author2", 2);

            booksList.AddRange(new List<BookDetails> { book1, book2, book3, book4, book5 });

            BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", new DateTime(2023, 09, 10), 2, Status.Borrowed, 0);
            BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", new DateTime(2023, 09, 12), 1, Status.Borrowed, 0);
            BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", new DateTime(2023, 09, 14), 1, Status.Returned, 16);
            BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", new DateTime(2023, 09, 11), 2, Status.Borrowed, 0);
            BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", new DateTime(2023, 09, 09), 1, Status.Returned, 20);

            borrowsList.AddRange(new List<BorrowDetails> { borrow1, borrow2, borrow3, borrow4, borrow5 });

        }//end of Default data

    }
}