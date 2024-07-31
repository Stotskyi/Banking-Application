using BankAccountSimulator.DAL.Entities;

namespace BankAccountSimulator.BLL.DTO;

public class UserDTO
{
    public int Id { get; set; }
    
    public string Username { get; set; }

    public string Password { get; set; }
    
    public CardDTO Card { get; set; }

    public AccountDTO Account { get; set; }
}