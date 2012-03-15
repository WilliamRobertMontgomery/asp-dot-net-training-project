using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using My.Calculator.ComplexNumbers;

namespace My.Calculator.Tests.CalculatorComplex
{
    [TestFixture]
    class Tests
    {
        private ICalculator<ComplexNumber> calculator;

        [Test]
        public void SubtrachtTest()
        {
            calculator = new ComplexNumbers.Calculator();
            ComplexNumber actual = calculator.Subtracht(new ComplexNumber(4, 5), new ComplexNumber(6, 7));
            ComplexNumber expected = new ComplexNumber(4 - 6, 5 - 7);
            Assert.True(actual.Equals(expected));
        }

        [Test]
        public void MultiplyTest()
        {
            calculator = new ComplexNumbers.Calculator();
            ComplexNumber actual = calculator.Multiply(new ComplexNumber(4, 5), new ComplexNumber(6, 7));
            ComplexNumber expected = new ComplexNumber(4 * 6 - 5 * 7, 5 * 6 + 4 * 7);
            Assert.True(actual.Equals(expected));
        }

        [Test]
        public void DivideTest()
        {
            calculator = new ComplexNumbers.Calculator();
            ComplexNumber actual = calculator.Divide(new ComplexNumber(4, 5), new ComplexNumber(6, 7));
            ComplexNumber expected = new ComplexNumber((4.0 * 6.0 + 5.0 * 7.0) / (6.0 * 6.0 + 7.0 * 7.0), (5.0 * 6.0 - 4.0 * 7.0) / (6.0 * 6.0 + 7.0 * 7.0));
            Assert.True(actual.Equals(expected));
        }

        [Test]
        public void AddTest()
        {
            calculator = new ComplexNumbers.Calculator();
            ComplexNumber actual = calculator.Add(new ComplexNumber(4, 5), new ComplexNumber(6, 7));
            ComplexNumber expected = new ComplexNumber(4 + 6, 5 + 7);
            Assert.True(actual.Equals(expected));
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            calculator = new ComplexNumbers.Calculator();
            ComplexNumber actual = calculator.Divide(new ComplexNumber(4, 5), new ComplexNumber(0, 0));
        }

        [Test]
        public void Equals()
        {
            ComplexNumber actual = new ComplexNumber(1,2);
            ComplexNumber expected = new ComplexNumber(2, 3);
            Assert.True(actual.Equals(actual));
            Assert.AreEqual(actual.Equals(expected),expected.Equals(actual));
        }
    }
}
