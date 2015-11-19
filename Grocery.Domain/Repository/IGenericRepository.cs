using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Grocery.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IList<T> Listar(params Expression<Func<T, object>> [] includes);

        T Obter(long id);

        List<T> Filtrar(Expression<Func<T, bool>> filtro);

        void Incluir(T objeto);

        void IncluirItens(List<T> objetos);

        void Editar(T objeto);

        void Excluir(T objeto);
    }
}
