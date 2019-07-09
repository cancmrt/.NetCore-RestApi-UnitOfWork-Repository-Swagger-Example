using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Entities
{
    public class Category:BaseEntity
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Properties { get; set; }
    }
}
