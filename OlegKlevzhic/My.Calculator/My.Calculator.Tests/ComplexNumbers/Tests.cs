using System;
using NUnit.Framework;
using My.Calculator.ComplexNumbers;

namespace My.Calculator.Tests.CalculatorComplex
{
	[TestFixture]
	class Tests
	{
		private ICalculator<Complex<double>> calculator;

		[Test]
		public void SubtrachtTest()
		{
			calculator = new ComplexNumbers.Calculator();
			Complex<double> actual = calculator.Subtracht(new Complex<double>(4, 5), new Complex<double>(6, 7));
			Complex<double> expected = new Complex<double>(4 - 6, 5 - 7);
			Assert.True(actual.Equals(expected));
		}

		[Test]
		public void MultiplyTest()
		{
			calculator = new ComplexNumbers.Calculator();
			Complex<double> actual = calculator.Multiply(new Complex<double>(4, 5), new Complex<double>(6, 7));
			Complex<double> expected = new Complex<double>(4 * 6 - 5 * 7, 5 * 6 + 4 * 7);
			Assert.True(actual.Equals(expected));
		}

		[Test]
		public void DivideTest()
		{
			calculator = new ComplexNumbers.Calculator();
			Complex<double> actual = calculator.Divide(new Complex<double>(4, 5), new Complex<double>(6, 7));
			Complex<double> expected = new Complex<double>((4.0 * 6.0 + 5.0 * 7.0) / (6.0 * 6.0 + 7.0 * 7.0), (5.0 * 6.0 - 4.0 * 7.0) / (6.0 * 6.0 + 7.0 * 7.0));
			Assert.True(actual.Equals(expected));
		}

		[Test]
		public void AddTest()
		{
			calculator = new ComplexNumbers.Calculator();
			Complex<double> actual = calculator.Add(new Complex<double>(4, 5), new Complex<double>(6, 7));
			Complex<double> expected = new Complex<double>(4 + 6, 5 + 7);
			Assert.True(actual.Equals(expected));
		}

		[Test]
		[ExpectedException(typeof(DivideByZeroException))]
		public void DivideByZeroTest()
		{
			calculator = new ComplexNumbers.Calculator();
			Complex<double> actual = calculator.Divide(new Complex<double>(4, 5), new Complex<double>(0, 0));
		}

		[Test]
		public void Equals()
		{
			Complex<double> actual = new Complex<double>(1, 2);
			Complex<double> expected = new Complex<double>(2, 3);
			Assert.True(actual.Equals(actual));
			Assert.AreEqual(actual.Equals(expected), expected.Equals(actual));
		}
	}
}
