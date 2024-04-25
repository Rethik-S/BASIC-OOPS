using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountOpening2
{
    public class Account
    {
        private static int s_customerId = 1000;


        public string CustomerId { get; }
        public string Name { get; set; }
        private double Balance { get; set; }
        public Gender Gender { get; set; }
        public long Phone { get; set; }
        public string MailId { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Account(string name, double balance, Gender gender, long phone, string mailId, DateTime dateOfBirth)
        {
            s_customerId++;
            CustomerId = "HDFC" + s_customerId;

            Name = name;
            Balance = balance;
            Gender = gender;
            Phone = phone;
            MailId = mailId;
            DateOfBirth = dateOfBirth;
        }
        public double Deposit(double amount)
        {
            Balance += amount;
            return Balance;
        }
        public double Withdraw(double amount)
        {
            Balance -= amount;
            return Balance;
        }
        public double CheckBalance()
        {
            return Balance;
        }

    }
}