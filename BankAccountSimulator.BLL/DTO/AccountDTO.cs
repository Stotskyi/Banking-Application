using BankAccountSimulator.DAL.Entities;
namespace BankAccountSimulator.BLL.DTO;

public class AccountDTO
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
    
    public UserDTO User { get; set; }
    public int UserId { get; set; }
}