using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.Lab1.Entities;

namespace My.Lab1.Entities
{
	public class Timetable
	{
		public int id { get; private set; }
		public DateTime dateTimeStart { get; set; }
		public Group group { get; set; }		
		public Subject subject { get; set; }
		public Teacher teacher { get; set; }

		public Timetable(int id, DateTime dateTimeStart, Group group, Subject subject, Teacher teacher)
		{
			this.id = id;
			this.group = group;
			this.subject = subject;
			this.teacher = teacher;
			this.dateTimeStart = dateTimeStart;
		}

		public override string ToString()
		{
			return String.Format("DateTime:{0}; Group:{1}; Subject:{2}; Teacher:{3}", dateTimeStart, group.name, subject.name, teacher.name);
		}
	}
}
