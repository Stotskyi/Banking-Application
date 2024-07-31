namespace BankAccountSimulator.PL.Models;

public class UserView
{
    
    public int Id { get; set; }
    
    public string Username { get; set; }

    public string Password { get; set; }
    
    public AccountView Account { get; set; }
    
    public CardView Card { get; set; }
    
}