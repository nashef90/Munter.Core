using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munter.Core.Models.Giphy
{
    public class Images
    {
        public Original original { get; set; }
        public OriginalStill original_still { get; set; }
        public OriginalMp4 original_mp4 { get; set; }
    }
}
