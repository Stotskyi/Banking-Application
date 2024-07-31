namespace BankAccountSimulator;

public static class ReadAmountOfMoneyInput
{
    public static decimal ReadAmountOfMoney()
    {
        Console.WriteLine("Enter a amount of money:");
        return Convert.ToDecimal(Console.ReadLine());
    }
}