using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Library.Entities
{
	public class Order
	{
		public Guid Id { get; private set; }
		public Reader Reader { get; private set; }
		public Book Book { get; private set; }
		public LibraryDepartment Department { get; private set; }
		public DateTime TimeGetBook { get; set; }
		public Librarian LibrarianOpenOrder { get; set; }
		public DateTime TimeReturnBook { get; set; }
		public Librarian LibrarianClosedOrder { get; set; }
		public bool Closed { get; set; }

		public Order(Reader reader, Book book)
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
			return (Id.ToString() + Reader.GetHashCode() + Book.GetHashCode() + TimeGetBook + (LibrarianOpenOrder != null ? LibrarianOpenOrder.GetHashCode() : 0) +
				TimeReturnBook + (LibrarianOpenOrder != null ? LibrarianOpenOrder.GetHashCode() : 0) + Closed).GetHashCode();
		}
	}
}
