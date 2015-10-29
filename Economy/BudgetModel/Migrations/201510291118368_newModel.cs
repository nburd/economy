namespace BudgetModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.GoodsItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        UnitOfMeasure_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UnitOfMeasures", t => t.UnitOfMeasure_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.UnitOfMeasure_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.ChekItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Quantity = c.Double(nullable: false),
                        Purchase_Id = c.Int(nullable: false),
                        GoodsItem_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id, cascadeDelete: true)
                .ForeignKey("dbo.GoodsItems", t => t.GoodsItem_Id, cascadeDelete: true)
                .Index(t => t.Purchase_Id)
                .Index(t => t.GoodsItem_Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Source_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sources", t => t.Source_Id, cascadeDelete: true)
                .Index(t => t.Source_Id);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.UnitOfMeasures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoodsItems", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.GoodsItems", "UnitOfMeasure_Id", "dbo.UnitOfMeasures");
            DropForeignKey("dbo.ChekItems", "GoodsItem_Id", "dbo.GoodsItems");
            DropForeignKey("dbo.Purchases", "Source_Id", "dbo.Sources");
            DropForeignKey("dbo.ChekItems", "Purchase_Id", "dbo.Purchases");
            DropIndex("dbo.UnitOfMeasures", new[] { "Name" });
            DropIndex("dbo.Sources", new[] { "Name" });
            DropIndex("dbo.Purchases", new[] { "Source_Id" });
            DropIndex("dbo.ChekItems", new[] { "GoodsItem_Id" });
            DropIndex("dbo.ChekItems", new[] { "Purchase_Id" });
            DropIndex("dbo.GoodsItems", new[] { "Category_Id" });
            DropIndex("dbo.GoodsItems", new[] { "UnitOfMeasure_Id" });
            DropIndex("dbo.GoodsItems", new[] { "Name" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropTable("dbo.UnitOfMeasures");
            DropTable("dbo.Sources");
            DropTable("dbo.Purchases");
            DropTable("dbo.ChekItems");
            DropTable("dbo.GoodsItems");
            DropTable("dbo.Categories");
        }
    }
}
