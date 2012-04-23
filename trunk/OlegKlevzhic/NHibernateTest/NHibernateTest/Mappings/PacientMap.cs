using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NHibernateTest.Entities;

namespace NHibernateTest.Mappings
{
	public class PacientMap : ClassMap<Pacient>
	{
		public PacientMap()
		{
			Id(x => x.Id).GeneratedBy.Guid();
			Map(x => x.FirstName);
			Map(x => x.LastName);
			HasMany(x => x.Records).KeyColumns.Add("Id_Pacient").Inverse().Cascade.All();
		}
	}
}
