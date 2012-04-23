using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateTest.Entities
{
	public class Pacient : EntityBase
	{
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual IList<Record> Records { get; set; }

		public Pacient()
		{
			this.Records = new List<Record>();
		}
	}
}
