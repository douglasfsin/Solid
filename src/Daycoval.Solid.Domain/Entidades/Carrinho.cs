using FluentValidation;
using System;
using System.Collections.Generic;

namespace Daycoval.Solid.Domain.Entidades
{
    public class Carrinho : Entity
    {
        public decimal ValorTotalPedido { get; set; }
        public List<Produto> Produtos { get; private set; }
        public Cliente Cliente { get; private set; }
        public bool FoiPago { get; set; }
        public bool FoiEntregue { get; set; }
        public DetalhePagamento Pagamento { get; private set; }

        public Carrinho(List<Produto> _produtos, Cliente _cliente, DetalhePagamento _pagamento)
        {
            Produtos = _produtos;
            Cliente = _cliente;
            Pagamento = _pagamento;
        }

        public bool Valido()
        {
            ValidationResult = new CarrinhoValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CarrinhoValidacao : AbstractValidator<Carrinho>
    {
        public CarrinhoValidacao()
        {
            RuleFor(c => c.Produtos)
                .NotNull()
                .WithMessage("Sem produtos no Carrinho");

            RuleFor(c => c.Cliente)
                .NotNull()
                .WithMessage("Cliente não informado");

            RuleFor(c => c.Pagamento)
                .NotNull()
                .WithMessage("Detalhes do pagamento não informados");
        }
    }
}