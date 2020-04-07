using BandTogether.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.ResourceModels.EnsembleResourceModels
{
    public class EnsembleDetail : IResourceDetail
    {
        public EnsembleDetail() { }

        public EnsembleDetail(int resourceId, string teacherId, string title, string description, DateTimeOffset created, DateTimeOffset? modified, bool isDownloadable, bool isPublic, int fileId, string skill, string ensemble, int gradeLevel)
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
            this.Skill = skill;
            this.Ensemble = ensemble;
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
        public string Skill { get; set; }
        public string Ensemble { get; set; }
        public int GradeLevel { get; set; }
    }
}
