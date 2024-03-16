using MediatR;

namespace Application.Features.Finance.Queries.GetFinance;

public record GetFinanceQuery(int ID) : IRequest<FinanceDTO>;