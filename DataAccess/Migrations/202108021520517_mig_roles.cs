namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_roles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 20),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Directors", "RoleId", c => c.Int());
            CreateIndex("dbo.Directors", "RoleId");
            AddForeignKey("dbo.Directors", "RoleId", "dbo.Roles", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Directors", "RoleId", "dbo.Roles");
            DropIndex("dbo.Directors", new[] { "RoleId" });
            DropColumn("dbo.Directors", "RoleId");
            DropTable("dbo.Roles");
        }
    }
}
