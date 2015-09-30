using Grocery.Domain.Entities;
using Grocery.Repository;
using System.Collections.Generic;

namespace Grocery.Domain.Repository
{
    public interface IProdutoRepository : IGenericRepository<Produto>
    {
        IList<Produto> Listar(string orderBy, bool reverse);
    }
}
