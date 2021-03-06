﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using restapi.Connection.Abstract;
using restapi.Entities;
using restapi.UnitOfWorks.Concrete;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IConnectionFactory connection;
        public ProductController(IConnectionFactory connectionFactory)
        {
            connection = connectionFactory;
        }
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                IEnumerable<Product> results = unit.ProductRepository.GetAll();
                unit.Commit();
                return results;
            }
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                Product result = unit.ProductRepository.Get(id);
                unit.Commit();
                return result;

            }
        }
        [HttpGet("category/{category_id}")]
        public IEnumerable<Product> GetByCategoryId(int category_id)
        {
            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                IEnumerable<Product> results = unit.ProductRepository.ProductByCategory(category_id);
                unit.Commit();
                return results;
            }
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] Product newProduct)
        {
            
            using (UnitOfWork unit = new UnitOfWork(connection))
            {
                unit.ProductRepository.Insert(newProduct);
                unit.Commit();
            }
        }

        [HttpPut]
        public void Put([FromBody] Product updateProduct)
        {
            
            using(UnitOfWork unit = new UnitOfWork(connection))
            {
                unit.ProductRepository.Update(updateProduct);
                unit.Commit();
            }
        }

        [HttpDelete]
        public void Delete([FromBody] Product deleteProduct)
        {
            using(UnitOfWork unit = new UnitOfWork(connection))
            {
                unit.ProductRepository.Delete(deleteProduct);
                unit.Commit();
            }
        }
    }
}
