using Microsoft.Extensions.Configuration;
using restapi.Connection.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Connection.Concrete
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection Connect {
            get
            {
                DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
                var DbFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var Connection = DbFactory.CreateConnection();
                Connection.ConnectionString = GetConnectionString();
                Connection.Open();
                return Connection;
            }
        }

        public void Dispose()
        {
            
        }

        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfigurationRoot Configuration = builder.Build();
            var connectionString = Configuration.GetSection("ConnectionStrings:MSSQLConnection");

            return connectionString.Value;
        }
    }
}
