using Grocery.Data;
using Grocery.Domain.Entities;
using Grocery.Domain.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Grocery.Repository
{
    public sealed class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(GroceryContext context)
            : base(context)
        {

        }

        public IList<Pedido> Listar()
        {

            var query = from a in this.dbContext.Set<Pedido>().Include(x => x.ItensPedido.Select(y => y.Produto))
                        select a;

            return query.ToListAsync<Pedido>().Result;
        }
    }
}
