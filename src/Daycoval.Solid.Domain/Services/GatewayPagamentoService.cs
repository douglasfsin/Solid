using System;
using System.Runtime.InteropServices;
using Daycoval.Solid.Domain.Entidades;

namespace Daycoval.Solid.Domain.Services
{
    public interface IGatewayPagamentoService
    {
        void EfetuarPagamento();
    }

    public class GatewayPagamentoService :IGatewayPagamentoService, IDisposable
    {
        public GatewayPagamentoService(string login, string senha, Carrinho carrinho, DetalhePagamento detalhePagamento)
        {
            Login = login;
            Senha = senha;
            NomeImpresso = detalhePagamento.NomeImpressoCartao;
            Valor = carrinho.ValorTotalPedido;
            MesExpiracao = detalhePagamento.MesExpiracao;
            AnoExpiracao = detalhePagamento.AnoExpiracao;
            FormaPagamentoCartao = (FormaPagamentoCartao)(FormaPagamento)detalhePagamento.FormaPagamento;
        }

        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string NomeImpresso { get; private set; }
        public decimal Valor { get; private set; }
        public int MesExpiracao { get; private set; }
        public int AnoExpiracao { get; private set; }
        public FormaPagamentoCartao FormaPagamentoCartao { get; set; }

        public void EfetuarPagamento()
        {
            //Não é necessário implementar este método.
        }

        public void Dispose()
        {
            Login = string.Empty;
            Senha = string.Empty;
            NomeImpresso = string.Empty;
            Valor = 0M;
            MesExpiracao = 0;
            AnoExpiracao = 0;
        }
    }
}