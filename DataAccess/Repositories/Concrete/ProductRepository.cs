using restapi.Entities;
using restapi.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Repositories.Concrete
{
    public class ProductRepository : IProdcutRepository
    {

        private IDbTransaction transaction;
        private IDbConnection connection { get { return transaction.Connection; } }

        public ProductRepository(IDbTransaction trancationOfProdcut)
        {
            transaction = trancationOfProdcut;
        }
        public int Add(Product entity)
        {
            int IdOfAddedProdcut = 0;
            object addProductObj = new
            {
                Name = entity.Name,
                Properties = entity.Properties,
                Price = entity.Price,
                Seller = entity.Seller,
                Brand = entity.Brand,
                CategoryId = entity.CategoryId
            };
            IdOfAddedProdcut = connection.ExecuteScalar<int>(@"INSERT INTO Products(Name,Properties,Price,Seller,Brand,CategoryId)
                                            VALUES (@Name,@Properties,@Price,@Seller,@Brand,@CategoryId
                                            SELECT SCOPE_IDENTITY()",
                                            addProductObj,
                                            transaction
                                            );
            return IdOfAddedProdcut;
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
