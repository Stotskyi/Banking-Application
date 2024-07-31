using BankAccountSimulator.PL.Models;

namespace BankAccountSimulator.PL.UserInputHandlers;

public static class UserInputReader
{
    public static UserView ReadUser()
    {
        Console.WriteLine("Enter your username:");
        string username = Console.ReadLine()!;

        Console.WriteLine("Enter your Password");
        string password = Console.ReadLine()!;

        return new UserView()
        {
            Username = username,
            Password = password
        };
    }
    
}