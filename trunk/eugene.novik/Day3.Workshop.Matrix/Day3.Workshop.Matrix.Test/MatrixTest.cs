using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Day3.Workshop.Matrix;


namespace Day3.Workshop.Matrix.Test
{
	[TestFixture]
	public class MatrixTest
	{

		[Test]
		public void Equals_Test()
		{
			Matrix a = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
			Matrix b = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
			Matrix c = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

			Assert.IsTrue(a.Equals(a));
			Assert.IsTrue(a.Equals(b) == b.Equals(a));
			Assert.IsTrue(a.Equals(b) && b.Equals(c));
			Assert.IsFalse(a.Equals(null));

			Assert.IsTrue(a.Equals(c));
			c = new Matrix(new double[,] { { 0, 0 }, { 0, 0 } });
			Assert.IsFalse(a.Equals(c));
		}


		[Test]
		public void Not_Equals_Test()
		{
			Matrix a = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
			Matrix d = new Matrix(new double[,] { { 10, 20 }, { 30, 40 } });
			Matrix e = new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });

			Assert.IsFalse(a.Equals(d));
			Assert.IsFalse(a.Equals(e));
			Assert.IsTrue(a.Equals(d) == d.Equals(a));
		}


		[Test]
		public void GetHashCode_Equal_Test()
		{
			Matrix a = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
			Matrix b = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

			Assert.IsTrue(a.Equals(b));
			Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
		}


		[Test]
		public void GetHashCode_Not_Equal_Test()
		{
			Matrix a = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
			Matrix b = new Matrix(new double[,] { { 10, 20 }, { 30, 40 } });

			Assert.IsFalse(a.Equals(b));
			Assert.AreNotEqual(a.GetHashCode(), b.GetHashCode());
		}


		[Test]
		public void Add_Equal_Dimensions_Test()
		{
			Matrix a = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
			Matrix b = new Matrix(new double[,] { { 10, 20 }, { 30, 40 } });
			Matrix c = new Matrix(new double[,] { { 11, 22 }, { 33, 44 } });

			Assert.AreEqual(Matrix.Add(a, b), c);
			Assert.AreEqual(a + b, c);
			Assert.AreEqual(b + a, c);
		}


		[Test]
		public void Add_Not_Equal_Dimensions_Test()
		{
			Matrix a = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
			Matrix b = new Matrix(new double[,] { { 10, 20, 30 }, { 40, 50, 60 } });

			Assert.AreEqual(Matrix.Add(a, b), null);
			Assert.AreEqual(a + b, null);
			Assert.AreEqual(b + a, null);
		}


		[Test]
		public void Multiply_Equal_Dimension_Test()
		{
			Matrix a = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
			Matrix b = new Matrix(new double[,] { { 10, 20 }, { 30, 40 } });
			Matrix c = new Matrix(new double[,] { { 70, 100 }, { 150, 220 } });

			Assert.AreEqual(Matrix.Multiply(a, b), c);
			Assert.AreEqual(a * b, c);
			Assert.AreEqual(b * a, c);
		}
		

		[Test]
		public void Multiply_Not_Equal_Dimension_Test()
		{
			Matrix a = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
			Matrix b = new Matrix(new double[,] { { 1, 2 }, { 4, 5 }, { 7, 8 } });
			Matrix c = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });

			Assert.AreEqual(Matrix.Multiply(a, b), null);
			Assert.AreEqual(a * b, null);

			Assert.AreEqual(Matrix.Multiply(a, c), null);
			Assert.AreEqual(Matrix.Multiply(b, c), null);
		}


		[Test]
		public void MultiplyByScalar_Test()
		{
			Matrix a = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
			Matrix b = new Matrix(new double[,] { { 10, 20 }, { 30, 40 } });
			double d = 10.0;

			Assert.AreEqual(Matrix.MultiplyByScalar(a, d), b);
			Assert.AreEqual(a * d, b);
			Assert.AreEqual(d * a, b);
		}


		[Test]
		public void Index_Get_Test()
		{
			Matrix a = new Matrix(new double[2, 2] { { 1, 2 }, { 3, 4 } });

			Assert.AreEqual(a[0, 0], 1);
			Assert.AreEqual(a[0, 1], 2);
			Assert.AreEqual(a[1, 0], 3);
			Assert.AreEqual(a[1, 1], 4);
		}


		[Test]
		public void Index_Set_Test()
		{
			Matrix a = new Matrix(new double[2, 2]);

			a[0, 0] = 10;
			a[0, 1] = 20;
			a[1, 0] = 30;
			a[1, 1] = 40;

			Assert.AreEqual(a[0, 0], 10);
			Assert.AreEqual(a[0, 1], 20);
			Assert.AreEqual(a[1, 0], 30);
			Assert.AreEqual(a[1, 1], 40);
		}


		[Test]
		public void Index_Out_Of_Range_Test()
		{
			Matrix a = new Matrix(new double[2, 2] { { 1, 2 }, { 3, 4 } });

			try
			{
				a[2, 2] = 10.0;
			}
			catch (Exception e)
			{
				Assert.AreEqual(typeof(System.IndexOutOfRangeException), e.GetType());
			}
		}

	}
}
