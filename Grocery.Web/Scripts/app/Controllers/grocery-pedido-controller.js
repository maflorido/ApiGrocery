app.controller("pedidoController", function ($scope, PedidoService, $location) {

    var self = this;

    self.Novo = function () {
        PedidoService.ListarProdutos($scope.configuracoesPagina).success(function (data) {
            $scope.produtosCombo = data;            
        });

        $location.path('/pedido/novo');
    }

    self.IncluirPedido = function () {
        
    }

});