using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods
{
    public class Program
    {
        static void Main(string[] args)
        {
            double x = 1, y = 2, h = 0.1, b = 2;
            Func<double, double, double> func = (x, y) => x + y / x;

            while (x <= b)
            {
                y += h * func(x, y);
                x += h;
                Console.WriteLine(y);
            }
        }
    }
}