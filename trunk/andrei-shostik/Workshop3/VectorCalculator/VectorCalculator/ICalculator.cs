using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorCalculator
{
    public interface ICalculator<T>
    {
        T Add(T param);

        T Substruct(T param);

        T Multiply(T param);

        T Divide(T param);
    }
}
