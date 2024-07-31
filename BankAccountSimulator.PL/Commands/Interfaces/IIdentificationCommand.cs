using BankAccountSimulator.BLL.Interfaces;
using BankAccountSimulator.PL.Models;

namespace BankAccountSimulator.PL.Commands.Interfaces;

public interface IIdentificationCommand
{
    public Task<UserView> Execute(IUserController srv);
}