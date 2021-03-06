﻿using Grocery.Domain.Entities;
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
            modelBuilder.Entity<Pedido>().ToTable("Pedido");
            modelBuilder.Entity<ItensPedido>().ToTable("ItemPedido");
            

            base.OnModelCreating(modelBuilder);
        }        

    }
}
