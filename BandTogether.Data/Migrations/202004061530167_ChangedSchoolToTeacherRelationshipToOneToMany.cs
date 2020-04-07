namespace BandTogether.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedSchoolToTeacherRelationshipToOneToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherSchoolJoin", "TeacherId", "dbo.ApplicationUser");
            DropForeignKey("dbo.TeacherSchoolJoin", "SchoolId", "dbo.School");
            DropIndex("dbo.TeacherSchoolJoin", new[] { "TeacherId" });
            DropIndex("dbo.TeacherSchoolJoin", new[] { "SchoolId" });
            AddColumn("dbo.School", "TeacherId", c => c.String(maxLength: 128));
            CreateIndex("dbo.School", "TeacherId");
            AddForeignKey("dbo.School", "TeacherId", "dbo.ApplicationUser", "Id");
            DropTable("dbo.TeacherSchoolJoin");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TeacherSchoolJoin",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherId, t.SchoolId });
            
            DropForeignKey("dbo.School", "TeacherId", "dbo.ApplicationUser");
            DropIndex("dbo.School", new[] { "TeacherId" });
            DropColumn("dbo.School", "TeacherId");
            CreateIndex("dbo.TeacherSchoolJoin", "SchoolId");
            CreateIndex("dbo.TeacherSchoolJoin", "TeacherId");
            AddForeignKey("dbo.TeacherSchoolJoin", "SchoolId", "dbo.School", "SchoolId", cascadeDelete: true);
            AddForeignKey("dbo.TeacherSchoolJoin", "TeacherId", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
    }
}
