using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LB5.Numbers
{
    internal class HEXNumber : INumber
    {
        private string _hex;
        public int initRank { get; set; }
        public int finalRank { get; set; }

        public HEXNumber(string hex)
        {
            if (!IsHexadecimalNumber(hex))
            {
                Console.WriteLine("Неверный формат числа");
                return;
            }
            _hex = hex;
            initRank = hex.Length;
        }

        private bool IsHexadecimalNumber(string number)
        {
            foreach (char digitChar in number)
            {
                if (!char.IsDigit(digitChar) && !(digitChar >= 'A' && digitChar <= 'F')
                && !(digitChar >= 'a' && digitChar <= 'f'))
                {
                    return false;
                }
            }
            return true;
        }

        public string ConvertToBinary()
        {
            string binary = Convert.ToString(Convert.ToInt32(_hex, 16), 2);
            finalRank = binary.Length;
            return binary;
        }

        public void Print()
        {
            Console.WriteLine($"Шестнадцатиричное число число {_hex}, конвертация в двоичную с.ч.: {ConvertToBinary()}");
            Console.WriteLine($"Число разрядов исходного числа: {initRank}, число разрядов после перевода в двоичную с.ч.: {finalRank}");
        }
    }
}
