using restapi.Entities;
using restapi.Repositories.Abstract;
using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using restapi.Connection.Abstract;

namespace restapi.Repositories.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProdcutRepository
    {

        IConnectionFactory connection;
        public ProductRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            connection = connectionFactory;
        }

        public IEnumerable<Product> ProductByCategory(int ProductsCategoryId)
        {
            string sql = @"SELECT * FROM Product WHERE CategoryId = @ProductsCategoryId";
            IEnumerable<Product> results = SqlMapper.Query<Product>(connection.Connect, sql, new { ProductsCategoryId });
            return results;

        }
    }
}
