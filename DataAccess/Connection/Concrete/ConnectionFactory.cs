using DataAccess.Connection.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccess.Connection.Concrete
{
    public class ConnectionFactory : IConnectionFactory
    {

        private readonly string connectionString = 
        public IDbConnection Connection { get => throw new NotImplementedException(); }

        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            var connectionString = Configuration["ConnectionStrings:YourConnectionString"];
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
