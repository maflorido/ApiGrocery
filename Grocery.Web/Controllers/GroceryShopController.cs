using Grocery.Data;
using Grocery.Domain.Entities;
using Grocery.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Grocery.WebApp.Controllers
{
    public class GroceryShopController : ApiController
    {
        private UnitOfWork contexto;

        public GroceryShopController()
        {
            this.contexto = DependencyResolver.Current.GetService<UnitOfWork>();
        }

        [System.Web.Http.HttpGet]
        public IList<ProdutoViewModel> GetAll()
        {
            var produtos = contexto.ProdutoRepository.Listar();

            return ProdutoViewModel.ListarProdutosViewModel(produtos);
        }

        [System.Web.Http.HttpPost]
        public ProdutoViewModel Post(ProdutoViewModel produtoViewModel)
        {
            if(ModelState.IsValid)
            {
                this.contexto.ProdutoRepository.Incluir(produtoViewModel.ToEntityProduto());
                this.contexto.Save();

                return produtoViewModel;
            }

            return null;

        }
        
        [System.Web.Http.HttpDelete]
        public void Delete(int id)
        {
            Produto produto = this.contexto.ProdutoRepository.Obter(id);

            this.contexto.ProdutoRepository.Excluir(produto);
            this.contexto.Save();

        }

    }
}
