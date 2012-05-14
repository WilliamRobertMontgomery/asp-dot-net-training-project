using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lab4.Library.Models;

namespace Lab4.Library.Test.Entities
{
	[TestFixture]
	public class OrderTest
	{
		Order o1, o2, o3;

		public OrderTest()
		{
			o1 = new Order(new Reader("Name1", "Address1"), new Book("Author1", "Title1", 2000, new LibraryDepartment("Абонемент", true)));
			o2 = new Order(o1.Reader, o1.Book) { Closed = true };
			o3 = new Order(o1.Id, o1.Reader, o1.Book);
		}

		[Test]
		public void EqualsTest()
		{
			Assert.AreNotEqual(o1, o2);
			Assert.AreEqual(o1, o3);
		}

		[Test]
		public void EqualTest()
		{
			Assert.IsFalse(o1 == o2);
			Assert.IsTrue(o1 == o3);
		}

		[Test]
		public void NotEqualTest()
		{
			Assert.IsTrue(o1 != o2);
			Assert.IsFalse(o1 != o3);
		}

		[Test]
		public void GetHashCode_Equal_Order_Test()
		{
			Assert.AreEqual(o1, o3);
			Assert.AreEqual(o1.GetHashCode(), o3.GetHashCode());
		}

		[Test]
		public void GetHashCode_Not_Equal_Order_Test()
		{
			Assert.AreNotEqual(o1, o2);
			Assert.AreNotEqual(o1.GetHashCode(), o2.GetHashCode());
		}

	}
}
