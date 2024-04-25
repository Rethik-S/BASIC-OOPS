using System;
namespace VaccinationDrive;
class Program
{
    public static void Main(string[] args)
    {
        //default data calling
        Operations.AddDefaultData();

        //calling main menu
        Operations.MainMenu();
    }
}