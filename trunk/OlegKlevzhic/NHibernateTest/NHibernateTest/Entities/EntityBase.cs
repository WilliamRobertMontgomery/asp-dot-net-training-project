using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateTest.Entities
{
	public abstract class EntityBase
	{
		public virtual Guid Id { get; set; }
	}
}
