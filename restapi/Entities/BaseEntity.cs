using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreationTime { get; set; }
        public bool IsRowActive { get; set; }
    }
}
