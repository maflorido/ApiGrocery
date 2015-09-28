app.factory('GroceryService', ['$http', function ($http) {
    var urlBase = '/api/GroceryShop';
    var GroceryService = {};

    GroceryService.GetProducts = function () {
        return $http.get(urlBase);
    };

    GroceryService.Novo = function (objeto) {

        console.log(objeto);
        return $http.post(urlBase + "/", objeto);
    };

    return GroceryService;
}]);