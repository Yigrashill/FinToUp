using Domain.Models;
using Microsoft.EntityFrameworkCore;

public class FinanceDataBaseContext :DbContext
{
    public FinanceDataBaseContext(DbContextOptions<FinanceDataBaseContext> options)
        :base(options)
    {
    }

    public DbSet<Finance>  Finances { get; set; }

    public DbSet<MonthlyStatement> MonthlyStatements { get; set; }



}
