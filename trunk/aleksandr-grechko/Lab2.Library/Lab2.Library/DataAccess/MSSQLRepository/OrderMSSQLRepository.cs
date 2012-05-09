using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2.Library.DataModel;
using System.Data.Linq;

namespace Lab2.Library.DataAccess
{
	public class OrderMSSQLRepository : OrderRepository
	{
		private LibraryDataContext context;

		public OrderMSSQLRepository(ReaderRepository readerRepository, BookRepository bookRepository, 
			LibraryDepartmentRepository libraryDepartmentRepository, LibrarianRepository librarianRepository,
			LibraryDataContext context)
		{
			this.readerRepository = readerRepository;
			this.bookRepository = bookRepository;
			this.libraryDepartmentRepository = libraryDepartmentRepository;
			this.librarianRepository = librarianRepository;

			this.context = context;
		}

		public override Order GetItem(Guid id)
		{
			return context.Orders.SingleOrDefault(item => item.Id == id);
		}

		public override IEnumerable<Order> GetItems()
		{
			return context.Orders.AsEnumerable<Order>();
		}

		public override void Save(Order item)
		{
			Order order = GetItem(item.Id);
			if (order == null)
			{
				context.Orders.InsertOnSubmit(item);
			}
			else
			{
				order.Book = item.Book;
				order.Reader = item.Reader;
				order.Department = item.Department;
				order.TimeGetBook = item.TimeGetBook;
				order.LibrarianOpenOrder = item.LibrarianOpenOrder;
				order.TimeReturnBook = item.TimeReturnBook;
				order.LibrarianClosedOrder = item.LibrarianClosedOrder;
				order.Closed = item.Closed;
			}
			context.SubmitChanges();
		}

		public override void Remove(Order item)
		{
			Remove(item.Id);
		}

		public override void Remove(Guid id)
		{
			Order order = GetItem(id);
			if (order != null)
			{
				context.Orders.DeleteOnSubmit(order);
				context.SubmitChanges();
			}
		}

		public override IEnumerable<Order> GetOrdersByBook(Book book, bool closed)
		{
			return context.Orders.Where(order => order.Book.Id == book.Id && order.Closed == closed);
		}

		public override IEnumerable<Order> GetOrdersByReader(Reader reader, bool closed)
		{
			return context.Orders.Where(order => order.Reader.Id == reader.Id && order.Closed == closed);
		}

		public override IEnumerable<Order> GetOpenOrders()
		{
			return context.Orders.Where(order => order.Closed == false);
		}
	}
}
