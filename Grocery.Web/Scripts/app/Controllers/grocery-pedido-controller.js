app.controller("pedidoController", function ($scope, PedidoService, $location) {

    var self = this;

    self.Novo = function () {
        PedidoService.ListarProdutos($scope.configuracoesPagina).success(function (data) {
            $scope.produtosCombo = data;            
        });

        $location.path('/pedido/novo');
    }

    self.IncluirPedido = function () {
        
        var produto = JSON.parse(self.produto);

        var produtoPedido = {
            Id: produto.Id,
            Nome: produto.Nome,
            Valor: produto.Valor,
            Quantidade: self.quantidade
        };

        $scope.produtosIncluidos = new Array();
        $scope.produtosIncluidos.push(produtoPedido);

    }

});