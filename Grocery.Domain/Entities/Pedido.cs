using System;
using System.Collections.Generic;

namespace Grocery.Domain.Entities
{
    public class Pedido
    {
        public Pedido()
        {
            this.ItensPedido = new List<ItensPedido>();
        }
        
        public long Id { get; private set; }

        public DateTime DataPedido { get; set; }

        public string CPF { get; set; }

        public string CEP { get; set; }

        public string Endereco { get; set; }

        public decimal Total { get; set; }

        public virtual IList<ItensPedido> ItensPedido { get; set; }
    }
}
