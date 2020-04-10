using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Description { get; set; }
        [Display(Name = "Added")]
        public DateTimeOffset DateCreated { get; set; }
        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }
    }
}
