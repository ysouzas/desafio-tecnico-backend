using B.API.Application.Mediator.Queries;
using B.API.Data.Repository.Interfaces;
using B.Core.Messages;
using B.Models;
using MediatR;

namespace B.API.Application.Mediator.Handlers;

public class CardCommandHandler : CommandHandler, IRequestHandler<GetAllCardQuery, CommandResponse<Card[]>>

{
    private readonly ICardRepository _cardRepository;

    public CardCommandHandler(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<CommandResponse<Card[]>> Handle(GetAllCardQuery request, CancellationToken cancellationToken)
    {
        var cardsFromDatabase = await _cardRepository.GetAll();

        return CommandResponse<Card[]>.Create(cardsFromDatabase.ToArray());
    }
}

