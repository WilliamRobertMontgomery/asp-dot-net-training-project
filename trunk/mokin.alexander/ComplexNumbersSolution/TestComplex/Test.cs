using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComplexNumbers;
using NUnit.Framework;

namespace TestComplex
{
    [TestFixture]
    public class Test
    {
        public const double real1 = 22.5;
        public const double real2 = 35.3;
        public const double image1 = 56.3;
        public const double image2 = 25.6;

        [Test]
        public void TestAdd()
        {
            Complex TestComplex1 = new Complex(real1, image1);
            Complex TestComplex2 = new Complex(real2, image2);
            //test: Complex operator +(Complex,Complex)
            Complex TestComplexResult = TestComplex1 + TestComplex2;
            Complex TestComplexResultExpected = new Complex(57.8, 81.9);
            Assert.AreEqual(TestComplexResult, TestComplexResultExpected);
            //test: Complex operator +(Complex, double)
            TestComplexResult = TestComplex1 + 20.1;
            TestComplexResultExpected.re = 42.6;
            TestComplexResultExpected.im = 56.3;
            Assert.AreEqual(TestComplexResult, TestComplexResultExpected);
            //test: Complex operator +(double, Complex)
            TestComplexResult = 20.1 + TestComplex1;
            Assert.AreEqual(TestComplexResult, TestComplexResultExpected);            
        }

        [Test]
        public void TestSubtract()
        {
            Complex TestComplex1 = new Complex(real1, image1);
            Complex TestComplex2 = new Complex(real2, image2);
            //test: Complex operator -(Complex, Complex)
            Complex TestComplexResult = TestComplex1 - TestComplex2;
            Complex TestComplexResultExpected = new Complex(-14.8, 9.7);
            Assert.AreEqual(TestComplexResult, TestComplexResultExpected);
            //test: Complex operator -(Complex, double)
            TestComplexResult = TestComplex1 - 20.1;
            TestComplexResultExpected.re = 2.4;
            TestComplexResultExpected.im = 56.3;
            Assert.AreEqual(TestComplexResult, TestComplexResultExpected);
        }

        [Test]
        public void TestMultiply()
        {
            Complex TestComplex1 = new Complex(real1, image1);
            Complex TestComplex2 = new Complex(real2, image2);
            //test: Complex operator *(Complex, Complex)
            Complex TestComplexResult = TestComplex1 * TestComplex2;
            Complex TestComplexResultExpected = new Complex(-647.03, 2563.39);
            Assert.AreEqual(TestComplexResult, TestComplexResultExpected);
            //test: Complex operator *(Complex, double)
            TestComplexResult = TestComplex1 * 2;
            TestComplexResultExpected.re = 45;
            TestComplexResultExpected.im = 112.6;
            Assert.AreEqual(TestComplexResult, TestComplexResultExpected);
            //test: Complex operator *(double, Complex)
            TestComplexResult = 2*TestComplex1;
            TestComplexResultExpected.re = 45;
            TestComplexResultExpected.im = 112.6;
            Assert.AreEqual(TestComplexResult, TestComplexResultExpected);
        }

        [Test]
        public void TestDevide()
        {
            Complex TestComplex1 = new Complex(real1, image1);
            Complex TestComplex2 = new Complex(real2, image2);
            //test: Complex operator /(Complex, Complex)
            Complex TestComplexResult = TestComplex1 / TestComplex2;
            Complex TestComplexResultExpected = new Complex(1.1756974940177, 0.74227037261038);
            Assert.AreEqual(TestComplexResult, TestComplexResultExpected);
            //test: Complex operator /(Complex, double)
            TestComplexResult = TestComplex1 / 2;
            TestComplexResultExpected.re = 11.25;
            TestComplexResultExpected.im = 28.15;
            Assert.AreEqual(TestComplexResult, TestComplexResultExpected);
        }

        [Test]
        public void TestEqualsAndGetHashCode()
        {
            Complex TestComplex1 = new Complex(real1, real2);
            Complex TestComplex2 = new Complex(real1, real2);
            Complex TestComplex3 = new Complex(real1, real2);
            
            //Test GetHashCode
            Assert.AreEqual(TestComplex1.GetHashCode(), TestComplex2.GetHashCode()); 
            Assert.AreEqual(TestComplex1.GetHashCode(), TestComplex1.GetHashCode());

            //Test Equals
            Assert.IsTrue(TestComplex1.Equals(TestComplex1));
            Assert.AreEqual(TestComplex1.Equals(TestComplex2), TestComplex2.Equals(TestComplex1));

            bool firstResult = TestComplex1.Equals(TestComplex2);
            bool secondResult = TestComplex2.Equals(TestComplex3);
            bool thirdResult = TestComplex1.Equals(TestComplex3);
            Assert.IsTrue(firstResult && secondResult && thirdResult);
        }
    }
}
