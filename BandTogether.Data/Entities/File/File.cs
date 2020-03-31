using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.Entities.File
{
    public abstract class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}
