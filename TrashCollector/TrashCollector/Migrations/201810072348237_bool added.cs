namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booladded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsTrashPickedUp", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsTrashPickedUp");
        }
    }
}
