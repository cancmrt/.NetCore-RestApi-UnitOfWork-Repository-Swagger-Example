using restapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Repositories.Abstract
{
    public interface IProdcutRepository
    {
        Product Get(int id);

        IEnumerable<Product> GetAll();

        int Add(Product entity);

        bool Update(Product entity);

        bool Remove(int id);
    }
}
