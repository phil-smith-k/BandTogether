using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.Entities
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public int LowestGrade { get; set; }
        public int HighestGrade { get; set; }
        public virtual Address Address { get; set; }
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
