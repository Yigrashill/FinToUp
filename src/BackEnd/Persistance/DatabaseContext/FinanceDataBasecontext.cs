using Domain.Models;
using Domain.Models.Common;
using Microsoft.EntityFrameworkCore;

public class FinanceDataBaseContext : DbContext
{
    public FinanceDataBaseContext(DbContextOptions<FinanceDataBaseContext> options)
        : base(options)
    {
    }

    public DbSet<Finance> Finances { get; set; }

    public DbSet<MonthlyStatement> MonthlyStatements { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinanceDataBaseContext).Assembly);

        // TODO add MonthStatement and then add Finance records
        // For simple use and start working whit data base we focus ony simple Finance records 
        // with no relations bettwen tables.

        modelBuilder.Entity<Finance>().HasData(
            new Finance
            {
                Id = 1,
                Title = "Biedronka",
                Createrd = DateTime.Now,
                FinanceType = FinanceType.Liabilities,
                Amount = -100.00M
            },
            new Finance
            {
                Id = 2,
                Title = "Wypłata",
                Createrd = DateTime.UtcNow,
                FinanceType = FinanceType.Assets,
                Amount = 1000.00M
            }
            );

        base.OnModelCreating(modelBuilder);
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entity in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State == EntityState.Modified || q.State == EntityState.Added))
        {
            entity.Entity.Updated = DateTime.Now;

            if (entity.State == EntityState.Added)
            {
                entity.Entity.Createrd = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
