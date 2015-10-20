namespace BudgetWinForms
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BudgetModel : DbContext
    {
        public BudgetModel()
            : base("name=BudgetModel")
        {
        }
        
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        public virtual DbSet<Source> Sources { get; set; }

        public virtual DbSet<GoodsItem> Goods{ get; set; }

        public virtual DbSet<Purchase> Purchases { get; set; }

        public virtual DbSet<ChekItem> ChekItems { get; set; }
    }
}