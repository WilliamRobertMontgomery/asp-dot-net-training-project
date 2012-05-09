using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2.Library.DataModel;

namespace Lab2.Library.DataAccess
{
	public abstract class LibrarianRepository : IRepository<Librarian>
	{
		protected LibraryDepartmentRepository libraryDepartmentRepository;

		public abstract Librarian GetItem(Guid id);

		public abstract IEnumerable<Librarian> GetItems();

		public abstract void Save(Librarian item);

		public abstract void Remove(Librarian item);

		public abstract void Remove(Guid id);
	}
}
