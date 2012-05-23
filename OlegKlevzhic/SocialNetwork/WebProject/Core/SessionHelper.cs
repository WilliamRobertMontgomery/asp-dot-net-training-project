using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using FluentNHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using WebProject.DataAccess.Mappings;

namespace WebProject.Core
{
	public static class SessionHelper
	{
		private static ISessionFactory _sessionFactory;
		private static NHibernate.Cfg.Configuration _configuration;

		public static ISessionFactory SessionFactory
		{
			get
			{
				if (_sessionFactory == null)
				{
					CreateSessionFactory();
				}
				return _sessionFactory;
			}
			set
			{
				_sessionFactory = value;
			}
		}

		public static NHibernate.Cfg.Configuration Configuration
		{
			get
			{
				if (_configuration == null)
				{
					CreateConfiguration();
				}
				return _configuration;
			}
			set
			{
				_configuration = value;
			}
		}

		private static void CreateSessionFactory()
		{
			_sessionFactory = Configuration.BuildSessionFactory();
		}

		private static void CreateConfiguration()
		{
			_configuration = Fluently.Configure()
					.Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2005
					.ConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings["SocialNetwork"].ConnectionString))
					.Mappings(m =>
					m.FluentMappings.AddFromAssemblyOf<UserMap>())
					.BuildConfiguration();
		}

		public static void BuildSchema()
		{
			new SchemaExport(Fluently.Configure()
				.Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2005
				.ConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings["SocialNetwork"].ConnectionString)
				).Mappings(m =>
					m.FluentMappings.AddFromAssemblyOf<UserMap>()).BuildConfiguration()).Create(true, true);
		}
	}
}