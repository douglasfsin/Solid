using System;
using System.Net.Mail;
using System.Runtime.InteropServices;
using Daycoval.Solid.Domain.Entidades;

namespace Daycoval.Solid.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        private readonly IEstoqueService _estoqueService;
      
        public PedidoService(IEmailService emailService, ISmsService smsService, IEstoqueService estoqueService)
        {
            _emailService = emailService;
            _smsService = smsService;
            _estoqueService = estoqueService;
        }

        public void RealizarPagamento(Carrinho carrinho)
        {
            var pagamento = PagamentoFactory.Pagamento(carrinho);
            pagamento.RealizarPagamento(carrinho);
        }

        public void EfetuarPedido(Carrinho carrinho, bool notificarClienteEmail,
            bool notificarClienteSms)
        {
            RealizarPagamento(carrinho);

            var estoque = new EstoqueService();
            VerificarCarrinhoPago(carrinho, estoque);
            EntregarProdutos(carrinho);

            _estoqueService.BaixarProdutosEstoque(carrinho, estoque);
            _emailService.EnviarEmail(carrinho, notificarClienteEmail);
            _smsService.RegistarSmsFila(carrinho, notificarClienteSms);
        }

        public void VerificarCarrinhoPago(Carrinho carrinho, EstoqueService estoque)
        {
            if (!carrinho.FoiPago)
                throw new ExternalException("O pagamento não foi efetuado.");

            foreach (var produto in carrinho.Produtos)
            {
                estoque.SolicitarProduto(produto);
            }
        }

        public void EntregarProdutos(Carrinho carrinho)
        {
            carrinho.FoiEntregue = true;
        }
    }
}