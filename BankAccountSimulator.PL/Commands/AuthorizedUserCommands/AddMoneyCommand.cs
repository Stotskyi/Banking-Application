using BankAccountSimulator.BLL.Interfaces;
using BankAccountSimulator.PL.Commands.Interfaces;
using BankAccountSimulator.PL.Models;

namespace BankAccountSimulator.PL.Commands.AuthorizedUserCommands;

public class AddMoneyCommand : ICommand
{
    public void Execute(UserView user,IUserController srv)
    { 
       var balance = ReadAmountOfMoneyInput.ReadAmountOfMoney();
       srv.AddMoneyAsync(user.Account.Id, balance);
       user.Account.Balance += balance;
    }

   
}