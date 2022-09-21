using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Daycoval.Solid.Domain.Entidades
{
    public abstract class Produto  : Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorImposto { get; set; }
        public TipoProduto TipoProduto { get; set; }

        public abstract void CalcularImposto();

        public bool Valido()
        {
            ValidationResult = new ProdutoValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class Eletronico : Produto
    {
        public override void CalcularImposto()
        {
            ValorImposto = Valor * 0.15M;
        }
    }

    public class Superfulos : Produto
    {
        public override void CalcularImposto()
        {
            ValorImposto = Valor * 0.20M;
        }
    }

    public class Alimentos : Produto
    {
        public override void CalcularImposto()
        {
            ValorImposto = Valor * 0.05M;
        }
    }

    public class ProdutoValidacao : AbstractValidator<Produto>
    {
        public ProdutoValidacao()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("O campo Descrição deve ser preenchido.")
                .Length(2, 200).WithMessage("A Descrição deve ter entre 2 e 200 caracteres.");

            RuleFor(p => p.Valor)
                .NotNull()
                .NotEqual(0)
                .WithMessage("O campo Valor deve ser preenchido.");

            RuleFor(p => p.Quantidade)
                .NotNull()
                .NotEqual(0)
                .WithMessage("O campo Quantidade deve ser preenchido.");

            RuleFor(p => p.TipoProduto)
                .NotNull().WithMessage("O campo TipoProduto deve ser preenchido.");

        }
    }

}