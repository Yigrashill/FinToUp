using AutoMapper;
using MediatR;
using Application.Contracts.Persistance;
using Application.Contracts.Exceptions;
using Application.Contracts.Logging;

namespace Application.Features.Finance.Queries.GetFinances;

public class GetFinancesQueryHandler : IRequestHandler<GetFinancesQuery, List<FinanceDTO>>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetFinancesQueryHandler> _logger;
    private readonly IFinanceRepository _financeRepository;

    public GetFinancesQueryHandler(IMapper mapper, IAppLogger<GetFinancesQueryHandler> logger, IFinanceRepository financeRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _financeRepository = financeRepository;
    }

    public async Task<List<FinanceDTO>> Handle(GetFinancesQuery request, CancellationToken cancellationToken)
    {
        // TODO Get data from database
        var finances = await _financeRepository.GetAsync();
        
        // Throw new exception when is no data in repository;
        if (finances is null)
        {
            _logger.LogInformation("$\"{name} in now wos not found\"");
            throw new NotFoundException(nameof(Finance), nameof(GetFinancesQueryHandler));
        }

        var data = _mapper.Map<List<FinanceDTO>>(finances);

        _logger.LogInformation("Finances wos return successfully");
        return data;
    }
 }