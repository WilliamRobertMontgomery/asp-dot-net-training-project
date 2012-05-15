using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab4.Models;

namespace My.Lab4.DataAccess
{
	public class StudentRepository: IRepository<Student>
	{
		private TimetableDataContext _dataContext;

		public StudentRepository(TimetableDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public Student GetItem(int id)
		{
			return _dataContext.Students.SingleOrDefault(t => t.id == id);
		}

		public IEnumerable<Student> GetItems()
		{
			return _dataContext.Students.AsEnumerable<Student>();
		}

		public void Add(Student item)
		{
			_dataContext.Students.InsertOnSubmit(item);
			_dataContext.SubmitChanges();
		}

		public void Remove(Student item)
		{
			_dataContext.Students.DeleteOnSubmit(item);
			_dataContext.SubmitChanges();
		}

		public void Remove(int id)
		{
			Student temp = _dataContext.Students.SingleOrDefault(t => t.id == id);
			if (temp != null)
			{
				_dataContext.Students.DeleteOnSubmit(temp);
				_dataContext.SubmitChanges();
			}	
		}

		public void Update(Student item)
		{
			Student itemUpdate = GetItem(item.id);
			if (itemUpdate != null)
			{
				itemUpdate.name = item.name;
				itemUpdate.id_group = item.id_group;
				_dataContext.SubmitChanges();
			}
		}
	}
}
