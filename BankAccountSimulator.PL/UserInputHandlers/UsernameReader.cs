using Spectre.Console;

namespace BankAccountSimulator.PL.UserInputHandlers;

public static class UsernameReader
{
    public static string ReadUsername()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>("Enter username to find:"));
    }
}