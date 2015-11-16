using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Domain.Entities
{
    public class ItensPedido
    {
        public Produto Produto { get; set; }

        public long Quantidade { get; set; }

        public double ValorItem
        {
            get { return ValorItem; }
            set { value = this.Produto.Valor; }
        }

        public double Total
        {
            get{ return Total; }
            set { value = this.ValorItem * this.Quantidade; }
        }
    }
}
