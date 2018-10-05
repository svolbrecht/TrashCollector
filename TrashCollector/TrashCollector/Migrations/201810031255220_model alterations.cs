namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelalterations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickupId", c => c.Int());
            AddColumn("dbo.Pickups", "SpecialPickUp", c => c.DateTime());
            AddColumn("dbo.Pickups", "StartPickUp", c => c.DateTime());
            AddColumn("dbo.Pickups", "EndPickUp", c => c.DateTime());
            AlterColumn("dbo.Customers", "Balance", c => c.Double(nullable: false));
            CreateIndex("dbo.Customers", "PickupId");
            AddForeignKey("dbo.Customers", "PickupId", "dbo.Pickups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "PickupId", "dbo.Pickups");
            DropIndex("dbo.Customers", new[] { "PickupId" });
            AlterColumn("dbo.Customers", "Balance", c => c.String());
            DropColumn("dbo.Pickups", "EndPickUp");
            DropColumn("dbo.Pickups", "StartPickUp");
            DropColumn("dbo.Pickups", "SpecialPickUp");
            DropColumn("dbo.Customers", "PickupId");
        }
    }
}
