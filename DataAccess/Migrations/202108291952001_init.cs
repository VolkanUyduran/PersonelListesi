namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personels", "Name", c => c.String(maxLength: 25));
            AlterColumn("dbo.Personels", "Surname", c => c.String(maxLength: 20));
            AlterColumn("dbo.Personels", "Tel", c => c.String(maxLength: 20));
            AlterColumn("dbo.Directors", "AdminPasswordHash", c => c.String());
            AlterColumn("dbo.Directors", "AdminPasswordSalt", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Directors", "AdminPasswordSalt", c => c.Binary());
            AlterColumn("dbo.Directors", "AdminPasswordHash", c => c.Binary());
            AlterColumn("dbo.Personels", "Tel", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Personels", "Surname", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Personels", "Name", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
