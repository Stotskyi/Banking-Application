using BankAccountSimulator.PL.Commands.Interfaces;

namespace BankAccountSimulator.PL.Commands.AdminCommands;

public class ViewUsers : IAdminCommand
{
    public void Execute(IUserController userController)
    {
        userController.ViewUsersAsync();
    }
}