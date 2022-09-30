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
            /*int n = 5;
            double[,] a =
            {
                { 5.38, 7.33, -0.24, -0.49, -8.41, 4.27 },
                { 2.81, -4.69, -6.13, -3.05, -5.19, 5.77 },
                { 7.60, 4.78, 8.59, 0.98, 6.72, 3.70 },
                { -8.44, -8.53, 5.76, -8.34, 4.96, 5.95 },
                { 0.61, 4.63, -4.04, 1.72, 3.61, -6.77 }
            };*/

            int n = 4;
            double[,] a =
            {
                { -6.32, 4.51, -3.84, -7.38, -6.56 },
                { 4.22, -4.13, -4.16, -1.93, 6.36 },
                { 1.90, -2.56, -3.94, -1.61, -8.84 },
                { 7.29, -1.49, 1.79, 6.11, 8.00 },
                { -0.70, -2.39, -4.08, -6.90, 1.65 }
            };

            double[,] matrix = Calculate(n, a);

            for (int i = 0; i <= n - 1; i++)
            {
                Console.WriteLine(matrix[i, n]);
            }
        }

        static double[,] Calculate(int n, double[,] matrix)
        {
            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = n; j >= i; j--)
                {
                    matrix[i, j] = matrix[i, j] / matrix[i, i];
                }

                for (int k = 0; k <= n - 1; k++)
                {
                    if (k != i)
                    {
                        for (int j = n; j >= 1; j--)
                        {
                            matrix[k, j] = matrix[k, j] - matrix[k, i] * matrix[i, j];
                        }
                    }
                }
            }
            return matrix;
        }
    }
}