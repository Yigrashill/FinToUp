using Domain.Models;
using Domain.Models.Common;
using Microsoft.EntityFrameworkCore;

public class FinanceDataBaseContext :DbContext
{
    public FinanceDataBaseContext(DbContextOptions<FinanceDataBaseContext> options)
        :base(options)
    {
    }

    public DbSet<Finance>  Finances { get; set; }

    public DbSet<MonthlyStatement> MonthlyStatements { get; set; }


    public override Task<int> SaveChangesAsync( CancellationToken cancellationToken = default)
    {
        foreach (var entity in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State == EntityState.Modified || q.State == EntityState.Added)
            ) 
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
