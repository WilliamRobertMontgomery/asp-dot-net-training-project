using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab1.Entities;

namespace My.Lab1.DataAccess
{
	public class SubjectRepository:IRepository<Subject>
	{
		private TimetableDataContext subjectDataContext;

		public SubjectRepository()
		{
			subjectDataContext = new TimetableDataContext();
		}

		public Subject GetItem(int id)
		{
			return subjectDataContext.Subjects.SingleOrDefault(t => t.id == id);
		}

		public IEnumerable<Subject> GetItems()
		{
			return subjectDataContext.Subjects.AsEnumerable<Subject>();
		}

		public void Add(Subject item)
		{
			subjectDataContext.Subjects.InsertOnSubmit(item);
			subjectDataContext.SubmitChanges();
		}

		public void Remove(Subject item)
		{
			subjectDataContext.Subjects.DeleteOnSubmit(item);
			subjectDataContext.SubmitChanges();
		}

		public void Remove(int id)
		{
			Subject temp = subjectDataContext.Subjects.SingleOrDefault(t => t.id == id);
			if (temp != null)
			{
				subjectDataContext.Subjects.DeleteOnSubmit(temp);
				subjectDataContext.SubmitChanges();
			}
		}

		public void Update(Subject item)
		{
			Subject itemUpdate = GetItem(item.id);
			if (itemUpdate != null)
			{
				itemUpdate.name = item.name;
				subjectDataContext.SubmitChanges();
			}
		}
	}
}
