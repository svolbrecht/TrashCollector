namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anothermodelupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "PickupId", "dbo.Pickups");
            DropIndex("dbo.Customers", new[] { "PickupId" });
            AddColumn("dbo.Customers", "WeeklyPickUp", c => c.DateTime());
            AddColumn("dbo.Customers", "SpecialPickUp", c => c.DateTime());
            AddColumn("dbo.Customers", "StartPickUp", c => c.DateTime());
            AddColumn("dbo.Customers", "EndPickUp", c => c.DateTime());
            DropColumn("dbo.Customers", "PickupId");
            DropTable("dbo.Pickups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeeklyPickUp = c.DateTime(),
                        SpecialPickUp = c.DateTime(),
                        StartPickUp = c.DateTime(),
                        EndPickUp = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "PickupId", c => c.Int());
            DropColumn("dbo.Customers", "EndPickUp");
            DropColumn("dbo.Customers", "StartPickUp");
            DropColumn("dbo.Customers", "SpecialPickUp");
            DropColumn("dbo.Customers", "WeeklyPickUp");
            CreateIndex("dbo.Customers", "PickupId");
            AddForeignKey("dbo.Customers", "PickupId", "dbo.Pickups", "Id");
        }
    }
}
