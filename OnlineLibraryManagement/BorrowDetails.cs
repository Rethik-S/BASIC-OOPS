using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    //enum
    public enum Status { Default, Borrowed, Returned }
    public class BorrowDetails
    {
        //field
        private static int s_borrowID = 2000;

        //Auto property
        public string BorrowID { get; }//read only property
        public string BookID { get; set; }
        public string UserID { get; set; }
        public DateTime BorrowedDate { get; set; }
        public int BorrowBookCount { get; set; }
        public Status Status { get; set; }
        public double PaidFineAmount { get; set; }

        //Constructor

        public BorrowDetails(string bookID, string userID, DateTime borrowedDate, int borrowBookCount, Status status, double paidFineAmount)
        {
            //Auto Incrementation
            s_borrowID++;
            BorrowID = "LB" + s_borrowID;

            BookID = bookID;
            UserID = userID;
            BorrowedDate = borrowedDate;
            BorrowBookCount = borrowBookCount;
            Status = status;
            PaidFineAmount = paidFineAmount;
        }




    }
}