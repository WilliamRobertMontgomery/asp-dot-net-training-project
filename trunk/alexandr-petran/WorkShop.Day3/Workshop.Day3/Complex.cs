using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop.Day3
{
	/// <summary>
	/// The class, that represent a complex number
	/// </summary>
	public class Complex: IComplex
	{
		public double Re 
		{
			get;
			set;
		}
		public double Im
		{
			get;
			set;
		}

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		public Complex(double a, double b)
		{
			this.Re = a;
			this.Im = b;
		}

		/// <summary>
		/// deafult constructor
		/// </summary>
		public Complex ()
		{
		}

		/// <summary>
		/// operator + overload
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Complex operator + (Complex a, Complex b)
		{
			Complex result = new Complex();
			result.Re = a.Re + b.Re;
			result.Im = a.Im + b.Im;
			return result;
		}

		/// <summary>
		/// operator - overload
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Complex operator - (Complex a, Complex b)
		{
			Complex result = new Complex();
			result.Re = a.Re - b.Re;
			result.Im = a.Im - b.Im;
			return result;
		}

		/// <summary>
		/// operator * overload
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Complex operator * (Complex a, Complex b)
		{
			Complex result = new Complex();
			result.Re = a.Re * b.Re - a.Im * b.Im;
			result.Im = a.Im * b.Re + a.Re * b.Im;
			return result;
		}

		/// <summary>
		/// operator / overload
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Complex operator / (Complex a, Complex b)
		{
			Complex result = new Complex();
			result.Re = ((a.Re*b.Re) + (a.Im*b.Im))/((b.Re*b.Re) + (b.Im*b.Im));
			result.Im = ((a.Im*b.Re)+(a.Re*b.Im))/((b.Re*b.Re) + (b.Im*b.Im));
			return result;
		}

		/// <summary>
		/// override of method ToString()
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (this.Re == 0 && this.Im == 0)
			{
				return "0";
			}
			else if(this.Im == 0)
			{
				return this.Re.ToString();
			}
			else if(this.Re == 0)
			{
				return String.Format("i{0}", this.Im);
			}
			else
			{
				return String.Format("{0} +i({1})", this.Re, this.Im);
			}


		}

		/// <summary>
		/// Method for comparing real parts of complex numbers
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool EqualsRe(Complex a, Complex b)
		{
			if(a == null || b == null)
			{
				throw new NullReferenceException();
			}
			else
			{
				return (a.Re == b.Re);
			}
		}

		/// <summary>
		/// Method for comparing imaginary parts of complex numbers
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool EqualsIm(Complex a, Complex b)
		{
			if (a == null || b == null)
			{
				throw new NullReferenceException();
			}
			else
			{
				return (a.Im == b.Im);
			}
		}

		/// <summary>
		/// Method for addind complex numbers
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public Complex Add(Complex b)
		{
			return this+b;
		}

		/// <summary>
		/// Method for substracting complex numbers
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public Complex Substract(Complex b)
		{
			return this-b;
		}

		/// <summary>
		/// Method for multiplying complex numbers
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public Complex Multiply(Complex b)
		{
			return this*b;
		}

		/// <summary>
		/// Method for dividing complex numbers
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public Complex Divide(Complex b)
		{
			return this/b;
		}
	}
}
