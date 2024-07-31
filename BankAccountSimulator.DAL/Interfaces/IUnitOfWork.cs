using BankAccountSimulator.DAL.Entities;

namespace BankAccountSimulator.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Card> Cards { get; }
    IRepository<Account> Accounts { get; }
    
    IAccountRepository AccountRepository { get; }
    
}