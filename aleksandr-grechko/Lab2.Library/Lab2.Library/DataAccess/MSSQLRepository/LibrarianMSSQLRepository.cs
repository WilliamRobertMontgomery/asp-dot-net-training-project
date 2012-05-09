using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2.Library.DataModel;

namespace Lab2.Library.DataAccess
{
	public class LibrarianMSSQLRepository : LibrarianRepository
	{
		private LibraryDataContext context;

		public LibrarianMSSQLRepository(LibraryDepartmentRepository libraryDepartmentRepository, LibraryDataContext context)
		{
			this.libraryDepartmentRepository = libraryDepartmentRepository;

			this.context = context;
		}

		public override Librarian GetItem(Guid id)
		{
			return context.Librarians.SingleOrDefault(item => item.Id == id);
		}

		public override IEnumerable<Librarian> GetItems()
		{
			return context.Librarians.AsEnumerable<Librarian>();
		}

		public override void Save(Librarian item)
		{
			Librarian librarian = GetItem(item.Id);
			if (librarian == null)
			{
				context.Librarians.InsertOnSubmit(item);
			}
			else
			{
				librarian.FullName = item.FullName;
				librarian.Department = item.Department;
			}
			context.SubmitChanges();
		}

		public override void Remove(Librarian item)
		{
			Remove(item.Id);
		}

		public override void Remove(Guid id)
		{
			Librarian librarian = GetItem(id);
			if (librarian != null)
			{
				context.Librarians.DeleteOnSubmit(librarian);
				context.SubmitChanges();
			}
		}
	}
}
