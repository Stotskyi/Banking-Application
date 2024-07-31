namespace BankAccountSimulator.BLL.DTO;

public class CardDTO
{
    public int Id { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public string ExpiryDate { get; set; } = string.Empty;
    public UserDTO User { get; set; }
    public int UserId { get; set; }
}