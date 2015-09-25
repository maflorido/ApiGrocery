app.factory('GroceryService', ['$http', function ($http) {
    var urlBase = '/api/GroceryShop';
    var GroceryService = {};

    GroceryService.GetProducts = function () {
        return $http.get(urlBase);
    };

    GroceryService.Novo = function () {
        return $http.post(urlBase + "/", this.objeto);
    };

    return GroceryService;
}]);