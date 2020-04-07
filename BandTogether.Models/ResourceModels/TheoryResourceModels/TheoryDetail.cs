using BandTogether.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.ResourceModels.TheoryResourceModels
{
    public class TheoryDetail : IResourceDetail
    {
        public TheoryDetail() { }

        public TheoryDetail(int resourceId, string teacherId, string title, string description, DateTimeOffset created, DateTimeOffset? modified, bool isDownloadable, bool isPublic, int fileId, string topic, int gradeLevel)
        {
            this.ResourceId = resourceId;
            this.TeacherId = teacherId;
            this.Title = title;
            this.Description = description;
            this.DateCreated = created;
            this.DateModified = modified;
            this.IsDownloadable = isDownloadable;
            this.IsPublic = isPublic;
            this.FileId = fileId;
            this.Topic = topic;
            this.GradeLevel = gradeLevel;
        }

        public int ResourceId { get; set; }
        public string TeacherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreated { get; set; }

        [Display(Name = "Last Modified")]
        public DateTimeOffset? DateModified { get; set; }

        public bool IsDownloadable { get; set; }
        public bool IsPublic { get; set; }
        public int FileId { get; set; }
        public int GradeLevel { get; set; }
        public string Topic { get; set; }
    }
}
