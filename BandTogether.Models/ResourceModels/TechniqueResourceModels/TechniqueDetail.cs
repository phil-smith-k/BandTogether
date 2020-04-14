using BandTogether.Data.Entities;
using BandTogether.Data.Entities.Enumerations;
using BandTogether.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.ResourceModels.TechniqueResourceModels
{
    public class TechniqueDetail : IResourceDetail
    {
        public TechniqueDetail() { }

        public TechniqueDetail(int resourceId, string teacherId, string name, string title, string description, DateTimeOffset created, DateTimeOffset? modified, bool isDownloadable, bool isPublic, int fileId, string content, byte[] data, MusicalSkill skill, Instrument instrument, int gradeLevel)
        {
            this.ResourceId = resourceId;
            this.TeacherId = teacherId;
            this.TeacherName = name;
            this.Title = title;
            this.Description = description;
            this.DateCreated = created;
            this.DateModified = modified;
            this.IsDownloadable = isDownloadable;
            this.IsPublic = isPublic;
            this.FileId = fileId;
            this.ContentType = content;
            this.FileData = data;
            this.Skill = skill;
            this.Instrument = instrument;
            this.GradeLevel = gradeLevel;
        }

        public int ResourceId { get; set; }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Added")]
        public DateTimeOffset DateCreated { get; set; }

        [Display(Name = "Last Updated")]
        public DateTimeOffset? DateModified { get; set; }

        public bool IsDownloadable { get; set; }
        public bool IsPublic { get; set; }
        public int FileId { get; set; }
        public string ContentType { get; set; }
        public byte[] FileData { get; set; }

        [EnumDataType(typeof(MusicalSkill))]
        public MusicalSkill Skill { get; set; }

        [EnumDataType(typeof(Instrument))]
        public Instrument Instrument { get; set; }

        [Display(Name = "Grade Level")]
        public int GradeLevel { get; set; }
    }
}
