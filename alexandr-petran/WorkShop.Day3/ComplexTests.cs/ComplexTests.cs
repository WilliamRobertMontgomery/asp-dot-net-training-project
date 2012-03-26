using Workshop.Day3;
using NUnit.Framework;

namespace ComplexTests.cs
{
	/// <summary>
	/// class for testing working with complex numbers
	/// </summary>
	[TestFixture]
	public class ComplexTests
	{
		Complex a = new Complex(3.1,5.3);
		Complex b = new Complex(9.6,-1.4);
		
		[Test]
		public void TestAdd()
		{
			Complex result = new Complex();
			result = a.Add(b);
			Complex expected = new Complex();
			expected.Re = a.Re + b.Re;
			expected.Im = a.Im + b.Im;
			Assert.AreEqual(result.Re,expected.Re);
			Assert.AreEqual(result.Im,expected.Im);
		}

		[Test]
		public void TestSubstract()
		{
			Complex result = new Complex();
			result = a.Substract(b);
			Complex expected = new Complex();
			expected.Re = a.Re - b.Re;
			expected.Im = a.Im - b.Im;
			Assert.AreEqual(result.Re, expected.Re);
			Assert.AreEqual(result.Im, expected.Im);
		}

		[Test]
		public void TestMultiply()
		{
			Complex result = new Complex();
			result = a.Multiply(b);
			Complex expected = new Complex();
			expected.Re = a.Re * b.Re - a.Im * b.Im;
			expected.Im = a.Im * b.Re + a.Re * b.Im;
			Assert.AreEqual(result.Re, expected.Re);
			Assert.AreEqual(result.Im, expected.Im);
		}

		[Test]
		public void TestDivide()
		{
			Complex result = new Complex();
			result = a.Divide(b);
			Complex expected = new Complex();
			expected.Re = ((a.Re * b.Re) + (a.Im * b.Im)) / ((b.Re * b.Re) + (b.Im * b.Im));
			expected.Im = ((a.Im * b.Re) + (a.Re * b.Im)) / ((b.Re * b.Re) + (b.Im * b.Im));
			Assert.AreEqual(result.Re, expected.Re);
			Assert.AreEqual(result.Im, expected.Im);
		}

		[Test]
		public void TestEqualsRe()
		{
			bool result = Complex.EqualsRe(a, b);
			Assert.AreEqual(result, false);
			result = Complex.EqualsRe(a, a);
			Assert.AreEqual(result,true);
		}

		[Test]
		public void TestEqualsIm()
		{
			bool result = Complex.EqualsIm(a, b);
			Assert.AreEqual(result, false);
			result = Complex.EqualsIm(a, a);
			Assert.AreEqual(result, true);
		}


	}
}
