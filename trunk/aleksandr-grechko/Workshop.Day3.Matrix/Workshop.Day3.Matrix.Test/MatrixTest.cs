using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Workshop.Day3.Matrix.Test
{
	[TestFixture]
	public class MatrixTest
	{
		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Martix_Wrong_Index_Test()
		{
			Matrix a = new Matrix(2, 2, 1); ;
			a[3, 3] = 5;
		}

		[Test]
		public void EqualsTest()
		{
			Matrix a = new Matrix(2, 2, 10);
			Matrix b = new Matrix(2, 2, 10);
			Matrix c = new Matrix(2, 2, 10);
			Matrix x = new Matrix(2, 2, 5);
			// Testing Equals
			Assert.IsTrue(a.Equals(b));
			Assert.IsFalse(a.Equals(x));
			// x.Equals(x) returns true
			Assert.IsTrue(a.Equals(a));
			// x.Equals(y) returns the same value as y.Equals(x)
			Assert.AreEqual(a.Equals(b), b.Equals(a)); //both true
			Assert.AreEqual(a.Equals(x), x.Equals(a)); // both false
			// if (x.Equals(y) && y.Equals(z)) returns true, then x.Equals(z) returns true.
			Assert.IsTrue(a.Equals(b) && b.Equals(c) && a.Equals(c));
		}

		[Test]
		public void EqualityTest()
		{
			Matrix a = new Matrix(2, 2, 1);
			Assert.IsTrue(a == new Matrix(2, 2, 1));
			Assert.IsFalse(a == new Matrix(2, 2, 5));
		}


		[Test]
		public void Equal_Different_Size_Matrixes_Test()
		{
			Matrix a = new Matrix(2, 2, 1);
			Matrix b = new Matrix(3, 3, 1);
			Assert.IsFalse(a.Equals(b));
			Assert.IsFalse(a == b);
			Assert.IsTrue(a != b);
		}

		[Test]
		public void Equal_After_Change_Matrixes_Test()
		{

			Matrix a = new Matrix(2, 2, 10);
			Matrix b = new Matrix(2, 2, 10);
			Assert.IsTrue(a.Equals(b));
			b[2, 2] = 5;
			Assert.IsFalse(a.Equals(b));
			b[2, 2] = 10;
			Assert.IsTrue(a.Equals(b));
		}

		[Test]
		public void Equal_Parameter_Null_Test()
		{
			Matrix a = new Matrix(2, 2, 1);
			Assert.IsFalse(a.Equals(null));
			Matrix b = null;
			Assert.IsFalse(a.Equals(b));
			Assert.IsFalse(a == b);
		}

		[Test]
		public void Equal_Both_Parameters_Null_Test()
		{
			Matrix a = null;
			Matrix b = null;
			Assert.IsTrue(a == b);
		}

		[Test]
		public void NotEqualTest()
		{
			Matrix a = new Matrix(2, 2, 1);
			Assert.IsFalse(a != new Matrix(2, 2, 1));
			Assert.IsTrue(a != new Matrix(2, 2, 2));
		}

		[Test]
		public void GetHashCode_Equal_Matrixes_Test()
		{
			Matrix a = new Matrix(2, 2, 1);
			Matrix b = new Matrix(2, 2, 1);
			Assert.AreEqual(a, b);
			Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
		}

		[Test]
		public void GetHashCode_Not_Equal_Matrixes_Test()
		{
			Matrix a = new Matrix(2, 2, 1);
			Matrix b = new Matrix(2, 2, 2);
			Assert.AreNotEqual(a, b);
			Assert.AreNotEqual(a.GetHashCode(), b.GetHashCode());
		}

		[Test]
		public void AddTest()
		{
			Matrix a = new Matrix(2, 2, 1);
			Matrix b = new Matrix(2, 2, 2);
			Matrix zero = new Matrix(2, 2);
			Assert.AreEqual(a + b, new Matrix(2, 2, 3));
			Assert.AreEqual(a + b, b + a);
			Assert.AreEqual(a + zero, a);
			Assert.AreEqual(a + new Matrix(2, 2, -1), zero);
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Add_Matrix_Different_Size_Test()
		{
			Matrix a = new Matrix(2, 2, 1) + new Matrix(3, 3, 5);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Add_Null_Parameter_Test()
		{
			Matrix a = null;
			a = a + a;
		}

		[Test]
		public void ScalarMultiplicationTest()
		{
			Matrix a = new Matrix(2, 2, 1);
			Assert.AreEqual(3 * a, new Matrix(2, 2, 3));
			Assert.AreEqual(1 * a, a);
			Assert.AreEqual(0 * a, new Matrix(2, 2));
			Assert.AreEqual(-1 * a, new Matrix(2, 2, -1));
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void ScalarMultiplication_Null_Parameter_Test()
		{
			Matrix a = null;
			a = a * 5;
		}

		[Test]
		public void MatrixMultiplicationTest()
		{
			Matrix a = new Matrix(new double[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			Matrix b = new Matrix(new double[2, 3] { { 6, 5, 4 }, { 3, 2, 1 } });
			Matrix c = new Matrix(new double[3, 3] { { 12, 9, 6 }, { 30, 23, 16 }, { 48, 37, 26 } });
			Assert.AreEqual(a * b, c);
			Assert.AreEqual((a * b) * c, a * (b * c));
			Assert.AreNotEqual(a * b, b * a);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void MatrixMultiplication_Null_Parameter_Test()
		{
			Matrix a = null;
			a = a * a;
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void MatrixMultiplication_Wrong_Size_Test()
		{
			Matrix a = new Matrix(2, 2, 1) * new Matrix(3, 3, 5);
		}

		[Test]
		public void ToStringTest()
		{
			Matrix a = new Matrix(2, 2, 1);
			string str = "|        1        1        |\r\n|        1        1        |\r\n";
			Assert.AreEqual(a.ToString(), str);
		}



	}
}
