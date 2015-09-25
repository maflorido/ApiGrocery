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

        [HttpGet]
        public IList<Produto> GetAll()
        {
            return Produtos;
        }

    }
}
