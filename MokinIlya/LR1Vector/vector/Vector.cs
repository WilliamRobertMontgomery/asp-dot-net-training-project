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

        private int _len;

        public int Len
        {
            get
            {
                return _len;
            }
        }

        //Metods
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

        public vector Multiply(vector a)
        {
            if (a.Len == Len)
            {
                vector outPerem=this.Clone();

                //formula(example): (a1,a2,a3)*(b1,b2,b3)=(a2b3-a3b2,a3b1-a1b3,a1b2-a2b1)
                for (int i = 0; i < Len; i++)
                {
                    //[i+n] ?? - seen overriding of indexer
                    outPerem[i] = this[i+1]*a[i+2]-this[i+2]*a[i+1];
                }
                return outPerem;
            }
            else return this;

            throw new NotImplementedException();
        }

        public vector Multiply(double a)
        {
            vector outPerem = this.Clone();

            //formula(example): (a1,a2)*b=(a1*b,a2*b)
            for (int i = 0; i < _len; i++)
            {
                outPerem[i] = x[i] * a;
            }
            return outPerem;

            throw new NotImplementedException();
        }

        public vector Divide(double a)
        {
            vector outPerem = this.Clone();

            //formula(example): (a1,a2)*b=(a1*b,a2*b)
            for (int i = 0; i < _len; i++)
            {
                outPerem[i] = x[i] / a;
            }
            return outPerem;

            throw new NotImplementedException();
        }

        public vector Sum(vector a)
        {
            if (a.Len == x.Length)
            {
                vector outPerem = this.Clone();

                //formula(example): (a1,a2)+(b1,b2)=(a1+b1,a2+b2)
                for (int i = 0; i < _len; i++)
                {
                    outPerem[i] = x[i] + a[i];
                }
                return outPerem;
            }
            else return this;
            throw new NotImplementedException();
        }

        public vector Minus(vector a)
        {
            if (a.Len == x.Length)
            {
                vector outPerem = this.Clone() ;

                //formula(example): (a1,a2)-(b1,b2)=(a1-b1,a2-b2)
                for (int i = 0; i < _len; i++)
                {
                    outPerem[i] = x[i] - a[i];
                }
                return outPerem;
            }
            else return this;
            throw new NotImplementedException();
        }

        //overrides && determines some methods
        public double this[int idx] //determining of indexer
        {
            get
            {
                if (idx < Len)
                {
                    return x[idx];
                }
                else
                {
                    return x[idx % (Len-1)];
                }
            }
            set
            {
                x[idx]= value;
            }

        }

        public override bool Equals(Object a) //overriding of Equals
        {
            if (a != null)
            {
                if (this.GetHashCode() ==  ((vector) a).GetHashCode())
                {
                    return true;
                }
            }
            return false;
        }

        public vector Clone() //determining of Clone
        {
            double[] cloneX = (double[]) x.Clone();
            vector clone = new vector(cloneX);
            return clone;
        }

        public override string ToString() //overriding of ToString
        {

            if (Len > 0)
            {
                //example of output: "( 0.50, 4.20, 5.49 )"
                string resultString = "( ";
                for (int i = 0; i < this.Len; i++)
                {
                    if (i != 0)
                    {
                        resultString += "; ";
                    }
                    resultString += this[i].ToString("0.00");
                    if (i == Len - 1)
                    {
                        resultString += " )";
                    }
                }
                return resultString;
            }
            else return "";

        }

        public override int GetHashCode() //overriding of GetHashCode
        {
            int hashCode=1;
            for (int i = 0; i < Len; i++)
            {
                hashCode = hashCode ^ ((int) x[i]);
            }
            return hashCode;
        }

        //overloads
        public static vector operator +(vector a, vector b)
        {
            return a.Sum(b);
        }

        public static vector operator -(vector a, vector b)
        {
            return a.Minus(b);
        }

        public static vector operator *(vector a, vector b)
        {
            return a.Multiply(b);
        }

        public static vector operator *(vector a, double b)
        {
            return a.Multiply(b);
        }

        public static vector operator *(double b, vector a)
        {
            return a.Multiply(b);
        }

        public static vector operator /(vector a, double b)
        {
            return a.Divide(b);
        }

        public static bool operator ==(vector a, vector b)
        {
            return a.Equals((object)b);
        }

        public static bool operator !=(vector a, vector b)
        {
            if (a != null)
            {
                if (a.Equals((object)b))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else return false;
        }
    }
}
