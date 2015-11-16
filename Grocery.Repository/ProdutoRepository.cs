using Grocery.Data;
using Grocery.Domain.Entities;
using Grocery.Domain.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Grocery.Repository
{
    public class ProdutoRepository: GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(GroceryContext context)
            : base(context)
        {
        }

        public IList<Produto> Listar(string orderBy, bool reverse)
        {
            var query = from a in this.dbContext.Set<Produto>().AsQueryable<Produto>()
                        select a;

            if (orderBy == "Nome" && reverse)
                query = query.OrderByDescending(x => x.Nome);
            else if (orderBy == "Nome" && !reverse)
                query = query.OrderBy(x => x.Nome);
            else if (orderBy == "Valor" && reverse)
                query = query.OrderByDescending(x => x.Valor);
            else
                query = query.OrderBy(x => x.Valor);           

            return query.ToListAsync().Result;
        }
    }
}
