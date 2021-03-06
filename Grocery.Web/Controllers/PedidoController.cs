﻿using Grocery.Data;
using Grocery.Domain.Entities;
using Grocery.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace Grocery.Web.Controllers
{
    public class PedidoController : ApiController
    {
        private UnitOfWork contexto;

        public PedidoController(UnitOfWork contexto)
        {
            this.contexto = contexto;
        }

        [System.Web.Http.HttpGet]
        public IList<PedidoViewModel> GetAll()
        {
            var pedidos = contexto.PedidoRepository.Listar();            

            var viewModel = PedidoViewModel.ListarPedidosViewModel(pedidos);

            return viewModel;
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Post(PedidoViewModel pedidosViewModel)
        {
            Pedido pedido = new Pedido()
            {
                CEP = pedidosViewModel.CEP,
                CPF = pedidosViewModel.CPF,
                DataPedido = DateTime.ParseExact(pedidosViewModel.DataPedido, "dd/MM/yyyy", CultureInfo.InvariantCulture),
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
