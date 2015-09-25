using Grocery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery.WebApp.Models
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel(long id, string nome, double valor)
        {
            this.Id = id;
            this.Nome = nome;
            this.Valor = valor;
        }


        public long Id { get; set; }

        public string Nome { get; set; }

        public double Valor { get; set; }

        public static IList<ProdutoViewModel> ListarProdutosViewModel(IList<Produto> produtos)
        {
            return produtos.Select(x => new ProdutoViewModel(x.Id, x.Nome, x.Valor)).ToList();
        }

    }
}