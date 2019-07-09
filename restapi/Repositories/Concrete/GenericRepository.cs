using restapi.Repositories.Abstract;
using System;
using System.Collections.Generic;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Linq;
using System.Threading.Tasks;
using restapi.Connection.Abstract;

namespace restapi.Repositories.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        IConnectionFactory connection;
        public GenericRepository(IConnectionFactory connectionFactory)
        {
            connection = connectionFactory;
        }
        public bool Delete(TEntity entity)
        {
            var deleted = SqlMapperExtensions.Delete<TEntity>(connection.Connect, entity);
            return deleted;
        }

        public TEntity Get(int Id)
        {
            TEntity result = SqlMapperExtensions.Get<TEntity>(connection.Connect,Id);
            return result;
        }

        public IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> results = SqlMapperExtensions.GetAll<TEntity>(connection.Connect);
            return results;
        }

        public long Insert(TEntity entity)
        {
            var added = SqlMapperExtensions.Insert<TEntity>(connection.Connect, entity);
            return added;
        }

        public bool Update(TEntity entity)
        {
            var updated = SqlMapperExtensions.Update<TEntity>(connection.Connect, entity);
            return updated;
        }
    }
}
