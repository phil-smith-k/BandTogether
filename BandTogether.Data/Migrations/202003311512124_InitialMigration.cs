namespace BandTogether.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false),
                        StreetAddress = c.String(nullable: false, maxLength: 600),
                        City = c.String(nullable: false, maxLength: 500),
                        State = c.String(nullable: false, maxLength: 100),
                        ZipCode = c.String(nullable: false, maxLength: 12),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.School", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.School",
                c => new
                    {
                        SchoolId = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(nullable: false, maxLength: 800),
                        LowestGrade = c.Int(nullable: false),
                        HighestGrade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SchoolId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        FileId = c.Int(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 500),
                        Data = c.Binary(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Teacher_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.ApplicationUser", t => t.Teacher_Id)
                .ForeignKey("dbo.Resource", t => t.FileId)
                .Index(t => t.FileId)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Resource",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 600),
                        Description = c.String(nullable: false),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        IsDownloadable = c.Boolean(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        Ensemble = c.Int(),
                        Skill = c.Int(),
                        GradeLevel = c.Int(),
                        Instrument = c.Int(),
                        Skill1 = c.Int(),
                        GradeLevel1 = c.Int(),
                        Topic = c.Int(),
                        GradeLevel2 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ResourceId)
                .ForeignKey("dbo.ApplicationUser", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherFollowJoin",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FollowedId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FollowedId })
                .ForeignKey("dbo.ApplicationUser", t => t.FollowerId)
                .ForeignKey("dbo.ApplicationUser", t => t.FollowedId)
                .Index(t => t.FollowerId)
                .Index(t => t.FollowedId);
            
            CreateTable(
                "dbo.TeacherSchoolJoin",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherId, t.SchoolId })
                .ForeignKey("dbo.ApplicationUser", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.School", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SchoolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Address", "AddressId", "dbo.School");
            DropForeignKey("dbo.TeacherSchoolJoin", "SchoolId", "dbo.School");
            DropForeignKey("dbo.TeacherSchoolJoin", "TeacherId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Resource", "TeacherId", "dbo.ApplicationUser");
            DropForeignKey("dbo.File", "FileId", "dbo.Resource");
            DropForeignKey("dbo.File", "Teacher_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.TeacherFollowJoin", "FollowedId", "dbo.ApplicationUser");
            DropForeignKey("dbo.TeacherFollowJoin", "FollowerId", "dbo.ApplicationUser");
            DropIndex("dbo.TeacherSchoolJoin", new[] { "SchoolId" });
            DropIndex("dbo.TeacherSchoolJoin", new[] { "TeacherId" });
            DropIndex("dbo.TeacherFollowJoin", new[] { "FollowedId" });
            DropIndex("dbo.TeacherFollowJoin", new[] { "FollowerId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Resource", new[] { "TeacherId" });
            DropIndex("dbo.File", new[] { "Teacher_Id" });
            DropIndex("dbo.File", new[] { "FileId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Address", new[] { "AddressId" });
            DropTable("dbo.TeacherSchoolJoin");
            DropTable("dbo.TeacherFollowJoin");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.Resource");
            DropTable("dbo.File");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.School");
            DropTable("dbo.Address");
        }
    }
}
