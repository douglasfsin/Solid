using Daycoval.Solid.Domain.Entidades;
using Daycoval.Solid.Domain.Services;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Xunit;

namespace Daycoval.Solid.Test
{
    public class PedidoServiceTests
    {
        [Fact]
        public void PedidoService_VerificarCarrinhoPago_CarrinhoPago()
        {
            // Arrange
            var cliente = new Cliente();
            var produtos = new List<Produto>();
            var emailService = new EmailService();
            var smsService = new SmsService("34991086213", "Pagamento aprovado");
            var estoqueService = new EstoqueService();
            var pedidoService = new PedidoService(emailService, smsService, estoqueService);
            var pagamento = new DetalhePagamento();
            var carrinho = new Carrinho(produtos, cliente, pagamento);
            carrinho.FoiPago = true;

            // Act
            pedidoService.VerificarCarrinhoPago(carrinho, estoqueService);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void PedidoService_VerificarCarrinhoPago_FalhaPagamentoCarrinho()
        {
            // Arrange
            var cliente = new Cliente();
            var produtos = new List<Produto>();
            var emailService = new EmailService();
            var smsService = new SmsService("34991086213", "Falha no Pagamento");
            var estoqueService = new EstoqueService();
            var pedidoService = new PedidoService(emailService, smsService, estoqueService);
            var pagamento = new DetalhePagamento();
            var carrinho = new Carrinho(produtos, cliente, pagamento);

            carrinho.FoiPago = false;

            // Act
            var exception = Assert.Throws<ExternalException>(() => pedidoService.VerificarCarrinhoPago(carrinho, estoqueService));

            // Assert
            Assert.Equal("O pagamento não foi efetuado.", exception.Message);
        }
    }
}
