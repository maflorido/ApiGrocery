using Grocery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Grocery.Data
{
    internal class GroceryDBInitializer : DropCreateDatabaseAlways<GroceryContext>
    {
        protected override void Seed(GroceryContext context)
        {
            context.Set<Produto>().AddRange(this.Produtos);
            context.Set<Pedido>().Add(new Pedido()
            {
                CEP = "1",
                CPF = "1",
                Endereco = "end",
                DataPedido = DateTime.Now,
                ItensPedido = new List<ItensPedido>()
                {
                    new ItensPedido()
                    {
                        Produto=this.Produtos[0],
                        Quantidade=5
                    }
                }
            });


            base.Seed(context);
        }

        private IList<Produto> Produtos = new List<Produto>() {
            new Produto(1,"prod 2", 50.5),
            new Produto(2,"prod 1", 105),
            new Produto(3,"prod 3", 5)
        };
    }
}
