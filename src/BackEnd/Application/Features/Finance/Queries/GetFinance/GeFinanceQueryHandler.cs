using AutoMapper;
using MediatR;
using Application.Contracts.Persistance;
using Application.Contracts.Exceptions;

namespace Application.Features.Finance.Queries.GetFinance;

public class GeFinanceQueryHandler : IRequestHandler<GetFinanceQuery, FinanceDTO>
{
    private readonly IMapper _mapper;
    private readonly IFinanceRepository _financeRepository;

    public GeFinanceQueryHandler(IMapper mapper, IFinanceRepository financeRepository)
    {
        _mapper = mapper;
        _financeRepository = financeRepository;
    }

    public async Task<FinanceDTO> Handle(GetFinanceQuery request, CancellationToken cancellationToken)
    {
        var finance = await _financeRepository.GetByIdAsync(request.ID);

        if (finance is null)
        {
            throw new NotFoundException(nameof(Finance), request.ID);
        }

        // convert data to DTO
        var data = _mapper.Map<FinanceDTO>(finance);

        // Return single finance
        return data;
    }
}