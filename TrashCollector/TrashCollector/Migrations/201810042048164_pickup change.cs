namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pickupchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "WeeklyPickUp", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "WeeklyPickUp", c => c.DateTime());
        }
    }
}
