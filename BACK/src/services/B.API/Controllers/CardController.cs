﻿using B.API.Application.Mediator.Queries;
using B.API.Data.Repository.Interfaces;
using B.Core.Controller;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace B.API.Controllers;

[Route("Cards")]
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
}

