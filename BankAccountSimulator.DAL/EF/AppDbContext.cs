using BankAccountSimulator.DAL.Entities;
using BankAccountSimulator.DAL.Infrastructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccountSimulator.DAL.EF;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder opts)
    {
        var config = Configuration.BuildConfig();
        opts.UseNpgsql(config.GetConnectionString("DefaultConnection"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Account)
            .WithOne(a => a.User)
            .HasForeignKey<Account>(a => a.UserId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Card)
            .WithOne(c => c.User)
            .HasForeignKey<Card>(c => c.UserId);
        


            base.OnModelCreating(modelBuilder);
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Card> Cards { get; set; }
}