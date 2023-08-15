using System.Text.RegularExpressions;
using DevFreela.Application.Commands.User.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Email)
            .EmailAddress()
            .WithMessage("O e-mail não é válido");

        RuleFor(p => p.Password)
            .Must(ValidPassword)
            .WithMessage("A senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula e um caractere especial");

        RuleFor(p => p.FullName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Informe o nome");
    }

    private bool ValidPassword(string password) {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}

