using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using WebProject.DataAccess.Entities;

namespace WebProject.DataAccess.Mappings
{
	public class UserMap : ClassMap<User>
	{
		public UserMap()
		{
			Table("Users");
			Id(x => x.Id);
			Map(x => x.UserName);
			Map(x => x.Email);
			Map(x => x.Password);
			Map(x => x.IsActivated);
			Map(x => x.LastActivityDate);
			Map(x => x.CreationDate);
			Map(x => x.IsOnLine);
			Map(x => x.IsLockedOut);

			HasManyToMany(x => x.Roles)
					.Cascade.All()
					.Table("UsersInRoles");
		}
	}
}
