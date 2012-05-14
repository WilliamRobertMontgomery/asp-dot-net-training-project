using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab4.Library.Models;

namespace Lab4.Library.DataAccess
{
	public class BookMSSQLRepository : BookRepository
	{
		private LibraryDataContext context;

		public BookMSSQLRepository(LibraryDepartmentRepository libraryDepartmentRepository, LibraryDataContext context)
		{
			this.libraryDepartmentRepository = libraryDepartmentRepository;

			this.context = context;
		}

		public override Book GetItem(Guid id)
		{
			return context.Books.SingleOrDefault(item => item.Id == id);
		}

		public override IEnumerable<Book> GetItems()
		{
			return context.Books.AsEnumerable<Book>();
		}

		public override void Save(Book item)
		{
			Book book = GetItem(item.Id);
			if (book == null)
			{
				context.Books.InsertOnSubmit(item);
			}
			else
			{
				book.Author = item.Author;
				book.Title = item.Title;
				book.Year = item.Year;
				book.Department = item.Department;
			}
			context.SubmitChanges();
		}

		public override void Remove(Book item)
		{
			Remove(item.Id);
		}

		public override void Remove(Guid id)
		{
			Book book = GetItem(id);
			if (book != null)
			{
				context.Books.DeleteOnSubmit(book);
				context.SubmitChanges();
			}
		}

		public override IEnumerable<Book> GetBooksByAuthor(string author, bool matchWholeString)
		{
			return context.Books.Where(book => matchWholeString ? book.Author == author : book.Author.Contains(author));
		}

		public override IEnumerable<Book> GetBooksByTitle(string title, bool matchWholeString)
		{
			return context.Books.Where(book => matchWholeString ? book.Title == title : book.Title.Contains(title));
		}

		public override IEnumerable<Book> GetBooksByDepartment(LibraryDepartment department)
		{
			return context.Books.Where(book => book.Department.Id == department.Id);
		}
	}
}
