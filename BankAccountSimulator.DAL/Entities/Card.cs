namespace BankAccountSimulator.DAL.Entities;

public class Card
{
    public Card()
    {
        CardNumber = new Random().Next(10000000, 50000000).ToString() +
                     new Random().Next(50000000, 99999999).ToString();
        ExpiryDate = DateTime.Now.ToString("MM/yyyy");
    }

    public int Id { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public string ExpiryDate { get; set; } = string.Empty;
    
    public int UserId { get; set; }
    public User User { get; set; }
}