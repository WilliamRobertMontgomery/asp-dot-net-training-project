namespace VectorCalculator
{
    using System;
    using System.Linq;
    using System.Text;

    public class Vector : ICalculator<double[]>
    {
        private Vector() {}

        /// <summary>
        /// Initializes a new instance of the class for an array
        /// </summary>
        /// <param name="vector">New vector as array of double[]</param>
        public Vector(double[] vector)
        {
            this.DataVector = vector;
        }

        /// <summary>
        /// New vector as array of double
        /// </summary>
        public double[] DataVector { get; private set; }

        /// <summary>
        /// Indexing vector
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>value of the vector</returns>
        public double this[int i]
        {
            get
            {
                return DataVector[i];
            }
            set
            {
                DataVector[i] = value;
            }
        }

        #region Actions on vectors

        /// <summary>
        /// Addition of two vectors
        /// </summary>
        /// <param name="vector">Vector as array of double[].</param>
        public double[] Add(double[] vector)
        {
            CheckVectors(DataVector, vector);
            var result = new double[DataVector.Length];

            for (int i = 0; i < DataVector.Length ; i++)
            {
                result[i] = DataVector[i] + vector[i];
            }
            return result;
        }

        /// <summary>
        /// Subtracts the second vector from the first
        /// </summary>
        /// <param name="vector">Vector as array of double[].</param>
        public double[] Substruct(double[] vector)
        {
            CheckVectors(DataVector, vector);
            var result = new double[DataVector.Length];

            for (int i = 0; i < DataVector.Length; i++)
            {
                result[i] = DataVector[i] - vector[i];
            }
            return result;
        }

        /// <summary>
        /// Multiplies two vectors
        /// </summary>
        /// <param name="vector">Vector as array of double[].</param>
        public double[] Multiply(double[] vector)
        {
            CheckVectors(DataVector, vector);
            var result = new double[DataVector.Length];

            for (int i = 0; i < DataVector.Length; i++)
            {
                result[i] = DataVector[i] * vector[i];
            }
            return result;
        }

        /// <summary>
        /// Multiplying a vector by a scalar
        /// </summary>
        /// <param name="scalar"></param>
        public double[] Multiply(double scalar)
        {
            if (DataVector == null)
            {
                throw new ArgumentNullException("Vector is not defined");
            }

            var result = new double[DataVector.Length];

            for (int i = 0; i < DataVector.Length; i++)
            {
                result[i] = DataVector[i] * scalar;
            }
            return result;
        }

        /// <summary>
        /// Scalar multiply of two vectors
        /// </summary>
        /// <param name="vector">another vector</param>
        /// <returns>Scalar multiply</returns>
        public double MultiplyScalar(double[] vector)
        {
            CheckVectors(DataVector, vector);

            return this.DataVector.Select((value, i) => value * vector[i]).Sum();
        }

        /// <summary>
        /// Division two vectors
        /// </summary>
        /// <param name="vector">Vector as array of double[]. Implicity conversion</param>
        public double[] Divide(double[] vector)
        {
            CheckVectors(DataVector, vector);
            var result = new double[DataVector.Length];

            for (int i = 0; i < DataVector.Length; i++)
            {
                ThrowDivideByZeroException(vector[i]);
                result[i] = DataVector[i] / vector[i];
            }
            return result;
        }

        #endregion

        #region Checking for exceptions

        /// <summary>
        /// Checks on the length of two vectors
        /// </summary>
        /// <param name="firstVector">First vector</param>
        /// <param name="secondVector">Second vector</param>
        private static void CheckVectors(double[] firstVector, double[] secondVector)
        {
            if (firstVector == null || secondVector == null)
            {
                throw new ArgumentNullException(string.Format("Only {0} is defined", firstVector ?? secondVector));
            }

            if (firstVector.Length != secondVector.Length)
            {
                throw new ArgumentException("Vectors' lengths aren't equal");
            }
        }

        /// <summary>
        /// Throw a divide by zero exceptio for test method
        /// </summary>
        private static void ThrowDivideByZeroException(double vectorValue)
        {
            if (Equals(vectorValue, 0.0))
            {
                throw new DivideByZeroException("ohh nooo, not a zero, again");
            }
        }

        #endregion

        #region Overload operations

        /// <summary>
        /// Overloading the addition operator
        /// </summary>
        /// <returns>Sum of two vectors</returns>
        public static double[] operator +(Vector firstVector, Vector secondVector)
        {
            CheckVectors(firstVector, secondVector);
            return firstVector.Add(secondVector);
        }

        /// <summary>
        /// Overload the subtraction operator. Subtracts the second vector from the first
        /// </summary>
        /// <returns>Subtraction of two vectors</returns>
        public static double[] operator -(Vector firstVector, Vector secondVector)
        {
            CheckVectors(firstVector, secondVector);
            return firstVector.Substruct(secondVector);
        }

        /// <summary>
        /// Overloading the multiplication operator
        /// </summary>
        /// <returns>Multiplication of two vectors</returns>
        public static double[] operator *(Vector firstVector, Vector secondVector)
        {
            CheckVectors(firstVector, secondVector);
            return firstVector.Multiply(secondVector);
        }

        /// <summary>
        /// Overloading the division operator
        /// </summary>
        /// <returns>Division of two vectors</returns>
        public static double[] operator /(Vector firstVector, Vector secondVector)
        {
            CheckVectors(firstVector, secondVector);
            return firstVector.Divide(secondVector);
        }

        #endregion

        #region Conversion operations

        /// <summary>
        /// Implicit type conversion of "Vector" type to "double[]"
        /// </summary>
        public static implicit operator double[](Vector vectorTypeOfVector)
        {
            if (vectorTypeOfVector == null)
            {
                throw new ArgumentNullException();
            }
            return vectorTypeOfVector.DataVector;
        }

        /// <summary>
        /// Implicit type conversion of type "double[]" to "Vector"
        /// </summary>
        public static implicit operator Vector(double[] vectorTypeOfDouble)
        {
            if (vectorTypeOfDouble == null)
            {
                throw new ArgumentNullException();
            }
            return new Vector(vectorTypeOfDouble);
        }
        #endregion

        #region Overrided methods

        /// <summary>
        /// Override ToString method
        /// </summary>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder("Vector data: ");

            foreach (var value in this.DataVector)
            {
                stringBuilder.AppendFormat("[{0}]", value);
            }

            return stringBuilder.Append(";").ToString();
        }

        /// <summary>
        /// Ovveride Equals method
        /// </summary>
        /// <param name="obj">object to compare</param>
        public override bool Equals(object obj)
        {
            double[] tempV = obj as dynamic;
            CheckVectors(DataVector, tempV);
            
            return this.DataVector
                .Select((vector, i) => !Equals(vector, tempV[i]))
                .Any(elem => false);
        }

        /// <summary>
        /// Ovveride GetHashCode method
        /// </summary>
        /// <returns>new mega-supper-pupper hashcode</returns>
        public override int GetHashCode()
        {
            return this.DataVector
                .Aggregate(0, (current, value) => current ^ value.GetHashCode());
        }

        #endregion
    }
}
