using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public enum DoseNumber { one, two, three }
    public class Vaccination
    {
        /*
            •	VaccinationID (Auto increment – VID3001)
            •	Registration Number (Beneficiary Reg. num)
            •	VaccineID
            •	DoseNumber – (1,2,3)
            •	Vaccinated Date (DateTime.Now)
        */

        //field
        private static int s_vaccinationID = 3000;

        //auto property
        public string VaccinationID { get; }
        public string RegistrationNumber { get; set; }
        public string VaccineID { get; set; }
        public DoseNumber DoseNumber { get; set; }
        public DateTime VaccinatedDate { get; set; }
        
        //constructor
        public Vaccination(string registrationNumber, string vaccineID, DoseNumber doseNumber, DateTime vaccinatedDate)
        {
            s_vaccinationID++;
            VaccinationID = "VID" + s_vaccinationID;

            RegistrationNumber = registrationNumber;
            VaccineID = vaccineID;
            DoseNumber = doseNumber;
            VaccinatedDate = vaccinatedDate;
        }

        public Vaccination()
        {
            
        }


    }
}