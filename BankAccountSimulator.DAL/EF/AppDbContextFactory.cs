using BankAccountSimulator.DAL.Infrastructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BankAccountSimulator.DAL.EF
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();

            var config = Configuration.BuildConfig();
            builder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

            return new AppDbContext(builder.Options);
        }
    }
}
