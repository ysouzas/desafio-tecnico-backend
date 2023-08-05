using B.API.DTOs;
using B.Core.Messages;
using FluentValidation;

namespace B.API.Application.Mediator.Commands;

public class UpdateCardCommand : CommandWithResponse<CardDTO>
{
    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
    public string Lista { get; set; } = string.Empty;

    public Guid Id { get; set; }
    public Guid IdUrl { get; set; }

    public bool IsValid()
    {
        ValidationResult = new UpdateCardValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public static UpdateCardCommand CreateFromDTO(UpdateCardDTO dto, Guid idUrl)
    {
        return new UpdateCardCommand()
        {
            Titulo = dto.Titulo,
            Conteudo = dto.Conteudo,
            Lista = dto.Lista,
            Id = dto.id,
            IdUrl = idUrl,
        };
    }

    public class UpdateCardValidation : AbstractValidator<UpdateCardCommand>
    {
        public UpdateCardValidation()
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

            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id must be set");

            RuleFor(c => c.Id)
                .Equal(c => c.IdUrl)
                .WithMessage("Id and Id From url must be the same");
        }
    }
}
