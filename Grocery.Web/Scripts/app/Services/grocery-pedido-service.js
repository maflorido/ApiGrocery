app.factory('PedidoService', ['$http', 'GroceryService', function ($http, GroceryService) {
    var PedidoService = {};
    var urlBase = '/api/Pedido';

    PedidoService.ListarProdutos = function (configuracoesListagemProdutos) {
        var produtos = GroceryService.GetProducts(configuracoesListagemProdutos);
        return produtos;
    }

    PedidoService.CriarProdutoPedido = function (produto, quantidade, cpf, cep, endereco) {
        var produto = JSON.parse(produto);

        var produtoPedido = {
            Id: produto.Id,
            Nome: produto.Nome,
            Valor: produto.Valor,
            Quantidade: quantidade,
            CPF: cpf,
            CEP: cep,
            Endereco: endereco
        };

        return produtoPedido;
    }

    PedidoService.ConsultarCep = function (url) {
        return $http.get(url);
    }

    PedidoService.SalvarPedido = function (pedidos) {

        console.log(pedidos);
        return $http.post(urlBase + "/", pedidos);
    }

    return PedidoService;
}]);