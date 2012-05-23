using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using WebProject.DataAccess.Entities;

namespace WebProject.DataAccess.Mappings
{
	public class RoleMap : ClassMap<Role>
	{
		public RoleMap()
		{
			Table("Roles");
			Id(x => x.Id);
			Map(x => x.RoleName);

			HasManyToMany(x => x.UsersInRole)
			.Cascade.All()
			.Inverse()
			.Table("UsersInRoles");
		}
	}
}
