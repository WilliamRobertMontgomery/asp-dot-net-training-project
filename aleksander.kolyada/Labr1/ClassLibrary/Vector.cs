using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Vector
    {
       private double x, y; //vector coordinates

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }

        public static Vector Sum(Vector A, Vector B)
        {
            Vector C = new Vector(A.x+B.x,A.y+B.y);
            return C;
        }
    }
}
