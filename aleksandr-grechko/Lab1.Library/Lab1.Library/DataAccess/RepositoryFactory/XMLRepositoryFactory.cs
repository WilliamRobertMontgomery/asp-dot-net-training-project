using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Library.DataAccess
{
	public class XMLRepositoryFactory : IRepositoryFactory
	{
		public ReaderRepository CreateReaderRepository()
		{
			return new ReaderXMLRepository();
		}

		public BookRepository CreateBookRepository(LibraryDepartmentRepository libraryDepartmentRepository)
		{
			return new BookXMLRepository(libraryDepartmentRepository);
		}

		public LibrarianRepository CreateLibrarianRepository(LibraryDepartmentRepository libraryDepartmentRepository)
		{
			return new LibrarianXMLRepository(libraryDepartmentRepository);
		}

		public LibraryDepartmentRepository CreateLibraryDepartmentRepository()
		{
			return new LibraryDepartmentXMLRepository();
		}

		public OrderRepository CreateOrderRepository(ReaderRepository readerRepository, BookRepository bookRepository, 
			LibraryDepartmentRepository libraryDepartmentRepository, LibrarianRepository librarianRepository)
		{
			return new OrderXMLRepository(readerRepository, bookRepository, libraryDepartmentRepository, librarianRepository);
		}
	}
}
