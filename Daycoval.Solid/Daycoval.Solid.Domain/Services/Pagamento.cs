using Daycoval.Solid.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Daycoval.Solid.Domain.Services
{
    public interface IPagamento
    {
        void RealizarPagamento(Carrinho carrinho);
        void InformarPagamento(Carrinho carrinho);
    }

    public class PagamentoFactory 
    {
        public static Pagamento Pagamento(Carrinho carrinho)
        {
            switch (carrinho.Pagamento.FormaPagamento)
            {
                case FormaPagamento.CartaoCredito:
                    return new PagamentoCartaoCreditoService(carrinho);
                    break;
                case FormaPagamento.CartaoDebito:
                    return new PagamentoCartaoDeditoService(carrinho);
                    break;
                case FormaPagamento.Dinheiro:
                    return new PagamentoDinheiroService(carrinho);
                    break;
                default:
                    throw new Exception("Meio de pagamento não implementado.");
                    break;
            }
        }

    }

    public class Pagamento : IPagamento
    {
        public void InformarPagamento(Carrinho carrinho)
        {
            carrinho.FoiPago = true;
        }

        public virtual void RealizarPagamento(Carrinho carrinho)
        {
            throw new NotImplementedException();
        }
    }

    public class PagamentoCartaoCreditoService : Pagamento
    {
        public PagamentoCartaoCreditoService(Carrinho carrinho)
        {
            Carrinho = carrinho;
        }

        public Carrinho Carrinho { get; }

        public override void RealizarPagamento(Carrinho carrinho)
        {
            using (var gatewayPatamento = new GatewayPagamentoService("login", "senha", carrinho, carrinho.Pagamento))
            {
                gatewayPatamento.EfetuarPagamento();
            }
            InformarPagamento(carrinho);
        }
    }

    public class PagamentoDinheiroService : Pagamento
    {
        public PagamentoDinheiroService(Carrinho carrinho)
        {
            Carrinho = carrinho;
        }

        public Carrinho Carrinho { get; }

        public override void RealizarPagamento(Carrinho carrinho)
        {
            InformarPagamento(carrinho);
        }
    }

    public class PagamentoCartaoDeditoService : Pagamento
    {
        public PagamentoCartaoDeditoService(Carrinho carrinho)
        {
            Carrinho = carrinho;
        }

        public Carrinho Carrinho { get; }

        public override void RealizarPagamento(Carrinho carrinho)
        {
            using (var gatewayPatamento = new GatewayPagamentoService("login", "senha", carrinho, carrinho.Pagamento))
            {
                gatewayPatamento.EfetuarPagamento();
            }
            InformarPagamento(carrinho);
        }
    }
}
