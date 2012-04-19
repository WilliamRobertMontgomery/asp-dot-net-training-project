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
		private const string fileStudents = "Subjects.txt";

		public Subject getItem(int id)
		{
			return getItems().DefaultIfEmpty(null).Where(s => s.id == id).First();
		}

		public IEnumerable<Subject> getItems()
		{
			string[] subjects = File.ReadAllLines(fileStudents);
			return subjects.Select(s =>
			{
				string[] subject = s.Split('|');
				return new Subject(Convert.ToInt32(subject[0]), subject[1]);
			});
		}

		public void add(Subject item)
		{
			File.AppendAllText(fileStudents, string.Join("|", item.id + "|" + item.name + "\n"));
		}

		public void remove(Subject item)
		{
			throw new NotImplementedException();
		}

		public void remove(int id)
		{
			throw new NotImplementedException();
		}
	}
}
