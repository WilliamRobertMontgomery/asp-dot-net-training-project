using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uriah
{
    public interface IVectors
    {
        public IVectors Sum(IVectors firstVector, IVectors secondVector);
        public IVectors Substruction(IVectors firstVector, IVectors secondVector);
        public IVectors MultiplyOnNumber(IVectors firstVector, double lambda);
        public double ScaleMultiply(IVectors firstVector, IVectors secondVector);

    }
}
