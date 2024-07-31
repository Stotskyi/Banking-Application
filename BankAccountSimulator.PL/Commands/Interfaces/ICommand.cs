using BankAccountSimulator.BLL.Interfaces;
using BankAccountSimulator.PL.Models;

namespace BankAccountSimulator.PL.Commands.Interfaces;

public interface ICommand
{
    public void Execute(UserView user,IUserController srv);
}