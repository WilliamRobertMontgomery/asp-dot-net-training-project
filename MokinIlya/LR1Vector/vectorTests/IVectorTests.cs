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
                //multiplication by a scalar TEST
                double[] TV1 = { 2.0, 3.0, 4.0 }; //TesVar1 (for actual vec)
                vector vec = new vector(TV1);
                vector actual = vec.Multiply(5.0);
                vector actual_2 = 5.0*vec;
                vector actual_3 = vec * 5.0;
                object actualObj = (object)actual;
                object actualObj_2 = (object)actual_2;
                object actualObj_3 = (object)actual_3;

                double[] TV2 = { 2.0 * 5.0, 3.0 * 5.0, 4.0 * 5.0 }; //TesVar2 (for expected vec)
                vector expected = new vector(TV2);
                object expectedObj = (object)expected;

                Assert.AreEqual(actualObj.GetHashCode(), expectedObj.GetHashCode());
                Assert.AreEqual(actualObj_2.GetHashCode(), expectedObj.GetHashCode());
                Assert.AreEqual(actualObj_3.GetHashCode(), expectedObj.GetHashCode());    
            }
            {
                //multiplication by a vector TEST
                double[] TV1 = { 2.0, 3.0, 4.0 }; //TesVar1 (for actual vec)
                vector vec = new vector(TV1);
                vector actual = vec.Multiply(vec);
                vector actual_2 = vec * vec;
                object actualObj = (object)actual;
                object actualObj_2 = (object)actual_2;

                double[] TV2 = { 0.0, 0.0, 0.0 }; //TesVar2 (for expected vec)
                vector expected = new vector(TV2);
                object expectedObj = (object)expected;

                Assert.AreEqual(actualObj.GetHashCode(), expectedObj.GetHashCode());
                Assert.AreEqual(actualObj_2.GetHashCode(), expectedObj.GetHashCode());
            }
        }

        [Test]
        public void Divide()
        {
            //dividing by a scalar TEST
            double[] TV1 = { 2.0, 3.0, 4.0 }; //TesVar1 (for actual vec)
            vector vec = new vector(TV1);
            vector actual = vec.Divide(5.0);
            vector actual_2 = vec / 5.0;
            object actualObj = (object)actual;
            object actualObj_2 = (object)actual_2;

            double[] TV2 = { 2.0 / 5.0, 3.0 / 5.0, 4.0 / 5.0 }; //TesVar2 (for expected vec)
            vector expected = new vector(TV2);
            object expectedObj = (object)expected;

            Assert.AreEqual(actualObj.GetHashCode(), expectedObj.GetHashCode());
            Assert.AreEqual(actualObj_2.GetHashCode(), expectedObj.GetHashCode());
        }

        [Test]
        public void TestSum()
        {
            //vector + vector TEST
            double[] TV1 = { 2.0, 3.0, 4.0 }; //TesVar1 (for actual vec)
            vector vec = new vector(TV1);
            vector actual = vec.Sum(vec);
            vector actual_2 = vec + vec;
            object actualObj = (object)actual;
            object actualObj_2 = (object)actual_2;

            double[] TV2 = { 4.0, 6.0, 8.0 }; //TesVar2 (for expected vec)
            vector expected = new vector(TV2);
            object expectedObj = (object)expected;

            Assert.AreEqual(actualObj.GetHashCode(), expectedObj.GetHashCode());
            Assert.AreEqual(actualObj_2.GetHashCode(), expectedObj.GetHashCode());
        }

        [Test]
        public void TestMinus()
        {
            //vector - vector TEST
            double[] TV1 = { 2.0, 3.0, 4.0 }; //TesVar1 (for actual vec)
            vector vec = new vector(TV1);
            vector actual = vec.Minus(vec);
            vector actual_2 = vec - vec;
            object actualObj = (object)actual;
            object actualObj_2 = (object)actual_2;

            double[] TV2 = { 0.0, 0.0, 0.0 }; //TesVar2 (for expected vec)
            vector expected = new vector(TV2);
            object expectedObj = (object)expected;

            Assert.AreEqual(actualObj.GetHashCode(), expectedObj.GetHashCode());
            Assert.AreEqual(actualObj_2.GetHashCode(), expectedObj.GetHashCode());
        }

        [Test]
        public void TestEquals()
        {
            //vector == vector TEST
            double[] TV1 = { 2.0, 3.0, 4.0 }; //TesVar1 (for actual vec1)
            double[] TV2 = { 2.0, 3.0, 4.0 }; //TesVar2 (for actual vec2)
            vector vec1 = new vector(TV1);
            vector vec2 = new vector(TV2);
            bool actual = vec2.Equals(vec1);
            bool actual_2 = (vec1 == vec2);

            Assert.AreEqual(true, actual);
            Assert.AreEqual(true, actual_2);
        }

        [Test]
        public void TestToString()
        {
            //vector.ToString TEST
            double[] TV = { 2.0, 3.0, 4.0 }; //TesVar (for actual vec)
            vector vec = new vector(TV);
            string actual = vec.ToString();

            string expected = "( 2,00; 3,00; 4,00 )";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetHashCode()
        {
            //vector.GetHashCode TEST
            double[] TV = { 2.0, 3.0, 4.0 }; //TesVar (for actual vec)
            vector vec = new vector(TV);
            int actual = vec.GetHashCode();

            int expected = 4;

            Assert.AreEqual(expected, actual);
        }     
    }
}
