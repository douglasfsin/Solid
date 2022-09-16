using FluentValidation;
using FluentValidation.Results;
using System;

namespace Daycoval.Solid.Domain.Entidades
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorImposto { get; set; }
        public TipoProduto TipoProduto { get; set; }


        public void CalcularImposto()
        {
            switch (TipoProduto)
            {
                case TipoProduto.Eletronico:
                    ValorImposto = Valor * 0.15M;
                    break;
                case TipoProduto.Alimentos:
                    ValorImposto = Valor * 0.05M;
                    break;
                case TipoProduto.Superfulos:
                    ValorImposto = Valor * 0.20M;
                    break;
                default:
                    throw new ArgumentException("O tipo de produto informado não está disponível.");
            }
        }

        public bool Valido()
        {
            ValidationResult = new ProdutoValidacao().Validate(this);
            return ValidationResult.IsValid;
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