using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext
    (
        DbContextOptions<DatabaseContext> options
    )   : base(options)
    {
        
    }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder){
        builder.Entity<Person>(entity =>{
            entity.HasKey(e => e.Id);
            entity
                .HasMany(e => e.contracts)
                .WithOne()
                .HasForeignKey(c => c.PersonId);
        });
        builder.Entity<Contract>(entity =>{
            entity.HasKey(e => e.Id);
        });
    }

}