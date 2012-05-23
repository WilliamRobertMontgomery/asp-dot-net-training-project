using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebProject.DataAccess.Entities
{
	public class Role : EntityBase<Guid>
	{
		public virtual string RoleName { get; set; }
		public virtual IList<User> UsersInRole { get; set; }

		public Role()
		{
			UsersInRole = new List<User>();
		}
	}
}
