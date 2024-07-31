using BankAccountSimulator.BLL.Interfaces;
using BankAccountSimulator.BLL.Services;
using Ninject.Modules;

namespace BankAccountSimulator.BLL.Util;

public class UserModule : NinjectModule
{
    public override void Load()
    {
        Bind<IUserService>().To<UserServices>();
    }
}