using System;

namespace My.Calculator.Matrices
{
	public class Calculator : ICalculator<Matrix<double>>
	{
		/// <summary>
		/// The method returns the sum two numbers.
		/// </summary>
		public Matrix<double> Add(Matrix<double> a, Matrix<double> b)
		{
			try
			{
				for (int i = 0; i < a.RowCount; i++)
				{
					for (int j = 0; j < a.ColumnCount; j++)
					{
						a.Array[i, j] += b.Array[i, j];
					}
				}
			}
			catch (FormatException ex)
			{
				throw new FormatException(ex.Message);
			}
			return a;
		}

		/// <summary>
		/// The method returns the difference two numbers.
		/// </summary>
		public Matrix<double> Subtracht(Matrix<double> a, Matrix<double> b)
		{
			try
			{
				int columnCount = a.ColumnCount;
				int rowCount = a.RowCount;
				for (int i = 0; i < rowCount; i++)
				{
					for (int j = 0; j < columnCount; j++)
					{
						a.Array[i, j] -= b.Array[i, j];
					}
				}
				return a;
			}
			catch (FormatException ex)
			{
				throw new FormatException(ex.Message);
			}
		}

		/// <summary>
		/// The method returns the multiply two numbers.
		/// </summary>
		public Matrix<double> Multiply(Matrix<double> a, Matrix<double> b)
		{
			Matrix<double> result = new Matrix<double>(a.ColumnCount, b.RowCount);

			if (a.ColumnCount != b.RowCount)
				throw new InvalidOperationException("These matrices can not be multiplied!");
			try
			{
				for (int i = 0; i < a.RowCount; i++)
				{

					for (int j = 0; j < b.ColumnCount; j++)
					{
						double s = 0;
						for (int k = 0; k < a.ColumnCount; k++)
						{
							s += a.Array[i, k] * b.Array[k, j];
						}
						result.Array[i, j] = s;
					}
				}
				return result;
			}
			catch (FormatException ex)
			{
				throw new FormatException(ex.Message);
			}
		}

		/// <summary>
		/// The method returns the divide two numbers.
		/// </summary>
		public Matrix<double> Divide(Matrix<double> a, Matrix<double> b)
		{
			throw new NotImplementedException();
		}
	}
}
