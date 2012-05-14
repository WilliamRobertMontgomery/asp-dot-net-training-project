using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;

namespace Lab4.Library.Models
{
    public class CustomLibraryDataContext : DataContext
    {
		private static readonly string attachDbFileName = ConfigurationManager.AppSettings["FullPathDbFilename"];

		private static readonly string dataSource = ConfigurationManager.AppSettings["DataSource"];

        private static readonly SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
        {
            AttachDBFilename = attachDbFileName,
            DataSource = dataSource,
            IntegratedSecurity = true,
            ConnectTimeout = 30
        };
 
        public CustomLibraryDataContext() 
            : base(connectionStringBuilder.ConnectionString) { }

		public CustomLibraryDataContext(MappingSource mappingSource)
			: base(connectionStringBuilder.ConnectionString, mappingSource) { }

		public CustomLibraryDataContext(string connectionString)
            : base(connectionString) { }

        public CustomLibraryDataContext(string connectionString, MappingSource mappingSource) 
            : base(connectionString, mappingSource) { }

        public CustomLibraryDataContext(IDbConnection connection, MappingSource mappingSource) 
            : base(connection, mappingSource) { }        
    }
}
