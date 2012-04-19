using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab1.Entities;
using System.IO;

namespace My.Lab1.DataAccess
{
	public class StudentRepository:IRepository<Student>
	{
		private const string fileStudents = "Students.txt";

		public Student getItem(int id)
		{
			return getItems().DefaultIfEmpty(null).Where(s => s.id == id).First();
		}

		public IEnumerable<Student> getItems()
		{
			string[] students = File.ReadAllLines(fileStudents);
			return students.Select(s=>
 				{
					string[] student = s.Split('|');
					return new Student(Convert.ToInt32(student[0]),student[1], new GroupRepository().getItem(Convert.ToInt32(student[2])));
				});
		}

		public void add(Student item)
		{
			File.AppendAllText(fileStudents, string.Join("|", item.id + "|" + item.name + "|" + item.group.id + "\n"));
		}

		public void remove(Student item)
		{
			throw new NotImplementedException();
		}

		public void remove(int id)
		{
			throw new NotImplementedException();
		}
	}
}
