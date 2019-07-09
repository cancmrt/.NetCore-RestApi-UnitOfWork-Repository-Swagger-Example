using restapi.Connection.Abstract;
using restapi.Repositories.Concrete;
using restapi.UnitOfWorks.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IConnectionFactory factoryConnection;
        private IDbConnection connection;
        private IDbTransaction transaction;

        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(IConnectionFactory connectionFactory)
        {
            factoryConnection = connectionFactory;
            connection = factoryConnection.Connect;
            transaction = connection.BeginTransaction();
        }
        public ProductRepository ProductRepository
        {
            get
            {
                return _productRepository ?? (_productRepository = new ProductRepository(factoryConnection));
            }
        }
        public CategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository ?? (_categoryRepository = new CategoryRepository(factoryConnection));
            }
        }

        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
                transaction = connection.BeginTransaction();
                ClearRepos();
                
            }
        }
        public void Dispose()
        {
            if (factoryConnection != null) { factoryConnection.Dispose(); factoryConnection = null; }
            if (transaction != null) { transaction.Dispose(); transaction = null; }
            if (connection != null) { connection.Dispose(); connection = null; }
        }

        public void ClearRepos()
        {
            _productRepository = null;
            _categoryRepository = null;
        }
    }
}
