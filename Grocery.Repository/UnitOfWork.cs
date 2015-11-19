using Grocery.Domain.Entities;
using Grocery.Domain.Repository;
using Grocery.Repository;
using System;

namespace Grocery.Data
{

    public class UnitOfWork : IDisposable
    {
        private GroceryContext context = new GroceryContext();
        private IProdutoRepository produtoRepository;
        private IPedidoRepository pedidoRepository;

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                if (this.produtoRepository == null)
                    this.produtoRepository = new ProdutoRepository(context);

                return this.produtoRepository;
            }
        }

        public IPedidoRepository PedidoRepository
        {
            get
            {
                if (this.pedidoRepository == null)
                    this.pedidoRepository = new PedidoRepository(context);

                return this.pedidoRepository;
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
