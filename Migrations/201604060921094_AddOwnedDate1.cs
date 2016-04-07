namespace DMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwnedDate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "DeviceDateOwned", c => c.DateTime(nullable: false));
            DropColumn("dbo.Devices", "DeviceOwned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "DeviceOwned", c => c.DateTime(nullable: false));
            DropColumn("dbo.Devices", "DeviceDateOwned");
        }
    }
}
