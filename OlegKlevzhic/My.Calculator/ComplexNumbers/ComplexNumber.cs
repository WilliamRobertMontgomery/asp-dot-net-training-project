using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Calculator.ComplexNumbers
{
    public struct ComplexNumber
    {
        public double re;
        public double im;

        public ComplexNumber(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public override string ToString()
        {
            if (re == 0 && im == 0)
            {
                return "0";
            }
            else
                if (re == 0)
                {
                    return "i" + im.ToString();
                }
                else
                    if (im == 0)
                    {
                        return re.ToString();
                    }
                    else
                        if (im < 0)
                        {
                            return re.ToString() + "i" + im.ToString();
                        }
                        else
                        {
                            return re.ToString() + "+" + "i" +  im.ToString();
                        }
        }

        public override bool Equals(System.Object _object)
        {
            if (_object == null)
            {
                return false;
            }

            return (re == ((ComplexNumber)(_object)).re) && (im == ((ComplexNumber)(_object)).im);
        }

        public bool Equals(ComplexNumber complexNumber)
        {
            if ((object)complexNumber == null)
            {
                return false;
            }

            return (re == complexNumber.re) && (im == complexNumber.im);
        }

        public override int GetHashCode()
        {
            return (int)re ^ (int)im;
        }

    }
}
