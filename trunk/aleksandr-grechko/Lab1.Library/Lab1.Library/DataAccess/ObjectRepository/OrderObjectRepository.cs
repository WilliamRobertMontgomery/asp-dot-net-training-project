using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;

namespace Lab1.Library.DataAccess
{
	public class OrderObjectRepository : OrderRepository
	{
		private List<Order> orders;

		public OrderObjectRepository(ReaderRepository readerRepository, BookRepository bookRepository, 
			LibraryDepartmentRepository libraryDepartmentRepository, LibrarianRepository librarianRepository)
		{
			this.readerRepository = readerRepository;
			this.bookRepository = bookRepository;
			this.libraryDepartmentRepository = libraryDepartmentRepository;
			this.librarianRepository = librarianRepository;
			orders = new List<Order>();
		}
	
		public override Order GetItem(Guid id)
		{
			return orders.SingleOrDefault(Order => Order.Id == id);
		}

		public override IEnumerable<Order> GetItems()
		{
			return orders;
		}

		public override void Save(Order item)
		{
			Order Order = GetItem(item.Id);
			if (Order != null)
			{
				orders[orders.IndexOf(Order)] = item;
			}
			else
			{
				orders.Add(item);
			}
		}

		public override void Remove(Order item)
		{
			orders.Remove(item);
		}

		public override void Remove(Guid id)
		{
			orders.Remove(GetItem(id));
		}

		public override IEnumerable<Order> GetOrdersByBook(Book book, bool closed)
		{
			return orders.Where(order => order.Book.Id == book.Id && order.Closed == closed);
		}

		public override IEnumerable<Order> GetOrdersByReader(Reader reader, bool closed)
		{
			return orders.Where(order => order.Reader.Id == reader.Id && order.Closed == closed);
		}

		public override IEnumerable<Order> GetOpenOrders()
		{
			return orders.Where(order => order.Closed == false);
		}
	}
}
