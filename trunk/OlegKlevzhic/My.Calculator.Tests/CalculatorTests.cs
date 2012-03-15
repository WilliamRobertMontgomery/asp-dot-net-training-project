using System;
using NUnit.Framework;
using System.Diagnostics;

namespace My.Calculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private ICalculator<double> calculator;

        [Test]
        public void SubtrachtTest()
        {
            calculator = new Calculator();
            double actual = calculator.Subtracht(11, 5);
            double expected = 11 - 5;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void MultiplyTest()
        {
            calculator = new Calculator();
            double actual = calculator.Multiply(3, 4);
            double expected = 3 * 4;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void DivideTest()
        {
            calculator = new Calculator();
            double actual = calculator.Divide(6, 3);
            double expected = 6 / 3;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void AddTest()
        {
            calculator = new Calculator();
            double actual = calculator.Add(2, 3);
            double expected = 2 + 3;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            calculator = new Calculator();
            double actual = calculator.Divide(6, 0);
        }
    }
}
