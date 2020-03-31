using BandTogether.Data.Entities.File;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.EntityConfigurations
{
    public class FileEntityConfig : EntityTypeConfiguration<File>
    {
        public FileEntityConfig()
        {
            //Primary Key
            this.HasKey(file => file.FileId);

            //Properties
            this.Property(file => file.FileName).IsRequired().HasMaxLength(500);
            this.Property(file => file.Data).IsRequired();
        }
    }
}
