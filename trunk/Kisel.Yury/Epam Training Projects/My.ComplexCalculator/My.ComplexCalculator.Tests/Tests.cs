using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using My.ComplexCalculator;

namespace My.ComplexCalculator.Tests
{
    [TestFixture]
    public class Tests
    {
        ComplexNumber TestedNumber1 = new ComplexNumber(2, 2);
        ComplexNumber TestedNumber2 = new ComplexNumber(3, 3);
        ComplexNumber TestedNumber3 = new ComplexNumber(2, 2);
        ComplexNumber ZeroNumber = new ComplexNumber();
        ComplexNumber NullNumber = null;
        IComplexCalculations Calculator = new ComplexCalculator();

        [Test]
        public void AddTest()
        {            
            ComplexNumber actual = Calculator.Add(TestedNumber1, TestedNumber2);
            ComplexNumber expected = TestedNumber1 + TestedNumber2;
            ComplexNumber.Equals(actual, expected);
        }

        [Test]
        public void SubstractTest()
        {
            ComplexNumber actual = Calculator.Substract(TestedNumber1, TestedNumber2);
            ComplexNumber expected = TestedNumber1 - TestedNumber2;
            ComplexNumber.Equals(actual, expected);
        }

        [Test]
        public void MultiplyTest()
        {
            ComplexNumber actual = Calculator.Multiply(TestedNumber1, TestedNumber2);
            ComplexNumber expected = TestedNumber1 * TestedNumber2;
            ComplexNumber.Equals(actual, expected);
        }

        [Test]
        public void DivideTest()
        {
            ComplexNumber actual = Calculator.Divide(TestedNumber1, TestedNumber2);
            ComplexNumber expected = TestedNumber1 / TestedNumber2;
            ComplexNumber.Equals(actual, expected);
        }
        
        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            ComplexNumber actual = Calculator.Divide(TestedNumber1, ZeroNumber);
        }

        [Test]
        public void EqualsTrueTest()
        {
            bool actual = ComplexNumber.Equals(TestedNumber1, TestedNumber3);
            bool expected = TestedNumber1.Re == TestedNumber3.Re || TestedNumber1.Im == TestedNumber3.Im;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void EqualsFalseTest()
        {
            bool actual = ComplexNumber.Equals(TestedNumber1, TestedNumber2);
            bool expected = TestedNumber1.Re == TestedNumber2.Re || TestedNumber1.Im == TestedNumber2.Im;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void EqualsNullTest()
        {
            bool actual = ComplexNumber.Equals(TestedNumber1, NullNumber);
        }
    }
}
