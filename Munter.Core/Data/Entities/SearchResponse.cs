using Munter.Core.Models.Giphy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munter.Core.Data.Entities
{
    public class SearchResponse: BaseEntity
    {
        public string SearchText { get; set; }
        public string JsonData { get; set; }
    }
}
