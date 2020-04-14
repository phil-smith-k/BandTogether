using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.ResourceModels
{
    public class ResourceDelete
    {
        public ResourceDelete() { }

        public ResourceDelete(int id, string teacherId, string title, string description, DateTimeOffset date)
        {
            this.ResourceId = id;
            this.TeacherId = teacherId;
            this.Title = title;
            this.Description = description;
            this.DateCreated = date;
        }

        public int ResourceId { get; set; }
        public string TeacherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
