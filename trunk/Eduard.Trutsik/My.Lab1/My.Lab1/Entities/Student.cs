using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Lab1.Entities
{
	public class Student
	{
		public int id {get; private set; }
		public string name {get; set;}
		public Group group { get; set; }

		public Student()
		{
			id = 0;
			name = "undefined";
			group = null;
		}

		public Student(int id, string name, Group group)
		{
			this.id = id;
			this.name = name;
			this.group = group;
		}

		public override string ToString()
		{
			return String.Format("Student: Name: {0}; NameGoup: {1}", name, group.name);
		}

	}
}
