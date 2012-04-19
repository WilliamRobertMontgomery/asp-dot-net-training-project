using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab1.Entities;

namespace My.Lab1.Entities
{
	public class Group
	{
		public int id { get; private set;}
		public string name { get; set; }

		public Group(int id, string name)
		{
			this.id = id;
			this.name = name;
		}

		public override string ToString()
		{
			return String.Format("Group Name: {0};", name);
		}
	}
}
