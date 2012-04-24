using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;

namespace Lab1.Library.DataAccess
{
	public class BookObjectRepository : BookRepository
	{
		private List<Book> books;

		public BookObjectRepository(LibraryDepartmentRepository libraryDepartmentRepository)
		{
			this.libraryDepartmentRepository = libraryDepartmentRepository;
			books = new List<Book>();
		}
	
		public override Book GetItem(Guid id)
		{
			return books.SingleOrDefault(Book => Book.Id == id);
		}

		public override IEnumerable<Book> GetItems()
		{
			return books;
		}

		public override void Save(Book item)
		{
			Book Book = GetItem(item.Id);
			if (Book != null)
			{
				books[books.IndexOf(Book)] = item;
			}
			else
			{
				books.Add(item);
			}
		}

		public override void Remove(Book item)
		{
			books.Remove(item);
		}

		public override void Remove(Guid id)
		{
			books.Remove(GetItem(id));
		}

		public override IEnumerable<Book> GetBooksByAuthor(string author, bool matchWholeString)
		{
			return books.Where(book => matchWholeString ? book.Author == author : book.Author.Contains(author));
		}

		public override IEnumerable<Book> GetBooksByTitle(string title, bool matchWholeString)
		{
			return books.Where(book => matchWholeString ? book.Title == title : book.Title.Contains(title));
		}

		public override IEnumerable<Book> GetBooksByDepartment(LibraryDepartment department)
		{
			return books.Where(book => book.Department.Id == department.Id);
		}
	}
}
