using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public class Vaccine
    {
        //field
        private static int s_vaccineID = 2000;

        //Auto properties
        public string VaccineID { get; }//read only property
        public string VaccineName { get; set; }
        public int NoOfDoseAvailable { get; set; }

        //Constructor
        public Vaccine(string vaccineName, int noOfDoseAvailable)
        {
            //Auto incrementation
            s_vaccineID++;
            VaccineID="CID"+s_vaccineID;
            
            VaccineName = vaccineName;
            NoOfDoseAvailable = noOfDoseAvailable;
        }
    }
}