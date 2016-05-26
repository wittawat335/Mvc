namespace ShoppingComplex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ooo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            RenameColumn(table: "dbo.AspNetUserClaims", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.AspNetUserClaims", name: "IX_UserId", newName: "IX_User_Id");
            DropPrimaryKey("dbo.AspNetUserLogins");
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WebActionId = c.Int(nullable: false),
                        RoleId = c.String(maxLength: 128),
                        Allowable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WebActions", t => t.WebActionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.WebActionId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.WebActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Controller = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String());
            AlterColumn("dbo.AspNetUsers", "ConfirmedEmail", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "UserId", "LoginProvider", "ProviderKey" });
            DropColumn("dbo.AspNetUsers", "EmailConfirmed");
            DropColumn("dbo.AspNetUsers", "PhoneNumber");
            DropColumn("dbo.AspNetUsers", "PhoneNumberConfirmed");
            DropColumn("dbo.AspNetUsers", "TwoFactorEnabled");
            DropColumn("dbo.AspNetUsers", "LockoutEndDateUtc");
            DropColumn("dbo.AspNetUsers", "LockoutEnabled");
            DropColumn("dbo.AspNetUsers", "AccessFailedCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmailConfirmed", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Permissions", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Permissions", "WebActionId", "dbo.WebActions");
            DropIndex("dbo.Permissions", new[] { "RoleId" });
            DropIndex("dbo.Permissions", new[] { "WebActionId" });
            DropPrimaryKey("dbo.AspNetUserLogins");
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "ConfirmedEmail", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropTable("dbo.WebActions");
            DropTable("dbo.Permissions");
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            RenameIndex(table: "dbo.AspNetUserClaims", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.AspNetUserClaims", name: "User_Id", newName: "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
        }
    }
}
