using Dapper;
using restapi.Connection.Abstract;
using restapi.Entities;
using restapi.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Repositories.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        IConnectionFactory connection;
        public CategoryRepository(IConnectionFactory connectionFactory):base(connectionFactory)
        {
            connection = connectionFactory;
        }
        public IEnumerable<Category> TopFiveCategory()
        {
            string sql = @"SELECT TOP 5 * FROM Category";
            IEnumerable<Category> results = SqlMapper.Query<Category>(connection.Connect, sql);
            return results;
        }
    }
}
