using Microsoft.EntityFrameworkCore;
using AuthenticationService.Core.Entities;

namespace AuthenticationService.DAL.Data;

public class DatabaseContext : DbContext 
{
    public DbSet<Account>? Accounts { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) 
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<Account>().HasIndex(x => x.Username).IsUnique();
    }
}