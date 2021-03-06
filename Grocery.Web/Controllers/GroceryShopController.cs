﻿using Grocery.Data;
using Grocery.Domain.Entities;
using Grocery.WebApp.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace Grocery.WebApp.Controllers
{
    public class GroceryShopController : ApiController
    {
        private UnitOfWork contexto;

        public GroceryShopController(UnitOfWork contexto)
        {
            this.contexto = contexto;
        }

        [System.Web.Http.HttpGet]
        public IList<ProdutoViewModel> GetAll(string SortBy, bool Reverse)
        {
            var produtos = contexto.ProdutoRepository.Listar(SortBy, Reverse);
            
            return ProdutoViewModel.ListarProdutosViewModel(produtos);
        }

        [System.Web.Http.HttpGet]
        public ProdutoViewModel Get(int id)
        {
            var produto = this.contexto.ProdutoRepository.Obter(id);

            ProdutoViewModel produtoViewModel = new ProdutoViewModel(produto.Id, produto.Nome, produto.Valor);

            return produtoViewModel;
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
        public IHttpActionResult Delete(int id)
        {
            Produto produto = this.contexto.ProdutoRepository.Obter(id);

            this.contexto.ProdutoRepository.Excluir(produto);
            this.contexto.Save();

            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult Put(ProdutoViewModel produtoViewModel)
        {

            Produto produtoAtual = this.contexto.ProdutoRepository.Obter(produtoViewModel.Id);

            produtoAtual.Nome = produtoViewModel.Nome;
            produtoAtual.Valor = produtoViewModel.Valor;

            this.contexto.ProdutoRepository.Editar(produtoAtual);
            this.contexto.Save();

            return Ok();
        }

    }
}
