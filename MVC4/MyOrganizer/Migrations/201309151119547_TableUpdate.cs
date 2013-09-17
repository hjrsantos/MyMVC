namespace MVC4.MyOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AppUsers", "RememberMe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppUsers", "RememberMe", c => c.Boolean(nullable: false));
        }
    }
}
