using AutoMapper;
using BankAccountSimulator.BLL.DTO;
using BankAccountSimulator.BLL.Interfaces;
using BankAccountSimulator.DAL.EF;
using BankAccountSimulator.PL.Commands.Interfaces;
using BankAccountSimulator.PL.Models;
using BankAccountSimulator.PL.UserInputHandlers;

namespace BankAccountSimulator.PL.Commands.IdentificationUserCommands;

public class RegisterUserCommand : IIdentificationCommand
{
    public RegisterUserCommand()
    {
        
    }

    public async Task<UserView> Execute(IUserController userService)
    {
        return await userService.RegisterAsync(UserInputReader.ReadUser());
    }

    
}