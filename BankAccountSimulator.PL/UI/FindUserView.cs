using BankAccountSimulator.PL.Models;
using Spectre.Console;

namespace BankAccountSimulator.PL.UI;

public static class FindUserView
{
   public static void DisplayUserTable(List<UserView> usersToDisplay)
    {
        var table = new Table().BorderColor(Color.Grey);

        table.AddColumn(new TableColumn("ID").Centered());
        table.AddColumn(new TableColumn("Username").Centered());
        table.AddColumn(new TableColumn("Balance").Centered());

        foreach (var user in usersToDisplay)
        {
            table.AddRow(user.Id.ToString(), user.Username,user.Account.Balance.ToString());
        }

        AnsiConsole.Render(table);
    }
  

    public static void DisplaySearchUser(UserView foundUser)
    {
        if (foundUser != null)
        {
            AnsiConsole.MarkupLine($"[bold]Found User:[/]");
            DisplayUserTable(new List<UserView> { foundUser });
        }
        else
        {
            AnsiConsole.MarkupLine($"[italic red]User with username  not found.[/]");
        }
        
    }
}