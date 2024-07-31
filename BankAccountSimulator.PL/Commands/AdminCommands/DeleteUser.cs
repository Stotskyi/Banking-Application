using BankAccountSimulator.PL.Commands.IdentificationUserCommands;
using BankAccountSimulator.PL.Commands.Interfaces;

namespace BankAccountSimulator.PL.Commands.AdminCommands;

public class DeleteUser : IAdminCommand
{
    public void Execute(IUserController srv)
    {
        throw new NotImplementedException();
    }
}