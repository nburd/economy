namespace BudgetWinForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnitOfMeasures", "ShortName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UnitOfMeasures", "ShortName");
        }
    }
}
