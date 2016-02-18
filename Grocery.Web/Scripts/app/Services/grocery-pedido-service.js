app.factory('PedidoService', ['$http', 'GroceryService', function ($http, GroceryService) {
    var PedidoService = {};
    var urlBase = '/api/Pedido';

    PedidoService.ListarProdutos = function (configuracoesListagemProdutos) {
        var produtos = GroceryService.GetProducts(configuracoesListagemProdutos);
        return produtos;
    }    

    PedidoService.SalvarPedido = function (pedidos, Pedido) {
        
        var listaProdutosPedido = new Array();
        for (var i = 0; i < pedidos.length; i++) {
            produtoAtual = pedidos[i].Produto;

            listaProdutosPedido.push({
                Id: produtoAtual.Id,
                NomeProduto: produtoAtual.Nome,
                Quantidade: pedidos[i].Quantidade,
                Valor: produtoAtual.Valor
            });
        }

        var objetoInserir = {
            CPF: Pedido.Cpf,
            CEP: Pedido.Cep,
            Endereco: Pedido.Endereco,
            DataPedido: Pedido.DataPedido,
            ItensPedido: listaProdutosPedido
        };

        return $http.post(urlBase + "/", objetoInserir);
    }

    PedidoService.Listar = function () {
        return $http.get(urlBase);
    }

    return PedidoService;
}]);