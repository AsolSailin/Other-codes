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
            double a = 0;
            double b = 1;
            double e = 0.001;
            Func<double, double> func = x => x / (1 + Math.Pow(x, 3));

            Console.WriteLine($"Ответ: {LeftCalculate(a, b, e, func)}");
            Console.WriteLine($"Ответ: {RightCalculate(a, b, e, func)}");
            /*Console.WriteLine($"Ответ: {Calculate(a, b, e, func)}");
            Console.WriteLine($"Ответ: {Calculate(a, b, e, func)}");
            Console.WriteLine($"Ответ: {Calculate(a, b, e, func)}");*/
        }

        static double LeftCalculate(double a, double b, double e, Func<double, double> func)
        {
            double i0 = 0;
            double i1 = double.PositiveInfinity;
            int n = 5;
            double h, x;

            while ((i1 - i0) > e)
            {
                n *= 2;
                i0 = i1;
                h = (b - a) / n;
                i1 = 0;

                for (int i = 0; i < n; i++)
                {
                    x = a + i * h;
                    i1 += func(x);
                }

                i1 *= h;
            }

            return i1;
        }

        static double RightCalculate(double a, double b, double e, Func<double, double> func)
        {
            double i0 = 0;
            double i1 = double.PositiveInfinity;
            int n = 5;
            double h, x;

            while ((i1 - i0) > e)
            {
                n *= 2;
                i0 = i1;
                h = (b - a) / n;
                i1 = 0;

                for (int i = 0; i < n; i++)
                {
                    x = a + (i = 1) * h;
                    i1 += func(x);
                }

                i1 *= h;
            }

            return i1;
        }
        
        static double MiddleCalculate(double a, double b, double e, Func<double, double> func)
        {
            double i0 = 0;
            double i1 = double.PositiveInfinity;
            int n = 5;
            double h, x;

            while ((i1 - i0) > e)
            {
                n *= 2;
                i0 = i1;
                h = (b - a) / n;
                i1 = 0;

                for (int i = 0; i < n; i++)
                {
                    x = a + h / 2 + i * h;
                    i1 += func(x);
                }

                i1 *= h;
            }

            return i1;
        }
    }
}