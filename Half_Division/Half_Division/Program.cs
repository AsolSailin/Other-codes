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
            Console.WriteLine($"Данные для метода половинного деления: ");
            Console.WriteLine($"---");
            Console.WriteLine($"Введите a: ");
            var a = double.Parse(Console.ReadLine());
            Console.WriteLine($"Введите b: ");
            var b = double.Parse(Console.ReadLine());
            Console.WriteLine($"Введите точность e: ");
            var e = double.Parse(Console.ReadLine());
            Console.WriteLine($"---");

            // 1 задание: x * Math.Sin(x) - 1
            // 6 задание: 8 * Math.Cos(x) - x - 6
            Console.WriteLine($"Ответ методом половинного деления: " +
                $"{Calculate(a, b, e, x => 8 * Math.Cos(x) - x - 6)}");
        }

        static double Calculate(double a, double b, double e, Func<double, double> func)
        {
            double c;

            while (b - a > 2 * e)
            {
                c = (a + b) / 2;

                if (func(a) * func(c) < 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }
            }

            return (a + b) / 2;
        }
    }
}