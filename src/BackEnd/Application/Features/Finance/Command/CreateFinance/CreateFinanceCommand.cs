using Domain.Models;
using MediatR;

namespace Application.Features.Finance.Command.CreateFinance;

public class CreateFinanceCommand : IRequest<int>
{
    public string Title { get; set; }
    public FinanceType FinanceType { get; set; }
    public decimal Amount { get; set; } = 0.00M;
}
