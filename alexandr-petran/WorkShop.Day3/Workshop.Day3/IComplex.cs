using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop.Day3
{
	public interface IComplex
	{
		Complex Add (Complex b);
		Complex Substract (Complex b);
		Complex Multiply (Complex b);
		Complex Divide(Complex b);
		double Re
		{
			get;
			set;
		}
		double Im
		{
			get;
			set;
		}
	}
}
