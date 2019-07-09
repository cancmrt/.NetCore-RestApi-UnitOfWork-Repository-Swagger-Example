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
                return unit.CategoryRepository.GetAll();
            }
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                return unit.CategoryRepository.Get(id);
            }
        }

        [HttpGet("top")]
        public IEnumerable<Category> GetTopFive()
        {
            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                return unit.CategoryRepository.TopFiveCategory();
            }
        }

        [HttpPost]
        public void Post([FromBody] Category newProduct)
        {

            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                unit.CategoryRepository.Insert(newProduct);
            }
        }

        [HttpPut]
        public void Put([FromBody] Category updateProduct)
        {

            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                unit.CategoryRepository.Update(updateProduct);
            }
        }

        [HttpDelete]
        public void Delete([FromBody] Category deleteProduct)
        {
            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                unit.CategoryRepository.Delete(deleteProduct);
            }
        }
    }
}
