using Domain.Models;

namespace Application.Contracts.Persistance;

public interface IFinanceRepository : IGenericRepository<Finance>
{
    Task IncriseFinance(int id, decimal incrise = 0.00M);

    Task<Finance> GetFinanceDetails(int id);
}
