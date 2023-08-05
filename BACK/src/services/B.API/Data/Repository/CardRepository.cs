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

    public async Task Add(Card card)
    {
        await _context.Cards.AddAsync(card);
    }

    public Task Delete(Card card)
    {
        throw new NotImplementedException();
    }

    public Task<Card> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Card> Update(Card card)
    {
        throw new NotImplementedException();
    }

    public void Dispose() => _context.Dispose();
}

