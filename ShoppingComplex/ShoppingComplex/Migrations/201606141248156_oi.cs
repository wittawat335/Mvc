namespace ShoppingComplex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Image", c => c.String(nullable: false));
        }
    }
}
