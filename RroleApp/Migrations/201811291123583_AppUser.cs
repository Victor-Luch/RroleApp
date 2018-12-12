namespace RroleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommentModels", "ApplicationUsers_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CommentModels", "ApplicationUsers_Id");
            AddForeignKey("dbo.CommentModels", "ApplicationUsers_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentModels", "ApplicationUsers_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CommentModels", new[] { "ApplicationUsers_Id" });
            DropColumn("dbo.CommentModels", "ApplicationUsers_Id");
        }
    }
}
