using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebProject.DataAccess.Entities
{
	public class User : EntityBase<Guid>
	{
		public virtual string UserName { get; set; }
		public virtual string Email { get; set; }
		public virtual string Password { get; set; }

		public virtual bool IsActivated { get; set; }
		public virtual DateTime LastActivityDate { get; set; }

		public virtual DateTime CreationDate { get; set; }

		public virtual bool IsOnLine { get; set; }
		public virtual bool IsLockedOut { get; set; }

		public virtual IList<Role> Roles { get; set; }

		public User()
		{
			this.CreationDate = new DateTime().MinDate();
			this.LastActivityDate = new DateTime().MinDate();
			this.Roles = new List<Role>();
		}

		public virtual void AddRole(Role role)
		{
			role.UsersInRole.Add(this);
			Roles.Add(role);
		}

		public virtual void RemoveRole(Role role)
		{
			role.UsersInRole.Remove(this);
			Roles.Remove(role);
		}
	}
}
