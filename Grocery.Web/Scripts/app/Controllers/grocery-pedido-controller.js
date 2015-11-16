app.controller("pedidoController", function ($scope, GroceryService, $location) {

    var self = this;

    self.Novo = function () {
        $location.path('/pedido/novo');
    }
});