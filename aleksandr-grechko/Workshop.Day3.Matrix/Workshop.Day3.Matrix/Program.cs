using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop.Day3.Matrix
{
	class Program
	{
		static void Main(string[] args)
		{
			Matrix m1 = new Matrix(5, 5, 10);

			Console.WriteLine(m1);

			Console.WriteLine(new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }));

			Console.Read();
		}
	}
}
