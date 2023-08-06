using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using B.API.Application.Mediator.Commands;
using B.API.Infrastructure.Settings;
using B.Core.Messages;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace B.API.Application.Mediator.Handlers;

public class SecurityCommandHandler : CommandHandler, IRequestHandler<GenerateTokenCommand, CommandResponse<string>>
{
    private readonly JwtSettings _jwtSettings;
    private readonly AdminSettings _adminSettings;

    public SecurityCommandHandler(IOptions<JwtSettings> jwtSettingsOptions, IOptions<AdminSettings> adminSettingsOptions)
    {
        _jwtSettings = jwtSettingsOptions.Value;
        _adminSettings = adminSettingsOptions.Value;
    }

    public Task<CommandResponse<string>> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {

        if (request.Password != _adminSettings.Senha || request.Username != _adminSettings.Login)
        {
            var validation = new ValidationResult();

            validation.Errors.Add(new FluentValidation.Results.ValidationFailure("Senha", "Senha doenst match"));
            validation.Errors.Add(new FluentValidation.Results.ValidationFailure("Login", "Login doenst match"));

            return Task.FromResult(CommandResponse<string>.Create(default, validation));

        }

        var token = GenerateJwtToken(request.Username);


        return Task.FromResult(CommandResponse<string>.Create(token));
    }

    private string GenerateJwtToken(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            }),
            Audience = _jwtSettings.Audience,
            Issuer = _jwtSettings.Issuer,
            Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_jwtSettings.ExpirationHours)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}