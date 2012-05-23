using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using WebProject.DataAccess.Entities;

namespace WebProject.DataAccess.Mappings
{
	public class ProfileMap : ClassMap<Profile>
	{
		public ProfileMap()
		{
			Table("Profiles");
			Id(x => x.Id);
			Map(x => x.Id_User).Column("Id_User");
			Map(x => x.FirstName);
			Map(x => x.LastName);
			Map(x => x.Gender);
			Map(x => x.BirthDate);
			Map(x => x.Country);
			Map(x => x.City);
			Map(x => x.Website);

			HasManyToMany(x => x.Friends).Cascade.All().Table("UsersInFriends").ParentKeyColumn("Id_Profile").ChildKeyColumn("Id_Friend");
			HasMany(x => x.SendMessages).Cascade.All().KeyColumn("Id_SendUser");
			HasMany(x => x.GetMessages).Cascade.All().KeyColumn("Id_GetUser");
		}
	}
}
