using MediatR;

namespace Application.Features.Finance.Queries.GetFinances;

public record GetFinancesQuery : IRequest<List<FinanceDTO>>;