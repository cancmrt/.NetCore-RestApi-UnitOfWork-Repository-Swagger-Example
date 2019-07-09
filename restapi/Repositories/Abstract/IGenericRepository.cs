using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Repositories.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();

        long Insert(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);
    }
}
