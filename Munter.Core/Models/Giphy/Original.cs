using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munter.Core.Models.Giphy
{
    public class Original: ImageSize
    {       
        public string size { get; set; }
        public string url { get; set; }
        public string mp4_size { get; set; }
        public string mp4 { get; set; }
        public string webp_size { get; set; }
        public string webp { get; set; }
        public string frames { get; set; }
        public string hash { get; set; }
    }
}
