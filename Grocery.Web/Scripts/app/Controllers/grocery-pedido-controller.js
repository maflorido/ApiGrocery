app.controller("pedidoController", function ($scope, PedidoService, $location) {

    var self = this;

    self.Novo = function () {
        PedidoService.ListarProdutos($scope.configuracoesPagina).success(function (data) {
            console.log(data);
        });

        $location.path('/pedido/novo');
    }
});