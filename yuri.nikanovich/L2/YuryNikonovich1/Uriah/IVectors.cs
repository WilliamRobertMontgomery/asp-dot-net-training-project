using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uriah
{
    public interface IVectors
    {
        IVectors Sum(IVectors firstVector, IVectors secondVector);
        IVectors MultiplyOnNumber(IVectors firstVector, double lambda);
        double ScaleMultiply(IVectors firstVector, IVectors secondVector);

    }
}
