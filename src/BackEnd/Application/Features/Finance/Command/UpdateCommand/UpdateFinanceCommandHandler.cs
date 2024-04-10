using MediatR;
using AutoMapper;
using Application.Contracts.Persistance;
using Application.Contracts.Exceptions;

namespace Application.Features.Finance.Command.UpdateCommand;

public class UpdateFinanceCommandHandler : IRequestHandler<UpdateFinanceCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IFinanceRepository _financeRepository;

    public UpdateFinanceCommandHandler(IMapper mapper, IFinanceRepository financeRepository)
    {
        _mapper = mapper;
        _financeRepository = financeRepository;
    }

    public async Task<Unit> Handle(UpdateFinanceCommand request, CancellationToken cancellationToken)
    {
        // TODO make validator like common service
        // TODO crerate validate service and inject in contructor

        // Find or not found
        var existingFinance = await _financeRepository.GetByIdAsync(request.Id);
        if (existingFinance is null)
        {
            throw new NotFoundException(nameof(Finance), request.Id);
        }

        // Validate data
        var validator = new UpdateFinanceCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Any()) 
        {
            throw new ValidationException("Update new finance: ", validationResult);
        }

        var financeToUpdate = _mapper.Map<Domain.Models.Finance>(request);
        await _financeRepository.UpdateAsync(financeToUpdate);

        return Unit.Value;
    }
}