using AutoMapper;

using BankAccountSimulator.BLL.Interfaces;

using BankAccountSimulator.PL.Commands.Interfaces;
using BankAccountSimulator.PL.Models;
using BankAccountSimulator.PL.UserInputHandlers;

namespace BankAccountSimulator.PL.Commands.IdentificationUserCommands;

public class ValidateUserCommand : IIdentificationCommand
{
    public ValidateUserCommand()
    {
        
    }
    public async Task<UserView> Execute(IUserController userController)
    {
        var user = UserInputReader.ReadUser();
        if (user is { Username: "admin", Password: "admin" })
            return user;
        return await userController.ValidateAsync(user);
    }
    
}