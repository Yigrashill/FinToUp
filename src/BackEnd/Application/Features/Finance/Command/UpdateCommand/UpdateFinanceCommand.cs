using MediatR;
using Domain.Models;
using Application.Features.Finance.Queries;

namespace Application.Features.Finance.Command.UpdateCommand;

public class UpdateFinanceCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public decimal? Amount { get; set; } = 0.00M;
    public FinanceTypeDTO FinanceType { get; set; }
}
