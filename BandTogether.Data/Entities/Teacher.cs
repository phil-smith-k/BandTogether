using BandTogether.Data.Entities.File;
using BandTogether.Data.Entities.ResourceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.Entities
{
    public class Teacher : ApplicationUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ImageFile ProfilePicture { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Teacher> Followers { get; set; }
        public virtual ICollection<Teacher> Following { get; set; }
        public virtual ICollection<School> Schools { get; set; }
    }
}
