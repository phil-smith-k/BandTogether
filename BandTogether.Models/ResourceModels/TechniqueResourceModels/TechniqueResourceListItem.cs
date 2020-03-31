using BandTogether.Data.Entities;
using BandTogether.Data.Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandTogether.Models.ResourceModels.TechniqueResourceModels
{
    public class TechniqueResourceListItem : ResourceListItem
    {
        public int GradeLevel { get; set; }
        public string Instrument { get; set; }
        public string Skill { get; set; }
    }
}