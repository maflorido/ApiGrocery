using Grocery.Data;
using Grocery.WebApp.Models;
using System.Collections.Generic;
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

    }
}
