using Grocery.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Grocery.Data
{
    public class GroceryContext : DbContext
    {
        public GroceryContext()
            : base("Contexto")
        {
            Database.SetInitializer<GroceryContext>(new GroceryDBInitializer());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto");
            base.OnModelCreating(modelBuilder);
        }        

    }
}
