using Grocery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery.Web.Models
{
    public class PedidoViewModel
    {

        public PedidoViewModel()
        {
            this.ItensPedido = new List<ItemPedidoViewModel>();
        }

        public IList<ItemPedidoViewModel> ItensPedido { get; set; }

        public string CPF { get; set; }

        public string CEP { get; set; }

        public string Endereco { get; set; }   
        
        public string DataPedido { get; set; }
    }
}