using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab1.Entities;

namespace My.Lab1.DataAccess
{
	public class Subj_TeachRepository:IRepository<Subj_Teach>
	{

		private TimetableDataContext subj_teachDataContext;

		public Subj_TeachRepository()
		{
			subj_teachDataContext = new TimetableDataContext();
		}

		public Subj_Teach GetItem(int id)
		{
			return subj_teachDataContext.Subj_Teaches.SingleOrDefault(t => t.id == id);
		}

		public IEnumerable<Subj_Teach> GetItems()
		{
			return subj_teachDataContext.Subj_Teaches.AsEnumerable<Subj_Teach>();
		}

		public void Add(Subj_Teach item)
		{
			subj_teachDataContext.Subj_Teaches.InsertOnSubmit(item);
			subj_teachDataContext.SubmitChanges();
		}

		public void Remove(Subj_Teach item)
		{
			subj_teachDataContext.Subj_Teaches.DeleteOnSubmit(item);
			subj_teachDataContext.SubmitChanges();
		}

		public void Remove(int id)
		{
			Subj_Teach temp = subj_teachDataContext.Subj_Teaches.SingleOrDefault(t => t.id == id);
			if (temp != null)
			{
				subj_teachDataContext.Subj_Teaches.DeleteOnSubmit(temp);
				subj_teachDataContext.SubmitChanges();
			}
		}

		public void Update(Subj_Teach item)
		{
			Subj_Teach itemUpdate = GetItem(item.id);
			if (itemUpdate != null)
			{
				itemUpdate.id_subject = item.id_subject;
				itemUpdate.id_teacher = item.id_teacher;
				subj_teachDataContext.SubmitChanges();
			}
		}
	}
}
