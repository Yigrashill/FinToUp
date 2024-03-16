using MediatR;

namespace Application.Features.Finance.Queries.GetAllFinances;

public record GetAllFinancesQuery : IRequest<List<FinanceDTO>>;