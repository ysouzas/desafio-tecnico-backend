﻿using B.API.Application.Mediator.Commands;
using B.API.Application.Mediator.Queries;
using B.API.DTOs;
using B.Core.Controller;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using B.API.Infrastructure.Filters;

namespace B.API.Controllers;

[Route("Cards")]
[Authorize]
public class CardsController : MainController
{
    private readonly IMediator _mediator;

    public CardsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var command = new GetAllCardQuery();
        return CustomResponse(await _mediator.Send(command));
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddCardDTO dto)
    {
        var command = AddCardCommand.CreateFromDTO(dto);

        return CustomResponse(await _mediator.Send(command), 201);
    }


    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Put(Guid id, UpdateCardDTO dto)
    {
        var command = UpdateCardCommand.CreateFromDTO(dto, id);

        return CustomResponse(await _mediator.Send(command), statusCodesBadRequestAlternative: 404);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Post(Guid id)
    {
        var command = DeleteCardCommand.Create(id);

        return CustomResponse(await _mediator.Send(command), statusCodesBadRequestAlternative: 404);
    }
}

