using B.API.DTOs;
using B.Core.Messages;
using FluentValidation;

namespace B.API.Application.Mediator.Commands;

public class GenerateTokenCommand : CommandWithResponse<string>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public bool IsValid()
    {
        ValidationResult = new GenerateTokenValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public static GenerateTokenCommand CreateFromDTO(LoginDTO dto)
    {
        return new GenerateTokenCommand()
        {
            Password = dto.Login,
            Username = dto.Senha,
        };
    }

    public class GenerateTokenValidation : AbstractValidator<GenerateTokenCommand>
    {
        public GenerateTokenValidation()
        {
            RuleFor(c => c.Password)
                .NotEmpty()
                .WithMessage("Senha must be set");

            RuleFor(c => c.Username)
                .NotEmpty()
                .WithMessage("Login must be set");
        }
    }
}
