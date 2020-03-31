using BandTogether.Data.Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.Entities.ResourceClasses
{
    public class TheoryResource : Resource
    {
        public TheoryTopic Topic { get; set; }
        public int GradeLevel { get; set; }
    }
}
