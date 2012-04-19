using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Complex
{
    interface IComplex
    {
        Complex Sum(Complex number);
        Complex Subtract(Complex number);
        Complex Multiply(Complex number);
        Complex Divide(Complex number);
        double Module();
    }
}
