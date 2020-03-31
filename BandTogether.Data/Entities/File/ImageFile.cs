using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.Entities.File
{
    public class ImageFile : File
    {
        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
