using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;

namespace Lab1.Library.DataAccess
{
	public abstract class LibraryDepartmentRepository : IRepository<LibraryDepartment>
	{
		public abstract LibraryDepartment GetItem(Guid id);

		public abstract IEnumerable<LibraryDepartment> GetItems();

		public abstract void Save(LibraryDepartment item);

		public abstract void Remove(LibraryDepartment item);

		public abstract void Remove(Guid id);
	}
}
