namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_correctpersonelbyımage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personels", "ImageId", "dbo.ImageFiles");
            DropIndex("dbo.Personels", new[] { "ImageId" });
            CreateIndex("dbo.ImageFiles", "Id");
            AddForeignKey("dbo.ImageFiles", "Id", "dbo.Personels", "Id", cascadeDelete: true);
            DropColumn("dbo.Personels", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personels", "ImageId", c => c.Int());
            DropForeignKey("dbo.ImageFiles", "Id", "dbo.Personels");
            DropIndex("dbo.ImageFiles", new[] { "Id" });
            CreateIndex("dbo.Personels", "ImageId");
            AddForeignKey("dbo.Personels", "ImageId", "dbo.ImageFiles", "ImageId");
        }
    }
}
