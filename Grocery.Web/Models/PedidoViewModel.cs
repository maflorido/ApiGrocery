using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grocery.Web.Models
{
    public class PedidoViewModel
    {
        public long Id { get; set; }

        public long Quantidade { get; set; }

        public long Valor { get; set; }

        public string CPF { get; set; }

        public string CEP { get; set; }

        public string Endereco { get; set; }
    }
}