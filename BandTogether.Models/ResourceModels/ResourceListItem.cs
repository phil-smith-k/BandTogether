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
        public ResourceListItem() { }
        public ResourceListItem(int id, string teacherId, string teacherName, string title, string description, DateTimeOffset date, bool isPublic, string content, byte[] data)
        {
            this.ResourceId = id;
            this.TeacherId = teacherId;
            this.TeacherName = teacherName;
            this.Title = title;
            this.Description = description;
            this.DateCreated = date;
            this.IsPublic = isPublic;
            this.ContentType = content;
            this.ImageData = data;
        }

        public int ResourceId { get; set; }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Added")]
        public DateTimeOffset DateCreated { get; set; }
        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }
        public string ContentType { get; set; }
        public byte[] ImageData { get; set; }
    }
}
