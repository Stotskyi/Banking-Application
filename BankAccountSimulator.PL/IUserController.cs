using BankAccountSimulator.PL.Models;

namespace BankAccountSimulator.PL;

public interface IUserController
{
    public Task<UserView> ValidateAsync(UserView user);
    public Task<UserView> RegisterAsync(UserView user);
    public Task<UserView> GetAsync(int id);

    Task AddMoneyAsync(int accountid, decimal money);
    Task WithdrawMoneyAsync(int accountId, decimal balance);
    Task FindUserAsync();
    void UpdateUserAsync();
    void DeleteUserAsync();
    Task ViewUsersAsync();
}