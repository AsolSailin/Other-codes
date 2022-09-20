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
            Console.WriteLine($"Данные для метода простых итераций: ");
            Console.WriteLine($"Введите x0: ");
            var x0 = double.Parse(Console.ReadLine());
            Console.WriteLine($"Введите точность e: ");
            var e = double.Parse(Console.ReadLine());
            Console.WriteLine($"---");

            // 1 задание: x * Math.Sin(x) - 1
            // 6 задание: x + 
            Console.WriteLine($"Ответ методом простых итераций: " +
                $"{Calculate(x0, e, x => x + 0.1 * (8 * Math.Cos(x) - x - 6))}");
        }

        static double Calculate(double x0, double e, Func<double, double> func)
        {
            double x1;
            x1 = func(x0);

            while (Math.Abs(x1 - x0) > e)
            {
                x0 = x1;
                x1 = func(x0);
            }

            return x1;
        }
    }
}