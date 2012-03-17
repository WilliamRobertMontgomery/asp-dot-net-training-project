using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Calculator.Matrices
{
	/// <summary>
	/// The class a matrix.
	/// </summary>
	public class Matrix<T>
	{
		int rowCount;
		int columnCount;
		T[,] array;

		/// <summary>
		/// Gets or sets of elements in the matrix.
		/// </summary>
		public T[,] Array
		{
			get { return array; }
			set { array = value; }
		}

		/// <summary>
		/// Get number of rows in the matrix.
		/// </summary>
		public int RowCount
		{
			get { return rowCount; }
		}

		/// <summary>
		/// Get number of columns in the matrix
		/// </summary>
		public int ColumnCount
		{
			get { return columnCount; }
		}

		public Matrix(int rowCount, int columnCount)
		{
			if (rowCount < 0)
			{
				throw new ArgumentOutOfRangeException("rowCount");
			}
			if (columnCount < 0)
			{
				throw new ArgumentOutOfRangeException("columnCount");
			}

			this.array = new T[rowCount, columnCount];
			this.rowCount = rowCount;
			this.columnCount = columnCount;
		}

		public Matrix(int rowCount, int columnCount, T[,] array)
		{
			if (rowCount < 0)
			{
				throw new ArgumentOutOfRangeException("rowCount");
			}
			if (columnCount < 0)
			{
				throw new ArgumentOutOfRangeException("columnCount");
			}

			this.array = array;
			this.rowCount = rowCount;
			this.columnCount = columnCount;
		}

		public override string ToString()
		{
			string s = String.Empty;
			for (int i = 0; i < rowCount; i++)
			{
				s += "\n";
				for (int j = 0; j < columnCount; j++)
				{
					s += array[i, j].ToString() + " ";
				}
			}
			return s;
		}

		public override bool Equals(System.Object _object)
		{
			if (_object == null)
			{
				return false;
			}

			return (array.Equals(((Matrix<T>)(_object))));
		}

		public bool Equals(Matrix<T> matrix)
		{
			if (matrix.ColumnCount != columnCount)
			{
				return false;
			}
			else if (matrix.RowCount != rowCount)
			{
				return false;
			}
			else
			{
				for (int i = 0; i < rowCount; i++)
				{
					for (int j = 0; j < columnCount; j++)
					{
						if (!matrix.array[i, j].Equals(array[i, j]))
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			return (this.array.GetHashCode() << 1);
		}
	}
}
