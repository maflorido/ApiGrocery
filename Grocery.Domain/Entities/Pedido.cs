using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public double Total { get; set; }

        public virtual IList<ItensPedido> ItensPedido { get; set; }
    }
}
