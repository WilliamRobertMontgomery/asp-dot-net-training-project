using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uriah
{
    public class Vectors : IVectors
    {
        public double X {get; set; }
        public double Y {get; set; }
        public double Z {get; set; }

        public IVectors Sum(IVectors firstVector, IVectors secondVector)
        {
            throw new NotImplementedException();
        }

        public IVectors Substruction(IVectors firstVector, IVectors secondVector)
        {
            throw new NotImplementedException();
        }

        public IVectors MultiplyOnNumber(IVectors firstVector, double lambda)
        {
            throw new NotImplementedException();
        }

        public double ScaleMultiply(IVectors firstVector, IVectors secondVector)
        {
            throw new NotImplementedException();
        }
    }
}
