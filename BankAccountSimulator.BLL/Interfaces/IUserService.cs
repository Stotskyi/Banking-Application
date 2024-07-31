using BankAccountSimulator.BLL.DTO;

namespace BankAccountSimulator.BLL.Interfaces;

public interface IUserService
{
    Task<UserDTO> RegisterAsync(UserDTO user);
    Task<UserDTO> ValidateAsync(UserDTO user);

    Task<UserDTO> GetAsync(int id);
    Task<IEnumerable<UserDTO>> GetUsersAsync();
    IAsyncEnumerable<UserDTO> GetUsersByPageAsync(int page, int pageSize);
    Task<int> GetTotalUsersCountAsync();

    Task AddMoneyAsync(int id, decimal money);
    Task WithdrawMoneyAsync(int id, decimal money);

    void Dispose();

}