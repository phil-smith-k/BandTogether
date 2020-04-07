using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.SchoolModels
{
    public class SchoolCreate
    {
        public string TeacherId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string SchoolName { get; set; }
        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Must be valid US Zip Code.")]
        public string ZipCode { get; set; }
        [Required]
        [Display(Name = "Lowest Grade Level")]
        [Range(1, 12)]
        public int LowestGradeLevel { get; set; }
        [Required]
        [Display(Name = "Highest Grade Level")]
        [Range(1, 12)]
        public int HighestGradeLevel { get; set; }
    }
}
