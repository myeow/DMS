namespace DMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSomeConstraints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "DeviceOwned", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "DeviceOwned");
        }
    }
}
