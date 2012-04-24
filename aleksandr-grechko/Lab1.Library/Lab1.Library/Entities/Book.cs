using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Library.Entities
{
	public class Book
	{
		public Guid Id { get; private set; }
		public string Author { get; private set; }
		public string Title { get; private set; }
		public int Year { get; private set; }
		public LibraryDepartment Department { get; private set; }

		public Book(Guid id, string author, string title, int year, LibraryDepartment department)
		{
			Id = id;
			Author = author;
			Title = title;
			Year = year;
			Department = department;
		}

		public Book(string author, string title, int year, LibraryDepartment department)
		{
			Id = Guid.NewGuid();
			Author = author;
			Title = title;
			Year = year;
			Department = department;
		}

		public override string ToString()
		{
			return String.Join("  ", Author, Title, Year, Department.Name);
		}

		public override bool Equals(Object obj)
		{
			if (obj == null || !(obj is Book))
			{
				return false;
			}
			return BookCompare(this, obj as Book);
		}

		public static bool operator ==(Book a, Book b)
		{
			if (((object)a == null) ^ ((object)b == null))
			{
				return false;
			}
			return BookCompare(a, b);
		}

		private static bool BookCompare(Book a, Book b)
		{
			if (Object.ReferenceEquals(a, b))
			{
				return true;
			}
			return a.Id == b.Id &&
				a.Author == b.Author &&
				a.Title == b.Title &&
				a.Year == b.Year &&
				a.Department == b.Department;
		}

		public static bool operator !=(Book a, Book b)
		{
			return !(a == b);
		}


		public override int GetHashCode()
		{
			return (Id + Author + Title + Year + Department.GetHashCode()).GetHashCode();
		}

	}
}
