using MediatR;
using AutoMapper;
using Application.Contracts.Persistance;

namespace Application.Features.Finance.Command.UpdateCommand;

public class UpdateFinance : IRequestHandler<UpdateFinanceCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IFinanceRepository _financeRepository;

    public UpdateFinance(IMapper mapper, IFinanceRepository financeRepository)
    {
        _mapper = mapper;
        _financeRepository = financeRepository;
    }

    public async Task<Unit> Handle(UpdateFinanceCommand request, CancellationToken cancellationToken)
    {
        // TODO Validate data

        var financeToUpdate = _mapper.Map<Domain.Models.Finance>(request);
        await _financeRepository.UpdateAsync(financeToUpdate);

        return Unit.Value;
    }
}