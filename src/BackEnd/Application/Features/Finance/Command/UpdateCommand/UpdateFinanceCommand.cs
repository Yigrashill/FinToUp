using MediatR;
using Domain.Models;

namespace Application.Features.Finance.Command.UpdateCommand;

public class UpdateFinanceCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public decimal? Amount { get; set; } = 0.00M;
    public FinanceType FinanceType { get; set; }
}
