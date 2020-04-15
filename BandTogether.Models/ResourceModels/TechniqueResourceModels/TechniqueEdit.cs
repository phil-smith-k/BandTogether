using BandTogether.Data.Entities;
using BandTogether.Data.Entities.Enumerations;
using BandTogether.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BandTogether.Models.ResourceModels.TechniqueResourceModels
{
    public class TechniqueEdit : IResourceEdit
    {
        public TechniqueEdit() { }

        public TechniqueEdit(string teacherId, int resourceId, string title, string description, bool isDownloadable, bool isPublic, Instrument instrument, MusicalSkill skill, int level, string fileName)
        {
            this.TeacherId = teacherId;
            this.ResourceId = resourceId;
            this.Title = title;
            this.Description = description;
            this.IsDownloadable = isDownloadable;
            this.IsPublic = isPublic;
            this.Instrument = instrument;
            this.Skill = skill;
            this.GradeLevel = level;
            this.FileName = fileName;
        }

        public string TeacherId { get; set; }

        public int ResourceId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Let others download?")]
        public bool IsDownloadable { get; set; }

        [Display(Name = "Make it public?")]
        public bool IsPublic { get; set; }

        [Required]
        [EnumDataType(typeof(Instrument))]
        public Instrument Instrument { get; set; }

        [Required]
        [EnumDataType(typeof(MusicalSkill))]
        public MusicalSkill Skill { get; set; }

        [Required]
        [Display(Name = "Grade Level")]
        [Range(4, 12)]
        public int GradeLevel { get; set; }

        [Required]
        [Display(Name = "File")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase File { get; set; }

        public string FileName { get; set; }
    }
}
