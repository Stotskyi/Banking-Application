namespace BankAccountSimulator.BLL.Infrastructure;

public class ValidationException : Exception
{
    public string Property { get; protected set; }

    public ValidationException(string message, string prop)
    {
        Property = prop;
    }
}