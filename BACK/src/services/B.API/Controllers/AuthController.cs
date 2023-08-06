using B.API.Application.Mediator.Commands;
using B.API.DTOs;
using B.Core.Controller;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace B.API.Controllers;

[Route("")]
public class AuthController : MainController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Post(LoginDTO login)
    {
        var command = GenerateTokenCommand.CreateFromDTO(login);

        return CustomResponse(await _mediator.Send(command));
    }
}

