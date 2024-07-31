using AutoMapper;
using BankAccountSimulator.BLL.DTO;
using BankAccountSimulator.DAL.Entities;
using BankAccountSimulator.PL.Models;

namespace BankAccountSimulator.BLL.Infrastructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
        CreateMap<UserDTO, UserView>();
        CreateMap<UserView, UserDTO>();
        
        CreateMap<Card, CardDTO>();
        CreateMap<CardDTO, Card>();
        CreateMap<CardView, CardDTO>();
        CreateMap<CardDTO, CardView>();

        CreateMap<Account, AccountDTO>();
        CreateMap<AccountDTO, Account>();
        CreateMap<AccountView, AccountDTO>();
        CreateMap<AccountDTO, AccountView>();

    }
}

