using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Entities
{
    [Table("Product")]
    public class Product:BaseEntity
    {
        public String Name { get; set; }

        public String Properties { get; set; }

        public double Price { get; set; }

        public String Seller { get; set; }

        public String Brand { get; set; }

        public int CategoryId { get; set; }


    }
}
