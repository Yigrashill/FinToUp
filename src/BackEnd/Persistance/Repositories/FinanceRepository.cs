using Application.Contracts.Persistance;
using Domain.Models;

namespace Persistance.Repositories;

public class FinanceRepository : GenericReporitory<Finance>, IFinanceRepository
{
    private readonly IGenericRepository<Finance> _generic;

    public FinanceRepository(FinanceDataBaseContext context, IGenericRepository<Finance> generic) 
        : base(context)
    {
        _generic = generic;
    }

    public Task<Finance> GetFinanceDetails(int id)
    {
        var fin = _generic.GetByIdAsync(id);
        return fin;
    }

    public async Task IncriseFinance(int id, decimal incrise = 0.00M)
    {
        var fin = await _generic.GetByIdAsync(id);
        fin.Amount += incrise;
        _context.Update(fin);

        await _context.SaveChangesAsync();
    }


    public async Task DeketeFinance(int id)
    {
        var finance = await _generic.GetByIdAsync(id);
        _context.Remove(finance);

        await _context.SaveChangesAsync();
    }

}
