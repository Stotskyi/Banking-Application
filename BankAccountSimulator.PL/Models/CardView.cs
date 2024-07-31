namespace BankAccountSimulator.PL.Models;

public class CardView
{
    public int Id { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public string ExpiryDate { get; set; } = string.Empty;
    
    public UserView User { get; set; }
    public int UserId { get; set; }
}