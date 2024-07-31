using BankAccountSimulator.PL;
using Ninject.Modules;

namespace EntryPoint;

public class UIModel : NinjectModule
{
    public override void Load()
    {
        Bind<IUserController>().To<UserController>();
    }
}
