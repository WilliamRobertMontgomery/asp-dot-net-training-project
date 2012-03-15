using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Calculator
{
    public interface ICalculator<Type>
    {
        Type Add(Type a, Type b);
        Type Subtracht(Type a, Type b);
        Type Multiply(Type a, Type b);
        Type Divide(Type a, Type b);
    }
}
