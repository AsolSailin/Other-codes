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
            int n = 2;
            double x;

            double[,] matrix = 
            {
                { 8.39, -8.99, -1.29, 8.86 },
                { -1.05, 1.89, 4.91, 4.20 },
                { -6.38, 8.36, 0.48, -5.06 }
            };

            for (int i = 0; i <= n; i++)
            {
                for (int j = n + 1; j >= i; j--)
                {
                    matrix[i, j] = matrix[i, j] / matrix[i,i];
                }

                for (int k = 0; k <= n; k++)
                {
                    if (k != i)
                    {
                        for (int j = n + 1; j >= 1; j--)
                        {
                            matrix[k, j] = matrix[k, j] - matrix[k, i] * matrix[i, j];
                        }
                    }
                }
            }

            for (int i = 0; i <= n; i++)
            {
                x = matrix[i, n + 1];
                Console.WriteLine(x);
            }
        }
    }
}