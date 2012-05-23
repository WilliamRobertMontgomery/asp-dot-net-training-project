using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LabTwo.Cinema.Entities
{
    public class CustomCinemaDataContext : DataContext
    {
        private static readonly string attachDbFileName = ConfigurationSettings.AppSettings["FullPathDbFilename"];

        private static readonly string dataSource = ConfigurationSettings.AppSettings["DataSource"];

        private static readonly SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
        {
            AttachDBFilename = attachDbFileName,
            DataSource = dataSource,
            IntegratedSecurity = true,
            ConnectTimeout = 30
        };

        public CustomCinemaDataContext()
            : base(connectionStringBuilder.ConnectionString) { }

        public CustomCinemaDataContext(MappingSource mappingSource)
            : base(connectionStringBuilder.ConnectionString, mappingSource) { }

        public CustomCinemaDataContext(string connectionString)
            : base(connectionString) { }

        public CustomCinemaDataContext(string connectionString, MappingSource mappingSource)
            : base(connectionString, mappingSource) { }

        public CustomCinemaDataContext(IDbConnection connection, MappingSource mappingSource)
            : base(connection, mappingSource) { }
    }
}