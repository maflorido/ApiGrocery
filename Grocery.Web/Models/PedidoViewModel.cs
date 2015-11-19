using Grocery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery.Web.Models
{
    public class PedidoViewModel
    {

        public PedidoViewModel()
        {
            this.ItensPedido = new List<ItemPedidoViewModel>();
        }

        public PedidoViewModel(string cpf, string cep, string endereco, DateTime dataPedido, IList<ItensPedido> itens)
        {
            this.CPF = cpf;
            this.CEP = cep;
            this.Endereco = endereco;
            this.DataPedido = dataPedido.ToString("dd/MM/yyyy");
            this.ItensPedido = itens.Select(x => new ItemPedidoViewModel(x)).ToList();

        }

        public IList<ItemPedidoViewModel> ItensPedido { get; set; }

        public string CPF { get; set; }

        public string CEP { get; set; }

        public string Endereco { get; set; }   
        
        public string DataPedido { get; set; }

        public static IList<PedidoViewModel> ListarPedidosViewModel(IList<Pedido> pedidos)
        {
            return pedidos.Select(x => new PedidoViewModel(x.CPF, x.CEP, x.Endereco, x.DataPedido, x.ItensPedido)).ToList();
        }
        
    }
}