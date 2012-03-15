using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Calculator
{
    public class Calculator: ICalculator<double>
    {

        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtracht(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException ex)
            {
                throw new DivideByZeroException(ex.Message);
            }
        }
    }
}
