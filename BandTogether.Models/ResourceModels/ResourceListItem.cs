using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.ResourceModels
{
    public class ResourceListItem
    {
        public int ResourceId { get; set; }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Title { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public bool IsPublic { get; set; }
    }
}
