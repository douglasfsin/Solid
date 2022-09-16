using FluentValidation;

namespace Daycoval.Solid.Domain.Entidades
{
    public class Cliente : Entity
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public bool Valido()
        {
            ValidationResult = new ClienteValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ClienteValidacao : AbstractValidator<Cliente>
    {
        public ClienteValidacao()
        {
            RuleFor(c => c.Cpf)
                .NotEmpty()
                .WithMessage("O Campo CPF deve ser preenchido");

            RuleFor(c => c.Nome)
                .NotEmpty()
            .WithMessage("O Campo Nome deve ser preenchido");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O Campo Email deve ser preenchido")
                .EmailAddress();

            RuleFor(c => c.Celular)
                .NotEmpty()
                .WithMessage("O Campo Celular deve ser preenchido");
        }
    }
}