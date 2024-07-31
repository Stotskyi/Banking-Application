using BankAccountSimulator;
using BankAccountSimulator.BLL.Interfaces;
using BankAccountSimulator.DAL.Entities;
using BankAccountSimulator.PL.Commands;
using BankAccountSimulator.PL.Models;
using Spectre.Console;

namespace BankAccountSimulator.PL.UI;

public static  class UIManager
{

    enum LoginPage
    {
        Login = 1,
        Register = 2
    }

    enum AdminOptions
    {
        ViewUsers = 1,
        FindUser = 2,
        UpdateUser = 3,
        DeleteUser = 4,
        Quit
    }

    enum MenuPage
    {
        AddMoney = 1,
        WithdrawMoney = 2,
        Quit = 3
    }

    public static  void DisplayLoginPage(IUserController userController)
    {
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<LoginPage>()
                .Title("Login Page")
                .HighlightStyle(new Style(Color.Green)) 
                .AddChoices(
                   LoginPage.Login,
                   LoginPage.Register));
        
            var commandHandler = CommandsFactory.BuildIdentificationCommand((int)option);
            var user = commandHandler.Execute(userController).Result;

            
            if(user is{Username: "admin", Password: "admin"})
                DisplayAdminPage(userController);
            DisplayMenuPage(user,userController);
    }
  
    public static void DisplayAdminPage(IUserController userController)
    {
        bool isAppRunning = true;
        while (isAppRunning)
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<AdminOptions>()
                    .Title("Admin Page")
                    .HighlightStyle(new Style(Color.Green)) 
                    .AddChoices(
                        AdminOptions.ViewUsers,
                        AdminOptions.FindUser,
                        AdminOptions.UpdateUser,
                        AdminOptions.DeleteUser,
                        AdminOptions.Quit));
            var commandHandler = CommandsFactory.BuildAdminCommand((int)option);
            commandHandler.Execute(userController);
        }
    }
    public static void  DisplayMenuPage(UserView a,IUserController srv)
    {
        while (true)
        {
            
            Console.WriteLine($"Balance:{a.Account.Balance}");
           
            
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuPage>()
                    .Title("Menu Page")
                    .HighlightStyle(new Style(Color.Green)) 
                    .AddChoices(
                        MenuPage.AddMoney,
                        MenuPage.WithdrawMoney,
                        MenuPage.Quit));
            
                var commandHandler = CommandsFactory.BuildAuthorizedCommand((int)option);
                commandHandler.Execute(a,srv);
           
                
        }
    }
}

