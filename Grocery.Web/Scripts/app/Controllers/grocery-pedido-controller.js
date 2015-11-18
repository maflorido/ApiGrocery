app.controller("pedidoController", function ($scope, PedidoService, $location) {

    var self = this;
    this.produtosIncluidos = new Array();
    var urlServicoCep = "http://cep.republicavirtual.com.br/web_cep.php?cep=valorcep&formato=jsonp";


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
        this.produtosIncluidos = $.grep(this.produtosIncluidos, function (e) {
            return e.Id != produto.Id;
        });
                
    }

    self.BuscarCep = function () {        
        var url = urlServicoCep.replace("valorcep", this.cep);

        PedidoService.ConsultarCep(url).success(function (data) {
            $scope.endereco = data.tipo_logradouro + " " + data.logradouro.split("-")[0].trim() + ", " + data.bairro + ", " + data.cidade + ", " + data.uf;
        })
        .error(function () {
            alert("Ocorreu um erro ao utilizar o serviço de busca de CEP.");
        });
        
   }    
});