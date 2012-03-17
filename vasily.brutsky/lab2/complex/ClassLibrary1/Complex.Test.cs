using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace ComplexNumber.Tests
{
      [TestFixture]
    public class ComplexTests
    {
         //Tests
          [Test]
          public void AddTest()
          {
              IComplex compl = new complex();
              complex a = new complex(2, 3);
              complex b = new complex(3, 4);
              complex actual = compl.Add(a, b);
              complex expected = a + b;
              Assert.AreEqual(actual.im, expected.im);
              Assert.AreEqual(actual.re, expected.re);
          }

          [Test]
          public void SubtractTest()
          {
              IComplex compl = new complex();
              complex a = new complex(20, 30);
              complex b = new complex(30, 40);
              complex actual = compl.Subtract(a, b);
              complex expected = a - b;
              Assert.AreEqual(actual.im, expected.im);
              Assert.AreEqual(actual.re, expected.re);

          }
          [Test]      
          public void MultiplyTest()
          {
              IComplex compl = new complex();
              complex a = new complex(20, 30);
              complex b = new complex(30, 40);
              complex actual = compl.Multiply(a, b);
              complex expected = a * b;
              Assert.AreEqual(actual.im, expected.im);
              Assert.AreEqual(actual.re, expected.re);

          }
          [Test]
          public void DivideTest()
          {
              IComplex compl = new complex();
              complex a = new complex(20, 30);
              complex b = new complex(30, 40);
              complex actual = compl.Divide(a, b);
              complex expected = a / b;
              Assert.AreEqual(actual.im, expected.im);
              Assert.AreEqual(actual.re, expected.re);

          }
          
          
    }
}
