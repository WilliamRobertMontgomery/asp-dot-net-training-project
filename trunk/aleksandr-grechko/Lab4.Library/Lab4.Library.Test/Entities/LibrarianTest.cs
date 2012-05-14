using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab4.Library.Models;

namespace Lab4.Library.Test.Entities
{
	[TestFixture]
	public class LibrarianTest
	{
		Librarian l1, l2, l3;

		public LibrarianTest()
		{
			l1 = new Librarian("Name1", new LibraryDepartment("Абонемент", true));
			l2 = new Librarian("Name2", new LibraryDepartment("Читальный зал", false));
			l3 = new Librarian(l1.Id, l1.FullName, l1.Department);
		}

		[Test]
		public void EqualsTest()
		{
			Assert.AreNotEqual(l1, l2);
			Assert.AreEqual(l1, l3);
		}

		[Test]
		public void EqualTest()
		{
			Assert.IsFalse(l1 == l2);
			Assert.IsTrue(l1 == l3);
		}

		[Test]
		public void NotEqualTest()
		{
			Assert.IsTrue(l1 != l2);
			Assert.IsFalse(l1 != l3);
		}

		[Test]
		public void GetHashCode_Equal_Librarian_Test()
		{
			Assert.AreEqual(l1, l3);
			Assert.AreEqual(l1.GetHashCode(), l3.GetHashCode());
		}

		[Test]
		public void GetHashCode_Not_Equal_Librarian_Test()
		{
			Assert.AreNotEqual(l1, l2);
			Assert.AreNotEqual(l1.GetHashCode(), l2.GetHashCode());
		}
	}
}
