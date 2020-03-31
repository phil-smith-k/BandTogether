using BandTogether.Data.Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.Entities.ResourceClasses
{
    public class EnsembleResource : Resource
    {
        public EnsembleType Ensemble { get; set; }
        public MusicalSkill Skill { get; set; }
        public int GradeLevel { get; set; }
    }
}
