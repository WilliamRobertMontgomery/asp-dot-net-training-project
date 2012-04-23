using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernateTest.Entities;
using FluentNHibernate.Mapping;

namespace NHibernateTest.Mappings
{
	public class RecordMap : ClassMap<Record>
	{
		public RecordMap()
		{
			Id(x => x.Id).GeneratedBy.Guid();
			Map(x => x.Time);
			References(x => x.Doctor).Column("Id_Doctor").Cascade.All().Not.Nullable();
			References(x => x.Pacient).Column("Id_Pacient").Cascade.All().Not.Nullable();
		}
	}
}
