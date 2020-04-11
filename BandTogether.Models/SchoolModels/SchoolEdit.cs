using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.SchoolModels
{
    public class SchoolEdit
    {
        public SchoolEdit() { }
        public SchoolEdit(string teacherId, int schoolId, string name, string address, string city, string state, string zip, int lowestGrade, int highestGrade)
        {
            this.TeacherId = teacherId;
            this.SchoolId = schoolId;
            this.SchoolName = name;
            this.StreetAddress = address;
            this.City = city;
            this.State = state;
            this.ZipCode = zip;
            this.LowestGradeLevel = lowestGrade;
            this.HighestGradeLevel = highestGrade;
        }

        public string TeacherId { get; set; }
        public int SchoolId { get; set; }

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

        [Required]
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
