using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace My.Complex
{
    public class Complex:IComplex
    {
        public double re;
        public double im;

        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public Complex Sum(Complex number)
        {
            return new Complex(this.re + number.re, this.im + number.im);
        }

        public Complex Subtract(Complex number)
        {
            return new Complex(this.re - number.re, this.im - number.im);
        }

        public Complex Multiply(Complex number)
        {
            return new Complex(this.re * number.re - this.im * number.im, this.re * number.im + this.im * number.re);
        }

        public Complex Divide(Complex number)
        {
            
            if (number.re == 0 && number.im == 0)
            {
                throw new DivideByZeroException();
            }
            try
            {
                return new Complex((this.re * number.re + this.im * number.im) / (number.re * number.re + number.im * number.im), (this.im * number.re - this.re * number.im) / (number.re * number.re + number.im * number.im));
            }
            catch (DivideByZeroException e)
            {
                Trace.WriteLine(e.StackTrace);
                return null;
            }
        }

        public double Module()
        {
            return Math.Sqrt(re * re + im * im);
        }

        public bool Equals(Complex number)
        {
            if (number != null)
            {
                if (this.im == number.im && this.re == number.re)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            if (im > 0)
            {
                return re + "+" + im + "i";
            }
            else if (im <0)
            {
                return re + "" + im + "i";
            }
            else if (im == 0)
            {
                return re.ToString();
            }
            else if (re == 0)
            {
                return im + "i";
            }
            else if (re == 0 && im == 0)
            {
                return "0";
            }
            else
            {
                return "null";
            }
        }
    }
}
