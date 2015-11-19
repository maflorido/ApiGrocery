using Grocery.Data;
using Grocery.Domain.Entities;
using Grocery.Web.Models;
using System.Linq;
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
        public IHttpActionResult Post(PedidoViewModel pedidosViewModel)
        {
            Pedido pedido = new Pedido()
            {
                CEP = pedidosViewModel.CEP,
                CPF = pedidosViewModel.CPF,
                DataPedido = pedidosViewModel.DataPedido,
                Endereco = pedidosViewModel.Endereco,
                ItensPedido = pedidosViewModel.ItensPedido.Select(x => new ItensPedido()
                {
                    ProdutoId = x.Id,
                    ValorItem = x.Valor,
                    Quantidade = x.Quantidade
                }).ToList()
            };

            pedido.Total = pedido.ItensPedido.Sum(x => x.Total);

            this.contexto.PedidoRepository.Incluir(pedido);
            this.contexto.Save();
            return Ok();
        }
    }
}
