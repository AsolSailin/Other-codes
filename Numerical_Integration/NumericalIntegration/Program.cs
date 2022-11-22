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
            //Func<double, double> func = x => 0.43 * Math.Pow(2.72, Math.Sin(x));
            double i0 = 0;
            double i1 = double.PositiveInfinity;
            int n = 50;
            double h = 0, x1 = 0, x2 = 0;

            Console.WriteLine($"Левый прямоугольник: {LeftRectangle(a, b, e, func, i0, i1, n, h, x1)}");
            Console.WriteLine($"Средний прямоугольник: {RightRectangle(a, b, e, func, i0, i1, n, h, x1)}");
            Console.WriteLine($"Правый прямоугольник: {MiddleRectangle(a, b, e, func, i0, i1, n, h, x1)}");
            Console.WriteLine($"Трапеция: {Trapezoid(a, b, e, func, i0, i1, n, h, x1)}");
            Console.WriteLine($"Симпсон: {Simpson(a, b, e, func, i0, i1, n, h, x1, x2)}");
        }

        public static double LeftRectangle(double a, double b, double e, Func<double, double> func, 
            double i0, double i1, int n, double h, double x)
        {
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

        public static double RightRectangle(double a, double b, double e, Func<double, double> func, 
            double i0, double i1, int n, double h, double x)
        {
            while ((i1 - i0) > e)
            {
                n *= 2;
                i0 = i1;
                h = (b - a) / n;
                i1 = 0;

                for (int i = 0; i < n; i++)
                {
                    x = a + (i + 1) * h;
                    i1 += func(x);
                }

                i1 *= h;
            }

            return i1;
        }
        
        public static double MiddleRectangle(double a, double b, double e, Func<double, double> func, 
            double i0, double i1, int n, double h, double x)
        {
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

        public static double Trapezoid(double a, double b, double e, Func<double, double> func, 
            double i0, double i1, int n, double h, double x)
        {
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

                i1 += (func(a) + func(a + (n - 1) * h)) / 2;
                i1 *= h;
            }

            return i1;
        }

        public static double Simpson(double a, double b, double e, Func<double, double> func, 
            double i0, double i1, int n, double h, double x1, double x2)
        {
            n--;
            while ((i1 - i0) > e)
            {
                n *= 2;
                i0 = i1;
                h = (b - a) / n;
                i1 = 0;

                for (int i = 0; i < n / 2; i++)
                {
                    x1 = a + (2 * i - 1) * h;
                    x2 = a + 2 * i * h;
                    i1 += 2 * func(x1) + func(x2);
                }

                i1 += (func(a) + func(a + (n - 1) * h)) / 2;
                i1 *= h * 2 / 3;
            }

            return i1;
        }
    }
}