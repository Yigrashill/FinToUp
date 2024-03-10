using MediatR;
using Application.Contracts.Persistance;

namespace Application.Features.Finance.Command.DeleteFinance;

public class DeleteFinanceCommandHandler :IRequestHandler<DeleteCommand, Unit>
{
    private readonly IFinanceRepository _financeRepository;

    public DeleteFinanceCommandHandler( IFinanceRepository financeRepository)
    {
        _financeRepository = financeRepository;
    }

    public async Task<Unit> Handle(DeleteCommand request,CancellationToken cancellationToken)
    {
        var deleteFinance = await _financeRepository.GetByIdAsync(request.Id);

        // TODO what hapend whan item dont exist in database

        await _financeRepository.DeleteAsync(deleteFinance);

        return Unit.Value;
    }
}