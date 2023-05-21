using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LB5.Numbers
{
    internal class OctalNumber : INumber
    {
        private int _octalNumber;
        public int initRank { get; set; }
        public int finalRank { get; set; }

        public OctalNumber(int octalNumber)
        {
            if (!isOctalNumber(octalNumber))
            {
                Console.WriteLine("не восьмеричнаое число");
            }
            _octalNumber = octalNumber;
            initRank = octalNumber.ToString().Length;
        }

        private bool isOctalNumber(int number)
        {
            while (number > 0)
            {
                if (number % 10 >= 8)
                {
                    return false;
                }
                number /= 10;
            }

            return true;
        }

        public string ConvertToBinary()
        {
            string binary = Convert.ToString(Convert.ToInt32(_octalNumber.ToString(), 8), 2);
            finalRank = binary.Length;
            return binary;
        }

        public void Print()
        {
            Console.WriteLine($"Восьмеричное число {_octalNumber}, конвертация в двоичную с.ч.: {ConvertToBinary()}");
            Console.WriteLine($"Число разрядов исходного числа: {initRank}, число разрядов после перевода в двоичную с.ч.: {finalRank}");
        }
    }
}
