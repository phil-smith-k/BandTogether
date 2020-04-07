using BandTogether.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.EntityConfigurations
{
    public class TeacherEntityConfig : EntityTypeConfiguration<Teacher>
    {
        public TeacherEntityConfig()
        {
            //Primary Key
            this.HasKey(teacher => teacher.Id);

            //Properties
            this.Property(teacher => teacher.FirstName);
            this.Property(teacher => teacher.LastName);

            //One Teacher to Zero or One ImageFile Relationship
            this.HasOptional(teacher => teacher.ProfilePicture)
                .WithRequired(file => file.Teacher);

            //Many Teachers to Many Teachers Relationship
            this.HasMany(teacher => teacher.Following)
                .WithMany(teacher => teacher.Followers)
                .Map(table => table.ToTable("TeacherFollowJoin")
                .MapLeftKey("FollowerId")
                .MapRightKey("FollowedId"));

            //Many Schools to Zero or One Teacher Relationship 
            this.HasMany(teacher => teacher.Schools)
                .WithOptional(school => school.Teacher)
                .HasForeignKey(school => school.TeacherId);


            //One Teacher to Many Resources Relationship
            this.HasMany(teacher => teacher.Resources)
                .WithRequired(res => res.Teacher)
                .HasForeignKey(res => res.TeacherId);
        }
    }
}
