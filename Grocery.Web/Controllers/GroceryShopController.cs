using Grocery.Data;
using Grocery.WebApp.Models;
using System.Collections.Generic;
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
