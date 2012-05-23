using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebProject.DataAccess.Entities
{
	public abstract class EntityBase<T>
	{
		public virtual T Id { get; set; }
	}
}
