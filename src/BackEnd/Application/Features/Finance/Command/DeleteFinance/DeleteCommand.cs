using MediatR;

namespace Application.Features.Finance.Command.DeleteFinance;
public record DeleteFinanceCommand(int ID) : IRequest<Unit>;
