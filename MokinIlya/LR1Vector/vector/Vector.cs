using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathematicalObj
{
    public class vector: IVector
    {
        private double[] x;

        public vector(double[] a)
        {
            x = a;
            _len = a.Length;
        }

        public int _len;

        public double Module()
        {
            double outPerem=0;
            for (int i = 0; i < _len; i++)
            {
                outPerem += Math.Pow(x[i], 2);
            }
            return Math.Sqrt(outPerem);
            throw new NotImplementedException();
        }

        public double[] Multiply(double[] a)
        {
            if (a.Length == x.Length)
            {
                double[] outPerem=x;
                for (int i = 0; i < _len; i++)
                {
                    outPerem[i] = x[i]*a[i];
                }
                return outPerem;
            }
            else return x;
            throw new NotImplementedException();
        }

        public double[] Multiply(double a)
        {
            double[] outPerem = x;
            for (int i = 0; i < _len; i++)
            {
                outPerem[i] = x[i] * a;
            }
            return outPerem;

            throw new NotImplementedException();
        }

        public double[] Sum(double[] a)
        {
            if (a.Length == x.Length)
            {
                double[] outPerem = x;
                for (int i = 0; i < _len; i++)
                {
                    outPerem[i] = x[i] + a[i];
                }
                return outPerem;
            }
            else return x;
            throw new NotImplementedException();
        }

        public double[] Sum(double a)
        {
            double[] outPerem = x;
            for (int i = 0; i < _len; i++)
            {
                outPerem[i] = x[i] + a;
            }
            return outPerem;
            throw new NotImplementedException();
        }

        public double[] Divide(double[] a)
        {
            if (a.Length == x.Length)
            {
                double[] outPerem = x;
                for (int i = 0; i < _len; i++)
                {
                    outPerem[i] = x[i] / a[i];
                }
                return outPerem;
            }
            else return x;
            throw new NotImplementedException();
        }

        public double[] Divide(double a)
        {
            double[] outPerem = x;
            for (int i = 0; i < _len; i++)
            {
                outPerem[i] = x[i] / a;
            }
            return outPerem;
            throw new NotImplementedException();
        }

    }
}
