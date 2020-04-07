using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.FileModels
{
    public class ResourceFileDetail
    {
        public ResourceFileDetail() { }
        public ResourceFileDetail(string name, string content, byte[] data)
        {
            this.FileName = name;
            this.ContentType = content;
            this.Data = data;
        }

        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
