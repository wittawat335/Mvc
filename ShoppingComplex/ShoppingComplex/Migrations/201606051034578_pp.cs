namespace ShoppingComplex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Activated", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "Activated");
        }
    }
}
