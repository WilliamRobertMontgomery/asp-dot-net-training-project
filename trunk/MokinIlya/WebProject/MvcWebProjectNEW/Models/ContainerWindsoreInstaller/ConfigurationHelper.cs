using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using MvcWebProjectNEW;

namespace Models.DataAccess
{
    public class NHibernateHelper
    {
        public static Configuration BuildDatabaseConfig()
        {
            var dbConfig = MsSqlConfiguration.MsSql2008
                .ConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

            return Fluently.Configure()
            .Database(dbConfig)
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MvcApplication>())
                //.ExposeConfiguration(config => config.SetProperty("current_session_context_class", "web"))
            .BuildConfiguration();
        }
    }
}