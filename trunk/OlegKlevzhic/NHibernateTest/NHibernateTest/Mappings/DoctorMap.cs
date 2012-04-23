using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernateTest.Entities;
using FluentNHibernate.Mapping;

namespace NHibernateTest.Mappings
{
	public class DoctorMap : ClassMap<Doctor>
	{
		public DoctorMap()
		{
			Id(x => x.Id).GeneratedBy.Guid();
			Map(x => x.FirstName).Not.Nullable();
			Map(x => x.LastName).Not.Nullable();
			References(x => x.Specialization).Column("Id_Specialization").Cascade.All();
			HasMany(x => x.Records).KeyColumns.Add("Id_Doctor").Inverse().Cascade.All();
		}
	}
}
