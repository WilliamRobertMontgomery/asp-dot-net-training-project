using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NHibernateTest.Entities;

namespace NHibernateTest.Mappings
{
	public class SpecializationMap : ClassMap<Specialization>
	{
		public SpecializationMap()
		{
			Id(x => x.Id).GeneratedBy.Guid();
			Map(x => x.NameSpecialization);
		}
	}
}
