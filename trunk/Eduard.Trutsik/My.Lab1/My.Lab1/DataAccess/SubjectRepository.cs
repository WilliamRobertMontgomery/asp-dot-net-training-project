using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using My.Lab1.Entities;

namespace My.Lab1.DataAccess
{
	public class SubjectRepository:IRepository<Subject>
	{
		private const string fileSubjects = "Subjects.txt";

		public Subject GetItem(int id)
		{
			return GetItems().DefaultIfEmpty(null).Where(s => s.id == id).First();
		}

		public IEnumerable<Subject> GetItems()
		{
			string[] subjects = File.ReadAllLines(fileSubjects);
			return subjects.Select(s =>
			{
				string[] subject = s.Split('|');
				return new Subject(Convert.ToInt32(subject[0]), subject[1]);
			});
		}

		public void Add(Subject item)
		{
			File.AppendAllText(fileSubjects, string.Join("|", item.id + "|" + item.name + "\n"));
		}

		public void Remove(Subject item)
		{
			IEnumerable<Subject> temp = GetItems().Where(g => g.id != item.id);
			File.Delete(fileSubjects);
			foreach (Subject subject in temp)
			{
				File.AppendAllText(fileSubjects, String.Join("|", subject.id + "|" + subject.name + "\n"));
			}
		}

		public void Remove(int id)
		{
			IEnumerable<Subject> temp = GetItems().Where(g => g.id != id);
			File.Delete(fileSubjects);
			foreach (Subject subject in temp)
			{
				File.AppendAllText(fileSubjects, String.Join("|", subject.id + "|" + subject.name + "\n"));
			}
		}
	}
}
