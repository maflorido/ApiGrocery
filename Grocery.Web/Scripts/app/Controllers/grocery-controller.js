app.controller("groceryController", function ($scope, GroceryService) {
    var self = this;
    
    self.Listar = function () {
        GetProducts();        
    }

    function GetProducts() {
        GroceryService.GetProducts().success(function (pl) {
            console.log(pl);
            $scope.produtos = pl
        },
        function (errorPl) {
            $scope.error = errorPl;
        });
    }
});