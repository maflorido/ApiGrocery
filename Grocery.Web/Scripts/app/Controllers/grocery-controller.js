app.controller("groceryController", function ($scope, GroceryService, $location) {
    var self = this;
    
    self.Listar = function () {
        $location.path("/");
        GetProducts();        
    }

    self.Cadastrar = function (rota) {
        $location.path(rota);
    }

    self.Salvar = function () {
        var objeto = {
            Nome: self.nome,
            Valor: self.valor
        };
        GroceryService.Novo(objeto).success(function (data) {
            alert("Produto incuído!");
            $location.path("/");
        }).error(function (data) {
            $scope.error = "Erro ao inserir!" + data;
        });
    }

    self.Remover = function (produto) {
        GroceryService.Remover(produto.Id).success(function (data) {
            alert("Produto excluído com sucesso!");
        });
    }

    function GetProducts() {
        GroceryService.GetProducts().success(function (pl) {
            $scope.produtos = pl
        },
        function (errorPl) {
            $scope.error = errorPl;
        });
    }
});