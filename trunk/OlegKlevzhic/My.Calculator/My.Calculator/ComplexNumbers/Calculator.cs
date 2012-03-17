using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace My.Calculator.ComplexNumbers
{
    public class Calculator : ICalculator<Complex<double>>
    {
		/// <summary>
		/// The method returns the sum of two complex numbers.
		/// </summary>
		/// <param name="a">The first term is complete.</param>
		/// <param name="b">The second term is complete.</param>
        public Complex<double> Add(Complex<double> a, Complex<double> b)
        {
            return new Complex<double>(a.Re + b.Re, a.Im + b.Im);
        }

		/// <summary>
		/// The method returns the difference of two complex numbers.
		/// </summary>
        public Complex<double> Subtracht(Complex<double> a, Complex<double> b)
        {
            return new Complex<double>(a.Re - b.Re, a.Im - b.Im);
        }

		/// <summary>
		/// The method returns the multiply of two complex numbers.
		/// </summary>
        public Complex<double> Multiply(Complex<double> a, Complex<double> b)
        {
            return new Complex<double>(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + a.Im * b.Re);
        }

		/// <summary>
		/// The method return the divide of two complex number.
		/// </summary>
        public Complex<double> Divide(Complex<double> a, Complex<double> b)
        {
            if (b.Im != 0 || b.Re != 0)
            {
                return new Complex<double>((a.Re * b.Re + a.Im * b.Im) / (b.Re * b.Re + b.Im * b.Im), (a.Im * b.Re - a.Re * b.Im) / (b.Re * b.Re + b.Im * b.Im));
            }
            else
            {
                throw new DivideByZeroException();
            }
        }
    }
}
