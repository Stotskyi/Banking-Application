namespace BankAccountSimulator.PL.Models;

public class AccountView
{
    public int Id { get; set; }
    public decimal Balance { get; set; }

    public int UserId { get; set; }
    public UserView User { get; set; }
}