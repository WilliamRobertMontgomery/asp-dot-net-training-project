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
        [Test]
        public void TestAdd()
        {
            double ar = 3 , ai = 4, br = 3, bi = 4;
            Complex num1 = new Complex(ar , ai);
            Complex num2 = new Complex(br , bi);
            Complex num3 = num1.Add(num1, num2);
            double result_r = ar + br;
            double result_i = ai + bi;
            Assert.AreEqual(result_r, num3.re);
            Assert.AreEqual(result_i, num3.im);
        }
    }
}
