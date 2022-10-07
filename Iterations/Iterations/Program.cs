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
            int n = 3;
            double e = 0.001;
            double[,] a =
            {
                { 16.63, -0.24, -6.10, 7.29 },
                { -3.45, -23.13, 1.11, -3.41 },
                { 3.76, -8.72, -27.01, -8.19 },
            };

            double[] y = new double[n];
            y = Colculate(n, e, a, y);

            for (int i = 0; i < y.Length; i++)
            {
                Console.WriteLine(y[i] + " ");
            }
        }

        static double[] Colculate(int n, double e, double[,] matrix, double[] y)
        {
            double[] x = new double[n];
            double d  = 0;

            if (Math.Sqrt(GetConvergence(n, matrix, d)) < 1)
            {
                for (int i = 0; i < n; i++)
                {
                    x[i] = matrix[i, n];
                }

                d = 0;

                for (int i = 0; i < n; i++)
                {
                    y[i] = matrix[i, n];

                    for (int j = 0; j < n; j++)
                    {
                        y[i] += matrix[i, j] * x[j];
                    }

                    d += Math.Pow((y[i] - x[i]), 2);
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
                        y[i] = matrix[i, n];

                        for (int j = 0; j < n; j++)
                        {
                            y[i] += matrix[i, j] * x[j];
                        }

                        d = d + Math.Pow((y[i] - x[i]), 2);
                    }

                    d = Math.Sqrt(d);
                }
            }

            return y;
        }

        static double GetConvergence(int n, double[,] matrix, double d)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i != j)
                    {
                        matrix[i, j] = -matrix[i, j] / matrix[i, i];
                        d += Math.Pow(matrix[i, j], 2);
                    }
                }
                matrix[i, n] = matrix[i, n] / matrix[i, i];
                matrix[i, i] = 0;
            }
            return d;
        }
    }
}