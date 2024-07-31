using BankAccountSimulator.BLL.Infrastructure;
using BankAccountSimulator.BLL.Interfaces;
using BankAccountSimulator.BLL.Services;
using BankAccountSimulator.BLL.Util;
using BankAccountSimulator.DAL.EF;
using BankAccountSimulator.PL;
using BankAccountSimulator.PL.UI;
using Ninject;
using Ninject.Modules;

namespace EntryPoint;

public class Program
{
    public static void Main()
    {
        NinjectModule serviceModule = new ServiceModule(@"Host=localhost;Database=Bankdb;Username=admin;Password=admin");
        var kernel = new StandardKernel( new UserModule(), serviceModule,new MappingModule(),new UIModel(), new DataAccessModule());
        
        IUserController userController = kernel.Get<UserController>();
        UIManager.DisplayLoginPage(userController);
    }

}
public class DataAccessModule : NinjectModule
{
    public override void Load()
    {
        Bind<AppDbContext>().ToSelf().InSingletonScope();
    }
}