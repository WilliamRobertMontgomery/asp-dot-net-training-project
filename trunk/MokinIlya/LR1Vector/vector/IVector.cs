using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathematicalObj
{
    public interface IVector
    {
        double Module();
        double[] Multiply(double[] a);
        double[] Multiply(double a);
        double[] Sum(double[] a);
        double[] Sum(double a);
        double[] Divide(double[] a);
        double[] Divide(double a);
    }
}
