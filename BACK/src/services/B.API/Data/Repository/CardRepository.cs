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

    public async Task<IEnumerable<Card>> GetAll()
    {
        return await _context.Cards.AsNoTracking().ToListAsync();
    }

    public Task Add(Card player)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Card player)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        Dispose();
    }



    public Task<Card> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Card> Update(Card player)
    {
        throw new NotImplementedException();
    }
}

