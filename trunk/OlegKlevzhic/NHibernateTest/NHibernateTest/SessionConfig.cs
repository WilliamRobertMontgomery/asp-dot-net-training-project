using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NHibernateTest.DataAccess;
using NHibernateTest.Mappings;

namespace Repository
{
	public class SessionConfig
	{
		private Configuration Config;
		private ISessionFactory SessionFactory;
		private ISession Session;

		public SessionConfig()
		{
			Configure();
			SessionFactory = InitSessionFactory();
		}

		public IRepository<T> CreateRepository<T>()
		{
			IRepository<T> repo = new Repository<T>(Session);
			return repo;
		}

		private ISessionFactory InitSessionFactory()
		{
			ISessionFactory factory = Config.BuildSessionFactory();
			return factory;
		}

		/// <summary>
		/// Configuration 
		/// </summary>
		private void Configure()
		{
			Config = Fluently.Configure().
				Database(
					MsSqlConfiguration
						.MsSql2008
						.ConnectionString(x => x
							.Server(@"PC-ASSASSIN\SQLSERVERR2")
							.Database("PoliclinicTest")
							.TrustedConnection())
							.UseReflectionOptimizer())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<DoctorMap>())
				.BuildConfiguration();
		}

		//TODO : Use automapping 
		// .Mappings(m => m.AutoMappings.Add(MappingFactory.CreateMappings()))


		public void BuildSchema()
		{
			new SchemaExport(this.Config)
				.Create(true, true);
		}

		public ISession OpenSession()
		{
			if (Session == null)
			{
				Session = SessionFactory.OpenSession();
			}
			return Session;
		}

		public void CloseSession()
		{
			if (Session != null && Session.IsOpen)
			{
				Session.Flush();
				Session.Close();
			}
		}

		public ITransaction BeginTransaction()
		{
			return OpenSession().BeginTransaction();
		}
	}

}
