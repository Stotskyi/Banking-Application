using BankAccountSimulator.DAL.EF;
using BankAccountSimulator.DAL.Entities;
using BankAccountSimulator.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAccountSimulator.DAL.Repositories;

public class AccountRepository : IRepository<Account>, IAccountRepository
{
    private AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Account>> GetAllAsync() => await _context.Accounts.ToListAsync();
    public async Task<Account> GetAsync(int id) => await _context.Accounts.FindAsync(id);

    public async Task<IEnumerable<Account>> FindAsync(Func<Account, bool> predicate) => await _context.Accounts.Where(predicate).AsQueryable().ToListAsync();
    

    public async Task CreateAsync(Account item)
    {
        await _context.Accounts.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Account item)
    {
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account != null)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }

    public IAsyncEnumerable<User> GetUsersByPageAsync(int id, int pageSize)
    {
       
        throw new NotImplementedException();
    }

    public async Task<int> GetTotalUsersCountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddMoneyAsync(int id, decimal money)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account != null)
        {
            account.Balance += money;
            await _context.SaveChangesAsync();
        }
    }

    public async Task WithdrawMoneyAsync(int id, decimal money)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account != null)
        {
            account.Balance -= money;
            await _context.SaveChangesAsync();
        }
    }
}