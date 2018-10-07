namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "SpecialPickUp", c => c.String());
            AlterColumn("dbo.Customers", "EndPickUp", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "EndPickUp", c => c.DateTime());
            AlterColumn("dbo.Customers", "SpecialPickUp", c => c.DateTime());
        }
    }
}
