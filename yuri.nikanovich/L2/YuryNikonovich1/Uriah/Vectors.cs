using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uriah
{
    public class Vector
    {
        public double X {get; set; }
        public double Y {get; set; }

		public Vector(double x, double y)
		{
			X = x;
			Y = y;
		}

		public Vector()
		{
			X = 0;
			Y = 0;
		}

		public static Vector operator +(Vector firstVector, Vector secondVector)
        {
			Vector resultVector = new Vector();
			resultVector.X = firstVector.X + secondVector.X;
			resultVector.Y = firstVector.Y + secondVector.Y;
			return resultVector;
        }

		public static Vector operator *(Vector firstVector, double lambda)
        {
            Vector resultVector = new Vector();
			resultVector.X = firstVector.X * lambda;
			resultVector.Y = firstVector.Y * lambda;
			return resultVector;
        }

		public static Vector operator *( double lambda, Vector firstVector)
		{
			Vector resultVector = new Vector();
			resultVector.X = firstVector.X * lambda;
			resultVector.Y = firstVector.Y * lambda;
			return resultVector;
		}

		public static double operator *(Vector firstVector, Vector secondVector)
        {
			return firstVector.X * secondVector.X + firstVector.Y * secondVector.Y;
        }

		public override bool Equals(Object obj)
        {
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			Vector firstVector = (Vector)obj;
			return (X == firstVector.X) && (Y == firstVector.Y);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

		public override string ToString()
		{
			return (System.String.Format("({0},{1})", X, Y));
		}

    }
}
