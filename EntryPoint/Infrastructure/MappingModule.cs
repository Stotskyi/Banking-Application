using AutoMapper;
using BankAccountSimulator.BLL.Services;
using Ninject.Modules;

namespace BankAccountSimulator.BLL.Infrastructure;

public class MappingModule : NinjectModule
{
    public override void Load()
    {
        var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
        this.Bind<IMapper>().ToConstructor(c => new Mapper((mapperConfig))).InSingletonScope();
        this.Bind<UserServices>().ToSelf().InSingletonScope();
        
    }
}