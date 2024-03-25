using AutoMapper;
using MediatR;
using Application.Contracts.Persistance;
using Application.Contracts.Exceptions;
using Application.Contracts.Logging;

namespace Application.Features.Finance.Queries.GetFinance;

public class GeFinanceQueryHandler : IRequestHandler<GetFinanceQuery, FinanceDTO>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<GeFinanceQueryHandler> _logger;
    private readonly IFinanceRepository _financeRepository;

    public GeFinanceQueryHandler(IMapper mapper, IAppLogger<GeFinanceQueryHandler> logger, IFinanceRepository financeRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _financeRepository = financeRepository;
    }

    public async Task<FinanceDTO> Handle(GetFinanceQuery request, CancellationToken cancellationToken)
    {
        var finance = await _financeRepository.GetByIdAsync(request.ID);

        if (finance is null)
        {
            _logger.LogWarning(nameof(Finance), request.ID);
            throw new NotFoundException(nameof(Finance), request.ID);
        }

        // convert data to DTO
        var data = _mapper.Map<FinanceDTO>(finance);
        _logger.LogInformation($"Retrun data from {nameof(GetFinanceQuery)}: ({request.ID})");

        // Return single finance
        return data;
    }
}