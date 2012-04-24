using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab1.Library.Entities;

namespace Lab1.Library.Test.Entities
{
	[TestFixture]
	public class BookTest
	{
		Book b1, b2, b3;

		public BookTest()
		{
			b1 = new Book("Author1", "Title1", 1999, new LibraryDepartment("Абонемент", true));
			b2 = new Book("Author2", "Title2", 2000, new LibraryDepartment("Читальный зал", false));
			b3 = new Book(b1.Id, "Author1", "Title1", 1999, b1.Department);
		}

		[Test]
		public void EqualsTest()
		{
			Assert.AreNotEqual(b1, b2);
			Assert.AreEqual(b1, b3);
		}

		[Test]
		public void EqualTest()
		{
			Assert.IsFalse(b1 == b2);
			Assert.IsTrue(b1 == b3);
		}

		[Test]
		public void NotEqualTest()
		{
			Assert.IsTrue(b1 != b2);
			Assert.IsFalse(b1 != b3);
		}

		[Test]
		public void GetHashCode_Equal_Book_Test()
		{
			Assert.AreEqual(b1, b3);
			Assert.AreEqual(b1.GetHashCode(), b3.GetHashCode());
		}

		[Test]
		public void GetHashCode_Not_Equal_Book_Test()
		{
			Assert.AreNotEqual(b1, b2);
			Assert.AreNotEqual(b1.GetHashCode(), b2.GetHashCode());
		}

	}
}
