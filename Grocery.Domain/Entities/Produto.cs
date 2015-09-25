using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Domain.Entities
{
    public class Produto
    {
        public Produto(long id, string nome, double valor)
        {
            this.Id = id;
            this.Nome = nome;
            this.Valor = valor;
        }

        public long Id { get; private set; }

        public string Nome { get; private set; }

        public double Valor { get; private set; }
    }
}
