app.factory('PedidoService', ['$http', 'GroceryService', function ($http, GroceryService) {
    var PedidoService = {};

    PedidoService.ListarProdutos = function (configuracoesListagemProdutos) {
        var produtos = GroceryService.GetProducts(configuracoesListagemProdutos);
        return produtos;
    }

    return PedidoService;
}]);