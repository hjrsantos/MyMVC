namespace MVC4.MyOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMDF : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        Title = c.String(),
                        AppUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TodoItems", new[] { "AppUser_Id" });
            DropForeignKey("dbo.TodoItems", "AppUser_Id", "dbo.AppUsers");
            DropTable("dbo.Categories");
            DropTable("dbo.AppUsers");
            DropTable("dbo.TodoItems");
        }
    }
}
