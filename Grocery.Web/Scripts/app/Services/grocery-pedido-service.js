app.factory('PedidoService', ['$http', 'GroceryService', function ($http, GroceryService) {
    var PedidoService = {};
    var urlBase = '/api/Pedido';

    PedidoService.ListarProdutos = function (configuracoesListagemProdutos) {
        var produtos = GroceryService.GetProducts(configuracoesListagemProdutos);
        return produtos;
    }    

    PedidoService.SalvarPedido = function (pedidos, cpf, cep, endereco, dataPedido) {        

        var objetoInserir = {
            CPF: cpf,
            CEP: cep,
            Endereco: endereco,
            DataPedido: dataPedido,
            ItensPedido: pedidos
        };

        console.log(objetoInserir);

        return $http.post(urlBase + "/", objetoInserir);
    }

    PedidoService.Listar = function () {
        return $http.get(urlBase);
    }

    return PedidoService;
}]);