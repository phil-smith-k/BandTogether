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
        public int? ImageFileId { get; set; }
        public virtual ImageFile ProfilePicture { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Teacher> Followers { get; set; }
        public ICollection<Teacher> Following { get; set; }
        public ICollection<School> Schools { get; set; }
    }
}
