using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery.WebApp.Models
{
    public class Produto
    {
        public Produto(int id, string nome, double valor)
        {
            this.Id = id;
            this.Nome = nome;
            this.Valor = valor;
        }


        public int Id { get; set; }

        public string Nome { get; set; }

        public double Valor { get; set; }
    }
}