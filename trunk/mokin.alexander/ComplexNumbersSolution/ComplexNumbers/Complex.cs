using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexNumbers
{
    public class Complex : IComplex
    {
        public double re,im;
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        /// <summary>
        /// Function add arguments and return complex value
        /// </summary>
        public Complex Add(Complex a, Complex b)
        {
            return new Complex(a.re + b.re, a.im + b.im);
        }

        public Complex Add(Complex a, double b)
        {
            throw new NotImplementedException();
        }

        public Complex Add(double a, Complex b)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Function subtract b from a and return complex value
        /// </summary>
        public Complex Subtract(Complex a, Complex b)
        {
            throw new NotImplementedException();
        }

        public Complex Subtract(Complex a, double b)
        {
            throw new NotImplementedException();
        }

        public Complex Subtract(double a, Complex b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Function multiply arguments and return complex value
        /// </summary>
        public Complex Multiply(Complex a, Complex b)
        {
            throw new NotImplementedException();
        }

        public Complex Multiply(Complex a, double b)
        {
            throw new NotImplementedException();
        }

        public Complex Multiply(double a, Complex b)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Function divide a by b and return complex value
        /// </summary>
        public Complex Devide(Complex a, Complex b)
        {
            throw new NotImplementedException();
        }

        public Complex Devide(Complex a, double b)
        {
            throw new NotImplementedException();
        }

        public Complex Devide(double a, Complex b)
        {
            throw new NotImplementedException();
        }
    }
}
