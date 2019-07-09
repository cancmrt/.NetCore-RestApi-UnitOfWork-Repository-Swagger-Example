using restapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Repositories.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        IEnumerable<Category> TopFiveCategory();
    }
}
