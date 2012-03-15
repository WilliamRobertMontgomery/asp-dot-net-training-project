using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace My.Calculator.ComplexNumbers
{
    public class Calculator : ICalculator<ComplexNumber>
    {

        public ComplexNumber Add(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.re + b.re, a.im + b.im);
        }

        public ComplexNumber Subtracht(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.re - b.re, a.im - b.im);
        }

        public ComplexNumber Multiply(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.re * b.re - a.im * b.im, a.re * b.im + a.im * b.re);
        }

        public ComplexNumber Divide(ComplexNumber a, ComplexNumber b)
        {
            if (b.im != 0 || b.re != 0)
            {
                return new ComplexNumber((a.re * b.re + a.im * b.im) / (b.re * b.re + b.im * b.im), (a.im * b.re - a.re * b.im) / (b.re * b.re + b.im * b.im));
            }
            else
            {
                throw new DivideByZeroException();
            }
        }
    }
}
