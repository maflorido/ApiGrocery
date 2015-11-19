using Grocery.Domain.Entities;
using Grocery.Repository;
using System.Collections.Generic;

namespace Grocery.Domain.Repository
{
    public interface IPedidoRepository : IGenericRepository<Pedido>
    {
        IList<Pedido> Listar();
    }
}
