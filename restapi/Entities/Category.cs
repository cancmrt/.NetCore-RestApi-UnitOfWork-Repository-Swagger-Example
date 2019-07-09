using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Entities
{
    [Table("Category")]
    public class Category:BaseEntity
    {
        public String Name { get; set; }

        public String Properties { get; set; }
    }
}
