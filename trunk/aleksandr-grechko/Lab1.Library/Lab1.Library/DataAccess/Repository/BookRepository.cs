using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;

namespace Lab1.Library.DataAccess
{
	public abstract class BookRepository : IRepository<Book>
	{
		protected LibraryDepartmentRepository libraryDepartmentRepository;

		public abstract Book GetItem(Guid id);

		public abstract IEnumerable<Book> GetItems();

		public abstract void Save(Book item);

		public abstract void Remove(Book item);

		public abstract void Remove(Guid id);

		public abstract IEnumerable<Book> GetBooksByAuthor(string author, bool matchWholeString);

		public abstract IEnumerable<Book> GetBooksByTitle(string title, bool matchWholeString);

		public abstract IEnumerable<Book> GetBooksByDepartment(LibraryDepartment department);
	}
}
