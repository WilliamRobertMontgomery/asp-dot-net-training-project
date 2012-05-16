using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab4.Library.Models;

namespace Lab4.Library.BusinessLogic
{
	public interface ILibraryClass
	{
		IEnumerable<Book> GetAllBooks();

		IEnumerable<Book> GetBooksByDepartment(LibraryDepartment department);

		IEnumerable<Book> GetBooksByAuthor(string author);

		IEnumerable<Book> GetBooksByTitle(string title);

		IEnumerable<LibraryDepartment> GetDepartments();

		bool OrderBook(Book book, Reader reader);

		void ReturnBook(Book book);

		IEnumerable<Book> GetBooksOrderedByReader(Reader reader);

		Reader GetReader(string fullName);

		Reader AddReader(string fullName, string address);

		bool AuthorizationReader(Reader reader);

		bool ExitReader(Reader reader);
	}
}
