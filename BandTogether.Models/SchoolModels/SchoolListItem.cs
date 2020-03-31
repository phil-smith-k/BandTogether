using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandTogether.Models.SchoolModels
{
    public class SchoolListItem
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}