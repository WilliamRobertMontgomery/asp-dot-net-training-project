using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MathematicalObj;

namespace vectorTests
{
    [TestFixture]

    public class IVectorTests
    {
        [Test]
        public void TestModule()
        {
            double[] TV = { 2.0, 3.0, 4.0 }; //TesVar
            vector vec = new vector(TV);
            double actual = vec.Module();
            double expected = Math.Sqrt(Math.Pow(TV[0], 2) + Math.Pow(TV[1], 2) + Math.Pow(TV[2], 2));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestMultiply()
        {
            {
                double[] TV = { 2.0, 3.0, 4.0 }; //TesVar
                vector vec = new vector(TV);
                double[] actual1 = vec.Multiply(5.0);
                double[] expected1 = { (double)(2.0 * 5.0), (double)(3.0 * 5.0), (double)(4.0 * 5.0) };
                Assert.AreEqual(expected1, actual1);
            }
            {
                double[] TV = { 2.0, 3.0, 4.0 }; //TesVar
                vector vec = new vector(TV);
                double[] actual2 = vec.Multiply(TV);
                double[] expected2 = { 4.0, 9.0, 16.0 };
                Assert.AreEqual(expected2, actual2);
            }
        }
 
        [Test]
        public void TestSum()
        {
            {
                double[] TV = { 2.0, 3.0, 4.0 }; //TesVar
                vector vec = new vector(TV);
                double[] actual = vec.Sum(12.0);
                double[] expected = {14.0,15.0,16.0};
                Assert.AreEqual(expected, actual);
            }
            {
                double[] TV = { 2.0, 3.0, 4.0 }; //TesVar
                vector vec = new vector(TV);
                double[] S = { 5.0, 3.0, 1.0 };
                double[] actual = vec.Sum(S);
                double[] expected = { 7.0, 6.0, 5.0 };
                Assert.AreEqual(expected, actual);
            }
        }
        
        [Test]
        public void TestDivide()
        {
            {
                double[] TV = { 2.0, 3.0, 4.0 }; //TesVar
                vector vec = new vector(TV);
                double[] actual1 = vec.Divide(5.0);
                double[] expected1 = { (double)(2.0 / 5.0), (double)(3.0 / 5.0), (double)(4.0 / 5.0) };
                Assert.AreEqual(expected1, actual1);
            }
            {
                double[] TV = { 2.0, 3.0, 4.0 }; //TesVar
                vector vec = new vector(TV);
                double[] actual2 = vec.Divide(TV);
                double[] expected2 = { 1.0, 1.0, 1.0 };
                Assert.AreEqual(expected2, actual2);
            }
        }
        
    }
}
