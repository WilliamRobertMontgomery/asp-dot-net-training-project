using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace My.Calculator.ComplexNumbers
{
    public class Calculator : ICalculator<Complex<double>>
    {

        public Complex<double> Add(Complex<double> a, Complex<double> b)
        {
            return new Complex<double>(a.re + b.re, a.im + b.im);
        }

        public Complex<double> Subtracht(Complex<double> a, Complex<double> b)
        {
            return new Complex<double>(a.re - b.re, a.im - b.im);
        }

        public Complex<double> Multiply(Complex<double> a, Complex<double> b)
        {
            return new Complex<double>(a.re * b.re - a.im * b.im, a.re * b.im + a.im * b.re);
        }

        public Complex<double> Divide(Complex<double> a, Complex<double> b)
        {
            if (b.im != 0 || b.re != 0)
            {
                return new Complex<double>((a.re * b.re + a.im * b.im) / (b.re * b.re + b.im * b.im), (a.im * b.re - a.re * b.im) / (b.re * b.re + b.im * b.im));
            }
            else
            {
                throw new DivideByZeroException();
            }
        }
    }
}
