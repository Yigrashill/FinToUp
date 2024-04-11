using AutoMapper;
using MediatR;
using Application.Contracts.Persistance;
using Application.Contracts.Exceptions;

namespace Application.Features.Finance.Command.CreateFinance;

public class CreateFinanceCommandHandler : IRequestHandler<CreateFinanceCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IFinanceRepository _financeRepository;

    public CreateFinanceCommandHandler(IMapper mapper, IFinanceRepository financeRepository)
    {
        _mapper = mapper;
        _financeRepository = financeRepository;
    }

    public async Task<int> Handle(CreateFinanceCommand request, CancellationToken cancellationToken)
    {
        // TODO make validator like common service
        // TODO crerate validate service and inject in contructor

        // Validate data
        var validator = new CreateFinanceCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Any())
        {
            throw new ValidationException("Create new finance: ", validationResult);
        }

        // Convert object to entity domain
        var finance = _mapper.Map<Domain.Models.Finance>(request);

        // Save in database
        await _financeRepository.CreateAsync(finance); 

        return finance.Id;
    }
}