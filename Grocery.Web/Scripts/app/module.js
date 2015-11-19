var app = angular.module("groceryApp", ["ngRoute"]);

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/listar',
                        {
                            templateUrl: '/paginas/ListaProdutos.html',
                            controller: 'groceryController'                            
                        });

    $routeProvider.when('/cadastro',
                        {
                            templateUrl: '/paginas/Cadastro.html',
                            controller: 'groceryController'
                        });

    $routeProvider.when('/editar',
                        {
                            templateUrl: '/paginas/Editar.html',
                            controller: 'groceryController'
                        });

    $routeProvider.when('/pedido/novo',
                        {
                            templateUrl: '/paginas/pedido/novo.html',
                            controller: 'pedidoController'
                        });

    $routeProvider.when('/pedido/listar',
                        {
                            templateUrl: '/paginas/pedido/listar.html',
                            controller: 'pedidoController'
                        });

    $routeProvider.when('/pedido/listarItens',
                        {
                            templateUrl: '/paginas/pedido/listarItens.html'
                        });


    $locationProvider.html5Mode({
        enbled: true,
        requireBase: false
    }).hashPrefix('!');
}]);