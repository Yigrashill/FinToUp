using Domain.Models;

namespace Application.Contracts.Persistance;

public interface IFinanceRepository : IGenericRepository<Finance>
{
    Task IncriseFinance(Finance finance);
}
