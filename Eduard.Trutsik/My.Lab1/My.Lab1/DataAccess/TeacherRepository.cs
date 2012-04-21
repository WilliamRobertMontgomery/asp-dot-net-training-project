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

		public Teacher GetItem(int id)
		{
			return GetItems().DefaultIfEmpty(null).Where(s => s.id == id).First();
		}

		public IEnumerable<Teacher> GetItems()
		{
			string[] teachers = File.ReadAllLines(fileTeachers);
			return teachers.Select(t =>
			{
				string[] teacher = t.Split('|');
				return new Teacher(Convert.ToInt32(teacher[0]), teacher[1]);
			});
		}

		public void Add(Teacher item)
		{
			File.AppendAllText(fileTeachers, string.Join("|", item.id + "|" + item.name + "\n"));
		}

		public void Remove(Teacher item)
		{
			IEnumerable<Teacher> temp = GetItems().Where(g => g.id != item.id);
			File.Delete(fileTeachers);
			foreach (Teacher teacher in temp)
			{
				File.AppendAllText(fileTeachers, String.Join("|", teacher.id + "|" + teacher.name + "\n"));
			}
		}

		public void Remove(int id)
		{
			IEnumerable<Teacher> temp = GetItems().Where(g => g.id != id);
			File.Delete(fileTeachers);
			foreach (Teacher teacher in temp)
			{
				File.AppendAllText(fileTeachers, String.Join("|", teacher.id + "|" + teacher.name + "\n"));
			}
		}
	}
}
