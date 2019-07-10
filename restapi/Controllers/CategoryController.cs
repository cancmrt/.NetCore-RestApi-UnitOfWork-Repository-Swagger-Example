using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restapi.Connection.Abstract;
using restapi.Entities;
using restapi.UnitOfWorks.Concrete;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IConnectionFactory connection;
        public CategoryController(IConnectionFactory connectionFactory)
        {
            connection = connectionFactory;
        }
        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                IEnumerable<Category> results = unit.CategoryRepository.GetAll();
                unit.Commit();
                return results;
            }
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                Category result = unit.CategoryRepository.Get(id);
                unit.Commit();
                return result;
            }
        }

        [HttpGet("top")]
        public IEnumerable<Category> GetTopFive()
        {
            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                IEnumerable<Category> results = unit.CategoryRepository.TopFiveCategory();
                unit.Commit();
                return results;
            }
        }

        [HttpPost]
        public void Post([FromBody] Category newProduct)
        {

            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                unit.CategoryRepository.Insert(newProduct);
                unit.Commit();
            }
        }

        [HttpPut]
        public void Put([FromBody] Category updateProduct)
        {

            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                unit.CategoryRepository.Update(updateProduct);
                unit.Commit();
            }
        }

        [HttpDelete]
        public void Delete([FromBody] Category deleteProduct)
        {
            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                unit.CategoryRepository.Delete(deleteProduct);
                unit.Commit();
            }
        }
    }
}
