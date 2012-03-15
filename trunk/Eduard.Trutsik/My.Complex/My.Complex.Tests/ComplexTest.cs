using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Diagnostics;
using System.IO;

namespace My.Complex.Tests
{
    [TestFixture]
    public class ComplexTest
    {

        private Complex number1;
        private Complex number2;

        [TestFixtureSetUp]
        public void SetUp()
        {
            number1 = new Complex(1, 2);
            number2 = new Complex(2, 4);
        }

        [Test]
        public void Sum()
        {
            Complex actual = number1.Sum(number2);
            Complex expected = new Complex(number1.re+ number2.re, number1.im + number2.im);
            Assert.True(actual.Equals(expected));
        }

        [Test]
        public void Subtract()
        {
            Complex actual = number1.Subtract(number2);
            Complex expected = new Complex(number1.re - number2.re, number1.im - number2.im);
            Assert.True(actual.Equals(expected));
        }

        [Test]
        public void Multiply()
        {
            Complex actual = number1.Multiply(number2);
            Complex expected = new Complex(number1.re * number2.re - number1.im * number2.im, number1.re * number2.im + number1.im * number2.re);
            Assert.True(actual.Equals(expected));
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            Complex actual = number1.Divide(new Complex(0,0));
        }

        [Test]
        public void Divide()
        {
            Complex actual = number1.Divide(number2);
            Complex expected = new Complex((number1.re * number2.re + number1.im * number2.im) / (number2.re * number2.re + number2.im * number2.im), (number1.im * number2.re - number1.re * number2.im) / (number2.re * number2.re + number2.im * number2.im));
            Assert.True(expected.Equals(actual));
        }

        [Test]
        public void Module()
        {
            double actual = number1.Module();
            double expected = Math.Sqrt(number1.re * number1.re + number1.im * number1.im);
            Assert.AreEqual(expected, actual);
        }
    }
}
