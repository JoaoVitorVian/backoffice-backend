using Domain.Entity;
using FluentValidation;

namespace Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O Name não pode ser nulo");

            RuleFor(x => x.Documento)
                .NotNull()
                .WithMessage("O Documento não pode ser nulo");

            RuleFor(x => x.Qualificacoes)
               .NotNull()
               .WithMessage("As Qualificacões não podem ser nulas");

            RuleFor(x => x.Bairro)
               .NotNull()
               .WithMessage("O Bairro não pode ser nulo");

            RuleFor(x => x.Localidade)
               .NotNull()
               .WithMessage("O Localidade não pode ser nulo");

            RuleFor(x => x.TipoDePessoa)
               .NotNull()
               .WithMessage("O TipoDePessoa não pode ser nulo");

            RuleFor(x => x.Cep)
               .NotNull()
               .WithMessage("O Cep não pode ser nulo");
        }
    }
}
