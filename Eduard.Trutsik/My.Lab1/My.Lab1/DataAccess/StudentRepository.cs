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

		public Student GetItem(int id)
		{
			return GetItems().DefaultIfEmpty(null).Where(s => s.id == id).First();
		}

		public IEnumerable<Student> GetItems()
		{
			string[] students = File.ReadAllLines(fileStudents);
			return students.Select(s=>
 				{
					string[] student = s.Split('|');
					return new Student(Convert.ToInt32(student[0]),student[1], new GroupRepository().GetItem(Convert.ToInt32(student[2])));
				});
		}

		public void Add(Student item)
		{
			File.AppendAllText(fileStudents, string.Join("|", item.id + "|" + item.name + "|" + item.group.id + "\n"));
		}

		public void Remove(Student item)
		{
			IEnumerable<Student> temp = GetItems().Where(g => g.id != item.id);
			File.Delete(fileStudents);
			foreach (Student student in temp)
			{
				File.AppendAllText(fileStudents, String.Join("|", student.id + "|" + student.name +"|"+ student.group+"\n"));
			}
		}

		public void Remove(int id)
		{
			IEnumerable<Student> temp = GetItems().Where(g => g.id != id);
			File.Delete(fileStudents);
			foreach (Student student in temp)
			{
				File.AppendAllText(fileStudents, String.Join("|", student.id + "|" + student.name + "|" + student.group + "\n"));
			}
		}
	}
}
