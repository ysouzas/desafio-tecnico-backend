using B.API.DTOs;
using B.Core.Messages;
using FluentValidation;

namespace B.API.Application.Mediator.Commands;

public class AddCardCommand : Command
{
    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
    public string Lista { get; set; } = string.Empty;

    public override bool IsValid()
    {
        ValidationResult = new AddCardValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public static AddCardCommand CreateFromDTO(AddCardDTO dto)
    {
        return new AddCardCommand()
        {
            Titulo = dto.Titulo,
            Conteudo = dto.Conteudo,
            Lista = dto.Lista,

        };
    }

    public class AddCardValidation : AbstractValidator<AddCardCommand>
    {
        public AddCardValidation()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty()
                .WithMessage("Titulo must be set");

            RuleFor(c => c.Conteudo)
                .NotEmpty()
                .WithMessage("Conteudo must be set");

            RuleFor(c => c.Lista)
                .NotEmpty()
                .WithMessage("Lista must be set");
        }
    }
}

