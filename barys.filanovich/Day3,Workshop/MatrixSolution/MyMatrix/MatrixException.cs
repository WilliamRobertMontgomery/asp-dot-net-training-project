using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMatrix
{
    class MatrixException : Exception
    {
        public MatrixException() : base() { }
        public MatrixException(string str) : base(str) { }
        public MatrixException(string str, Exception inner) : base(str, inner) { }
        protected MatrixException(
            System.Runtime.Serialization.SerializationInfo si,
            System.Runtime.Serialization.StreamingContext sc)
            : base(si, sc) { }

        public override string ToString()
        {
            return this.Message;
        }
    }
}
