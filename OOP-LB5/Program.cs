// See https://aka.ms/new-console-template for more information
using OOP_LB5.Numbers;
using System.Security.Cryptography;

namespace OOP_LB5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstTask();
        }

        public static void FirstTask()
        {
            INumber[] numbers = new INumber[6];

            numbers[0] = new DecimalNumber(21);
            numbers[1] = new DecimalNumber(1245);
            numbers[2] = new OctalNumber(64);
            numbers[3] = new OctalNumber(777);
            numbers[4] = new HEXNumber("A1");
            numbers[5] = new HEXNumber("FF");

            foreach (INumber number in numbers)
            {
                number.ConvertToBinary();
                number.Print();
                Console.WriteLine();
            }
        }
    }
}