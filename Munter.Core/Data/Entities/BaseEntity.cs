using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munter.Core.Data.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
