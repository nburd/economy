namespace BudgetWinForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoodsItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category_Id = c.Int(),
                        UnitOfMeasure_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.UnitOfMeasures", t => t.UnitOfMeasure_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.UnitOfMeasure_Id);
            
            CreateTable(
                "dbo.ChekItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Quantity = c.Double(nullable: false),
                        GoodsItem_Id = c.Int(),
                        Purchase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GoodsItems", t => t.GoodsItem_Id)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id)
                .Index(t => t.GoodsItem_Id)
                .Index(t => t.Purchase_Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Source_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sources", t => t.Source_Id)
                .Index(t => t.Source_Id);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnitOfMeasures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoodsItems", "UnitOfMeasure_Id", "dbo.UnitOfMeasures");
            DropForeignKey("dbo.Purchases", "Source_Id", "dbo.Sources");
            DropForeignKey("dbo.ChekItems", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.ChekItems", "GoodsItem_Id", "dbo.GoodsItems");
            DropForeignKey("dbo.GoodsItems", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Purchases", new[] { "Source_Id" });
            DropIndex("dbo.ChekItems", new[] { "Purchase_Id" });
            DropIndex("dbo.ChekItems", new[] { "GoodsItem_Id" });
            DropIndex("dbo.GoodsItems", new[] { "UnitOfMeasure_Id" });
            DropIndex("dbo.GoodsItems", new[] { "Category_Id" });
            DropTable("dbo.UnitOfMeasures");
            DropTable("dbo.Sources");
            DropTable("dbo.Purchases");
            DropTable("dbo.ChekItems");
            DropTable("dbo.GoodsItems");
            DropTable("dbo.Categories");
        }
    }
}
