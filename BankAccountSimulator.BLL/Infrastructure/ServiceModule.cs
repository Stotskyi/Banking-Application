using BankAccountSimulator.DAL.Interfaces;
using BankAccountSimulator.DAL.Repositories;
using Ninject.Modules;

namespace BankAccountSimulator.BLL.Infrastructure;

public class ServiceModule : NinjectModule
{
    private readonly string connection;

    public ServiceModule(string connection)
    {
        this.connection = connection;
    }

    public override void Load()
    {
        Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connection);
    }
}