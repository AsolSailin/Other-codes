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
            double e = 0.001;

            int n = 3;
            double[,] a =
            {
                { 16.63, -0.24, -6.10, 7.29 },
                { -3.45, -23.13, 1.11, -3.41 },
                { 3.76, -8.72, -27.01, -8.19 },
            };

            double[] x = new double[n];
            x = Colculate(n, e, a, x);

            if (x.Length != 0)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    Console.WriteLine(x[i] + " ");
                }
            }
        }

        static double[] Colculate(int n, double e, double[,] matrix, double[] x)
        {
            double[] y = new double[n];
            double d = 0;

            d = GetConvergence(n, matrix, d); 

            if (Math.Sqrt(d) < 1)
            {
                d = 2 * e;

                while(d > e)
                {
                    d = 0;

                    for (int i = 0; i < n; i++)
                    {
                        y[i] = matrix[i, n];
                        
                        for (int j = 0; j < n; j++)
                        {
                            y[i] += matrix[i, j] * x[j];
                        }

                        d += Math.Pow((y[i] - x[i]), 2);
                        x[i] = y[i];
                    }

                    d = Math.Sqrt(d);
                }
            }

            return x;
        }

        static double GetConvergence(int n, double[,] matrix, double d)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
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