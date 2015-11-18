using Grocery.Data;
using Grocery.Web.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace Grocery.Web.Controllers
{
    public class PedidoController : ApiController
    {
        private UnitOfWork contexto;

        public PedidoController()
        {
            this.contexto = DependencyResolver.Current.GetService<UnitOfWork>();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Post(IList<PedidoViewModel> pedidosIncluir)
        {            


            //this.contexto.ProdutoRepository.Incluir(produtoAtual);
            //this.contexto.Save();
            return Ok();
        }
    }
}
