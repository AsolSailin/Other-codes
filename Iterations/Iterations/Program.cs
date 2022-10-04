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
            int n = 4;
            double e = 0.001;
            double[,] a =
            {
                { -6.32, 4.51, -3.84, -7.38, -6.56 },
                { 4.22, -4.13, -4.16, -1.93, 6.36 },
                { 1.90, -2.56, -3.94, -1.61, -8.84 },
                { 7.29, -1.49, 1.79, 6.11, 8.00 },
                { -0.70, -2.39, -4.08, -6.90, 1.65 }
            };

            double[] y = new double[n];
            y = Colculate(n, e, a, y);

            foreach(var yn in y)
            {
                Console.WriteLine();
            }
        }

        static double[] Colculate(int n, double e, double[,] matrix, double[] y)
        {
            double[] x = new double[n];
            double d;
            if (GetConvergence(n, matrix))
            {
                for (int i = 0; i < n; i++)
                {
                    x[i] = matrix[i, n + 1];
                }

                d = 0;

                for (int i = 0; i < n; i++)
                {
                    d = d + Math.Pow((y[i] - x[i]), 2);

                    for (int j = 0; j < n; j++)
                    {
                        y[i] = y[i] + matrix[i, j] * x[j];
                    }

                    y[i] = matrix[i, n + 1];
                }

                d = Math.Sqrt(d);

                while (d > e)
                {
                    for (int i = 0; i < n; i++)
                    {
                        x[i] = y[i];
                    }

                    d = 0;

                    for (int i = 0; i < n; i++)
                    {
                        d = d + Math.Pow((y[i] - x[i]), 2);

                        for (int j = 0; j < n; j++)
                        {
                            y[i] = y[i] + matrix[i, j] * x[j];
                        }

                        y[i] = matrix[i, n + 1];
                    }

                    d = Math.Sqrt(d);
                }
            }

            return y;
        }

        static bool GetConvergence(int n, double[,] matrix)
        {
            bool b = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                }
            }
            return b;
        }
    }
}