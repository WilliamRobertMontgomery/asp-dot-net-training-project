using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using WebProject.DataAccess.Entities;

namespace WebProject.DataAccess.Mappings
{
	public class MessageMap : ClassMap<Message>
	{
		public MessageMap()
		{
			Table("Messages");
			Id(x => x.Id);
			Map(x => x.Text);
			Map(x => x.Date);
			Map(x => x.NameGetUser).Column("Name_GetUser");
			Map(x => x.NameSendUser).Column("Name_SendUser");

			References(x => x.GetUser).Column("Id_GetUser");
			References(x => x.SendUser).Column("Id_SendUser");
		}
	}
}
