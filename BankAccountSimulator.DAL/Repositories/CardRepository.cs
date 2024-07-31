using BankAccountSimulator.DAL.EF;
using BankAccountSimulator.DAL.Entities;
using BankAccountSimulator.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAccountSimulator.DAL.Repositories;

public class CardRepository : IRepository<Card>
{
    private AppDbContext _context;

    public CardRepository(AppDbContext context)
    {
        _context = context;
    }

    
    public int GetTotalUsersCount()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Card>> GetAllAsync()
    {
        return await _context.Cards.ToListAsync();
    }

    public async Task<Card> GetAsync(int id)
    {
        return await _context.Cards.FindAsync(id);
    }

    public async Task<IEnumerable<Card>> FindAsync(Func<Card, bool> predicate)
    {
        return await Task.Run(() => _context.Cards.Where(predicate).ToList());
    }

    public async Task CreateAsync(Card item)
    {
        await _context.Cards.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Card item)
    {
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var card = await _context.Cards.FindAsync(id);
        if (card != null)
        {
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }
    }

    public IAsyncEnumerable<User> GetUsersByPageAsync(int id, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetTotalUsersCountAsync()
    {
        throw new NotImplementedException();
    }
}