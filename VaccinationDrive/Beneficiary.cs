using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    //enum
    public enum Gender { Select, Male, Female, Others }
    public class Beneficiary
    {
        /*
            a.  Registration Number (Auto Incremented BID1001)
            b.	Name
            c.	Age
            d.	Gender (Enum [Male, Female, Others])
            e.	Mobile Number
            f.	City
        */

        //field
        private static int s_BeneficiaryID = 1000;


        //Auto properties
        public string BeneficiaryID { get; }//read only property
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string MobileNumber { get; set; }
        public string City { get; set; }

        //Constructor
        public Beneficiary(string name, int age, Gender gender, string mobileNumber, string city)
        {
            //Auto Incrementation
            s_BeneficiaryID++;
            BeneficiaryID = "BID" + s_BeneficiaryID;

            Name = name;
            Age = age;
            Gender = gender;
            MobileNumber = mobileNumber;
            City = city;
        }

    }
}