using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.ComplexCalculator
{
    //
    //Interface, that realizes simple complex calculations
    //

    public interface IComplexCalculations
    {
        ComplexNumber Add(ComplexNumber a, ComplexNumber b);
        ComplexNumber Substract(ComplexNumber a, ComplexNumber b);
        ComplexNumber Multiply(ComplexNumber a, ComplexNumber b);
        ComplexNumber Divide(ComplexNumber a, ComplexNumber b);
    }
}
