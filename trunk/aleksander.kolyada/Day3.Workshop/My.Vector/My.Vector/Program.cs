using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Vector
{
    class Program
    {
        static void Main(string[] args)
        {

            Vector vect1 = new Vector(3.0, 3.0, 1.0);
            Vector vect2 = new Vector(2.0, -4.0, -4.0);
            Vector vect3;
            //addition of vectors
            vect3 = vect1 + vect2;
            Console.WriteLine("vect1 = " + vect1);
            Console.WriteLine("vect2 = " + vect2);
            Console.WriteLine("vect3 = " + vect3);
            //multiply vector by scalar
            Console.WriteLine("2*vect3 = " + 2*vect3);
            //scalar myltiplying
            double sclm = vect1 * vect2;
            Console.WriteLine("vect1*vect2 = " + sclm);
            Console.ReadKey();
        }
    }
}
