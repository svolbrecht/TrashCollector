namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimestuff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "EndPickUp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "EndPickUp", c => c.String());
        }
    }
}
