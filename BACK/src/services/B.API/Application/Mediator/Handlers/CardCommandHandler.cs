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
                                                  IRequestHandler<AddCardCommand, CommandResponse<CardDTO>>,
                                                  IRequestHandler<UpdateCardCommand, CommandResponse<CardDTO>>,
                                                  IRequestHandler<DeleteCardCommand, CommandResponse<CardDTO[]>>


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

    public async Task<CommandResponse<CardDTO>> Handle(AddCardCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return new(default, request.ValidationResult);

        var card = new Card(request.Titulo, request.Conteudo, request.Lista);

        var cardFromDatabase = await _cardRepository.Add(card);

        var result = await PersistData(_cardRepository.UnitOfWork);

        return result.IsValid ? CommandResponse<CardDTO>.Create(cardFromDatabase.ToCardDTO()) : CommandResponse<CardDTO>.Create(default, result);
    }

    public async Task<CommandResponse<CardDTO>> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return new(default, request.ValidationResult);

        var card = await _cardRepository.GetById(request.Id);

        if (card is null)
        {
            var validation = new ValidationResult();

            validation.Errors.Add(new ValidationFailure("Id", "Card doenst exist"));
            return CommandResponse<CardDTO>.Create(default, validation, true);
        }

        card.Conteudo = request.Conteudo;
        card.Lista = request.Lista;
        card.Titulo = request.Titulo;

        var updatedCard = _cardRepository.Update(card);

        var result = await PersistData(_cardRepository.UnitOfWork);

        return result.IsValid ? CommandResponse<CardDTO>.Create(updatedCard.ToCardDTO()) : CommandResponse<CardDTO>.Create(default, result);
    }

    public async Task<CommandResponse<CardDTO[]>> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid()) return new(default, request.ValidationResult);

        var card = await _cardRepository.GetById(request.Id);

        if (card is null)
        {
            var validation = new ValidationResult();

            validation.Errors.Add(new ValidationFailure("Id", "Card doenst exist"));
            return CommandResponse<CardDTO[]>.Create(default, validation, true);
        }

        await _cardRepository.Delete(card);

        var result = await PersistData(_cardRepository.UnitOfWork);

        var cardsFromDatabase = await _cardRepository.GetAll();

        var cardsDTO = cardsFromDatabase.ToCardDTO();

        return result.IsValid ? CommandResponse<CardDTO[]>.Create(cardsDTO) : CommandResponse<CardDTO[]>.Create(default, result);
    }
}

