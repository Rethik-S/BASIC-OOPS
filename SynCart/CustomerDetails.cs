using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class CustomerDetails
    {
        //field
        private static int s_customerId = 1000;

        //Auto property
        public string CustomerId { get; }
        public string Name { get; set; }
        public string City { get; set; }
        public long MobileNumber { get; set; }
        public double WalletBalance { get; set; }
        public string EmailId { get; set; }

        //constructor
        public CustomerDetails(string name, string city, long mobileNumber, double walletBalance, string emailId)
        {
            s_customerId++;
            CustomerId = "CID" + s_customerId;

            Name = name;
            City = city;
            MobileNumber = mobileNumber;
            WalletBalance = walletBalance;
            EmailId = emailId;
        }
        
        //Methods
        public double WalletRecharge(double amount)
        {
            WalletBalance += amount;
            return WalletBalance;
        }
    }
}