namespace BudgetModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheksUnique2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ChekItems", "Price", unique: true, name: "IX_PriceAndGoods");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ChekItems", "IX_PriceAndGoods");
        }
    }
}
