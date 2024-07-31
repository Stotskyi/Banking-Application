using BankAccountSimulator.DAL.EF;
using BankAccountSimulator.DAL.Entities;
using BankAccountSimulator.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAccountSimulator.DAL.Repositories;

public class UserRepository : IRepository<User>
{
    private AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.Include(u => u.Account)
            .Include(u => u.Card)
            .ToListAsync();
    }

    public async Task<User> GetAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async  Task<IEnumerable<User>> FindAsync(Func<User, bool> predicate)
    {
        return await Task.Run(() =>  _context.Users.Include(u => u.Account)
            .Include(u => u.Card)
            .Where(predicate));
    }

    public async Task CreateAsync(User item)
    {
        await _context.Users.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User item)
    {
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async IAsyncEnumerable<User> GetUsersByPageAsync(int page, int pageSize)
    {
        var a = _context.Users.Include(u => u.Account)
            .Include(u => u.Card)
            .OrderBy(u => u.Username)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        foreach (var u in a)
        {
            yield return u;
        }
        
    }

    public async Task<int> GetTotalUsersCountAsync()
    {
        return await _context.Users.CountAsync();
    }
}
