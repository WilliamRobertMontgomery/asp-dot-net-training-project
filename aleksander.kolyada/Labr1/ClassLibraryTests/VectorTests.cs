using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ClassLibrary;

namespace ClassLibraryTests
{
    [TestFixture]
    public class VectorTests
    {
        [Test]
        public void TestSum()
        {
            Vector a = new Vector(1, 2), b = new Vector(2, 3), c;
            c = Vector.Sum(a, b);
            double actualX = c.GetX();
            double expectedX = 3;
            double actualY = c.GetY();
            double expectedY = 5;
            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);
        }
    }
}
