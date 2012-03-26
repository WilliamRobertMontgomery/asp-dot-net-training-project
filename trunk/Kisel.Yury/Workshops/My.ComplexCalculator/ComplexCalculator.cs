using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.ComplexCalculator
{
    //
    //Calculator for complex numbers
    //

    public class ComplexCalculator : IComplexCalculations
    {                
        public ComplexNumber Add(ComplexNumber a, ComplexNumber b)
        {
            return a + b;
        }

        public ComplexNumber Substract(ComplexNumber a, ComplexNumber b)
        {
            return a - b;
        }

        public ComplexNumber Multiply(ComplexNumber a, ComplexNumber b)
        {
            return a * b;
        }

        public ComplexNumber Divide(ComplexNumber a, ComplexNumber b)
        {
            if (b.Im != 0 || b.Re != 0)
            {
                return a / b;
            }
            else
            {
                throw new DivideByZeroException();
            }
        }
    }
}
