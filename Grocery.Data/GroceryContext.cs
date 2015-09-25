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
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            this.Set<Produto>().AddRange(Produtos);
            this.SaveChanges();

            base.OnModelCreating(modelBuilder);
        }

        private IList<Produto> Produtos = new List<Produto>() {
            new Produto(1,"prod 2", 50.5),
            new Produto(2,"prod 1", 105),
            new Produto(3,"prod 3", 5)
        };


    }
}
