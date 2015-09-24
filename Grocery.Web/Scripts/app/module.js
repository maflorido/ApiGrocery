var app = angular.module("groceryApp", ["ngRoute"]);

app.factory("ShareData", function () {
    value: 0
});

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/',
                        {
                            templateUrl: 'ListaProdutos.html',
                            controller: 'groceryController'
                        });

    $locationProvider.html5Mode({
        enbled: true,
        requireBase: false
    }).hashPrefix('!');
}]);