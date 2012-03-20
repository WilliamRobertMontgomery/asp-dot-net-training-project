namespace UnitTests.VectorsTests
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using NUnit.Framework;
    using VectorCalculator;

    [TestFixture]
    public class VectorTests
    {
        /// <summary>
        /// the first vector as an array of double
        /// </summary>
        private double[] firstVectorOfDouble;

        /// <summary>
        /// the second vector as an array of double
        /// </summary>
        private double[] secondVectorOfDouble;

        /// <summary>
        /// vector as an array of double with zero value
        /// </summary>
        private double[] withZeroArrOfDouble;

        /// <summary>
        /// firstVector as type of Vector
        /// </summary>
        private Vector firstVector;
        
        /// <summary>
        /// secondVector as type of Vector
        /// </summary>
        private Vector secondVector;

        /// <summary>
        /// Initialize the implicit readonly fields like a constructor
        /// </summary>
        [TestFixtureSetUp]
        public void SetUpVariables()
        {
            Trace.WriteLine("Initialized at " + DateTime.Now);
            this.firstVectorOfDouble = new[] { 2.2, 4.4, 6.6 };
            this.secondVectorOfDouble = new[] { 1.1, 2.2, 3.3 };
            this.withZeroArrOfDouble = new[] { 1.1, 0.0, 3.3 };
        }

        /// <summary>
        /// Initialize before the start of a new method
        /// </summary>
        [SetUp]
        public void SetUpVectors()
        {
            Trace.WriteLine("Test started at " + DateTime.Now);
            this.firstVector = new Vector(this.firstVectorOfDouble);
            this.secondVector = new Vector(this.secondVectorOfDouble);
        }

        /// <summary>
        /// Logging after the end of each method
        /// </summary>
        [TearDown]
        public void TestDispose()
        {
            Trace.WriteLine("Test finished at " + DateTime.Now);
        }

        /// <summary>
        /// Logging after all tests
        /// </summary>
        [TestFixtureTearDown]
        public void TestKitDispose()
        {
            Trace.WriteLine("Completed at " + DateTime.Now);
        }
        
        /// <summary>
        /// Test for the addition of two vectors
        /// </summary>
        [Test]
        public void TestAdd()
        {
            double[] result = this.firstVector.Add(this.secondVectorOfDouble);
            
            for (int i = 0; i < result.Length ; i++)
            {
                Assert.AreEqual(this.firstVector[i] + this.secondVectorOfDouble[i], result[i]);
            }
        }

        /// <summary>
        /// Test for the subtraction of two vectors
        /// </summary>
        [Test]
        public void TestSubtract()
        {
            double[] result = this.firstVector.Substruct(this.secondVectorOfDouble);
            
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(this.firstVector[i] - this.secondVectorOfDouble[i], result[i]);
            }
        }

        /// <summary>
        /// Test for the multiplication of two vectors
        /// </summary>
        [Test]
        public void TestMyltiply()
        {
            double[] result = this.firstVector.Multiply(this.secondVectorOfDouble);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(this.firstVector[i] * this.secondVectorOfDouble[i], result[i]);
            }
        }

        /// <summary>
        /// Test for the multiplication of vector and a scalar
        /// </summary>
        [Test]
        public void TestMyltiplyVectorAndScalar()
        {
            double[] result = this.firstVector.Multiply(this.secondVectorOfDouble[0]);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(this.firstVector[i] * this.secondVectorOfDouble[0], result[i]);
            }
        }

        /// <summary>
        /// Test of the scalar multiply of two vectors
        /// </summary>
        [Test]
        public void TestScalarMyltiplication()
        {
            double result = this.firstVector.MultiplyScalar(this.secondVectorOfDouble);
            Assert.AreEqual(this.firstVector.DataVector.Select((value, i) => value * this.secondVectorOfDouble[i]).Sum(), result);
        }

        /// <summary>
        /// Test for the division of two vectors
        /// </summary>
        [Test]
        public void TestDivide()
        {
            double[] result = this.firstVector.Divide(this.secondVectorOfDouble);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(this.firstVector[i] / this.secondVectorOfDouble[i], result[i]);
            }
        }

        /// <summary>
        /// Test for the division of two vectors and handle exception
        /// </summary>
        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivideByZero()
        {
            double[] result = this.firstVector.Divide(this.withZeroArrOfDouble);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(this.firstVector[i] / this.withZeroArrOfDouble[i], result[i]);
            }
        }

        /// <summary>
        /// Test for the addition operator
        /// </summary>
        [Test]
        public void TestAddOperator()
        {
            double[] result = this.firstVector + this.secondVector;
            
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(this.firstVector[i] + this.secondVector[i], result[i]);
            }
        }

        /// <summary>
        /// Test for the substraction operator
        /// </summary>
        [Test]
        public void TestSubstractOperator()
        {
            double[] result = this.firstVector - this.secondVector;
            
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(this.firstVector[i] - this.secondVector[i], result[i]);
            }
        }

        /// <summary>
        /// Test for the multiplication operator
        /// </summary>
        [Test]
        public void TestMultiplyOperator()
        {
            double[] result = this.firstVector * this.secondVector;

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(this.firstVector[i] * this.secondVector[i], result[i]);
            }
        }

        /// <summary>
        /// Test for the division operator
        /// </summary>
        [Test]
        public void TestDivideOperator()
        {
            double[] result = this.firstVector / this.secondVector;
            
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(this.firstVector[i] / this.secondVector[i], result[i]);
            }
        }

        /// <summary>
        /// Test for division operator and throw exception
        /// </summary>
        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivideByZeroOperator()
        {
            var yVector = new Vector(this.withZeroArrOfDouble);
            double[] result = this.firstVector / yVector;
            
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(this.firstVector[i] / yVector[i], result[i]);
            }
        }
        
        /// <summary>
        /// Test for implicit conversion to double
        /// </summary>
        [Test]
        public void TestImplicitConversionToDouble()
        {
            var vector = new Vector(this.firstVectorOfDouble);
            double[] result = vector;
            Assert.That(this.firstVectorOfDouble == result);
        }
        
        /// <summary>
        /// Test for implicit conversion to Vector
        /// </summary>
        [Test]
        public void TestImplicitConversionToVector()
        {
            double[] vector = new Vector(this.firstVectorOfDouble);
            Vector result = this.firstVectorOfDouble;
            double[] toDouble = result;
            Assert.That(vector == toDouble);
        }

        /// <summary>
        /// Test ovverided ToString method
        /// </summary>
        [Test]
        public void TestToString()
        {
            var tempFirstString = string.Format("Vector data: [{0}][{1}][{2}];", 
                this.firstVectorOfDouble[0], this.firstVectorOfDouble[1], this.firstVectorOfDouble[2]);
            var tempSecondString = string.Format("Vector data: [{0}][{1}][{2}];",
                this.secondVectorOfDouble[0], this.secondVectorOfDouble[1], this.secondVectorOfDouble[2]);

            Assert.IsNotEmpty(this.firstVectorOfDouble);
            Assert.AreEqual(tempFirstString, (new Vector(this.firstVectorOfDouble)).ToString());
            Assert.AreEqual(tempSecondString, (new Vector(this.secondVectorOfDouble)).ToString());
        }

        /// <summary>
        /// Test ovverided Equals method
        /// </summary>
        [Test]
        public void TestEquals()
        {
            var tempFirst = new[] { 2.2, 5.2, 6.1 };
            var tempSecond = new[] { 2.2, 5.2, 6.1 };
            
            Assert.AreEqual(tempFirst.SequenceEqual(tempSecond)
                , this.firstVector.Equals(new[] { 2.2, 4.4, 6.6 }));
            Assert.AreNotEqual(tempFirst.SequenceEqual(tempSecond)
                , this.firstVector.Equals(new[] { 0.2, 4.4, 6.6 }));
        }

        /// <summary>
        /// Test ovverided GetHashCode method
        /// </summary>
        [Test]
        public void TestGetHashCode()
        {
            Assert.AreEqual(new Vector(this.firstVectorOfDouble).GetHashCode(), firstVector.GetHashCode());
            Assert.That(new Vector(this.firstVectorOfDouble).GetHashCode() == firstVector.GetHashCode());
            Assert.AreNotEqual(new Vector(this.secondVectorOfDouble).GetHashCode(), firstVector.GetHashCode());
        }
    }
}
