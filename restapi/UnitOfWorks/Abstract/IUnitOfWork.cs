using restapi.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.UnitOfWorks.Abstract
{
    public interface IUnitOfWork
    {
        ProductRepository ProductRepository { get; }

        CategoryRepository CategoryRepository { get; }

        void Commit();

        void Dispose();

        void ClearRepos();


    }
}
