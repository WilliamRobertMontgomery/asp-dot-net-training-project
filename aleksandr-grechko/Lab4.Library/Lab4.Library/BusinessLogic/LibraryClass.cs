using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab4.Library.DataAccess;
using Lab4.Library.Models;

namespace Lab4.Library.BusinessLogic
{
	public class LibraryClass : ILibraryClass
	{
		private Repository repository;

		private List<LibraryDepartment> allDepartments;

		private List<Librarian> workLibrarians;

		private List<Reader> activeReaders;

		private List<Order> openOrders;


		public LibraryClass(Repository repository)
		{
			this.repository = repository;

			allDepartments = repository.LibraryDepartmentRepository.GetItems().ToList<LibraryDepartment>();
			workLibrarians = repository.LibrarianRepository.GetItems().ToList<Librarian>();
			openOrders = repository.OrderRepository.GetOpenOrders().ToList<Order>();
			activeReaders = new List<Reader>();
		}


		public IEnumerable<Book> GetAllBooks()
		{
			return repository.BookRepository.GetItems();
		}

		public IEnumerable<Book> GetBooksByDepartment(LibraryDepartment department)
		{
			return repository.BookRepository.GetBooksByDepartment(department);
		}

		public IEnumerable<Book> GetBooksByAuthor(string author)
		{
			return repository.BookRepository.GetBooksByAuthor(author, false);
		}

		public IEnumerable<Book> GetBooksByTitle(string title)
		{
			return repository.BookRepository.GetBooksByTitle(title, false);
		}


		public IEnumerable<LibraryDepartment> GetDepartments()
		{
			return repository.LibraryDepartmentRepository.GetItems();
		}


		public bool OrderBook(Book book, Reader reader)
		{
			if (openOrders.Select(o => o.Book).Contains(book)) return false;
			if (!activeReaders.Contains(reader)) return false;

			Order order = new Order(reader, book);
			order.TimeGetBook = DateTime.Now;
			order.TimeReturnBook = DateTime.Now;
			order.LibrarianOpenOrder = workLibrarians.First(l => l.Department == book.Department);

			openOrders.Add(order);
			repository.OrderRepository.Save(order);

			return true;
		}

		public void ReturnBook(Book book)
		{
			Order order = openOrders.Single(o => o.Book == book);
			openOrders.Remove(order);
			order.TimeReturnBook = DateTime.Now;
			order.LibrarianClosedOrder = workLibrarians.First(l => l.Department == book.Department);
			order.Closed = true;
			repository.OrderRepository.Save(order);
		}

		public IEnumerable<Book> GetBooksOrderedByReader(Reader reader)
		{
			return openOrders.Where(order => order.Reader == reader).Select(order => order.Book);
		}


		public Reader GetReader(string fullName)
		{
			return repository.ReaderRepository.GetReadersByName(fullName, true).FirstOrDefault();
		}

		public Reader AddReader(string fullName, string address)
		{
			Reader reader = new Reader(fullName, address);
			repository.ReaderRepository.Save(reader);
			return reader;
		}

		public bool AuthorizationReader(Reader reader)
		{
			if (activeReaders.Contains(reader))
			{
				return false;
			}
			else
			{
				activeReaders.Add(reader);
				return true;
			}
		}

		public bool ExitReader(Reader reader)
		{
			activeReaders.Remove(reader);
			return true;
		}
	}
}
