using B.API.Application.Mediator.Commands;
using B.API.Application.Mediator.Queries;
using B.API.Data.Repository.Interfaces;
using B.API.DTOs;
using B.API.Extentions;
using B.Core.Messages;
using B.Models;
using FluentValidation.Results;
using MediatR;

namespace B.API.Application.Mediator.Handlers;

public class CardCommandHandler : CommandHandler, IRequestHandler<GetAllCardQuery, CommandResponse<CardDTO[]>>,
                                                  IRequestHandler<AddCardCommand, ValidationResult>

{
    private readonly ICardRepository _cardRepository;

    public CardCommandHandler(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<CommandResponse<CardDTO[]>> Handle(GetAllCardQuery request, CancellationToken cancellationToken)
    {
        var cardsFromDatabase = await _cardRepository.GetAll();

        var cardsDTO = cardsFromDatabase.ToCardDTO();

        return CommandResponse<CardDTO[]>.Create(cardsDTO.ToArray());
    }

    public async Task<ValidationResult> Handle(AddCardCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return request.ValidationResult;

        Card card = new(request.Titulo, request.Conteudo, request.Lista);

        await _cardRepository.Add(card);

        return await PersistData(_cardRepository.UnitOfWork);
    }
}

