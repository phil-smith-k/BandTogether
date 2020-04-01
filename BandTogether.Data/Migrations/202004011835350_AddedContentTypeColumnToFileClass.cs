namespace BandTogether.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContentTypeColumnToFileClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.File", "ContentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.File", "ContentType");
        }
    }
}
