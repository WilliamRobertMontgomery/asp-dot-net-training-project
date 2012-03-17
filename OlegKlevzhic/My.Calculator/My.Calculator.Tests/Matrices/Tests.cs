using System;
using NUnit.Framework;
using My.Calculator.Matrices;

namespace My.Calculator.Tests.Matrices
{
	[TestFixture]
	class Tests
	{
		private ICalculator<Matrix<double>> calculator;

		[Test]
		public void AddTest()
		{
			calculator = new Calculator.Matrices.Calculator();

			Matrix<double> actual = calculator.Add(new Matrix<double>(1, 2, new double[,] { { 1.0, 2.0 } }), new Matrix<double>(1, 2, new double[,] { { 1.0, 2.0 } }));
			Matrix<double> expected = new Matrix<double>(1, 2, new double[,] { { 2.0, 4.0 } });
			Assert.True(actual.Equals(expected));
		}

		[Test]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void TestInvalidOperation()
		{
			calculator = new Calculator.Matrices.Calculator();

			Matrix<double> actual = calculator.Add(new Matrix<double>(1, 4, new double[,] { { 1.0, 2.0 } }), new Matrix<double>(1, 2, new double[,] { { 1.0, 2.0 } }));
			Matrix<double> expected = new Matrix<double>(1, 2, new double[,] { { 2.0, 4.0 } });
			Assert.True(actual.Equals(expected));
		}

		[Test]
		public void Equals()
		{
			Matrix<double> actual = new Matrix<double>(1, 2, new double[,] { { 2.0, 4.0 } });
			Matrix<double> expected = new Matrix<double>(2, 2, new double[,] { { 2.0, 4.0 }, { 2.1, 3.4 } });
			Assert.True(actual.Equals(actual));
			Assert.AreEqual(actual.Equals(expected), expected.Equals(actual));
		}

		[Test]
		public void SubtrachtTest()
		{
			calculator = new Calculator.Matrices.Calculator();

			Matrix<double> actual = calculator.Subtracht(new Matrix<double>(1, 2, new double[,] { { 1.0, 2.0 } }), new Matrix<double>(1, 2, new double[,] { { 1.0, 2.0 } }));
			Matrix<double> expected = new Matrix<double>(1, 2, new double[,] { { 0, 0 } });
			Assert.True(actual.Equals(expected));
		}

		[Test]
		public void MultiplyTest()
		{
			calculator = new Calculator.Matrices.Calculator();

			Matrix<double> actual = calculator.Multiply(new Matrix<double>(2, 2, new double[,] { { 1.0, 3.0 }, { 2.0, 2.0 } }), new Matrix<double>(2, 2, new double[,] { { 1.0, 5.0 }, { 2.0, 2.0 } }));
			Matrix<double> expected = new Matrix<double>(2, 2, new double[,] { { 7,11 },{6,14} });
			Assert.True(actual.Equals(expected));
		}

	}
}
