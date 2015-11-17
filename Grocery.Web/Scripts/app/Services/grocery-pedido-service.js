app.factory('PedidoService', ['$http', 'GroceryService', function ($http, GroceryService) {
    var PedidoService = {};

    PedidoService.ListarProdutos = function (configuracoesListagemProdutos) {
        var produtos = GroceryService.GetProducts(configuracoesListagemProdutos);
        return produtos;
    }

    PedidoService.CriarProdutoPedido = function (produto, quantidade) {
        var produto = JSON.parse(produto);

        var produtoPedido = {
            Id: produto.Id,
            Nome: produto.Nome,
            Valor: produto.Valor,
            Quantidade: quantidade
        };

        return produtoPedido;
    }

    PedidoService.ConsultarCep = function (url) {
        return $http.get(url);
    }

    return PedidoService;
}]);