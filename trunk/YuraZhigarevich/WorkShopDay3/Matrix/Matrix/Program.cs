using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The program is implemented for square matrices!");
            Console.Write("Enter the order of the matrix:  n= ");
            string s = Console.ReadLine();
            Int16 n = Convert.ToInt16(s);

            int[,] a = new int[n, n];
            Random rnd = new Random();
            Console.WriteLine("The first matrix:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = rnd.Next(1, 9);
                    Console.Write(" {0}", a[i, j]);
                }
                Console.WriteLine();
            }
            Thread.Sleep(1000);
            int[,] b = new int[n, n];
            Random rnd1 = new Random();
            Console.WriteLine("The second matrix:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    b[i, j] = rnd1.Next(2, 8);
                    Console.Write(" {0}", b[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Addition of matrices: ");
            int[,] c = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                    Console.Write(" {0}", c[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Multiplication by a scalar: ");
            int[,] d = new int[n, n];
            Console.Write("Enter the number:  x= ");
            string ss = Console.ReadLine();
            Int16 x = Convert.ToInt16(ss);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    d[i, j] = a[i, j]*x;
                    Console.Write(" {0}", d[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Multiplication of matrices: ");
            int[,] e = new int[n, n];
            int sum;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum=0;
                    for (int k = 0; k < n; k++)
                    {
                    sum=sum+a[i,k]*b[k,j];
                    }
                    e[i, j] = sum;
                    Console.Write(" {0}", e[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
