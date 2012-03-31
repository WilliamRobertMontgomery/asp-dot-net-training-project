﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MyMatrix;

namespace MyMatrixTests
{
    public class MatrixTests
    {
        private Matrix expectedMatrix;
        private Matrix actualMatrix;

        Matrix GetMatrix1()
        {
            Matrix matrix1 = new Matrix(2, 3);
           
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 3;
            matrix1[0, 2] = 1;
            matrix1[1, 0] = 1;
            matrix1[1, 1] = 0;
            matrix1[1, 2] = 0;

            return matrix1;
        }

        Matrix GetMatrix2()
        {
            Matrix matrix2 = new Matrix(2, 3);
            
            matrix2[0, 0] = 0;
            matrix2[0, 1] = 0;
            matrix2[0, 2] = 5;
            matrix2[1, 0] = 7;
            matrix2[1, 1] = 5;
            matrix2[1, 2] = 0;

            return matrix2;
        }

        Matrix GetMatrix3()
        {
            Matrix matrix3 = new Matrix(3, 1);
           
            matrix3[0, 0] = 1;
            matrix3[1, 0] = 4;
            matrix3[2, 0] = 3;

            return matrix3;
        }

        Matrix GetMatrix4()
        {
            Matrix matrix4 = new Matrix(1, 3);
            
            matrix4[0, 0] = 2;
            matrix4[0, 1] = 4;
            matrix4[0, 2] = 1;

            return matrix4;
        }

        [Test]
        public void Addition()
        {
            /*  Addition
             * 
             *   Matrix 1   +   Matrix 2    =   expectedMatrix
             *   
             *  |1  3   1|   +   |0  0   5|   =   |1  3   6|
             *  |1  0   0|       |7  5   0|       |8  5   0|
             */

            expectedMatrix = new Matrix(2, 3);

            expectedMatrix[0, 0] = 1;
            expectedMatrix[0, 1] = 3;
            expectedMatrix[0, 2] = 6;
            expectedMatrix[1, 0] = 8;
            expectedMatrix[1, 1] = 5;
            expectedMatrix[1, 2] = 0;

            actualMatrix = GetMatrix1() + GetMatrix2();

        }

        [Test]
        public void ScalarMultiplication()
        {
            /*  Scalar Multiplication
             * 
             *   Scalar   *   Matrix 2    =   expectedMatrix
             *   
             *      2   *   |0  0   5|   =   |0   0   10|
             *              |7  5   0|       |14  10   0|
             */

            expectedMatrix = new Matrix(2, 3);

            expectedMatrix[0, 0] = 0;
            expectedMatrix[0, 1] = 0;
            expectedMatrix[0, 2] = 10;
            expectedMatrix[1, 0] = 14;
            expectedMatrix[1, 1] = 10;
            expectedMatrix[1, 2] = 0;

            actualMatrix = 2 * GetMatrix2();
        }

        [Test]
        public void MatrixMultiplicationV1()
        {
            /*  Matrix Multiplication
             * 
             *   Matrix 3   *   Matrix 4    =   expectedMatrix
             *   
             *  |1|                       |2   4   1|
             *  |4|   *   |2  4  1|   =   |8  16   4|
             *  |3|                       |6  12   3|
             */

            expectedMatrix = new Matrix(3, 3);

            expectedMatrix[0, 0] = 2;
            expectedMatrix[0, 1] = 4;
            expectedMatrix[0, 2] = 1;
            expectedMatrix[1, 0] = 8;
            expectedMatrix[1, 1] = 16;
            expectedMatrix[1, 2] = 4;
            expectedMatrix[2, 0] = 6;
            expectedMatrix[2, 1] = 12;
            expectedMatrix[2, 2] = 3;

            actualMatrix = GetMatrix3() * GetMatrix4();
        }

        [Test]
        public void MatrixMultiplicationV2()
        {
            /*  Matrix Multiplication
             * 
             *   Matrix 4 * Matrix 3 = expectedMatrix
             *   
             *                  |1|       
             *  |2  4  1|   *   |4|   =   |21|
             *                  |3|       
             */

            expectedMatrix = new Matrix(1, 1);

            expectedMatrix[0, 0] = 21;
 
            actualMatrix = GetMatrix4() * GetMatrix3();
        }

    }
}
