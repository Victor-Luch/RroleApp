namespace RroleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentModels",
                c => new
                    {
                        CommentModelId = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                    })
                .PrimaryKey(t => t.CommentModelId);
            
            CreateTable(
                "dbo.Guides",
                c => new
                    {
                        GuideId = c.Int(nullable: false, identity: true),
                        GuideName = c.String(),
                        HeroOptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GuideId)
                .ForeignKey("dbo.HeroOpts", t => t.HeroOptId, cascadeDelete: true)
                .Index(t => t.HeroOptId);
            
            CreateTable(
                "dbo.HeroOpts",
                c => new
                    {
                        HeroOptId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RoleInGame = c.String(),
                    })
                .PrimaryKey(t => t.HeroOptId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemPrice = c.Int(nullable: false),
                        ItemDescription = c.String(),
                        ItemImage = c.String(),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ItemGuides",
                c => new
                    {
                        Item_ItemId = c.Int(nullable: false),
                        Guide_GuideId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_ItemId, t.Guide_GuideId })
                .ForeignKey("dbo.Items", t => t.Item_ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Guides", t => t.Guide_GuideId, cascadeDelete: true)
                .Index(t => t.Item_ItemId)
                .Index(t => t.Guide_GuideId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ItemGuides", "Guide_GuideId", "dbo.Guides");
            DropForeignKey("dbo.ItemGuides", "Item_ItemId", "dbo.Items");
            DropForeignKey("dbo.Guides", "HeroOptId", "dbo.HeroOpts");
            DropIndex("dbo.ItemGuides", new[] { "Guide_GuideId" });
            DropIndex("dbo.ItemGuides", new[] { "Item_ItemId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Guides", new[] { "HeroOptId" });
            DropTable("dbo.ItemGuides");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Items");
            DropTable("dbo.HeroOpts");
            DropTable("dbo.Guides");
            DropTable("dbo.CommentModels");
        }
    }
}
