using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;

namespace Lab1.Library.DataAccess
{
	public class LibrarianObjectRepository : LibrarianRepository
	{
		private List<Librarian> librarians;

		public LibrarianObjectRepository(LibraryDepartmentRepository libraryDepartmentRepository)
		{
			this.libraryDepartmentRepository = libraryDepartmentRepository;
			librarians = new List<Librarian>();
		}
	
		public override Librarian GetItem(Guid id)
		{
			return librarians.SingleOrDefault(Librarian => Librarian.Id == id);
		}

		public override IEnumerable<Librarian> GetItems()
		{
			return librarians;
		}

		public override void Save(Librarian item)
		{
			Librarian Librarian = GetItem(item.Id);
			if (Librarian != null)
			{
				librarians[librarians.IndexOf(Librarian)] = item;
			}
			else
			{
				librarians.Add(item);
			}
		}

		public override void Remove(Librarian item)
		{
			librarians.Remove(item);
		}

		public override void Remove(Guid id)
		{
			librarians.Remove(GetItem(id));
		}
	}
}
