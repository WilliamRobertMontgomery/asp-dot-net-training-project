using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Calculator.ComplexNumbers
{
	/// <summary>
	/// The structure is a complex number.
	/// </summary>
	public struct Complex<T>
	{
		private T re;
		private T im;

		/// <summary>
		/// Gets or sets the value of the real part of complex number.
		/// </summary>
		public T Re
		{
			get { return re; }
			set { re = value; }
		}
		
		/// <summary>
		/// Gets or sets the value of the imaginary part of complex number.
		/// </summary>
		public T Im
		{
			get { return im; }
			set { im = value; }
		}

		public Complex(T re, T im)
		{
			this.re = re;
			this.im = im;
		}

		public override string ToString()
		{
			if (re.Equals(0) && im.Equals(0))
			{
				return "0";
			}
			else
				if (re.Equals(0))
				{
					return "i" + im.ToString();
				}
				else
					if (im.Equals(0))
					{
						return re.ToString();
					}
					else
						if (im.Equals(0))
						{
							return re.ToString() + "i" + im.ToString();
						}
						else
						{
							return re.ToString() + "+" + "i" + im.ToString();
						}
		}

		public override bool Equals(System.Object _object)
		{
			if (_object == null)
			{
				return false;
			}

			return (re.Equals(((Complex<T>)(_object)).re)) && (im.Equals(((Complex<T>)(_object)).im));
		}

		public bool Equals(Complex<T> complexNumber)
		{
			if (complexNumber.Equals(null))
			{
				return false;
			}

			return (re.Equals(complexNumber.re)) && (im.Equals(complexNumber.im));
		}

		public override int GetHashCode()
		{
			return (this.re.GetHashCode() ^ (this.im.GetHashCode() << 1));
		}

	}
}
