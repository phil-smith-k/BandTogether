using BandTogether.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.EntityConfigurations
{
    public class AddressEntityConfig : EntityTypeConfiguration<Address>
    {
        public AddressEntityConfig()
        {
            //Primary Key
            this.HasKey(a => a.AddressId);

            //Properties
            this.Property(a => a.StreetAddress).IsRequired().HasMaxLength(600);
            this.Property(a => a.City).IsRequired().HasMaxLength(500);
            this.Property(a => a.State).IsRequired().HasMaxLength(100);
            this.Property(a => a.ZipCode).IsRequired().HasMaxLength(12);

            //One Address to One School Relationship
            this.HasRequired(a => a.School)
                .WithRequiredDependent(s => s.Address);
        }
    }
}
