namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageFiles", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImageFiles", "ImageName");
        }
    }
}
