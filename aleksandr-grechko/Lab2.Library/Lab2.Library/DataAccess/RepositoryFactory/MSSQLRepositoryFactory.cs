using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2.Library.DataModel;
using System.IO;

namespace Lab2.Library.DataAccess
{
	public class MSSQLRepositoryFactory : IRepositoryFactory
	{
		private LibraryDataContext context;

		public MSSQLRepositoryFactory()
		{
			context = new LibraryDataContext();
		}

		public ReaderRepository CreateReaderRepository()
		{
			return new ReaderMSSQLRepository(context);
		}

		public BookRepository CreateBookRepository(LibraryDepartmentRepository libraryDepartmentRepository)
		{
			return new BookMSSQLRepository(libraryDepartmentRepository, context);
		}

		public LibrarianRepository CreateLibrarianRepository(LibraryDepartmentRepository libraryDepartmentRepository)
		{
			return new LibrarianMSSQLRepository(libraryDepartmentRepository, context);
		}

		public LibraryDepartmentRepository CreateLibraryDepartmentRepository()
		{
			return new LibraryDepartmentMSSQLRepository(context);
		}

		public OrderRepository CreateOrderRepository(ReaderRepository readerRepository, BookRepository bookRepository, 
			LibraryDepartmentRepository libraryDepartmentRepository, LibrarianRepository librarianRepository)
		{
			return new OrderMSSQLRepository(readerRepository, bookRepository, libraryDepartmentRepository, librarianRepository, context);
		}
	}
}
