namespace MVC4.MyOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAppuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoItems", "AppUser_Id", c => c.Int());
            AddForeignKey("dbo.TodoItems", "AppUser_Id", "dbo.AppUsers", "Id");
            CreateIndex("dbo.TodoItems", "AppUser_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TodoItems", new[] { "AppUser_Id" });
            DropForeignKey("dbo.TodoItems", "AppUser_Id", "dbo.AppUsers");
            DropColumn("dbo.TodoItems", "AppUser_Id");
        }
    }
}
