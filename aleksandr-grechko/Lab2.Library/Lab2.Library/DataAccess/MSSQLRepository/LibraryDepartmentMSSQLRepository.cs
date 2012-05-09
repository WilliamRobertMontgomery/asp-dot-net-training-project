using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2.Library.DataModel;

namespace Lab2.Library.DataAccess
{
	public class LibraryDepartmentMSSQLRepository : LibraryDepartmentRepository
	{
		private LibraryDataContext context;

		public LibraryDepartmentMSSQLRepository(LibraryDataContext context)
		{
			this.context = context;
		}

		public override LibraryDepartment GetItem(Guid id)
		{
			return context.LibraryDepartments.SingleOrDefault(item => item.Id == id);
		}

		public override IEnumerable<LibraryDepartment> GetItems()
		{
			return context.LibraryDepartments.AsEnumerable<LibraryDepartment>();
		}

		public override void Save(LibraryDepartment item)
		{
			LibraryDepartment department = GetItem(item.Id);
			if (department == null)
			{
				context.LibraryDepartments.InsertOnSubmit(item);
			}
			else
			{
				department.Name = item.Name;
				department.IsAbonement = item.IsAbonement;
			}
			context.SubmitChanges();
		}

		public override void Remove(LibraryDepartment item)
		{
			Remove(item.Id);
		}

		public override void Remove(Guid id)
		{
			LibraryDepartment department = GetItem(id);
			if (department != null)
			{
				context.LibraryDepartments.DeleteOnSubmit(department);
				context.SubmitChanges();
			}
		}
	}
}
