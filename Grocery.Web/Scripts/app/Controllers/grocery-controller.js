﻿app.controller("groceryController", function ($scope, GroceryService, $location) {

    $scope.configuracoesPagina = {
        SortBy: 'Nome',
        Reverse: false
    };    

    var self = this;

    self.GroceryController = function () {
        self.Produto = {};
        self.Produtos = new Array();
    }

    self.GroceryController();

    self.Listar = function () {
        GetProducts();        
    }

    self.Cadastrar = function (rota) {
        $location.path(rota);
        self.GroceryController();
    }

    self.Editar = function (id) {

        GroceryService.Editar(id).success(function (data) {
            self.Produto = data;
            $location.path("/editar");
        });
    }

    self.PostEditar = function () {     

        GroceryService.Salvar(self.Produto).success(function (data) {
            alert('Produto editado.')
            GetProducts();

        }).error(function (data) {
            alert('Erro inesperado!');
        });
    }

    self.Salvar = function () {
        console.log(self.Produto);
        GroceryService.Novo(self.Produto).success(function (data) {
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
            self.Produtos = pl;
            console.log(self.Produtos);
            $location.path("/listar");
        },
        function (errorPl) {
            $scope.error = errorPl;
        });
    }
});