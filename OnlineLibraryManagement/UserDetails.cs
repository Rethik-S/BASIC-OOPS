using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    //enum
    public enum Gender{Select,Male,Female,Other}
    public enum Department{Select,ECE,EEE,CSE}
    public class UserDetails
    {
        //field
        /// <summary>
        /// Static field s_userID used to autoincrement user Id of the instance of <see cref="UserDetails"/>
        /// </summary>
        private static int s_userID=3000;


        //Auto property
        public string UserID { get; }//read only property
        public string UserName { get; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public string MobileNumber { get; set; }
        public string MailID { get; set; }
        public double WalletBalance { get; set; }

        //constructor
        public UserDetails(string userName, Gender gender, Department department, string mobileNumber, string mailID, double walletBalance)
        {
            //auto incrementation
            s_userID++;
            UserID="SF"+s_userID;

            UserName = userName;
            Gender = gender;
            Department = department;
            MobileNumber = mobileNumber;
            MailID = mailID;
            WalletBalance = walletBalance;
        }

        //Methods
        public double WalletRecharge(double amount)
        {
            WalletBalance+=amount;
            return WalletBalance;
        }

        public double DeductBalance(double amount)
        {
            WalletBalance-=amount;
            return WalletBalance;
        }
    }
}