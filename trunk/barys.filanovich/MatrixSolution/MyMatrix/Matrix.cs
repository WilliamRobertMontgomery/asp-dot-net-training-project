using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMatrix
{
    public class Matrix
    {
        int rows;
        int columns;
        int[,] matrix;

        public Matrix(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            matrix = new int[Rows, Columns];
        }
        
        public int Rows
        {
            get
            {
                return this.rows;
            }
            private set
            {
                if (value >= 1)
                {
                    this.rows = value;
                }
                else
                {
                    throw new MatrixException("Rows is less then 1!");
                }
            }
        }
       
        public int Columns
        {
            get
            {
                return this.columns;
            }
            private set
            {
                if (value >= 1)
                {
                    this.columns = value;
                }
                else
                {
                    throw new MatrixException("Colums is less then 1!");
                }
            }
        }

        public int this[int index1, int index2]
        {
            get
            {
                if (IndexTrue(index1, index2))
                    return this.matrix[index1, index2];
                else
                    throw new MatrixException("Range error!");
            }
            set
            {
                if (IndexTrue(index1, index2))
                    this.matrix[index1, index2] = value;
                else
                    throw new MatrixException("Range error!");
            }
        }

        static bool GoodForAddition(Matrix mx1, Matrix mx2)
        {
            if ((mx1.Rows == mx2.Rows) & (mx1.Columns == mx2.Columns))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool GoodForMult(Matrix mx1, Matrix mx2)
        {
            if (mx1.columns == mx2.Rows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool IndexTrue(int index1, int index2)
        {
            if ((index1 >= 0 & index1 < this.Rows) & (index2 >= 0 & index2 < this.Columns))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Matrix operator +(Matrix mx1, Matrix mx2)
        {
            if (!GoodForAddition(mx1, mx2))
            {
                throw new MatrixException("Addition these matrix is impossibly!");
            }

            Matrix result = new Matrix(mx1.Rows, mx1.Columns);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Columns; col++)
                {
                    result[row, col] = mx1[row, col] + mx2[row, col];
                }
            }

            return result;
        }

        public static Matrix operator *(int number, Matrix mx)
        {
            Matrix result = new Matrix(mx.Rows, mx.Columns);
            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Columns; col++)
                {
                    result[row, col] = 2 * mx[row, col];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix mx, int number)
        {
            return number * mx;
        }

        public static Matrix operator *(Matrix mx1, Matrix mx2)
        {
            if (!GoodForMult(mx1, mx2))
            {
                throw new MatrixException("Multiplication these matrix is impossibly!");
            }

            Matrix result = new Matrix(mx1.Rows, mx2.Columns);

            for (int rowRes = 0; rowRes < result.Rows; rowRes++)
            {
                for (int colRes = 0; colRes < result.Columns; colRes++)
                {
                    int resCell = 0;
                    for (int colMx1 = 0; colMx1 < mx1.Columns; colMx1++)
                    {
                        resCell += mx1[rowRes, colMx1] * mx2[colMx1, colRes];
                    }
                    result[rowRes, colRes] = resCell;
                }
            }

            return result;
        }

        public static bool operator ==(Matrix mx1, Matrix mx2)
        {
            if (mx1.Columns != mx2.Columns || mx1.Rows != mx2.Rows)
                return false;

            for (int row = 0; row < mx1.Rows; row++)
            {
                for (int col = 0; col < mx1.Columns; col++)
                {
                    if (mx1[row, col] != mx2[row, col])
                        return false;
                }
            }

            return true;
        }

        public static bool operator !=(Matrix mx1, Matrix mx2)
        {
            if (mx1 == mx2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object input)
        {
            if (input is Matrix && input != null)
            {
                return this == input;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    str.AppendFormat("{0}\t", this[row, col]);
                }
                str.Append("\n");
            }
            return str.ToString();
        }

    }
}
