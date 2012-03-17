using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexNumber
{
    public interface IComplex
    {
        complex Add(complex a, complex b);
        complex Subtract(complex a, complex b);
        complex Multiply(complex a, complex b);
        complex Divide(complex a, complex b);
        void Print(complex a);

        double re
        {
            get;
            set;
        }

        double im
        {
            get;
            set;
        }



    }
}
