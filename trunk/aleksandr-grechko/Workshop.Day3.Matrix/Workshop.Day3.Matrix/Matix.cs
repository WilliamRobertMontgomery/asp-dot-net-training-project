using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop.Day3.Matrix
{
	public class Matrix
	{
		private readonly int rows;
		private readonly int columns;
		private double[,] matrix;

		public int Rows
		{
			get { return rows; }
		}

		public int Columns
		{
			get { return columns; }
		}

		public double this[int i, int j]
		{
			get
			{
				CheckIndexes(i, j);
				return matrix[i - 1, j - 1];
			}
			set
			{
				CheckIndexes(i, j);
				matrix[i - 1, j - 1] = value;
			}
		}

		private void CheckIndexes(int i, int j)
		{
			if ((i < 1) || (i > rows) || (j < 1) || (j > columns))
			{
				throw new System.ArgumentException("Index is out of range", "");
			}
		}

		public Matrix(int rows, int columns, double defaultValue = 0)
		{
			this.rows = rows;
			this.columns = columns;
			matrix = new double[rows, columns];
			if (defaultValue != 0)
			{
				for (int i = 0; i < rows; i++)
					for (int j = 0; j < columns; j++)
					{
						matrix[i, j] = defaultValue;
					};
			}
		}

		public Matrix(double[,] array)
		{
			rows = array.GetLength(0);
			columns = array.GetLength(1);
			matrix = new double[rows, columns];
			for (int i = 0; i < rows; i++)
				for (int j = 0; j < columns; j++)
				{
					matrix[i, j] = array[i, j];
				};
		}

		public override string ToString()
		{
			StringBuilder strBuilder = new StringBuilder();
			for (int i = 0; i < rows; i++)
			{
				strBuilder.Append("| ");
				for (int j = 0; j < columns; j++)
				{
					strBuilder.AppendFormat("{0,8} ", matrix[i, j]);
				};
				strBuilder.AppendLine("       |");
			};
			return strBuilder.ToString();
		}

		public override bool Equals(Object obj)
		{
			if (obj == null || !(obj is Matrix))
			{
				return false;
			}
			return MatrixCompare(this, obj as Matrix);
		}

		public static bool operator ==(Matrix a, Matrix b)
		{
			if (((object)a == null) ^ ((object)b == null))
			{
				return false;
			}
			return MatrixCompare(a, b);
		}

		private static bool MatrixCompare(Matrix a, Matrix b)
		{
			if (Object.ReferenceEquals(a, b))
			{
				return true;
			}
			if (a.rows != b.rows || a.columns != b.columns)
			{
				return false;
			}
			for (int i = 0; i < a.rows; i++)
				for (int j = 0; j < a.columns; j++)
					if (a.matrix[i, j] != b.matrix[i, j])
					{
						// Here would be more correct to check  abs(x-y) < epsilon*abs(max(x,y))
						// where epsilon is relative error
						return false;
					};
			return true;
		}

		public static bool operator !=(Matrix a, Matrix b)
		{
			return !(a == b);
		}

		private delegate double MatrixElementOperation(int i, int j);

		private static Matrix MatrixOperation(int resultRows, int resultColumns, MatrixElementOperation f)
		{
			Matrix result = new Matrix(resultRows, resultColumns);
			for (int i = 0; i < result.rows; i++)
				for (int j = 0; j < result.columns; j++)
				{
					result.matrix[i, j] = f(i, j);
				};
			return result;
		}

		private static void CheckArguments(params Matrix[] matrixList)
		{
			foreach (Matrix item in matrixList)
				if ((object)item == null)
				{
					throw new System.ArgumentException("Parameter cannot be null", "");
				};
		}

		public static Matrix operator +(Matrix a, Matrix b)
		{
			CheckArguments(a, b);
			if (a.rows != b.rows || a.columns != b.columns)
			{
				throw new System.InvalidOperationException("Matrixes should be the identical size");
			}
			return MatrixOperation(a.rows, a.columns, (int i, int j) => a.matrix[i, j] + b.matrix[i, j]);
		}

		public static Matrix operator *(double k, Matrix a)
		{
			CheckArguments(a);
			return MatrixOperation(a.rows, a.columns, (int i, int j) => k * a.matrix[i, j]);
		}

		public static Matrix operator *(Matrix a, double k)
		{
			return k * a;
		}

		public static Matrix operator *(Matrix a, Matrix b)
		{
			CheckArguments(a, b);
			if (a.columns != b.rows)
			{
				throw new System.InvalidOperationException("The number of columns of the left matrix should be the equal to the number of rows of the right matrix");
			}
			return MatrixOperation(a.rows, b.columns, (int i, int j) => 
				{ 
					double x = 0; 
					for (int k = 0; k < a.columns; k++) 
						x += a.matrix[i, k] * b.matrix[k, j]; 
					return x; 
				});
		}

		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}

	}

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
