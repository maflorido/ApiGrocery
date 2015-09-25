var app = angular.module("groceryApp", ["ngRoute"]);

app.factory("ShareData", function () {
    value: 0
});

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/',
                        {
                            templateUrl: '/paginas/ListaProdutos.html',
                            controller: 'groceryController'
                        });

    $routeProvider.when('/cadastro',
                        {
                            templateUrl: '/paginas/Cadastro.html',
                            controller: 'groceryController'
                        });

    $locationProvider.html5Mode({
        enbled: true,
        requireBase: false
    }).hashPrefix('!');
}]);