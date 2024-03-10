using AutoMapper;
using MediatR;
using Application.Contracts.Persistance;

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
        // TODO Get data from data base
        var finance = await _financeRepository.GetByIdAsync(request.ID);

        // convert data to DTO
        var data = _mapper.Map<FinanceDTO>(finance);

        // Return single finance
        return data;
    }
}