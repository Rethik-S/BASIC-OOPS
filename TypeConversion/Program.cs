using System;
namespace TypeConversion;
class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number 1:");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Enter a number 2:");
        int num2 = int.Parse(Console.ReadLine());
        Console.WriteLine(num1+num2);

        Console.Write("Enter a double num:");
        double dNum = int.Parse(Console.ReadLine());
        Console.WriteLine(dNum);
        Console.ReadKey();
    }
}