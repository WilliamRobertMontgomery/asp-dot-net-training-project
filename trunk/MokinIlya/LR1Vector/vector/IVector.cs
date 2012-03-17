using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathematicalObj
{
    public interface IVector
    {
        double Module();
        vector Multiply(vector a);
        vector Multiply(double a);
        vector Divide(double a);
        vector Sum(vector a);
        vector Minus(vector a);

        bool Equals(Object a);
        vector Clone();
        string ToString();
        int GetHashCode();
    }
}
