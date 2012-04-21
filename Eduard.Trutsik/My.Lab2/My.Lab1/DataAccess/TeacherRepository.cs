using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab1.Entities;
using System.IO;

namespace My.Lab1.DataAccess
{
	public class TeacherRepository : IRepository<Teacher>
	{
		private TimetableDataContext teacherDataContext;

		public TeacherRepository()
		{
			teacherDataContext = new TimetableDataContext();
		}

		public Teacher GetItem(int id)
		{
			return teacherDataContext.Teachers.SingleOrDefault(t => t.id == id);
		}

		public IEnumerable<Teacher> GetItems()
		{
			return teacherDataContext.Teachers.AsEnumerable<Teacher>();
		}

		public void Add(Teacher item)
		{
			teacherDataContext.Teachers.InsertOnSubmit(item);
			teacherDataContext.SubmitChanges();
		}

		public void Remove(Teacher item)
		{
			teacherDataContext.Teachers.DeleteOnSubmit(item);
			teacherDataContext.SubmitChanges();
		}

		public void Remove(int id)
		{
			Teacher temp = teacherDataContext.Teachers.SingleOrDefault(t => t.id == id);
			if (temp != null)
			{
				teacherDataContext.Teachers.DeleteOnSubmit(temp);
				teacherDataContext.SubmitChanges();
			}			
		}

		public void Update(Teacher item)
		{
			Teacher itemUpdate = GetItem(item.id);
			if (itemUpdate != null)
			{
				itemUpdate.name = item.name;
				teacherDataContext.SubmitChanges();
			}
		}
	}
}
