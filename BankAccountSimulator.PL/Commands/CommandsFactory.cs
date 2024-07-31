
using BankAccountSimulator.PL.Commands.AdminCommands;
using BankAccountSimulator.PL.Commands.AuthorizedUserCommands;
using BankAccountSimulator.PL.Commands.IdentificationUserCommands;
using BankAccountSimulator.PL.Commands.Interfaces;

namespace BankAccountSimulator.PL.Commands;

public static class CommandsFactory
{

    public static IIdentificationCommand BuildIdentificationCommand(int command)
        => command switch
        {
            1 => new ValidateUserCommand(),
            2 => new RegisterUserCommand(),
        };

    public static ICommand BuildAuthorizedCommand(int command)
        => command switch
        {
            1 => new AddMoneyCommand(),
            2 => new WithdrawMoneyCommand(),
        };

    public static IAdminCommand BuildAdminCommand(int command)
        => command switch
        {
            1 => new ViewUsers(),
            2 => new FindUser(),
            3 => new UpdateUser(),
            4 => new DeleteUser(),
        };
}