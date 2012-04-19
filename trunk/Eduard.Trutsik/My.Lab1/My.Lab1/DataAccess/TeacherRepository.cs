using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab1.Entities;
using System.IO;

namespace My.Lab1.DataAccess
{
	public class TeacherRepository: IRepository<Teacher>
	{
		private const string fileTeachers = "Teachers.txt";

		public Teacher getItem(int id)
		{
			return getItems().DefaultIfEmpty(null).Where(s => s.id == id).First();
		}

		public IEnumerable<Teacher> getItems()
		{
			string[] teachers = File.ReadAllLines(fileTeachers);
			return teachers.Select(t =>
			{
				string[] teacher = t.Split('|');
				return new Teacher(Convert.ToInt32(teacher[0]), teacher[1]);
			});
		}

		public void add(Teacher item)
		{
			File.AppendAllText(fileTeachers, string.Join("|", item.id + "|" + item.name + "\n"));
		}

		public void remove(Teacher item)
		{
			throw new NotImplementedException();
		}

		public void remove(int id)
		{
			throw new NotImplementedException();
		}
	}
}
