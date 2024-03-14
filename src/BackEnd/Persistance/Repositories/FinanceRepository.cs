using Application.Contracts.Persistance;
using Domain.Models;

namespace Persistance.Repositories;

public class FinanceRepository : GenericReporitory<Finance>, IFinanceRepository
{
    public FinanceRepository(FinanceDataBaseContext context) 
        : base(context)
    {
    }

    public async Task IncriseFinance(Finance finance)
    {
        _context.Update(finance);
        await _context.SaveChangesAsync();
    }
}
