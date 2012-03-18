using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Uriah;


namespace Vectors.Test
{
	[TestFixture]
	public class Test
    {
		[Test]
		public void TestEqual1()
		{
			Vector vector = new Vector(1,2);
			bool actual = vector.Equals(vector);
			Assert.AreEqual(actual, true);
		}

		[Test]
		public void TestEquals2()
		{
			Vector firstVector = new Vector(1, 2);
			Vector secondVector = new Vector(2, 1);
			bool actual = firstVector.Equals(secondVector);
			bool expected = secondVector.Equals(firstVector);
			Assert.AreEqual(actual, expected);
		}

		[Test]
		public void TestEquals3()
		{
			Vector firstVector = new Vector(1, 2);
			Vector secondVector = new Vector(1, 2);
			Vector thirdVector = new Vector(1, 2);
			bool actual = firstVector.Equals(secondVector)&&secondVector.Equals(thirdVector);
			bool expected = firstVector.Equals(thirdVector);
			Assert.AreEqual(actual, expected);
		}

		[Test]
		public void TestEquals4()
		{
			Vector firstVector = new Vector(1, 2);
			bool actual = firstVector.Equals(null);
			Assert.AreEqual(actual, false);
		}

		[Test]
		public void TestSum()
		{
			Vector firstVector = new Vector(1, 2);
			Vector secondVector = new Vector(5, 3);
			Vector actual = firstVector + secondVector;
			Vector expected = new Vector(6, 5);

			Assert.AreEqual(actual, expected);
		}

		[Test]
		public void TestMultiply1()
		{
			Vector firstVector = new Vector(1, 2);
			Vector secondVector = new Vector(5, 3);
			double actual = firstVector * secondVector;
			double expected = 1*5 + 2*3;

			Assert.AreEqual(actual, expected);
		}

		[Test]
		public void TestMultiply2()
		{
			Vector firstVector = new Vector(3, 8);
			Vector actual = firstVector * 1.2;
			Vector expected = new Vector(3 * 1.2, 8 * 1.2);
			Assert.AreEqual(actual, expected);
		}
	
		[Test]
		public void TestMultiply3()
		{
			Vector firstVector = new Vector(3, 8);
			Vector actual = 1.2 * firstVector;
			Vector expected = new Vector(3 * 1.2, 8 * 1.2);
			Assert.AreEqual(actual, expected);
		}

		[Test]
		public void TestToString()
		{
			Vector firstVector = new Vector(3, 8);
			string actual = firstVector.ToString();
			string expected = "(3,8)";
			Assert.AreEqual(actual, expected);
		}

	}
}
