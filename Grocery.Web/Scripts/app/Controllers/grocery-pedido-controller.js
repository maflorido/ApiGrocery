app.controller("pedidoController", function ($scope, PedidoService, $location) {

    var self = this;
    this.produtosIncluidos = new Array();
    var urlServicoCep = "http://cep.republicavirtual.com.br/web_cep.php?cep=valorcep&formato=jsonp";


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

    self.BuscarCep = function () {
        var url = urlServicoCep.replace("valorcep", self.cep);

        PedidoService.ConsultarCep(url).success(function (data) {
            self.endereco = data.tipo_logradouro + " " + data.logradouro.split("-")[0].trim() + ", " + data.bairro + ", " + data.cidade + ", " + data.uf;
        })
        .error(function () {
            alert("Ocorreu um erro ao utilizar o serviço de busca de CEP.");
        });
    }

    self.Salvar = function () {        

        PedidoService.SalvarPedido(self.produtosIncluidos, self.cpf, self.cep, self.endereco, self.dataPedido).success(function () {
            alert('Pedido incluído!');
        }).error(function () {
            alert('Erro inesperado.');
        });
    }
});