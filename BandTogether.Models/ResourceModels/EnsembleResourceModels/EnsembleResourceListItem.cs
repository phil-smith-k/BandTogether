using BandTogether.Data.Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandTogether.Models.ResourceModels.EnsembleResourceModels
{
    public class EnsembleResourceListItem
    {
        public int ResourceId { get; set; }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Title { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public bool IsPublic { get; set; }
        public int GradeLevel { get; set; }
        public string Ensemble { get; set; }
        public string Skill { get; set; }
    }
}