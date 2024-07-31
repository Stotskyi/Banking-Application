using BankAccountSimulator.BLL.Interfaces;
using BankAccountSimulator.PL.Commands.Interfaces;
using BankAccountSimulator.PL.Models;

namespace BankAccountSimulator.PL.Commands.AuthorizedUserCommands;

public class WithdrawMoneyCommand : ICommand
{
    public void Execute(UserView user, IUserController userController)
    {
        var balance = ReadAmountOfMoneyInput.ReadAmountOfMoney();
       userController.WithdrawMoneyAsync(user.Account.Id, balance);
       user.Account.Balance += balance;

    }
}