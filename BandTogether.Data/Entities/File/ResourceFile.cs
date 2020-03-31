using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandTogether.Data.Entities.ResourceClasses;

namespace BandTogether.Data.Entities.File
{
    public class ResourceFile : File
    {
        public virtual Resource Resource { get; set; }
    }
}
