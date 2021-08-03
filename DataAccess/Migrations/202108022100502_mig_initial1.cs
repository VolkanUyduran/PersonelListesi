namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageFiles", "Id", "dbo.Personels");
            DropIndex("dbo.ImageFiles", new[] { "Id" });
            AddColumn("dbo.Personels", "ImageId", c => c.Int());
            AddColumn("dbo.ImageFiles", "PersonelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Personels", "ImageId");
            AddForeignKey("dbo.Personels", "ImageId", "dbo.ImageFiles", "ImageId");
            DropColumn("dbo.ImageFiles", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageFiles", "Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Personels", "ImageId", "dbo.ImageFiles");
            DropIndex("dbo.Personels", new[] { "ImageId" });
            DropColumn("dbo.ImageFiles", "PersonelId");
            DropColumn("dbo.Personels", "ImageId");
            CreateIndex("dbo.ImageFiles", "Id");
            AddForeignKey("dbo.ImageFiles", "Id", "dbo.Personels", "Id", cascadeDelete: true);
        }
    }
}
