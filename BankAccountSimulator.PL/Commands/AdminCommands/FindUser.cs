using BankAccountSimulator.PL.Commands.IdentificationUserCommands;
using BankAccountSimulator.PL.Commands.Interfaces;

namespace BankAccountSimulator.PL.Commands.AdminCommands;

public class FindUser : IAdminCommand
{
    public void Execute(IUserController userController)
    {
        userController.FindUserAsync();
    }
}