namespace BankAccountSimulator.DAL.Interfaces;

public interface IAccountRepository
{
    Task AddMoneyAsync(int id, decimal money);
    Task WithdrawMoneyAsync(int id, decimal money);
}