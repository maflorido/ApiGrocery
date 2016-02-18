app.controller("pedidoController", function ($scope, PedidoService, ngDialog, $location) {

    var self = this;

    self.PedidoController = function () {
        self.produtosIncluidos = new Array();
        self.Pedido = {};

    }
    
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

        self.PedidoController();
        $location.path('/pedido/novo');
    }

    self.IncluirPedido = function () {        
        var produto = JSON.parse(self.Pedido.Produto);
        self.Pedido.Produto = produto;
        self.produtosIncluidos.push(self.Pedido);
    }


    self.RemoverProdutoPedido = function (produto) {
        self.produtosIncluidos = $.grep(self.produtosIncluidos, function (e) {
            return e.Id != produto.Id;
        });
                
    }

    self.Salvar = function () {        

        PedidoService.SalvarPedido(self.produtosIncluidos, self.Produto.cpf, self.Produto.cep, self.Produto.endereco, self.Produto.dataPedido).success(function () {
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