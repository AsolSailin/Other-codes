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
            double a = 1, b = 2, e = 0.001, 
                i0 = 0, i1 = double.PositiveInfinity, i2 = 0, 
                h = 0, x = 0, x1 = 0, x2 = 0, result = 0;
            int n = 0;
            Func<double, double> func = x => 1 / (Math.Pow(x,6) * (1 + Math.Pow(x, 2)));
            
            Console.WriteLine($"Левый прямоугольник: {LeftRectangle(a, b, e, n, func, i0, i1, i2, h, x, x1, x2, result)}");
        }

        public static double LeftRectangle(double a, double b, double e, int n, Func<double, double> func, 
            double i0, double i1, double i2, double h, double x, double x1, double x2, double result)
        {
            while ((i1 - i0) > e)
            {
                i0 = i1;
                h = (b - a) / n;
                i1 = 0;

                for (int i = 0; i < n; i++)
                {
                    x = a + i * h;
                    x1 = x + (h / 2) - (h / (2 * Math.Sqrt(3)));
                    x2 = x + (h / 2) + (h / (2 * Math.Sqrt(3)));
                    i1 += func(x1);
                    i2 += func(x2);
                }

                result = i1 + i2;
                result *= h / 2;
            }

            return result;
        }
    }
}