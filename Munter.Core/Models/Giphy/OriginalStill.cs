using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munter.Core.Models.Giphy
{
    public class OriginalStill : ImageSize
    {
        public string size { get; set; }
        public string url { get; set; }
    }
}
