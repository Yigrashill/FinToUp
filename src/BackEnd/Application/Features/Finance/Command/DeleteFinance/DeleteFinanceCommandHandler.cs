using MediatR;
using Application.Contracts.Persistance;
using Application.Contracts.Exceptions;

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

        if (deleteFinance is null)
        {
            throw new NotFoundException(nameof(Finance), request.Id);
        }

        await _financeRepository.DeleteAsync(deleteFinance);

        return Unit.Value;
    }
}