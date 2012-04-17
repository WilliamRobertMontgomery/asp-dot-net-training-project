using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day3.Workshop.Matrix
{
	public class Matrix
	{
		private double[,] items;

		private int rows;
		private int columns;


		public int Rows
		{
			get { return rows; }
		}
		public int Columns
		{
			get { return columns; }
		}


		public Matrix(double[,] arr)
		{
			rows = arr.GetLength(0);
			columns = arr.GetLength(1);

			items = new double[rows, columns];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					items[i, j] = arr[i, j];
				}
			}
		}


		public double this[int index1, int index2]
		{
			get
			{
				CheckIndex(index1, index2);
				return items[index1, index2];
			}
			set
			{
				CheckIndex(index1, index2);
				items[index1, index2] = value;
			}
		}

		public bool CheckIndex(int index1, int index2)
		{
			if ((index1 < 0 || index1 >= rows) || (index1 < 0 || index1 >= rows))
			{
				throw new IndexOutOfRangeException("Index was outside the bounds of the matrix");
			}
			return true;
		}


		public static Matrix Add(Matrix a, Matrix b)
		{

			if (a.Rows != b.Rows || a.Columns != b.Columns)
			{
				return null;
			}

			Matrix resultMatrix = new Matrix(new double[a.Columns, a.Rows]);

			for (int i = 0; i < a.Rows; i++)
			{
				for (int j = 0; j < a.Columns; j++)
				{
					resultMatrix.items[i, j] = a.items[i, j] + b.items[i, j];
				}
			}
			return resultMatrix;
		}

		public static Matrix operator +(Matrix a, Matrix b)
		{
			return Add(a, b);
		}


		public static Matrix MultiplyByScalar(Matrix a, double b)
		{
			Matrix resultMatrix = new Matrix(new double[a.Columns, a.Rows]);

			for (int i = 0; i < a.Rows; i++)
			{
				for (int j = 0; j < a.Columns; j++)
				{
					resultMatrix.items[i, j] = a.items[i, j] * b;
				}
			}
			return resultMatrix;
		}

		public static Matrix operator *(Matrix a, double b)
		{
			return MultiplyByScalar(a, b);
		}

		public static Matrix operator *(double b, Matrix a)
		{
			return MultiplyByScalar(a, b);
		}



		public static Matrix Multiply(Matrix a, Matrix b)
		{
			if (a.Columns != b.Rows)
			{
				return null;
			}

			Matrix resultMatrix = new Matrix(new double[a.Rows, b.Columns]);

			for (int i = 0; i < a.Rows; i++)
			{
				for (int j = 0; j < b.Columns; j++)
				{
					resultMatrix.items[i, j] = 0;
					for (int k = 0; k < a.Columns; k++)
					{
						resultMatrix.items[i, j] += a.items[i, k] * b.items[k, j];
					}
				}
			}

			return resultMatrix;
		}

		public static Matrix operator *(Matrix a, Matrix b)
		{
			return Multiply(a, b);
		}


		public override bool Equals(object obj)
		{
			bool result = false; 

			Matrix other = obj as Matrix;

			if (other != null)
			{
				if (other.Rows == Rows && other.Columns == Columns)
				{
					result = true;
					for (int i = 0; i < Rows; i++)
					{
						for (int j = 0; j < Columns; j++)
						{
							if (items[i, j] != other.items[i, j])
							{
								result = false;
							}
						}
					}
				}
			}
			return result;
		}

		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}

		public static bool operator ==(Matrix a, Matrix b)
		{
			return Object.Equals(a, b);
		}

		public static bool operator !=(Matrix a, Matrix b)
		{
			return !Object.Equals(a, b);
		}


		public override string ToString()
		{
			StringBuilder str = new StringBuilder();

			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					str.AppendFormat("{0}\t", items[i, j]);
				}
				str.AppendFormat("\n");
			}

			return str.ToString();
		}

	}
}
