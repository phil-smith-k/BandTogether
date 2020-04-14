﻿using BandTogether.Data.Entities.Enumerations;
using BandTogether.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BandTogether.Models.ResourceModels.EnsembleResourceModels
{
    public class EnsembleEdit : IResourceEdit
    {
        public EnsembleEdit() { }

        public EnsembleEdit(string teacherId, int resourceId, string title, string description, bool isDownloadable, bool isPublic, EnsembleType ensemble, MusicalSkill skill, int level)
        {
            this.TeacherId = teacherId;
            this.ResourceId = resourceId;
            this.Title = title;
            this.Description = description;
            this.IsDownloadable = isDownloadable;
            this.IsPublic = isPublic;
            this.Ensemble = ensemble;
            this.Skill = skill;
            this.GradeLevel = level;
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
        [EnumDataType(typeof(EnsembleType))]
        public EnsembleType Ensemble { get; set; }

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
    }
}
