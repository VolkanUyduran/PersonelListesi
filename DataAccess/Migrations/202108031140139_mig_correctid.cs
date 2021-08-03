namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_correctid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageFiles", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.ImageFiles", "PersonelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageFiles", "PersonelId", c => c.Int(nullable: false));
            DropColumn("dbo.ImageFiles", "Id");
        }
    }
}
