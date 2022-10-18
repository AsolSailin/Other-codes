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
            int n = 5;
            // a) 1.02
            // б) 0.65
            // в) 1.28
            double pointX = 1.02;
            double[] x = new double[5] { 0.27, 0.93, 1.46, 2.11, 2.87 };
            double[] y = new double[5] { 2.60, 2.43, 2.06, 0.25, -2.60 };
            Console.WriteLine($"Ответ: {Calculate(n, pointX, x, y)}");
        }

        static double Calculate(int n, double pointX, double[] x, double[] y)
        {
            double l = 0;

            for (int i = 0; i < n; i++)
            {
                var p = y[i];

                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        p = p * (pointX - x[j]) / (x[i] - x[j]);
                    }
                }

                l += p;
            }

            return l;
        }
    }
}