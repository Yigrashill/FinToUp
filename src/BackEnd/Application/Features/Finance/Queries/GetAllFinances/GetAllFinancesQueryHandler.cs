using AutoMapper;
using MediatR;
using Application.Contracts.Persistance;

namespace Application.Features.Finance.Queries.GetAllFinances;

public class GetAllFinancesQueryHandler : IRequestHandler<GetAllFinancesQuery, List<FinanceDTO>>
{
    private readonly IMapper _mapper;
    private readonly IFinanceRepository _financeRepository;

    public GetAllFinancesQueryHandler(IMapper mapper, IFinanceRepository financeRepository)
    {
        _mapper = mapper;
        _financeRepository = financeRepository;
    }

    public async Task<List<FinanceDTO>> Handle(GetAllFinancesQuery request, CancellationToken cancellationToken)
    {
        // TODO Get data from database
        var finances = await _financeRepository.GetAsync();

        var data = _mapper.Map<List<FinanceDTO>>(finances);

        return data;
    }
 }