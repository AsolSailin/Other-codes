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
            Console.WriteLine($"Введите a: "); // 0,5
            var a = double.Parse(Console.ReadLine());
            Console.WriteLine($"Введите b: "); // 1
            var b = double.Parse(Console.ReadLine());
            Console.WriteLine($"Введите точность e: ");
            var e = double.Parse(Console.ReadLine()); // 0,000001
            Console.WriteLine($"---");

            // 1-3 задание: 2 * x - 5 * Math.Log(x) - 3
            Func<double, double> func = x => 2 * x - 5 * Math.Log(x) - 3;
            Func<double, double> func1 = f => 2 - 5/f;
            
            Console.WriteLine($"Ответ методом касательных: " +
                $"{TangentMethod(a, b, e, func, func1)}");
            Console.WriteLine($"Ответ методом хорд: " +
                $"{СhordMethod(a, b, e, func)}");
            Console.WriteLine($"Ответ комбинированным методом: " +
                $"{СombinedMethod(a, b, e, func, func1)}");
        }

        static double TangentMethod (double a, double b, double e, 
            Func<double, double> func, Func<double, double> func1)
        {
            double h, x, y, c, x0, x1;

            h = (b - a) / 100;
            x = func(a);
            y = func(a + 2 * h) - 2 * func(a + h) + func(a);

            if (x * y > 0)
            {
                x0 = a;
            }
            else
            {
                x0 = b;
            }

            x1 = x0 - func(x0) / func1(x0);

            while (Math.Abs(x1 - x0) > e)
            {
                x0 = x1;
                x1 = x0 - func(x0) / func1(x0);
            }

            return x1;
        }

        static double СhordMethod(double a, double b, double e, 
            Func<double, double> func)
        {
            double h, x, y, c, x0, x1;

            h = (b - a) / 100;
            x = func(a);
            y = func(a + 2 * h) - 2 * func(a + h) + func(a);

            if (x * y < 0)
            {
                x0 = a;
                c = b;
            }
            else
            {
                x0 = b;
                c = a;
            }

            x1 = (x0 * func(c) - c * func(x0)) / (func(c) - func(x0));

            while (Math.Abs(x1 - x0) > e)
            {
                x0 = x1;
                x1 = (x0 * func(c) - c * func(x0)) / (func(c) - func(x0));
            }

            return x1;
        }

        static double СombinedMethod(double a, double b, double e,
            Func<double, double> func, Func<double, double> func1)
        {
            double h, x, y, c, x0, x1, x2, x3;

            h = (b - a) / 100;
            x = func(a);
            y = func(a + 2 * h) - 2 * func(a + h) + func(a);

            if (x * y < 0)
            {
                x0 = a;
                x1 = b;
                c = b;
            }
            else
            {
                x0 = b;
                x1 = a;
                c = a;
            }

            x2 = (x0 * func(c) - c * func(x0)) / (func(c) - func(x0));
            x3 = x1 - func(x1) / func1(x1);

            while (Math.Abs(x3 - x2) > 2 * e)
            {
                x0 = x2;
                x1 = x3;
                x2 = (x0 * func(c) - c * func(x0)) / (func(c) - func(x0));
                x3 = x1 - func(x1) / func1(x1);
            }

            x = (x2 + x3) / 2;

            return x;
        }
    }
}
