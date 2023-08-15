using DevFreela.Application.Commands.Project.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand> {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo da Descrição é de 255 caracteres.");

            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o Título do Projeto.");

            RuleFor(p => p.Title)
                .MinimumLength(30)
                .WithMessage("Título do Projeto deve conter no mínimo 30 caracteres.");

            RuleFor(p => p.TotalCost)
                .GreaterThan(0)
                .WithMessage("Informe o valor do Projeto.");
        }
    }
}

