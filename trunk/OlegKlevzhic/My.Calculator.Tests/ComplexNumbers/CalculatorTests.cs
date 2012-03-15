using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using My.Calculator.ComplexNumbers;

namespace My.Calculator.Tests.CalculatorComplex
{
    [TestFixture]
    class CalculatorTests
    {
        private ICalculator<ComplexNumber> calculator;

        [Test]
        public void SubtrachtTest()
        {
            calculator = new ComplexNumbers.Calculator();
            ComplexNumber actual = calculator.Subtracht(new ComplexNumber(4, 5), new ComplexNumber(6, 7));
            ComplexNumber expected = new ComplexNumber(4 - 6, 5 - 7);
            Assert.AreEqual(actual.re, expected.re);
            Assert.AreEqual(actual.im, expected.im);
        }

        [Test]
        public void MultiplyTest()
        {
            calculator = new ComplexNumbers.Calculator();
            ComplexNumber actual = calculator.Multiply(new ComplexNumber(4, 5), new ComplexNumber(6, 7));
            ComplexNumber expected = new ComplexNumber(4 * 6 - 5 * 7, 5 * 6 + 4 * 7);
            Assert.AreEqual(actual.re, expected.re);
            Assert.AreEqual(actual.im, expected.im);
        }

        [Test]
        public void DivideTest()
        {
            calculator = new ComplexNumbers.Calculator();
            ComplexNumber actual = calculator.Divide(new ComplexNumber(4, 5), new ComplexNumber(6, 7));
            ComplexNumber expected = new ComplexNumber((4.0 * 6.0 + 5.0 * 7.0) / (6.0 * 6.0 + 7.0 * 7.0), (5.0 * 6.0 - 4.0 * 7.0) / (6.0 * 6.0 + 7.0 * 7.0));
            Assert.AreEqual(actual.re, expected.re);
            Assert.AreEqual(actual.im, expected.im);
        }

        [Test]
        public void AddTest()
        {
            calculator = new ComplexNumbers.Calculator();
            ComplexNumber actual = calculator.Add(new ComplexNumber(4, 5), new ComplexNumber(6, 7));
            ComplexNumber expected = new ComplexNumber(4 + 6, 5 + 7);
            Assert.AreEqual(actual.re, expected.re);
            Assert.AreEqual(actual.im, expected.im);
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            calculator = new ComplexNumbers.Calculator();
            ComplexNumber actual = calculator.Divide(new ComplexNumber(4, 5), new ComplexNumber(0, 0));
        }
    }
}
