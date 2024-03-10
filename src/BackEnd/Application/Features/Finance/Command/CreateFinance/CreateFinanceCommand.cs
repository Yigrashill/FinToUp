using Application.Contracts.Persistance;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Finance.Command.CreateFinance;


public class CreateFinanceCommand : IRequest<int>
{
    public string Title { get; set; }
    public FinanceType FinanceType { get; set; }
    public decimal Amount { get; set; } = 0.00M;
}

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
        // TODO Validate data

        // Convert object to entity domain
        var finance = _mapper.Map<Domain.Models.Finance>(request);

        // Save in database
        await _financeRepository.CreateAsync(finance); 

        return finance.Id;
    }
}