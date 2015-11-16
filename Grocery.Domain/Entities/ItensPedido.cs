using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery.Domain.Entities
{
    public class ItensPedido
    {
        [Key]
        [Column(Order = 1)]
        public long PedidoId { get; set; }

        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }

        [Key]
        [Column(Order = 2)]
        public long ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        public long Quantidade { get; set; }

        public double ValorItem
        {
            get { return this.Produto.Valor; }            
        }

        public double Total
        {
            get { return this.ValorItem * this.Quantidade; }
        }
    }
}
