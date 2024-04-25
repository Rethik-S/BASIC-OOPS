using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBillCalculation
{
    public class Meter
    {
        private static int s_meterId=1000;


        public string MeterId { get; }
        public string UserName { get; set; }
        public long PhoneNumber { get; set; }
        public string MailId { get; set; }
        public double Units { get; set; }

        public Meter(string userName, long phoneNumber, string mailId)
        {
            s_meterId++;
            MeterId="EB"+s_meterId;

            UserName = userName;
            PhoneNumber = phoneNumber;
            MailId = mailId;
        }
        public double CalculateAmount(double unitsUsed)
        {
            Units += unitsUsed;
            double amount = 5*Units;
            return amount;

        }
    }
}