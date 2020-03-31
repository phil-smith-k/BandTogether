using BandTogether.Data.Entities;
using BandTogether.Data.Entities.File;
using BandTogether.Data.Entities.ResourceClasses;
using BandTogether.Data.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<File> Files { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<ResourceFile> ResourceFiles { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<TechniqueResource> TechniqueResources { get; set; }
        public DbSet<EnsembleResource> EnsembleResources { get; set; }
        public DbSet<TheoryResource> TheoryResources { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }
}
