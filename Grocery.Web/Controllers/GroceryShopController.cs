using Grocery.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Grocery.WebApp.Controllers
{
    public class GroceryShopController : ApiController
    {

        private IList<Produto> Produtos = new List<Produto>() {
            new Produto(1,"prod 2", 50.5),
            new Produto(2,"prod 1", 105),
            new Produto(3,"prod 3", 5)
        };

        [HttpGet]
        public IList<Produto> GetAll()
        {
            return Produtos;
        }

    }
}
