app.controller("groceryController", function ($scope, GroceryService, $location) {

    $scope.configuracoesPagina = {
        SortBy: 'Nome',
        Reverse: false
    };

    var self = this;
    
    self.Listar = function () {
        GetProducts();        
    }

    self.Cadastrar = function (rota) {
        $location.path(rota);
    }

    self.Editar = function (id) {

        GroceryService.Editar(id).success(function (data) {
            $scope.produto = data;

            $location.path("/editar");
        });        
    }

    self.PostEditar = function () {     
        var objeto = {
            Id: $scope.produto.Id,
            Nome: $scope.produto.Nome,
            Valor: $scope.produto.Valor
        };

        GroceryService.Salvar(objeto).success(function (data) {
            alert('Produto editado.')
            GetProducts();

        }).error(function (data) {
            alert('Erro inesperado!');
        });
    }

    self.Salvar = function () {
        var objeto = {
            Nome: self.nome,
            Valor: self.valor
        };
        GroceryService.Novo(objeto).success(function (data) {
            alert("Produto incuído!");
            GetProducts();
        }).error(function (data) {
            $scope.error = "Erro ao inserir!" + data;
        });
    }

    self.Remover = function (produto) {
        GroceryService.Remover(produto.Id).success(function (data) {
            alert("Produto excluído com sucesso!");
            GetProducts();            
        }).error(function (data) {
            alert('Erro inesperado!');
        });;
    }

    self.Ordenar = function (coluna) {
        console.log(coluna);
        console.log($scope.configuracoesPagina.sortBy);

        if (coluna == $scope.configuracoesPagina.SortBy) {
            $scope.configuracoesPagina.Reverse = !$scope.configuracoesPagina.Reverse;
        } else {
            $scope.configuracoesPagina.SortBy = coluna;
            $scope.configuracoesPagina.Reverse = false;
        }

        GetProducts();
    }

    function GetProducts() {
        GroceryService.GetProducts($scope.configuracoesPagina).success(function (pl) {
            $scope.produtos = pl
            $location.path("/listar");
        },
        function (errorPl) {
            $scope.error = errorPl;
        });
    }
});