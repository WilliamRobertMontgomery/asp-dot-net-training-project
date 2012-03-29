using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Vector
{
    class Vector
    {
        // fields
        private double _x;
        private double _y;
        private double _z;

        // properties
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }
        
        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }

        // Constructors
        public Vector(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector(Vector r)
        {
            X = r.X;
            Y = r.Y;
            Z = r.Z;
        }

        // overriding ToString method
        public override string ToString()
        {
            return "( " + X + " , " + Y + " , " + Z + " )";
        }

        //overloading multiply operator
        // multiplying vector by scalar
        public static Vector operator * (double scl, Vector a)
        {
            return new Vector(scl * a.X, scl * a.Y, scl * a.Z);
        }

        // overloading operator of addition
        public static Vector operator + (Vector a, Vector b)
        {
            Vector result = new Vector(a);
            result.X += b.X;
            result.Y += b.Y;
            result.Z += b.Z;
            return result;
        }

        //overloading multiply operator
        //scalar myltiplying
        public static double operator * (Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        //overloading comparison operators
        public static bool operator ==(Vector a, Vector b)
        {
            if (a.X == b.X && a.Y == b.Y && a.Z == b.Z)
                return true;
            else 
                return false;
        }

        public static bool operator !=(Vector a, Vector b)
        {
                return !(a == b);
        }

    }
 
}
