app.controller("pedidoController", function ($scope, PedidoService, $location) {

    var self = this;
    this.produtosIncluidos = new Array();
    var urlServicoCep = "http://cep.republicavirtual.com.br/web_cep.php?cep=valorcep&formato=jsonp"

    self.Novo = function () {
        PedidoService.ListarProdutos($scope.configuracoesPagina).success(function (data) {
            $scope.produtosCombo = data;            
        });

        $location.path('/pedido/novo');
    }

    self.IncluirPedido = function () {        
        var produtoPedido = PedidoService.CriarProdutoPedido(self.produto, self.quantidade);
        this.produtosIncluidos.push(produtoPedido);
    }


    self.RemoverProdutoPedido = function (produto) {
        console.log(produto);

        this.produtosIncluidos = $.grep(this.produtosIncluidos, function (e) {
            return e.Id != produto.Id;
        });
                
    }

    self.BuscarCep = function () {        
        var url = urlServicoCep.replace("valorcep", this.cep);

        PedidoService.ConsultarCep(url).success(function (data) {
            console.log(data);
        });
        
   }    
});