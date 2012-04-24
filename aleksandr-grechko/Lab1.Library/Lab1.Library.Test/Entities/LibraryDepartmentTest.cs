using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab1.Library.Entities;

namespace Lab1.Library.Test.Entities
{
	[TestFixture]
	public class LibraryDepartmentTest
	{
		LibraryDepartment ld1, ld2, ld3;

		public LibraryDepartmentTest()
		{
			ld1 = new LibraryDepartment("Name1", true);
			ld2 = new LibraryDepartment("Name2", false);
			ld3 = new LibraryDepartment(ld1.Id, "Name1", true);
		}

		[Test]
		public void EqualsTest()
		{
			Assert.AreNotEqual(ld1, ld2);
			Assert.AreEqual(ld1, ld3);
		}

		[Test]
		public void EqualTest()
		{
			Assert.IsFalse(ld1 == ld2);
			Assert.IsTrue(ld1 == ld3);
		}

		[Test]
		public void NotEqualTest()
		{
			Assert.IsTrue(ld1 != ld2);
			Assert.IsFalse(ld1 != ld3);
		}

		[Test]
		public void GetHashCode_Equal_LibraryDepartment_Test()
		{
			Assert.AreEqual(ld1, ld3);
			Assert.AreEqual(ld1.GetHashCode(), ld3.GetHashCode());
		}

		[Test]
		public void GetHashCode_Not_Equal_LibraryDepartment_Test()
		{
			Assert.AreNotEqual(ld1, ld2);
			Assert.AreNotEqual(ld1.GetHashCode(), ld2.GetHashCode());
		}

	}
}
