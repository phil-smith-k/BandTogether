using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.EditProfileModels
{
    public class EditProfileName
    {
        public EditProfileName() { }
        public EditProfileName(string id, string firstName, string lastName)
        {
            this.TeacherId = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        [Required]
        public string TeacherId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
