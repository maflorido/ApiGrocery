app.factory('GroceryService', ['$http', function ($http) {
    var urlBase = '/api/GroceryShop';
    var GroceryService = {};

    GroceryService.GetProducts = function () {
        return $http.get(urlBase);
    };

    GroceryService.Novo = function (objeto) {
        return $http.post(urlBase + "/", objeto);
    };

    GroceryService.Remover = function (id) {
        return $http.delete(urlBase + "/" + id);
    };

    GroceryService.Editar = function (id) {
        return $http.get(urlBase + "/" + id);
    };

    GroceryService.Salvar = function (objeto) {
        return $http.put(urlBase + "/", objeto);
    }

    return GroceryService;
}]);