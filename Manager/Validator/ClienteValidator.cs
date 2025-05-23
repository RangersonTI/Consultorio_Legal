using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Core.Domain;
using FluentValidation;

namespace Manager.Validator;

public class ClienteValidator : AbstractValidator<Cliente>
{
    public ClienteValidator()
    {
        RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
        RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
        RuleFor(x => x.Telefone).NotNull().NotEmpty().Matches("[2-9][0-9]{9}").WithMessage("O telefone tem que ser do formato [2-9]{2}[0-9]{10}");
        RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
        RuleFor(x => x.Sexo).NotNull().NotEmpty().Must(IsMOrF).WithMessage("O sexo deve ser 'M' ou 'F'");

    }
    private bool IsMOrF(char sexo)
    {
        return sexo == 'M' || sexo == 'F';
    }
}
