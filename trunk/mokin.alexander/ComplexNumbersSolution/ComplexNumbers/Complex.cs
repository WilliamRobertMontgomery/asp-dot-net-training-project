using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexNumbers
{
    public class Complex : IComplex
    {
        private double Re,Im;

        public Complex()
        {
            Re = 0.0;
            Im = 0.0;
        }

        public Complex(double Re, double Im)
        {
            this.Re = re;
            this.Im = im;
        }

        public double re
        {
            get;
            set;
        }
        public double im
        {
            get;
            set;
        }
        /// <summary>
        /// Function add arguments and return complex value
        /// </summary>
        public Complex Add(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }

        public Complex Add(Complex a, double b)
        {
            return new Complex(a.Re + b, a.Im);
        }
                
        /// <summary>
        /// Function subtract b from a and return complex value
        /// </summary>
        public Complex Subtract(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }

        public Complex Subtract(Complex a, double b)
        {
            return new Complex(a.Re - b, a.Im);
        }

        /// <summary>
        /// Function multiply arguments and return complex value
        /// </summary>
        public Complex Multiply(Complex a, Complex b)
        {
            return new Complex(a.Re * b.Re - a.Im * b.Im, a.Im * b.Re + a.Re * b.Im);
        }

        public Complex Multiply(Complex a, double b)
        {
            return new Complex(a.Re*b, a.Im * b);
        }
        
        /// <summary>
        /// Function divide a by b and return complex value
        /// </summary>
        public Complex Devide(Complex a, Complex b)
        {
            //numerator consists of real part and imaginary part
            Complex numerator = new Complex(0 , 0); 
            //denominator is always real
            double denominator = 0;
            numerator.Re = a.Re * b.Re + a.Im * b.Im;
            numerator.Im = a.Im * b.Re - b.Im * a.Re;
            denominator = Math.Pow(b.Re, 2)+ Math.Pow(b.Im, 2);
            return new Complex(numerator.Re / denominator, numerator.Im / denominator);
        }

        public Complex Devide(Complex a, double b)
        {
            return new Complex(a.Re / b, a.Im / b);
        }        

        public static  Complex operator+ (Complex a, Complex b)
        {
            return a.Add(a, b);
        }
        public static  Complex operator+ (Complex a, double b)
        {
            return a.Add(a, b);
        }
        public static  Complex operator+ (double a, Complex b)
        {
            return b.Add(b, a);
        }

        public static  Complex operator- (Complex a, Complex b)
        {
            return a.Subtract(a, b);
        }
        public static  Complex operator- (Complex a, double b)
        {
            return a.Subtract(a, b);
        }

        public static  Complex operator* (Complex a, Complex b)
        {
            return a.Multiply(a, b);
        }
        public static  Complex operator* (Complex a, double b)
        {
            return a.Multiply(a, b);
        }
        public static  Complex operator* (double a, Complex b)
        {
            return b.Multiply(b, a);
        }

        public static  Complex operator /(Complex a, Complex b)
        {
            return a.Devide(a, b);
        }
        public static  Complex operator /(Complex a, double b)
        {
            return a.Devide(a, b);
        }

        public override bool Equals(object arg)
        {
            Complex obj = new Complex(((Complex)arg).Re, ((Complex)arg).Im);
            Math.Round(obj.Re, 4, MidpointRounding.AwayFromZero);
            Math.Round(obj.Im, 4, MidpointRounding.AwayFromZero);

            Math.Round(this.Re, 4, MidpointRounding.AwayFromZero);
            Math.Round(this.Im, 4, MidpointRounding.AwayFromZero);

            if ((obj.Re == this.Re) && (obj.Im == this.Im))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return Re.ToString().GetHashCode() ^ Im.ToString().GetHashCode(); 
        }
    }
}
