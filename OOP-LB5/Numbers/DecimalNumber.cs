using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LB5.Numbers
{
    internal class DecimalNumber : INumber
    {
        private int _number;
        public int initRank { get; set; }
        public int finalRank { get; set; }


        public DecimalNumber(int number)
        {
            _number = number;
            initRank = number.ToString().Length;
        }

        public string ConvertToBinary()
        {
            string binary = Convert.ToString(_number, 2);
            finalRank = binary.Length;
            return binary;
        }

        public void Print()
        {
            Console.WriteLine($"Десятичное число {_number}, конвертация в двоичную с.ч.: {ConvertToBinary()}");
            Console.WriteLine($"Число разрядов исходного числа: {initRank}, число разрядов после перевода в двоичную с.ч.: {finalRank}");
        }
    }
}
