namespace SoapStockApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 30),
                        CustomerEmail = c.String(nullable: false, maxLength: 50),
                        CustomerAddr = c.String(nullable: false, maxLength: 100),
                        CustomerPhone = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 30),
                        ProductSupplierName = c.String(nullable: false, maxLength: 30),
                        ProductDescr = c.String(),
                        ProductType = c.Int(nullable: false),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
        }
    }
}
