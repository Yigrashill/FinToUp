using Application.Contracts.Persistance;
using Domain.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories;

public class GenericReporitory<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly FinanceDataBaseContext _context;

    public GenericReporitory(FinanceDataBaseContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
         _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
