using B.API.DTOs;
using B.Core.Messages;
using FluentValidation;

namespace B.API.Application.Mediator.Commands;

public class DeleteCardCommand : CommandWithResponse<CardDTO[]>
{
    public Guid Id { get; set; }

    public bool IsValid()
    {
        ValidationResult = new DeleteCardValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public static DeleteCardCommand Create(Guid id)
    {
        return new DeleteCardCommand()
        {
            Id = id,
        };
    }

    public class DeleteCardValidation : AbstractValidator<DeleteCardCommand>
    {
        public DeleteCardValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id must be set");
        }
    }
}
