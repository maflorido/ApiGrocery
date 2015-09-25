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

        GroceryService.Novo().success(function (data) {
            alert("Produto incuído!");            
            $scope.produtos.push(data);            
        }).error(function (data) {
            $scope.error = "Erro ao inserir!" + data;
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