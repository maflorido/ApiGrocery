using Grocery.Data;
using Grocery.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Grocery.WebApp.Controllers
{
    public class GroceryShopController : ApiController
    {
        private UnitOfWork contexto;

        public GroceryShopController(UnitOfWork contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public IList<ProdutoViewModel> GetAll()
        {
            var produtos = contexto.ProdutoRepository.Listar();

            return ProdutoViewModel.ListarProdutosViewModel(produtos);
        }

    }
}
