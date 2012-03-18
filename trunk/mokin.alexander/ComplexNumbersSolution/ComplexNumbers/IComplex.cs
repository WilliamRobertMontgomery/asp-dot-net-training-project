using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexNumbers
{
    interface IComplex
    {
        
        Complex Add(Complex a, Complex b);
        Complex Add(Complex a, double b);
  
        Complex Subtract(Complex a, Complex b);
        Complex Subtract(Complex a, double b);
       
        Complex Multiply(Complex a, Complex b);
        Complex Multiply(Complex a, double b);

        Complex Devide(Complex a, Complex b);
        Complex Devide(Complex a, double b);              
    }
}
