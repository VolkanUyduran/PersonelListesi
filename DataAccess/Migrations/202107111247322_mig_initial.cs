namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                        Surname = c.String(maxLength: 20),
                        Tel = c.String(maxLength: 20),
                        DateOfBirth = c.DateTime(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DirectorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Directors", t => t.DirectorId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DirectorId);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Email = c.String(maxLength: 50),
                        AdminPasswordHash = c.Binary(),
                        AdminPasswordSalt = c.Binary(),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Personels", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageFiles", "Id", "dbo.Personels");
            DropForeignKey("dbo.Personels", "DirectorId", "dbo.Directors");
            DropForeignKey("dbo.Personels", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.ImageFiles", new[] { "Id" });
            DropIndex("dbo.Personels", new[] { "DirectorId" });
            DropIndex("dbo.Personels", new[] { "DepartmentId" });
            DropTable("dbo.ImageFiles");
            DropTable("dbo.Directors");
            DropTable("dbo.Personels");
            DropTable("dbo.Departments");
        }
    }
}
