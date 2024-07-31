using BankAccountSimulator.BLL.Interfaces;

namespace BankAccountSimulator.PL.Commands.Interfaces;

public interface IAdminCommand
{
    void Execute(IUserController srv);
}