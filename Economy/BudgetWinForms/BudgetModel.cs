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

        #region Fluent API

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Category>()
                .HasMany(x => x.GoodsItems)
                .WithRequired(x => x.Category)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<UnitOfMeasure>()
                .HasMany(x => x.GoodsItems)
                .WithRequired(x => x.UnitOfMeasure)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Source>()
                .HasMany(x => x.Purchases)
                .WithRequired(x => x.Source)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<GoodsItem>()
               .HasMany(x => x.ChekItems)
               .WithRequired(x => x.GoodsItem)
               .WillCascadeOnDelete(true);
            modelBuilder.Entity<Purchase>()
                .HasMany(x => x.ChekItems)
                .WithRequired(x => x.Purchase)
                .WillCascadeOnDelete(true);

        }

        #endregion
    }
}