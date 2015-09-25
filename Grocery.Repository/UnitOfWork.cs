using Grocery.Domain.Entities;
using Grocery.Repository;
using System;

namespace Grocery.Data
{

    public class UnitOfWork:IDisposable
    {
        private GroceryContext context = new GroceryContext();
        private GenericRepository<Produto> produtoRepository;

        public IGenericRepository<Produto> ProdutoRepository
        {
            get
            {
                if (this.produtoRepository == null)
                    this.produtoRepository = new GenericRepository<Produto>(context);

                return this.produtoRepository;
            }
        }
        public void Save()
        {
            this.context.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
