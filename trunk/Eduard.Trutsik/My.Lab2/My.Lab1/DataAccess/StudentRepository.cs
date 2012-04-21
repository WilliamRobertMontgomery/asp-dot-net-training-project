using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab1.Entities;

namespace My.Lab1.DataAccess
{
	public class StudentRepository: IRepository<Student>
	{
		private TimetableDataContext studentDataContext;

		public StudentRepository()
		{
			studentDataContext = new TimetableDataContext();
		}

		public Student GetItem(int id)
		{
			return studentDataContext.Students.SingleOrDefault(t => t.id == id);
		}

		public IEnumerable<Student> GetItems()
		{
			return studentDataContext.Students.AsEnumerable<Student>();
		}

		public void Add(Student item)
		{
			studentDataContext.Students.InsertOnSubmit(item);
			studentDataContext.SubmitChanges();
		}

		public void Remove(Student item)
		{
			studentDataContext.Students.DeleteOnSubmit(item);
			studentDataContext.SubmitChanges();
		}

		public void Remove(int id)
		{
			Student temp = studentDataContext.Students.SingleOrDefault(t => t.id == id);
			if (temp != null)
			{
				studentDataContext.Students.DeleteOnSubmit(temp);
				studentDataContext.SubmitChanges();
			}	
		}

		public void Update(Student item)
		{
			Student itemUpdate = GetItem(item.id);
			if (itemUpdate != null)
			{
				itemUpdate.name = item.name;
				itemUpdate.id_group = item.id_group;
				studentDataContext.SubmitChanges();
			}
		}
	}
}
