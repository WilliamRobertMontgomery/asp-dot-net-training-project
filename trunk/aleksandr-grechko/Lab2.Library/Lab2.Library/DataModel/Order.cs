using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Library.DataModel
{
	public partial class Order
	{
		public Order(Reader reader, Book book)
			: this()
		{
			Id = Guid.NewGuid();
			Reader = reader;
			Book = book;
			if (book != null)
			{
				Department = book.Department;
			}
		}

		public Order(Guid id, Reader reader, Book book)
			: this()
		{
			Id = id;
			Reader = reader;
			Book = book;
			if (book != null)
			{
				Department = book.Department;
			}
		}

		public override string ToString()
		{
			return String.Join(" ", Reader.FullName, Book.Author, Book.Title, Department.Name, "/n",
				TimeGetBook, LibrarianOpenOrder != null ? LibrarianOpenOrder.FullName : "", "/n",
				TimeReturnBook, LibrarianClosedOrder != null ? LibrarianClosedOrder.FullName : "", "/n",
				Closed ? "Open" : "Close");
		}

		public override bool Equals(Object obj)
		{
			if (obj == null || !(obj is Order))
			{
				return false;
			}
			return OrderCompare(this, obj as Order);
		}

		public static bool operator ==(Order a, Order b)
		{
			if (((object)a == null) ^ ((object)b == null))
			{
				return false;
			}
			return OrderCompare(a, b);
		}

		private static bool OrderCompare(Order a, Order b)
		{
			if (Object.ReferenceEquals(a, b))
			{
				return true;
			}
			return a.Id == b.Id &&
				a.Reader == b.Reader &&
				a.Book == b.Book &&
				a.TimeGetBook == b.TimeGetBook &&
				a.LibrarianOpenOrder == b.LibrarianOpenOrder &&
				a.TimeReturnBook == b.TimeReturnBook &&
				a.LibrarianClosedOrder == b.LibrarianClosedOrder &&
				a.Closed == b.Closed;
		}

		public static bool operator !=(Order a, Order b)
		{
			return !(a == b);
		}


		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
