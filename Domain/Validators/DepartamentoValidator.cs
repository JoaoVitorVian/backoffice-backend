using Domain.Entity;
using FluentValidation;

namespace Validators
{
    public class DepartamentoValidator : AbstractValidator<Departamento>
    {
        public DepartamentoValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia");

            RuleFor(x => x.NomeDepartamento)
                .NotNull()
                .WithMessage("O NomeDepartamento não pode ser nulo");

            RuleFor(x => x.NomeResponsavel)
                .NotNull()
                .WithMessage("O NomeDepartamento não pode ser nulo");
        }
    }
}
