using BandTogether.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.EntityConfigurations
{
    public class SchoolEntityConfig : EntityTypeConfiguration<School>
    {
        public SchoolEntityConfig()
        {
            //Primary Key
            this.HasKey(school => school.SchoolId);

            //Properties
            this.Property(school => school.SchoolName).IsRequired().HasMaxLength(800);
            this.Property(school => school.LowestGrade).IsRequired();
            this.Property(school => school.HighestGrade).IsRequired();

            //One School to One Address Relationship
            this.HasRequired(school => school.Address)
                .WithRequiredPrincipal(address => address.School);
        }
    }
}
