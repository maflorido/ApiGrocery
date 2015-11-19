using Grocery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery.Web.Models
{
    public class ItemPedidoViewModel
    {
        public ItemPedidoViewModel()
        {

        }

        public ItemPedidoViewModel(ItensPedido itemPedido)
        {
            this.Id = itemPedido.ProdutoId;
            this.Quantidade = itemPedido.Quantidade;
            this.Valor = itemPedido.ValorItem;
        }

        public long Id { get; set; }

        public long Quantidade { get; set; }

        public decimal Valor { get; set; }

    }
}