using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;

namespace Lab1.Library.DataAccess
{
	public class LibraryDepartmentObjectRepository : LibraryDepartmentRepository
	{
		private List<LibraryDepartment> LibraryDepartments;

		public LibraryDepartmentObjectRepository()
		{
			LibraryDepartments = new List<LibraryDepartment>();
		}

		public override LibraryDepartment GetItem(Guid id)
		{
			return LibraryDepartments.SingleOrDefault(LibraryDepartment => LibraryDepartment.Id == id);
		}

		public override IEnumerable<LibraryDepartment> GetItems()
		{
			return LibraryDepartments;
		}

		public override void Save(LibraryDepartment item)
		{
			LibraryDepartment LibraryDepartment = GetItem(item.Id);
			if (LibraryDepartment != null)
			{
				LibraryDepartments[LibraryDepartments.IndexOf(LibraryDepartment)] = item;
			}
			else
			{
				LibraryDepartments.Add(item);
			}
		}

		public override void Remove(LibraryDepartment item)
		{
			LibraryDepartments.Remove(item);
		}

		public override void Remove(Guid id)
		{
			LibraryDepartments.Remove(GetItem(id));
		}
	}
}
