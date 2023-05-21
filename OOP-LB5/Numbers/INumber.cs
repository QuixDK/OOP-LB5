using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LB5.Numbers
{
    internal interface INumber
    {
        int initRank { get; }
        int finalRank { get; }
        void Print();
        string ConvertToBinary();
    }
}
