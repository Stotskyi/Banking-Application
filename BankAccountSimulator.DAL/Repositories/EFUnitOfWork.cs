
using BankAccountSimulator.DAL.EF;
using BankAccountSimulator.DAL.Entities;
using BankAccountSimulator.DAL.Interfaces;

namespace BankAccountSimulator.DAL.Repositories;

public class EFUnitOfWork : IUnitOfWork
{
    private AppDbContext _context;
    private UserRepository _userRepository;
    private CardRepository _cardRepository;
    private AccountRepository _accountRepository;

    public EFUnitOfWork(AppDbContext cnt)
    {
        _context = cnt;
    }

    public IRepository<User> Users
    {
        get
        {
            if (_userRepository == null)
                _userRepository = new UserRepository(_context);
            return _userRepository;
        }
    }
    public IRepository<Card> Cards
    {
        get
        {
            if (_cardRepository == null)
                _cardRepository = new CardRepository(_context);
            return _cardRepository;
        }
    }

    public IRepository<Account> Accounts
    {
        get
        {
            if (_accountRepository == null)
                _accountRepository = new AccountRepository(_context);
            return _accountRepository;
        }
    }

    public IAccountRepository AccountRepository
    {
        get
        {
            if (_accountRepository == null)
                _accountRepository = new AccountRepository(_context);
            return _accountRepository;
        }
    }

    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            this.disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

}