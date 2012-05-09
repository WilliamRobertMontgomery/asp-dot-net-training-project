using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab2.Library.DataModel;

namespace Lab2.Library.Test.Entities
{
	[TestFixture]
	public class ReaderTest
	{
		Reader r1, r2, r3;

		public ReaderTest()
		{
			r1 = new Reader("Name1", "Address1");
			r2 = new Reader("Name2", "Address2");
			r3 = new Reader(r1.Id, "Name1", "Address1");
		}

		[Test]
		public void EqualsTest()
		{
			Assert.AreNotEqual(r1, r2);
			Assert.AreEqual(r1, r3);
		}

		[Test]
		public void EqualTest()
		{
			Assert.IsFalse(r1 == r2);
			Assert.IsTrue(r1 == r3);
		}

		[Test]
		public void NotEqualTest()
		{
			Assert.IsTrue(r1 != r2);
			Assert.IsFalse(r1 != r3);
		}

		[Test]
		public void GetHashCode_Equal_Reader_Test()
		{
			Assert.AreEqual(r1, r3);
			Assert.AreEqual(r1.GetHashCode(), r3.GetHashCode());
		}

		[Test]
		public void GetHashCode_Not_Equal_Reader_Test()
		{
			Assert.AreNotEqual(r1, r2);
			Assert.AreNotEqual(r1.GetHashCode(), r2.GetHashCode());
		}

	}
}
