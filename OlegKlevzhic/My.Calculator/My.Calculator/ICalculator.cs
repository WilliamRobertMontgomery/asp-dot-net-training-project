using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Calculator
{
    public interface ICalculator<T>
    {
        T Add(T a, T b);
        T Subtracht(T a, T b);
        T Multiply(T a, T b);
        T Divide(T a, T b);
    }
}
