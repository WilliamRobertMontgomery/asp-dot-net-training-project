using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateTest.Entities
{
	public class Doctor : EntityBase
	{
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual Specialization Specialization { get; set; }
		public virtual IList<Record> Records { get; set; }

		public Doctor()
		{
			this.Records = new List<Record>();
		}
	}
}
