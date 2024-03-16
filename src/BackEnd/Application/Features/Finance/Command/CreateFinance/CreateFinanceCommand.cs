using Application.Features.Finance.Queries;
using MediatR;

namespace Application.Features.Finance.Command.CreateFinance;

public class CreateFinanceCommand : IRequest<int>
{
    public string? Title { get; set; }
    public decimal? Amount { get; set; } = 0.00M;
    public FinanceTypeDTO FinanceType { get; set; }
}