using Grocery.Domain.Entities;
using Grocery.Domain.Repository;
using Grocery.Repository;
using System;

namespace Grocery.Data
{

    public class UnitOfWork : IDisposable
    {
        private GroceryContext context;
        private IProdutoRepository produtoRepository;
        private IPedidoRepository pedidoRepository;

        public UnitOfWork(GroceryContext context, IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            this.context = context;
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return this.produtoRepository;
            }
        }

        public IPedidoRepository PedidoRepository
        {
            get
            {
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
