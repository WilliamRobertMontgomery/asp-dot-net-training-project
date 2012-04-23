using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateTest.Entities
{
	public class Record : EntityBase
	{
		public virtual Doctor Doctor { get; set; }
		public virtual Pacient Pacient { get; set; }
		public virtual DateTime Time { get; set; }
	}
}
