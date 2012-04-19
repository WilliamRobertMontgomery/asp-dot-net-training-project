using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Lab1.Entities
{
	public class Teacher
	{
		public int id {get; private set; }
		public string name {get; set;}

		public Teacher()
		{
			id = 0;
			name = "undefined";
		}

		public Teacher(int id, string name)
		{
			this.id = id;
			this.name = name;
		}

		public override string ToString()
		{
			return String.Format("Teacher Name: {0};", name);
		}
	}
}
