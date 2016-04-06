namespace DMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        DeviceId = c.Int(nullable: false, identity: true),
                        DeviceName = c.String(nullable: false, maxLength: 100),
                        DeviceOwner = c.String(nullable: false, maxLength: 100),
                        DeviceDateCreated = c.DateTime(nullable: false),
                        DeviceCreatedBy = c.String(),
                        DeviceDateModified = c.DateTime(nullable: false),
                        DeviceModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.DeviceId);
            
            CreateTable(
                "dbo.DeviceSpecsContents",
                c => new
                    {
                        DeviceSpecsContentId = c.Int(nullable: false, identity: true),
                        DeviceSpecsCatId = c.Int(nullable: false),
                        DeviceId = c.Int(nullable: false),
                        DeviceSpecsContentVal = c.String(),
                        DeviceSpecsContentDateCreated = c.DateTime(nullable: false),
                        DeviceSpecsContentCreatedBy = c.String(),
                        DeviceSpecsContentDateModified = c.DateTime(nullable: false),
                        DeviceSpecsContentModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.DeviceSpecsContentId)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceSpecsCats", t => t.DeviceSpecsCatId, cascadeDelete: true)
                .Index(t => t.DeviceSpecsCatId)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.DeviceSpecsCats",
                c => new
                    {
                        DeviceSpecsCatId = c.Int(nullable: false, identity: true),
                        DeviceSpecsCatName = c.String(nullable: false, maxLength: 100),
                        DeviceSpecsCatDateCreated = c.DateTime(nullable: false),
                        DeviceSpecsCatCreatedBy = c.String(),
                        DeviceSpecsCatDateModified = c.DateTime(nullable: false),
                        DeviceSpecsCatModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.DeviceSpecsCatId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DeviceSpecsContents", "DeviceSpecsCatId", "dbo.DeviceSpecsCats");
            DropForeignKey("dbo.DeviceSpecsContents", "DeviceId", "dbo.Devices");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.DeviceSpecsContents", new[] { "DeviceId" });
            DropIndex("dbo.DeviceSpecsContents", new[] { "DeviceSpecsCatId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.DeviceSpecsCats");
            DropTable("dbo.DeviceSpecsContents");
            DropTable("dbo.Devices");
        }
    }
}
