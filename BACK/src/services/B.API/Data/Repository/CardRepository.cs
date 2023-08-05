using B.API.Data.Repository.Interfaces;
using B.Core.Data;
using B.Models;
using Microsoft.EntityFrameworkCore;

namespace B.API.Data.Repository;

public class CardRepository : ICardRepository
{
    private readonly ApiContext _context;

    public CardRepository(ApiContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<ICollection<Card>> GetAll()
    {
        return await _context.Cards.AsNoTracking().ToListAsync();
    }

    public async Task<Card> Add(Card card)
    {
        return (await _context.Cards.AddAsync(card)).Entity;
    }

    public Card Update(Card card)
    {
        var updatedCard = _context.Cards.Update(card);

        return updatedCard.Entity;
    }

    public async Task Delete(Card card)
    {
        _context.Cards.Remove(card);
    }

    public async Task<Card> GetById(Guid id)
    {
        return await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
    }



    public void Dispose() => _context.Dispose();
}

