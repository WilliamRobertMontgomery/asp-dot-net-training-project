using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab4.Library.Models;

namespace Lab4.Library.DataAccess
{
	public abstract class OrderRepository : IRepository<Order>
	{
		protected ReaderRepository readerRepository;

		protected LibraryDepartmentRepository libraryDepartmentRepository;

		protected BookRepository bookRepository;

		protected LibrarianRepository librarianRepository;


		public abstract Order GetItem(Guid id);

		public abstract IEnumerable<Order> GetItems();

		public abstract void Save(Order item);

		public abstract void Remove(Order item);

		public abstract void Remove(Guid id);

		public abstract IEnumerable<Order> GetOrdersByBook(Book book, bool closed);

		public abstract IEnumerable<Order> GetOrdersByReader(Reader reader, bool closed);

		public abstract IEnumerable<Order> GetOpenOrders();
	}
}
