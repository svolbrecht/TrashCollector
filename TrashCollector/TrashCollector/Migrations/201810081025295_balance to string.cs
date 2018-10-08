namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class balancetostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Balance", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Balance", c => c.Double(nullable: false));
        }
    }
}
