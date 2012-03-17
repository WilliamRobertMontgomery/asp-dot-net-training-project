using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexNumber
{
    public class complex : IComplex
    {

       
        //Fields
        private double _re, _im;

        //Constructors
        public complex(double Re, double Im)
        {
            _re = Re;
            _im = Im;
        }
        public complex()
        {
            _re = 0;
            _im = 0;
        }

        //Properties
        public double re
        {
            get
            {
                return _re;
            }
            set
            {
                _re = value;
            }
        }
        public double im
        {
            get
            {
                return _im;
            }
            set
            {
                _im = value;
            }
        }

     

        //Overloaded Operators
        public static complex operator +(complex a, complex b)
        {
            return new complex(a.re + b.re, a.im + b.im);
        }

        public static complex operator -(complex a, complex b)
        {
            return new complex(a.re - b.re, a.im - b.im);
        }

        public static complex operator *(complex a, complex b)
        {
            return new complex(((a.re * b.re) - (a.im * b.im)), ((a.im * b.re) + (a.re * b.im)));
        }

        public static complex operator /(complex a, complex b)
        {
            return new complex(((a.re * b.re) + (a.im * b.im)) / (Math.Pow(b.re, 2) + Math.Pow(b.im, 2)), ((a.im * b.re) - (a.re * b.im)) / (Math.Pow(b.re, 2) + Math.Pow(b.im, 2)));
        }

        public static bool operator ==(complex a, complex b)
        {
            if ((a.re == b.re) && (a.im == b.im))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool operator !=(complex a, complex b)
        {
            if ((a.re == b.re) && (a.im == b.im))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void Print (complex a)
        {
            Console.WriteLine (a.ToString());
        }

        //arithmetic methods
        public complex Add(complex a, complex b)
        {
            return a + b;
        
        }

        public complex Subtract(complex a, complex b)
        {
            return a - b;
        }

        public complex Multiply(complex a, complex b)
        {
            return a * b;
        }

        public complex Divide(complex a, complex b)
        {
            return a / b;
        }

        public bool  Equals(complex a)
        {
            if (a != null)
            {
                if (this.im == a.im && this.re == a.re)
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
                return re + " + " + im + "i";
            }
            else if (im < 0)
            {
                return re + " " + im + "i";
            }
            else if (re == 0)
            {
                return im + "i";
            }
            else if (im == 0)
            {
                return re.ToString();
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
