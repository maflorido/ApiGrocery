app.controller("pedidoController", function ($scope, PedidoService, ngDialog, $location) {

    var self = this;
    this.produtosIncluidos = new Array();

    self.ListarPedido = function () {
        PedidoService.Listar().success(function (data) {
            $scope.pedidosCadastrados = data;
        });
        $location.path('/pedido/listar');
    }

    self.Novo = function () {
        PedidoService.ListarProdutos($scope.configuracoesPagina).success(function (data) {
            self.produtosCombo = data;            
        });        

        
        $location.path('/pedido/novo');
    }

    self.IncluirPedido = function () {        
        var produtoPedido = PedidoService.CriarProdutoPedido(self.produto, self.quantidade);
        self.produtosIncluidos.push(produtoPedido);
    }


    self.RemoverProdutoPedido = function (produto) {
        self.produtosIncluidos = $.grep(self.produtosIncluidos, function (e) {
            return e.Id != produto.Id;
        });
                
    }

    self.Salvar = function () {        

        PedidoService.SalvarPedido(self.produtosIncluidos, self.cpf, self.cep, self.endereco, self.dataPedido).success(function () {
            alert('Pedido incluído!');
        }).error(function () {
            alert('Erro inesperado.');
        });
    }

    self.ListarItens = function (pedidos) {
        this.pedidos = pedidos;

        ngDialog.open({
            template: '/paginas/pedido/listarItens.html',            
            scope: $scope
        });
    }
});