using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.ComplexCalculator
{
    //
    // Class for keeping complex numbers
    //

    public class ComplexNumber
    {
        
        //real and imaginary part

        private double Real;
        private double Imaginary;
        public double Re
        {
            get
            {
                return Real;
            }
            set
            {
                Real = value;
            }
        }
        public double Im
        {
            get
            {
                return Imaginary;
            }
            set
            {
                Imaginary = value;
            }
        }

        //constructors

        public ComplexNumber(double a, double b)
        {
            this.Real = a;
            this.Imaginary = b;
        }

        public ComplexNumber()
        {
            this.Real = 0;
            this.Imaginary = 0;
        }

        //overload simple arifmetic operators

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            ComplexNumber Result = new ComplexNumber();
            Result.Re = a.Re + b.Re;
            Result.Im = a.Im + b.Im;
            return Result;
        }

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            ComplexNumber Result = new ComplexNumber();
            Result.Re = a.Re - b.Re;
            Result.Im = a.Im - b.Im;
            return Result;
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            ComplexNumber Result = new ComplexNumber();
            Result.Re = a.Re * b.Re - a.Im * b.Im;
            Result.Im = a.Re * b.Im + a.Im * b.Re;
            return Result;
        }

        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            ComplexNumber Result = new ComplexNumber();
            Result.Re = (a.Re * b.Re + a.Im * b.Im) / (b.Re * b.Re + b.Im * b.Im);
            Result.Im = (a.Im * b.Re - a.Re * b.Im) / (b.Re * b.Re + b.Im * b.Im);
            return Result;
        }

        //overload methods ToSring() and Equals()
        
        public override string ToString()
        {
            if (this.Re == 0 || this.Im == 0)
            {
                return ("0");
            }
            else if (this.Re == 0)
            {
                return String.Format("{0} * i", this.Im);
            }
            else if (this.Im == 0)
            {
                return String.Format("{0}", this.Re);
            }
            else
            {
                return String.Format("{0} + {1} * i", this.Re, this.Im);
            }
        }

        public static bool Equals(ComplexNumber obj1, ComplexNumber obj2)
        {
            if (obj1 != null || obj2 != null)
            {
                return (obj1.Re == obj2.Re || obj1.Im == obj2.Im);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        //write on consol
        
        public void Write()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
