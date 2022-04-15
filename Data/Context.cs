using ExceptionTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ExceptionTest.Data;

public class Context : DbContext
{
    private readonly string connectionString;
    public DbSet<CarCategory> CarCategory { get; set; }
    public DbSet<Car> Car { get; set; }
    
    public Context(string connectionString)
    {
        this.connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(opt =>
        {
            opt.HasKey(x => x.Id);
            opt.HasIndex(x => x.Name).IsUnique(true);
            opt.HasOne(x => x.CarCategory).WithMany(x => x.Cars).HasForeignKey(x => x.CategoryId);
        });

        modelBuilder.Entity<CarCategory>(opt =>
        {
            opt.HasKey(x => x.Id);
            opt.HasIndex(x => x.Name);
            opt.HasMany(x => x.Cars).WithOne(x => x.CarCategory);
        });
    }

    public override int SaveChanges()
    {
        var result = base.SaveChanges();

        this.ChangeTracker.Clear();
        GC.SuppressFinalize(this);

        return result;
    }
}