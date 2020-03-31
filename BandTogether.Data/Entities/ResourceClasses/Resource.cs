using BandTogether.Data.Entities.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.Entities.ResourceClasses
{
    public abstract class Resource
    {
        public int ResourceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public bool IsDownloadable { get; set; }
        public bool IsPublic { get; set; }
        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ResourceFile File { get; set; }
    }
}
